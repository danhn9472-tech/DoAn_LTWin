namespace DoAn_LTWin.Forms
{
    partial class ThongKe1
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
            this.txtTong = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnMoi = new System.Windows.Forms.Button();
            this.btnTK = new System.Windows.Forms.Button();
            this.dgvThongKe = new System.Windows.Forms.DataGridView();
            this.MSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SLB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.loạiThốngKêToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doanhThuTheoNgayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SPBCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSP = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbNgay = new System.Windows.Forms.ComboBox();
            this.cmbThang = new System.Windows.Forms.ComboBox();
            this.cmbNam = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTong
            // 
            this.txtTong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtTong.Location = new System.Drawing.Point(148, 444);
            this.txtTong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTong.Name = "txtTong";
            this.txtTong.Size = new System.Drawing.Size(125, 22);
            this.txtTong.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 450);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Tổng Doanh Thu";
            // 
            // btnMoi
            // 
            this.btnMoi.Location = new System.Drawing.Point(134, 87);
            this.btnMoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMoi.Name = "btnMoi";
            this.btnMoi.Size = new System.Drawing.Size(94, 23);
            this.btnMoi.TabIndex = 11;
            this.btnMoi.Text = "Làm Mới";
            this.btnMoi.UseVisualStyleBackColor = true;
            this.btnMoi.Click += new System.EventHandler(this.btnMoi_Click);
            // 
            // btnTK
            // 
            this.btnTK.Location = new System.Drawing.Point(12, 87);
            this.btnTK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTK.Name = "btnTK";
            this.btnTK.Size = new System.Drawing.Size(94, 23);
            this.btnTK.TabIndex = 12;
            this.btnTK.Text = "Thống Kê";
            this.btnTK.UseVisualStyleBackColor = true;
            this.btnTK.Click += new System.EventHandler(this.btnTK_Click);
            // 
            // dgvThongKe
            // 
            this.dgvThongKe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThongKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongKe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MSP,
            this.TSP,
            this.DGia,
            this.SLB,
            this.DT,
            this.NBan});
            this.dgvThongKe.Location = new System.Drawing.Point(1, 125);
            this.dgvThongKe.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvThongKe.Name = "dgvThongKe";
            this.dgvThongKe.RowHeadersWidth = 51;
            this.dgvThongKe.Size = new System.Drawing.Size(1015, 311);
            this.dgvThongKe.TabIndex = 15;
            // 
            // MSP
            // 
            this.MSP.DataPropertyName = "MSP";
            this.MSP.HeaderText = "MaSP";
            this.MSP.MinimumWidth = 6;
            this.MSP.Name = "MSP";
            // 
            // TSP
            // 
            this.TSP.DataPropertyName = "TSP";
            this.TSP.HeaderText = "Tên SP";
            this.TSP.MinimumWidth = 6;
            this.TSP.Name = "TSP";
            // 
            // DGia
            // 
            this.DGia.DataPropertyName = "DGia";
            this.DGia.HeaderText = "Đơn Giá";
            this.DGia.MinimumWidth = 6;
            this.DGia.Name = "DGia";
            // 
            // SLB
            // 
            this.SLB.DataPropertyName = "SLB";
            this.SLB.HeaderText = "Số Lượng Bán";
            this.SLB.MinimumWidth = 6;
            this.SLB.Name = "SLB";
            // 
            // DT
            // 
            this.DT.DataPropertyName = "DT";
            this.DT.HeaderText = "Doanh Thu";
            this.DT.MinimumWidth = 6;
            this.DT.Name = "DT";
            // 
            // NBan
            // 
            this.NBan.DataPropertyName = "NBan";
            this.NBan.HeaderText = "Ngày Bán ";
            this.NBan.MinimumWidth = 6;
            this.NBan.Name = "NBan";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loạiThốngKêToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1028, 28);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // loạiThốngKêToolStripMenuItem
            // 
            this.loạiThốngKêToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.doanhThuTheoNgayToolStripMenuItem,
            this.SPBCToolStripMenuItem});
            this.loạiThốngKêToolStripMenuItem.Name = "loạiThốngKêToolStripMenuItem";
            this.loạiThốngKêToolStripMenuItem.Size = new System.Drawing.Size(118, 24);
            this.loạiThốngKêToolStripMenuItem.Text = "Loại Thống Kê";
            // 
            // doanhThuTheoNgayToolStripMenuItem
            // 
            this.doanhThuTheoNgayToolStripMenuItem.Name = "doanhThuTheoNgayToolStripMenuItem";
            this.doanhThuTheoNgayToolStripMenuItem.Size = new System.Drawing.Size(258, 26);
            this.doanhThuTheoNgayToolStripMenuItem.Text = "Doanh Thu Theo Ngày";
            // 
            // SPBCToolStripMenuItem
            // 
            this.SPBCToolStripMenuItem.Name = "SPBCToolStripMenuItem";
            this.SPBCToolStripMenuItem.Size = new System.Drawing.Size(258, 26);
            this.SPBCToolStripMenuItem.Text = "Sản Phẩm Bán Chạy Nhất";
            this.SPBCToolStripMenuItem.Click += new System.EventHandler(this.SPBCToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(643, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "Chọn Sản Phẩm ";
            // 
            // cmbSP
            // 
            this.cmbSP.FormattingEnabled = true;
            this.cmbSP.Location = new System.Drawing.Point(755, 42);
            this.cmbSP.Name = "cmbSP";
            this.cmbSP.Size = new System.Drawing.Size(121, 24);
            this.cmbSP.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "Ngay";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(227, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "Thang";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(435, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 16);
            this.label5.TabIndex = 20;
            this.label5.Text = "Nam";
            // 
            // cmbNgay
            // 
            this.cmbNgay.FormattingEnabled = true;
            this.cmbNgay.Location = new System.Drawing.Point(67, 42);
            this.cmbNgay.Name = "cmbNgay";
            this.cmbNgay.Size = new System.Drawing.Size(121, 24);
            this.cmbNgay.TabIndex = 21;
            // 
            // cmbThang
            // 
            this.cmbThang.FormattingEnabled = true;
            this.cmbThang.Location = new System.Drawing.Point(279, 42);
            this.cmbThang.Name = "cmbThang";
            this.cmbThang.Size = new System.Drawing.Size(121, 24);
            this.cmbThang.TabIndex = 21;
            this.cmbThang.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // cmbNam
            // 
            this.cmbNam.FormattingEnabled = true;
            this.cmbNam.Location = new System.Drawing.Point(487, 42);
            this.cmbNam.Name = "cmbNam";
            this.cmbNam.Size = new System.Drawing.Size(121, 24);
            this.cmbNam.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(399, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(170, 16);
            this.label6.TabIndex = 22;
            this.label6.Text = "DOANH THU THEO NGÀY";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(915, 450);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 28);
            this.button1.TabIndex = 23;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ThongKe1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 483);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbNam);
            this.Controls.Add(this.cmbThang);
            this.Controls.Add(this.cmbNgay);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbSP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvThongKe);
            this.Controls.Add(this.txtTong);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnMoi);
            this.Controls.Add(this.btnTK);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ThongKe1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnMoi;
        private System.Windows.Forms.Button btnTK;
        private System.Windows.Forms.DataGridView dgvThongKe;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem loạiThốngKêToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doanhThuTheoNgayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SPBCToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbNgay;
        private System.Windows.Forms.ComboBox cmbThang;
        private System.Windows.Forms.ComboBox cmbNam;
        private System.Windows.Forms.DataGridViewTextBoxColumn MSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn TSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLB;
        private System.Windows.Forms.DataGridViewTextBoxColumn DT;
        private System.Windows.Forms.DataGridViewTextBoxColumn NBan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
    }
}