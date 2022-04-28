using System;
using System.Collections.Generic;

#nullable disable

namespace PtfHub.Domain.Entities
{
    public partial class MeetingType
    {
        public MeetingType()
        {
            Meetings = new HashSet<Meeting>();
        }

        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Meeting> Meetings { get; set; }
    }
}
