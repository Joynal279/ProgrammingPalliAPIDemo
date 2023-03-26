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
using CoreApiResponse;
using System.Net;

namespace ProgrammingPalliAPIDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostController : BaseController
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
                var posts = _postManager.GetAll().OrderByDescending(u=>u.CreatedDate).ThenByDescending(u=>u.Title).ToList(); //for accending use:  OrderBy(u=>u.CreatedDate)
                return CustomResult("Data loaded successfully", posts, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("title")]
        public IActionResult GetAll(string title)
        {
            try
            {
                var posts = _postManager.GetAll(title);
                return CustomResult("Data loaded done", posts.ToList(), HttpStatusCode.OK);
            }catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
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
                    return CustomResult("Data not found", HttpStatusCode.NotFound);
                }
                return CustomResult("Data found", post, HttpStatusCode.OK);
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
                    //return Created("", post);
                    return CustomResult("Post has been created", post, HttpStatusCode.OK);
                }
                return CustomResult("Post save failed", post, HttpStatusCode.BadRequest);
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
                    return CustomResult("Id is missing", post, HttpStatusCode.BadRequest);
                }
                bool update = _postManager.Update(post);
                if (update)
                {
                    return CustomResult("successfully edited", post, HttpStatusCode.OK);
                }
                return CustomResult("Edit failed", post, HttpStatusCode.BadRequest);
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
                    return CustomResult("data not found", HttpStatusCode.NotFound);
                }
                bool isDelete = _postManager.Delete(post);
                if (isDelete)
                {
                    return CustomResult("Post has been deleted", HttpStatusCode.OK);
                }
                return CustomResult("delete failed", HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

    }
}
