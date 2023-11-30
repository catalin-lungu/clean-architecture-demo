using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Features.Students.Queries.GetStudentCheckIns
{
    public class GetStudentCheckInQuery : IRequest<List<CheckInVM>>
    {
        public int Id { get; set; }
    }

}
