using Microsoft.Extensions.Configuration;
using MOK.Library.Domain.Settings;
using System.IO;

namespace MOK.Library.WebAPI.Settings
{
	public class DbConnection : IDbConnection
	{
		public string DefaultConnection { get; set; }

		public DbConnection()
		{
			var builder = new ConfigurationBuilder()
					.SetBasePath(Directory.GetCurrentDirectory())
					.AddJsonFile("appsettings.json");

			IConfigurationRoot configuration = builder.Build();
			configuration.GetSection("ConnectionStrings").Bind(this);
		}
	}
}
