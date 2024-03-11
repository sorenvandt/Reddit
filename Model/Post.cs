using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Post
    {
        public int PostId { get; set; }

        [Required]
        public string Content { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        // Samling af kommentarer knyttet til dette indlæg
        public ICollection<Comments> Comments { get; set; }
    }
}
