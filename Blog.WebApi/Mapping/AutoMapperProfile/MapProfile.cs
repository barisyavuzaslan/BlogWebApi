using AutoMapper;
using Blog.DTO.Dtos.BlogDtos;
using Blog.DTO.Dtos.CategoryDtos;
using Blog.Entities.Concrete;
using Blog.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WebApi.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<BlogListDto, Entities.Concrete.Blog>();
            CreateMap<Entities.Concrete.Blog, BlogListDto>();
            
            CreateMap<BlogAddModel, Entities.Concrete.Blog>();
            CreateMap<Entities.Concrete.Blog, BlogAddModel>();

            CreateMap<BlogUpdateModel, Entities.Concrete.Blog>();
            CreateMap<Entities.Concrete.Blog, BlogUpdateModel>();

            CreateMap<CategoryListDto, Category>();
            CreateMap<Category, CategoryListDto>();

            CreateMap<CategoryAddDto, Category>();
            CreateMap<Category, CategoryAddDto>();

            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<Category, CategoryUpdateDto>();
        }
    }
}
