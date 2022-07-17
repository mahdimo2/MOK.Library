using MOK.Library.Domain.DataModels;
using MOK.Library.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace MOK.Library.DataAccess.Repositories
{
	public class SubjectRepository : ISubjectRepository
	{
		private LibraryDbContext _dbContext;

		public SubjectRepository(LibraryDbContext dataContext)
		{
			_dbContext = dataContext;
		}

		public void Insert(Subject subject)
		{
			_dbContext.Subjects.Add(subject);
		}

		public void Update(Subject subject)
		{
			_dbContext.Subjects.Update(subject);
		}

		public void Delete(Subject subject)
		{
			_dbContext.Subjects.Remove(subject);
		}

		public int Save()
		{
			return _dbContext.SaveChanges();
		}

		public Subject Get(int subjectId)
		{
			return _dbContext.Subjects.Find(subjectId);
		}

		public IEnumerable<Subject> SearchByName(string keyword)
		{
			return _dbContext.Subjects.Where( s=> s.Name.Contains(keyword));
		}
	}
}
