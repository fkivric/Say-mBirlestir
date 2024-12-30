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
using System.Data.SqlClient;

namespace SayimBirlestir
{
    public partial class frmKilitEkrani : DevExpress.XtraEditors.XtraForm
    {

        public Form parentForm;

        public Form mdiParent;

        public Delegate onCloseHandler;
        string User;
        string enterKey;
        DataTable yetki = new DataTable();
        public frmKilitEkrani()
        {
            InitializeComponent();
                //yetki = Sorgu(string.Format(@"select * from SOCIAL where SOCODE = '{0}'", _user), Properties.Settings.Default.connectionstring2);
                enterKey = Properties.Settings.Default.Vol_SOENTERKEY;
                User = "Volant Kullanıcı: " + Properties.Settings.Default.Vol_SOCODE;
        }

        public DataTable Sorgu(string sorgu, string connection)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sorgu, connection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }
        private void frmKilitEkrani_Load(object sender, EventArgs e)
        {
            try
            {
                groupKullanici.Text = User;
            }
            catch
            {
                Close();
                if (parentForm != null)
                {
                    parentForm.Enabled = true;
                }
                throw;
            }
        }

        private void frmKilitEkrani_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (parentForm != null)
            {
                parentForm.Enabled = true;
            }
            if (enterKey == sifreTbx.Text)
            {
                if ((object)onCloseHandler != null)
                {
                    onCloseHandler.DynamicInvoke(1);
                }
            }
            else if ((object)onCloseHandler != null)
            {
                onCloseHandler.DynamicInvoke(0);
            }
            sifreTbx.Text = "";
        }

        private void sifreTbx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (enterKey == sifreTbx.Text)
                {
                    Close();
                }
                else
                {
                    XtraMessageBox.Show("Parola denemesi başarızı!");
                }
            }
        }

        private void btnKilidAc_Click(object sender, EventArgs e)
        {
            try
            {
                if (enterKey == sifreTbx.Text)
                {
                    Close();
                }
                else
                {
                    XtraMessageBox.Show("Parola denemesi başarızı!");
                    sifreTbx.Text = "";
                }
            }
            catch (Exception exp)
            {
                CustomMessageBox.ShowMessage("", exp.ToString(), this, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}