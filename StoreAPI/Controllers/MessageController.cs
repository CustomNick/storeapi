using Microsoft.AspNetCore.Authorization;
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
    public class MessageController : Controller
    {
        private readonly IMessageRepository _repo;

        public MessageController(IMessageRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<MessageDto>>> Get(Guid id)
        {
            try
            {
                return await _repo.GetByItem(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<MessageDto>> Post([FromBody] MessageDto message)
        {
            try
            {
                return await _repo.Send(message);
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
