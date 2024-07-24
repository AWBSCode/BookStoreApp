
// There is a problem with referencing and importing
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public static class clsLoginAndSignupBussinessLayer
    {
        public static bool LoginUser(string Email, string Password)
        {
            return clsLoginAndSignupDataAccess.LoginUser(Email, Password);
        }

        public static bool UserSignup(string name, string phone, string password, string email) {
            return clsLoginAndSignupDataAccess.SignUserUp(name, phone, password, email);
        }

        public static int GetInsertedPersonID(string name, string phone, string password, string email) {
            return clsLoginAndSignupDataAccess.InsertPersonAndGetID(name, phone, password, email);
        }

        public static bool LoginAdmin(string Email, string Password)
        {
            return clsLoginAndSignupDataAccess.LoginAdmin(Email, Password);
        }
    }
}
