using MOK.Library.Domain;
using MOK.Library.Domain.DTO;
using MOK.Library.Domain.Mappings;
using MOK.Library.Domain.Repositories;
using MOK.Library.Domain.Services;
using System.Collections.Generic;

namespace MOK.Library.Service
{
	public class BookService : IBookService
	{
		IBookRepository _repository;

		public BookService(IBookRepository subjectRepository)
		{
			_repository = subjectRepository;
		}

		public void Delete(Book book)
		{
			_repository.Delete(book.ToModel());
			_repository.Save();
		}

		public Book Get(int bookId)
		{
			return _repository.Get(bookId).ToDTO();
		}

		public void Insert(Book book)
		{
			if (!Validate(book))
				return;

			_repository.Insert(book.ToModel());
			_repository.Save();
		}

		public IEnumerable<Book> SearchByTitle(string keyword)
		{
			return _repository.SearchByTitle(keyword).ToDTO();
		}

		public void Update(Book book)
		{
			if (!Validate(book))
				return;

			_repository.Update(book.ToModel());
			_repository.Save();
		}

		private bool Validate(Book book)
		{
			var errors = new List<string>();

			if (book == null)
				errors.Add("Book is Null");
			else
			{
				if (string.IsNullOrEmpty(book.Title))
					errors.Add("Name is empty");
				if (string.IsNullOrEmpty(book.Author))
					errors.Add("Author is empty");
				if (book.Id < 0)
					errors.Add("Id is invalid");
				if (book.SubjectId <= 0)
					errors.Add("SubjectId is invalid");
			}

			if (errors.Count > 0)
				throw new ValidationException(errors);

			return true;
		}
	}
}