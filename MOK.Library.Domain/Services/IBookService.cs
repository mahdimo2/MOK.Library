using MOK.Library.Domain.DTO;
using System.Collections.Generic;

namespace MOK.Library.Domain.Services
{
	public interface IBookService
	{
		void Insert(Book subject);
		void Update(Book subject);
		void Delete(Book subject);
		Book Get(int bookId);
		IEnumerable<Book> SearchByTitle(string keyword);
	}
}
