using Store.DATA.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store.DATA.Repositories
{
    public interface IRoleRepository
    {
        Task<List<RoleDto>> GetAll();

        Task<RoleDto> GetById(Guid id);

        Task<RoleDto> Create(RoleDto item);

        Task<bool> Update(RoleDto item);

        Task<bool> Delete(Guid id);
    }
}
