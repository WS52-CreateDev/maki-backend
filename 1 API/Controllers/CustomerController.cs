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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerData _customerData;
        private readonly ICustomerDomain _customerDomain;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerData customerData, ICustomerDomain customerDomain, IMapper mapper)
        {
            _customerData = customerData;
            _customerDomain = customerDomain;
            _mapper = mapper;
        }

        // GET: api/Customer
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var data = await _customerData.GetAllAsync();
            var result = _mapper.Map<List<Customer>, List<CustomerResponse>>(data.ToList());
            return Ok(result);
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _customerData.GetByIdAsync(id);
            if (data == null)
                return NotFound();

            var result = _mapper.Map<Customer, CustomerResponse>(data);
            return Ok(result);
        }

        // POST: api/Customer
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CustomerRequest input)
        {
            if (ModelState.IsValid)
            {
                var customer = _mapper.Map<CustomerRequest, Customer>(input);
                var result = await _customerDomain.RegisterCustomerAsync(customer);
                if (result)
                    return StatusCode(StatusCodes.Status201Created);

                return BadRequest("Could not register customer.");
            }

            return BadRequest(ModelState);
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] CustomerRequest input)
        {
            if (ModelState.IsValid)
            {
                var customer = _mapper.Map<CustomerRequest, Customer>(input);
                var result = await _customerDomain.UpdateCustomerAsync(id, customer);
                if (result)
                    return Ok();

                return NotFound("Customer not found.");
            }

            return BadRequest(ModelState);
        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _customerDomain.DeleteCustomerAsync(id);
            if (result)
                return Ok();

            return NotFound("Customer not found.");
        }
// POST: api/Customer/login
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var customer = await _customerDomain.AuthenticateCustomerAsync(loginRequest.Email, loginRequest.Password);
                if (customer != null)
                {
                    var result = _mapper.Map<Customer, CustomerResponse>(customer);
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
