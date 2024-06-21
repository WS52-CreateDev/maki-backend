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
    public class DesignController : ControllerBase
    {
        private readonly IDesignData _designData;
        private readonly IMapper _mapper;

        public DesignController(IDesignData designData, IMapper mapper)
        {
            _designData = designData;
            _mapper = mapper;
        }

        // GET: api/Design
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var data = await _designData.GetAllAsync();
            var result = _mapper.Map<List<Design>, List<DesignResponse>>(data);

            if (result.Count == 0) return NotFound();
            return Ok(result);
        }

        // GET: api/Design/id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _designData.GetByIdAsync(id);
            var result = _mapper.Map<Design, DesignResponse>(data);

            if (result != null)
                return Ok(result);

            return NotFound();
        }

        // POST: api/Design
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] DesignRequest input)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var design = _mapper.Map<DesignRequest, Design>(input);
                    await _designData.SaveAsync(design);
                    return StatusCode(StatusCodes.Status201Created);
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        // PUT: api/Design/id
        [HttpPut("{id}")]
        

        // DELETE: api/Design/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _designData.DeleteAsync(id);
            return Ok();
        }
    }
}
