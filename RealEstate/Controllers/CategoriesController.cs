using Microsoft.AspNetCore.Mvc;
using RealEstate.Models;
using RealEstate.Data;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RealEstate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        // get DB Context Class
        private readonly ApiDbContext _dbContext = new();



        // get all list of categories
        // IEnumerable<Category>
        [HttpGet]
        public async Task<IEnumerable<Category>> Get()
        {
            // return all the categories
            //return Ok(_dbContext.Categories);
            //return StatusCode(StatusCodes.Status200OK, result);

            return await _dbContext.Categories.ToListAsync();

        }


        // Get Category By Id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var category = _dbContext.Categories.FirstOrDefault(x => x.Id == id);
            if (category == null) return StatusCode(StatusCodes.Status404NotFound, null);
            return StatusCode(StatusCodes.Status200OK, category);
        }


        // custom route
        // api/categories/GetSortCategories
        [HttpGet("[action]")]
        public async Task<IEnumerable<Category>> SortCategories()
        {
            return await _dbContext.Categories.OrderByDescending(x => x.Name).ToListAsync();
        }


        // post
        // [FromBody] -> parse the request from the body
        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);


        }

        // put
        // [HttpPut("{id}")]  -> id

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Category categoryObj)
        {
            var category = _dbContext.Categories.Find(id);

            // check if id exist
            if (category == null) return StatusCode(StatusCodes.Status404NotFound, null);

            category.Name = categoryObj.Name;
            category.ImageUrl = categoryObj.ImageUrl;

            _dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status200OK);

        }


        // delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = _dbContext.Categories.Find(id);

            // check if id exist
            if (category == null) return StatusCode(StatusCodes.Status404NotFound, null);

            _dbContext.Categories.Remove(category);
            return Ok("Record Deleted");
        }




    }
}

