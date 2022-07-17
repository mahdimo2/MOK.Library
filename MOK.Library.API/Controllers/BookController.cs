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
	public class BookController : ControllerBase
	{
		private IBookService _bookService;

		private readonly ILogger<BookController> _logger;

		public BookController(ILogger<BookController> logger, IBookService bookService)
		{
			_logger = logger;
			_bookService = bookService;
		}

		[HttpGet("Get/{id}")]
		public BookFetchModel Get(int id)
		{
			return _bookService.Get(id).ToFetchModel();
		}

		[HttpPost("Insert")]
		public IActionResult Insert(BookCrudModel model)
		{
			_bookService.Insert(model.ToDTO());
			return Ok();
		}

		[HttpPut("Update")]
		public IActionResult Update(BookCrudModel model)
		{
			_bookService.Update(model.ToDTO());
			return Ok();
		}

		[HttpDelete("Delete/{id}")]
		public IActionResult Delete(int id)
		{
			var model = _bookService.Get(id);
			_bookService.Update(model);
			return Ok();
		}

		[HttpPost("Search/keyword")]
		public List<BookFetchModel> Search(string keywork)
		{
			return _bookService.SearchByTitle(keywork).ToFetchModel().ToList();
		}
	}
}
