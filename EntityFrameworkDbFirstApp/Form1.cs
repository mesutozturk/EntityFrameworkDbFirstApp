using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkDbFirstApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NorthwindEntities db = new NorthwindEntities();
            List<Category> kategoriler = db.Categories.OrderBy(x => x.CategoryName).ToList();
            lstKategoriler.DataSource = kategoriler;
            lstKategoriler.DisplayMember = "CategoryName";
            lstKategoriler.ValueMember = "CategoryID";
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            NorthwindEntities db = new NorthwindEntities();
            try
            {
                db.Categories.Add(new Category()
                {
                    CategoryName = txtKategoriAdi.Text,
                    Description = txtAciklama.Text
                });
                db.SaveChanges();
                lstKategoriler.DataSource = db.Categories.OrderBy(x => x.CategoryName).ToList();
                MessageBox.Show("Kategori ekleme işleminiz başarılı");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}");
            }
        }

        private Category seciliCategory;
        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstKategoriler.SelectedItem == null) return;
            try
            {
                seciliCategory = lstKategoriler.SelectedItem as Category;
                DialogResult cevap = MessageBox.Show($"{seciliCategory.CategoryName} isimli kategoriyi silmek istiyor musunuz?", "Silme işlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                    NorthwindEntities db = new NorthwindEntities();
                    seciliCategory = db.Categories.Find(seciliCategory.CategoryID);
                    db.Categories.Remove(seciliCategory);
                    db.SaveChanges();
                    MessageBox.Show("Kategori silme işlemi başarılı");
                    lstKategoriler.DataSource = db.Categories.OrderBy(x => x.CategoryName).ToList();
                }
                else
                {
                    MessageBox.Show("Silme işleminden vazgeçildi");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Kategori silme işlemi başarısız. " + ex.Message);
            }
        }
    }
}
