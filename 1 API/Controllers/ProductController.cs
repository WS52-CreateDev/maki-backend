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
    public class ProductController : ControllerBase
    {
        private IProductData _productData;
        private IProductDomain _productDomain;
        private IMapper _mapper;
        
        public ProductController(IProductData productData, IProductDomain productDomain, IMapper mapper)
        {
            _productData = productData;
            _productDomain = productDomain;
            _mapper = mapper;
        }
        
        // GET: api/Product
        [HttpGet]
        public IActionResult Get()
        {
            var data = _productData.GetAll();
            var result = _mapper.Map<List<Product>, List<ProductResponse>>(data);
            return Ok(result);
        }
        
        // GET: api/Product/id
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var data = _productData.GetById(id);
            var result = _mapper.Map<Product, ProductResponse>(data);
            
            if (result != null)
                return Ok(result);

            return StatusCode(StatusCodes.Status404NotFound);
        }
        
        // POST: api/Product
        [HttpPost]
        public IActionResult Post([FromBody] ProductRequest input)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var product = _mapper.Map<ProductRequest, Product>(input);
                    var result = _productDomain.Save(product);
                    if (result)
                        return StatusCode(StatusCodes.Status201Created);
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        
        //PUT: api/Product/id
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            
        }
        
        // DELETE: api/Product/id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            
        }
    }
    
}
