using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using MilkManagementSystem.Areas.CUS_Customer.Models;
using MilkManagementSystem.Areas.PRS_Purchase.Models;
using MilkManagementSystem.Areas.SLS_Sales.Models;

namespace MilkManagementSystem.DAL
{
    public class SLS_DALBase:DALHelper
    {
        #region SLS_Sale_SelectAll
        public DataTable dbo_SLS_Sale_SelectAll(int UserID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SLS_Sales_SelectAll");
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

        #region SLS_Sales_Insert

        public bool dbo_PR_SLS_Sales_Insert(SLS_SalesModel modelSLS_Sales)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SLS_Sales_Insert");
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, 2);
                sqlDB.AddInParameter(dbCMD, "CompanyID", SqlDbType.Int, modelSLS_Sales.CompanyID);
                sqlDB.AddInParameter(dbCMD, "CustomerID", SqlDbType.Int, modelSLS_Sales.CustomerID);
                sqlDB.AddInParameter(dbCMD, "SaleQuantity", SqlDbType.NVarChar, modelSLS_Sales.SaleQuantity);
                sqlDB.AddInParameter(dbCMD, "Price", SqlDbType.Decimal, modelSLS_Sales.Price);
                sqlDB.AddInParameter(dbCMD, "PaymentStatus", SqlDbType.Bit, modelSLS_Sales.PaymentStatus);
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

        #region SLS_Sales_UpdateByPK

        public bool dbo_PR_SLS_Sales_UpdateByPK(SLS_SalesModel modelSLS_Sales)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SLS_Sales_UpdateByPK");
                sqlDB.AddInParameter(dbCMD, "SaleID", SqlDbType.Int, modelSLS_Sales.SaleID);
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, 2);
                sqlDB.AddInParameter(dbCMD, "CompanyID", SqlDbType.Int, modelSLS_Sales.CompanyID);
                sqlDB.AddInParameter(dbCMD, "CustomerID", SqlDbType.Int, modelSLS_Sales.CustomerID);
                sqlDB.AddInParameter(dbCMD, "SaleQuantity", SqlDbType.NVarChar, modelSLS_Sales.SaleQuantity);
                sqlDB.AddInParameter(dbCMD, "Price", SqlDbType.Decimal, modelSLS_Sales.Price);
                sqlDB.AddInParameter(dbCMD, "PaymentStatus", SqlDbType.Bit, modelSLS_Sales.PaymentStatus);
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

        #region SLS_Sale_SelectByPK

        public DataTable dbo_PR_SLS_Sales_SelectByPK(int SaleID, int UserID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SLS_Sales_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "SaleID", SqlDbType.Int, SaleID);
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

        #region SLS_Sale_DeleteByPK
        public bool dbo_PR_SLS_Sales_DeleteByPK(int SaleID, int UserID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SLS_Sales_DeleteByPK");
                sqlDB.AddInParameter(dbCMD, "SaleID", SqlDbType.Int, SaleID);
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

        #region CUS_CustomerDropDown

        public DataTable dbo_CUS_Customer_SelectByDropdownList()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_CUS_Customer_SelectFromDropdown");
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
