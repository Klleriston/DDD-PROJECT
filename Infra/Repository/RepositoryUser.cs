﻿using Domain.Interfaces;
using Entities.Entities;
using Infra.Config;
using Infra.Repository.Generics;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class RepositoryUser : RepositoryGeneric<ApplicationUser>, IUser
    {
        private readonly DbContextOptions<ContextDb> _OptionsBuilder;
        public RepositoryUser()
        {
            _OptionsBuilder = new DbContextOptions<ContextDb>();
        }
        

        public async Task<bool> AddUser(string email, string password, int age, int phone)
        {
            try
            {
                using (var data = new ContextDb(_OptionsBuilder))
                {
                    await data.ApplicationUsers.AddAsync(
                        new ApplicationUser
                        {
                            Email = email,
                            PasswordHash = password,
                            Age = age,
                            Phone = phone
                        });

                    await data.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> ExistUser(string email, string password)
        {
            try
            {
                using (var data = new ContextDb(_OptionsBuilder))
                {
                    return await data.ApplicationUsers
                        .Where(u => u.Email == email && u.PasswordHash.Equals(password))
                        .AsNoTracking()
                        .AnyAsync();
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
