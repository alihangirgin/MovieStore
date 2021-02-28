using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.Data.Seeds
{
    internal class UserSeed : IEntityTypeConfiguration<User>
    {
        private readonly int[] _ids;

        public UserSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(new User(){
                    AccessFailedCount=0,
                    Email="user1@gmail.com", EmailConfirmed=true,
                    ConcurrencyStamp="cdcf8fb8-1a87-4080-9ce7-ce3f35878a9a",
                    LockoutEnabled=true,
                    NormalizedEmail="USER1@GMAIL.COM",
                    NormalizedUserName="USER1",
                    PasswordHash="AQAAAAEAACcQAAAAEFLTKZM3sI4Uxec9PUhygjVEQpN2LgFi/XysXpyJYzyYbZjHwxsY2hKdFARVzTGeCQ==",
                    PhoneNumber="NULL",
                    PhoneNumberConfirmed=false,
                    SecurityStamp="U4EFKKNM45PL6CFHSTNZODTATSLG2KVJ",
                    UserName="User1",
                    TwoFactorEnabled=false,
                    Id = _ids[0],
                    CreateDate =DateTime.Now
                });
        }
    }
}
