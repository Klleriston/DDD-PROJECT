using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUser
    {
        Task<bool> AddUser(
            string email,
            string password,
            int age,
            int phone
            );

        Task<bool> ExistUser(
            string email,
            string password
            );
    }
}
