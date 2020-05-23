using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.DATA.Dto;
using Store.DATA.Entities;
using Store.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.API.Controllers
{
    [Route("api/[controller]")]
    public class ItemController : Controller
    {
        private readonly IItemRepository _repo;

        public ItemController(IItemRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<ItemDto>>> Get()
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
        public async Task<ActionResult<ItemDto>> Get(Guid id)
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

        [HttpGet("category/{id}")]
        public async Task<ActionResult<List<ItemDto>>> GetByCategory(Guid id)
        {
            try
            {
                return await _repo.GetByCategory(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<ItemDto>> Post([FromBody] ItemDto item)
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
        public async Task<ActionResult<bool>> Put([FromBody] ItemDto item)
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
