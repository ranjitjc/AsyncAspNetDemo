using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AsyncAwaitWebUI
{
    public partial class Dashboard : System.Web.UI.Page
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

            LoadProducts();

            LoadSaleOrders();

            LoadPersons();



            statistics.Add(new Statistic { ThreadId = Thread.CurrentThread.ManagedThreadId, Message = "Page Load:End" });

            ThreadGridView.DataSource = statistics;
            ThreadGridView.DataBind();

            TimeSpan ts = pageWatch.Elapsed;

            PageElapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
               ts.Hours, ts.Minutes, ts.Seconds,
               ts.Milliseconds / 10);
        }


        private void LoadProducts()
        {
            statistics.Add(new Statistic { ThreadId = Thread.CurrentThread.ManagedThreadId, Message = "LoadProducts():Start" });

            ProductProxyService.ProductServiceClient client = new ProductProxyService.ProductServiceClient();
            IList<ProductProxyService.Product> products = client.GetProducts();
            statistics.Add(new Statistic { ThreadId = Thread.CurrentThread.ManagedThreadId, Message = "LoadProducts():End" });

            ProductGridView.DataSource = products.Take(10);
            ProductGridView.DataBind();

        }


        private void LoadSaleOrders()
        {

            statistics.Add(new Statistic { ThreadId = Thread.CurrentThread.ManagedThreadId, Message = "LoadSaleOrders():Start" });
            SaleOrderProxyService.SaleOrderServiceClient client = new SaleOrderProxyService.SaleOrderServiceClient();
            IList<SaleOrderProxyService.SaleOrder> products = client.GetSaleOrders();
            statistics.Add(new Statistic { ThreadId = Thread.CurrentThread.ManagedThreadId, Message = "LoadSaleOrders():End" });

            SaleOrderGridView.DataSource = products.Take(10);
            SaleOrderGridView.DataBind();

        }


        private void LoadPersons()
        {
            statistics.Add(new Statistic { ThreadId = Thread.CurrentThread.ManagedThreadId, Message = "LoadPersons():Start" });
            PersonProxyService.PersonServiceClient client = new PersonProxyService.PersonServiceClient();
            IList<PersonProxyService.Person> products = client.GetPersons();
            statistics.Add(new Statistic { ThreadId = Thread.CurrentThread.ManagedThreadId, Message = "LoadPersons():End" });
            PersonGridView.DataSource = products.Take(10);
            PersonGridView.DataBind();

            ThreadGridView.DataSource = statistics;
            ThreadGridView.DataBind();

       }

    }
}