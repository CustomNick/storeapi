using Store.DATA.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store.DATA.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<CategoryDto>> GetAll();

        Task<CategoryDto> GetById(Guid id);

        Task<CategoryDto> Create(CategoryDto item);

        Task<bool> Update(CategoryDto item);

        Task<bool> Delete(Guid id);
    }
}
