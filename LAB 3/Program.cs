using LAB_3.Data;

namespace BookShop2._0;
class Program
{
    public static BokHandelContext _context = new BokHandelContext();

    public static void Main(string[] args)
    {
        _context.Database.EnsureCreated();

        BookShop.BookShopPart1();
        BookShop.BookShopPart2();
        BookShop.BookShopPart3();
        BookShop.BookShopPart4();
    }

}


