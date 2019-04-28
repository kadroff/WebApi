using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModulSchool.Application;
using ModulSchool.Models;


namespace ModulSchool.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly GetUsersInfoRequestHandler _getUsersInfoRequestHandler;
        private readonly AppendUserRequestHandler _appendUserRequestHandler;

        public UsersController(GetUsersInfoRequestHandler getUsersInfoRequestHandler, AppendUserRequestHandler appendUserRequestHandler)
        {
            _getUsersInfoRequestHandler = getUsersInfoRequestHandler;
            _appendUserRequestHandler = appendUserRequestHandler;
        }

        [HttpGet("{id}")]
        public Task<User> GetUserInfo(Guid id)
        {
            return _getUsersInfoRequestHandler.Handle(id);
        }
        
        [HttpPost("append")]
        public Task<User> AppendUser([FromBody] User user)
        {
            Guid guid = Guid.NewGuid();
            user.Id = guid;
            return _appendUserRequestHandler.Handle(user);
        }
    }
}
