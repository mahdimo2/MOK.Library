using MOK.Library.Domain.DataModels;
using MOK.Library.Domain.Repositories;
using System.Collections.Generic;

namespace MOK.Library.API.Test
{
	public class BookRepositoryFake : IBookRepository
	{
		List<Book> _repository;

		public BookRepositoryFake()
		{
			_repository = new List<Book>() {
				new Book() { Id = 1, Title = "Unit Test 1", Author = "Author 1" , SubjectId = 1},
				new Book() { Id = 2, Title = "Unit Test 2", Author = "Author 2" , SubjectId = 2},
			};
		}

		public void Delete(Book book)
		{
			_repository.Remove(book);
		}

		public Book Get(int bookId)
		{
			return _repository.Find(S => S.Id == bookId);
		}

		public void Insert(Book book)
		{
			_repository.Add(book);
		}

		public int Save()
		{
			return 1;
		}

		public IEnumerable<Book> SearchByTitle(string keyword)
		{
			return _repository.FindAll( S=> S.Title.Contains(keyword));
		}

		public void Update(Book book)
		{
			_repository.Remove(book);
			_repository.Add(book);
		}
	}
}