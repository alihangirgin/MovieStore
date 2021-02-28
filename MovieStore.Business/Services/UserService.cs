using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using MovieStore.Core.DTOs;
using MovieStore.Core.Models;
using MovieStore.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Business.Services
{
    public class UserService:IUserService
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;

        public UserService(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public UserClaimDto GetUser()
        {
            var user = _httpContextAccessor.HttpContext.User;
            var dbUser = _userManager.GetUserAsync(user).Result;
            if (dbUser != null)
            {
                UserClaimDto userClaimViewModel = new UserClaimDto()
                {
                    Email = dbUser.Email,
                    UserName = dbUser.UserName,
                    UserId = dbUser.Id

                };
                return userClaimViewModel;
            }
            return null;

        }
    }
}
