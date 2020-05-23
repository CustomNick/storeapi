using Store.CORE.EF;
using Store.DATA.Converters;
using Store.DATA.Dto;
using Store.DATA.Entities;
using Store.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.CORE.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StoreContext _context;

        public CategoryRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryDto>> GetAll()
        {
            return CategoryConverter.Convert(_context.Categories.AsNoTracking().ToList());
        }

        public async Task<CategoryDto> GetById(Guid id)
        {
            return CategoryConverter.Convert(_context.Categories.AsNoTracking().FirstOrDefault(x => x.Id == id));
        }

        public async Task<CategoryDto> Create(CategoryDto item)
        {
            var result = await _context.Categories.AddAsync(CategoryConverter.Convert(item));
            await _context.SaveChangesAsync();
            return CategoryConverter.Convert(result.Entity);
        }

        public async Task<bool> Update(CategoryDto item)
        {
            var category = _context.Categories.First(x => x.Id == item.Id);
            if (category != null)
            {
                category.Name = item.Name;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(Guid id)
        {
            var category = _context.Categories.AsNoTracking().First(x => x.Id == id);
            var items = _context.Items.AsNoTracking().ToList().FindAll(x => x.CategoryId == id);
            if (category != null)
            {
                _context.Items.RemoveRange(items);
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
