using Microsoft.AspNetCore.Identity;
using Store.DATA.Converters;
using Store.DATA.Dto;
using Store.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.CORE.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleManager<IdentityRole<Guid>> _rm;

        public RoleRepository(RoleManager<IdentityRole<Guid>> rm)
        {
            _rm = rm;
        }

        public async Task<List<RoleDto>> GetAll()
        {
            return RoleConverter.Convert(_rm.Roles.ToList());
        }

        public async Task<RoleDto> GetById(Guid id)
        {
            return RoleConverter.Convert(await _rm.FindByIdAsync(id.ToString()));
        }

        public async Task<RoleDto> Create(RoleDto role)
        {
            var result = await _rm.CreateAsync(RoleConverter.Convert(role));
            if (result.Succeeded)
                return RoleConverter.Convert(await _rm.FindByNameAsync(role.Name));
            return null;
        }

        public async Task<bool> Update(RoleDto role)
        {
            return (await _rm.UpdateAsync(RoleConverter.Convert(role))).Succeeded;
        }

        public async Task<bool> Delete(Guid id)
        {
            return (await _rm.DeleteAsync(await _rm.FindByIdAsync(id.ToString()))).Succeeded;
        }
    }
}
