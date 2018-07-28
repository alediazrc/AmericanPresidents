using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndpointApp.Models
{
    public class CustomPresident: Presidents
    {
        public string ShortDiedDate { get; set; }
        public string ShortBirthDate { get; set; }
    }
}
