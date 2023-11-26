using Service.Helpers.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Service.Exceptions
{
    public class NullExceptions : Exception
    {
        public NullExceptions(string message):base(message) { }
    }
}
