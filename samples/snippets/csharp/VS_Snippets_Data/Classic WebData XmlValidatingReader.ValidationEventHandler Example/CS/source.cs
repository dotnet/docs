// <Snippet1>
using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;

public class Sample
{

  private XmlTextReader txtreader = null;
  private XmlValidatingReader reader = null;
  private Boolean m_success = true;

  public Sample ()
  {
        //Validate file against the XSD schema. 
        //The validation should fail.
        Validate("notValidXSD.xml"); 
  }    

  public static void Main ()
  {
      Sample validation = new Sample();
  }

  private void Validate(String filename)
  {    
     try
     {
        Console.WriteLine("Validating XML file " + filename.ToString());
        txtreader = new XmlTextReader (filename);
        reader = new XmlValidatingReader (txtreader);

        // Set the validation event handler
        reader.ValidationEventHandler += new ValidationEventHandler (this.ValidationEventHandle);

        // Read XML data
        while (reader.Read()){}
        Console.WriteLine ("Validation finished. Validation {0}", (m_success==true ? "successful" : "failed"));
     }

     finally
     {
        //Close the reader.
        if (reader != null)
          reader.Close();
     } 
  }

  //Display the validation error.
  private void ValidationEventHandle (object sender, ValidationEventArgs args)
  {
     m_success = false;
     Console.WriteLine("\r\n\tValidation error: " + args.Message );
  }
}
   // </Snippet1>

