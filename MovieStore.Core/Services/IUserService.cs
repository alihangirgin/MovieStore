using MovieStore.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Core.Services
{
    public interface IUserService
    {
        //User GetUserByUserId();
        UserClaimDto GetUser();
    }
}