using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Business.Interfaces;
using Blog.DTO.Dtos.BlogDtos;
using Blog.DTO.Dtos.CategoryBlogDtos;
using Blog.Entities.Concrete;
using Blog.WebApi.CustomFilters;
using Blog.WebApi.Enums;
using Blog.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : BaseController
    {
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;
        public BlogsController(IBlogService blogService, IMapper mapper)
        {
            _blogService = blogService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<List<BlogListDto>>(await _blogService.GetAllSortedByPostedTimeAsync()));
        }
        [HttpGet("{id}")]
        [ServiceFilter(typeof(ValidId<Entities.Concrete.Blog>))]
        public async Task<IActionResult> GetAll(int id)
        {
            return Ok(_mapper.Map<BlogListDto>(await _blogService.FindByIdAsync(id)));
        }

        [HttpPost]
        [Authorize]
        [ValidModel]
        public async Task<IActionResult> Create([FromForm]BlogAddModel blogAddModel)
        {
            var uploadmodel = await UploadFileAsync(blogAddModel.Image, "image/jpeg");

            if (uploadmodel.UploadState == UploadState.Success)
            {
                blogAddModel.ImagePath = uploadmodel.NewName;
                await _blogService.AddAsync(_mapper.Map<Entities.Concrete.Blog>(blogAddModel));
                return Created("", blogAddModel);
            }
            else if (uploadmodel.UploadState == UploadState.NotExist)
            {
                await _blogService.AddAsync(_mapper.Map<Entities.Concrete.Blog>(blogAddModel));
                return Created("", blogAddModel);
            }
            else
            {
                return BadRequest(uploadmodel.ErrorMessage);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        [ValidModel]
        [ServiceFilter(typeof(ValidId<Entities.Concrete.Blog>))]
        public async Task<IActionResult> Update(int id, [FromForm]BlogUpdateModel blogUpdateModel)
        {

            if (id != blogUpdateModel.Id)
                return BadRequest("Geçersiz Id değeri");

            var uploadmodel = await UploadFileAsync(blogUpdateModel.Image, "image/jpeg");
            if (uploadmodel.UploadState == UploadState.Success)
            {
                var updatedblog = await _blogService.FindByIdAsync(blogUpdateModel.Id);
                updatedblog.ShrotDescription = blogUpdateModel.ShrotDescription;
                updatedblog.Description = blogUpdateModel.Description;
                updatedblog.Title = blogUpdateModel.Title;
                updatedblog.AppUserID = blogUpdateModel.AppUserID;
                updatedblog.ImagePath = uploadmodel.NewName;
                await _blogService.UpdateAsync(updatedblog);
                return NoContent();
            }
            else if (uploadmodel.UploadState == UploadState.NotExist)
            {
                var updatedblog = await _blogService.FindByIdAsync(blogUpdateModel.Id);
                updatedblog.ShrotDescription = blogUpdateModel.ShrotDescription;
                updatedblog.Description = blogUpdateModel.Description;
                updatedblog.Title = blogUpdateModel.Title;
                blogUpdateModel.AppUserID = blogUpdateModel.AppUserID;
                await _blogService.UpdateAsync(updatedblog);
                return NoContent();
            }
            else
            {
                return BadRequest(uploadmodel.ErrorMessage);
            }

        }

        [HttpDelete("{id}")]
        [Authorize]
        [ServiceFilter(typeof(ValidId<Entities.Concrete.Blog>))]
        public async Task<IActionResult> Delete(int id)
        {
            await _blogService.RemoveAsync(new Entities.Concrete.Blog { Id = id });
            return NoContent();
        }
        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> AddToCategoryAsync(CategoryBlogDto categoryBlogDto)
        {
            await _blogService.AddToCategoryAsync(categoryBlogDto);
            return Created("", categoryBlogDto);
        }
        [HttpDelete("[action]")]
        [ValidModel]
        public async Task<IActionResult> RemoveFromCategoryAsync(CategoryBlogDto categoryBlogDto)
        {
            await _blogService.RemoveFromCategoryAsync(categoryBlogDto);
            return NoContent();
        }

        [HttpGet("[action]/{id}")]
        [ServiceFilter(typeof(ValidId<Category>))]
        public async Task<IActionResult> GetAllByCategoryId(int id)
        {
            return Ok(await _blogService.GetAllByCategoryIdAsync(id));
        }



    }
}