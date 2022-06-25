using Blog.DataAccess.Concrete.EntityFrameworkCore.Context;
using Blog.DataAccess.Intefaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfBlogRepository : EfGenericRepository<Entities.Concrete.Blog>, IBlogDal
    {
        public async Task<List<Entities.Concrete.Blog>> GetAllByCategoryIdAsync(int categoryId)
        {
            using var context = new BlogContext();

            return await context.Blogs.Join(context.CategoryBlogs, b => b.Id, c => c.BlogId, (blog, categoryBlog) => new
            {
                blog = blog,
                categoryBlog = categoryBlog

            }).Where(I => I.categoryBlog.CategoryId == categoryId).Select(I => new Entities.Concrete.Blog
            {
                AppUser = I.blog.AppUser,
                AppUserID = I.blog.AppUserID,
                CategoryBlogs = I.blog.CategoryBlogs,
                Comments = I.blog.Comments,
                Description = I.blog.Description,
                Id = I.blog.Id,
                ImagePath = I.blog.ImagePath,
                PostedTime = I.blog.PostedTime,
                ShrotDescription = I.blog.ShrotDescription,
                Title = I.blog.Title

            }).ToListAsync();

             
        }
    }
}
