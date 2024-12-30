using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SayimBirlestir
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        private DateTime lastInteractionTime;
        public static frmMain Instance { get; private set; }
        public frmMain()
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "McSkin";
            DefaultLookAndFeel defaultLookAndFeel = new DefaultLookAndFeel();
            defaultLookAndFeel.LookAndFeel.SkinName = "McSkin";
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
            try
            {
                SplashScreen();
                InitializeComponent();
                lastInteractionTime = DateTime.Now;
                Instance = this;
            }
            catch (Exception exp)
            {
                CustomMessageBox.ShowMessage(exp.Message, exp.ToString(), this, "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            finally
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false, 500, this);
            }
        }
        SqlConnectionObject conn = new SqlConnectionObject();
        SqlConnection sql = new SqlConnection(Properties.Settings.Default.connectionstring);

        void SplashScreen()
        {
            FluentSplashScreenOptions splashScreen = new FluentSplashScreenOptions();
            splashScreen.Title = "YÖN AVM";
            splashScreen.Subtitle = "YÖN avm® Volant İşlem Düzeltme";
            splashScreen.RightFooter = "Başlıyor...";
            splashScreen.LeftFooter = $"CopyRight ® 2023 {Environment.NewLine} Tüm Hahkları Saklıdır.";
            splashScreen.LoadingIndicatorType = FluentLoadingIndicatorType.Dots;
            splashScreen.OpacityColor = System.Drawing.Color.FromArgb(16, 110, 190);
            splashScreen.Opacity = 90;
            splashScreen.AppearanceLeftFooter.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowFluentSplashScreen(splashScreen, parentForm: this, useFadeIn: true, useFadeOut: true);
        }
        private bool isLockForm = false;

        private IslemReturnDlg IslemReturnHandler;
        private delegate void IslemReturnDlg(int durum);
        private frmKilitEkrani kilitForm = null;
        public void IslemReturn(int durum)
        {
            try
            {
                if (durum == 1)
                {
                    this.Enabled = true;
                    isLockForm = false;
                }
            }
            catch (Exception exp)
            {
                CustomMessageBox.ShowMessage("", exp.ToString(), this, "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }
        private const int idleThresholdSeconds = 600; // Kullanıcının etkileşimde bulunmadığı süre eşiği (saniye cinsinden)
        public static int idleCounter = 0;
        public void ResetIdleCounter()
        {
            idleCounter = 0;
        }
        //arka plan işlemleri
        private BackgroundWorker _backgroundWorker;
        private ManualResetEvent _workerCompletedEvent = new ManualResetEvent(false);
        private const string READY_TEXT = "Hazır";
        private void executeBackground(Action doWorkAction, Action progressAction = null, Action completedAction = null)
        {
            try
            {
                if (_backgroundWorker != null)
                {


                    if (_backgroundWorker.IsBusy)
                    {
                        //XtraMessageBox.Show("Her oturum açıldığında 1 işlem yapacak. Eğer bu girişteki ilk işlemse uygulama çalışmaktadır. Lütfen Bekleyiniz");
                        return;
                    }
                }
                _backgroundWorker = new BackgroundWorker
                {
                    WorkerSupportsCancellation = true
                };
                _backgroundWorker.DoWork += (x, y) =>
                {
                    try
                    {
                        doWorkAction.Invoke();
                    }
                    catch (Exception ex)
                    {
                        y.Cancel = true;
                        CustomMessageBox.ShowMessage("Bilinmeyen Hata. Detay : " + ex.Message,ex.ToString(),this,"Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // throw;
                    }
                };
                if (progressAction != null)
                {
                    _backgroundWorker.ProgressChanged += (x, y) =>
                    {
                        progressAction.Invoke();
                    };
                }
                if (completedAction != null)
                {
                    _backgroundWorker.RunWorkerCompleted += (x, y) =>
                    {
                        completedAction.Invoke();
                    };
                }
                _backgroundWorker.RunWorkerAsync();
            }
            catch (Exception)
            {

            }

        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            idleCounter++;
            if (base.DesignMode)
            {
                return;
            }
            lock (this)
            {
                if (idleCounter >= idleThresholdSeconds && !isLockForm)
                {
                    isLockForm = true;
                    IslemReturnHandler = IslemReturn;
                    this.Enabled = false;
                    if (kilitForm == null || kilitForm.IsDisposed)
                    {
                        kilitForm = new frmKilitEkrani();
                    }
                    kilitForm.onCloseHandler = IslemReturnHandler;
                    kilitForm.ShowDialog();
                    ResetIdleCounter();
                }
            }
        }
        private void completeProgress()
        {
            try
            {
                _backgroundWorker.Dispose();
                _backgroundWorker = null;
                if (!this.Enabled)
                {
                    this.Enabled = true;
                }

            }
            finally
            {
                //this.Cursor = Cursors.Default;
                _workerCompletedEvent.Set();

            }
        }
        private void CreateDirectoryIfNotExists(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                try
                {
                    Directory.CreateDirectory(directoryPath);
                    MessageBox.Show($"'{directoryPath}' dizini oluşturuldu.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"'{directoryPath}' dizini oluşturulurken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        bool FormMode = false;
        private void xtraTabControl_CloseButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (xtraTabControl.SelectedTabPage.Name == "anaSayfaTab")
                {
                    return;
                }
                if (xtraTabControl.SelectedTabPage.Controls.Count > 0)
                {
                    foreach (object item in xtraTabControl.SelectedTabPage.Controls)
                    {
                        if (item is Form && item is Form frm)
                        {
                            frm.Close();
                            frm.Dispose();
                        }
                    }
                }
                xtraTabControl.SelectedTabPage.Controls[0].Dispose();
            }
            catch
            {
            }
            xtraTabControl.TabPages.Remove(xtraTabControl.SelectedTabPage);
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
        }
        public void xtraTabControlSizeRule()
        {
            try
            {
                for (int i = 0; i < xtraTabControl.TabPages.Count; i++)
                {
                    Application.DoEvents();
                    xtraTabControl.TabPages[i].Width = xtraTabControl.Width;
                    xtraTabControl.TabPages[i].Height = xtraTabControl.Height;
                    foreach (Control item in xtraTabControl.TabPages[i].Controls)
                    {
                        Application.DoEvents();
                        xtraTabControl.TabPages[i].Controls.Remove(item);
                        if (item is Form frm)
                        {
                            frm.Dock = DockStyle.Fill;
                            frm.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                            frm.AutoSize = false;
                            frm.Size = new Size(xtraTabControl.TabPages[i].Width, xtraTabControl.TabPages[i].Height);
                        }
                        xtraTabControl.TabPages[i].Controls.Add(item);
                        item.Refresh();
                        Application.DoEvents();
                    }
                    Application.DoEvents();
                }
            }
            catch
            {
            }
        }
        private void xtraTabControl_SizeChanged(object sender, EventArgs e)
        {
            if (!base.DesignMode)
            {
                xtraTabControlSizeRule();
            }
        }
        public void OpenTabForm(Form form)
        {
            if (FormMode)
            {
                bool isOpen = false;

                foreach (Form child in MdiChildren)
                {
                    if (child.Name == form.Name)
                    {
                        isOpen = true;
                        break;
                    }
                }

                if (isOpen)
                {
                    DialogResult result = XtraMessageBox.Show(
                        form.Text + " Açık. Kapatmak için Hayır Geçiş Yapmak için Evet seçin!",
                        "Uyarı",
                        MessageBoxButtons.YesNoCancel
                    );

                    switch (result)
                    {
                        case DialogResult.Yes:
                            // Form'u öne getir
                            foreach (Form child in MdiChildren)
                            {
                                if (child.Name == form.Name)
                                {
                                    child.BringToFront();
                                    child.Focus();
                                    break;
                                }
                            }
                            break;

                        case DialogResult.No:
                            // Form'u kapat
                            foreach (Form child in MdiChildren)
                            {
                                if (child.Name == form.Name)
                                {
                                    child.BringToFront();
                                    child.Close();
                                    break;
                                }
                            }
                            break;

                        case DialogResult.Cancel:
                            // İptal işlemi
                            break;
                    }
                }
                else
                {
                    form.MdiParent = this;
                    form.Show();
                }
            }
            else
            {
                bool isFormOpen = false;
                // İlgili formun açık olup olmadığını kontrol etmek için bir bayrak kullanıyoruz.

                for (int i = 0; i < xtraTabControl.TabPages.Count; i++)
                {

                    if (xtraTabControl.TabPages[i].Text == form.Text)
                    {
                        isFormOpen = true;
                        // Aynı isme sahip bir formun açık olduğunu belirledik.
                        break;
                    }
                }
                if (isFormOpen)
                {
                    XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                    args.AutoCloseOptions.Delay = 2000;
                    args.Caption = "Uyarı";
                    args.Text = form.Text + "Açık.";
                    args.Buttons = new DialogResult[] { DialogResult.OK };
                    args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                    form.Focus();
                    XtraMessageBox.Show(args).ToString();
                    form.Close();
                    form.Dispose();
                    return;
                    // Form zaten açıksa kullanıcıyı uyar ve işlemi sonlandır.
                }
                else
                {
                    xtraTabControl.TabPages.Add(form.Text);
                    xtraTabControl.SelectedTabPageIndex = xtraTabControl.TabPages.Count - 1;
                    form.MdiParent = this;
                    form.TopLevel = false;
                    form.Dock = DockStyle.Fill;
                    form.FormBorderStyle = FormBorderStyle.None;
                    form.WindowState = FormWindowState.Maximized;
                    form.Parent = xtraTabControl.TabPages[xtraTabControl.TabPages.Count - 1];
                    form.Show();
                }
            }
        }

        private void BaritemKontrol_ItemClick(object sender, TileItemEventArgs e)
        {
            OpenTabForm(new Form1());
        }

        private void BaritemRapor_ItemClick(object sender, TileItemEventArgs e)
        {
            OpenTabForm(new Form1());
        }
    }
}
