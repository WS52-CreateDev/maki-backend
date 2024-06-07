using _1_API.Request;
using _1_API.Response;
using _2_Domain;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
namespace _1_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignController : ControllerBase
    {
        private readonly IDesignService _designService;
        private readonly IMapper _mapper;

        public DesignController(IDesignService designService, IMapper mapper)
        {
            _designService = designService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var data = await _designService.GetAllAsync();
            var result = _mapper.Map<List<DesignDomain>, List<DesignResponse>>(data.ToList());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _designService.GetByIdAsync(id);
            if (data == null)
                return NotFound();

            var result = _mapper.Map<DesignDomain, DesignResponse>(data);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] DesignRequest input)
        {
            if (ModelState.IsValid)
            {
                var design = _mapper.Map<DesignRequest, DesignDomain>(input);
                await _designService.CreateAsync(design);
                return StatusCode(StatusCodes.Status201Created);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _designService.DeleteAsync(id);
            return Ok();
        }
    }
}