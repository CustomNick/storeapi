using Microsoft.AspNetCore.Mvc;
using Store.DATA.Dto;
using Store.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository _repo;

        public UserController(IUserRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> Get()
        {
            try
            {
                return await _repo.GetAll();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> Get(Guid id)
        {
            try
            {
                return await _repo.GetById(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("email/{email}")]
        public async Task<ActionResult<UserDto>> Get(string email)
        {
            try
            {
                return await _repo.GetByEmail(email);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("role")]
        public async Task<ActionResult<List<UserDto>>> GetByRole([FromBody] string name)
        {
            try
            {
                return await _repo.GetByRole(name);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("role/{id}")]
        public async Task<ActionResult<List<string>>> GetRoles(Guid id)
        {
            try
            {
                return await _repo.GetRolesById(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost("{name}")]
        public async Task<ActionResult<bool>> Post([FromBody] UserDto user, string name)
        {
            try
            {
                return await _repo.AddUser(user, name);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Post([FromBody] UserDto user)
        {
            try
            {
                return await _repo.Create(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        public async Task<ActionResult<bool>> Put([FromBody] UserDto user)
        {
            try
            {
                return await _repo.Update(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            try
            {
                return await _repo.Delete(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete("role/{name}")]
        public async Task<ActionResult<bool>> DeleteUser([FromBody] UserDto user, string name)
        {
            try
            {
                return await _repo.DeleteUser(user, name);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
