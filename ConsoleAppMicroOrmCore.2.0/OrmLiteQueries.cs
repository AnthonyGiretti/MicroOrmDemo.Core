using ConsoleAppMicroOrmCore._2._0;
using models;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrmLite
{
    public class OrmLiteQueries
    {
        public List<Orders> GetOrders()
        {
            var ormlite = new OrmLiteConnectionFactory(@const.connectionString);

            using (var dbConnection = ormlite.OpenDbConnection())
            {
                return dbConnection.Select<Orders>(@"SELECT TOP 500 [WorkOrderID] AS Id, P.Name AS ProductName, [OrderQty] AS Quantity, [DueDate] AS Date
                                 FROM [AdventureWorks2014].[Production].[WorkOrder] AS WO 
                                 INNER JOIN[Production].[Product] AS P ON P.ProductID = WO.ProductID").ToList();
            }
        }
        public List<Orders> GetOrders(int iteration)
        {
            var ormlite = new OrmLiteConnectionFactory(@const.connectionString, SqlServer2014Dialect.Provider);

            var listOrders = new List<Orders>();
            using (var dbConnection = ormlite.OpenDbConnection())
            {

                for (int i = 1; i <= iteration; i++)
                    listOrders.Add(GetOrder(dbConnection, i));
            }

            return listOrders;
        }

        private Orders GetOrder(IDbConnection connection, int id)
        {
            return connection.Select<Orders>(@"SELECT [WorkOrderID] AS Id, P.Name AS ProductName, [OrderQty] AS Quantity, [DueDate] AS Date
                                              FROM [AdventureWorks2014].[Production].[WorkOrder] AS WO 
                                              INNER JOIN[Production].[Product] AS P ON P.ProductID = WO.ProductID
                                              WHERE WorkOrderID = @Id", new { Id = id }).FirstOrDefault();
        }
    }
}
