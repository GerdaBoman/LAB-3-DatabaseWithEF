
using LAB_3;
using LAB_3.Data;
using LAB_3.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BookShop2._0;
class Program 
{
    public static BokHandelContext _context = new BokHandelContext();

    public static void Main(string[] args)
    {
        _context.Database.EnsureCreated();

        //The simplest console application ever :D
        Console.WriteLine("Every shops inventory:");
        InvetoryMethods.Inventory();
        Console.Write("Press Any Key to continue");
        Console.ReadKey();
        Console.WriteLine();
        Console.Clear();

        Console.WriteLine("All titles in every shop and their quantities");
        EvertyTitleQuantity.TotalInvetory();
        Console.ReadKey();  
        Console.Clear();

        
        GetBooks("All book titles before addition of new title ");
        Console.Write("Press Any Key to continue");
        Console.ReadKey();
        Console.WriteLine();
        Console.Clear();


        AddingBookMethods.AddBookToExistingAuthor("9872568142361", "Super Charlie", "Swedish", 37, 56, DateTime.ParseExact("2002/02/10", "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture), 3, 24, 2);
        GetBooks("After adding Super Charlie book ");
        Console.Write("Press Any Key to continue");
        Console.ReadKey();
        Console.WriteLine();
        Console.Clear();

        Console.WriteLine("Adding 100 books of Super Charlie to bookshop AKANYK");
        AddingBookMethods.AddBookToInventory("AKANYK", "9872568142361", 100);
        InvetoryMethods.Inventory();
        Console.Write("Press Any Key to continue");
        Console.ReadKey();
        Console.WriteLine();
        Console.Clear();

        Console.WriteLine("Adding 100 books of Super Charlie to bookshop DROILD");
        AddingBookMethods.AddBookToInventory("DROILD", "9872568142361", 100);
        InvetoryMethods.Inventory();
        Console.Write("Press Any Key to continue");
        Console.ReadKey();
        Console.WriteLine();
        Console.Clear();

        Console.WriteLine("Removing 25 books of Super Charlie from shop AKANYK");
        RemoveBookMethods.RemoveQuantityOfBookFromShop("AKANYK", "9872568142361", 25);
        EvertyTitleQuantity.TotalInvetory();
        Console.ReadKey();
        Console.Clear();

        Console.WriteLine("Removing all of the books with title Super Charlie from shop DROILD");
        RemoveBookMethods.RemoveTitleFromShopInventory("9872568142361", "DROILD");
        EvertyTitleQuantity.TotalInvetory();
        Console.ReadKey();
        Console.Clear();

        Console.WriteLine("Adding 25 books to Super Charlier to shop AKANYK");
        AddingBookMethods.AddToTitleQuanityInShop("AKANYK", "9872568142361", 25);
        EvertyTitleQuantity.TotalInvetory();
        Console.ReadKey();
        Console.Clear();


        Console.WriteLine("Removing Super Charlie from all the shops and books table");
        RemoveBookMethods.RemoveBookCompletly("9872568142361");
        GetBooks("After book is removed ");
        Console.Write("Press Any Key to continue");
        Console.ReadKey();
        Console.Clear();

        Console.WriteLine("Results after all addition and removals");
        EvertyTitleQuantity.TotalInvetory();
        Console.ReadKey();
        Console.Clear();

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

    //Print all book titles 
    private static void GetBooks(string text)
    {
        var book = _context.Books.ToList();
        Console.WriteLine($"{text} number of books: {book.Count} ");
        foreach (var Book in book)
        {
            Console.WriteLine(Book.Title);
        }
    }


}


