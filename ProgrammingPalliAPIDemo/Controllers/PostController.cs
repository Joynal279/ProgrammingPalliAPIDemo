using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgrammingPalliAPIDemo.Data;
using ProgrammingPalliAPIDemo.Models;
using ProgrammingPalliAPIDemo.Manager;
using ProgrammingPalliAPIDemo.Interfaces.Manager;

namespace ProgrammingPalliAPIDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        //ApplicationDbContext _dbContext;
        //PostManager _postManager;

        IPostManager _postManager;

        //public PostController(ApplicationDbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //    _postManager = new PostManager(dbContext);
        //}

        public PostController(IPostManager postManager)
        {
            _postManager = postManager;
        }

        [HttpGet]
        public List<Post> GetAll()
        {
            //var posts = _dbContext.posts.ToList();
            var posts = _postManager.GetAll().ToList(); 
            return posts;
        }

        [HttpGet("id")]
        public Post GetById(int id)
        {
            var post = _postManager.GetById(id: id);
            return post;
        }

        [HttpPost]
        public Post Add(Post post)
        {
            post.CreatedDate = DateTime.Now;
            //_dbContext.posts.Add(post);
            //bool isSaved = _dbContext.SaveChanges() > 0;

            bool isSaved = _postManager.Add(post);

            if (isSaved)
            {
                return post;
            }
            return null;
        }

    }
}
