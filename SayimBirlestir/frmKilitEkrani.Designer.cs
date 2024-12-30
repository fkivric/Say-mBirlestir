namespace SayimBirlestir
{
    partial class frmKilitEkrani
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKilitEkrani));
            this.groupKullanici = new DevExpress.XtraEditors.GroupControl();
            this.btnKilidAc = new DevExpress.XtraEditors.SimpleButton();
            this.sifreTbx = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupKullanici)).BeginInit();
            this.groupKullanici.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sifreTbx.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupKullanici
            // 
            this.groupKullanici.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.groupKullanici.CaptionImageOptions.Image = global::SayimBirlestir.Properties.Resources.bodetails_32x32;
            this.groupKullanici.Controls.Add(this.btnKilidAc);
            this.groupKullanici.Controls.Add(this.sifreTbx);
            this.groupKullanici.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupKullanici.Location = new System.Drawing.Point(0, 0);
            this.groupKullanici.Name = "groupKullanici";
            this.groupKullanici.Size = new System.Drawing.Size(264, 92);
            this.groupKullanici.TabIndex = 0;
            // 
            // btnKilidAc
            // 
            this.btnKilidAc.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnKilidAc.ImageOptions.Image")));
            this.btnKilidAc.Location = new System.Drawing.Point(93, 66);
            this.btnKilidAc.Name = "btnKilidAc";
            this.btnKilidAc.Size = new System.Drawing.Size(75, 23);
            this.btnKilidAc.TabIndex = 1;
            this.btnKilidAc.Text = "Kilidi Aç";
            this.btnKilidAc.Click += new System.EventHandler(this.btnKilidAc_Click);
            // 
            // sifreTbx
            // 
            this.sifreTbx.Location = new System.Drawing.Point(60, 42);
            this.sifreTbx.Name = "sifreTbx";
            this.sifreTbx.Properties.PasswordChar = '*';
            this.sifreTbx.Size = new System.Drawing.Size(146, 20);
            this.sifreTbx.TabIndex = 0;
            this.sifreTbx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sifreTbx_KeyDown);
            // 
            // frmKilitEkrani
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 92);
            this.Controls.Add(this.groupKullanici);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IconOptions.Image = global::SayimBirlestir.Properties.Resources.Entegref__1_;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(264, 92);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(264, 92);
            this.Name = "frmKilitEkrani";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EntegreF Kilit Ekrani";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmKilitEkrani_FormClosed);
            this.Load += new System.EventHandler(this.frmKilitEkrani_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupKullanici)).EndInit();
            this.groupKullanici.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sifreTbx.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupKullanici;
        private DevExpress.XtraEditors.TextEdit sifreTbx;
        private DevExpress.XtraEditors.SimpleButton btnKilidAc;
    }
}