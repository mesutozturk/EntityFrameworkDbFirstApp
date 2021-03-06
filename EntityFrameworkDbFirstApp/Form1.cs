﻿using System;
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
            lstKategoriler.DisplayMember = "CategoryName";
            lstKategoriler.ValueMember = "CategoryID";
            lstKategoriler.DataSource = kategoriler;
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
        private ListBox seciListBox;
        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (seciListBox == lstKategoriler)
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
            else if (seciListBox == lstUrunler)
            {
                if (lstUrunler.SelectedItem == null) return;
                try
                {
                    NorthwindEntities db = new NorthwindEntities();
                    seciliProduct = db.Products.Find(seciliProduct.ProductID);
                    if (seciliProduct == null)
                    {
                        MessageBox.Show("Silinecek ürün bulunamadı");
                        return;
                    }
                    db.Products.Remove(seciliProduct);
                    db.SaveChanges();
                    lstKategoriler.DataSource = db.Categories.OrderBy(x => x.CategoryName).ToList();
                    MessageBox.Show("Ürün silme işlemi başarılı");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ürün silme işlemi başarısız");
                }
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            //int a = 5;
            //int b = 15;

            //b = a;
            //a = 10;
            ////MessageBox.Show($"b nın değeri: {b}");

            //Armut a1Armut = new Armut();
            //a1Armut.Agirlik = 5;
            //Armut a2Armut = new Armut();
            //a2Armut.Agirlik = 15;

            //a2Armut = a1Armut;
            //a1Armut.Agirlik = 10;
            //MessageBox.Show($"a2armut'un ağırlık değeri: {a2Armut.Agirlik}");
            if (seciliCategory == null) return;
            try
            {
                NorthwindEntities db = new NorthwindEntities();
                seciliCategory = db.Categories.Find(seciliCategory.CategoryID);
                if (seciliCategory == null)
                {
                    MessageBox.Show("kategori bulunamadı");
                    return;
                }
                seciliCategory.CategoryName = txtKategoriAdi.Text;
                seciliCategory.Description = txtAciklama.Text;
                db.SaveChanges();
                MessageBox.Show("Güncelleme işlemi başarılı");
                lstKategoriler.DataSource = db.Categories.OrderBy(x => x.CategoryName).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme işleminde bir hata oluştu");
            }
        }

        private void lstKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstKategoriler.SelectedItem == null) return;
            seciliCategory = lstKategoriler.SelectedItem as Category;
            txtAciklama.Text = seciliCategory?.Description;
            txtKategoriAdi.Text = seciliCategory?.CategoryName;
            seciListBox = lstKategoriler;
            List<Product> urunler = seciliCategory?.Products.ToList();
            lstUrunler.DisplayMember = "ProductName";
            lstUrunler.DataSource = urunler;
        }

        private Product seciliProduct;
        private void lstUrunler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstUrunler.SelectedItem == null) return;
            seciliProduct = lstUrunler.SelectedItem as Product;
            txtUrunAdi.Text = seciliProduct?.ProductName;
            nFiyat.Value = (seciliProduct.UnitPrice.HasValue ? seciliProduct.UnitPrice.Value : 0);
            nStok.Value = (seciliProduct.UnitsInStock.HasValue ? seciliProduct.UnitsInStock.Value : 0);
            cbSatistaDegilMi.Checked = seciliProduct.Discontinued;
            seciListBox = lstUrunler;
        }

        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            try
            {
                NorthwindEntities db = new NorthwindEntities();
                db.Products.Add(new Product()
                {
                    Discontinued = cbSatistaDegilMi.Checked,
                    ProductName = txtUrunAdi.Text,
                    UnitPrice = nFiyat.Value,
                    UnitsInStock = Convert.ToInt16(nStok.Value),
                    CategoryID = seciliCategory.CategoryID
                });
                db.SaveChanges();
                lstKategoriler.DataSource = db.Categories.OrderBy(x => x.CategoryName).ToList();
                MessageBox.Show("Ürün ekleme işleminiz başarılı");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürün ekleme işleminiz başarısız " + ex.Message);
            }
        }

        private void btnUrunGuncelle_Click(object sender, EventArgs e)
        {
            if (seciliProduct == null) return;
            try
            {
                NorthwindEntities db = new NorthwindEntities();
                seciliProduct = db.Products.Find(seciliProduct.ProductID);
                if (seciliProduct == null)
                {
                    MessageBox.Show("Silinecek ürün bulunamadı");
                    return;
                }
                seciliProduct.ProductName = txtUrunAdi.Text;
                seciliProduct.UnitPrice = nFiyat.Value;
                seciliProduct.Discontinued = cbSatistaDegilMi.Checked;
                seciliProduct.UnitsInStock = Convert.ToInt16(nStok.Value);
                db.SaveChanges();
                lstKategoriler.DataSource = db.Categories.OrderBy(x => x.CategoryName).ToList();
                MessageBox.Show("Ürün güncelleme işlemi başarılı");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürün güncelleme işlemi başarısız");
            }
        }

        private void txtKategoriAra_KeyUp(object sender, KeyEventArgs e)
        {
            string key = txtKategoriAra.Text.ToLower();
            NorthwindEntities db= new NorthwindEntities();
            List<Category> bulunan = db.Categories.Where(x => x.CategoryName.ToLower().Contains(key)).ToList();
            lstKategoriler.DataSource = bulunan;
        }
    }
    public class Armut
    {
        public int Agirlik { get; set; }
    }
}


