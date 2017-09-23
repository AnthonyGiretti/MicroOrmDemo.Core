using ConsoleAppMicroOrmCore._2._0;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    public class EfQueries
    {
        public List<Orders> GetOrders()
        {
            using (var context = new AdventureWorksContext())
            {
                var query = context.WorkOrder.Select(
                    x => new Orders
                    {
                        Id = x.WorkOrderId,
                        ProductName = x.Product.Name,
                        Quantity = x.OrderQty,
                        Date = x.DueDate
                    }).Take(500);

                return query.ToList();
            }
        }
        public List<Orders> GetOrders(int iteration)
        {
            var listOrders = new List<Orders>();
            using (var context = new AdventureWorksContext())
            {

                for (int i = 1; i <= iteration; i++)
                    listOrders.Add(GetOrder(context, i));
            }

            return listOrders;
        }

        private Orders GetOrder(AdventureWorksContext context, int id)
        {
            return  context.WorkOrder.Where(f=> f.WorkOrderId == id).Select(
                    x => new Orders
                    {
                        Id = x.WorkOrderId,
                        ProductName = x.Product.Name,
                        Quantity = x.OrderQty,
                        Date = x.DueDate
                    }).FirstOrDefault();
        }
    }
}
