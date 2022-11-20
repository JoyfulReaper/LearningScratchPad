using CQRS_No_MediatR.Models;

namespace CQRS_No_MediatR.Services;
public interface IPersonRepo
{
    Person AddPerson(Person person);
    IReadOnlyCollection<Person> GetAllPeople();
    Person? GetPerson(int id);
}