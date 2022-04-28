using System;
using System.Collections.Generic;

#nullable disable

namespace PtfHub.Domain.Entities
{
    public partial class Person
    {
        public Person()
        {
            MeetingAttendances = new HashSet<MeetingAttendance>();
        }

        public Guid Guid { get; set; }
        public string FullName { get; set; }
        public string MobileNumber1 { get; set; }
        public string MobileNumber2 { get; set; }
        public string HomeNumber { get; set; }
        public string FacebookUrl { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public Guid EducationId { get; set; }
        public string Gender { get; set; }
        public DateTime? LastLogin { get; set; }

        public virtual Education Education { get; set; }
        public virtual ICollection<MeetingAttendance> MeetingAttendances { get; set; }
    }
}
