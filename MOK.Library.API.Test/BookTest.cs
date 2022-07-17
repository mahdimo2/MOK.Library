using Microsoft.AspNetCore.Mvc;
using MOK.Library.API.Controllers;
using MOK.Library.Domain;
using MOK.Library.Domain.Mappings;
using MOK.Library.Domain.WebApi;
using MOK.Library.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MOK.Library.API.Test
{
	public class BookTest
	{
		BookService _ServiceFake;
		BookController _Controller;

		public BookTest()
		{
			_ServiceFake = new BookService(new BookRepositoryFake());
			_Controller = new BookController(null, _ServiceFake);
		}

		[Fact]
		public void Insert()
		{
			var book = new BookCrudModel() { Id = 0, Title = "Unit Test", Author = "Author", SubjectId = 1 };
			var result = _Controller.Insert(book);

			Assert.IsType<OkResult>(result);
		}

		[Fact]
		public void Update()
		{
			var subject = new BookCrudModel() { Id = 1, Title = "Unit Test", Author = "Author", SubjectId = 1 };
			var result = _Controller.Update(subject);

			Assert.IsType<OkResult>(result);
		}

		[Fact]
		public void Delete()
		{
			var result = _Controller.Delete(1);

			Assert.IsType<OkResult>(result);
		}

		[Fact]
		public void Get()
		{
			var result = _Controller.Get(1);

			Assert.IsType<BookFetchModel>(result);
		}

		[Fact]
		public void SearchByName()
		{
			var result = _Controller.Search("Unit");

			Assert.IsType<List<BookFetchModel>>(result);
			Assert.Contains("Unit", result.FirstOrDefault().Title);
		}
	}
}
