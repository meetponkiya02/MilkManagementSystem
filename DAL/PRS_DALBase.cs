using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using MilkManagementSystem.Areas.CUS_Customer.Models;
using MilkManagementSystem.Areas.PRS_Purchase.Models;

namespace MilkManagementSystem.DAL
{
    public class PRS_DALBase:DALHelper
    {
        #region PRS_Purchase_SelectAll
        public DataTable dbo_PRS_Purchase_SelectAll(int UserID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PRS_Purchase_SelectAll");
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, 2);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);

                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;

            }

        }
        #endregion

        #region PRS_Purchase_SelectByPK

        public DataTable dbo_PR_PRS_Purchase_SelectByPK(int PurchaseID, int UserID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PRS_Purchase_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "PurchaseID", SqlDbType.Int, PurchaseID);
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, 2);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);

                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }


        }

        #endregion

        #region PRS_Purchase_Insert

        public bool dbo_PR_PRS_Purchase_Insert(PRS_PurchaseModel modelPRS_Purchase)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PRS_Purchase_Insert");
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, 2);
                sqlDB.AddInParameter(dbCMD, "CompanyID", SqlDbType.Int, modelPRS_Purchase.CompanyID);
                sqlDB.AddInParameter(dbCMD, "Quantity", SqlDbType.NVarChar, modelPRS_Purchase.Quantity);
                sqlDB.AddInParameter(dbCMD, "Price", SqlDbType.Decimal, modelPRS_Purchase.Price);
                sqlDB.AddInParameter(dbCMD, "Date", SqlDbType.DateTime, DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));
                sqlDB.AddInParameter(dbCMD, "CreationDate", SqlDbType.DateTime, DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));
                sqlDB.AddInParameter(dbCMD, "ModificationDate", SqlDbType.DateTime, DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

        #region PRS_Purchase_UpadteByPK

        public bool dbo_PR_PRS_Purchase_UpdateByPK(PRS_PurchaseModel modelPRS_Purchase)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PRS_Purchase_UpdateByPK");
                sqlDB.AddInParameter(dbCMD, "PurchaseID", SqlDbType.Int, modelPRS_Purchase.PurchaseID);
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, 2);
                sqlDB.AddInParameter(dbCMD, "CompanyID", SqlDbType.Int, modelPRS_Purchase.CompanyID);
                sqlDB.AddInParameter(dbCMD, "Quantity", SqlDbType.NVarChar, modelPRS_Purchase.Quantity);
                sqlDB.AddInParameter(dbCMD, "Price", SqlDbType.Decimal, modelPRS_Purchase.Price);
                sqlDB.AddInParameter(dbCMD, "Date", SqlDbType.DateTime, DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));
                sqlDB.AddInParameter(dbCMD, "CreationDate", SqlDbType.DateTime, DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));
                sqlDB.AddInParameter(dbCMD, "ModificationDate", SqlDbType.DateTime, DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

        #region PRS_Purchase_DeleteByPK
        public bool dbo_PR_PRS_Purchase_DeleteByPK(int PurchaseID, int UserID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PRS_Purchase_DeleteByPK");
                sqlDB.AddInParameter(dbCMD, "PurchaseID", SqlDbType.Int, PurchaseID);
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, 2);
                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region COM_CompanyDropDown

        public DataTable dbo_COM_Company_SelectByDropdownList()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_COM_Company_SelectFromDropdown");
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, 2);
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

    }
}
