using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitService.Services
{
    [ServiceContract]
    public interface IPersonService
    {
        [OperationContract]
        IList<Person> GetPersons();

        [OperationContract]
        Task<IList<Person>> GetPersonsTask();

    }


    [DataContract]
    public class Person
    {

        [DataMember]
        public int ID
        {
            get;
            set;
        }

        [DataMember]
        public string PersonType
        {
            get;
            set;
        }

        public string MiddleName
        {
            get;
            set;
        }

        [DataMember]
        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }


       

 
    }

}
