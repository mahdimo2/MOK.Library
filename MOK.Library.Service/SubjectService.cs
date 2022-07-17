using MOK.Library.Domain;
using MOK.Library.Domain.DTO;
using MOK.Library.Domain.Mappings;
using MOK.Library.Domain.Repositories;
using MOK.Library.Domain.Services;
using System.Collections.Generic;

namespace MOK.Library.Service
{
	public class SubjectService : ISubjectService
	{
		ISubjectRepository _repository;

		public SubjectService(ISubjectRepository subjectRepository)
		{
			_repository = subjectRepository;
		}

		public void Delete(Subject subject)
		{
			_repository.Delete(subject.ToModel());
			_repository.Save();
		}

		public Subject Get(int subjectId)
		{
			return _repository.Get(subjectId).ToDTO();
		}

		public void Insert(Subject subject)
		{
			if (!Validate(subject))
				return;

			_repository.Insert(subject.ToModel());
			_repository.Save();
		}

		public IEnumerable<Subject> SearchByName(string keyword)
		{
			return _repository.SearchByName(keyword).ToDTO();
		}

		public void Update(Subject subject)
		{
			if (!Validate(subject))
				return;

			_repository.Update(subject.ToModel());
			_repository.Save();
		}

		private bool Validate(Subject subject)
		{
			var errors = new List<string>();

			if (subject == null)
				errors.Add("Subject is Null");
			else
			{
				if (string.IsNullOrEmpty(subject.Name))
					errors.Add("Name is empty");
				if (subject.Id < 0)
					errors.Add("Id is invalid");
			}

			if (errors.Count > 0)
				throw new ValidationException(errors);
			
			return true;
		}
	}
}