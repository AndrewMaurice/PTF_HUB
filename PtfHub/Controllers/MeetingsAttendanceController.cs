using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PtfHub.Core.Dtos;
using PtfHub.Core.IServices;
using PtfHub.Exceptions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PtfHub.Controllers
{
    [Route("api/[controller]")]
    public class MeetingsAttendanceController : Controller
    {
        #region Attributes

        private readonly IMeetingsAttendenceService _meetingsAttendenceService;

        #endregion

        #region Constructor

        public MeetingsAttendanceController(IMeetingsAttendenceService meetingsAttendenceService)
        {
            _meetingsAttendenceService = meetingsAttendenceService;
        }

        #endregion

        #region Endpoints

        // POST api/values
        [HttpPost("AttendMeeting")]
        public async Task<IActionResult> Post([FromBody] RecordMeetingAttendanceDto value)
        {
            try
            {
                await _meetingsAttendenceService.AttendMenting(value);
                return Ok($"Attendance has been recorded successfully");
            }
            catch (Exception e)
            {
                if (e is NotFoundException)
                {
                    return NotFound(e.Message);
                }
                if (e is RecordAlreadyExistsExcpetion)
                {
                    return Conflict(e.Message);
                }

                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        #endregion
    }
}
