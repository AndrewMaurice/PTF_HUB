using System;
using System.Collections.Generic;

#nullable disable

namespace PtfHub.Domain.Entities
{
    public partial class MeetingAttendance
    {
        public Guid Guid { get; set; }
        public Guid PersonId { get; set; }
        public Guid MeetingId { get; set; }
        public DateTime AttendanceTime { get; set; }

        public virtual Meeting Meeting { get; set; }
        public virtual Person Person { get; set; }
    }
}
