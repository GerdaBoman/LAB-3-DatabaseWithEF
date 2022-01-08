using LAB_3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop2._0
{
    partial class RemoveBookMethods : Program
    {

        

        //Remove book completly from book and inventory table
        public static void RemoveBookCompletly(string isbnID)
        {
            var bookInBooks = _context.Books.SingleOrDefault(x => x.IsbnId == isbnID);

            var bookInInventory = _context.Inventories.FirstOrDefault(i => i.IsbnId == isbnID);

            if (bookInBooks != null)
            {
                _context.Inventories.Remove(bookInInventory);
                _context.Books.Remove(bookInBooks);
                _context.SaveChanges();

            }
            else
            {
                Console.WriteLine("No book found");

            }
        }

        //Remove book and its quantity from shops inventory
        public static void RemoveTitleFromShopInventory(string isbnID, string shopID)
        {
            var bookInShop = (from i in _context.Inventories
                              where i.IsbnId == isbnID &&
                              i.ShopId == shopID
                              select i).FirstOrDefault();

            if (bookInShop != null)
            {
                _context.Inventories.Remove(bookInShop);
                _context.SaveChanges();

            }
            else
                Console.WriteLine("Book not found");
        }

        //Remove amount of books from book titles quantity and spesific shop
        public static void RemoveQuantityOfBookFromShop(string shopId, string isbnId, int amountBook)
        {


            var bookInStore = _context.Inventories.Where(i => i.ShopId == shopId && i.IsbnId == isbnId).SingleOrDefault();
            if (bookInStore != null)
            {
                bookInStore.Quantity = bookInStore.Quantity - amountBook;
                _context.SaveChanges();
            }
        }


    }
}
