using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthTestUser.Enums
{
    public enum UserRoleEnum
    {
        [Display(Name = "ادمین")]
        Admin = 1,
        [Display(Name = "کاربر")]
        User = 2,


    }
}
