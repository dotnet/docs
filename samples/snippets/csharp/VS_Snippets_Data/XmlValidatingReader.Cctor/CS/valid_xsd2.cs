//<snippet1>
using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;

public class Sample
{

  private Boolean m_success = true;

  public Sample ()
  {
      //Validate the document using an external XSD schema.  Validation should fail.
      Validate("notValidXSD.xml"); 

      //Validate the document using an inline XSD. Validation should succeed.
      Validate("inlineXSD.xml");
  }    

  public static void Main ()
  {
      Sample validation = new Sample();
  }

  private void Validate(String filename)
  {    
      m_success = true;
      Console.WriteLine("\r\n******");
      Console.WriteLine("Validating XML file " + filename.ToString());
      XmlTextReader txtreader = new XmlTextReader (filename);
      XmlValidatingReader reader = new XmlValidatingReader (txtreader);

      // Set the validation event handler
      reader.ValidationEventHandler += new ValidationEventHandler (ValidationCallBack);

      // Read XML data
      while (reader.Read()){}
      Console.WriteLine ("Validation finished. Validation {0}", (m_success==true ? "successful!" : "failed."));

      //Close the reader.
      reader.Close();
  }

  //Display the validation error.
  private void ValidationCallBack (object sender, ValidationEventArgs args)
  {
     m_success = false;
     Console.WriteLine("\r\n\tValidation error: " + args.Message );
  }
}
//</snippet1>