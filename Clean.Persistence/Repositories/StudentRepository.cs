using Clean.Application.Contracts;
using Clean.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Persistence.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        protected readonly DemoDbContext _dbContext;
        public StudentRepository(DemoDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddCheckIn(CheckIn checkIn)
        {
            await _dbContext.Set<CheckIn>().AddAsync(checkIn);
            await _dbContext.SaveChangesAsync();

            return checkIn.Id;
        }

        public Task<List<CheckIn>> GetCheckInAsync(string studentEmail)
        {
            var checkIns = _dbContext.Set<CheckIn>().Where(x => x.Email == studentEmail).ToListAsync();
            return checkIns;
        }

        public async Task<bool> IsEmailUniqueAsync(string studentEmail)
        {
            return !await _dbContext.Students.AnyAsync(s => s.Email == studentEmail);
        }
    }
}
