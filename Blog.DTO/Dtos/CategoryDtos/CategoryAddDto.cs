using Blog.DTO.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.DTO.Dtos.CategoryDtos
{
    public class CategoryAddDto : IDto
    {
        public string Name { get; set; }
    }
}
