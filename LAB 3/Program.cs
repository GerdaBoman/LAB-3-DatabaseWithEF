using LAB_3.Data;

namespace BookShop2._0;
class Program
{
    public static BokHandelContext _context = new BokHandelContext();

    public static void Main(string[] args)
    {
        _context.Database.EnsureCreated();

<<<<<<< HEAD
        BookShop.BookShopPart1();
        BookShop.BookShopPart2();
        BookShop.BookShopPart3();
        BookShop.BookShopPart4();
=======
        BookShop();
     
    }
    public static void BookShop()
    {
        //The simplest console application ever :D
        Console.WriteLine("Every shops inventory:");
        InventoryMethods.InventoryInShops();
        Console.Write("Press Any Key to continue");
        Console.ReadKey();
        Console.WriteLine();
        Console.Clear();

        Console.WriteLine("All titles in every shop and their quantities");
        InventoryMethods.TotalInvetory();
        Console.ReadKey();
        Console.Clear();

        InventoryMethods.GetBooks("All book titles before addition of new title ");
        Console.Write("Press Any Key to continue");
        Console.ReadKey();
        Console.WriteLine();
        Console.Clear();

        AddingBookMethods.AddBookToExistingAuthor("9872568142361", "Super Charlie", "Swedish", 37, 56, DateTime.ParseExact("2002/02/10", "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture), 3, 24, 2);
        InventoryMethods.GetBooks("After adding Super Charlie book ");
        Console.Write("Press Any Key to continue");
        Console.ReadKey();
        Console.WriteLine();
        Console.Clear();

        //Sample of adding extra book quantity to excisting book title  with user input
        Console.WriteLine("Add books to store");
        InventoryMethods.InventoryInShops();
        Console.Write("To which store would you like to add the books(Enter StoreId): ");
        string? store = Console.ReadLine();
        Console.WriteLine();
        Console.Write("How many books would you like to add: ");
        int add = int.Parse(Console.ReadLine());
        Console.WriteLine();
        Console.Write("Choose book you want to add more books to: ");
        string? userInput = Console.ReadLine();
        string isbnID = AddingBookMethods.BooksIsbnFromName(userInput);
        AddingBookMethods.AddToTitleQuanityInShop(store, isbnID, add);

        Console.Write("Press Any Key to continue");
        Console.ReadKey();
        Console.WriteLine();
        Console.Clear();

        Console.WriteLine("Adding 100 books of Super Charlie to bookshop AKANYK");
        AddingBookMethods.AddNewBookToInventory("AKANYK", "9872568142361", 100);
        InventoryMethods.InventoryInShops();
        Console.Write("Press Any Key to continue");
        Console.ReadKey();
        Console.WriteLine();
        Console.Clear();

        Console.WriteLine("Adding 100 books of Super Charlie to bookshop DROILD");
        AddingBookMethods.AddNewBookToInventory("DROILD", "9872568142361", 100);
        InventoryMethods.InventoryInShops();
        Console.Write("Press Any Key to continue");
        Console.ReadKey();
        Console.WriteLine();
        Console.Clear();
>>>>>>> a9131a3d3de06a9a39dff880b620a1924adb769d

    }
}


