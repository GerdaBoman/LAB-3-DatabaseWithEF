using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LAB_3.Model
{
    [Keyless]
    public partial class TitlesPerAuthor
    {
        [StringLength(511)]
        public string Author { get; set; } = null!;
        public int? Age { get; set; }
        [Column("Total Titles")]
        public int? TotalTitles { get; set; }
        [Column("Stock Value", TypeName = "money")]
        public decimal? StockValue { get; set; }
    }
}
