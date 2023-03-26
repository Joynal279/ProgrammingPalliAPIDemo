using System;
using EF.Core.Repository.Interface.Manager;
using ProgrammingPalliAPIDemo.Models;

namespace ProgrammingPalliAPIDemo.Interfaces.Manager
{
	public interface IPostManager: ICommonManager<Post>
	{
		Post GetById(int id);
	}
}

