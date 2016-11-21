namespace QL_KhoHang
{
    partial class frmTrangChu
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnTK = new System.Windows.Forms.Button();
            this.btnNCC = new System.Windows.Forms.Button();
            this.btnCN = new System.Windows.Forms.Button();
            this.btnXH = new System.Windows.Forms.Button();
            this.btnDSHH = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnNH = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(358, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thông Tin Kho Hàng";
            // 
            // btnTK
            // 
            this.btnTK.Location = new System.Drawing.Point(382, 243);
            this.btnTK.Name = "btnTK";
            this.btnTK.Size = new System.Drawing.Size(140, 34);
            this.btnTK.TabIndex = 1;
            this.btnTK.Text = "Thống Kê";
            this.btnTK.UseVisualStyleBackColor = true;
            this.btnTK.Click += new System.EventHandler(this.btnNH_Click);
            // 
            // btnNCC
            // 
            this.btnNCC.Location = new System.Drawing.Point(633, 121);
            this.btnNCC.Name = "btnNCC";
            this.btnNCC.Size = new System.Drawing.Size(140, 34);
            this.btnNCC.TabIndex = 2;
            this.btnNCC.Text = "Nhà Cung Cấp";
            this.btnNCC.UseVisualStyleBackColor = true;
            this.btnNCC.Click += new System.EventHandler(this.btnNCC_Click);
            // 
            // btnCN
            // 
            this.btnCN.Location = new System.Drawing.Point(633, 243);
            this.btnCN.Name = "btnCN";
            this.btnCN.Size = new System.Drawing.Size(140, 34);
            this.btnCN.TabIndex = 3;
            this.btnCN.Text = "Chi Nhánh";
            this.btnCN.UseVisualStyleBackColor = true;
            this.btnCN.Click += new System.EventHandler(this.btnCN_Click);
            // 
            // btnXH
            // 
            this.btnXH.Location = new System.Drawing.Point(124, 243);
            this.btnXH.Name = "btnXH";
            this.btnXH.Size = new System.Drawing.Size(140, 34);
            this.btnXH.TabIndex = 4;
            this.btnXH.Text = "Xuất Hàng Hóa";
            this.btnXH.UseVisualStyleBackColor = true;
            this.btnXH.Click += new System.EventHandler(this.btnXH_Click);
            // 
            // btnDSHH
            // 
            this.btnDSHH.Location = new System.Drawing.Point(382, 121);
            this.btnDSHH.Name = "btnDSHH";
            this.btnDSHH.Size = new System.Drawing.Size(140, 34);
            this.btnDSHH.TabIndex = 5;
            this.btnDSHH.Text = "Danh Sách Hàng Hóa";
            this.btnDSHH.UseVisualStyleBackColor = true;
            this.btnDSHH.Click += new System.EventHandler(this.btnDSHH_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(688, 29);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(85, 23);
            this.btnThoat.TabIndex = 6;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnNH
            // 
            this.btnNH.Location = new System.Drawing.Point(124, 121);
            this.btnNH.Name = "btnNH";
            this.btnNH.Size = new System.Drawing.Size(140, 34);
            this.btnNH.TabIndex = 7;
            this.btnNH.Text = "Nhập Hàng Hóa";
            this.btnNH.UseVisualStyleBackColor = true;
            this.btnNH.Click += new System.EventHandler(this.btnNH_Click_1);
            // 
            // frmTrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 448);
            this.Controls.Add(this.btnNH);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnDSHH);
            this.Controls.Add(this.btnXH);
            this.Controls.Add(this.btnCN);
            this.Controls.Add(this.btnNCC);
            this.Controls.Add(this.btnTK);
            this.Controls.Add(this.label1);
            this.Name = "frmTrangChu";
            this.Text = "Trang Chủ";
            this.Load += new System.EventHandler(this.frmTrangChu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTK;
        private System.Windows.Forms.Button btnNCC;
        private System.Windows.Forms.Button btnCN;
        private System.Windows.Forms.Button btnXH;
        private System.Windows.Forms.Button btnDSHH;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnNH;
    }
}