using System;
using System.Collections.Generic;

#nullable disable

namespace PtfHub.Domain.Entities
{
    public partial class Location
    {
        public Location()
        {
            Meetings = new HashSet<Meeting>();
        }

        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonNumber { get; set; }
        public string GoogleMapsUrl { get; set; }

        public virtual ICollection<Meeting> Meetings { get; set; }
    }
}
