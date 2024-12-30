using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.LookAndFeel;

namespace SayimBirlestir
{
    public partial class frmMessageBox : XtraForm
    {
        public frmMessageBox()
        {
            InitializeComponent();
            baslangicZamani = DateTime.Now;
            timer1.Start();
        }
        public Image MessageIcon
        {
            get { return pictureBox1.Image; }
            set { pictureBox1.Image = value; }
        }
        public string Message
        {
            get { return lblMessage.Text; }
            set { lblMessage.Text = value; }
        }

        public string detay
        {
            get { return rchtxt.Text; }
            set { rchtxt.Text = value; }
        }

        private void frmMessageBox_Load(object sender, EventArgs e)
        {
            panelControl1.Visible = false;
            this.Size = new Size(549, 190);

            if (rchtxt.Text != "")
            {
                btnDetay.Enabled = true;
            }
            if (lblMessage.Text == "Lütfen Bekleyin")
            {
                btnOk.Enabled = false;
                btnDetay_Click(null, null);
            }
        }
        int totalHeight = 0;
        private void btnDetay_Click(object sender, EventArgs e)
        {
            if (totalHeight == 0)
            {
                int firstCharIndex = rchtxt.GetCharIndexFromPosition(new Point(0, 0));
                int firstLine = rchtxt.GetLineFromCharIndex(firstCharIndex);

                int lastCharIndex = rchtxt.GetCharIndexFromPosition(new Point(rchtxt.Width - 1, rchtxt.Height - 1));
                int lastLine = rchtxt.GetLineFromCharIndex(lastCharIndex);

                int lineCount = lastLine - firstLine + 1;

                int firstLineHeight = rchtxt.GetPositionFromCharIndex(rchtxt.GetFirstCharIndexFromLine(firstLine)).Y;
                int lastLineHeight = rchtxt.GetPositionFromCharIndex(rchtxt.GetFirstCharIndexFromLine(lastLine)).Y;

                totalHeight = lastLineHeight - firstLineHeight + rchtxt.Font.Height * (lineCount);
            }

            // Get the current DPI scale factor of the screen
            float dpiScale = this.CreateGraphics().DpiX / 96f; // 96 is the default DPI at 100% scale

            // Adjust totalHeight based on the DPI scaling factor
            totalHeight = (int)(totalHeight * dpiScale);

            var boyut = this.Size.Height;
            if (boyut == 190)
            {
                if (rchtxt.Text != "")
                {
                    // Apply DPI scaling to the height of the form
                    this.Size = new Size((int)(549 * dpiScale), (int)(boyut + totalHeight));
                    panelControl1.Visible = true;
                }
            }
            else
            {
                // Adjust for DPI scaling in the else branch as well
                this.Size = new Size((int)(549 * dpiScale), (int)(190 * dpiScale));
                panelControl1.Visible = false;
            }
            //var boyut = this.Size.Height;
            //if (boyut == 190)
            //{
            //    if (rchtxt.Text != "")
            //    {
            //        this.Size = new Size(549, boyut+ totalHeight);
            //        panelControl1.Visible = true;
            //    }
            //}
            //else
            //{
            //    this.Size = new Size(549, 190);
            //    panelControl1.Visible = false;
            //}

        }
        int kapanis = 5;
        private DateTime baslangicZamani;
        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan gecenSure = DateTime.Now - baslangicZamani;

            // Saat, dakika ve saniye bilgilerini alıyoruz
            int saat = gecenSure.Hours;
            int dakika = gecenSure.Minutes;
            int saniye = gecenSure.Seconds;

            // Label üzerine saat bilgisini yazdırma
            lblTime.Text = $"{saat:D2}:{dakika:D2}:{saniye:D2}";
            lblsimdi.Text = DateTime.Now.ToString("HH:mm:ss");
            if (lblMessage.Text == "Lütfen Bekleyin: ")
            {
                if (kapanis == saniye)
                {
                    this.Close();
                    this.Dispose();
                }
                else
                {
                    btnOk.Text = "Kapat (" + (kapanis - saniye).ToString() + ")";
                }
            }
            //if (rchtxt.Text == "Volant Sunucu için Diğer Tanımlı Erişim Adresleri Deneniyor....")
            //{
            //    TimeSpan gecenSure = DateTime.Now - baslangicZamani;

            //    // Saat, dakika ve saniye bilgilerini alıyoruz
            //    int saat = gecenSure.Hours;
            //    int dakika = gecenSure.Minutes;
            //    int saniye = gecenSure.Seconds;

            //    // Label üzerine saat bilgisini yazdırma
            //    lblTime.Text = $"{saat:D2}:{dakika:D2}:{saniye:D2}";
            //    if (saniye >= 2)
            //    {
            //        btnOk.Enabled = true;
            //    }

            //}
            //else
            //{
            //    lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
            //}
        }
    }
}