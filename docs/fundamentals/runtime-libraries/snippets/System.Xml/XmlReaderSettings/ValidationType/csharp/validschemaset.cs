// <Snippet1>
using System;
using System.Xml;
using System.Xml.Schema;
using System.IO;

public class Sample
{
  public static void Main() {

    // Create the XmlSchemaSet class.
    XmlSchemaSet sc = new XmlSchemaSet();

    // Add the schema to the collection.
    sc.Add("urn:bookstore-schema", "books.xsd");

    // Set the validation settings.
    XmlReaderSettings settings = new XmlReaderSettings();
    settings.ValidationType = ValidationType.Schema;
    settings.Schemas = sc;
    settings.ValidationEventHandler += ValidationCallBack;

    // Create the XmlReader object.
    XmlReader reader = XmlReader.Create("booksSchemaFail.xml", settings);

    // Parse the file.
    while (reader.Read());
  }

  // Display any validation errors.
  private static void ValidationCallBack(object sender, ValidationEventArgs e) {
    Console.WriteLine($"Validation Error:\n   {e.Message}\n");
  }
}
// The example displays output like the following:
//   Validation Error:
//        The element 'book' in namespace 'urn:bookstore-schema' has invalid child element 'author'
//        in namespace 'urn:bookstore-schema'. List of possible elements expected: 'title' in
//        namespace 'urn:bookstore-schema'.
//
//    Validation Error:
//       The element 'author' in namespace 'urn:bookstore-schema' has invalid child element 'name'
//       in namespace 'urn:bookstore-schema'. List of possible elements expected: 'first-name' in
//       namespace 'urn:bookstore-schema'.
// </Snippet1>