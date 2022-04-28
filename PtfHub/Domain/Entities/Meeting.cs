using System;
using System.Collections.Generic;

#nullable disable

namespace PtfHub.Domain.Entities
{
    public partial class Meeting
    {
        public Meeting()
        {
            MeetingAttendances = new HashSet<MeetingAttendance>();
        }

        public Guid Guid { get; set; }
        public DateTime Date { get; set; }
        public bool IsCanceled { get; set; }
        public string CancelationReason { get; set; }
        public Guid? SpeakerId { get; set; }
        public Guid TypeId { get; set; }
        public Guid LocationId { get; set; }

        public virtual Location Location { get; set; }
        public virtual Speaker Speaker { get; set; }
        public virtual MeetingType Type { get; set; }
        public virtual ICollection<MeetingAttendance> MeetingAttendances { get; set; }
    }
}
