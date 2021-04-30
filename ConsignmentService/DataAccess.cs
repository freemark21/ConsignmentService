using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dapper;

namespace ConsignmentService
{
    public class DataAccess
    {
        public void InsertReturnItem(ReturnItem returnItem)
        {
            using (IDbConnection connection = new SqlConnection(DBhelper.CnnVal("ConsignmentReturns")))
            {
                //set sql parameters
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CustomerNumber", returnItem.CustomerNumber);
                parameters.Add("@UserID", returnItem.UserID);
                parameters.Add("@Cono", returnItem.Cono);
                parameters.Add("@Whse", returnItem.Whse);
                parameters.Add("@ReplenexNumber", returnItem.ReplenexNumber);
                parameters.Add("@Qty", returnItem.Qty);
                parameters.Add("@UnitOfIssue", returnItem.UnitOfIssue);
                parameters.Add("@ProductName", returnItem.ProductName);
                parameters.Add("@SupplyProPrice", returnItem.SupplyProPrice);
                parameters.Add("@ShipTo", returnItem.ShipTo);

                //execute stored procedure
                connection.Query("spConsignmentReturns_InsertReturnItem", parameters, commandType: CommandType.StoredProcedure);
            }
        }

    }
}
