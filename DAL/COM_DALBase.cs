using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.ComponentModel.Design;
using MilkManagementSystem.Areas.COM_Company.Models;

namespace MilkManagementSystem.DAL
{
    public class COM_DALBase : DALHelper
    {

        #region COM_Company_SelectAll
        public DataTable dbo_COM_Company_SelectAll(int UserID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_COM_Company_SelectAll");
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

        #region COM_Company_DeleteByPK
        public bool dbo_PR_COM_Company_DeleteByPK(int CompanyID,int UserID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_COM_Company_DeleteByPK");
                sqlDB.AddInParameter(dbCMD, "CompanyID", SqlDbType.Int, CompanyID);
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

        #region COM_Company_SelectByPK

        public DataTable dbo_PR_COM_Company_SelectByPK(int CompanyID,int UserID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_COM_Company_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "CompanyID", SqlDbType.Int, CompanyID);
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

        #region COM_Company_Insert

        public bool dbo_PR_COM_Company_Insert(COM_CompanyModel modelCOM_Company)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_COM_Company_Insert");
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, 2);
                sqlDB.AddInParameter(dbCMD, "CompanyName", SqlDbType.NVarChar, modelCOM_Company.CompanyName);
                sqlDB.AddInParameter(dbCMD, "Contact", SqlDbType.NVarChar, modelCOM_Company.Contact);
                sqlDB.AddInParameter(dbCMD, "Email", SqlDbType.NVarChar, modelCOM_Company.Email);
                sqlDB.AddInParameter(dbCMD, "Address", SqlDbType.NVarChar, modelCOM_Company.Address);
                sqlDB.AddInParameter(dbCMD, "Pincode", SqlDbType.NVarChar, modelCOM_Company.Pincode);
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

        #region COM_Company_UpdateByPK

        public bool dbo_PR_COM_Company_UpdateByPK(COM_CompanyModel modelCOM_Company)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_COM_Company_UpdateByPK");
                sqlDB.AddInParameter(dbCMD, "CompanyID", SqlDbType.Int, modelCOM_Company.CompanyID);
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, 2);

                sqlDB.AddInParameter(dbCMD, "CompanyName", SqlDbType.NVarChar, modelCOM_Company.CompanyName);
                sqlDB.AddInParameter(dbCMD, "Contact", SqlDbType.NVarChar, modelCOM_Company.Contact);
                sqlDB.AddInParameter(dbCMD, "Email", SqlDbType.NVarChar, modelCOM_Company.Email);
                sqlDB.AddInParameter(dbCMD, "Address", SqlDbType.NVarChar, modelCOM_Company.Address);
                sqlDB.AddInParameter(dbCMD, "Pincode", SqlDbType.NVarChar, modelCOM_Company.Pincode);
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
