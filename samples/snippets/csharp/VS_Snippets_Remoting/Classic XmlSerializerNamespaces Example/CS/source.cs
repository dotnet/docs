// <Snippet1>
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
 
public class Run
{
   public static void Main()
   {
      Run test = new Run();
      test.SerializeObject("XmlNamespaces.xml");
   }
 
   public void SerializeObject(string filename)
   {
      XmlSerializer s = new XmlSerializer(typeof(Books));
      // Writing a file requires a TextWriter.
      TextWriter t = new StreamWriter(filename);

      /* Create an XmlSerializerNamespaces object and add two
      prefix-namespace pairs. */
      XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
      ns.Add("books", "http://www.cpandl.com");
      ns.Add("money", "http://www.cohowinery.com");

      // Create a Book instance.
      Book b = new Book();
      b.TITLE = "A Book Title";
      Price p = new Price();
      p.price = (decimal) 9.95;
      p.currency = "US Dollar";
      b.PRICE = p;
      Books bks = new Books();
      bks.Book = b;
      s.Serialize(t,bks,ns);
      t.Close();
   }
}

public class Books
{
   [XmlElement(Namespace = "http://www.cohowinery.com")]
   public Book Book;
}

[XmlType(Namespace ="http://www.cpandl.com")]
public class Book
{
   [XmlElement(Namespace = "http://www.cpandl.com")]
   public string TITLE;
   [XmlElement(Namespace ="http://www.cohowinery.com")]
   public Price PRICE;
}

public class Price
{
   [XmlAttribute(Namespace = "http://www.cpandl.com")]
   public string currency;
   [XmlElement(Namespace = "http://www.cohowinery.com")]
   public decimal price;
}

// </Snippet1>
