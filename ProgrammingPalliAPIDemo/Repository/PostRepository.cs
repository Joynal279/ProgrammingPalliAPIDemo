using System;
using EF.Core.Repository.Repository;
using ProgrammingPalliAPIDemo.Data;
using ProgrammingPalliAPIDemo.Interfaces.Repository;
using ProgrammingPalliAPIDemo.Models;

namespace ProgrammingPalliAPIDemo.Repository
{
	public class PostRepository: CommonRepository<Post>, IPostRepository
	{
		public PostRepository(ApplicationDbContext dbContext): base(dbContext)
		{
		}
	}
}

