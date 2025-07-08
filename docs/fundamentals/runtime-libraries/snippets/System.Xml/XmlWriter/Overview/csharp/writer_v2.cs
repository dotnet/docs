using System;
using System.Text;
using System.IO;
using System.Xml;

class Whidbey_Write_Methods
{

    static void Main()
    {

        // WriteQName();
    }

    public static void WriteDateTime()
    {
        //<snippet1>	
        Double price = 9.95;
        DateTime date = new DateTime(2004, 5, 20);

        using (XmlWriter writer = XmlWriter.Create("data.xml"))
        {
            writer.WriteStartElement("book");
            writer.WriteStartAttribute("pub-date");
            writer.WriteValue(date);
            writer.WriteEndAttribute();

            writer.WriteStartElement("price");
            writer.WriteValue(price);
            writer.WriteEndElement();

            writer.WriteEndElement();
            writer.Flush();
        }
        //</snippet1>
    }

    public static void CreateURI()
    {
        //<snippet2>	
        using (XmlWriter writer = XmlWriter.Create("output.xml"))
        {
            writer.WriteStartElement("book");
            writer.WriteElementString("price", "19.95");
            writer.WriteEndElement();
            writer.Flush();
        }

        //</snippet2>
    }

    public static void Create_Console()
    {
        //<snippet3>	
        using (XmlWriter writer = XmlWriter.Create(Console.Out))
        {
            writer.WriteStartElement("book");
            writer.WriteElementString("price", "19.95");
            writer.WriteEndElement();
            writer.Flush();
        }

        //</snippet3>
    }

    public static void Create_StringWriter()
    {
        //<snippet4>	
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.OmitXmlDeclaration = true;
        StringWriter sw = new StringWriter();

        using (XmlWriter writer = XmlWriter.Create(sw, settings))
        {
            writer.WriteStartElement("book");
            writer.WriteElementString("price", "19.95");
            writer.WriteEndElement();
            writer.Flush();

            String output = sw.ToString();
        }

        //</snippet4>
    }

    public static void WriteQName()
    {
        //<snippet5>	
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Indent = true;
        settings.OmitXmlDeclaration = true;
        using (XmlWriter writer = XmlWriter.Create(Console.Out, settings))
        {
            writer.WriteStartElement("root");
            writer.WriteAttributeString("xmlns", "x", null, "urn:abc");
            writer.WriteStartElement("item");
            writer.WriteStartAttribute("href", null);
            writer.WriteString("#");
            writer.WriteQualifiedName("test", "urn:abc");
            writer.WriteEndAttribute();
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
        //</snippet5>
    }

    // # 6 placeholder for XmlQualfieldName.Empty snippet

    public static void GenericCreate()
    {
        //<snippet7>	
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Indent = true;
        settings.IndentChars = ("    ");
        using (XmlWriter writer = XmlWriter.Create("books.xml", settings))
        {
            // Write XML data.
            writer.WriteStartElement("book");
            writer.WriteElementString("price", "19.95");
            writer.WriteEndElement();
            writer.Flush();
        }
        //</snippet7>
    }

    public static void Output1()
    {
        //<snippet8>	
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Indent = true;
        settings.IndentChars = "\t";
        XmlWriter writer = XmlWriter.Create("books.xml", settings);
        //</snippet8>
    }

    public static void Output2()
    {
        //<snippet9>	
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Indent = true;
        settings.NewLineOnAttributes = true;
        XmlWriter writer = XmlWriter.Create("books.xml", settings);
        //</snippet9>
    }

    public static void Attrs1()
    {
        //<snippet10>
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Indent = true;
        using (XmlWriter writer = XmlWriter.Create(Console.Out, settings))
        {
            writer.WriteStartElement("Product");
            writer.WriteAttributeString("supplierID", "A23-1");
            writer.WriteElementString("ProductID", "12345");
            writer.WriteEndElement();
        }
        //</snippet10>
    }

    public static void Attrs2()
    {
        //<snippet11>
        DateTime hireDate = new DateTime(2008, 5, 20);
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Indent = true;
        using (XmlWriter writer = XmlWriter.Create(Console.Out, settings))
        {
            writer.WriteStartElement("Employee");
            writer.WriteStartAttribute("review-date");
            writer.WriteValue(hireDate.AddMonths(6));
            writer.WriteEndAttribute();
            writer.WriteElementString("EmployeeID", "12345");
            writer.WriteEndElement();
        }
	//</snippet11>
    }

    public static void Attrs3()
    {
        //<snippet12>
        XmlReader reader = XmlReader.Create("book.xml");
        reader.ReadToDescendant("book");
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Indent = true;
        using (XmlWriter writer = XmlWriter.Create(Console.Out, settings))
        {

            writer.WriteStartElement("root");
            writer.WriteAttributes(reader, true);
            writer.WriteEndElement();
        }
	//</snippet12>
    }

    public static void Elems1()
    {
        XmlWriter writer = XmlWriter.Create(Console.Out);
        //<snippet13>
        writer.WriteElementString("price", "19.95");
        //</snippet13>
        writer.Flush();
    }

    public static void Elems2()
    {
        XmlWriter writer = XmlWriter.Create(Console.Out);
        //<snippet14>
        writer.WriteStartElement("bk", "book", "urn:books");
        writer.WriteAttributeString("genre", "urn:books", "mystery");
        writer.WriteElementString("price", "19.95");
        writer.WriteEndElement();
        //</snippet14>
        writer.Flush();
    }

    public static void Elems3()
    {
        //<snippet15>
        // Create a reader and position it on the book node.
        XmlReader reader = XmlReader.Create("books.xml");
        reader.ReadToFollowing("book");

        // Write out the book node.
        XmlWriter writer = XmlWriter.Create("newBook.xml");
        writer.WriteNode(reader, true);
        writer.Flush();
        //</snippet15>
    }

    public static void TypedWrite()
    {
        // Create a reader and position it on the book node.
        XmlReader reader = XmlReader.Create("books.xml");
        XmlWriter writer = XmlWriter.Create(Console.Out);
        //<snippet16>
        reader.ReadToDescendant("price");
        writer.WriteStartElement("price");
        writer.WriteValue((reader.ReadElementContentAsDouble()) * 1.15);
        writer.WriteEndElement();
        //</snippet16>
        writer.Flush();
    }

    public static void Namespace1()
    {
        XmlWriter writer = XmlWriter.Create(Console.Out);
        //<snippet17>
        writer.WriteStartElement("root");
        writer.WriteAttributeString("xmlns", "x", null, "urn:1");
        writer.WriteStartElement("item", "urn:1");
        writer.WriteEndElement();
        writer.WriteStartElement("item", "urn:1");
        writer.WriteEndElement();
        writer.WriteEndElement();
        //</snippet17>
        writer.Flush();
    }

    public static void Namespace2()
    {
        XmlWriter writer = XmlWriter.Create(Console.Out);
        //<snippet18>
        writer.WriteStartElement("x", "root", "123");
        writer.WriteStartElement("item");
        writer.WriteAttributeString("xmlns", "x", null, "abc");
        writer.WriteEndElement();
        writer.WriteEndElement();
        //</snippet18>
        writer.Flush();
    }

    public static void Namespace3()
    {
        XmlWriter writer = XmlWriter.Create(Console.Out);
        //<snippet19>
        writer.WriteStartElement("x", "root", "urn:1");
        writer.WriteStartElement("y", "item", "urn:1");
        writer.WriteEndElement();
        writer.WriteEndElement();
        //</snippet19>
        writer.Flush();
    }
} // end class.
