using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitService.Service
{
    [ServiceContract]
    public interface ISaleOrderService
    {
        [OperationContract]
        IList<SaleOrder> GetSaleOrders();

        [OperationContract]
        Task<IList<SaleOrder>> GetSaleOrdersTask();

    }


    [DataContract]
    public class SaleOrder
    {

        [DataMember]
        public int ID
        {
            get;
            set;
        }

        [DataMember]
        public string Number
        {
            get;
            set;
        }

        [DataMember]
        public string AccountNumber
        {
            get;
            set;
        }


        public string PurchaseOrderNumber
        {
            get;
            set;
        }


        public int CustomerID
        {
            get;
            set;
        }

        public int? SalePersonID
        {
            get;
            set;
        }

        public decimal SubTotal
        {
            get;
            set;
        }


        public decimal TaxAmount
        {
            get;
            set;
        }


        public decimal FreightAmount
        {
            get;
            set;
        }
        public decimal TotalDue
        {
            get;
            set;
        }
    }

}
