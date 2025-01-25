using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class clsBooks
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public int CountOfCopies { get; set; }
        public string Authors { get; set; }
        public int AuthorsAverageRate { get; set; }

        public clsBooks(int bookID, string title, int price, int countOfCopies, string authors, int rate)
        {
            BookID = bookID;
            Title = title;
            Price = price;
            CountOfCopies = countOfCopies;
            Authors = authors;
            AuthorsAverageRate = rate;
        }

        public clsBooks() {
            BookID = -1;
        }

        public bool AddAuthorToTheBook(int id) { 
            clsAuthors author = clsAuthors.FindAuthor(id);
            return author.AddAuthorCombo(BookID);
        }
        
        static public clsBooks FindBook(int id)
        {
            string Title = "",  authors = "";
            int Price = 0, CountOfCopies = 0, AvgRate = 0;

            bool isFound = clsBook.FindBookByID(id, ref Title, ref Price, ref CountOfCopies, ref authors, ref AvgRate);
            
            if (isFound)
            {
                return new clsBooks(id, Title, Price, CountOfCopies, authors, AvgRate);
            }

            return null; 
        }

        static public DataTable GetAllBooks()
        {
            return clsBook.GetAllBooks();   
        }

        public bool SaveUpdate()
        {
            return clsBook.UpdateBook(BookID, Title, Price, CountOfCopies);
        }

        public bool Delete()
        {
            return clsBook.DeleteBook(BookID);
        }

        public bool DeleteAllAuthorsCombos()
        {
            return clsBook.ClearBookCombos(BookID); 
        }

        public bool SaveAdd()
        {
            bool bookInserted = clsBook.InsertBook(Title, Price, CountOfCopies);
            BookID = bookInserted ? clsBook.GetLastBookID() : 0;
            return bookInserted;
        }

        

    }
}
