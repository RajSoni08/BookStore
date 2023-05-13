using AutoMapper;
using Azure;
using BookStore_API.Model.Dto;
using BookStore_API.Model;
using BookStore_API.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace BookStore_API.Controllers
{
    [Route("api/Publisher")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherRepository _dbPublisher;
        private readonly IMapper _mapper;

        public PublisherController(IPublisherRepository dbPublisher, IMapper mapper)
        {
            _dbPublisher = dbPublisher;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<PublisherDTO>> GetUsers()
        {
            return Ok(await _dbPublisher.GetAllAsync());

        }
        [HttpPost]

        public async Task<ActionResult<PublisherDTO>> CreateUser([FromBody] PublisherDTO publisherDTO)
        {
            var user = await _dbPublisher.GetAsync(u => u.Name.ToLower() == publisherDTO.Name.ToLower());
            if (user is not null)
            {
                ModelState.AddModelError("Errormessages", "Publisher Already Exist");
                return BadRequest(ModelState);
            }
            if (publisherDTO == null)
            {
                return BadRequest(publisherDTO);
            }
            if (publisherDTO.PId > 0)
            {
                return BadRequest();

            }
            Publisher publisher = _mapper.Map<Publisher>(publisherDTO);

            await _dbPublisher.CreateAsync(publisher);
            return Ok(publisherDTO);
        }
        [HttpGet("{id:int}", Name = "GetUserofPublisherController")]
        public async Task<IActionResult> GetUser(int id)
        {
            if (id == 0)
            {

                return BadRequest();

            }
            var user = await _dbPublisher.GetAsync(u => u.PId == id);
            if (user == null)
            {
                return NotFound();
            }
            PublisherDTO Result = _mapper.Map<PublisherDTO>(user);
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
            var user = await _dbPublisher.GetAsync(u => u.PId == id);
            if (user == null)
            {
                return NotFound();
            }

            await _dbPublisher.RemoveAsync(user);
            return Ok("Publisher Deleted Successfully");
        }


        [HttpPut("id")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] PublisherUpdateDTO publisherUpdateUpdateDTO)
        {
            if (publisherUpdateUpdateDTO == null || id != publisherUpdateUpdateDTO.PId)
            {
                return BadRequest(publisherUpdateUpdateDTO);

            }
            Publisher model = _mapper.Map<Publisher>(publisherUpdateUpdateDTO);
            await _dbPublisher.UpdateAsync(model);
            return Ok("User Updated Successfully");
        }
    }
}

