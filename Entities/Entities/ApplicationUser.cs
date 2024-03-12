using Entities.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Column("USER_AGE")]
        public int Age { get; set; }
        [Column("USER_NUMBER")]
        public int Number { get; set; }
        [Column("USER_TYPE")]
        public TypeUsers UserType { get; set; }
    }
}
