using CQRS_No_MediatR.Models;
using CQRS_No_MediatR.Queries;
using CQRS_No_MediatR.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_No_MediatR.QueryHandlers;


internal class GetPersonByIdHandler : IQueryHandler<GetPersonByIdQuery, Person?>
{
    private readonly IPersonRepo _personRepo;

    public GetPersonByIdHandler(IPersonRepo personRepo)
    {
        _personRepo = personRepo;
    }

    public Task<Person?> Handle(GetPersonByIdQuery command, CancellationToken cancellation)
    {
        return Task.FromResult(_personRepo.GetPerson(command.Id));
    }
}
