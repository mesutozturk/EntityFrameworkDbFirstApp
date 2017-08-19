namespace EntityFrameworkDbFirstApp
{
    partial class Form1
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
            this.lstKategoriler = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKategoriAdi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAciklama = new System.Windows.Forms.RichTextBox();
            this.btnEkle = new System.Windows.Forms.Button();
            this.cmsSil = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.silToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsSil.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstKategoriler
            // 
            this.lstKategoriler.ContextMenuStrip = this.cmsSil;
            this.lstKategoriler.FormattingEnabled = true;
            this.lstKategoriler.Location = new System.Drawing.Point(13, 13);
            this.lstKategoriler.Name = "lstKategoriler";
            this.lstKategoriler.Size = new System.Drawing.Size(196, 316);
            this.lstKategoriler.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(215, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kategori Adı";
            // 
            // txtKategoriAdi
            // 
            this.txtKategoriAdi.Location = new System.Drawing.Point(296, 13);
            this.txtKategoriAdi.Name = "txtKategoriAdi";
            this.txtKategoriAdi.Size = new System.Drawing.Size(121, 20);
            this.txtKategoriAdi.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Açıklama";
            // 
            // txtAciklama
            // 
            this.txtAciklama.Location = new System.Drawing.Point(296, 42);
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(121, 120);
            this.txtAciklama.TabIndex = 3;
            this.txtAciklama.Text = "";
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(296, 168);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(121, 23);
            this.btnEkle.TabIndex = 4;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // cmsSil
            // 
            this.cmsSil.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.silToolStripMenuItem});
            this.cmsSil.Name = "cmsSil";
            this.cmsSil.Size = new System.Drawing.Size(153, 48);
            // 
            // silToolStripMenuItem
            // 
            this.silToolStripMenuItem.Name = "silToolStripMenuItem";
            this.silToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.silToolStripMenuItem.Text = "Sil";
            this.silToolStripMenuItem.Click += new System.EventHandler(this.silToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 430);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.txtAciklama);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtKategoriAdi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstKategoriler);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.cmsSil.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstKategoriler;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKategoriAdi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txtAciklama;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.ContextMenuStrip cmsSil;
        private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem;
    }
}

