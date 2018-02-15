using AsyncAwaitService.DataService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitService.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PersonService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PersonService.svc or PersonService.svc.cs at the Solution Explorer and start debugging.
    public class PersonService : IPersonService
    {
        public async Task<IList<Person>> GetPersonsTask()
        {
            await Task.Delay(1000);
            IList<Person> Persons = new List<Person>();
            DataTable ds;

            using (PersonDataService data = new PersonDataService())
            {
                string sql = "SELECT *  FROM [Person].[Person]";

                ds = await data.GetPersonsAsync(sql);
            }
            Persons = ConvertToPersons(ds);

            return Persons;
        }

        private IList<Person> ConvertToPersons(DataTable dtPerson)
        {
            return dtPerson.AsEnumerable()
                   .Select(row => new Person
                   {
                       ID = row.Field<int>("BusinessEntityID"),
                       PersonType = row.Field<string>("PersonType"),
                       FirstName = row.Field<string>("FirstName"),
                       MiddleName = row.Field<string>("MiddleName"),
                       LastName = row.Field<string>("LastName")
                       
                   }).OrderBy(o => o.FirstName).ToList();
        }

        public IList<Person> GetPersons()
        {
            Thread.Sleep(1000);
            IList<Person> Persons = new List<Person>();
            DataTable ds;

            using (PersonDataService data = new PersonDataService())
            {
                string sql = "SELECT *  FROM [Person].[Person]";

                ds = data.GetPersons(sql);
            }
            Persons = ConvertToPersons(ds);

            return Persons;
        }
    }
}
