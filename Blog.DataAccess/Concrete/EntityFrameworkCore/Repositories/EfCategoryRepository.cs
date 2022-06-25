using Blog.DataAccess.Concrete.EntityFrameworkCore.Context;
using Blog.DataAccess.Intefaces;
using Blog.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfCategoryRepository : EfGenericRepository<Category>, ICategoryDal
    {
        public async Task<List<Category>> GetAllWithBlogsAsync()
        {
            using var context = new BlogContext();
            return await context.Categories.Include(I => I.CategoryBlogs).OrderByDescending(I => I.Id).ToListAsync();
        }
    }
}
