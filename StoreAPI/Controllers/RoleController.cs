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
    public class RoleController : Controller
    {
        private readonly IRoleRepository _repo;

        public RoleController(IRoleRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<RoleDto>>> Get()
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
        public async Task<ActionResult<RoleDto>> Get(Guid id)
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

        [HttpPost]
        public async Task<ActionResult<RoleDto>> Post([FromBody] RoleDto role)
        {
            try
            {
                return await _repo.Create(role);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        public async Task<ActionResult<bool>> Put([FromBody] RoleDto role)
        {
            try
            {
                return await _repo.Update(role);
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
    }
}
