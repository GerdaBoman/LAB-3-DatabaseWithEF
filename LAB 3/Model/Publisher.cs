using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LAB_3.Model
{
    public partial class Publisher
    {
        public Publisher()
        {
            Books = new HashSet<Book>();
        }

        [Key]
        [Column("Publisher_ID")]
        public int PublisherId { get; set; }
        [Column("Publischer_Name")]
        [StringLength(50)]
        public string? PublischerName { get; set; }
        [Column("Publisher_Address")]
        [StringLength(50)]
        public string? PublisherAddress { get; set; }
        [Column("Telephone_Number")]
        [StringLength(30)]
        public string? TelephoneNumber { get; set; }

        [InverseProperty(nameof(Book.Publishers))]
        public virtual ICollection<Book> Books { get; set; }
    }
}
