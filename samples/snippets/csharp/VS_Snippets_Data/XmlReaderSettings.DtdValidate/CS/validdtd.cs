//<snippet1>
using System;
using System.Xml;
using System.Xml.Schema;
using System.IO;

public class Sample {

  public static void Main() {

    // Set the validation settings.
    XmlReaderSettings settings = new XmlReaderSettings();
    settings.DtdProcessing = DtdProcessing.Parse;
    settings.ValidationType = ValidationType.DTD;
    settings.ValidationEventHandler += new ValidationEventHandler (ValidationCallBack);
 
    // Create the XmlReader object.
    XmlReader reader = XmlReader.Create("itemDTD.xml", settings);


    // Parse the file. 
    while (reader.Read());
    
  }

  // Display any validation errors.
  private static void ValidationCallBack(object sender, ValidationEventArgs e) {
    Console.WriteLine("Validation Error: {0}", e.Message);
  }
}
//</snippet1>
