using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndpointApp.Models
{
    public class CustomPresident
    {
        public string ShortDiedDate { get; set; }
        public string ShortBirthDate { get; set; }
        public string President { get; set; }
        public string Birthplace { get; set; }
        public DateTime? DeathDay { get; set; }
        public DateTime Birthday { get; set; }
        public string DeathPlace { get; set; }
        public int Id { get; set; }
    }
}
