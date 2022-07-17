using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOK.Library.Domain.Mappings;
using MOK.Library.Domain.Services;
using MOK.Library.Domain.WebApi;
using System.Collections.Generic;
using System.Linq;

namespace MOK.Library.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class SubjectController : ControllerBase
	{
		private ISubjectService _subjectService;

		private readonly ILogger<SubjectController> _logger;

		public SubjectController(ILogger<SubjectController> logger, ISubjectService subjectService)
		{
			_logger = logger;
			_subjectService = subjectService;
		}

		[HttpGet("/{id}")]
		public SubjectFetchModel Get(int id)
		{
			return _subjectService.Get(id).ToFetchModel();
		}

		[HttpPost("Insert")]
		public IActionResult Insert(SubjectCrudModel model)
		{
			_subjectService.Insert(model.ToDTO());
			return Ok();
		}

		[HttpPut("Update")]
		public IActionResult Update(SubjectCrudModel model)
		{
			_subjectService.Update(model.ToDTO());
			return Ok();
		}

		[HttpDelete("Delete/{id}")]
		public IActionResult Delete(int id)
		{
			var model = _subjectService.Get(id);
			_subjectService.Update(model);
			return Ok();
		}

		[HttpPost("Search/keyword")]
		public List<SubjectFetchModel> Search(string keywork)
		{
			return _subjectService.SearchByName(keywork).ToFetchModel().ToList();
		}
	}
}
