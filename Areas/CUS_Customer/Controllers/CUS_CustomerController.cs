using Microsoft.AspNetCore.Mvc;
using MilkManagementSystem.Areas.COM_Company.Models;
using MilkManagementSystem.Areas.CUS_Customer.Models;
using MilkManagementSystem.DAL;
using System.Data;

namespace MilkManagementSystem.Areas.CUS_Customer.Controllers
{
    [Area("CUS_Customer")]
    [Route("CUS_Customer/[Controller]/[action]")]
    public class CUS_CustomerController : Controller
    {
        #region DAL_Object
        CUS_DAL dalCUS = new CUS_DAL();

        #endregion

        #region Index
        public IActionResult Index(int UserID)
        {
            DataTable dt = dalCUS.dbo_CUS_Customer_SelectAll(UserID);

            return View("CUS_CustomerList", dt);

        }
        #endregion

        #region Add
        public IActionResult Add(int CustomerID, int UserID)
        {
            #region Select By PK
            if (CustomerID != null)
            {

                DataTable dt = dalCUS.dbo_PR_CUS_Customer_SelectByPK(CustomerID, UserID);
                if (dt.Rows.Count > 0)
                {
                    CUS_CustomerModel model = new CUS_CustomerModel();
                    foreach (DataRow dr in dt.Rows)
                    {
                        model.CustomerID = Convert.ToInt32(dr["CustomerID"]);
                        model.CustomerName = dr["CustomerName"].ToString();
                        model.Mobile = dr["Mobile"].ToString();
                        model.Email = dr["Email"].ToString();
                        model.Address = dr["Address"].ToString();
                        model.Pincode = dr["Pincode"].ToString();
                        model.CreationDate = Convert.ToDateTime(dr["CreationDate"]);
                        model.ModificationDate = Convert.ToDateTime(dr["ModificationDate"]);

                    }
                    return View("CUS_CustomerAddEdit", model);
                }

            }
            #endregion

            return View("CUS_CustomerAddEdit");
        }
        #endregion

        #region Save 
        [HttpPost]
        public IActionResult Save(CUS_CustomerModel modelCUS_Customer)
        {


            if (modelCUS_Customer.CustomerID == null)
            {

                if (Convert.ToBoolean(dalCUS.dbo_PR_CUS_Customer_Insert(modelCUS_Customer)))
                {
                    TempData["CustomerInsert"] = "Record inserted successfully";

                }
            }
            else
            {
                if (Convert.ToBoolean(dalCUS.dbo_PR_CUS_Customer_UpdateByPK(modelCUS_Customer)))
                {

                    TempData["CustomerUpdate"] = "Record Update Successfully";

                }
                return RedirectToAction("Index");
            }



            return RedirectToAction("Add");
        }
        #endregion

        #region Delete
        public IActionResult Delete(int CustomerID, int UserID)
        {

            if (Convert.ToBoolean(dalCUS.dbo_PR_CUS_Customer_DeleteByPK(CustomerID, UserID)))
            {
                return RedirectToAction("Index");
            }
            return View("Index");

        }
        #endregion
    }
}
