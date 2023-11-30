using EmptyFiles;
using Clean.Application.Contracts;
using Clean.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Test
{
    public class RepositoryMocks
    {
        public static Mock<IRepository<Student>> GetStudentRepository()
        {
            var students = new List<Student>
            {
                new Student
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@email.com"
                },
                new Student
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Doe",
                    Email = "john.doe@email.com"
                },
                new Student
                {
                    Id = 3,
                    FirstName = "John",
                    LastName = "Smith",
                    Email = "john.smith@email.com",
                }
            };

            var mockStudentRepository = new Mock<IRepository<Student>>();
            mockStudentRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(students);

            mockStudentRepository.Setup(repo => repo.AddAsync(It.IsAny<Student>())).ReturnsAsync(
                (Student student) =>
                {
                    students.Add(student);
                    return student;
                });

            return mockStudentRepository;
        }
    }
}
