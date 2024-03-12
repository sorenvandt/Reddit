using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Comments
    {
        [Key]
        public int CommentId { get; set; }
        public string Comment {  get; set; }

        // Fremmednøgle til brugeren, der har oprettet kommentaren
        public int UserId { get; set; }
        public User User { get; set; }

        // Fremmednøgle til indlægget, kommentaren er knyttet til
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
