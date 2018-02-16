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
    public partial class DashboardAsync : System.Web.UI.Page
    {
        public string PageElapsedTime;
        //public string LoadElapsedTime;
        List<Statistic> statistics = new List<Statistic>();

        Stopwatch pageWatch = new Stopwatch();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Stopwatch loadWatch = new Stopwatch();
            //loadWatch.Start();


            pageWatch.Start();
            statistics.Add(new Statistic { ThreadId = Thread.CurrentThread.ManagedThreadId, Message = "Page Load:Start" });
            RegisterAsyncTask(new PageAsyncTask(LoadAsync));

            statistics.Add(new Statistic { ThreadId = Thread.CurrentThread.ManagedThreadId, Message = "Page Load::End" });


        }
        private async Task LoadAsync()
        {
            statistics.Add(new Statistic { ThreadId = Thread.CurrentThread.ManagedThreadId, Message = "LoadAsync():Start" });
            ProductProxyService.ProductServiceClient client = new ProductProxyService.ProductServiceClient();
            SaleOrderProxyService.SaleOrderServiceClient saleOrderClient = new SaleOrderProxyService.SaleOrderServiceClient();
            PersonProxyService.PersonServiceClient personClient = new PersonProxyService.PersonServiceClient();
            

            var productsTask = client.GetProductsTaskAsync();
            var saleOrdersTask = saleOrderClient.GetSaleOrdersTaskAsync();
            var personTask = personClient.GetPersonsTaskAsync();

            statistics.Add(new Statistic { ThreadId = Thread.CurrentThread.ManagedThreadId, Message = "LoadAsync():Before WhenAll()" });

            await Task.WhenAll(productsTask, saleOrdersTask, personTask);

            statistics.Add(new Statistic { ThreadId = Thread.CurrentThread.ManagedThreadId, Message = "LoadAsync():Tasks all done." });

            LoadProducts(productsTask.Result);
            LoadSaleOrders(saleOrdersTask.Result);
            LoadPersons(personTask.Result);

            statistics.Add(new Statistic { ThreadId = Thread.CurrentThread.ManagedThreadId, Message = "LoadAsync():Exit" });
            ThreadGridView.DataSource = statistics;
            ThreadGridView.DataBind();

            TimeSpan ts = pageWatch.Elapsed;
            PageElapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
              ts.Hours, ts.Minutes, ts.Seconds,
              ts.Milliseconds / 10);

        }

        private void LoadProducts(IList<ProductProxyService.Product>  products)
        {
            ProductGridView.DataSource = products.Take(10);
            ProductGridView.DataBind();
        }

        private void LoadSaleOrders(IList<SaleOrderProxyService.SaleOrder> saleOrders)
        {
            SaleOrderGridView.DataSource = saleOrders.Take(10);
            SaleOrderGridView.DataBind();

        }


        private void LoadPersons(IList<PersonProxyService.Person> persons)
        {
            //threadIds.Add(Thread.CurrentThread.ManagedThreadId);
            PersonGridView.DataSource = persons.Take(10);
            PersonGridView.DataBind();
       }

    }
}