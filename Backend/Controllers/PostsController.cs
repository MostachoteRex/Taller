using Amazon.Runtime.Internal;
using Application.DTOs.Post;
using Application.Interfaces;
using Infraestructure.Data.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var response = _postService.GetAll();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var response = _postService.Get(id);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreatePostDTO request)
        {
            var response = _postService.Create(request);
            return response ? Ok(response) : BadRequest(response);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var response = _postService.Delete(id);
            return Ok(response);
        }
    }
}
