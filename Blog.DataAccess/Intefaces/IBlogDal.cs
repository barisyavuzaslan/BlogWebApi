using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DataAccess.Intefaces
{
    public interface IBlogDal : IGenericDal<Blog.Entities.Concrete.Blog>
    {
        Task<List<Blog.Entities.Concrete.Blog>> GetAllByCategoryIdAsync(int categoryId);
    }
}
