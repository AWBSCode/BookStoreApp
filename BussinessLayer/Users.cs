using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class clsUsers : clsPersons
    {
        public int UserID { get; set; }
        
        public clsUsers()
        {
            UserID = -1;
        }

        public clsUsers(int userID, int personId, string name, string password, string email, string phone)
            : base(personId, name, password, email, phone)
        {
            UserID = userID;          
        }

        private bool _Update()
        {
            // if (UserID == -1) return false; 

            return DataAccessLayer.clsUser.UpdateUser(UserID, Name, Phone, Password, Email);
        }

        public bool Delete()
        {
            if (UserID == -1) return false;
            return DataAccessLayer.clsUser.DeleteUserByID(UserID);
        }

        public bool Save()
        {
            return _Update();
        }

        public bool AddSave()
        {
            return DataAccessLayer.clsLoginAndSignupDataAccess.SignUserUp(Name, Phone, Password, Email);
        }

        static public clsUsers FindUserByID(int id)
        {
            int personId = 0;
            string name = "", email = "", password = "", phone = "";
            clsUser.FindUserByID(id, ref personId, ref name, ref phone, ref password, ref email);
            clsUsers Found = new clsUsers(id, personId, name, password, email, phone);
            return Found;
        }

        static public DataTable GetAllUsersData()
        {
            return DataAccessLayer.clsUser.GetAllUsers();
        }

    }
}
