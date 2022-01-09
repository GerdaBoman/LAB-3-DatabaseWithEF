using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LAB_3.Model
{
    public partial class Genre
    {
        public Genre()
        {
            Books = new HashSet<Book>();
        }

        [Key]
        [Column("Genre_ID")]
        public int GenreId { get; set; }
        [Column("Genre")]
        [StringLength(50)]
        public string? Genre1 { get; set; }

        [InverseProperty(nameof(Book.Genre))]
        public virtual ICollection<Book> Books { get; set; }
    }
}
