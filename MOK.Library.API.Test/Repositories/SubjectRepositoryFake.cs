using MOK.Library.Domain.DataModels;
using MOK.Library.Domain.Repositories;
using System.Collections.Generic;

namespace MOK.Library.API.Test
{
	public class SubjectRepositoryFake : ISubjectRepository
	{
		List<Subject> _repository;

		public SubjectRepositoryFake()
		{
			_repository = new List<Subject>() {
				new Subject() { Id = 1, Name = "Unit Test 1"},
				new Subject() { Id = 2, Name = "Unit Test 2"},
			};
		}

		public void Delete(Subject subject)
		{
			_repository.Remove(subject);
		}

		public Subject Get(int subjectId)
		{
			return _repository.Find(S => S.Id == subjectId);
		}

		public void Insert(Subject subject)
		{
			_repository.Add(subject);
		}

		public int Save()
		{
			return 1;
		}

		public IEnumerable<Subject> SearchByName(string keyword)
		{
			return _repository.FindAll( S=> S.Name.Contains(keyword));
		}

		public void Update(Subject subject)
		{
			_repository.Remove(subject);
			_repository.Add(subject);
		}
	}
}