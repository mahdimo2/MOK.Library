using MOK.Library.Domain.DTO;
using System.Collections.Generic;

namespace MOK.Library.Domain.Services
{
	public interface ISubjectService
	{
		void Insert(Subject subject);
		void Update(Subject subject);
		void Delete(Subject subject);
		Subject Get(int subjectId);
		IEnumerable<Subject> SearchByName(string keyword);
	}
}
