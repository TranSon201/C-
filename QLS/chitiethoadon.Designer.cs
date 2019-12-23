namespace QLS
{
    partial class chitiethoadon
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
            this.dataGridViewchitiethd = new System.Windows.Forms.DataGridView();
            this.textMasach = new System.Windows.Forms.TextBox();
            this.textSoluong = new System.Windows.Forms.TextBox();
            this.buttonthemchitiet = new System.Windows.Forms.Button();
            this.buttonsuachitiet = new System.Windows.Forms.Button();
            this.buttonxoachitiet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewchitiethd)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewchitiethd
            // 
            this.dataGridViewchitiethd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewchitiethd.Location = new System.Drawing.Point(12, 21);
            this.dataGridViewchitiethd.Name = "dataGridViewchitiethd";
            this.dataGridViewchitiethd.Size = new System.Drawing.Size(260, 150);
            this.dataGridViewchitiethd.TabIndex = 0;
            this.dataGridViewchitiethd.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewchitiethd_CellContentClick);
            // 
            // textMasach
            // 
            this.textMasach.Location = new System.Drawing.Point(79, 193);
            this.textMasach.Name = "textMasach";
            this.textMasach.Size = new System.Drawing.Size(100, 20);
            this.textMasach.TabIndex = 1;
            // 
            // textSoluong
            // 
            this.textSoluong.Location = new System.Drawing.Point(79, 239);
            this.textSoluong.Name = "textSoluong";
            this.textSoluong.Size = new System.Drawing.Size(100, 20);
            this.textSoluong.TabIndex = 2;
            // 
            // buttonthemchitiet
            // 
            this.buttonthemchitiet.Location = new System.Drawing.Point(12, 288);
            this.buttonthemchitiet.Name = "buttonthemchitiet";
            this.buttonthemchitiet.Size = new System.Drawing.Size(75, 23);
            this.buttonthemchitiet.TabIndex = 3;
            this.buttonthemchitiet.Text = "Thêm";
            this.buttonthemchitiet.UseVisualStyleBackColor = true;
            this.buttonthemchitiet.Click += new System.EventHandler(this.buttonthemchitiet_Click);
            // 
            // buttonsuachitiet
            // 
            this.buttonsuachitiet.Location = new System.Drawing.Point(104, 288);
            this.buttonsuachitiet.Name = "buttonsuachitiet";
            this.buttonsuachitiet.Size = new System.Drawing.Size(75, 23);
            this.buttonsuachitiet.TabIndex = 4;
            this.buttonsuachitiet.Text = "Sửa";
            this.buttonsuachitiet.UseVisualStyleBackColor = true;
            this.buttonsuachitiet.Click += new System.EventHandler(this.buttonsuachitiet_Click);
            // 
            // buttonxoachitiet
            // 
            this.buttonxoachitiet.Location = new System.Drawing.Point(197, 288);
            this.buttonxoachitiet.Name = "buttonxoachitiet";
            this.buttonxoachitiet.Size = new System.Drawing.Size(75, 23);
            this.buttonxoachitiet.TabIndex = 5;
            this.buttonxoachitiet.Text = "Xóa";
            this.buttonxoachitiet.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Mã Sách";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Số Lượng";
            // 
            // chitiethoadon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 323);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonxoachitiet);
            this.Controls.Add(this.buttonsuachitiet);
            this.Controls.Add(this.buttonthemchitiet);
            this.Controls.Add(this.textSoluong);
            this.Controls.Add(this.textMasach);
            this.Controls.Add(this.dataGridViewchitiethd);
            this.Name = "chitiethoadon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi Tiết Hóa Đơn";
            this.Load += new System.EventHandler(this.chitiethoadon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewchitiethd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewchitiethd;
        private System.Windows.Forms.TextBox textMasach;
        private System.Windows.Forms.TextBox textSoluong;
        private System.Windows.Forms.Button buttonthemchitiet;
        private System.Windows.Forms.Button buttonsuachitiet;
        private System.Windows.Forms.Button buttonxoachitiet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}