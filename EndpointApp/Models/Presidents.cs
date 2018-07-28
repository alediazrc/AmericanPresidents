using System;
using System.Collections.Generic;

namespace EndpointApp.Models
{
    public partial class Presidents
    {
        public string President { get; set; }
        public DateTime Birthday { get; set; }
        public string Birthplace { get; set; }
        public DateTime DeathDay { get; set; }
        public string DeathPlace { get; set; }
        public int Id { get; set; }
    }
}
