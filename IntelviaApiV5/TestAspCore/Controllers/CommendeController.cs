using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAspCore.Models;
using TestAspCore.Repositories;

namespace TestAspCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommendeController : ControllerBase
    {
        private readonly IStoreRepository<CommandeModel> _store;
        public CommendeController(IStoreRepository<CommandeModel> store)
        {
            _store = store;
        }


        [HttpGet("Getcomd")]

        public async Task<IEnumerable<CommandeModel>> GetComd()
        {
            return await _store.Get();
        }

        [HttpGet("{id}")]

        public async Task<CommandeModel> GetComd(Guid id)
        {
            return await _store.Get(id);
        }


        [HttpPost("Postcmd")]

        public async Task<ActionResult<CommandeModel>> PostCmd([FromBody] CommandeModel cmd)
        {
            var newCmd = await _store.Create(cmd);
            return CreatedAtAction(nameof(GetComd), new { id = newCmd.id }, newCmd);
        }

        [HttpPut]

        public async Task<ActionResult<CommandeModel>> PutCmd(Guid id, [FromBody] CommandeModel cmd)
        {
            if (id != cmd.id)
            {
                return BadRequest();
            }
            await _store.Update(cmd);
            return NoContent();
        }


        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(Guid id)
        {
            var cmdDelet = await _store.Get(id);
            if (cmdDelet == null)
                return NotFound();
            await _store.Delete(cmdDelet.id);
            return NoContent();
        }
    }
}
