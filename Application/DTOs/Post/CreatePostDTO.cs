﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Post
{
    public class CreatePostDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
    }
}
