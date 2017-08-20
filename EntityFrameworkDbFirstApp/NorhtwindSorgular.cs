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
    public partial class NorhtwindSorgular : Form
    {
        public NorhtwindSorgular()
        {
            InitializeComponent();
        }

        private void btnCalistir_Click(object sender, EventArgs e)
        {
            NorthwindEntities db = new NorthwindEntities();
            //ürünler tablosundan productID,productname,unitprice ve ürünün categoryname' ini, productname e göre adanzye sıralı getiren sorgu
            var sorgu1 = db.Products
                .Where(x => x.UnitsInStock > 10)//şart eklemek için kullandık. stoğu 10dan büyük ürünleri getirmek için
                .Select(x => new
                {
                    UrunID = x.ProductID,
                    UrunAdi = x.ProductName,
                    Fiyat = x.UnitPrice,
                    Stok = x.UnitsInStock,
                    KategoriAdi = x.Category.CategoryName
                }) // tüm kolonları görmek istemediğimiz için
                .OrderByDescending(x => x.Fiyat) //fiyata göre büyükten küçüğe sıraladık
                .ThenBy(x => x.UrunAdi) // ürün adına göre a'dan z'ye sıraladık
                .ToList();

            dataGridView1.DataSource = sorgu1;
            this.Text = $"Toplam Ürün Sayısı: {db.Products.Count()}";

            //en pahalı 5 ürün ?
            var sorgu2 = db.Products
                .OrderByDescending(x => x.UnitPrice)
                .Take(5)
                .Select(x => new
                {
                    UrunID = x.ProductID,
                    UrunAdi = x.ProductName,
                    Fiyat = x.UnitPrice,
                    Stok = x.UnitsInStock,
                    KategoriAdi = x.Category.CategoryName
                }).ToList();
        }
    }
}
