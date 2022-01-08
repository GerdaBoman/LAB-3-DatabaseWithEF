using LAB_3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_3
{
    public partial class EvertyTitleQuantity
    {
        public static BokHandelContext _context = new();
        public static void TotalInvetory()
        {
            var everyBook = (from b in _context.Books
                             join q in _context.Inventories on b.IsbnId equals q.IsbnId
                             select new
                             {
                                 q.ShopId,
                                 q.Quantity,
                                 b.Title
                             }).ToList();

            var sumOfAllBooks = (from q in _context.Inventories
                                 where q.Quantity != null
                                 select q.Quantity).Sum();



            Console.WriteLine($"Total number of books: {sumOfAllBooks}");
            Console.WriteLine();

            foreach (var data in everyBook)
            {
                Console.WriteLine($"{data.ShopId} {data.Title}  = {data.Quantity}");
            }

        }

    }
}
