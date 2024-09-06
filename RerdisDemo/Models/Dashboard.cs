namespace RerdisDemo.Models
{
    public class Dashboard
    {
        
        public int TotalCustomersCount { get; set; }
        public int TotalRevenue { get; set; }
        public string? TopSellingProduct { get; set; }

        public string? TopSellingCountryName{get;set; }

    }
}
