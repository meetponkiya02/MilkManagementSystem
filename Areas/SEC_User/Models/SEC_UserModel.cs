namespace MilkManagementSystem.Areas.SEC_User.Models
{
    public class SEC_UserModel
    {
        public int? UserID { get; set; }

        public string UserName { get; set; }

        public string PassWord { get; set; }

        public string RollType { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }
    }
}
