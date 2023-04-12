using Microsoft.AspNetCore.Mvc;

namespace MilkManagementSystem.Areas.COM_Company.Models
{
    public class COM_CompanyModel 
    {
        public int CompanyID { get; set; }  

        public int UserID { get; set; } 
        public string CompanyName { get; set; } 

        public string Contact { get; set; }
        
        public string  Email { get; set; }  

        public string Address { get; set; } 

        public string Pincode  { get; set; }    

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }  
    }
}
