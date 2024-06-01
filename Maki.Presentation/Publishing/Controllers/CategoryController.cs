using _1_API.Request;
using _1_API.Response;
using _2_Domain;
using _3_Data.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace _1_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryData _categoryData;
        private ICategoryDomain _categoryDomain;
        private IMapper _mapper;
        
        public CategoryController(ICategoryData categoryData, ICategoryDomain categoryDomain, IMapper mapper)
        {
            _categoryData = categoryData;
            _categoryDomain = categoryDomain;
            _mapper = mapper;
        }
        
        // GET: api/Category
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var data = await _categoryData.GetAllAsync();
            var result = _mapper.Map<List<Category>, List<CategoryResponse>>(data);
            return Ok(result);
        }
        
        // GET: api/Category/id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data =  _categoryData.GetById(id);
            var result = _mapper.Map<Category, CategoryResponse>(data);
            
            if (result != null)
                return Ok(result);

            return StatusCode(StatusCodes.Status404NotFound);
        }
        
        // POST: api/Category
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CategoryRequest input)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var category = _mapper.Map<CategoryRequest, Category>(input);
                    var result = await _categoryDomain.SaveAsync(category);
                    if (result > 0)
                        return StatusCode(StatusCodes.Status201Created);
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        
        //PUT: api/Category/id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] CategoryRequest input)
        {
            if (ModelState.IsValid)
            {
                var category = _mapper.Map<CategoryRequest, Category>(input);
                var result = await _categoryDomain.UpdateAsync(category, id);
                if (result)
                {
                    return Ok();
                }
            }
            return StatusCode(StatusCodes.Status400BadRequest);
        }
        
        // DELETE: api/Category/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _categoryDomain.DeleteAsync(id);
            return Ok();
        }

    }
    
}

