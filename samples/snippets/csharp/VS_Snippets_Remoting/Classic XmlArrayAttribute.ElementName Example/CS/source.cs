// <Snippet1>
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
 
public class Library
{
   private Book[] books;
   [XmlArray(ElementName="My_Books")]
   public Book[] Books
   {
      get{return books;}
      set{books = value;}
   }
}
 
public class Book
{
   public string Title;
   public string Author;
   public string ISBN;
}
 
public class Run
{
   public static void Main()
   {
      Run test = new Run();
      test.WriteBook("ArrayExample.xml");
   }
 
   public void WriteBook(string filename)
   {
      XmlSerializer mySerializer = new XmlSerializer(typeof(Library));
      TextWriter t = new StreamWriter(filename);
      XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
      ns.Add("bk", "http://wwww.contoso.com");
 
      Book b1 = new Book();
      b1.Title = "MyBook Title";
      b1.Author = "An Author";
      b1.ISBN = "00000000";
 
      Book b2 = new Book();
      b2.Title = "Another Title";
      b2.Author = "Another Author";
      b2.ISBN = "0000000";
       
      Library myLibrary = new Library();
      Book[] myBooks = {b1,b2};
      myLibrary.Books = myBooks;
       
      mySerializer.Serialize(t,myLibrary,ns);
      t.Close();
   }
}
   
// </Snippet1>
