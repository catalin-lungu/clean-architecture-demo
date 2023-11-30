using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Domain.Entities
{
    public class CheckIn
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Major { get; set; } = string.Empty;
        public DateTime CheckInTime { get; set; }
    }
}
