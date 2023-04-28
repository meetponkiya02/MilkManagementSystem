using Microsoft.AspNetCore.Mvc;
using MilkManagementSystem.Areas.COM_Company.Models;
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

        #region Index
        public IActionResult Index(int UserID)
        {
            DataTable dt = dalCOM.dbo_COM_Company_SelectAll(UserID);

            return View("COM_CompanyList", dt);
       
        }
        #endregion

        #region Add
        public IActionResult Add(int CompanyID,int UserID)
        {
            #region Select By PK
            if (CompanyID != null)
            {

                DataTable dt = dalCOM.dbo_PR_COM_Company_SelectByPK(CompanyID, UserID);
                if (dt.Rows.Count > 0)
                {
                    COM_CompanyModel model = new COM_CompanyModel();
                    foreach (DataRow dr in dt.Rows)
                    {
                        model.CompanyID = Convert.ToInt32(dr["CompanyID"]);
                        model.CompanyName = dr["CompanyName"].ToString();
                        model.Contact = dr["Contact"].ToString();
                        model.Email = dr["Email"].ToString();
                        model.Address = dr["Address"].ToString();
                        model.Pincode = dr["Pincode"].ToString();


                       

                        model.CreationDate = Convert.ToDateTime(dr["CreationDate"]);
                        model.ModificationDate = Convert.ToDateTime(dr["ModificationDate"]);

                    }
                    return View("COM_CompanyAddEdit", model);
                }




            }
            #endregion

            return View("COM_CompanyAddEdit");
        }
        #endregion

        #region Save 
        [HttpPost]
        public IActionResult Save(COM_CompanyModel modelCOM_Company)
        {


            if (modelCOM_Company.CompanyID == null)
            {

                if (Convert.ToBoolean(dalCOM.dbo_PR_COM_Company_Insert(modelCOM_Company)))
                {
                    TempData["CompanyInsert"] = "Record inserted successfully";

                }
            }
            else
            {
                if (Convert.ToBoolean(dalCOM.dbo_PR_COM_Company_UpdateByPK(modelCOM_Company)))
                {

                    TempData["CompanyUpdate"] = "Record Update Successfully";

                }
                return RedirectToAction("Index");
            }



            return RedirectToAction("Add");
        }
        #endregion

        #region Delete
        public IActionResult Delete(int CompanyID, int UserID)
        {

            if (Convert.ToBoolean(dalCOM.dbo_PR_COM_Company_DeleteByPK(CompanyID,UserID)))
            {
                return RedirectToAction("Index");
            }
            return View("Index");

        }
        #endregion
    }
}
