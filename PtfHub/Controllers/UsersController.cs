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
    public class UsersController : Controller
    {
        #region Attributes

        private readonly IUsersService _usersService;

        #endregion

        #region Constructor

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        #endregion

        #region Endpoints

        // POST api/values
        [HttpPost("Login")]
        public async Task<IActionResult> Post([FromBody] UserLoginDto value)
        {
            try
            {
                return Ok(await _usersService.Login(value));
            }
            catch(Exception e)
            {
                if (e is NotFoundException)
                {
                    return NotFound(e);
                }

                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        #endregion
    }
}
