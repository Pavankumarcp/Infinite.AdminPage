using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Infinite.AdminPage.Repositories;
using Infinite.AdminPage.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infinite.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegUserController : ControllerBase
    {
        private readonly IRepository<RegUser> _repository;
       public RegUserController(IRepository<RegUser> repository)
        {
            _repository=repository;
        }
        [HttpGet("GetAllUsers")]
        public IEnumerable<RegUser> GetUsers()
        {
            return _repository.GetAll();
        }
        [HttpPut("UpdateUserDetails/{Id}")]
        public async Task<IActionResult> UpdateUserDetails(int Id, [FromBody] RegUser reguser)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _repository.Update(Id, reguser);
            if(result!=null)
            {
                return NoContent();
            }
            return NotFound("User Not Found");
        }
    }
}
