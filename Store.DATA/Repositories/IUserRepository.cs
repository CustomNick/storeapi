using Store.DATA.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store.DATA.Repositories
{
    public interface IUserRepository
    {
        Task<List<UserDto>> GetAll();

        Task<UserDto> GetById(Guid id);

        Task<UserDto> GetByEmail(string email);

        Task<List<UserDto>> GetByRole(string name);

        Task<List<string>> GetRolesById(Guid id);

        Task<bool> AddUser(UserDto user, string name);

        Task<bool> DeleteUser(UserDto user, string name);

        Task<UserDto> Create(UserDto item);

        Task<bool> Update(UserDto item);

        Task<bool> Delete(Guid id);
    }
}
