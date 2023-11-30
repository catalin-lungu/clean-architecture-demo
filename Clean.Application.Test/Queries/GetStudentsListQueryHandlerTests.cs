using AutoMapper;
using Clean.Application.Contracts;
using Clean.Application.Features.Students.Queries;
using Clean.Domain.Entities;
using Moq;
using Shouldly;

namespace Clean.Application.Test.Queries
{
    public class GetStudentsListQueryHandlerTests
    {
        private readonly Mock<IRepository<Student>> _mockStudentRepository;
        private readonly IMapper _mockMapper;

        public GetStudentsListQueryHandlerTests()
        {
            _mockStudentRepository = RepositoryMocks.GetStudentRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<Clean.Application.Profiles.MappingProfile>();
            });

            _mockMapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public void GetStudentsListQueryHandlerTest()
        {
            var handler = new Clean.Application.Features.Students.Queries.GetStudentsList.GetStudentsListQueryHandler(_mockMapper, _mockStudentRepository.Object);
            // Arrange
            var query = new Clean.Application.Features.Students.Queries.GetStudentsList.GetStudentsListQuery();

            // Act
            var result = handler.Handle(query, CancellationToken.None).Result;

            // Assert
            result.ShouldBeOfType<List<StudentVM>>();
            Assert.Equal(3, result.Count);  
        }
    }
}