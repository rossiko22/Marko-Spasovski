using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Models.Dtos;
using LibraryManagement.Models.Entities;

namespace LibraryManagement.Services.IServices
{
    public interface IBookService
    {
        Task<ResponseObject<Book>> DeleteBookById(int Id);
        Task<ResponseObject<Book>> UpdateBook(int id, BookDto bookDto);
        Task<ResponseObject<Book>> CreateBook(BookDto bookDto);
        Task<ResponseObject<Book>> GetBookByIdAsync(int Id);
        Task<ResponseObject<List<Book>>> GetAllBooksAsync();
    }
}
