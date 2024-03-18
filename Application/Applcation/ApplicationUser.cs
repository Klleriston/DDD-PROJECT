using Application.Interface;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Applcation
{
    public class ApplicationUser : IUserApplication
    {
        IUser _Iuser;
        
        public ApplicationUser(IUser user) 
        {
            _Iuser = user;
        }

        public async Task<bool> AddUser(string email, string password, int age, int phone)
        {
            return await _Iuser.AddUser(email, password, age, phone);
        }

        public async Task<bool> ExistUser(string email, string password)
        {
            return await _Iuser.ExistUser(email, password);
        }
    }
}
