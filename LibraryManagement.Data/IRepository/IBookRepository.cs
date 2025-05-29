using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Models.Entities;

namespace LibraryManagement.Data.IRepository
{
    public interface IBookRepository
    {
        Task<Book> GetBookByIdAsync(int Id);
        Task<List<Book>> GetAllBooksAsync();
        Task UpdateBookAsync(int id, Book book);
        Task DeleteBookAsync(Book bookToDelete);
        Task<Book> AddBookAsync(Book book);

        Task<List<Book>> FindBooksByIds(List<int> ids);
 

    }
}
