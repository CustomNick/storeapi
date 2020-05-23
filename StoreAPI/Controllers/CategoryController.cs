using Microsoft.AspNetCore.Mvc;
using Store.DATA.Entities;
using Store.DATA.Dto;
using Store.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _repo;

        public CategoryController(ICategoryRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Produces(typeof(Response<List<CategoryDto>>))]
        public async Task<ActionResult<List<CategoryDto>>> Get()
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
        public async Task<ActionResult<CategoryDto>> Get(Guid id)
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
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<CategoryDto>> Post([FromBody] CategoryDto item)
        {
            try
            {
                return await _repo.Create(item);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<bool>> Put([FromBody] CategoryDto item)
        {
            try
            {
                return await _repo.Update(item);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
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
