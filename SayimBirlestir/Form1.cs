using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using SayimBirlestir.Class;
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
using static SayimBirlestir.Class.Siniflar;

namespace SayimBirlestir
{
    public partial class Form1 : XtraForm
    {
        SqlConnectionObject conn = new SqlConnectionObject();
        SqlConnection sql = new SqlConnection(Properties.Settings.Default.connectionstring);
        public Form1()
        {
            try
            {
                SplashScreen();
                InitializeComponent();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false, 300, this);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MGZ();
            gridView1.Columns["PROUNAME"].GroupIndex = 0;

            // Expand all groups 
            gridView1.ExpandAllGroups();
        }
        private void MGZ()
        {
            srcMagaza.Properties.DataSource = conn.GetData("select DIVVAL,DIVNAME,DIVREGION from DIVISON where DIVSTS = 1 order by 2", sql);
            srcMagaza.Properties.ValueMember = "DIVVAL";
            srcMagaza.Properties.DisplayMember = "DIVNAME";
        }
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
                        XtraMessageBox.Show("Her oturum açıldığında 1 işlem yapacak. Eğer bu girişteki ilk işlemse uygulama çalışmaktadır. Lütfen Bekleyiniz");
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
                        XtraMessageBox.Show("Bilinmeyen Hata. Detay : " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void directoryCreator(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
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

        List<Magazalar> Magazalars = new List<Magazalar>();
        List<Sayim> Sayims = new List<Sayim>();
        string CENID = "";
        private void btnEkle_Click(object sender, EventArgs e)
        {

            StringBuilder cenID = new StringBuilder();
            string q = @"select distinct DEEDID,
            case when DEEDDPBHEVAL = 120 then 'SONRADA EKLENEN' else 'SONRADAN ÇIKARTILAN'end as DPDEEDNAME,
            DSTORNAME,DEEDDATE,PROBHNOTES,sum(PROBHQUAN) as PROBHQUAN from DEEDS
						            left outer join DEFPRODUCTDEED on DEEDDPBHEVAL = DPDEEDBHVAL
			                        left outer join PRODUCTSBEHAVE on PROBHDEEDID = DEEDID
			                        left outer join DEFSTORAGE ON DSTORID=DEEDSTORID
			                        where DEFSTORAGE.DSTORDIVISON  in ('{0}') AND DEEDDPBHEVAL IN (-1,1,6,7,120,130,620,630,640,803,806,807,808,999,2,802)
			                        and DATEPART(YYYY,PROBHDATE) = DATEPART(YYYY,GETDATE())  
			                        and DEEDDPBHEVAL in (620,120)
						            and not exists (select * from CENSUS where CENID = DEEDDCENID)
            group by DEEDID,DEEDDATE,DEEDDPBHEVAL,PROBHNOTES,DSTORNAME
            union
            select distinct DEEDID,
            'SAYIM FİŞİ ZORUNLU' as DPDEEDNAME,
            DSTORNAME,DEEDDATE,PROBHNOTES,sum(PROBHQUAN) as PROBHQUAN from DEEDS
						            left outer join DEFPRODUCTDEED on DEEDDPBHEVAL = DPDEEDBHVAL
			                        left outer join PRODUCTSBEHAVE on PROBHDEEDID = DEEDID
			                        left outer join DEFSTORAGE ON DSTORID=DEEDSTORID
			                        where DEFSTORAGE.DSTORDIVISON  in ('{0}') AND DEEDDPBHEVAL IN (-1,1,6,7,120,130,620,630,640,803,806,807,808,999,2,802)
			                        and DATEPART(YYYY,PROBHDATE) = DATEPART(YYYY,GETDATE())  
			                        and DEEDDPBHEVAL in (620,120)
						            and exists (select * from CENSUS where CENID = DEEDDCENID)
            group by DEEDID,DEEDDATE,DPDEEDNAME,PROBHNOTES,DSTORNAME
            order by 2,1";
            string w = @"select STRING_AGG(CENID,',') as CENID from CENSUS
            left outer join DEFSTORAGE on DSTORID = CENSTORID
            where DSTORVAL = '{0}'
            and CENCONFIRM = 1
            and DATEPART(YYYY,CENDATE) = DATEPART(YYYY,getdate())";
            string divval;
            string divname;
            int sayac;
            if (srcMagaza.EditValue == null)
            {
                var MGZ = conn.GetData("select DIVVAL,DIVNAME,DIVREGION from DIVISON where DIVSTS = 1 order by 2", sql);
                sayac = MGZ.Rows.Count;
            }
            else
            {
                sayac = 1;
            }
            ProgressBarFrm progressForm = new ProgressBarFrm()
            {
                Start = 0,
                Finish = sayac,
                Position = 0,
                ToplamAdet = sayac.ToString(),
            };
            executeBackground(
       () =>
       {
           progressForm.Show(this);
           if (srcMagaza.EditValue == null)
           {
               var MGZ = conn.GetData("select DIVVAL,DIVNAME,DIVREGION from DIVISON where DIVSTS = 1 order by 2", sql);
               for (int i = 0; i < MGZ.Rows.Count; i++)
                {
                    divval = MGZ.Rows[i]["DIVVAL"].ToString();
                    divname = MGZ.Rows[i]["DIVNAME"].ToString();
                    // Listeye eklenip eklenmediğini kontrol et 
                    var existingMagaza = Magazalars.FirstOrDefault(m => m.DIVVAL == divval);
                    if (existingMagaza != null)
                    {
                        MessageBox.Show("Bu mağaza zaten eklendi.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
                    }
                    // Yeni bir Magazalar nesnesi oluştur ve değerleri ata 
                    Magazalar magazalar = new Magazalar
                    {
                        DIVVAL = divval,
                        DIVNAME = divname
                    };
                    // Listeye ekle 
                    Magazalars.Add(magazalar);
                   Invoke((MethodInvoker)delegate
                   {
                       // gridMagazalar'ın veri kaynağını güncelle 
                       gridMagazalar.DataSource = null;
                       gridMagazalar.DataSource = Magazalars;
                       // gridMagazalar'ı güncelle 
                       gridMagazalar.Refresh();

                   });

                    var dt = conn.GetData(String.Format(q, divval), sql);
                    if (dt != null)
                    {
                        List<Sayim> sysm = dt.ToList<Sayim>();
                        Sayims.AddRange(sysm);
                    }
                   Invoke((MethodInvoker)delegate
                   {
                       // gridSayim'ın veri kaynağını güncelle 
                       gridSayim.DataSource = null;
                       gridSayim.DataSource = Sayims;
                       // gridSayim'ı güncelle 
                       gridSayim.Refresh();

                   });
                    string sorgu = String.Format(w, divval);
                    var ct = conn.GetData(sorgu, sql);
                    if (ct != null)
                    {
                        if (ct.Rows.Count > 0 && !string.IsNullOrEmpty(ct.Rows[0]["CENID"].ToString()))
                        {
                            if (CENID.Length > 0)
                            {
                                cenID.Append(","); // Eğer daha önce değer eklenmişse, öncesine virgül ekleyin 
                            }
                            cenID.Append(ct.Rows[0]["CENID"].ToString());
                        }
                        CENID = CENID + cenID.ToString();
                   }
                   progressForm.PerformStep(this);
               }
            }
            else
            {

                divval = srcMagaza.EditValue.ToString();
                divname = srcMagaza.Text;
                // Listeye eklenip eklenmediğini kontrol et 
                var existingMagaza = Magazalars.FirstOrDefault(m => m.DIVVAL == divval);
                if (existingMagaza != null)
                {
                    MessageBox.Show("Bu mağaza zaten eklendi.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
                }
                // Yeni bir Magazalar nesnesi oluştur ve değerleri ata 
                Magazalar magazalar = new Magazalar
                {
                    DIVVAL = divval,
                    DIVNAME = divname
                };
                // Listeye ekle 
                Magazalars.Add(magazalar);
               Invoke((MethodInvoker)delegate
               {
                   // gridMagazalar'ın veri kaynağını güncelle 
                   gridMagazalar.DataSource = null;
                   gridMagazalar.DataSource = Magazalars;
                   // gridMagazalar'ı güncelle 
                   gridMagazalar.Refresh();
               });

                var dt = conn.GetData(String.Format(q, divval), sql);
                List<Sayim> sysm = dt.ToList<Sayim>();
                Sayims.AddRange(sysm);

               Invoke((MethodInvoker)delegate
               {
                   // gridSayim'ın veri kaynağını güncelle 
                   gridSayim.DataSource = null;
                   gridSayim.DataSource = Sayims;
                   // gridSayim'ı güncelle 
                   gridSayim.Refresh();
               });
                string sorgu = String.Format(w, divval);
                var ct = conn.GetData(sorgu, sql);
                if (ct.Rows.Count > 0 && !string.IsNullOrEmpty(ct.Rows[0]["CENID"].ToString()))
                {
                    if (CENID.Length > 0)
                    {
                        cenID.Append(","); // Eğer daha önce değer eklenmişse, öncesine virgül ekleyin 
                    }
                    cenID.Append(ct.Rows[0]["CENID"].ToString());
                }
                CENID = CENID + cenID.ToString();
               progressForm.PerformStep(this);
           }
       },

            null,
            () =>
            {
                completeProgress();
                progressForm.Hide(this);
                ViewMagazalar.OptionsView.BestFitMaxRowCount = -1;
                ViewMagazalar.BestFitColumns(true);
                ViewSayim.OptionsView.BestFitMaxRowCount = -1;
                ViewSayim.BestFitColumns(true);
                // Diğer kontrolleri etkinleştir 
                tileBarItem1.Enabled = true;
                tileBarItem3.Enabled = true;
            });
        }

        private void tileBarItem1_ItemClick(object sender, TileItemEventArgs e)
        {
            var selectedRows = ViewSayim.GetSelectedRows();
            string sorgu = "";
            string DEEDID = "";
            StringBuilder deedIds = new StringBuilder();
            //string q = @"SELECT 0 as sira,
            //PROUNAME,
            //(select DSTORNAME from DEFSTORAGE where DSTORID in (SAYIM.DSTORID,FAZLA.DSTORID,EKSIK.DSTORID)) as MAGAZA,
            //stok.PROVAL,stok.PRONAME,
            //ISNULL(SAYILAN,0)-ISNULL(FAZLA,0)+ISNULL(EKSIK,0) ENVANTER,
            //SAYILAN,
            //ISNULL(FAZLA,0) as FAZLA,
            //ISNULL(EKSIK,0) as EKSIK
            //FROM PRODUCTS stok
            //LEFT OUTER JOIN PRODUCTSUNITED ON PROUID = PROPROUID
            // outer apply(select DSTORID,PROBHQUAN as FAZLA from DEEDS
            //   left outer join PRODUCTSBEHAVE on PROBHDEEDID = DEEDID
            //   left outer join DEFSTORAGE ON DSTORID=DEEDSTORID
            //   where DEFSTORAGE.DSTORDIVISON  in ({0}) AND DEEDDPBHEVAL IN (-1,1,6,7,120,130,620,630,640,803,806,807,808,999,2,802)
            //   and PROBHPROID = PROID
            //   and DATEPART(YYYY,PROBHDATE) = DATEPART(YYYY,GETDATE())  
            //   and DEEDDPBHEVAL = 120) FAZLA
            // outer apply(select DSTORID,PROBHQUAN as EKSIK from DEEDS
            //   left outer join PRODUCTSBEHAVE on PROBHDEEDID = DEEDID
            //   left outer join DEFSTORAGE ON DSTORID=DEEDSTORID
            //   where DEFSTORAGE.DSTORDIVISON  in ({0}) AND DEEDDPBHEVAL IN (-1,1,6,7,120,130,620,630,640,803,806,807,808,999,2,802)
            //   and PROBHPROID = PROID
            //   and DATEPART(YYYY,PROBHDATE) = DATEPART(YYYY,GETDATE())  
            //   and DEEDDPBHEVAL = 620) EKSIK
            // outer apply(select DSTORID,stok.PROVAL,stok.PRONAME,sum(CENCHQUAN) as SAYILAN from CENSUS
            //  LEFT OUTER JOIN DEFSTORAGE ON DSTORID=CENSTORID 
            //  LEFT OUTER JOIN DIVISON on DIVVAL = DSTORDIVISON
            //  LEFT OUTER JOIN CENSUSCHILD on CENID = CENCHCENID
            //  where DIVVAL in ({0}) and DATEPART(YYYY,CENDATE) = DATEPART(YYYY,GETDATE())
            //  and stok.PROID = CENCHPROID
            //  group by DSTORID
            //  ) SAYIM
            //WHERE PROSTS = 1 AND FAZLA is not NULL or EKSIK is not NULL OR SAYILAN is not NULL";
            string q = @"SELECT 
              PROUNAME,
              (select DSTORNAME from DEFSTORAGE where DSTORID in (SAYIM.DSTORID,FAZLA.DSTORID,EKSIK.DSTORID)) as MAGAZA,
              stok.PROVAL,stok.PRONAME,
              ISNULL(SAYILAN,0)-ISNULL(FAZLA,0)+ISNULL(EKSIK,0) ENVANTER,
              SAYILAN,
              ISNULL(FAZLA,0) as FAZLA,
              ISNULL(EKSIK,0) as EKSIK
            FROM PRODUCTS stok
            LEFT OUTER JOIN PRODUCTSUNITED ON PROUID = PROPROUID
            outer apply(select DSTORID,PROBHQUAN as FAZLA from DEEDS
	            left outer join PRODUCTSBEHAVE on PROBHDEEDID = DEEDID
                left outer join DEFSTORAGE ON DSTORID=DEEDSTORID
                where DEFSTORAGE.DSTORDIVISON  in ({0}) AND DEEDDPBHEVAL IN (-1,1,6,7,120,130,620,630,640,803,806,807,808,999,2,802)
	            and DEEDID in ({1})
                and PROBHPROID = PROID
                and DATEPART(YYYY,PROBHDATE) = DATEPART(YYYY,GETDATE())  
                and DEEDDPBHEVAL = 120) FAZLA
            outer apply(select DSTORID,PROBHQUAN as EKSIK from DEEDS
                left outer join PRODUCTSBEHAVE on PROBHDEEDID = DEEDID
                left outer join DEFSTORAGE ON DSTORID=DEEDSTORID
                where DEFSTORAGE.DSTORDIVISON  in ({0}) AND DEEDDPBHEVAL IN (-1,1,6,7,120,130,620,630,640,803,806,807,808,999,2,802)
	            and DEEDID in ({1})
                and PROBHPROID = PROID
                and DATEPART(YYYY,PROBHDATE) = DATEPART(YYYY,GETDATE())  
                and DEEDDPBHEVAL = 620) EKSIK
            outer apply(select DSTORID,stok.PROVAL,stok.PRONAME,sum(CENCHQUAN) as SAYILAN from CENSUS
                LEFT OUTER JOIN DEFSTORAGE ON DSTORID=CENSTORID 
                LEFT OUTER JOIN DIVISON on DIVVAL = DSTORDIVISON
                LEFT OUTER JOIN CENSUSCHILD on CENID = CENCHCENID
                where DIVVAL in ({0}) and DATEPART(YYYY,CENDATE) = DATEPART(YYYY,GETDATE())
                and stok.PROID = CENCHPROID
	            and CENCONFIRM = 1
                group by DSTORID) SAYIM
            WHERE FAZLA is not NULL or EKSIK is not NULL OR SAYILAN is not NULL";
            ProgressBarFrm progressForm = new ProgressBarFrm()
            {
                Start = 0,
                Finish = 1,
                Position = 0,
                ToplamAdet = 1.ToString(),
            };
            executeBackground(
       () =>
       {
           progressForm.Show(this);
           for (int i = 0; i < selectedRows.Length; i++)
           {
               if (i != 0)
               {
                   deedIds.Append(","); // İlk öğe haricinde, öncesine virgül ekle 
               }
               deedIds.Append(ViewSayim.GetRowCellValue(selectedRows[i], "DEEDID").ToString());
           }
           DEEDID = deedIds.ToString(); // Sonuç olarak elde edilen string

           for (int i = 0; i < ViewMagazalar.RowCount; i++)
           {
               string divval = ViewMagazalar.GetRowCellValue(i, "DIVVAL").ToString();
               if (i == 0)
               {
                   sorgu = String.Format(q, $"'{divval}'", DEEDID);
               }
               else
               {
                   sorgu = sorgu + " union " + String.Format(q, $"'{divval}'", DEEDID);  //$",'{divval}'";
               }
           }
           sorgu += " order by PROUNAME,PRONAME,MAGAZA";
           Invoke((MethodInvoker)delegate
           {
               gridControl1.DataSource = conn.GetData(sorgu, sql);
           });
           progressForm.PerformStep(this);
       },

            null,
            () =>
            {
                completeProgress();
                progressForm.Hide(this);
                Invoke((MethodInvoker)delegate
                {
                });
                gridView1.OptionsView.BestFitMaxRowCount = -1;
                gridView1.BestFitColumns(true);
                navigationFrame1.SelectedPage = navigationPage2;
            });
        }


        private void tileBarItem2_ItemClick(object sender, TileItemEventArgs e)
        {

            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Sayım Sonucu", Magazalars[0].DIVNAME);
            CreateDirectoryIfNotExists(path);
            string file = Path.Combine(path, Magazalars[0].DIVNAME + ".xlsx");
            gridView1.ExportToXlsx(file);
            //Process.Start(path + ".xlsx");
        }

        private void tileBarItem3_ItemClick(object sender, TileItemEventArgs e)
        {
            Magazalars.Clear();
            Sayims.Clear();
            gridControl1.DataSource = null;
            gridSayim.DataSource = null;
            MGZ();
            gridMagazalar.DataSource = null;
            tileBarItem1.Enabled = false;
            tileBarItem3.Enabled = false;
            CENID = "";
            srcMagaza.EditValue = null;
        }

        private void ViewSayim_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle >= 0)
            {
                string dpdeedname = view.GetRowCellValue(e.RowHandle, "DPDEEDNAME").ToString();
                if (dpdeedname == "SAYIM FİŞİ ZORUNLU")
                {
                    view.SelectRow(e.RowHandle);
                }
            }

        }

        private void ViewSayim_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            GridView view = sender as GridView; if (e.ControllerRow >= 0)
            {
                string dpdeedname = view.GetRowCellValue(e.ControllerRow, "DPDEEDNAME").ToString();
                if (dpdeedname == "SAYIM FİŞİ ZORUNLU" && e.Action == CollectionChangeAction.Remove)
                {
                    // Seçimin kaldırılmasını engelle
                    view.SelectRow(e.ControllerRow);
                }
            }
        }

        private void tileBarItem4_ItemClick(object sender, TileItemEventArgs e)
        {
            gridControl1.DataSource = null;
            navigationFrame1.SelectedPage = navigationPage1;
        }
    }
}
