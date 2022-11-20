using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_No_MediatR;
public interface IQueryHandler<in TQuery, TQueryResult>
{
    Task<TQueryResult> Handle(TQuery query, CancellationToken cancellation);
}
