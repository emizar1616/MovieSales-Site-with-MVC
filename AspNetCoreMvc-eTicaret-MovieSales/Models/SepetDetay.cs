namespace AspNetCoreMvc_eTicaret_MovieSales.Models
{
    public class SepetDetay
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public int MovieQuantity { get; set; }
        public decimal MoviePrice { get; set; }
        public List<SepetDetay> SepeteEkle(List<SepetDetay> sepet, SepetDetay siparis)
        {
            if (sepet.Any(s => s.MovieId == siparis.MovieId))
            {
                //Sipariş olarak gelen üründen önceden sepette var , o zaman miktarını arttırırız.
                foreach (var s in sepet)
                {
                    // aynı ürünü bulup , miktarını sipariş miktarı kadar arttırıyoruz.
                    if (s.MovieId == siparis.MovieId)
                    {
                        s.MovieQuantity += siparis.MovieQuantity;
                    }
                }
            }
            else
            {
                //Yeni ürün gelmiştir. İlk defa sepete atılacaktır.
                sepet.Add(siparis);
            }
            return sepet;
        }

        public List<SepetDetay> SepettenSil(List<SepetDetay> sepet, int id)
        {
            sepet.RemoveAll(s => s.MovieId == id);
            return sepet;
        }

        public int ToplamAdet(List<SepetDetay> sepet)
        {
            var toplamAdet = sepet.Sum(s => s.MovieQuantity);
            return toplamAdet;
        }

        public decimal ToplamTutar(List<SepetDetay> sepet)
        {
            var toplamTutar = sepet.Sum(s => s.MovieQuantity * s.MoviePrice);
            return toplamTutar;
        }
    }
}
