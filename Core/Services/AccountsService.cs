using AutoMapper;
using Core.Dtos;
using Core.Exceptions;
using Core.Interfaces;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class AccountsService : IAccountsService
    {
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;

        public AccountsService(UserManager<User> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public async Task Register(RegisterDto model)
        {
            //var user = new User()
            //{
            //    UserName = model.Email,
            //    Email = model.Email,
            //    Birthdate = model.Birthdate,
            //    PhoneNumber = model.PhoneNumber
            //};
            var user = mapper.Map<User>(model);

            var result = await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                var messages = string.Join("\n", result.Errors.Select(x => x.Description));
                throw new HttpException(messages, HttpStatusCode.BadRequest);
            }
        }

        public Task Login(LoginDto model)
        {
            throw new NotImplementedException();
        }

        public Task Logout()
        {
            throw new NotImplementedException();
        }
    }
}
