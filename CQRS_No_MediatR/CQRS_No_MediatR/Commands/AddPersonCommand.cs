using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_No_MediatR.Commands;
internal record AddPersonCommand (string FirstName, string LastName);