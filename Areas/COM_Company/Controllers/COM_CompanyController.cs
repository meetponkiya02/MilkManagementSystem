using Microsoft.AspNetCore.Mvc;
using MilkManagementSystem.DAL;
using System.Data;

namespace MilkManagementSystem.Areas.COM_Company.Controllers
{
    [Area("COM_Company")]
    [Route("COM_Company/[Controller]/[action]")]
    public class COM_CompanyController : Controller
    {
        #region DAL_Object
        COM_DAL dalCOM = new COM_DAL();

        #endregion


        public IActionResult Index(int UserID)
        {
            DataTable dt = dalCOM.dbo_COM_Company_SelectAll(UserID);

            return View("COM_CompanyList", dt);
       
        }
    }
}
