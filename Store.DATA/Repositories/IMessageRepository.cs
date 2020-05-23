using Store.DATA.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store.DATA.Repositories
{
    public interface IMessageRepository
    {
        Task<List<MessageDto>> GetByItem(Guid id);

        Task<MessageDto> Send(MessageDto message);

        Task<bool> Delete(Guid id);
    }
}
