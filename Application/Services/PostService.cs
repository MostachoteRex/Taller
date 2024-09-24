using Application.DTOs.Post;
using Application.Interfaces;
using Infraestructure.Data.Models;
using Infraestructure.Data.Repositories.Interfaces;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PostService : IPostService
    {
        private readonly IRepository<Post> _repository;
        public PostService(IRepository<Post> repository)
        {
            _repository = repository;
        }
        public bool Create(CreatePostDTO request)
        {
            Post newPost = new Post
            {
                Id = ObjectId.GenerateNewId(),
                Title = request.Title,
                Content = request.Content,
                ImageUrl = request.ImageUrl,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                AuthorId = 0
            };

            _repository.AddAsync(newPost).Wait();
            return true;
        }
        public List<PostDTO> GetAll()
        {
            var data = _repository.GetAllAsync().Result;

            var response = new List<PostDTO>();


            foreach (var item in data)
            {
                response.Add(new PostDTO
                {
                    Id = item.Id.ToString(),
                    Title = item.Title,
                    Content = item.Content,
                    ImageUrl = item.ImageUrl,
                    CreatedAt = item.CreatedAt,
                    UpdatedAt = item.UpdatedAt,
                    AuthorId = item.AuthorId,
                });
            }

            return response;
        }
        public PostDTO? Get(string id)
        {
            var data = _repository.GetByIdAsync(id).Result;

            if (data is null)
                return null;

            var response = new PostDTO
            {
                Id = data.Id.ToString(),
                Title = data.Title,
                Content = data.Content,
                ImageUrl = data.ImageUrl,
                CreatedAt = data.UpdatedAt,
                UpdatedAt = data.UpdatedAt,
                AuthorId = data.AuthorId,
            };

            return response;
        }        
        public bool Delete(string id)
        {
            var data = _repository.GetByIdAsync(id).Result;

            if (data is null)
                return false;

            _repository.DeleteAsync(id).Wait();
            return true;
        }
        public bool Update(string id, UpdatePostDTO request)
        {

            var data = _repository.GetByIdAsync(id).Result;

            if (data is null) 
                return false;

            data.Title = request.Title;
            data.Content = request.Content;
            data.ImageUrl = request.ImageUrl;
            data.UpdatedAt = DateTime.Now;

            _repository.UpdateAsync(id, data).Wait();

            return true;
        }
    }
}
