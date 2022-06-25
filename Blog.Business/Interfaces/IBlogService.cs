using Blog.DTO.Dtos.CategoryBlogDtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Interfaces
{
    public interface IBlogService : IGenericService<Entities.Concrete.Blog>
    {
        Task<List<Entities.Concrete.Blog>> GetAllSortedByPostedTimeAsync();
        Task<List<Blog.Entities.Concrete.Blog>> GetAllByCategoryIdAsync(int categoryId);
        Task AddToCategoryAsync(CategoryBlogDto categoryBlogDto);
        Task RemoveFromCategoryAsync(CategoryBlogDto categoryBlogDto);
    }
}
