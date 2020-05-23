using Store.DATA.Dto;
using Store.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DATA.Converters
{
    public static class CategoryConverter
    {
        public static CategoryDto Convert(Category category) =>
            new CategoryDto
            {
                Name = category.Name,
                Id = category.Id
            };

        public static Category Convert(CategoryDto category) =>
            new Category
            {
                Name = category.Name,
                Id = category.Id
            };

        public static List<CategoryDto> Convert(List<Category> categories) =>
            categories.Select(a => Convert(a)).ToList();

        public static List<Category> Convert(List<CategoryDto> categories) =>
            categories.Select(a => Convert(a)).ToList();
    }
}
