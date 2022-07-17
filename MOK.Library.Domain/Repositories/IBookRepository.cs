using MOK.Library.Domain.DataModels;
using System.Collections.Generic;

namespace MOK.Library.Domain.Repositories
{
	public interface IBookRepository
	{
		void Insert(Book book);

		void Update(Book book);

		void Delete(Book book);

		int Save();

		Book Get(int bookId);

		IEnumerable<Book> SearchByTitle(string keyword);
		
	}
}