//<snippet1>
using System;
using System.Xml;
using System.Xml.Schema;
using System.IO;

public class Sample {

  public static void Main() {

    // Create the XmlSchemaSet class.
    XmlSchemaSet sc = new XmlSchemaSet();

    // Add the schema to the collection.
    sc.Add("urn:bookstore-schema", "books.xsd");

    // Set the validation settings.
    XmlReaderSettings settings = new XmlReaderSettings();
    settings.ValidationType = ValidationType.Schema;
    settings.Schemas = sc;
    settings.ValidationEventHandler += new ValidationEventHandler (ValidationCallBack);
 
    // Create the XmlReader object.
    XmlReader reader = XmlReader.Create("booksSchemaFail.xml", settings);

    // Parse the file. 
    while (reader.Read());
    
  }

  // Display any validation errors.
  private static void ValidationCallBack(object sender, ValidationEventArgs e) {
    Console.WriteLine("Validation Error: {0}", e.Message);
  }
}
//</snippet1>