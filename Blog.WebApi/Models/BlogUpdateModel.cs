﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WebApi.Models
{
    public class BlogUpdateModel
    {
        public int Id { get; set; }
        public int AppUserID { get; set; }
        public string Title { get; set; }
        public string ShrotDescription { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public IFormFile Image { get; set; }
    }
}
