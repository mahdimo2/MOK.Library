namespace MOK.Library.Domain.WebApi
{
	public class BookCrudModel
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string ISBN { get; set; }
		public string Author { get; set; }
		public int SubjectId { get; set; }

	}
}