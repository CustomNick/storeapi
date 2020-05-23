using Microsoft.AspNetCore.Identity;
using Store.DATA.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store.DATA.Converters
{
    public static class RoleConverter
    {
        public static IdentityRole<Guid> Convert(RoleDto item) =>
            new IdentityRole<Guid>
            {
                Id = item.Id,
                Name = item.Name
            };

        public static RoleDto Convert(IdentityRole<Guid> item) =>
            new RoleDto
            {
                Id = item.Id,
                Name = item.Name
            };

        public static List<IdentityRole<Guid>> Convert(List<RoleDto> items) =>
            items.Select(a => Convert(a)).ToList();

        public static List<RoleDto> Convert(List<IdentityRole<Guid>> items) =>
            items.Select(a => Convert(a)).ToList();
    }
}
