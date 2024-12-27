namespace SayimBirlestir
{
    partial class ProgressBarFrm
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
            this.prgProgress = new DevExpress.XtraEditors.ProgressBarControl();
            this.progressPanel1 = new DevExpress.XtraWaitForm.ProgressPanel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblZaman = new DevExpress.XtraEditors.LabelControl();
            this.lblIslem = new DevExpress.XtraEditors.LabelControl();
            this.lblAdet = new DevExpress.XtraEditors.LabelControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.prgProgress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // prgProgress
            // 
            this.prgProgress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.prgProgress.Location = new System.Drawing.Point(0, 96);
            this.prgProgress.Name = "prgProgress";
            this.prgProgress.Size = new System.Drawing.Size(553, 30);
            this.prgProgress.TabIndex = 0;
            // 
            // progressPanel1
            // 
            this.progressPanel1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.progressPanel1.Appearance.Options.UseBackColor = true;
            this.progressPanel1.Caption = "Lütfen Bekleyiniz.";
            this.progressPanel1.Description = "Yükleniyor...";
            this.progressPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressPanel1.Location = new System.Drawing.Point(0, 0);
            this.progressPanel1.Name = "progressPanel1";
            this.progressPanel1.Size = new System.Drawing.Size(553, 69);
            this.progressPanel1.TabIndex = 1;
            this.progressPanel1.Text = "progressPanel1";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.tablePanel1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 69);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(553, 27);
            this.panelControl1.TabIndex = 2;
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 65.95F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 27.98F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 38.4F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 27.67F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F)});
            this.tablePanel1.Controls.Add(this.labelControl2);
            this.tablePanel1.Controls.Add(this.labelControl1);
            this.tablePanel1.Controls.Add(this.lblZaman);
            this.tablePanel1.Controls.Add(this.lblIslem);
            this.tablePanel1.Controls.Add(this.lblAdet);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(2, 2);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.tablePanel1.Size = new System.Drawing.Size(549, 23);
            this.tablePanel1.TabIndex = 0;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Options.UseTextOptions = true;
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel1.SetColumn(this.labelControl2, 0);
            this.labelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl2.Location = new System.Drawing.Point(3, 3);
            this.labelControl2.Name = "labelControl2";
            this.tablePanel1.SetRow(this.labelControl2, 0);
            this.labelControl2.Size = new System.Drawing.Size(166, 17);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Toplam İşlem Sayısı / Yapılan =";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel1.SetColumn(this.labelControl1, 3);
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl1.Location = new System.Drawing.Point(349, 3);
            this.labelControl1.Name = "labelControl1";
            this.tablePanel1.SetRow(this.labelControl1, 0);
            this.labelControl1.Size = new System.Drawing.Size(66, 17);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "İşlem Süresi :";
            // 
            // lblZaman
            // 
            this.lblZaman.Appearance.Options.UseTextOptions = true;
            this.lblZaman.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblZaman.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel1.SetColumn(this.lblZaman, 4);
            this.lblZaman.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblZaman.Location = new System.Drawing.Point(421, 3);
            this.lblZaman.Name = "lblZaman";
            this.tablePanel1.SetRow(this.lblZaman, 0);
            this.lblZaman.Size = new System.Drawing.Size(125, 17);
            this.lblZaman.TabIndex = 3;
            this.lblZaman.Text = "labelControl3";
            this.lblZaman.Click += new System.EventHandler(this.lblZaman_Click);
            // 
            // lblIslem
            // 
            this.lblIslem.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel1.SetColumn(this.lblIslem, 2);
            this.lblIslem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIslem.Location = new System.Drawing.Point(249, 3);
            this.lblIslem.Name = "lblIslem";
            this.tablePanel1.SetRow(this.lblIslem, 0);
            this.lblIslem.Size = new System.Drawing.Size(94, 17);
            this.lblIslem.TabIndex = 1;
            this.lblIslem.Text = "labelControl2";
            // 
            // lblAdet
            // 
            this.lblAdet.Appearance.Options.UseTextOptions = true;
            this.lblAdet.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblAdet.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel1.SetColumn(this.lblAdet, 1);
            this.lblAdet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAdet.Location = new System.Drawing.Point(175, 3);
            this.lblAdet.Name = "lblAdet";
            this.tablePanel1.SetRow(this.lblAdet, 0);
            this.lblAdet.Size = new System.Drawing.Size(67, 17);
            this.lblAdet.TabIndex = 0;
            this.lblAdet.Text = "labelControl1";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ProgressBarFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 126);
            this.ControlBox = false;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.progressPanel1);
            this.Controls.Add(this.prgProgress);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProgressBarFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ProgressBarFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.prgProgress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            this.tablePanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ProgressBarControl prgProgress;
        private DevExpress.XtraWaitForm.ProgressPanel progressPanel1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.LabelControl lblIslem;
        private DevExpress.XtraEditors.LabelControl lblAdet;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.LabelControl lblZaman;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}