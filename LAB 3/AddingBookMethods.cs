using BookShop2._0;
using LAB_3.Data;
using LAB_3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_3
{
    partial class AddingBookMethods : Program
    {

        //Adding new book title to existing author
        public static void AddBookToExistingAuthor(string isbnID, string title, string language, int pageNumber, decimal price, DateTime releaseDate, int authorID, int genreid,
        int publishersID)
        {
            var book = new Book
            {

                IsbnId = isbnID,
                Title = title,
                Language = language,
                PageNumbers = pageNumber,
                PriceSek = price,
                ReleaseDate = releaseDate,
                AuthorId = authorID,
                GenreId = genreid,
                PublishersId = publishersID
            };

            _context.Books.Add(book);
            _context.SaveChanges();
        }

        //Adding new book to Inventory

        public static void AddNewBookToInventory(string shopID, string isbnId, int quantity)
        {
            var insertInInventory = new Inventory
            {
                ShopId = shopID,
                IsbnId = isbnId,
                Quantity = quantity

            };

            _context.Inventories.Add(insertInInventory);
            _context.SaveChanges();


        }

        //adding extra books into book title quantity in specific shop
        public static void AddToTitleQuanityInShop(string shopId, string isbnId, int amountBook)
        {
            var bookInStore = _context.Inventories.Where(i => i.ShopId == shopId && i.IsbnId == isbnId).SingleOrDefault();
            if (bookInStore != null)
            {
                bookInStore.Quantity = bookInStore.Quantity + amountBook;
                _context.SaveChanges();
            }
        }
    }
}
