namespace MOK.Library.Domain.WebApi
{
	public class BookFetchModel
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string ISBN { get; set; }
		public string Author { get; set; }
		public int SubjectId { get; set; }
		public SubjectFetchModel Subject { get; set; }
	}
}