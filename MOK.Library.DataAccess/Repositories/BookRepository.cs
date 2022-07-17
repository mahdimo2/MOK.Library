using MOK.Library.Domain.DataModels;
using MOK.Library.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace MOK.Library.DataAccess.Repositories
{
	public class BookRepository : IBookRepository
	{
		private LibraryDbContext _dbContext;

		public BookRepository(LibraryDbContext dataContext)
		{
			_dbContext = dataContext;
		}

		public void Insert(Book book)
		{
			_dbContext.Books.Add(book);
		}

		public void Update(Book book)
		{
			_dbContext.Books.Update(book);
		}

		public void Delete(Book book)
		{
			_dbContext.Books.Remove(book);
		}

		public int Save()
		{
			return _dbContext.SaveChanges();
		}

		public Book Get(int bookId)
		{
			return _dbContext.Books.Find(bookId);
		}

		public IEnumerable<Book> SearchByTitle(string keyword)
		{
			return _dbContext.Books.Where( s=> s.Title.Contains(keyword));
		}
	}
}
