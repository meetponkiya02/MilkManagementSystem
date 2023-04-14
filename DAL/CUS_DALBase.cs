using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using MilkManagementSystem.Areas.COM_Company.Models;
using MilkManagementSystem.Areas.CUS_Customer.Models;

namespace MilkManagementSystem.DAL
{
    public class CUS_DALBase:DALHelper
    {
        #region CUS_Customer_SelectAll
        public DataTable dbo_CUS_Customer_SelectAll(int UserID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_CUS_Customer_SelectAll");
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

        #region CUS_Customer_DeleteByPK
        public bool dbo_PR_CUS_Customer_DeleteByPK(int CustomerID, int UserID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_CUS_Customer_DeleteByPK");
                sqlDB.AddInParameter(dbCMD, "CustomerID", SqlDbType.Int, CustomerID);
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

        #region CUS_Customer_SelectByPK

        public DataTable dbo_PR_CUS_Customer_SelectByPK(int CustomerID, int UserID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_CUS_Customer_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "CustomerID", SqlDbType.Int, CustomerID);
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

        #region Cus_Customer_Insert

        public bool dbo_PR_CUS_Customer_Insert(CUS_CustomerModel modelCUS_Customer)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_CUS_Customer_Insert");
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, 2);
                sqlDB.AddInParameter(dbCMD, "CustomerName", SqlDbType.NVarChar, modelCUS_Customer.CustomerName);
                sqlDB.AddInParameter(dbCMD, "Mobile", SqlDbType.NVarChar, modelCUS_Customer.Mobile);
                sqlDB.AddInParameter(dbCMD, "Email", SqlDbType.NVarChar, modelCUS_Customer.Email);
                sqlDB.AddInParameter(dbCMD, "Address", SqlDbType.NVarChar, modelCUS_Customer.Address);
                sqlDB.AddInParameter(dbCMD, "Pincode", SqlDbType.NVarChar, modelCUS_Customer.Pincode);
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

        #region CUS_Customer_UpdatebyPK

        public bool dbo_PR_CUS_Customer_UpdateByPK(CUS_CustomerModel modelCUS_Customer)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_CUS_Customer_UpdateByPK");
                sqlDB.AddInParameter(dbCMD, "CustomerID", SqlDbType.Int, modelCUS_Customer.CustomerID);
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, 2);
                sqlDB.AddInParameter(dbCMD, "CustomerName", SqlDbType.NVarChar, modelCUS_Customer.CustomerName);
                sqlDB.AddInParameter(dbCMD, "Mobile", SqlDbType.NVarChar, modelCUS_Customer.Mobile);
                sqlDB.AddInParameter(dbCMD, "Email", SqlDbType.NVarChar, modelCUS_Customer.Email);
                sqlDB.AddInParameter(dbCMD, "Address", SqlDbType.NVarChar, modelCUS_Customer.Address);
                sqlDB.AddInParameter(dbCMD, "Pincode", SqlDbType.NVarChar, modelCUS_Customer.Pincode);
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
    }
}
