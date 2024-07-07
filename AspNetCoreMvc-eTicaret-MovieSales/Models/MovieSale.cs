namespace AspNetCoreMvc_eTicaret_MovieSales.Models
{
    public class MovieSale   //Film Satış 
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public int TotalQuantity { get; set; }
        public decimal TotalPrice { get; set; }

        public List<MovieSaleDetail> MovieSaleDetails { get; set; }
        public Customer Customer { get; set; }

    }
}
