using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MOK.Framework;
using MOK.Library.DataAccess.Repositories;
using MOK.Library.Domain;
using MOK.Library.Domain.Repositories;

namespace MOK.Library.DataAccess
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
			_serviceCollection.AddSingleton<Domain.DataAccess.IInitializer, Initializer>();
			_serviceCollection.AddDbContext<LibraryDbContext>();
			_serviceCollection.AddScoped<IBookRepository, BookRepository>();
			_serviceCollection.AddScoped<ISubjectRepository, SubjectRepository>();
		}
	}
}