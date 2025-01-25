using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class clsAuthors : clsPersons
    {
        public int AuthorID { get; set; }
        public int Rate {  get; set; }

        public clsAuthors(int authorID, int personId, string name, string email, string phone, int rate) 
         : base(personId, name, "", email, phone)
        {
            AuthorID = authorID;
            Rate = rate;
        }

        public clsAuthors()
        {
            AuthorID = -1;
            Rate = -1;
        }

        static public clsAuthors FindAuthor(int AuthorId)
        {
            string name = "", email = "", phone = "";
            int rate = 0, personId = 0;
            bool isOk = clsAuthor.FindAuthorByID(AuthorId, ref personId, ref name, ref phone, ref email, ref rate) ;

            if (!isOk)
            {
                return new clsAuthors();
            }

            return new clsAuthors(AuthorId, personId, name, email, phone, rate);
        }

        static public clsAuthors FindAuthor(string AuthorName)
        {
            string email = "", phone = "";
            int rate = 0, personId = 0, AuthorId = 0;
            bool isOk = clsAuthor.FindAuthorByName(AuthorName, ref personId, ref AuthorId, ref email, ref phone, ref rate);

            if (!isOk)
            {
                return new clsAuthors();
            }

            return new clsAuthors(AuthorId, personId, AuthorName, email, phone, rate);
        }

        public bool AddAuthorCombo(int BookID)
        {
            if (clsAuthors.FindAuthor(AuthorID).PersonId == 0)
            {
                return false;
            }

            return clsAuthor.AddAuthorCombo(BookID, AuthorID);
        }

        public bool AddSave()
        {
            return clsAuthor.InsertAuthor(Name, Phone, Email, Rate);
        }

        static public List<string> GetAuthorsList()
        { 
            return clsAuthor.GetAuthorsList();
        }

        public DataTable GetAuthorsBooks()
        {
            return clsAuthor.GetAuthorsBookList(AuthorID);
        }

        static public DataTable GetAllAuthors()
        {
            return clsAuthor.GetAllAuthors();
        }
        
        public bool UpdateSave()
        {
            return clsAuthor.UpdateAuthor(AuthorID, PersonId, Name, Phone, Email, Rate);
        }

        public bool DeleteAuthorAndHisBooks()
        {
            int personID = clsAuthors.FindAuthor(AuthorID).PersonId;
            return clsAuthor.DeleteAuthor(AuthorID) && clsPerson.DeletePerson(personID);

        }

        static public string GetLatestAddedAuthorName()
        {
            return clsAuthor.GetLastAuthorName();
        }
    }
}
