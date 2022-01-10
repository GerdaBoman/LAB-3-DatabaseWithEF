namespace BookShop2._0;

partial class BookShop : Program
{
    public static void BookShopPart1()
    {
        //First part consists of mostley inventory methods and a adding new book to exsisting author

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

        //Adding new book to existing author
        AddingBookMethods.AddBookToExistingAuthor("9872568142361", "Super Charlie", "Swedish", 37, 56, DateTime.ParseExact("2002/02/10", "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture), 3, 24, 2);
        InventoryMethods.GetBooks("After adding Super Charlie book ");
        Console.Write("Press Any Key to continue");
        Console.ReadKey();
        Console.WriteLine();
        Console.Clear();
    }
    public static void BookShopPart2()
    {
        //Second part is a sample of adding extra book quantity to existing book titles with user input

        Console.WriteLine("Add books to store");
        InventoryMethods.InventoryInShops();
        Console.Write("To which store would you like to add the books(Enter StoreId): ");
        string? store = Console.ReadLine();
        Console.WriteLine();
        Console.Write("How many books would you like to add: ");
        int add = int.Parse(Console.ReadLine());
        Console.WriteLine();
        Console.Write("Choose book you want to add more books to (Enter title): ");
        string? userInput = Console.ReadLine();
        string isbnID = AddingBookMethods.BooksIsbnFromName(userInput);
        AddingBookMethods.AddToTitleQuanityInShop(store, isbnID, add);

        Console.Write("Press Any Key to continue");
        Console.ReadKey();
        Console.WriteLine();
        Console.Clear();
    }
    public static void BookShopPart3()
    {
        //Third part cosist of adding and removing quantity of the newley added book to/from specific bookstores

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

        Console.WriteLine("Removing 25 books of Super Charlie from shop AKANYK");
        RemoveBookMethods.RemoveQuantityOfBookFromShop("AKANYK", "9872568142361", 25);
        InventoryMethods.TotalInvetory();
        Console.ReadKey();
        Console.Clear();

        Console.WriteLine("Removing all of the books with title Super Charlie from shop DROILD");
        RemoveBookMethods.RemoveTitleFromShopInventory("9872568142361", "DROILD");
        InventoryMethods.TotalInvetory();
        Console.ReadKey();
        Console.Clear();

        Console.WriteLine("Adding 25 books to Super Charlier to shop AKANYK");
        AddingBookMethods.AddToTitleQuanityInShop("AKANYK", "9872568142361", 25);
        InventoryMethods.TotalInvetory();
        Console.ReadKey();
        Console.Clear();


        Console.WriteLine("Removing Super Charlie from all the shops and books table");
        RemoveBookMethods.RemoveBookCompletly("9872568142361");
        InventoryMethods.GetBooks("After book is removed ");
        Console.Write("Press Any Key to continue");
        Console.ReadKey();
        Console.Clear();

        Console.WriteLine("Results after all addition and removals");
        InventoryMethods.TotalInvetory();
        Console.ReadKey();
        Console.Clear();
    }
    public static void BookShopPart4()
    {
        //Fourth part is a sampel of adding new author and removing author by it's id

        Console.WriteLine("Adding new author");
        AuthorMethods.AddNewAuthor("Dan", "Brown", DateTime.ParseExact("1964/06/22", "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture));
        Console.WriteLine("After adding new author");
        AuthorMethods.AllAuthors();
        Console.Write("Press Any Key to continue");
        Console.ReadKey();
        Console.Clear();

        Console.Write("Choose author ID to remove: ");
        int input = int.Parse(Console.ReadLine());
        Console.WriteLine("Removing author");
        AuthorMethods.RemoveAuthors(input);
        AuthorMethods.AllAuthors();
        Console.Write("Press Any Key to continue");
        Console.ReadKey();
        Console.WriteLine();
        Console.Clear();
    }
}
