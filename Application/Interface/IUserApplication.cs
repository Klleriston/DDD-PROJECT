using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IUserApplication
    {
        Task<bool> AddUser(
            string email,
            string password,
            int age,
            int phone
            );
    }
}
