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
        public IActionResult GetAll()
        {
            try
            {
                //var posts = _dbContext.posts.ToList();
                var posts = _postManager.GetAll().ToList();
                return Ok(posts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            try
            {
                var post = _postManager.GetById(id: id);
                if (post == null)
                {
                    return NotFound();
                }
                return Ok(post);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost]
        public IActionResult Add(Post post)
        {
            try
            {
                post.CreatedDate = DateTime.Now;
                //_dbContext.posts.Add(post);
                //bool isSaved = _dbContext.SaveChanges() > 0;

                bool isSaved = _postManager.Add(post);

                if (isSaved)
                {
                    return Created("", post);
                }
                return BadRequest("Post save failed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut]
        public IActionResult Edit(Post post)
        {
            try
            {
                if (post.Id == 0)
                {
                    return BadRequest("Id is missing.");
                }
                bool update = _postManager.Update(post);
                if (update)
                {
                    return Ok(post);
                }
                return BadRequest("Post updated failed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var post = _postManager.GetById(id);
                if (post == null)
                {
                    return NotFound();
                }
                bool isDelete = _postManager.Delete(post);
                if (isDelete)
                {
                    return Ok("Post has been deleted");
                }
                return BadRequest("Post failed been deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

    }
}
