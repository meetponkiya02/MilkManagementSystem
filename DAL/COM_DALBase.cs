using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace MilkManagementSystem.DAL
{
    public class COM_DALBase : DALHelper
    {

        #region dbo.PR_COM_Company_SelectAll
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
    }
}
