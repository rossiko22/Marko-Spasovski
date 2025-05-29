using LibraryManagement.Data.IRepository;
using LibraryManagement.Models.Dtos;
using LibraryManagement.Models.Entities;
using LibraryManagement.Services.IServices;
using Microsoft.IdentityModel.Tokens;

namespace LibraryManagement.Services.Services
{
    public class BookService: IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }



        public async Task<ResponseObject<List<Book>>> GetAllBooksAsync()
        {
            var books = await _bookRepository.GetAllBooksAsync();

            if (books == null || books.IsNullOrEmpty())
            {
                return new ResponseObject<List<Book>>
                {
                    Data = null,
                    Message = $"There are no books currently",
                    Success = false,
                };
            }

            return new ResponseObject<List<Book>>
            {
                Data = books,
                Message = $"Books sucesfully fetched",
                Success = true,
            };

        }


        public async Task<ResponseObject<Book>> GetBookByIdAsync(int Id)
        {
            var book = await _bookRepository.GetBookByIdAsync(Id);

            if (book == null)
            {
                return new ResponseObject<Book>
                {
                    Data = null,
                    Message = $"Book with id {Id} not found!",
                    Success = false,
                };
            }

            return new ResponseObject<Book>
            {
                Data = book,
                Message = $"Book with id {Id} found!",
                Success = true,
            };

        }


        public async Task<ResponseObject<Book>> CreateBook(BookDto bookDto)
        {
            
            if(bookDto.Publisher == "" || bookDto.Publisher == "" || bookDto.Name == "" || bookDto.Author == "" || bookDto.Year == "" || bookDto.NumberOfCopies <= 0)
            {
                return new ResponseObject<Book>
                {
                    Data = null,
                    Message = $"All fields must be filled",
                    Success = false,
                };
            }

            Book book = new Book
            {
                IBAN = bookDto.IBAN,
                Name = bookDto.Name,
                Author = bookDto.Author,
                Publisher = bookDto.Publisher,
                Year = bookDto.Year,
                NumberOfCopies = bookDto.NumberOfCopies,

            };

            return new ResponseObject<Book>
            {
                Data = book,
                Message = $"Sucessfully Created!",
                Success = true,
            };

        }


        public async Task<ResponseObject<Book>> UpdateBook(int id , BookDto bookDto)
        {

            var bookToUpdate = await _bookRepository.GetBookByIdAsync(id);


            if (bookToUpdate == null)
            {
                return new ResponseObject<Book>
                {
                    Data = null,
                    Message = $"Book with id {id} not found!",
                    Success = false,
                };
            }

            if (bookDto.Publisher == "" || bookDto.Publisher == "" || bookDto.Name == "" || bookDto.Author == "" || bookDto.Year == "" || bookDto.NumberOfCopies <= 0)
            {
                return new ResponseObject<Book>
                {
                    Data = null,
                    Message = $"All fields must be filled",
                    Success = false,
                };
            }

            bookToUpdate.IBAN = bookDto.IBAN;
            bookToUpdate.Name = bookDto.Name;
            bookToUpdate.Author = bookDto.Author;
            bookToUpdate.Publisher = bookDto.Publisher;
            bookToUpdate.Year = bookDto.Year;
            bookToUpdate.NumberOfCopies = bookDto.NumberOfCopies;

            await _bookRepository.UpdateBookAsync(id, bookToUpdate);

            return new ResponseObject<Book>
            {
                Data = null,
                Message = $"Book Sucessfully Updated",
                Success = false,
            };
        }

        public async Task<ResponseObject<Book>> DeleteBookById(int Id)
        {
            var book = await _bookRepository.GetBookByIdAsync(Id);

            if (book == null)
            {
                return new ResponseObject<Book>
                {
                    Data = null,
                    Message = $"Book with id {Id} not found!",
                    Success = false,
                };
            }

            await _bookRepository.DeleteBookAsync(book);

            return new ResponseObject<Book>
            {
                Data = book,
                Message = $"Book with id {Id} deleted!",
                Success = true,
            };

        }




    }
}
