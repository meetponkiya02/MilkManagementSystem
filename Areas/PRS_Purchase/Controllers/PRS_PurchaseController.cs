using Microsoft.AspNetCore.Mvc;
using MilkManagementSystem.Areas.COM_Company.Models;
using MilkManagementSystem.Areas.CUS_Customer.Models;
using MilkManagementSystem.Areas.PRS_Purchase.Models;
using MilkManagementSystem.DAL;
using System.Data;

namespace MilkManagementSystem.Areas.PRS_Purchase.Controllers
{
    [Area("PRS_Purchase")]
    [Route("PRS_Purchase/[Controller]/[action]")]
    public class PRS_PurchaseController : Controller
    {
      
        #region DAL_Object
        PRS_DAL dalPRS = new PRS_DAL();

        #endregion

        #region Index
        public IActionResult Index(int UserID)
        {
            DataTable dt = dalPRS.dbo_PRS_Purchase_SelectAll(UserID);

            return View("PRS_PurchaseList", dt);

        }
        #endregion

        #region Add
        public IActionResult Add(int PurchaseID, int UserID)
        {
            #region Company Drop Down

            DataTable dtCompany = dalPRS.dbo_COM_Company_SelectByDropdownList();

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

            #region Select By PK
            if (PurchaseID != null)
            {

                DataTable dt = dalPRS.dbo_PR_PRS_Purchase_SelectByPK(PurchaseID, UserID);
                if (dt.Rows.Count > 0)
                {
                    PRS_PurchaseModel model = new PRS_PurchaseModel();
                    foreach (DataRow dr in dt.Rows)
                    {
                        model.PurchaseID = Convert.ToInt32(dr["PurchaseID"]);
                        model.CompanyID = Convert.ToInt32(dr["CompanyID"]);
                        model.Quantity = dr["Quantity"].ToString();
                        model.Price = Convert.ToDecimal(dr["Price"]);
                        model.Date = Convert.ToDateTime(dr["Date"]);
                        model.CreationDate = Convert.ToDateTime(dr["CreationDate"]);
                        model.ModificationDate = Convert.ToDateTime(dr["ModificationDate"]);

                    }
                    return View("PRS_PurchaseAddEdit", model);
                }

            }
            #endregion

            return View("PRS_PurchaseAddEdit");
        }
        #endregion

        #region Save 
        [HttpPost]
        public IActionResult Save(PRS_PurchaseModel modelPRS_Purchase)
        {


            if (modelPRS_Purchase.PurchaseID == null)
            {

                if (Convert.ToBoolean(dalPRS.dbo_PR_PRS_Purchase_Insert(modelPRS_Purchase)))
                {
                    TempData["PurchaseInsertMessage"] = "Record inserted successfully";

                }
            }
            else
            {
                if (Convert.ToBoolean(dalPRS.dbo_PR_PRS_Purchase_UpdateByPK(modelPRS_Purchase)))
                {

                    TempData["PurchaseUpdateMessage"] = "Record Update Successfully";

                }
                return RedirectToAction("Index");
            }



            return RedirectToAction("Add");
        }
        #endregion

        #region Delete
        public IActionResult Delete(int PurchaseID, int UserID)
        {

            if (Convert.ToBoolean(dalPRS.dbo_PR_PRS_Purchase_DeleteByPK(PurchaseID, UserID)))
            {
                return RedirectToAction("Index");
            }
            return View("Index");

        }
        #endregion

    }
}
