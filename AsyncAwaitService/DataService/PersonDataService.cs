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
    public class PersonDataService: BaseDataService, IDisposable
    {
        public PersonDataService()
        {
            this.DBName = "AdventureWorks";
        }

        public string ErrorMessage
        {
            get; set;
        }


        public DataTable GetPersons(string sql)
        {
            DataTable dtPersons = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;

            this.ExecuteSql(dtPersons, cmd, "Persons");

            if (dtPersons != null && dtPersons.Rows.Count <= 0)
            {
                dtPersons = null;
            }

            return dtPersons;
        }


        public async Task<DataTable> GetPersonsAsync(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;
            return await Task.Factory.StartNew(() => GetDataTableAsync(cmd, token, "UsageData"), token).Result;
        }

        #region IDisposable

        ~PersonDataService()
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