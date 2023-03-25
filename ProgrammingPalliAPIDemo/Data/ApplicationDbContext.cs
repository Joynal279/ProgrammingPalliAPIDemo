using System;
using Microsoft.EntityFrameworkCore;
using ProgrammingPalliAPIDemo.Models;

namespace ProgrammingPalliAPIDemo.Data
{
	public class ApplicationDbContext: DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
		{
		}

		public DbSet<Post> posts { get; set; }
	}
}

