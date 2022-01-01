using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LAB_3.Model
{
    [Table("Inventory")]
    [Index(nameof(ShopId), nameof(IsbnId), Name = "Inventory", IsUnique = true)]
    public partial class Inventory
    {
        [Key]
        [Column("Shop_ID")]
        [StringLength(6)]
        public string ShopId { get; set; } = null!;
        [Key]
        [Column("ISBN_ID")]
        [StringLength(13)]
        public string IsbnId { get; set; } = null!;
        public int? Quantity { get; set; }

        [ForeignKey(nameof(IsbnId))]
        [InverseProperty(nameof(Book.Inventories))]
        public virtual Book Isbn { get; set; } = null!;
        [ForeignKey(nameof(ShopId))]
        [InverseProperty("Inventories")]
        public virtual Shop Shop { get; set; } = null!;
    }
}
