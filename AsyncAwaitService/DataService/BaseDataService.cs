using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace AsyncAwaitService.DataService
{
    public class BaseDataService
    {

        protected string DBName = "";
        protected int CommandTimeout = 300;
        protected String CurrentQueryExecuted = String.Empty;

        public BaseDataService()
        {
            DBName = "";
        }

        /// <summary>
        /// Constructor which sets connection name
        /// </summary>
        /// <param name="ConnectionName"></param>
        public BaseDataService(string ConnectionName)
        {
            DBName = ConnectionName;
        }



        /// <summary>
        /// Executes SQL and populates Datatable 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="sql_cmd"></param>
        /// <param name="dtName"></param>
        public void ExecuteSql(DataTable dt, SqlCommand sql_cmd, string dtName)
        {
            Thread.Sleep(1000);
            //#if DEBUG
            //            CurrentQueryExecuted = SqlHelper.ConvertCmdToSqlForDebug(sql_cmd);
            //            Debug.WriteLine("----------------------------------------------------\n");
            //            Debug.WriteLine(CurrentQueryExecuted);
            //            Debug.WriteLine("\n----------------------------------------------------");
            //#endif
            string connectionString = ConfigurationManager.ConnectionStrings[DBName].ConnectionString;
            sql_cmd.Connection = new SqlConnection(connectionString);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql_cmd);
            dataAdapter.SelectCommand.CommandTimeout = this.CommandTimeout;
            dataAdapter.Fill(dt);
            dt.TableName = dtName;
        }


        
        public async Task<DataTable> GetDataTableAsync(SqlCommand sql_cmd, CancellationToken cancellationToken, string tableName = null)
        {
            await Task.Delay(1000);
//#if DEBUG
//            CurrentQueryExecuted = SqlHelper.ConvertCmdToSqlForDebug(sql_cmd);
//            Debug.WriteLine("----------------------------------------------------\n");
//            Debug.WriteLine(CurrentQueryExecuted);
//            Debug.WriteLine("\n----------------------------------------------------");
//#endif

            TaskCompletionSource<DataTable> source = new TaskCompletionSource<DataTable>();
            var resultTable = new DataTable(tableName ?? sql_cmd.CommandText);


            if (cancellationToken.IsCancellationRequested == true)
            {
                source.SetCanceled();

                await source.Task;
            }

            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings[DBName].ConnectionString;
                var asyncConnectionString = new SqlConnectionStringBuilder(connectionString)
                {
                    AsynchronousProcessing = true
                }.ToString();
                using (var conn = new SqlConnection(asyncConnectionString))
                {
                    await conn.OpenAsync(cancellationToken);
                    sql_cmd.Connection = conn;
                    DbDataReader dataReader = await sql_cmd.ExecuteReaderAsync(CommandBehavior.Default, cancellationToken);
                    resultTable.Load(dataReader);
                    source.SetResult(resultTable);
                }

            }
            catch (Exception ex)
            {
                source.SetException(ex);
            }

            return resultTable;
        }
    }
}