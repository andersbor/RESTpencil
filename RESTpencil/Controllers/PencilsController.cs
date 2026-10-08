using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RESTpencil.Models;

namespace RESTpencil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PencilsController : ControllerBase
    {

        private readonly PencilsRepository _pencilsRepository;

        public PencilsController(PencilsRepository pencilsRepository)
        {
            _pencilsRepository = pencilsRepository;
        }

        // GET: api/<PencilsController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Pencil>> Get()
        {
            List<Pencil> pencils = _pencilsRepository.GetAllPencils();
            return Ok(pencils);
        }

        // GET api/<PencilsController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Pencil> Get(int id)
        {
            var pencil = _pencilsRepository.GetPencilById(id);
            if (pencil == null)
            {
                return NotFound();
            }
            return Ok(pencil);
        }

        // POST api/<PencilsController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Authorize(Roles = "Admin")]
        public ActionResult<Pencil> Post([FromBody] Pencil pencil)
        {
            var addedPencil = _pencilsRepository.AddPencil(pencil);
            return CreatedAtAction(nameof(Get), new { id = addedPencil.Id }, addedPencil);
        }

        // PUT api/<PencilsController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Admin")]
        public ActionResult<Pencil> Put(int id, [FromBody] Pencil updatedPencil)
        {
            var pencil = _pencilsRepository.UpdatePencil(id, updatedPencil);
            if (pencil == null)
            {
                return NotFound();
            }
            return Ok(pencil);
        }

        // DELETE api/<PencilsController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Admin")]
        public ActionResult<Pencil> Delete(int id)
        {
            var pencil = _pencilsRepository.DeletePencil(id);
            if (pencil == null)
            {
                return NotFound();
            }
            return Ok(pencil);  
        }
    }
}
