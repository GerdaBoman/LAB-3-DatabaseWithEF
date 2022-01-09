using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LAB_3.Model
{
    public partial class Shop
    {
        public Shop()
        {
            Inventories = new HashSet<Inventory>();
        }

        [Key]
        [Column("Shop_ID")]
        [StringLength(6)]
        public string ShopId { get; set; } = null!;
        [Column("Shop_Name")]
        [StringLength(50)]
        public string? ShopName { get; set; }
        [Column("Shop_Address")]
        [StringLength(100)]
        public string? ShopAddress { get; set; }
        [Column("Shop_Town")]
        [StringLength(100)]
        public string? ShopTown { get; set; }
        [Column("Shop_ContactNumber")]
        [StringLength(30)]
        public string? ShopContactNumber { get; set; }

        [InverseProperty(nameof(Inventory.Shop))]
        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
