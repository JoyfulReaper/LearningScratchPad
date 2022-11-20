using CQRS_No_MediatR.Models;
using CQRS_No_MediatR.Queries;
using CQRS_No_MediatR.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_No_MediatR.QueryHandlers;


internal class GetAllPeopleHandler : IQueryHandler<GetAllPeopleQuery, IReadOnlyCollection<Person>>
{
    private readonly IPersonRepo _personRepo;

    public GetAllPeopleHandler(IPersonRepo personRepo)
    {
        _personRepo = personRepo;
    }

    public Task<IReadOnlyCollection<Person>> Handle(GetAllPeopleQuery query, CancellationToken cancellation)
    {
        return Task.FromResult(_personRepo.GetAllPeople());
    }
}
