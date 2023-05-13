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
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _dbAuthor;
        private readonly IMapper _mapper;
        public AuthorController(IAuthorRepository dbAuthor, IMapper mapper)
        {
            _dbAuthor = dbAuthor;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<AuthorDTO>> GetUsers()
        {
            return Ok(await _dbAuthor.GetAllAsync());

        }
        [HttpPost]

        public async Task<ActionResult<AuthorDTO>> CreateUser([FromBody] AuthorDTO authorDTO)
        {
            var user = await _dbAuthor.GetAsync(u => u.Name.ToLower() == authorDTO.Name.ToLower());
            if (user is not null)
            {
                ModelState.AddModelError("Errormessages", "Author Already Exist");
                return BadRequest(ModelState);
            }
            if (authorDTO == null)
            {
                return BadRequest(authorDTO);
            }
            if (authorDTO.AID > 0)
            {
                return BadRequest();

            }
            Author author = _mapper.Map<Author>(authorDTO);

            await _dbAuthor.CreateAsync(author);
            return Ok(authorDTO);
        }
        [HttpGet("{id:int}", Name = "GetUserofAuthorController")]
        public async Task<IActionResult> GetUser(int id)
        {
            if (id == 0)
            {

                return BadRequest();

            }
            var user = await _dbAuthor.GetAsync(u => u.AID == id);
            if (user == null)
            {
                return NotFound();
            }
            Author Result = _mapper.Map<Author>(user);
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
            var user = await _dbAuthor.GetAsync(u => u.AID == id);
            if (user == null)
            {
                return NotFound();
            }

            await _dbAuthor.RemoveAsync(user);
            return Ok("Author Deleted Successfully");
        }


        [HttpPut("id")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] AuthorUpdateDTO authorUpdateUpdateDTO)
        {
            if (authorUpdateUpdateDTO == null || id != authorUpdateUpdateDTO.AID)
            {
                return BadRequest(authorUpdateUpdateDTO);

            }
            Author model = _mapper.Map<Author>(authorUpdateUpdateDTO);
            await _dbAuthor.UpdateAsync(model);
            return Ok("Author Updated Successfully");
        }

    }
}
