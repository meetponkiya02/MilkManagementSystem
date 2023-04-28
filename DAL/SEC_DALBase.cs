using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using MilkManagementSystem.Areas.SEC_User.Models;

namespace MilkManagementSystem.DAL
{
    public class SEC_DALBase:DALHelper
    {
        #region SEC_User_SelectAll
        public DataTable dbo_PR_SEC_User_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SEC_User_SelectAll");

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

        #region SEC_User_Delete
        public bool dbo_PR_SEC_User_DeleteByPK(int UserID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SEC_User_DeleteByPK");
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, UserID);
                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        #endregion

        #region SEC_User_SelectByPK

        public DataTable dbo_PR_SEC_User_SelectByPK(int UserID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SEC_User_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, UserID);

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

        #region SEC_User_Insert

        public bool dbo_PR_SEC_User_Insert(SEC_UserModel modelSEC_User)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SEC_User_Insert");

                sqlDB.AddInParameter(dbCMD, "UserName", SqlDbType.NVarChar, modelSEC_User.UserName);
                sqlDB.AddInParameter(dbCMD, "PassWord", SqlDbType.NVarChar, modelSEC_User.PassWord);
                sqlDB.AddInParameter(dbCMD, "RollType", SqlDbType.NVarChar, modelSEC_User.RollType);
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

        #region SEC_User_Insert

        public bool dbo_PR_SEC_User_UpdateByPK(SEC_UserModel modelSEC_User)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SEC_User_UpdateByPK");
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, modelSEC_User.UserID);
                sqlDB.AddInParameter(dbCMD, "UserName", SqlDbType.NVarChar, modelSEC_User.UserName);
                sqlDB.AddInParameter(dbCMD, "PassWord", SqlDbType.NVarChar, modelSEC_User.PassWord);
                sqlDB.AddInParameter(dbCMD, "RollType", SqlDbType.NVarChar, modelSEC_User.RollType);
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
