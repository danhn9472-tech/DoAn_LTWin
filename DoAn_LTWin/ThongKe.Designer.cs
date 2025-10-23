namespace do_an
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            menuStrip1 = new MenuStrip();
            ChucNangToolStripMenuItem = new ToolStripMenuItem();
            doanhThulStripMenuItem = new ToolStripMenuItem();
            TonKhoToolStripMenuItem = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            toolStripLabel5 = new ToolStripLabel();
            toolStripComboBox5 = new ToolStripComboBox();
            toolStripSeparator3 = new ToolStripSeparator();
            toolStripLabel1 = new ToolStripLabel();
            toolStripComboBox1 = new ToolStripComboBox();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripLabel2 = new ToolStripLabel();
            toolStripComboBox2 = new ToolStripComboBox();
            toolStripSeparator2 = new ToolStripSeparator();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            button2 = new Button();
            label3 = new Label();
            textBox1 = new TextBox();
            toolStripLabel3 = new ToolStripLabel();
            toolStripComboBox3 = new ToolStripComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(0, 60);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 3;
            button1.Text = "Thống Kê";
            button1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column7, Column3, Column4, Column5, Column6 });
            dataGridView1.Location = new Point(0, 95);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1023, 389);
            dataGridView1.TabIndex = 4;
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
            // Column3
            // 
            Column3.HeaderText = "Đơn Giá";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.HeaderText = "Số Lượng Bán";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            // 
            // Column5
            // 
            Column5.HeaderText = "Doanh Thu";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            // 
            // Column6
            // 
            Column6.HeaderText = "Ngày Bán ";
            Column6.MinimumWidth = 6;
            Column6.Name = "Column6";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { ChucNangToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1023, 28);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // ChucNangToolStripMenuItem
            // 
            ChucNangToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { doanhThulStripMenuItem, TonKhoToolStripMenuItem });
            ChucNangToolStripMenuItem.Name = "ChucNangToolStripMenuItem";
            ChucNangToolStripMenuItem.Size = new Size(118, 24);
            ChucNangToolStripMenuItem.Text = "Loại Thống Kê";
            // 
            // doanhThulStripMenuItem
            // 
            doanhThulStripMenuItem.Name = "doanhThulStripMenuItem";
            doanhThulStripMenuItem.Size = new Size(258, 26);
            doanhThulStripMenuItem.Text = "Doanh Thu Theo Ngày";
            // 
            // TonKhoToolStripMenuItem
            // 
            TonKhoToolStripMenuItem.Name = "TonKhoToolStripMenuItem";
            TonKhoToolStripMenuItem.Size = new Size(258, 26);
            TonKhoToolStripMenuItem.Text = "Sản Phẩm Bán Chạy Nhất";
            TonKhoToolStripMenuItem.Click += TonKhoToolStripMenuItem_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel5, toolStripComboBox5, toolStripSeparator3, toolStripLabel1, toolStripComboBox1, toolStripSeparator1, toolStripLabel2, toolStripComboBox2, toolStripSeparator2, toolStripLabel3, toolStripComboBox3 });
            toolStrip1.Location = new Point(0, 28);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1023, 28);
            toolStrip1.TabIndex = 6;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel5
            // 
            toolStripLabel5.Name = "toolStripLabel5";
            toolStripLabel5.Size = new Size(44, 25);
            toolStripLabel5.Text = "Ngày";
            // 
            // toolStripComboBox5
            // 
            toolStripComboBox5.Name = "toolStripComboBox5";
            toolStripComboBox5.Size = new Size(121, 28);
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
            // toolStripComboBox1
            // 
            toolStripComboBox1.AutoCompleteCustomSource.AddRange(new string[] { "Tất cả các tháng", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" });
            toolStripComboBox1.Name = "toolStripComboBox1";
            toolStripComboBox1.Size = new Size(121, 28);
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
            // toolStripComboBox2
            // 
            toolStripComboBox2.AutoCompleteCustomSource.AddRange(new string[] { "Tất cả các năm", "2023", "2024", "2025" });
            toolStripComboBox2.Name = "toolStripComboBox2";
            toolStripComboBox2.Size = new Size(121, 28);
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 28);
            // 
            // button2
            // 
            button2.Location = new Point(112, 60);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 3;
            button2.Text = "Làm Mới";
            button2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 493);
            label3.Name = "label3";
            label3.Size = new Size(119, 20);
            label3.TabIndex = 9;
            label3.Text = "Tổng Doanh Thu";
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(224, 224, 224);
            textBox1.Location = new Point(137, 490);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 10;
            // 
            // toolStripLabel3
            // 
            toolStripLabel3.Name = "toolStripLabel3";
            toolStripLabel3.Size = new Size(112, 25);
            toolStripLabel3.Text = "Chọn Sản Phẩm";
            // 
            // toolStripComboBox3
            // 
            toolStripComboBox3.Name = "toolStripComboBox3";
            toolStripComboBox3.Size = new Size(121, 28);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1023, 522);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(toolStrip1);
            Controls.Add(dataGridView1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Thống kê ";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private DataGridView dataGridView1;
        private MenuStrip menuStrip1;
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripComboBox toolStripComboBox1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem ChucNangToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ToolStripLabel toolStripLabel2;
        private ToolStripComboBox toolStripComboBox2;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem doanhThulStripMenuItem;
        private ToolStripMenuItem TonKhoToolStripMenuItem;
        private Button button2;
        private ToolStripLabel toolStripLabel5;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripComboBox toolStripComboBox5;
        private Label label3;
        private TextBox textBox1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private ToolStripLabel toolStripLabel3;
        private ToolStripComboBox toolStripComboBox3;
    }
}
