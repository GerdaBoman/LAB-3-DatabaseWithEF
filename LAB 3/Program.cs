
using LAB_3;
using LAB_3.Data;
using LAB_3.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BookShop2._0;
class Program : TotalInventoryOfEachShop
{
    public static BokHandelContext _context = new BokHandelContext();

    public static void Main(string[] args)
    {
        _context.Database.EnsureCreated();

        //The simplest console application ever :D

        TotalInventoryOfEachShop.Inventory();
        Console.Write("Press Any Key to continue");
        Console.ReadKey();
        Console.WriteLine();
        Console.Clear();

        EvertyTitleQuantity.TotalInvetory();
        Console.ReadKey();  
        Console.Clear();

        
        GetBooks("All books before add ");
        Console.Write("Press Any Key to continue");
        Console.ReadKey();
        Console.WriteLine();
        Console.Clear();


        AddingBookMethods.AddBookToExistingAuthor("9872568142361", "Super Charlie", "Swedish", 37, 56, DateTime.ParseExact("2002/02/10", "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture), 3, 24, 2);
        GetBooks("After adding book ");
        Console.Write("Press Any Key to continue");
        Console.ReadKey();
        Console.WriteLine();
        Console.Clear();

        AddingBookMethods.AddBookToInventory("AKANYK", "9872568142361", 100);
        TotalInventoryOfEachShop.Inventory();
        Console.Write("Press Any Key to continue");
        Console.ReadKey();
        Console.WriteLine();
        Console.Clear();

        AddingBookMethods.AddBookToInventory("DROILD", "9872568142361", 100);
        TotalInventoryOfEachShop.Inventory();
        Console.Write("Press Any Key to continue");
        Console.ReadKey();
        Console.WriteLine();
        Console.Clear();

        RemoveBookMethods.RemoveQuantityOfBookFromShop("AKANYK", "9872568142361", 25);
        EvertyTitleQuantity.TotalInvetory();
        Console.ReadKey();
        Console.Clear();

        RemoveBookMethods.RemoveTitleFromShopInventory("9872568142361", "DROILD");
        EvertyTitleQuantity.TotalInvetory();
        Console.ReadKey();
        Console.Clear();

        AddingBookMethods.AddToTitleQuanityInShop("AKANYK", "9872568142361", 25);

        RemoveBookMethods.RemoveBookCompletly("9872568142361");
        GetBooks("After book is removed ");
        Console.Write("Press Any Key to continue");
        Console.ReadKey();
        Console.Clear();

        EvertyTitleQuantity.TotalInvetory();
        Console.ReadKey();
        Console.Clear();


        AuthorMethods.AddNewAuthor("Dan", "Brown", DateTime.ParseExact("1964/06/22", "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture));
        Console.WriteLine("After adding new author");
        AuthorMethods.AllAuthors();
        Console.Write("Press Any Key to continue");
        Console.ReadKey();
        Console.Clear();

        Console.Write("Choose author ID to remove: ");
        int input = int.Parse(Console.ReadLine());
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


