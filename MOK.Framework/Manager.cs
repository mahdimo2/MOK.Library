using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace MOK.Framework
{
	public class Manager
	{
		public static IServiceProvider ServiceProvider { get; private set; }
		public static IServiceCollection serviceDescriptors { get; private set; }

		public static void InitDependencies(IServiceCollection services)
		{
			RegisterDependencies(services);
		}

		public static void InitApplicationServices(IServiceProvider serviceProvider)
		{
			ServiceProvider = serviceProvider;
		}

		private static void RegisterDependencies(IServiceCollection services)
		{
			string _executionPath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			string assembliesPath = _executionPath == "" ? AppDomain.CurrentDomain.BaseDirectory : _executionPath;
			var assemblies = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(assembliesPath)
				.GetDirectoryContents("")
				.Where(
					f => f.Name.EndsWith(".dll") && f.Name.Contains("MOK.")
				);

			foreach (var yAssembly in assemblies)
			{
				try
				{
					var iocAssmblies = Assembly.LoadFrom(yAssembly.PhysicalPath).DefinedTypes.Where(t => t.ImplementedInterfaces.Contains(typeof(IDependencyRegistrar))).ToList();
					iocAssmblies.ForEach(ioc =>
					{
						try
						{
							IDependencyRegistrar registrar = Activator.CreateInstance(ioc, services) as IDependencyRegistrar;
							registrar.Register();
						}
						catch (Exception ex)
						{
							throw new Exception($"Error in registering '{ioc.FullName}'", ex);
						}
					});
				}
				catch (Exception ex)
				{
					throw new Exception($"Error in loading assembly '{yAssembly.Name}'", ex);
				}
			}
		}
	}
}