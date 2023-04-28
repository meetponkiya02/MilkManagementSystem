namespace MilkManagementSystem.Areas.SLS_Sales.Models
{
    public class SLS_SalesModel
    {
        public int? SaleID { get; set; }    
        public int? UsreID { get; set; }
        public int CompanyID { get; set; }

        public int CustomerID { get; set; } 

        public string SaleQuantity { get; set; }    

        public decimal Price { get; set; }

        public bool PaymentStatus { get; set; }

        public DateTime Date { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}
