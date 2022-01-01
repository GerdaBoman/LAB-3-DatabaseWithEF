using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LAB_3.Model
{
    public partial class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(255)]
        public string FirstName { get; set; } = null!;
        [StringLength(255)]
        public string LastName { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        [InverseProperty(nameof(Book.Author))]
        public virtual ICollection<Book> Books { get; set; }
    }
}
