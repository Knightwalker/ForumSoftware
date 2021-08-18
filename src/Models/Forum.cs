namespace ForumSoftware.Models
{
    using System.Collections.Generic;

    public class Forum
    {
        public Forum()
        {
            this.ParentId = null; // root element by default
            this.Type = "category";
        }

        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Forum Parent { get; set; }
        public List<Forum> Children { get; set; }
        public List<Topic> Topics { get; set; }
    }
}
