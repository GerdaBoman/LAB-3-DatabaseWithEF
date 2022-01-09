using LAB_3.Model;

namespace BookShop2._0
{
    partial class AuthorMethods : Program
    {



        //Adding new author
        public static void AddNewAuthor(string fristName, string LastName, DateTime dateOfBirth)
        {

            var author = new Author
            {

                FirstName = fristName,
                LastName = LastName,
                DateOfBirth = dateOfBirth,
            };
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        //Remove author from their ID number
        public static void RemoveAuthors(int iD)
        {

            var author = (from a in _context.Authors
                          where a.Id == iD
                          select a).SingleOrDefault();
            if (author == null)
            {
                Console.WriteLine("No author found");

            }
            else
            {
                _context.Authors.Remove(author);

                _context.SaveChanges();
                Console.WriteLine("Author removed!");
            }


        }

        //Print all author list
        public static void AllAuthors()
        {
            var authors = _context.Authors.ToList();
            Console.WriteLine($"Number of authors: {authors.Count} ");
            var authorID = (from a in _context.Authors
                            select new
                            {
                                a.Id,
                                a.FirstName,
                                a.LastName
                            }).ToList();

            foreach (var author in authorID)
            {
                Console.WriteLine($"{author.Id} -- {author.FirstName} {author.LastName}");
            }

        }


    }
}
