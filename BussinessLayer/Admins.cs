using DataAccessLayer;
using System.Data;

namespace BussinessLayer
{
    public class clsAdmins : clsPersons 
    {
        public int AdminId { get; set; }
        public int PermissionCode { get; }

        public enum enPermissions
        {
            enUsers,
            enAdmins,
            enBook,
        }

        protected clsAdmins()
        {
            AdminId = -1;
            PermissionCode = 0;
        }

        public clsAdmins(int adminId, int permissionCode, int personId, string name, string password, string email, string phone)
            : base(personId, name, password, email, phone)
        {
            AdminId = adminId;
            PermissionCode = permissionCode;
        }

        public DataTable GetAllAdmins()
        {
            if (clsAdmin.HasPermissionFor(PermissionCode, clsAdmin.enPermissions.admins)) {
                return DataAccessLayer.clsAdmin.GetAllAdmins();
            }

            return null;
        }

        static public clsAdmins FindAdminByID(int ID)
        {
            int PersonId=0, Perms=0;
            string Name = "", Password = "", Phone = "", Email = "";
            clsAdmin.FindAdmin(ID, ref PersonId, ref Name, ref  Phone, ref Password, ref Email, ref Perms);

            clsAdmins admin = new clsAdmins(ID, Perms, PersonId, Name, Password, Email, Phone);

            return admin;
        }

        public bool HasPermissionFor(enPermissions wantedPerm)
        {
            if (PermissionCode == -1) return true;
            clsAdmin.enPermissions Perm = clsAdmin.enPermissions.None;
            
            if (wantedPerm == enPermissions.enBook)
            {
                Perm= clsAdmin.enPermissions.books;
            }  else if (wantedPerm == enPermissions.enUsers)
            {
                Perm = clsAdmin.enPermissions.users;
            } else if (wantedPerm == enPermissions.enAdmins)
            {
                Perm = clsAdmin.enPermissions.admins;
            }

            return clsAdmin.HasPermissionFor(PermissionCode, Perm);
        }

        public bool SaveUpdate()
        {
            return clsAdmin.UpdateAdmin(AdminId, Name, Phone, Password, Email, PermissionCode);
        }

        public bool AddNewAndSave()
        {
            return clsAdmin.InsertNewAdmin(Name, Phone, Password, Email, PermissionCode);
        }

        static public int GetPermissionCode(bool users, bool books, bool admins)
        {
            return clsAdmin.CreatePermissionCode(users, books, admins);
        }

        public bool Delete()
        {
            return clsAdmin.DeleteAdmin(AdminId);
        }
    }
}
