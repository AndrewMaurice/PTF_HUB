using System;
using System.Threading.Tasks;
using PtfHub.Core.Dtos;
using PtfHub.Core.IServices;
using PtfHub.DAL.Repositories;
using PtfHub.Exceptions;

namespace PtfHub.Core.Services
{
    public class UsersService : IUsersService
    {
        #region Attributes

        private readonly PersonsRepository _personsRepository;

        #endregion

        #region Constructor

        public UsersService(PersonsRepository personsRepository)
        {
            _personsRepository = personsRepository;
        }

        #endregion

        #region Methods

        public async Task<UserLoginResponseDto> Login(UserLoginDto loginDto)
        {
            var personInDb = await _personsRepository.Filter(p => p.MobileNumber1 == loginDto.PhoneNumber
            || p.MobileNumber2 == loginDto.PhoneNumber
            || p.HomeNumber == loginDto.PhoneNumber);

            if (personInDb == null)
            {
                throw new NotFoundException($"Cannot found any user with number ${loginDto.PhoneNumber}");
            }

            var personInDbWithAllTheDetails = await _personsRepository.GetPersonFromDb(personInDb.Guid);

            return new UserLoginResponseDto
            {
                Id = personInDbWithAllTheDetails.Guid.ToString(),
                FullName = personInDbWithAllTheDetails.FullName,
                MobileNumber1 = personInDbWithAllTheDetails.MobileNumber1,
                MobileNumber2 = personInDbWithAllTheDetails.MobileNumber2,
                Address = personInDbWithAllTheDetails.Address,
                City = personInDbWithAllTheDetails.City,
                Country = personInDbWithAllTheDetails.Country,
                University = personInDbWithAllTheDetails.Education.University.Name,
                Faculty = personInDbWithAllTheDetails.Education.University.Faculty,
                FacebookUrl = personInDbWithAllTheDetails.FacebookUrl,
                Gender = personInDbWithAllTheDetails.Gender,
                HomeNumber = personInDbWithAllTheDetails.HomeNumber,
                LastLogin = personInDbWithAllTheDetails.LastLogin,
                UniversityGraduationYear = personInDbWithAllTheDetails.Education.Till,
                UniversityJoiningYear = personInDbWithAllTheDetails.Education.From

            };

        }

        #endregion
    }
}
