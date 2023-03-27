using Microsoft.AspNetCore.Mvc;
using webApi.Models;
using webApi.Services;

namespace webApi.Controllers
{
    [ApiController]
    [Route("api/owner")]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerController(IOwnerRepository ownerRepository)
        {

            _ownerRepository = ownerRepository;
        }

        [HttpGet(Name = "GetOwners")]
        public async Task<IActionResult> GetOwners()
        {
            var owners = await _ownerRepository.GetOwners();
            return Ok(owners);
        }

        [HttpGet("{id}", Name = "GetOwner")]
        public async Task<IActionResult> GetOwner(int id)
        {
            var owner = await _ownerRepository.GetOwner(id);
            if (owner == null)
            {
                return NotFound();
            }
            return Ok(owner);
        }
        [HttpGet("{id}/account")]
        public async Task<ActionResult<Owner>> GetOwnerWithDetails(int id)
        {
            var owner = await _ownerRepository.GetOwnerWithDetails(id);
            if (owner == null)
            {
                return NotFound();
            }
            else
            {
                // var ownerResult = _mapper.Map<OwnerDto>(owner);
                return Ok(owner);
            }
        }

        [HttpPost(Name = "CreateOwner")]
        public async Task<IActionResult> CreateOwner([FromBody] Owner owner)
        {
            if (owner == null)
            {
                return BadRequest("Owner object is null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }
            _ownerRepository.CreateOwner(owner);
            return CreatedAtRoute("GetOwner", new { id = owner.Id }, owner);
        }
        [HttpDelete("{id}", Name = "DeleteOwner")]
        public async Task<IActionResult> DeleteOwner(int id)
        {
            var owner = await _ownerRepository.GetOwner(id);
            if (owner == null)
            {
                return NotFound();
            }
            _ownerRepository.DeleteOwner(owner);
            return NoContent();
        }

        [HttpPut("{id}", Name = "UpdateOwner")]
        public async Task<IActionResult> UpdateOwner(int id, [FromBody] Owner owner)
        {
            if (owner == null)
            {
                return BadRequest("Owner object is null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }
            var ownerEntity = await _ownerRepository.GetOwner(id);
            if (ownerEntity == null)
            {
                return NotFound();
            }
            _ownerRepository.UpdateOwner(ownerEntity, owner);
            return NoContent();
        }
    }
}