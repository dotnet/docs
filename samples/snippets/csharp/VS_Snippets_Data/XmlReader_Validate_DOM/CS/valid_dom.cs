//<snippet1>
using System;
using System.Xml;
using System.Xml.Schema;
using System.IO;

public class Sample {

  public static void Main() {

    // Create and load the XML document.
    XmlDocument doc = new XmlDocument();
    doc.Load("booksSchema.xml");

    // Make changes to the document.
    XmlElement book = (XmlElement) doc.DocumentElement.FirstChild;
    book.SetAttribute("publisher", "Worldwide Publishing");

    // Create an XmlNodeReader using the XML document.
    XmlNodeReader nodeReader = new XmlNodeReader(doc);

    // Set the validation settings on the XmlReaderSettings object.
    XmlReaderSettings settings = new XmlReaderSettings();
    settings.ValidationType = ValidationType.Schema;
    settings.Schemas.Add("urn:bookstore-schema", "books.xsd");
    settings.ValidationEventHandler += new ValidationEventHandler (ValidationCallBack);

   // Create a validating reader that wraps the XmlNodeReader object.
   XmlReader reader = XmlReader.Create(nodeReader, settings);
    
   // Parse the XML file.
   while (reader.Read());
  }

  // Display any validation errors.
  private static void ValidationCallBack(object sender, ValidationEventArgs e) {
    Console.WriteLine("Validation Error: {0}", e.Message);
  }
}
//</snippet1>
