using DapperSlapper.DataAccess;
using DapperSlapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperSlapper
{
    public class ConsoleApplication
    {
        private readonly IDataAccess _data;

        public ConsoleApplication(IDataAccess data)
        {
            _data = data;
        }

        public async Task Run()
        {
            var res = await _data.LoadData<dynamic, object>("spGetPeople", new { });
            var people = Slapper.AutoMapper.MapDynamic<Person>(res);

            foreach(var person in people)
            {
                Console.WriteLine(person.FirstName + " " + person.LastName);
                Console.WriteLine(person.Address.City + ", " + person.Address.StateAbr);
            }
        }
    }
}
