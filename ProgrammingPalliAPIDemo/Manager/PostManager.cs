using System;
using EF.Core.Repository.Manager;
using ProgrammingPalliAPIDemo.Data;
using ProgrammingPalliAPIDemo.Interfaces.Manager;
using ProgrammingPalliAPIDemo.Models;
using ProgrammingPalliAPIDemo.Repository;

namespace ProgrammingPalliAPIDemo.Manager
{
	public class PostManager: CommonManager<Post>, IPostManager
	{
		public PostManager(ApplicationDbContext _dbContext): base(new PostRepository(_dbContext))
		{
		}

        public ICollection<Post> GetAll(string title)
        {
            return Get(u => u.Title.ToLower() == title.ToLower());
        }

        public Post GetById(int id)
        {
            return GetFirstOrDefault(u => u.Id == id);
        }

        public ICollection<Post> SearchPost(string text)
        {
            return Get(u => u.Title.ToLower().Contains(text.ToLower()) || u.Description.ToLower().Contains(text.ToLower()));
        }
    }
}

