using Microsoft.Extensions.DependencyInjection;
using MOK.Framework;
using MOK.Library.Domain.Services;

namespace MOK.Library.Service
{
	public class DependencyRegistrar : IDependencyRegistrar
	{
		private IServiceCollection _serviceCollection;

		public DependencyRegistrar(IServiceCollection serviceCollection)
		{
			_serviceCollection = serviceCollection;
		}

		public void Register()
		{
			_serviceCollection.AddScoped<ISubjectService, SubjectService>();
			_serviceCollection.AddScoped<IBookService, BookService>();
		}
	}
}