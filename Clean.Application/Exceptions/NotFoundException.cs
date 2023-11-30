using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Exceptions
{
    public class NotFoundException: Exception
    {
        public NotFoundException(string name) : base($"{name} not found!")
        { }
    }
}
