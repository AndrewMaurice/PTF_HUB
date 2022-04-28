using System;
using System.ComponentModel.DataAnnotations;

namespace PtfHub.Core.Dtos
{
    public class UserLoginDto
    {
        [Required]
        public string PhoneNumber { get; set; }
    }
}
