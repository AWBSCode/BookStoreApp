using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class clsUsers : DataAccessLayer.clsUser
    {
        static public stUser GetUserByID(int id)
        {
            return FindUserByID(id);
        }

        static public DataTable GetAllUsersData()
        {
            return GetAllUsers(); // changed without testing. Maybe have a bug.
        }

        static public bool UpdateUser(stUser User)
        {
            return UpdateUserByID(User);
        }

        static public bool DeleteUser(int UserID)
        {
            return DeleteUserByID(UserID);
        }
    }
}
