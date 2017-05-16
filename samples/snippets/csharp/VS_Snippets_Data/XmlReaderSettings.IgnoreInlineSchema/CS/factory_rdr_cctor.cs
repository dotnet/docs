//<snippet1>
using System;
using System.Xml;
using System.Xml.Schema;
using System.IO;

public class ValidXSD {

  public static void Main() {

    // Set the validation settings.
    XmlReaderSettings settings = new XmlReaderSettings();
    settings.ValidationType = ValidationType.Schema;
    settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
    settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
    settings.ValidationEventHandler += new ValidationEventHandler (ValidationCallBack);

    // Create the XmlReader object.
    XmlReader reader = XmlReader.Create("inlineSchema.xml", settings);

    // Parse the file. 
    while (reader.Read());
    
  }

  // Display any warnings or errors.
  private static void ValidationCallBack (object sender, ValidationEventArgs args) {
     if (args.Severity==XmlSeverityType.Warning)
       Console.WriteLine("\tWarning: Matching schema not found.  No validation occurred." + args.Message);
     else
        Console.WriteLine("\tValidation error: " + args.Message);

  }  

}
//</snippet1>
