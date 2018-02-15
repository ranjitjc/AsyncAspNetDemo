using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace AsyncAwaitService.DataService
{
    public class ProductDataService: BaseDataService, IDisposable
    {
        public ProductDataService()
        {
            this.DBName = "AdventureWorks";
        }

        public string ErrorMessage
        {
            get; set;
        }


        public DataTable GetProducts(string sql)
        {
            DataTable dtProducts = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;

            this.ExecuteSql(dtProducts, cmd, "Products");

            if (dtProducts != null && dtProducts.Rows.Count <= 0)
            {
                dtProducts = null;
            }

            return dtProducts;
        }


        public async Task<DataTable> GetProductsAsync(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;
            return await Task.Factory.StartNew(() => GetDataTableAsync(cmd, token, "UsageData"), token).Result;
        }

        #region IDisposable

        ~ProductDataService()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false; // to detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    ErrorMessage = null;
                }
            }
            disposed = true;
        }

        #endregion
    }
}