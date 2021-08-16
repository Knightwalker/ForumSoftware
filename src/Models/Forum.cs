namespace ForumSoftware.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Forum
    {
        [Key]
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Forum Parent { get; set; }
        public List<Forum> Children { get; set; }
        public List<Topic> Topics { get; set; }
    }
}
