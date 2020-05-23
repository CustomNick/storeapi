using Microsoft.AspNetCore.Identity;
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
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _um;

        public UserRepository(UserManager<User> um)
        {
            _um = um;
        }

        public async Task<List<UserDto>> GetAll()
        {
            return UserConverter.Convert(_um.Users.ToList());
        }

        public async Task<UserDto> GetById(Guid id)
        {
            return UserConverter.Convert(await _um.FindByIdAsync(id.ToString()));
        }

        public async Task<UserDto> GetByEmail(string email)
        {
            return UserConverter.Convert(await _um.FindByEmailAsync(email));
        }

        public async Task<List<UserDto>> GetByRole(string name)
        {
            return UserConverter.Convert((await _um.GetUsersInRoleAsync(name)).ToList());
        }

        public async Task<List<string>> GetRolesById(Guid id)
        {
            return (await _um.GetRolesAsync(await _um.FindByIdAsync(id.ToString()))).ToList();
        }

        public async Task<bool> AddUser(UserDto user, string name)
        {
            var u = await _um.FindByNameAsync(user.Email);
            var result = (await _um.AddToRoleAsync(u, name)).Succeeded;
            return result;
        }

        public async Task<bool> DeleteUser(UserDto user, string name)
        {
            return (await _um.RemoveFromRoleAsync(UserConverter.Convert(user), name)).Succeeded;
        }

        public async Task<UserDto> Create(UserDto user)
        {
            var result = await _um.CreateAsync(UserConverter.Convert(user));
            if (result.Succeeded)
            {
                await AddUser(UserConverter.Convert(await _um.FindByEmailAsync(user.Email)), "user");
                return UserConverter.Convert(await _um.FindByEmailAsync(user.Email));
            }
            return null;
        }

        public async Task<bool> Update(UserDto user)
        {
            return (await _um.UpdateAsync(UserConverter.Convert(user))).Succeeded;
        }

        public async Task<bool> Delete(Guid id)
        {
            return (await _um.DeleteAsync(await _um.FindByIdAsync(id.ToString()))).Succeeded;
        }
    }
}
