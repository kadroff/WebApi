using System;
using System.Threading.Tasks;
using ModulSchool.Services;
using ModulSchool.Models;

namespace ModulSchool.Application
{
    public class AppendUserRequestHandler
    {
        private readonly IUserInfoService _userInfoService;
        
        public AppendUserRequestHandler(IUserInfoService userInfoService)
        {
            _userInfoService = userInfoService;
        }

        public Task<User> Handle(User user)
        {

            return _userInfoService.AppendUser(user);
        }
    }
}