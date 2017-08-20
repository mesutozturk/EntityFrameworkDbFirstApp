using EntityFrameworkDbFirstApp.ViewModels;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace EntityFrameworkDbFirstApp
{
    public partial class NorhtwindSorgular : Form
    {
        public NorhtwindSorgular()
        {
            InitializeComponent();
            this.btnIleri.Click += new EventHandler(Sayfala_Click);
            this.btnGeri.Click += Sayfala_Click;
        }

        private void Sayfala_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            NorthwindEntities db = new NorthwindEntities();
            if (btn.Name == "btnIleri")
            {
                if (sayfaNo < maksimumSayfaSayisi)
                    sayfaNo++;
            }
            else
            {
                if (sayfaNo > 1)
                    sayfaNo--;
            }
            if (sayfaNo == maksimumSayfaSayisi)
                btnIleri.Enabled = false;
            else
                btnIleri.Enabled = true;
            if (sayfaNo == 1)
                btnGeri.Enabled = false;
            else
                btnGeri.Enabled = true;
            lblSayfaNo.Text = $"Sayfa: {sayfaNo}/{maksimumSayfaSayisi}";
            var sorgu2 = db.Products
                .OrderByDescending(x => x.UnitPrice)
                .Skip((sayfaNo - 1) * sayfadakiIstenenUrunSayisi)
                .Take(sayfadakiIstenenUrunSayisi)
                .Select(x => new
                {
                    UrunID = x.ProductID,
                    UrunAdi = x.ProductName,
                    Fiyat = x.UnitPrice,
                    Stok = x.UnitsInStock,
                    KategoriAdi = x.Category.CategoryName
                }).ToList();

            dataGridView1.DataSource = sorgu2;
        }

        private int sayfadakiIstenenUrunSayisi = 5, sayfaNo = 1, maksimumSayfaSayisi = 0;
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
            maksimumSayfaSayisi = (int)Math.Ceiling(db.Products.Count() / (double)sayfadakiIstenenUrunSayisi);
            lblSayfaNo.Text = $"Sayfa: {sayfaNo}/{maksimumSayfaSayisi}";


            //en pahalı 5 ürün ?
            var sorgu2 = db.Products
                .OrderByDescending(x => x.UnitPrice)
                .Skip((sayfaNo - 1) * sayfadakiIstenenUrunSayisi)
                .Take(sayfadakiIstenenUrunSayisi)
                .Select(x => new
                {
                    UrunID = x.ProductID,
                    UrunAdi = x.ProductName,
                    Fiyat = x.UnitPrice,
                    Stok = x.UnitsInStock,
                    KategoriAdi = x.Category.CategoryName
                }).ToList();

            dataGridView1.DataSource = sorgu2;


            // ürünlerimi id ad  stok miktarları fiyatlari ve fiyatlara %18 kdv eklenmiş hallerini raporlayan sorguyu yazalım.

            var sorgu3 = db.Products
                .Select(x => new KDVLiViewModel()
                {
                    UrunID = x.ProductID,
                    UrunAdi = x.ProductName,
                    Stok = x.UnitsInStock,
                    Fiyat = x.UnitPrice,
                    KDVli = x.UnitPrice * 1.18m
                })
                .ToList();
            dataGridView1.DataSource = sorgu3;

            // Çalışanlarımı ad,soyad,email  nancy davalio n.davalio@northwind.com

            var sorgu4 = db.Employees.Select(x => new CalisanMailViewModel()
            {
                Ad = x.FirstName,
                Soyad = x.LastName,
                EPosta = (x.FirstName.Substring(0, 1) + "." + x.LastName + "@northwind.com").ToLower()
            }).ToList();
            dataGridView1.DataSource = sorgu4;

            var sorgu5 = from calisan in db.Employees
                         select new CalisanMailViewModel()
                         {
                             Ad = calisan.FirstName,
                             Soyad = calisan.LastName,
                             EPosta = (calisan.FirstName.Substring(0, 1) + "." + calisan.LastName + "@northwind.com").ToLower()
                         };
            dataGridView1.DataSource = sorgu5.ToList();

            var sorgu6 = from kat in db.Categories
                         join urun in db.Products
                         on kat.CategoryID equals urun.CategoryID
                         where urun.UnitsInStock > 10 && urun.UnitPrice < 50
                         orderby urun.UnitPrice descending
                         select new
                         {
                             UrunAdi = urun.ProductName,
                             Fiyat = urun.UnitPrice,
                             KategoriAdi = kat.CategoryName
                         };
            dataGridView1.DataSource = sorgu6.ToList();

            //Siparişlerde toplam ne kadar kargo ücreti ödenmiş?
            this.Text = $"Toplam {db.Orders.Sum(x => x.Freight):c2} Kargo ödemesi yapıldı!";
            this.Text = $"Ortalama {db.Orders.Average(x => x.Freight):c2} Kargo ödemesi yapıldı!";
            this.Text = $"Max {db.Orders.Max(x => x.Freight):c2} Kargo ödemesi yapıldı!";
            this.Text = $"Min {db.Orders.Min(x => x.Freight):c2} Kargo ödemesi yapıldı!";


            //sipariş no - toplam sipariş tutarı
            //SELECT o.OrderID,SUM(od.UnitPrice * od.Quantity) Toplam FROM dbo.Orders o
            //JOIN dbo.[Order Details] od ON od.OrderID=o.OrderID
            //GROUP BY o.OrderID
            //    ORDER BY Toplam desc
            var sorgu8 = from siparis in db.Orders
                         join sdetay in db.Order_Details
                         on siparis.OrderID equals sdetay.OrderID
                         where siparis.OrderDate.Value.Year == 1996
                         group new
                         {
                             siparis,
                             sdetay
                         } by new
                         {
                             siparisId = siparis.OrderID
                         }
                into siparisIdler
                         select new
                         {
                             SiparisId = siparisIdler.Key.siparisId,
                             Toplam = siparisIdler.Sum(x => (x.sdetay.UnitPrice * x.sdetay.Quantity))
                         };

            dataGridView1.DataSource = sorgu8.OrderByDescending(x => x.Toplam).ToList();

            var sorgu9 = db.Orders.Where(x => x.OrderDate.Value.Year == 1996).GroupBy(x => new { x, x.OrderID }).Select(x => new
            {
                ID = x.Key.OrderID,
                Toplam = x.Key.x.Order_Details.Sum(y => y.UnitPrice * y.Quantity)
            }).OrderByDescending(x => x.Toplam).ToList();

            dataGridView1.DataSource = sorgu9;

            var sorgu10 = from siparisdetay in db.Order_Details
                          join urun in db.Products
                          on siparisdetay.ProductID equals urun.ProductID
                          join kategori in db.Categories
                          on urun.CategoryID equals kategori.CategoryID
                          join siparis in db.Orders
                          on siparisdetay.OrderID equals siparis.OrderID
                          group new
                          {
                              kategori,
                              urun,
                              siparisdetay
                          } by new
                          {
                              kadi = kategori.CategoryName,
                              uadi = urun.ProductName
                          }
                into kategoriurungrup
                          select new
                          {
                              KategoriAdi = kategoriurungrup.Key.kadi,
                              UrunAdi = kategoriurungrup.Key.uadi,
                              Toplam = kategoriurungrup.Sum(x => x.siparisdetay.Quantity * x.siparisdetay.UnitPrice)
                          };
            dataGridView1.DataSource = sorgu10
                .OrderBy(x => x.KategoriAdi)
                .ThenByDescending(x => x.Toplam)
                .ToList();
        }
    }
}
