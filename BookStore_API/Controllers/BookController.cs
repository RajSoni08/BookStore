using AutoMapper;
using Azure;
using BookStore_API.Data;
using BookStore_API.Model.Dto;
using BookStore_API.Model;
using BookStore_API.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace BookStore_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _dbBook;
        private readonly IMapper _mapper;

        public BookController(IBookRepository dbBook, IMapper mapper)
        {
            _dbBook = dbBook;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<BookDTO>> GetUsers()
        {
            return Ok(await _dbBook.GetAllAsync());

        }
        [HttpPost]

        public async Task<ActionResult<BookDTO>> CreateUser([FromBody] BookDTO bookDTO)
        {
            var user = await _dbBook.GetAsync(u => u.Title.ToLower() == bookDTO.Title.ToLower());
            if (user is not null)
            {
                ModelState.AddModelError("Errormessages", "Book Already Exist");
                return BadRequest(ModelState);
            }
            if (bookDTO == null)
            {
                return BadRequest(bookDTO);
            }
            if (bookDTO.ID > 0)
            {
                return BadRequest();

            }
            Book author = _mapper.Map<Book>(bookDTO);

            await _dbBook.CreateAsync(author);
            return Ok(bookDTO);
        }
        [HttpGet("{id:int}", Name = "GetUserofBookController")]
        public async Task<IActionResult> GetUser(int id)
        {
            if (id == 0)
            {

                return BadRequest();

            }
            var user = await _dbBook.GetAsync(u => u.ID == id);
            if (user == null)
            {
                return NotFound();
            }
            Book Result = _mapper.Map<Book>(user);
            return Ok(Result);
        }
        [HttpDelete("id")]
        [Authorize(Roles = "admin")]


        public async Task<IActionResult> DeleteUser(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var user = await _dbBook.GetAsync(u => u.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            await _dbBook.RemoveAsync(user);
            return Ok("Book Deleted Successfully");
        }


        [HttpPut("id")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] BookUpdateDTO BookUpdateDTO)
        {
            if (BookUpdateDTO == null || id != BookUpdateDTO.ID)
            {
                return BadRequest(BookUpdateDTO);

            }
            Book model = _mapper.Map<Book>(BookUpdateDTO);
            await _dbBook.UpdateAsync(model);
            return Ok("Book Updated Successfully");
        }
    }
}
