using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class Person
    {
        public enum PersonRole
        {
            User,
            Admin
        };

        public PersonRole Role = PersonRole.User;

        public Person(PersonRole personRole)
        {
            this.Role = personRole;
        }

        

    }
}
