using MOK.Library.Domain.DataAccess;
using MOK.Library.Domain.Settings;

namespace MOK.Library.DataAccess
{
	public class Initializer : IInitializer
	{
		static LibraryDbContext _dbContext;

		public Initializer(IDbConnection dbConnection)
		{
			_dbContext = new LibraryDbContext(null, dbConnection);
		}

		public void Initialize()
		{
			_dbContext.Database.EnsureCreated();
		}
	}
}
