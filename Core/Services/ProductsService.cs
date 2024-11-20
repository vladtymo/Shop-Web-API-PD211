using AutoMapper;
using Core.Dtos;
using Core.Exceptions;
using Core.Interfaces;
using Data;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Core.Services
{
    public class ProductsService : IProductsService
    {
        private readonly ShopDbContext ctx;
        private readonly IMapper mapper;
        private readonly IFileService fileService;

        public ProductsService(ShopDbContext ctx, IMapper mapper, IFileService fileService)
        {
            this.ctx = ctx;
            this.mapper = mapper;
            this.fileService = fileService;
        }

        public IEnumerable<CategoryDto> GetCategories()
        {
            return mapper.Map<IEnumerable<CategoryDto>>(ctx.Categories.ToList());
        }
        
        public async Task Create(CreateProductDto model)
        {
            // TODO: validate
            Product entity = mapper.Map<Product>(model);
            
            if (model.Image != null)
                entity.ImageUrl = await fileService.SaveFile(model.Image);

            ctx.Products.Add(entity);
            await ctx.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var product = ctx.Products.Find(id);
            if (product == null) 
                throw new HttpException($"Product with id: {id} not found.", HttpStatusCode.NotFound);

            ctx.Products.Remove(product);
            ctx.SaveChanges();
        }

        public void Edit(EditProductDto model)
        {
            // TODO: validate

            ctx.Products.Update(mapper.Map<Product>(model));
            ctx.SaveChanges();
        }

        public ProductDto? Get(int id)
        {
            var product = ctx.Products.Find(id);
            if (product == null) 
                throw new HttpException($"Product with id: {id} not found.", HttpStatusCode.NotFound);

            // load product category
            ctx.Entry(product).Reference(x => x.Category).Load();

            return mapper.Map<ProductDto>(product);
        }

        public IEnumerable<ProductDto> GetAll()
        {
            return mapper.Map<List<ProductDto>>(ctx.Products.ToList());
        }
    }
}
