using Blog.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.DTO.Dtos.CategoryDtos
{
    public class CategoryListDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
