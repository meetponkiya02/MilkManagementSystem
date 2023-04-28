using Microsoft.AspNetCore.Mvc;
using MilkManagementSystem.Areas.COM_Company.Models;
using MilkManagementSystem.Areas.CUS_Customer.Models;
using MilkManagementSystem.Areas.PRS_Purchase.Models;
using MilkManagementSystem.Areas.SLS_Sales.Models;
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

        #region Add
        public IActionResult Add(int SaleID, int UserID)
        {
            #region Company Drop Down

            DataTable dtCompany = dalSLS.dbo_COM_Company_SelectByDropdownList();

            List<COM_CompanyDropDownmodel> list = new List<COM_CompanyDropDownmodel>();
            foreach (DataRow dr in dtCompany.Rows)
            {
                COM_CompanyDropDownmodel vlst = new COM_CompanyDropDownmodel();
                vlst.CompanyID = Convert.ToInt32(dr["CompanyID"]);
                vlst.CompanyName = dr["CompanyName"].ToString();
                list.Add(vlst);
            }
            ViewBag.CompanyList = list;

            #endregion

            #region Customer Drop Down

            DataTable dtCustomer = dalSLS.dbo_CUS_Customer_SelectByDropdownList();

            List<CUS_CustomerDropDownmodel> list1 = new List<CUS_CustomerDropDownmodel>();
            foreach (DataRow dr in dtCustomer.Rows)
            {
                CUS_CustomerDropDownmodel vlst = new CUS_CustomerDropDownmodel();
                vlst.CustomerID = Convert.ToInt32(dr["CustomerID"]);
                vlst.CustomerName = dr["CustomerName"].ToString();
                list1.Add(vlst);
            }
            ViewBag.CustomerList = list1;

            #endregion

            #region Select By PK
            if (SaleID != null)
            {

                DataTable dt = dalSLS.dbo_PR_SLS_Sales_SelectByPK(SaleID, UserID);
                if (dt.Rows.Count > 0)
                {
                    SLS_SalesModel model = new SLS_SalesModel();
                    foreach (DataRow dr in dt.Rows)
                    {
                        model.SaleID = Convert.ToInt32(dr["SaleID"]);
                        model.CompanyID = Convert.ToInt32(dr["CompanyID"]);
                        model.CustomerID = Convert.ToInt32(dr["CustomerID"]);
                        model.SaleQuantity = dr["SaleQuantity"].ToString();
                        model.Price = Convert.ToDecimal(dr["Price"]);
                        model.PaymentStatus = Convert.ToBoolean(dr["PaymentStatus"]);
                        model.Date = Convert.ToDateTime(dr["Date"]);
                        model.CreationDate = Convert.ToDateTime(dr["CreationDate"]);
                        model.ModificationDate = Convert.ToDateTime(dr["ModificationDate"]);

                    }
                    return View("SLS_SalesAddEdit", model);
                }

            }
            #endregion

            return View("SLS_SalesAddEdit");
        }
        #endregion

        #region Save 
        [HttpPost]
        public IActionResult Save(SLS_SalesModel modelSLS_Sales)
        {


            if (modelSLS_Sales.SaleID == null)
            {

                if (Convert.ToBoolean(dalSLS.dbo_PR_SLS_Sales_Insert(modelSLS_Sales)))
                {
                    TempData["Salesinsert"] = "Record inserted successfully";

                }
            }
            else
            {
                if (Convert.ToBoolean(dalSLS.dbo_PR_SLS_Sales_UpdateByPK(modelSLS_Sales)))
                {

                    TempData["SaleUpdateMessage"] = "Record Update Successfully";

                }
                return RedirectToAction("Index");
            }



            return RedirectToAction("Add");
        }
        #endregion

        #region Delete
        public IActionResult Delete(int SaleID, int UserID)
        {

            if (Convert.ToBoolean(dalSLS.dbo_PR_SLS_Sales_DeleteByPK(SaleID, UserID)))
            {
                return RedirectToAction("Index");
            }
            return View("Index");

        }
        #endregion

    }
}
