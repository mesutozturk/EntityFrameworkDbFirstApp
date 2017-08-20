namespace EntityFrameworkDbFirstApp
{
    partial class NorhtwindSorgular
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
            this.btnCalistir = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnGeri = new System.Windows.Forms.Button();
            this.btnIleri = new System.Windows.Forms.Button();
            this.lblSayfaNo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCalistir
            // 
            this.btnCalistir.Location = new System.Drawing.Point(13, 13);
            this.btnCalistir.Name = "btnCalistir";
            this.btnCalistir.Size = new System.Drawing.Size(118, 37);
            this.btnCalistir.TabIndex = 0;
            this.btnCalistir.Text = "Çalıştır";
            this.btnCalistir.UseVisualStyleBackColor = true;
            this.btnCalistir.Click += new System.EventHandler(this.btnCalistir_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 75);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(676, 300);
            this.dataGridView1.TabIndex = 1;
            // 
            // btnGeri
            // 
            this.btnGeri.Location = new System.Drawing.Point(218, 46);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new System.Drawing.Size(75, 23);
            this.btnGeri.TabIndex = 2;
            this.btnGeri.Text = "<<<<";
            this.btnGeri.UseVisualStyleBackColor = true;
            // 
            // btnIleri
            // 
            this.btnIleri.Location = new System.Drawing.Point(299, 46);
            this.btnIleri.Name = "btnIleri";
            this.btnIleri.Size = new System.Drawing.Size(75, 23);
            this.btnIleri.TabIndex = 2;
            this.btnIleri.Text = ">>>>";
            this.btnIleri.UseVisualStyleBackColor = true;
            // 
            // lblSayfaNo
            // 
            this.lblSayfaNo.AutoSize = true;
            this.lblSayfaNo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSayfaNo.Location = new System.Drawing.Point(257, 13);
            this.lblSayfaNo.Name = "lblSayfaNo";
            this.lblSayfaNo.Size = new System.Drawing.Size(71, 19);
            this.lblSayfaNo.TabIndex = 3;
            this.lblSayfaNo.Text = "Sayfa: 1";
            // 
            // NorhtwindSorgular
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 387);
            this.Controls.Add(this.lblSayfaNo);
            this.Controls.Add(this.btnIleri);
            this.Controls.Add(this.btnGeri);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnCalistir);
            this.Name = "NorhtwindSorgular";
            this.Text = "NorhtwindSorgular";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCalistir;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnGeri;
        private System.Windows.Forms.Button btnIleri;
        private System.Windows.Forms.Label lblSayfaNo;
    }
}