using System;
using System.Collections.Generic;
using System.Text;

namespace Store.DATA.Entities
{
    public class Item
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public string Image { get; set; }

        public Guid CategoryId { get; set; }

        public List<Message> Messages { get; set; }
    }
}
