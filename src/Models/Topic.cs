namespace ForumSoftware.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ForumId { get; set; }
        public Forum Forum { get; set; }
    }
}
