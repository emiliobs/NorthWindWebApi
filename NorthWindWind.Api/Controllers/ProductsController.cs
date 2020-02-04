using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.Entities.Entities;
using NorthWind.Dal;

namespace NorthWindWind.Api.Controllers
{
    [Produces("application/json")]
    [Route("products")]
    [EnableCors("CORSPolicy")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsRepository _productsRepository;

        public ProductsController(ProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        [HttpGet]
        public List<Product> Get()
        {
            return _productsRepository.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_productsRepository.GetById(id));
        }

        [HttpPost]         
        public IActionResult Post([FromBody] Product product)
        {
          
              return Ok(_productsRepository.Create(product));
            //return new CreatedAtRouteResult("Get", new { id = product.Id }, product);


        }

        
        public IActionResult Put([FromBody] Product product)
        {
           
           return Ok(_productsRepository.Update(product));
           
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productsRepository.Delete(id);
            return NoContent();
        }

    }
}