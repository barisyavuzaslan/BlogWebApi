using Blog.DataAccess.Intefaces;
using Blog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
   public class EfCommentRepository:EfGenericRepository<Comment>,ICommentDal
    {
    }
}
