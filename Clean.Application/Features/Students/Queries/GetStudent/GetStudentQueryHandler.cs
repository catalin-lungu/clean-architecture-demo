using AutoMapper;
using Clean.Application.Contracts;
using Clean.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Features.Students.Queries.GetStudent
{
    internal class GetStudentQueryHandler : IRequestHandler<GetStudentQuery, StudentVM>
    {
        private readonly IRepository<Student> _studentRepository;
        private readonly IMapper _mapper;

        public GetStudentQueryHandler(IMapper mapper, IRepository<Student> studentRepository)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
        }

        public async Task<StudentVM> Handle(GetStudentQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetByIdAsync(request.Id);
            var studentVM = _mapper.Map<StudentVM>(student);
            return studentVM;
        }
    }
}
