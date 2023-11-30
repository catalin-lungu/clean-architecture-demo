using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Features.Students.Queries
{
    public class CheckInVM
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Major { get; set; } = string.Empty;
        public DateTime CheckInTime { get; set; }
    }
}
