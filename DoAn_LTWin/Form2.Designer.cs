namespace do_an
{
    partial class Form2
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
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            label2 = new Label();
            btnMoi = new Button();
            dgvThongKe = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            button1 = new Button();
            btnThongKe = new Button();
            button4 = new Button();
            toolStrip1 = new ToolStrip();
            toolStripLabel5 = new ToolStripLabel();
            cmbNgay = new ToolStripComboBox();
            toolStripSeparator3 = new ToolStripSeparator();
            toolStripLabel1 = new ToolStripLabel();
            cmbThang = new ToolStripComboBox();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripLabel2 = new ToolStripLabel();
            cmbNam = new ToolStripComboBox();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripLabel3 = new ToolStripLabel();
            cmbSP = new ToolStripComboBox();
            toolStripLabel4 = new ToolStripLabel();
            toolStripTextBox1 = new ToolStripTextBox();
            ((System.ComponentModel.ISupportInitialize)dgvThongKe).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(378, 43);
            label2.Name = "label2";
            label2.Size = new Size(204, 20);
            label2.TabIndex = 17;
            label2.Text = "SẢN PHẨM BÁN CHẠY NHẤT";
            // 
            // btnMoi
            // 
            btnMoi.Location = new Point(920, 66);
            btnMoi.Name = "btnMoi";
            btnMoi.Size = new Size(94, 29);
            btnMoi.TabIndex = 12;
            btnMoi.Text = "Làm Mới";
            btnMoi.UseVisualStyleBackColor = true;
            // 
            // dgvThongKe
            // 
            dgvThongKe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvThongKe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvThongKe.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column7, Column4, Column3 });
            dgvThongKe.Location = new Point(-9, 101);
            dgvThongKe.Name = "dgvThongKe";
            dgvThongKe.RowHeadersWidth = 51;
            dgvThongKe.Size = new Size(1023, 389);
            dgvThongKe.TabIndex = 14;
            // 
            // Column1
            // 
            Column1.HeaderText = "MaSP";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.HeaderText = "Tên SP";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            // 
            // Column7
            // 
            Column7.HeaderText = "Loại SP";
            Column7.MinimumWidth = 6;
            Column7.Name = "Column7";
            // 
            // Column4
            // 
            Column4.HeaderText = "Số Lượng Bán";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            // 
            // Column3
            // 
            Column3.HeaderText = "Doanh Thu";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            // 
            // button1
            // 
            button1.Location = new Point(-111, 27);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 13;
            button1.Text = "Thống Kê";
            button1.UseVisualStyleBackColor = true;
            // 
            // btnThongKe
            // 
            btnThongKe.Location = new Point(803, 66);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Size = new Size(94, 29);
            btnThongKe.TabIndex = 22;
            btnThongKe.Text = "Thống Kê";
            btnThongKe.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(920, 496);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 24;
            button4.Text = "Thoát";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel5, cmbNgay, toolStripSeparator3, toolStripLabel1, cmbThang, toolStripSeparator1, toolStripLabel2, cmbNam, toolStripSeparator2, toolStripLabel3, cmbSP, toolStripLabel4, toolStripTextBox1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1026, 28);
            toolStrip1.TabIndex = 27;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel5
            // 
            toolStripLabel5.Name = "toolStripLabel5";
            toolStripLabel5.Size = new Size(44, 25);
            toolStripLabel5.Text = "Ngày";
            // 
            // cmbNgay
            // 
            cmbNgay.Name = "cmbNgay";
            cmbNgay.Size = new Size(121, 28);
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 28);
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(50, 25);
            toolStripLabel1.Text = "Tháng";
            // 
            // cmbThang
            // 
            cmbThang.AutoCompleteCustomSource.AddRange(new string[] { "Tất cả các tháng", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" });
            cmbThang.Name = "cmbThang";
            cmbThang.Size = new Size(121, 28);
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 28);
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(41, 25);
            toolStripLabel2.Text = "Năm";
            // 
            // cmbNam
            // 
            cmbNam.AutoCompleteCustomSource.AddRange(new string[] { "Tất cả các năm", "2023", "2024", "2025" });
            cmbNam.Name = "cmbNam";
            cmbNam.Size = new Size(121, 28);
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 28);
            // 
            // toolStripLabel3
            // 
            toolStripLabel3.Name = "toolStripLabel3";
            toolStripLabel3.Size = new Size(112, 25);
            toolStripLabel3.Text = "Chọn Sản Phẩm";
            // 
            // cmbSP
            // 
            cmbSP.Name = "cmbSP";
            cmbSP.Size = new Size(121, 28);
            // 
            // toolStripLabel4
            // 
            toolStripLabel4.Name = "toolStripLabel4";
            toolStripLabel4.Size = new Size(34, 25);
            toolStripLabel4.Text = "Top";
            // 
            // toolStripTextBox1
            // 
            toolStripTextBox1.Name = "toolStripTextBox1";
            toolStripTextBox1.Size = new Size(100, 28);
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1026, 532);
            Controls.Add(toolStrip1);
            Controls.Add(button4);
            Controls.Add(btnThongKe);
            Controls.Add(label2);
            Controls.Add(btnMoi);
            Controls.Add(dgvThongKe);
            Controls.Add(button1);
            Name = "Form2";
            Text = "Sản Phẩm Bán Chạy";
            ((System.ComponentModel.ISupportInitialize)dgvThongKe).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label label2;
        private Button btnMoi;
        private DataGridView dgvThongKe;
        private Button button1;
        private Button btnThongKe;
        private Button button4;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column3;
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel5;
        private ToolStripComboBox cmbNgay;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripLabel toolStripLabel1;
        private ToolStripComboBox cmbThang;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripLabel toolStripLabel2;
        private ToolStripComboBox cmbNam;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripLabel toolStripLabel3;
        private ToolStripComboBox cmbSP;
        private ToolStripLabel toolStripLabel4;
        private ToolStripTextBox toolStripTextBox1;
    }
}