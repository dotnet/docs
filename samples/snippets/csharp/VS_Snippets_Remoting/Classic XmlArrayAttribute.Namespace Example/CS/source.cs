// <Snippet1>
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
 
public class Library
   {
   private Book[] books;
   private Periodical [] periodicals;
   /* This element will be qualified with the prefix 
   that is associated with the namespace http://wwww.cpandl.com. */
   [XmlArray(ElementName = "Titles", 
   Namespace="http://wwww.cpandl.com")]
   public Book[] Books
   {
      get{return books;}
      set{books = value;}
   }
   /* This element will be qualified with the prefix that is
   associated with the namespace http://www.proseware.com. */
   [XmlArray(ElementName = "Titles", Namespace = 
   "http://www.proseware.com")]
   public Periodical[] Periodicals
   {
      get{return periodicals;}
      set{periodicals = value;}
   }
}
 
public class Book
{
   public string Title;
   public string Author;
   public string ISBN;
   [XmlAttribute]
   public string Publisher;
}
 
public class Periodical
{
   private string title;
   public string Title
   {
      get{return title;}
      set{title = value;}
   }
}
 
public class Run
{
   public static void Main()
   {
      Run test = new Run();
      test.WriteBook("MyLibrary.xml");
      test.ReadBook("MyLibrary.xml");   
   }
 
   public void WriteBook(string filename)
   {
      // Creates a new XmlSerializer.
      XmlSerializer mySerializer = new XmlSerializer(typeof(Library));
      // Writing the file requires a StreamWriter.
      TextWriter myStreamWriter = new StreamWriter(filename);
      /* Creates an XmlSerializerNamespaces and adds prefixes and 
      namespaces to be used. */
      XmlSerializerNamespaces myNamespaces = 
      new XmlSerializerNamespaces();
      myNamespaces.Add("books", "http://wwww.cpandl.com");
      myNamespaces.Add("magazines", "http://www.proseware.com");
      // Creates an instance of the class to be serialized.
      Library myLibrary = new Library();
 
      // Creates two book objects.
      Book b1 = new Book();
      b1.Title = "My Book Title";
      b1.Author = "An Author";
      b1.ISBN = "000000000";
      b1.Publisher = "Microsoft Press";
 
      Book b2 = new Book();
      b2.Title = "Another Book Title";
      b2.Author = "Another Author";
      b2.ISBN = "00000001";
      b2.Publisher = "Another Press";
       
      /* Creates an array using the objects, and sets the Books property
      to the array. */
      Book[] myBooks = {b1,b2};
      myLibrary.Books = myBooks;
 
      // Creates two Periodical objects.
      Periodical per1 = new Periodical();
      per1.Title = "My Magazine Title";
      Periodical per2 = new Periodical();
      per2.Title = "Another Magazine Title";
 
      // Sets the Periodicals property to the array. 
      Periodical[] myPeridocials = {per1, per2};
      myLibrary.Periodicals = myPeridocials;

      // Serializes the myLibrary object.
      mySerializer.Serialize(myStreamWriter, myLibrary, myNamespaces);

       myStreamWriter.Close();
    }
 
   public void ReadBook(string filename)
   {
      /* Creates an instance of an XmlSerializer
      with the class used to read the document. */
      XmlSerializer mySerializer = new XmlSerializer(typeof(Library));
      // A FileStream is needed to read the file.
      FileStream myFileStream = new FileStream(filename, FileMode.Open);

      Library myLibrary = (Library) mySerializer.Deserialize(myFileStream);

      // Reads each book in the array returned by the Books property.      
      for(int i = 0; i< myLibrary.Books.Length;i++)
      {
         Console.WriteLine(myLibrary.Books[i].Title);
         Console.WriteLine(myLibrary.Books[i].Author);
         Console.WriteLine(myLibrary.Books[i].ISBN);
         Console.WriteLine(myLibrary.Books[i].Publisher);
         Console.WriteLine();
      }
      // Reads each Periodical returned by the Periodicals property.
      for(int i = 0; i< myLibrary.Periodicals.Length;i++)
      {
         Console.WriteLine(myLibrary.Periodicals[i].Title);
      }
   }
}
   
// </Snippet1>
