using Blog.DataAccess.Intefaces;
using Blog.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Blog.DTO.Dtos.CategoryBlogDtos;
using Blog.Entities.Concrete;

namespace Blog.Business.Concrete
{
    public class BlogManager : GenericManager<Entities.Concrete.Blog>, IBlogService
    {
        private readonly IGenericDal<Entities.Concrete.Blog> _genericDal;
        private readonly IGenericDal<CategoryBlog> _categoryBlogService;
        private readonly IBlogDal _blogDal;
        public BlogManager(IGenericDal<Entities.Concrete.Blog> genericDal, IGenericDal<CategoryBlog> categoryBlogService, IBlogDal blogDal) : base(genericDal)
        {
            _genericDal = genericDal;
            _categoryBlogService = categoryBlogService;
            _blogDal = blogDal;
        }

        public async Task AddToCategoryAsync(CategoryBlogDto categoryBlogDto)
        {
            var control = await _categoryBlogService.GetAsync(I => I.CategoryId == categoryBlogDto.CategoryId && I.BlogId == categoryBlogDto.BlogId);
            if (control != null)
                await _categoryBlogService.AddAsync(new CategoryBlog { BlogId = categoryBlogDto.BlogId, CategoryId = categoryBlogDto.CategoryId });
        }

        public Task<List<Entities.Concrete.Blog>> GetAllByCategoryIdAsync(int categoryId)
        {
            return _blogDal.GetAllByCategoryIdAsync(categoryId);
        }

        public async Task<List<Entities.Concrete.Blog>> GetAllSortedByPostedTimeAsync()
        {
            return await _genericDal.GetAllAsync(I => I.PostedTime);
        }

        public async Task RemoveFromCategoryAsync(CategoryBlogDto categoryBlogDto)
        {
            var deletedCategory = await _categoryBlogService.GetAsync(I => I.CategoryId == categoryBlogDto.CategoryId && I.BlogId == categoryBlogDto.BlogId);
            if (deletedCategory != null)
                await _categoryBlogService.RemoveAsync(deletedCategory);

        }
    }
}
