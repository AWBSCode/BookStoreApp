using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class clsPersons
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public clsPersons()
        {
            PersonId = -1;
            Name = "";
            Password = "";
            Email = "";
            Phone = "";
        }

        public clsPersons(int personId, string name, string password, string email, string phone)
        {
            PersonId = personId;
            Name = name;
            Password = password;
            Email = email;
            Phone = phone;

            /*if (userID == -1)
            {
                _Mode = enMode.enAddNew;
            } else
            {
                _Mode = enMode.enUpdate;
            }*/
        }

    }
}
