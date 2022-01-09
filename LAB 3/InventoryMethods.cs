using LAB_3.Model;

namespace BookShop2._0;

partial class InventoryMethods : Program
{
    public static void GetBooks(string text)
    {

        var book = _context.Books.ToList();
        Console.WriteLine($"{text} number of books: {book.Count} ");
        foreach (var Book in book)
        {
            Console.WriteLine(Book.Title);
        }
    }

    //how many of each title there is in every shop. 
    public static void InventoryInShops()

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

