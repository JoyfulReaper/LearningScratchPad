using CQRS_No_MediatR.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_No_MediatR.Services;
public class PersonRepo : IPersonRepo
{
    private readonly static List<Person> people = new();

    public Person AddPerson(Person person)
    {
        if (people.Count > 0)
        {
            person.Id = people.Max(p => p.Id) + 1;
        }
        else
        {
            person.Id = 1;
        }

        people.Add(person);
        return person;
    }

    public Person? GetPerson(int id)
    {
        return people.FirstOrDefault(x => x.Id == id);
    }

    public IReadOnlyCollection<Person> GetAllPeople()
    {
        return people.AsReadOnly();
    }
}
