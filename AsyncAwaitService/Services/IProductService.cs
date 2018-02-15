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
    public interface IProductService
    {
        [OperationContract]
        IList<Product> GetProducts();

        [OperationContract]
        Task<IList<Product>> GetProductsTask();

    }


    [DataContract]
    public class Product
    {

        [DataMember]
        public int ID
        {
            get;
            set;
        }

        [DataMember]
        public string  Name
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

        public int SafetyStockLevel
        {
            get;
            set;
        }


        public decimal StandardCost
        {
            get;
            set;
        }

        public decimal ListCost
        {
            get;
            set;
        }
    }

}
