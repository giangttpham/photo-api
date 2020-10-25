using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Photo.Api.Exceptions
{
    public class NotFoundException: Exception

    {
        public NotFoundException(): base("The requested photo cannot be found.")
            { }
    }
}
