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
    public class MessageRepository : IMessageRepository
    {
        private readonly StoreContext _context;

        public MessageRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<List<MessageDto>> GetByItem(Guid id)
        {
            var messages = _context.Messages.AsNoTracking().ToList().FindAll(x => x.ItemId == id);
            return MessageConverter.Convert(messages);
        }

        public async Task<MessageDto> Send(MessageDto message)
        {
            var result = _context.Messages.Add(MessageConverter.Convert(message));
            var item = _context.Items.First(x => x.Id == message.ItemId);
            item.Messages.Add(result.Entity);
            await _context.SaveChangesAsync();
            return MessageConverter.Convert(result.Entity);
        }

        public async Task<bool> Delete(Guid id)
        {
            var message = _context.Messages.AsNoTracking().First(x => x.Id == id);
            if (message != null)
            {
                _context.Messages.Remove(message);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
