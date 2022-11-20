using CQRS_No_MediatR.Commands;
using CQRS_No_MediatR.Models;
using CQRS_No_MediatR.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_No_MediatR;
public class Application : IApplication
{
    private readonly IQueryDispatcher _queryDispatcher;
    private readonly ICommandDispatcher _commandDispatcher;

    public Application(IQueryDispatcher queryDispatcher,
        ICommandDispatcher commandDispatcher)
    {
        _queryDispatcher = queryDispatcher;
        _commandDispatcher = commandDispatcher;
    }

    public async Task Start()
    {
        await _commandDispatcher.Dispatch<AddPersonCommand, Person>(
           new AddPersonCommand("Test", "Person"),
           new CancellationToken());

        await _commandDispatcher.Dispatch<AddPersonCommand, Person>(
            new AddPersonCommand("Frank", "Tests"),
            new CancellationToken());

        await _commandDispatcher.Dispatch<AddPersonCommand, Person>(
            new AddPersonCommand("Fred", "Tester"),
            new CancellationToken());

        var people = await _queryDispatcher.Dispatch<GetAllPeopleQuery, IReadOnlyCollection<Person>>(new GetAllPeopleQuery(), new CancellationToken());
        foreach (var p in people)
        {
            await global::System.Console.Out.WriteLineAsync(p.Id + " " + p.FirstName + " " + p.LastName);
        }

        var person = await _queryDispatcher.Dispatch<GetPersonByIdQuery, Person>(new GetPersonByIdQuery(1), new CancellationToken());
        await Console.Out.WriteLineAsync(person.Id + " " + person.FirstName + " " + person.LastName);
    }
}
