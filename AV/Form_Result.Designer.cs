namespace AV
{
    partial class Form_Result
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_xoa_all = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.dgv_STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_filenhiem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_hanhdong = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgv_STT,
            this.dgv_filenhiem,
            this.dgv_hanhdong});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(577, 319);
            this.dataGridView1.TabIndex = 0;
            // 
            // btn_xoa_all
            // 
            this.btn_xoa_all.Location = new System.Drawing.Point(440, 341);
            this.btn_xoa_all.Name = "btn_xoa_all";
            this.btn_xoa_all.Size = new System.Drawing.Size(75, 23);
            this.btn_xoa_all.TabIndex = 1;
            this.btn_xoa_all.Text = "Xóa tất cả";
            this.btn_xoa_all.UseVisualStyleBackColor = true;
            this.btn_xoa_all.Click += new System.EventHandler(this.btn_xoa_all_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(521, 341);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(68, 23);
            this.btn_OK.TabIndex = 2;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // dgv_STT
            // 
            this.dgv_STT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgv_STT.HeaderText = "STT";
            this.dgv_STT.Name = "dgv_STT";
            this.dgv_STT.Width = 50;
            // 
            // dgv_filenhiem
            // 
            this.dgv_filenhiem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgv_filenhiem.HeaderText = "File bị nhiễm";
            this.dgv_filenhiem.Name = "dgv_filenhiem";
            this.dgv_filenhiem.Width = 400;
            // 
            // dgv_hanhdong
            // 
            this.dgv_hanhdong.HeaderText = "Xóa/Bỏ qua";
            this.dgv_hanhdong.Name = "dgv_hanhdong";
            this.dgv_hanhdong.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_hanhdong.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgv_hanhdong.Width = 83;
            // 
            // Form_Result
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 376);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_xoa_all);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form_Result";
            this.Text = "Form_Result";
            this.Load += new System.EventHandler(this.Form_Result_Load);
<<<<<<< HEAD
=======
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
>>>>>>> refs/remotes/origin/master
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_xoa_all;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_filenhiem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgv_hanhdong;
    }
}