using System;
using System.Collections.Generic;

#nullable disable

namespace PtfHub.Domain.Entities
{
    public partial class Speaker
    {
        public Speaker()
        {
            Meetings = new HashSet<Meeting>();
        }

        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<Meeting> Meetings { get; set; }
    }
}
