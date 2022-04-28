using System;
using System.Collections.Generic;

#nullable disable

namespace PtfHub.Domain.Entities
{
    public partial class University
    {
        public University()
        {
            Educations = new HashSet<Education>();
        }

        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Faculty { get; set; }

        public virtual ICollection<Education> Educations { get; set; }
    }
}
