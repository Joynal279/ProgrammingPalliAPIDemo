using System;
using EF.Core.Repository.Interface.Manager;
using ProgrammingPalliAPIDemo.Models;

namespace ProgrammingPalliAPIDemo.Interfaces.Manager
{
	public interface IPostManager: ICommonManager<Post>
	{
		Post GetById(int id);
		ICollection<Post> GetAll(string title);
		ICollection<Post> SearchPost(string text);

		ICollection<Post> GetPosts(int page, int pageSize);
	}
}

