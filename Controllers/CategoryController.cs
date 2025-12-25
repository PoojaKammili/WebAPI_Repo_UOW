using Microsoft.AspNetCore.Mvc;
using WebAPI_Repo__UOW_.Models;
using WebAPI_Repo__UOW_.UnitOfWork;
using WebAPI_Repo_UOW.UnitOfWork;

namespace WebAPI_Repo_UOW.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public CategoryController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_uow.Category.readall());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var category = _uow.Category.readbyid(id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpPost("create")]
        public IActionResult Create(Category category)
        {
            _uow.Category.create(category);
            _uow.Complete();
            return Ok(category);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Category category)
        {
            if (id != category.Id) return BadRequest();

            _uow.Category.update(category);
            _uow.Complete();
            return Ok(category);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = _uow.Category.readbyid(id);
            if (category == null) return NotFound();

            _uow.Category.delete(category);
            _uow.Complete();
            return NoContent();
        }
    }
}
