using Store.CORE.EF;
using Store.DATA.Converters;
using Store.DATA.Dto;
using Store.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.CORE.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly StoreContext _context;

        public ItemRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<List<ItemDto>> GetAll()
        {
            var items = ItemConverter.Convert(_context.Items.AsNoTracking().ToList());
            foreach (var item in items)
            {
                var category = CategoryConverter.Convert(_context.Categories.AsNoTracking().First(x => x.Id == item.CategoryId));
                item.Category = category;
                item.CategoryName = category.Name;
            }
            return items;
        }

        public async Task<ItemDto> GetById(Guid id)
        {
            var item = ItemConverter.Convert(_context.Items.AsNoTracking().First(x => x.Id == id));
            var category = CategoryConverter.Convert(_context.Categories.AsNoTracking().First(x => x.Id == item.CategoryId));
            item.Category = category;
            item.CategoryName = category.Name;
            return item;
        }

        public async Task<List<ItemDto>> GetByCategory(Guid id)
        {
            var category = CategoryConverter.Convert(_context.Categories.AsNoTracking().FirstOrDefault(x => x.Id == id));
            var items = ItemConverter.Convert(_context.Items.AsNoTracking().ToList().FindAll(x => x.CategoryId == id));
            foreach (var item in items)
            {
                item.Category = category;
                item.CategoryName = category.Name;
            }
            return items;
        }

        public async Task<ItemDto> Create(ItemDto item)
        {
            var category = _context.Categories.First(x => x.Id == item.CategoryId);
            item.Category = CategoryConverter.Convert(category);
            item.CategoryName = category.Name;
            var result = _context.Items.Add(ItemConverter.Convert(item));
            category.Items.Add(result.Entity);
            await _context.SaveChangesAsync();
            item.Id = result.Entity.Id;
            return item;
        }

        public async Task<bool> Update(ItemDto item)
        {
            var i = _context.Items.First(x => x.Id == item.Id);
            if (i != null)
            {
                i.Name = item.Name;
                i.Description = item.Description;
                i.Price = item.Price;
                i.Image = item.Image;
                i.CategoryId = item.CategoryId;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(Guid id)
        {
            var item = _context.Items.AsNoTracking().First(x => x.Id == id);
            if (item != null)
            {
                _context.Categories.FirstOrDefault(x => x.Id == item.CategoryId).Items.Remove(item);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
