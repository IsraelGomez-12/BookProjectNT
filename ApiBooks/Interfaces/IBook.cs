using ApiBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ApiBooks.Interfaces
{
    public interface IBook
    {
        Task <List<Book>> GetBooks();
        Task<Book> CreateBook(Book book);
        Task<Book> UpdateBook(Book book);
        Task<Book> GetBookById(int id);
        Task<HttpStatusCode> DeleteBook(int id);
    }
}
