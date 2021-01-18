using System;

namespace MapperTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var mapper = Mapper.Instance;
            mapper.Register<Person, PersonDTO>(x => new PersonDTO()
            {
                FirstName = x.FirstName,
                LastName = x.LastName
            });

            Person test = GetDemoPerson();

            PersonDTO testDTO = mapper.Map<Person, PersonDTO>(test);

            Console.WriteLine($"{testDTO}");
        }

        private static Person GetDemoPerson() =>
            new Person()
            {
                FirstName = "Test",
                LastName = "Guy",
                SSN = "111-11-2548"
            };
    }
}
