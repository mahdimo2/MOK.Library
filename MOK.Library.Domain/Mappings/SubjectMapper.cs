using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace MOK.Library.Domain.Mappings
{
	public static class SubjectMapper
	{
		private static IMapper _mapper;

		static SubjectMapper()
		{
			MapperConfiguration config = new MapperConfiguration(conf =>
			{
				conf.CreateMap<DataModels.Subject, DTO.Subject>();
				conf.CreateMap<DTO.Subject, DataModels.Subject>();

				conf.CreateMap<WebApi.SubjectCrudModel, DTO.Subject>();
				conf.CreateMap<WebApi.SubjectFetchModel, DTO.Subject>();
				conf.CreateMap<DTO.Subject, WebApi.SubjectFetchModel>();
				conf.CreateMap<DTO.Subject, WebApi.SubjectCrudModel>();
			});
			_mapper = config.CreateMapper();
		}

		public static DTO.Subject ToDTO(this DataModels.Subject item)
		{
			return _mapper.Map<DTO.Subject>(item);
		}

		public static IEnumerable<DTO.Subject> ToDTO(this IEnumerable<DataModels.Subject> items)
		{
			return items.Select(u => u.ToDTO());
		}

		public static DataModels.Subject ToModel(this DTO.Subject item)
		{
			return _mapper.Map<DataModels.Subject>(item);
		}

		public static IEnumerable<DataModels.Subject> ToModel(this IEnumerable<DTO.Subject> item)
		{
			return item.Select(u => u.ToModel());
		}

		public static WebApi.SubjectFetchModel ToFetchModel(this DTO.Subject item)
		{
			return _mapper.Map<WebApi.SubjectFetchModel>(item);
		}

		public static IEnumerable<WebApi.SubjectFetchModel> ToFetchModel(this IEnumerable<DTO.Subject> item)
		{
			return item.Select(u => u.ToFetchModel());
		}

		public static DTO.Subject ToDTO(this WebApi.SubjectFetchModel item)
		{
			return _mapper.Map<DTO.Subject>(item);
		}

		public static IEnumerable<DTO.Subject> ToDTO(this IEnumerable<WebApi.SubjectFetchModel> items)
		{
			return items.Select(u => u.ToDTO());
		}

		//public static WebApi.SubjectFetchModel ToCrudModel(this DTO.Subject item)
		//{
		//	return _mapper.Map<WebApi.SubjectFetchModel>(item);
		//}

		//public static IEnumerable<WebApi.SubjectFetchModel> ToFetchModel(this IEnumerable<DTO.Subject> item)
		//{
		//	return item.Select(u => u.ToFetchModel());
		//}

		public static DTO.Subject ToDTO(this WebApi.SubjectCrudModel item)
		{
			return _mapper.Map<DTO.Subject>(item);
		}

		public static IEnumerable<DTO.Subject> ToDTO(this IEnumerable<WebApi.SubjectCrudModel> items)
		{
			return items.Select(u => u.ToDTO());
		}
	}
}
