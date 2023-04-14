namespace MilkManagementSystem.Areas.PRS_Purchase.Models
{
    public class PRS_PurchaseModel
    {
        public int? PurchaseID { get; set; }

        public int? UserID { get; set; }

        public int? CompanyID { get; set; }
        public string CompanyName { get; set; } 

        public string  Quantity { get; set; }

        public decimal? Price { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}
