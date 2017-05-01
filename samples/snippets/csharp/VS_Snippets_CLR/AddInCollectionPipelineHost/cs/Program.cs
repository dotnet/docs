// <Snippet1>
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using LibraryContractsHAV;
using System.AddIn.Hosting;
using System.Xml;


namespace ListAdaptersHost
{
class Program
{
static void Main(string[] args)
{

    // <Snippet2>
    // In this example, the pipeline root is the current directory.
    String pipeRoot = Environment.CurrentDirectory;

    // Rebuild the cache of pipeline and add-in information.
    string[] warnings = AddInStore.Update(pipeRoot);
    if (warnings.Length > 0)
    {
        foreach (string one in warnings)
        {
            Console.WriteLine(one);
        }
    }
    // </Snippet2>

    // <Snippet3>
    // Find add-ins of type LibraryManager under the specified pipeline root directory.
    Collection<AddInToken> tokens = AddInStore.FindAddIns(typeof(LibraryManager), pipeRoot);
    // </Snippet3>
    // Determine which add-in to use.
    AddInToken selectedToken = ChooseAddIn(tokens);

    // <Snippet4>
    // Activate the selected AddInToken in a new
    // application domain with a specified security trust level.
    LibraryManager manager = selectedToken.Activate<LibraryManager>(AddInSecurityLevel.FullTrust);
    // </Snippet4>

    // Create a collection of books.
    IList<BookInfo> books = CreateBooks();

    // Show the collection count.
    Console.WriteLine("Number of books:  {0}",books.Count.ToString());

    // Have the add-in process the books.
    // The add-in will discount computer books by $20
    // and list their before and after prices. It
    // will also remove all horror books.
    manager.ProcessBooks(books);

    // List the genre of each book. There
    // should be no horror books.
    foreach (BookInfo bk in books)
    {
        Console.WriteLine(bk.Genre());
    }

    Console.WriteLine("Number of books: {0}", books.Count.ToString());

    Console.WriteLine();
    // Have the add-in pass a BookInfo object
    // of the best selling book.
    BookInfo bestBook = manager.GetBestSeller();
    Console.WriteLine("Best seller is {0} by {1}", bestBook.Title(), bestBook.Author());

    // Have the add-in show the sales tax rate.
    manager.Data("sales tax");

    // <Snippet6>
    AddInController ctrl = AddInController.GetAddInController(manager);
    ctrl.Shutdown();
    // </Snippet6>
    Console.WriteLine("Press any key to exit.");
    Console.ReadLine();
}



private static AddInToken ChooseAddIn(Collection<AddInToken> tokens)
{
    if (tokens.Count == 0)
    {
        Console.WriteLine("No add-ins of this type are available");
        return null;
    }
    Console.WriteLine("{0} Available add-in(s):",tokens.Count.ToString());
    // <Snippet5>
    for (int i = 0; i < tokens.Count; i++)
    {
        // Show AddInToken properties.
        Console.WriteLine("[{0}] - {1}, Publisher: {2}, Version: {3}, Description: {4}",
            (i + 1).ToString(), tokens[i].Name, tokens[i].Publisher,
            tokens[i].Version, tokens[i].Description);
    }
    // </Snippet5>
    Console.WriteLine("Select add-in by number:");
    String line = Console.ReadLine();
    int selection;
    if (Int32.TryParse(line, out selection))
    {
        if (selection <= tokens.Count)
        {
            return tokens[selection - 1];
        }
    }
    Console.WriteLine("Invalid selection: {0}. Please choose again.", line);
    return ChooseAddIn(tokens);
}


internal static IList<BookInfo> CreateBooks()
{
    List<BookInfo> books = new List<BookInfo>();

    string ParamId = "";
    string ParamAuthor = "";
    string ParamTitle = "";
    string ParamGenre = "";
    string ParamPrice = "";
    string ParamPublish_Date = "";
    string ParamDescription = "";

    XmlDocument xDoc = new XmlDocument();
    xDoc.Load(@"c:\Books.xml");

     XmlNode xRoot = xDoc.DocumentElement;
     if (xRoot.Name == "catalog")
    {
        XmlNodeList bklist = xRoot.ChildNodes;
        foreach (XmlNode bk in bklist)
        {
            ParamId = bk.Attributes[0].Value;
            XmlNodeList dataItems = bk.ChildNodes;
            int items = dataItems.Count;
            foreach (XmlNode di in dataItems)
            {
                switch (di.Name)
                {
                    case "author":
                        ParamAuthor = di.InnerText;
                        break;
                    case "title":
                        ParamTitle = di.InnerText;
                        break;
                    case "genre":
                        ParamGenre = di.InnerText;
                        break;
                     case "price":
                        ParamPrice = di.InnerText;
                        break;
                     case "publish_date":
                        ParamAuthor = di.InnerText;
                        break;
                     case "description":
                        ParamDescription = di.InnerText;
                        break;
                      default:
                        break;
                }

            }
            books.Add(new MyBookInfo(ParamId, ParamAuthor, ParamTitle, ParamGenre,
                            ParamPrice, ParamPublish_Date, ParamDescription));
        }

    }
    return books;
}


}

class MyBookInfo : BookInfo
{
    private string _id;
    private string _author;
    private string _title;
    private string _genre;
    private string _price;
    private string _publish_date;
    private string _description;

    public MyBookInfo(string id, string author, string title,
                        string genre, string price,
                        string publish_date, string description)
    {
        _id = id;
        _author = author;
        _title = title;
        _genre = genre;
        _price = price;
        _publish_date = publish_date;
        _description = description;
    }

    public override string ID()
    {
        return _id;
    }

    public override string Title()
    {
        return _title;
    }

    public override string Author()
    {
        return _author;
    }

     public override string Genre()
    {
        return _genre;
    }
    public override string Price()
    {
        return _price;
    }
    public override string Publish_Date()
    {
        return _publish_date;
    }
    public override string Description()
    {
        return _description;
    }
}
}
// </Snippet1>