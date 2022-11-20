using CQRS_No_MediatR.Commands;
using CQRS_No_MediatR.Models;
using CQRS_No_MediatR.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_No_MediatR.CommandHandlers;
public class AddPersonHandler : ICommandHandler<AddPersonCommand, Person>
{
    private readonly IPersonRepo _personRepo;

    public AddPersonHandler(IPersonRepo personRepo)
	{
        _personRepo = personRepo;
    }

    Task<Person> ICommandHandler<AddPersonCommand, Person>.Handle(AddPersonCommand command, CancellationToken cancellation)
    {
        Person person = new Person
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
        };

        return Task.FromResult(_personRepo.AddPerson(person));
    }
}
