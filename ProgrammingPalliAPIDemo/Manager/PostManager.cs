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
	}
}

