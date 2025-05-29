using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Data.IRepository;
using LibraryManagement.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Data.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly DatabaseContext _databaseContext;

        public BookRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<Book> GetBookByIdAsync(int Id)
        {
            var book = await _databaseContext.Books.FirstOrDefaultAsync(book => book.Id == Id);
            return book;
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            var books = await _databaseContext.Books.ToListAsync();
            return books;
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            await _databaseContext.Books.AddAsync(book);
            await _databaseContext.SaveChangesAsync();
            return book;
        }

        public async Task DeleteBookAsync(Book bookToDelete)
        {

            _databaseContext.Books.Remove(bookToDelete);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task UpdateBookAsync(int id, Book book)
        {
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<List<Book>> FindBooksByIds(List<int> ids)
        {
            List<Book> Books = new List<Book>();
            List<int> allBooksId = await _databaseContext.Books.Select(b => b.Id).ToListAsync();

            for (int i = 0; i < allBooksId.Count; i++)
            {
                if (ids.Contains(allBooksId[i]))
                {
                    var idOfBook = allBooksId[i];
                    var book = await _databaseContext.Books.FirstOrDefaultAsync(b => b.Id == idOfBook);
                    Books.Add(book);
                }   
            }
            return Books;
        }
    }
}