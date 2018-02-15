using AsyncAwaitService.DataService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace AsyncAwaitService.Service
{
    public class ProductService : IProductService
    {
        public async Task<IList<Product>> GetProductsTask()
        {
            IList<Product> products = new List<Product>();
            DataTable ds;

            using (ProductDataService data = new ProductDataService())
            {
                string sql = "SELECT *  FROM [Production].[Product]";

                ds = await data.GetProductsAsync(sql);
            }
            products = ConvertToProducts(ds);

            return products;
        }

        private IList<Product> ConvertToProducts(DataTable dtProduct)
        {
            return dtProduct.AsEnumerable()
                   .Select(row => new Product
                   {
                       ID = row.Field<int>("ProductID"),
                       Number = row.Field<string>("ProductNumber"),
                       Name = row.Field<string>("Name"),
                       SafetyStockLevel = row.Field<Int16>("SafetyStockLevel"),
                       StandardCost = row.Field<decimal>("StandardCost"),
                       ListCost = row.Field<decimal>("ListPrice"),
                   }).OrderBy(o => o.Name).ToList();
        }

        public IList<Product> GetProducts()
        {
            
            IList<Product> products = new List<Product>();
            DataTable ds;

            using (ProductDataService data = new ProductDataService())
            {
                string sql = "SELECT *  FROM [Production].[Product]";

                ds = data.GetProducts(sql);
            }
            products = ConvertToProducts(ds);

            return products;
        }
    }
}