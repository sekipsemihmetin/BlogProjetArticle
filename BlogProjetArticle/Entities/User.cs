namespace BlogProjetArticle.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }
        public string ProfilePicture { get; set; }
        public string Username { get; set; }
        public List<Article> Articles { get; set; }
    }
}
