using System;
using System.Collections.Generic;
using System.Text;

namespace Store.DATA.Entities
{
    public class Message
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

        public string Name { get; set; }

        public Guid ItemId { get; set; }
    }
}
