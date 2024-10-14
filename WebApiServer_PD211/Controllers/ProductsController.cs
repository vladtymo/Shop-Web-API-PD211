using AutoMapper;
using Core.Dtos;
using Core.Interfaces;
using Data;
using Data.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiServer_PD211.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(productsService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(productsService.Get(id));
        }

        [HttpPost]
        public IActionResult Create(CreateProductDto model)
        {
            productsService.Create(model);
            return Ok();
        }

        [HttpPut]
        public IActionResult Edit(EditProductDto model)
        {
            productsService.Edit(model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            productsService.Delete(id);
            return Ok();
        }
    }
}
