using MOK.Library.Domain.DataModels;
using System.Collections.Generic;

namespace MOK.Library.Domain.Repositories
{
	public interface ISubjectRepository
	{
		void Insert(Subject subject);

		void Update(Subject subject);

		void Delete(Subject subject);

		int Save();

		Subject Get(int subjectId);

		IEnumerable<Subject> SearchByName(string keyword);
		
	}
}