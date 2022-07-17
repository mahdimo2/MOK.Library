using Microsoft.AspNetCore.Mvc;
using MOK.Library.API.Controllers;
using MOK.Library.Domain.Mappings;
using MOK.Library.Domain.WebApi;
using MOK.Library.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MOK.Library.API.Test
{
	public class SubjectTest
	{
		SubjectService _subjectServiceFake;
		SubjectController _subjectController;

		public SubjectTest()
		{
			_subjectServiceFake = new SubjectService(new SubjectRepositoryFake());
			_subjectController = new SubjectController(null, _subjectServiceFake);
		}

		[Fact]
		public void Insert()
		{
			var subject = new SubjectCrudModel() { Id = 0, Name = "Unit Test" };
			var result = _subjectController.Insert(subject);

			Assert.IsType<OkResult>(result);
		}

		[Fact]
		public void Update()
		{
			var subject = new SubjectCrudModel() { Id = 1, Name = "Unit Test" };
			var result = _subjectController.Update(subject);

			Assert.IsType<OkResult>(result);
		}

		[Fact]
		public void Delete()
		{
			var result = _subjectController.Delete(1);

			Assert.IsType<OkResult>(result);
		}

		[Fact]
		public void Get()
		{
			var result = _subjectController.Get(1);

			Assert.IsType<SubjectFetchModel>(result);
		}

		[Fact]
		public void SearchByName()
		{
			var result = _subjectController.Search("Unit");

			Assert.IsType<List<SubjectFetchModel>>(result);
			Assert.Contains("Unit", result.FirstOrDefault().Name);
		}
	}
}
