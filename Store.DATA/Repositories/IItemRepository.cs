using Store.DATA.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store.DATA.Repositories
{
    public interface IItemRepository
    {
        Task<List<ItemDto>> GetAll();

        Task<ItemDto> GetById(Guid id);

        Task<List<ItemDto>> GetByCategory(Guid id);

        Task<ItemDto> Create(ItemDto item);

        Task<bool> Update(ItemDto item);

        Task<bool> Delete(Guid id);
    }
}
