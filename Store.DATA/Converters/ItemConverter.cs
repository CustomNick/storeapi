using Store.DATA.Dto;
using Store.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store.DATA.Converters
{
    public static class ItemConverter
    {
        public static ItemDto Convert(Item item) =>
            new ItemDto
            {
                Name = item.Name,
                Id = item.Id,
                Description = item.Description,
                Price = item.Price,
                Image = item.Image,
                CategoryId = item.CategoryId
            };

        public static Item Convert(ItemDto item) =>
            new Item
            {
                Name = item.Name,
                Id = item.Id,
                Description = item.Description,
                Price = item.Price,
                Image = item.Image,
                CategoryId = item.CategoryId
            };

        public static List<ItemDto> Convert(List<Item> items) =>
            items.Select(a => Convert(a)).ToList();

        public static List<Item> Convert(List<ItemDto> items) =>
            items.Select(a => Convert(a)).ToList();
    }
}
