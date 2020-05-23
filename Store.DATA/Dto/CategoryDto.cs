using System;
using System.Collections.Generic;
using System.Text;

namespace Store.DATA.Dto
{
    public class CategoryDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<ItemDto> Items { get; set; } = new List<ItemDto>();
    }
}
