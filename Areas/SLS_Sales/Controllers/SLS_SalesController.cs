using Microsoft.AspNetCore.Mvc;
using MilkManagementSystem.DAL;
using System.Data;

namespace MilkManagementSystem.Areas.SLS_Sales.Controllers
{
    [Area("SLS_Sales")]
    [Route("SLS_Sales/[Controller]/[action]")]
    public class SLS_SalesController : Controller
    {
        #region DAL_Object
        SLS_DAL dalSLS= new SLS_DAL();

        #endregion

        #region Index
        public IActionResult Index(int UserID)
        {
            DataTable dt = dalSLS.dbo_SLS_Sale_SelectAll(UserID);

            return View("SLS_SalesList", dt);

        }
        #endregion

    }
}
