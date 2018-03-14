using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;
using System.Collections;

class XPathNavigatorProperties
{
	static void Main()
	{
        Console.ReadLine();
    }

    #region CanEdit
    static void XPathNavigatorProperties_CanEdit()
    {
        //<snippet1>
        XPathDocument readOnlyDocument = new XPathDocument("books.xml");
        XPathNavigator readOnlyNavigator = readOnlyDocument.CreateNavigator();

        XmlDocument editableDocument = new XmlDocument();
        editableDocument.Load("books.xml");
        XPathNavigator editableNavigator = editableDocument.CreateNavigator();

        Console.WriteLine("XPathNavigator.CanEdit from XPathDocument: {0}", readOnlyNavigator.CanEdit);
        Console.WriteLine("XPathNavigator.CanEdit from XmlDocument: {0}", editableNavigator.CanEdit);
        //</snippet1>
    }
    #endregion

    #region InnerXml
    static void XPathNavigatorProperties_InnerXml()
    {
		//<snippet2>
        XPathDocument document = new XPathDocument("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books");
        navigator.MoveToChild("book", "http://www.contoso.com/books");

        Console.WriteLine(navigator.InnerXml);
		//</snippet2>
    }
    #endregion

    #region NavigatorComparer
    static void XPathNavigatorProperties_NavigatorComparer()
    {
        //<snippet3>
        XPathDocument document = new XPathDocument("books.xml");
        XPathNavigator navigator = document.CreateNavigator();
        Hashtable table = new Hashtable(XPathNavigator.NavigatorComparer);

        // Add nodes to the Hashtable.
        foreach (XPathNavigator navigator2 in navigator.Select("//book"))
        {
            object value = navigator2.Evaluate("string(./title)");
            table.Add(navigator2.Clone(), value);
            Console.WriteLine("Added book with title {0}", value);
        }

        Console.WriteLine(table.Count);
        Console.WriteLine("Does the Hashtable have the book \"The Confidence Man\"?");
        Console.WriteLine(table.Contains(navigator.SelectSingleNode("//book[title='The Confidence Man']")));
        //</snippet3>
    }
    #endregion

    #region OuterXml
    static void XPathNavigatorProperties_OuterXml()
    {
        //<snippet4>
        XPathDocument document = new XPathDocument("contosoBooks.xml");
        XPathNavigator navigator = document.CreateNavigator();

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books");
        navigator.MoveToChild("book", "http://www.contoso.com/books");

        Console.WriteLine(navigator.OuterXml);
        //</snippet4>
    }
    #endregion

    #region ValueAs
    static void XPathNavigatorProperties_ValueAs()
    {
        //<snippet5>
        XPathDocument document = new XPathDocument("valueas.xml");
        XPathNavigator navigator = document.CreateNavigator();

        // ValueAsBoolean
        navigator.MoveToChild("root", "");
        navigator.MoveToChild("booleanElement", "");
        bool booleanValue = navigator.ValueAsBoolean;
        Console.WriteLine(navigator.LocalName + ": " + booleanValue);

        // ValueAsDateTime
        navigator.MoveToNext("dateTimeElement", "");
        DateTime dateTimeValue = navigator.ValueAsDateTime;
        Console.WriteLine(navigator.LocalName + ": " + dateTimeValue);

        // ValueAsDouble, ValueAsInt32, ValueAsInt64, ValueAsSingle
        navigator.MoveToNext("numberElement", "");
        Double doubleValue = navigator.ValueAsDouble;
        Int32 int32Value = navigator.ValueAsInt;
        Int64 int64Value = navigator.ValueAsLong;
        Console.WriteLine(navigator.LocalName + ": " + doubleValue);
        Console.WriteLine(navigator.LocalName + ": " + int32Value);
        Console.WriteLine(navigator.LocalName + ": " + int64Value);
        //</snippet5>
    }
    #endregion

    #region ValueType
    static void XPathNavigatorProperties_ValueType()
    {
        //<snippet6>
        // Create an XmlReaderSettings object with the contosoBooks.xsd schema.
        XmlReaderSettings settings = new XmlReaderSettings();
        settings.Schemas.Add("http://www.contoso.com/books", "contosoBooks.xsd");
        settings.ValidationType = ValidationType.Schema;

        // Create an XmlReader object with the contosoBooks.xml file and its schema.
        XmlReader reader = XmlReader.Create("contosoBooks.xml", settings);

        XPathDocument document = new XPathDocument(reader);
        XPathNavigator navigator = document.CreateNavigator();

        navigator.MoveToChild("bookstore", "http://www.contoso.com/books");
        navigator.MoveToChild("book", "http://www.contoso.com/books");
        navigator.MoveToChild("price", "http://www.contoso.com/books");

        // Display the current type of the price element.
        Console.WriteLine(navigator.ValueType);

        // Get the value of the price element as a string and display it.
        string price = navigator.ValueAs(typeof(string)) as string;
        Console.WriteLine(price);
        //</snippet6>
    }
    #endregion
}

