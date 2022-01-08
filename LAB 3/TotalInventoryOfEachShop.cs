using LAB_3.Data;

namespace BookShop2._0
{
   public partial class TotalInventoryOfEachShop
    {
        public static BokHandelContext _context = new();
        public static async void Inventory()
        //how many of each title there is in every shop. 
        {
            var count = _context.Inventories.GroupBy(s => s.ShopId)
                .Select(s => new
                {
                    s.Key,
                    SUM = s.Sum(q => q.Quantity)
                });

            foreach (var group in count)
            {
                Console.WriteLine("Shop id = {0} Total = {1}", group.Key, group.SUM);
            }

        }
    }
}