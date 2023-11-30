using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Features.Students.Queries.GetStudent
{
    public class GetStudentQuery : IRequest<StudentVM>
    {
        public int Id { get; set; }
    }
}
