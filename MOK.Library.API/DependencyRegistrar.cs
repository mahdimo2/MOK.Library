using Microsoft.Extensions.DependencyInjection;
using MOK.Framework;
using MOK.Library.Domain;
using MOK.Library.Domain.Settings;
using MOK.Library.WebAPI.Settings;

namespace MOK.Library.WebAPI
{
	public class DependencyRegistrar : IDependencyRegistrar
	{
		private readonly IServiceCollection _serviceCollection;

		public DependencyRegistrar(IServiceCollection serviceCollection)
		{
			_serviceCollection = serviceCollection;
		}

		public void Register()
		{
			_serviceCollection.AddSingleton<IDbConnection, DbConnection>();
		}
	}
}