using Blog.Business.Concrete;
using Blog.Business.Interfaces;
using Blog.Business.Tools.JWTTool;
using Blog.Business.ValidationRules.FluentValidation;
using Blog.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Blog.DataAccess.Intefaces;
using Blog.DTO.Dtos.AppUserDtos;
using Blog.DTO.Dtos.CategoryBlogDtos;
using Blog.DTO.Dtos.CategoryDtos;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Business.Containers.MicrosoftIoC
{
    public static class CustomIoCExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericDal<>), typeof(EfGenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));

            services.AddScoped<IBlogService, BlogManager>();
            services.AddScoped<IBlogDal, EfBlogRepository>();

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryRepository>();

            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAppUserDal, EfAppUserRepository>();

            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ICommentDal, EfCommentRepository>();

            services.AddScoped<IJWTService, JWTManager>();




            services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginValidator>();
            services.AddTransient<IValidator<CategoryAddDto>, CategoryAddValidator>();
            services.AddTransient<IValidator<CategoryUpdateDto>, CategoryUpdateValidator>();
            services.AddTransient<IValidator<CategoryBlogDto>, CategoryBlogValidator>();


        }
    }
}
