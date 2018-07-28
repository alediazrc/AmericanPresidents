using EndpointApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndpointApp.Repositories
{
    public class GenericReposity <T>
    where T: class
    {
        internal endpointdatabaseContext context;

        public GenericReposity(endpointdatabaseContext _context)
        {
            context = _context;
        }
    }
}
