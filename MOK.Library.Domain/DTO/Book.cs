namespace MOK.Library.Domain.DTO
{
	public class Book
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string ISBN { get; set; }
		public string Author { get; set; }
		public int SubjectId { get; set; }
		public Subject Subject { get; set; }

	}
}