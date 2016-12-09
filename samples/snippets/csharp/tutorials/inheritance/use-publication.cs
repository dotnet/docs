using System;

public enum PublicationType { Misc, Book, Magazine, Article };

public abstract class Publication
{
   private bool published = false;
   private DateTime datePublished;
   private string pubName;
   private string pubTitle;
   private PublicationType pubType;
   private string copyrName;
   private int copyrDate;
   private int totalPages; 

   public Publication(string title, string publisher, PublicationType type)
   {
      if (publisher == null)
         throw new ArgumentNullException("The publisher cannot be null.");
      else if (String.IsNullOrWhiteSpace(publisher))
         throw new ArgumentException("The publisher cannot consist only of whitespace.");
      pubName = publisher;
  
      if (title == null)
         throw new ArgumentNullException("The title cannot be null.");
      else if (String.IsNullOrWhiteSpace(title))
         throw new ArgumentException("The title cannot consist only of whitespace.");
      pubTitle = title;

      pubType = type;
   }

   public string Publisher
   { get { return pubName; } }

   public string Title
   { get { return pubTitle; } }

   public PublicationType Type
   { get { return pubType; } }

   public string CopyrightName
   { get { return copyrName; } }
   
   public int CopyrightDate
   { get { return copyrDate; } }

   public int Pages
   { get { return totalPages; }
     set 
     {
         if (value <= 0)
            throw new ArgumentOutOfRangeException("The number of pages cannot be zero or negative.");
         totalPages = value;   
     }
   }

   public string GetPublicationDate()
   {
      if (!published)
         return "NYP";
      else
         return datePublished.ToString("d");   
   }
   
   public void Publish(DateTime datePublished)
   {
      published = true;
      this.datePublished = datePublished;
   }

   public void Copyright(string copyrightName, int copyrightDate)
   {
      if (copyrightName == null)
         throw new ArgumentNullException("The name of the copyright holder cannot be null.");
      else if (String.IsNullOrWhiteSpace(copyrightName))
         throw new ArgumentException("The name of the copyright holder cannot consist only of whitespace.");
      copyrName = copyrightName;
      
      int currentYear = DateTime.Now.Year;
      if (copyrightDate < currentYear - 10 || copyrightDate > currentYear + 2)
         throw new ArgumentOutOfRangeException(String.Format("The copyright year must be between {0} and {1}", 
            currentYear - 10, currentYear + 1));
      copyrDate = copyrightDate;      
   }

   public override string ToString()
   {
       return Title;
   }
}

public sealed class Book : Publication
{
   private string authorName;
   private Decimal bookPrice;
   private string id;
   private string ISOCurrencySymbol;

   public Book(string title, string publisher, string author) : 
          this(title, publisher, author, String.Empty)
   { }

   public Book(string title, string publisher, string author, string isbn) : base(title, publisher, PublicationType.Book)
   {
      // isbn argument must be a 10- or 13-character numeric string without "-" characters.
      // We could also determine whether the ISBN is valid by comparing its checksum digit 
      // with a computed checksum.
      //
      if (! String.IsNullOrEmpty(isbn)) {
Console.WriteLine("ISBN: '{0}' (1) characters", isbn, isbn.Length);
        // Determine if ISBN length is correct.
        if (! (isbn.Length == 10 | isbn.Length == 13))
            throw new ArgumentException("The ISBN must be a 10- or 13-character numeric string.");
        ulong nISBN = 0;
        if (! UInt64.TryParse(isbn, out nISBN))
            throw new ArgumentException("The ISBN can consist of numeric characters only.");
      } 
      id = isbn;

      authorName = author;
   }
     
   public string ISBN
   { get { return id; } }

   public string Author
   { get { return authorName; } }
   
   public Decimal Price
   {  get { return bookPrice; } }

   // A three-digit ISO currency symbol.
   public string Currency
   { get { return ISOCurrencySymbol; } }
   

   // Returns the old price, and sets a new price.
   public Decimal SetPrice(Decimal price, string currency)
   {
       if (price < 0)
          throw new ArgumentOutOfRangeException("The price cannot be negative.");
       Decimal oldValue = bookPrice;
       bookPrice = price;
       
       if (currency.Length != 3)
          throw new ArgumentException("The ISO currency symbol is a 3-character string.");
       ISOCurrencySymbol = currency;

       return oldValue;      
   }

   public override bool Equals(object obj)
   {
      Book book = obj as Book;
      if (book == null)
         return false;
      else
         return id == book.id && Title == book.Title;   
   }

   public override int GetHashCode()
   {
       return id.GetHashCode();
   }

   public override string ToString()
   {
      return String.Format("{0}{1}", String.IsNullOrEmpty(Author) ? "" : Author + ", ", Title);
   }
}

// <Snippet1>
public class Example
{
   public static void Main()
   {
      var book = new Book("The Tempest", "Public Domain Press", "Shakespeare, William", "0971655819");
      ShowPublicationInfo(book);
      book.Publish(new DateTime(2016, 8, 18));
      ShowPublicationInfo(book);

      var book2 = new Book("The Tempest", "Classic Works Press", "Shakespeare, William");
      Console.Write("{0} and {1} are the same publication: {2}", book.Title, book2.Title, 
      ((Publication) book).Equals(book2));
   }

   public static void ShowPublicationInfo(Publication pub)
   {
       string pubDate = pub.GetPublicationDate();
       Console.WriteLine("{0}, {1:d} by {2}", pub.Title, pubDate == "NYP" ? 
                         "Not Yet Published" : "published on " + pubDate, pub.Publisher);
       
   }
}
// </Snippet1>