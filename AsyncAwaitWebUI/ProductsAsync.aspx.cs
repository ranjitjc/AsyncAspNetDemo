using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AsyncAwaitWebUI
{
    public partial class ProductsAsync : System.Web.UI.Page
    {
        public string PageElapsedTime;
        public string LoadElapsedTime;
        List<Statistic> statistics = new List<Statistic>();
        Stopwatch pageWatch = new Stopwatch();
        protected void Page_Load(object sender, EventArgs e)
        {
            Stopwatch loadWatch = new Stopwatch();
            loadWatch.Start();

            
            pageWatch.Start();
            statistics.Add(new Statistic { ThreadId = Thread.CurrentThread.ManagedThreadId, Message = "Page Load:Start" });


            RegisterAsyncTask(new PageAsyncTask(LoadProductsAsync));
            statistics.Add(new Statistic { ThreadId = Thread.CurrentThread.ManagedThreadId, Message = "Page Load::End" });


            TimeSpan ts = loadWatch.Elapsed;

            LoadElapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
               ts.Hours, ts.Minutes, ts.Seconds,
               ts.Milliseconds / 10);
        }


        private async Task LoadProductsAsync()
        {
            statistics.Add(new Statistic { ThreadId = Thread.CurrentThread.ManagedThreadId, Message = "LoadProductsAsync():Start" });

            ProductProxyService.ProductServiceClient client = new ProductProxyService.ProductServiceClient();
            IList<ProductProxyService.Product> products= await client.GetProductsTaskAsync();
            statistics.Add(new Statistic { ThreadId = Thread.CurrentThread.ManagedThreadId, Message = "LoadProductsAsync():End" });

            ProductGridView.DataSource = products;
            ProductGridView.DataBind();

            ThreadGridView.DataSource = statistics;
            ThreadGridView.DataBind();

            TimeSpan ts = pageWatch.Elapsed;
            PageElapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
               ts.Hours, ts.Minutes, ts.Seconds,
               ts.Milliseconds / 10);
        }

    }
}