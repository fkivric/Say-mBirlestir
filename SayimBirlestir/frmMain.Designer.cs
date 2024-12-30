namespace SayimBirlestir
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraEditors.TileItemElement tileItemElement1 = new DevExpress.XtraEditors.TileItemElement();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            DevExpress.XtraEditors.TileItemElement tileItemElement2 = new DevExpress.XtraEditors.TileItemElement();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.tileBar1 = new DevExpress.XtraBars.Navigation.TileBar();
            this.tileBarGroup2 = new DevExpress.XtraBars.Navigation.TileBarGroup();
            this.BaritemKontrol = new DevExpress.XtraBars.Navigation.TileBarItem();
            this.BaritemRapor = new DevExpress.XtraBars.Navigation.TileBarItem();
            this.xtraTabControl = new DevExpress.XtraTab.XtraTabControl();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // tileBar1
            // 
            this.tileBar1.AppearanceItem.Normal.BackColor = System.Drawing.Color.Black;
            this.tileBar1.AppearanceItem.Normal.BackColor2 = System.Drawing.Color.Blue;
            this.tileBar1.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tileBar1.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.tileBar1.Groups.Add(this.tileBarGroup2);
            this.tileBar1.ItemPadding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.tileBar1.Location = new System.Drawing.Point(0, 0);
            this.tileBar1.MaxId = 2;
            this.tileBar1.Name = "tileBar1";
            this.tileBar1.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.tileBar1.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.ScrollButtons;
            this.tileBar1.Size = new System.Drawing.Size(1233, 85);
            this.tileBar1.TabIndex = 0;
            this.tileBar1.Text = "tileBar1";
            // 
            // tileBarGroup2
            // 
            this.tileBarGroup2.Items.Add(this.BaritemKontrol);
            this.tileBarGroup2.Items.Add(this.BaritemRapor);
            this.tileBarGroup2.Name = "tileBarGroup2";
            // 
            // BaritemKontrol
            // 
            this.BaritemKontrol.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            tileItemElement1.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement1.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Left;
            tileItemElement1.Text = "Sayım Başlanğıç Kontrolleri";
            tileItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            this.BaritemKontrol.Elements.Add(tileItemElement1);
            this.BaritemKontrol.Id = 0;
            this.BaritemKontrol.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            this.BaritemKontrol.Name = "BaritemKontrol";
            this.BaritemKontrol.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.BaritemKontrol_ItemClick);
            // 
            // BaritemRapor
            // 
            this.BaritemRapor.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            tileItemElement2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            tileItemElement2.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement2.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Left;
            tileItemElement2.Text = "Sayım Raporları";
            this.BaritemRapor.Elements.Add(tileItemElement2);
            this.BaritemRapor.Id = 1;
            this.BaritemRapor.ItemSize = DevExpress.XtraBars.Navigation.TileBarItemSize.Wide;
            this.BaritemRapor.Name = "BaritemRapor";
            this.BaritemRapor.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.BaritemRapor_ItemClick);
            // 
            // xtraTabControl
            // 
            this.xtraTabControl.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageHeader;
            this.xtraTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl.Location = new System.Drawing.Point(0, 85);
            this.xtraTabControl.MultiLine = DevExpress.Utils.DefaultBoolean.True;
            this.xtraTabControl.Name = "xtraTabControl";
            this.xtraTabControl.ShowTabHeader = DevExpress.Utils.DefaultBoolean.True;
            this.xtraTabControl.Size = new System.Drawing.Size(1233, 588);
            this.xtraTabControl.TabIndex = 1;
            this.xtraTabControl.CloseButtonClick += new System.EventHandler(this.xtraTabControl_CloseButtonClick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1233, 673);
            this.Controls.Add(this.xtraTabControl);
            this.Controls.Add(this.tileBar1);
            this.IconOptions.Image = global::SayimBirlestir.Properties.Resources.Entegref__1_;
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.Text = "Volant Sayım";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Navigation.TileBar tileBar1;
        private DevExpress.XtraBars.Navigation.TileBarGroup tileBarGroup2;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl;
        private System.Windows.Forms.Timer timer2;
        private DevExpress.XtraBars.Navigation.TileBarItem BaritemKontrol;
        private DevExpress.XtraBars.Navigation.TileBarItem BaritemRapor;
    }
}