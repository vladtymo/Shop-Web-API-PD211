using AutoMapper;
using Core.Dtos;
using Core.Models;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiServer_PD211.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ShopDbContext ctx;
        private readonly IMapper mapper;

        public ProductsController(ShopDbContext ctx, IMapper mapper)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var items = mapper.Map<List<ProductDto>>(ctx.Products.ToList());
            return Ok(items);
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var product = ctx.Products.Find(id);
            if (product == null) return NotFound();

            // load product category
            ctx.Entry(product).Reference(x => x.Category).Load();

            return Ok(mapper.Map<ProductDto>(product));
        }

        [HttpPost]
        public IActionResult Create(CreateProductModel model)
        {
           if (!ModelState.IsValid) return BadRequest();

           ctx.Products.Add(mapper.Map<Product>(model));
           ctx.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Edit(Product model)
        {
            if (!ModelState.IsValid) return BadRequest();

            ctx.Products.Update(model);
            ctx.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var product = ctx.Products.Find(id);
            if (product == null) return NotFound();

            ctx.Products.Remove(product);
            ctx.SaveChanges();

            return Ok();
        }
    }
}
