using Clean.Domain.Entities;

namespace Clean.Application.Contracts
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<int> AddCheckIn(CheckIn checkIn);

        Task<List<CheckIn>> GetCheckInAsync(string studentEmail);

        Task<bool> IsEmailUniqueAsync(string studentEmail);
    }
}
