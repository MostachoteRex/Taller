using Application.DTOs.Post;
using Infraestructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPostService
    {
        bool Create(CreatePostDTO request);
        bool Delete(string id);
        PostDTO Get(string id);
        List<PostDTO> GetAll();
        bool Update(string id, UpdatePostDTO request);
    }
}
