// <Snippet1>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Find
{
    class Program
    {
        private static string IDtoFind = "bk109";

        private static List<Book> Books = new List<Book>();
        public static void Main(string[] args)
        {
            FillList();
            
            // Find a book by its ID.
            Book result = Books.Find(
            delegate(Book bk)
            {
                return bk.ID == IDtoFind;
            }
            );
            if (result != null)
            {
                DisplayResult(result, "Find by ID: " + IDtoFind);   
            }
            else
            {
                Console.WriteLine("\nNot found: {0}", IDtoFind);
            }


            // Find last book in collection published before 2001.
            result = Books.FindLast(
            delegate(Book bk)
            {
                DateTime year2001 = new DateTime(2001,01,01);
                return bk.Publish_date < year2001;
            });
            if (result != null)
            {
                DisplayResult(result, "Last book in collection published before 2001:");
            }
            else
            {
                Console.WriteLine("\nNot found: {0}", IDtoFind);
            }


            // Find all computer books.
            List<Book> results = Books.FindAll(FindComputer);
            if (results.Count != 0)
            {
                DisplayResults(results, "All computer:");
            }
            else
            {
                Console.WriteLine("\nNo books found.");
            }

            // Find all books under $10.00.
            results = Books.FindAll(
            delegate(Book bk)
            {
                return bk.Price < 10.00;
            }
            );
            if (results.Count != 0)
            {
                DisplayResults(results, "Books under $10:");
            }
            else
            {
                Console.WriteLine("\nNo books found.");
            }
            

            // Find index values.
            Console.WriteLine();
            int ndx = Books.FindIndex(FindComputer);
            Console.WriteLine("Index of first computer book: {0}", ndx);
            ndx = Books.FindLastIndex(FindComputer);
            Console.WriteLine("Index of last computer book: {0}", ndx);

            int mid = Books.Count / 2;
            ndx = Books.FindIndex(mid, mid, FindComputer);
            Console.WriteLine("Index of first computer book in the second half of the collection: {0}", ndx);
            
            ndx = Books.FindLastIndex(Books.Count - 1, mid, FindComputer);
            Console.WriteLine("Index of last computer book in the second half of the collection: {0}", ndx);

        }





        // Populates the list with sample data.
        private static void FillList()
        {
            
            // Create XML elements from a source file.
            XElement xTree = XElement.Load(@"c:\temp\books.xml");

            // Create an enumerable collection of the elements.
            IEnumerable<XElement> elements = xTree.Elements();

            // Evaluate each element and set set values in the book object.
            foreach (XElement el in elements)
            {
                Book book = new Book();
                book.ID = el.Attribute("id").Value;
                IEnumerable<XElement> props = el.Elements();
                foreach (XElement p in props)
                {


                    if (p.Name.ToString().ToLower() == "author")
                    {
                        book.Author = p.Value;
                    }
                    else if (p.Name.ToString().ToLower() == "title")
                    {
                        book.Title = p.Value;
                    }
                    else if (p.Name.ToString().ToLower() == "genre")
                    {
                        book.Genre = p.Value;
                    }
                    else if (p.Name.ToString().ToLower() == "price")
                    {
                        book.Price = Convert.ToDouble(p.Value);
                    }
                    else if (p.Name.ToString().ToLower() == "publish_date")
                    {
                        book.Publish_date = Convert.ToDateTime(p.Value);
                    }
                    else if (p.Name.ToString().ToLower() == "description")
                    {
                        book.Description = p.Value;
                    }
                }

                Books.Add(book);

            }

            DisplayResults(Books, "All books:");

        }

        // Explicit predicate delegate.
        private static bool FindComputer(Book bk)
        {

            if (bk.Genre == "Computer")
            {
                return true;
            }
	    else
            {
                return false;
            }

        }

        private static void DisplayResult(Book result, string title)
        {
            Console.WriteLine();
            Console.WriteLine(title);
            Console.WriteLine("\n{0}\t{1}\t{2}\t{3}\t{4}\t{5}", result.ID,
                result.Author, result.Title, result.Genre, result.Price,
                result.Publish_date.ToShortDateString());
            Console.WriteLine();


        }

        private static void DisplayResults(List<Book> results, string title)
        {
            Console.WriteLine();
            Console.WriteLine(title);
            foreach (Book b in results)
            {

                Console.Write("\n{0}\t{1}\t{2}\t{3}\t{4}\t{5}", b.ID,
                    b.Author, b.Title, b.Genre, b.Price,
                    b.Publish_date.ToShortDateString());
            }
            Console.WriteLine();

        }

    }

    public class Book
    {
        public string ID { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public double Price { get; set; }
        public DateTime Publish_date { get; set; }
        public string Description { get; set; }
    }
}
// </Snippet1>
