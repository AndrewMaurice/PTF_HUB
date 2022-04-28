using System;
using System.Threading.Tasks;
using PtfHub.Core.Dtos;
using PtfHub.Core.IServices;
using PtfHub.DAL.IRepositories;
using PtfHub.DAL.UnitOfWork;
using PtfHub.Domain.Entities;
using PtfHub.Exceptions;

namespace PtfHub.Core.Services
{
    public class MeetingsAttendenceService : IMeetingsAttendenceService
    {
        #region Attributes

        private readonly IGenericRepository<MeetingAttendance> _meetingAttendanceRepository;
        private readonly IGenericRepository<Person> _personsRepository;
        private readonly IGenericRepository<Meeting> _meetingsRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        public MeetingsAttendenceService(IGenericRepository<MeetingAttendance> meetingAttendanceRepository,
            IGenericRepository<Person> personsRepository,
            IGenericRepository<Meeting> meetingsRepository,
            IUnitOfWork unitOfWork)
        {
            _meetingAttendanceRepository = meetingAttendanceRepository;
            _personsRepository = personsRepository;
            _meetingsRepository = meetingsRepository;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        public async Task AttendMenting(RecordMeetingAttendanceDto meetingAttendanceDto)
        {
            var userInDb = await _personsRepository.Filter(p => p.Guid == Guid.Parse(meetingAttendanceDto.UserId));

            if (userInDb == null)
            {
                throw new NotFoundException($"Cannot find a user with id: {meetingAttendanceDto.UserId} registered on the system");
            }

            var meetingInDb = await _meetingsRepository.Filter(p => p.Guid == Guid.Parse(meetingAttendanceDto.MeetingId));

            if (meetingInDb == null)
            {
                throw new NotFoundException($"Cannot find a meeting with id: {meetingAttendanceDto.MeetingId} registered on the system");
            }

            var meetingAttendanceInDb = await _meetingAttendanceRepository.Filter(m => m.MeetingId == Guid.Parse(meetingAttendanceDto.MeetingId) && m.PersonId == Guid.Parse(meetingAttendanceDto.UserId));

            if (meetingAttendanceInDb != null)
            {
                throw new RecordAlreadyExistsExcpetion($"Attendance for User Id: {meetingAttendanceDto.UserId} for meeting with Id: {meetingAttendanceDto.MeetingId} already exissts");
            }

            await _meetingAttendanceRepository.Add(new MeetingAttendance
            {
                Guid = Guid.NewGuid(),
                MeetingId = Guid.Parse(meetingAttendanceDto.MeetingId),
                PersonId = Guid.Parse(meetingAttendanceDto.UserId),
                AttendanceTime = DateTime.Now
            });

            await _unitOfWork.SaveChangesAsync();
        }

        #endregion
    }
}
