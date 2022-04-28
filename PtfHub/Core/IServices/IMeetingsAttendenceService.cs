using System;
using System.Threading.Tasks;
using PtfHub.Core.Dtos;

namespace PtfHub.Core.IServices
{
    public interface IMeetingsAttendenceService
    {
        Task AttendMenting(RecordMeetingAttendanceDto meetingAttendanceDto);
    }
}
