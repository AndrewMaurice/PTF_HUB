using System;
namespace PtfHub.Core.Dtos
{
    public class UserLoginResponseDto
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string MobileNumber1 { get; set; }
        public string MobileNumber2 { get; set; }
        public string HomeNumber { get; set; }
        public string FacebookUrl { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string University { get; set; }
        public string Faculty { get; set; }
        public int UniversityJoiningYear { get; set; }
        public object UniversityGraduationYear { get; set; }
        public string Gender { get; set; }
        public DateTime? LastLogin { get; set; }
    }
}
