using _1_API.Request;
using _1_API.Response;
using _2_Domain;
using _3_Data;
using _3_Data.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace _1_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtisanController : ControllerBase
    {
        private readonly IArtisanData _artisanData;
        private readonly IArtisanDomain _artisanDomain;
        private readonly IMapper _mapper;
        
        public ArtisanController(IArtisanData artisanData, IArtisanDomain artisanDomain, IMapper mapper)
        {
            _artisanData = artisanData;
            _artisanDomain = artisanDomain;
            _mapper = mapper;
        }
        
        // GET: api/Artisan
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var data = await _artisanData.GetAllAsync();
            var result = _mapper.Map<List<Artisan>, List<ArtisanResponse>>(data.ToList());
            return Ok(result);
        }
        //Post: api/Artisan
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ArtisanRequest input)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var artisan = _mapper.Map<ArtisanRequest, Artisan>(input);
                    var result = await _artisanDomain.RegisterArtisanAsync(artisan);
                    if (result)
                        return StatusCode(StatusCodes.Status201Created);
                    return BadRequest("Could not register artisan.");
                }
                return BadRequest(ModelState);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
            
        }
        
        //Put: api/Artisan/id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] ArtisanRequest input)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var artisan = _mapper.Map<ArtisanRequest, Artisan>(input);
                    var result = await _artisanDomain.UpdateArtisanAsync(id, artisan);
                    if (result)
                        return StatusCode(StatusCodes.Status200OK);
                    return BadRequest("Could not update artisan.");
                }
                return BadRequest(ModelState);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        
        //Delete: api/Artisan/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var result = await _artisanDomain.DeleteArtisanAsync(id);
                if (result)
                    return StatusCode(StatusCodes.Status200OK);
                return BadRequest("Could not delete artisan.");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        
        //Post: api/Artisan/login
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var artisan = await _artisanDomain.AuthenticateArtisanAsync(loginRequest.Email, loginRequest.Password);
                if (artisan != null)
                {
                    var result = _mapper.Map<Artisan, ArtisanResponse>(artisan);
                    return Ok(result);
                }
                return Unauthorized("Invalid email or password.");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }


    }
}