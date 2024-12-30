namespace BlogProjetArticle.Entities
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public int AuthorId { get; set; }
        public User Author { get; set; }
        public List<Subject> Subjects { get; set; }
    }
}
