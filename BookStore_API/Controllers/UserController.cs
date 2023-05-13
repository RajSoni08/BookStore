using AutoMapper;
using Azure;
using BookStore_API.Data;
using BookStore_API.Model;
using BookStore_API.Model.Dto;
using BookStore_API.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;

namespace BookStore_API.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _dbUserRepo;
        private readonly IMapper _mapper;
        public UserController(IMapper mapper, IUserRepository dbUserRepo)
        {
            _mapper = mapper;
            _dbUserRepo = dbUserRepo;
        }

        [HttpGet]
        public async Task<ActionResult<UserDTO>> GetUsers()
        {
            return Ok(await _dbUserRepo.GetAllAsync());

        }
        [HttpPost]

        public async Task<ActionResult<UserDTO>> CreateUser([FromBody] UserDTO userDTO)
        {
            var user = await _dbUserRepo.GetAsync(u => u.Name.ToLower() == userDTO.Name.ToLower());
            if (user is not null)
            {
                ModelState.AddModelError("Errormessages", "User Already Exist");
                return BadRequest(ModelState);
            }
            if (userDTO == null)
            {
                return BadRequest(userDTO);
            }
            if (userDTO.Id > 0)
            {
                return BadRequest();

            }
            User users = _mapper.Map<User>(userDTO);

            await _dbUserRepo.CreateAsync(users);




            return Ok(userDTO);
        }
        [HttpGet("{id:int}", Name = "GetUserofUserController")]
        public async Task<IActionResult> GetUser(int id)
        {
            if (id == 0)
            {
                
                return BadRequest();

            }
            var user = await _dbUserRepo.GetAsync(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            UserDTO Result = _mapper.Map<UserDTO>(user);
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
            var user = await _dbUserRepo.GetAsync(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            await _dbUserRepo.RemoveAsync(user);
            return Ok("User Deleted Successfully");
        }


        [HttpPut("id")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserUpdateDTO userUpdateDTO)
        {
            if (userUpdateDTO == null || id != userUpdateDTO.Id)
            {
                return BadRequest(userUpdateDTO);

            }
            User model = _mapper.Map<User>(userUpdateDTO);
            await _dbUserRepo.UpdateAsync(model);
            return Ok("User Updated Successfully");
        }
    }
}

