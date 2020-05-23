using System;
using System.Collections.Generic;
using System.Text;

namespace Store.DATA.Dto
{
    public class ItemDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public string Image { get; set; }

        public Guid CategoryId { get; set; }

        public CategoryDto Category { get; set; }

        public string CategoryName { get; set; }

        public List<MessageDto> Messages { get; set; }
    }
}
