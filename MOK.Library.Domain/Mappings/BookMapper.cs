using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace MOK.Library.Domain.Mappings
{
	public static class BookMapper
	{
		private static IMapper _mapper;

		static BookMapper()
		{
			MapperConfiguration config = new MapperConfiguration(conf =>
			{
				conf.CreateMap<DataModels.Book, DTO.Book>();
				conf.CreateMap<DTO.Book, DataModels.Book>();

				conf.CreateMap<WebApi.BookCrudModel, DTO.Book>();
				conf.CreateMap<WebApi.BookFetchModel, DTO.Book>();
				conf.CreateMap<DTO.Book, WebApi.BookCrudModel>();
				conf.CreateMap<DTO.Book, WebApi.BookFetchModel>();
			});
			_mapper = config.CreateMapper();
		}

		public static DTO.Book ToDTO(this DataModels.Book item)
		{
			return _mapper.Map<DTO.Book>(item);
		}

		public static IEnumerable<DTO.Book> ToDTO(this IEnumerable<DataModels.Book> items)
		{
			return items.Select(u => u.ToDTO());
		}

		public static DataModels.Book ToModel(this DTO.Book item)
		{
			return _mapper.Map<DataModels.Book>(item);
		}

		public static IEnumerable<DataModels.Book> ToModel(this IEnumerable<DTO.Book> item)
		{
			return item.Select(u => u.ToModel());
		}

		public static WebApi.BookFetchModel ToFetchModel(this DTO.Book item)
		{
			return _mapper.Map<WebApi.BookFetchModel>(item);
		}

		public static IEnumerable<WebApi.BookFetchModel> ToFetchModel(this IEnumerable<DTO.Book> item)
		{
			return item.Select(u => u.ToFetchModel());
		}

		public static DTO.Book ToDTO(this WebApi.BookFetchModel item)
		{
			return _mapper.Map<DTO.Book>(item);
		}

		public static IEnumerable<DTO.Book> ToDTO(this IEnumerable<WebApi.BookFetchModel> items)
		{
			return items.Select(u => u.ToDTO());
		}


		public static DTO.Book ToDTO(this WebApi.BookCrudModel item)
		{
			return _mapper.Map<DTO.Book>(item);
		}

		public static IEnumerable<DTO.Book> ToDTO(this IEnumerable<WebApi.BookCrudModel> items)
		{
			return items.Select(u => u.ToDTO());
		}
	}
}
