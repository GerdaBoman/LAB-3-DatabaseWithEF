using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LAB_3.Model
{
    public partial class Book
    {
        public Book()
        {
            Inventories = new HashSet<Inventory>();
        }

        [Key]
        [Column("ISBN_ID")]
        [StringLength(13)]
        public string IsbnId { get; set; } = null!;
        [StringLength(50)]
        public string Title { get; set; } = null!;
        [StringLength(50)]
        public string? Language { get; set; }
        [Column("Page_Numbers")]
        public int? PageNumbers { get; set; }
        [Column("Price(SEK)", TypeName = "money")]
        public decimal? PriceSek { get; set; }
        [Column("Release_Date")]
        public DateTime? ReleaseDate { get; set; }
        [Column("Author_ID")]
        public int? AuthorId { get; set; }
        [Column("Genre_ID")]
        public int? GenreId { get; set; }
        [Column("Publishers_ID")]
        public int? PublishersId { get; set; }

        [ForeignKey(nameof(AuthorId))]
        [InverseProperty("Books")]
        public virtual Author? Author { get; set; }
        [ForeignKey(nameof(GenreId))]
        [InverseProperty("Books")]
        public virtual Genre? Genre { get; set; }
        [ForeignKey(nameof(PublishersId))]
        [InverseProperty(nameof(Publisher.Books))]
        public virtual Publisher? Publishers { get; set; }
        [InverseProperty(nameof(Inventory.Isbn))]
        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
