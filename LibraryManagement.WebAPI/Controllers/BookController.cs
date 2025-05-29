using LibraryManagement.Models.Dtos;
using LibraryManagement.Models.Entities;
using LibraryManagement.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseObject<List<Book>>>> GetAllBooks()
        {
            var responseObject = await _bookService.GetAllBooksAsync();

            if (responseObject.Success)
            {
                return Ok (responseObject.Data);
            }
            else
            {
                return BadRequest(responseObject.Message);
            }
        }



        [HttpGet("id")]
        public async Task<ActionResult<ResponseObject<List<Book>>>> GetBookById(int id)
        {
            var responseObject = await _bookService.GetBookByIdAsync(id);

            if (responseObject.Success)
            {
                return Ok(responseObject.Data);
            }
            else
            {
                return BadRequest(responseObject.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult<ResponseObject<List<Book>>>> CreateBook(BookDto bookDto)
        {
            var responseObject = await _bookService.CreateBook(bookDto);

            if (responseObject.Success)
            {
                return Ok(responseObject.Data);
            }
            else
            {
                return BadRequest(responseObject.Message);
            }
        }

        [HttpPut("id")]
        public async Task<ActionResult<ResponseObject<List<Book>>>> UpdateBook(int id, BookDto bookDto)
        {
            var responseObject = await _bookService.UpdateBook(id, bookDto);

            if (responseObject.Success)
            {
                return Ok(responseObject.Data);
            }
            else
            {
                return BadRequest(responseObject.Message);
            }
        }
    }
}
