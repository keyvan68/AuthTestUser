using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthTestUser.Classes
{
    public static class ExceptionHandlerClass
    {
        public static string GetPersianMessage(Exception Ex)
        {
            return "خطا در عملیات";
        }
    }
}
