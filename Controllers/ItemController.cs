using Microsoft.AspNetCore.Mvc;
using WebAPI_Repo__UOW_.Models;
using WebAPI_Repo__UOW_.UnitOfWork;
using WebAPI_Repo_UOW.UnitOfWork;

namespace WebAPI_Repo_UOW.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public ItemController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_uow.Items.readall());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _uow.Items.readbyid(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost("create")]
        public IActionResult Create(Item item)
        {
            // FK protection
            var category = _uow.Category.readbyid(item.CategoryId);
            if (category == null)
                return BadRequest("Invalid CategoryId");

            _uow.Items.create(item);
            _uow.Complete();
            return Ok(item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Item item)
        {
            if (id != item.Id) return BadRequest();

            _uow.Items.update(item);
            _uow.Complete();
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _uow.Items.readbyid(id);
            if (item == null) return NotFound();

            _uow.Items.delete(item);
            _uow.Complete();
            return NoContent();
        }
    }
}
