﻿using AutoMapper;
using Core.Dtos;
using Core.Interfaces;
using Data;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class ProductsService : IProductsService
    {
        private readonly ShopDbContext ctx;
        private readonly IMapper mapper;

        public ProductsService(ShopDbContext ctx, IMapper mapper)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }

        public void Create(CreateProductDto model)
        {
            // TODO: validate

            ctx.Products.Add(mapper.Map<Product>(model));
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = ctx.Products.Find(id);
            if (product == null) return;

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
            if (product == null) return null;

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
