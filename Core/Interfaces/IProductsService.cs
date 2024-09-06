using Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProductsService
    {
        void Delete(int id);
        void Create(CreateProductDto model);
        void Edit(EditProductDto model);
        ProductDto? Get(int id);
        IEnumerable<ProductDto> GetAll();
    }
}
