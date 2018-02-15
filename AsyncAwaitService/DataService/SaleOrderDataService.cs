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
    public class SaleOrderDataService: BaseDataService, IDisposable
    {
        public SaleOrderDataService()
        {
            this.DBName = "AdventureWorks";
        }

        public string ErrorMessage
        {
            get; set;
        }


        public DataTable GetSaleOrders(string sql)
        {
            DataTable dtSaleOrders = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;

            this.ExecuteSql(dtSaleOrders, cmd, "SaleOrders");

            if (dtSaleOrders != null && dtSaleOrders.Rows.Count <= 0)
            {
                dtSaleOrders = null;
            }

            return dtSaleOrders;
        }


        public async Task<DataTable> GetSaleOrdersAsync(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;
            return await Task.Factory.StartNew(() => GetDataTableAsync(cmd, token, "SaleOrders"), token).Result;
        }

        #region IDisposable

        ~SaleOrderDataService()
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