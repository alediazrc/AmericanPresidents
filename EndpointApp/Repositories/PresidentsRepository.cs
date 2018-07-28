using EndpointApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndpointApp.Repositories
{
    public class PresidentsRepository: GenericReposity<CustomPresident>
    {
        public PresidentsRepository(endpointdatabaseContext context) : base (context)
        {
            
        }
    }
}
