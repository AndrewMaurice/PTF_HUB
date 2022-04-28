using System;
using System.Collections.Generic;

#nullable disable

namespace PtfHub.Domain.Entities
{
    public partial class Education
    {
        public Education()
        {
            People = new HashSet<Person>();
        }

        public Guid Guid { get; set; }
        public Guid UniversityId { get; set; }
        public int From { get; set; }
        public int? Till { get; set; }
        public byte[] UpdatedTime { get; set; }

        public virtual University University { get; set; }
        public virtual ICollection<Person> People { get; set; }
    }
}
