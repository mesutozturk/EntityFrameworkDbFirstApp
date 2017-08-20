namespace EntityFrameworkDbFirstApp.ViewModels
{
    public class KDVLiViewModel
    {
        public int UrunID { get; set; }
        public string UrunAdi { get; set; }
        public short? Stok { get; set; }
        public decimal? Fiyat { get; set; }
        public decimal? KDVli { get; set; }
    }
}
