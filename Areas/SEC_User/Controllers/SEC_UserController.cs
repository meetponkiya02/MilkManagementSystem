using Microsoft.AspNetCore.Mvc;
using MilkManagementSystem.Areas.SEC_User.Models;
using MilkManagementSystem.DAL;
using System.Data;

namespace MilkManagementSystem.Areas.SEC_User.Controllers
{
    [Area("SEC_User")]
    [Route("SEC_User/[Controller]/[action]")]
    public class SEC_UserController : Controller
    {
        #region DAL Object
        SEC_DAL dalSEC = new SEC_DAL();

        #endregion

        #region Index

        #region Select All
        public IActionResult Index()
        {
            SEC_DAL dalSEC = new SEC_DAL();
            DataTable dt = dalSEC.dbo_PR_SEC_User_SelectAll();

            return View("SEC_UserList", dt);

        }
        #endregion

        #endregion

        #region Delete
        public IActionResult Delete(int UserID)
        {

            if (Convert.ToBoolean(dalSEC.dbo_PR_SEC_User_DeleteByPK(UserID)))
            {
                return RedirectToAction("Index");
            }
            return View("Index");

        }
        #endregion

        #region Add
        public IActionResult Add(int UserID)
        {
            #region Select By PK
            if (UserID != null)
            {

                DataTable dt = dalSEC.dbo_PR_SEC_User_SelectByPK(UserID);
                if (dt.Rows.Count > 0)
                {
                    SEC_UserModel model = new SEC_UserModel();
                    foreach (DataRow dr in dt.Rows)
                    {
                        model.UserID = Convert.ToInt32(dr["UserID"]);
                        model.UserName = dr["UserName"].ToString();
                        model.PassWord = dr["PassWord"].ToString();
                        model.RollType = dr["RollType"].ToString();
                        model.CreationDate = Convert.ToDateTime(dr["CreationDate"]);
                        model.ModificationDate = Convert.ToDateTime(dr["ModificationDate"]);

                    }
                    return View("SEC_UserAddEdit", model);
                }
            }
            #endregion

            return View("SEC_UserAddEdit");
        }
        #endregion

        #region Save 
        [HttpPost]
        public IActionResult Save(SEC_UserModel modelSEC_User)
        {


            if (modelSEC_User.UserID == null)
            {

                if (Convert.ToBoolean(dalSEC.dbo_PR_SEC_User_Insert(modelSEC_User)))
                {
                    TempData["CountryInsertMessage"] = "Record inserted successfully";

                }
            }
            else
            {
                if (Convert.ToBoolean(dalSEC.dbo_PR_SEC_User_UpdateByPK(modelSEC_User)))
                {

                    TempData["CountryUpdateMessage"] = "Record Update Successfully";

                }
                return RedirectToAction("Index");
            }



            return RedirectToAction("Add");
        }
        #endregion
    }
}
