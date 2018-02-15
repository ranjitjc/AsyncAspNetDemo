using AsyncAwaitService.DataService;
using AsyncAwaitService.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "OrderService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select OrderService.svc or OrderService.svc.cs at the Solution Explorer and start debugging.
    public class SaleOrderService : ISaleOrderService
    {
        public IList<SaleOrder> GetSaleOrders()
        {
            Thread.Sleep(1000);
            IList<SaleOrder> products = new List<SaleOrder>();
            DataTable ds;

            using (SaleOrderDataService data = new SaleOrderDataService())
            {
                string sql = "SELECT *  FROM [Sales].[SalesOrderHeader] WHERE SalesOrderNumber like '%43%'";

                ds = data.GetSaleOrders(sql);
            }
            products = ConvertToSaleOrder(ds);

            return products;
        }

        public async Task<IList<SaleOrder>> GetSaleOrdersTask()
        {
            await Task.Delay(1000);
            IList<SaleOrder> products = new List<SaleOrder>();
            DataTable ds;

            using (SaleOrderDataService data = new SaleOrderDataService())
            {
                string sql = "SELECT *  FROM  [Sales].[SalesOrderHeader] WHERE SalesOrderNumber like '%43%'";

                ds = await data.GetSaleOrdersAsync(sql);
            }
            products = ConvertToSaleOrder(ds);

            return products;
        }

        private IList<SaleOrder> ConvertToSaleOrder(DataTable dtProduct)
        {
            return dtProduct.AsEnumerable()
                  .Select(row => new SaleOrder
                  {
                      ID = row.Field<int>("SalesOrderID"),
                      Number = row.Field<string>("SalesOrderNumber"),
                      AccountNumber = row.Field<string>("AccountNumber"),
                      PurchaseOrderNumber = row.Field<string>("PurchaseOrderNumber"),
                      CustomerID = row.Field<int>("CustomerID"),
                      SalePersonID = row.Field<int?>("SalesPersonID"),
                      SubTotal = row.Field<decimal>("SubTotal"),
                      TaxAmount = row.Field<decimal>("TaxAmt"),
                      FreightAmount = row.Field<decimal>("Freight"),
                      TotalDue = row.Field<decimal>("TotalDue"),
                  }).OrderBy(o => o.Number).ToList();
        }
    }
}
