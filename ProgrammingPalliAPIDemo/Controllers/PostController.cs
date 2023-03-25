using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgrammingPalliAPIDemo.Data;
using ProgrammingPalliAPIDemo.Models;

namespace ProgrammingPalliAPIDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        ApplicationDbContext _dbContext;
        public PostController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public List<Post> GetAll()
        {
            var posts = _dbContext.posts.ToList();
            return posts;
        }

        [HttpPost]
        public Post Add(Post post)
        {
            post.CreatedDate = DateTime.Now;
            _dbContext.posts.Add(post);
            bool isSaved = _dbContext.SaveChanges() > 0;
            if (isSaved)
            {
                return post;
            }
            return null;
        }

    }
}
