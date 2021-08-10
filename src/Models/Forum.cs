namespace ForumSoftware.Models
{
    using System.Collections.Generic;
    public class Forum
    {
        public int Id { get; set; }
        public int? ForumId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Test { get; set; }
        public ICollection<Topic> Topics { get; set; }
        public ICollection<Forum> Children { get; set; }
    }
}
