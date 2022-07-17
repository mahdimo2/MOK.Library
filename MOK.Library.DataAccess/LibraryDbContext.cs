using Microsoft.EntityFrameworkCore;
using MOK.Library.Domain.DataModels;
using MOK.Library.Domain.Settings;
using System.Linq;

namespace MOK.Library.DataAccess
{
	public class LibraryDbContext : DbContext
	{
		public LibraryDbContext(DbContextOptions<LibraryDbContext> options, IDbConnection dbConnection) 
			: base(ConfigureOptions(options, dbConnection))
		{
			
		}

		private static DbContextOptions<LibraryDbContext> ConfigureOptions(DbContextOptions<LibraryDbContext> options, IDbConnection dbConnection)
		{
			//if (options == null  || options.Extensions.Count() < 2)
			//{
				var optionBuilder = new DbContextOptionsBuilder<LibraryDbContext>().UseSqlServer(dbConnection.DefaultConnection);
				options = optionBuilder.Options;
			//}

			return options;
		}

		public DbSet<Book> Books { get; set; }
		public DbSet<Subject> Subjects { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Book>().ToTable("Book");
			modelBuilder.Entity<Book>()
				.Property(b => b.Id).UseIdentityColumn();
			modelBuilder.Entity<Book>()
				.HasOne<Subject>( b => b.Subject).WithMany().HasForeignKey( b=> b.SubjectId);
			

			modelBuilder.Entity<Subject>().ToTable("Subject");
			modelBuilder.Entity<Subject>()
				.Property(s => s.Id).UseIdentityColumn();

		}
	}
}
