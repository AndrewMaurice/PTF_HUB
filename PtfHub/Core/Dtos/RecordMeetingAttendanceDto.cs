using System;
using System.ComponentModel.DataAnnotations;

namespace PtfHub.Core.Dtos
{
    public class RecordMeetingAttendanceDto
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string MeetingId { get; set; }
    }
}
