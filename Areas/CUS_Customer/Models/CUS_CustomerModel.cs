namespace MilkManagementSystem.Areas.CUS_Customer.Models
{
    public class CUS_CustomerModel
    {

        public int? CustomerID { get; set; }

        public int? UserID { get; set; }
        public string CustomerName { get; set; } 
        
        public string Mobile { get; set; }  

        public string Email { get; set; }   

        public string Address  { get; set; }    

        public string Pincode { get; set; } 

        public DateTime CreationDate { get; set; }  

        public DateTime ModificationDate { get; set; }  
    }
}
