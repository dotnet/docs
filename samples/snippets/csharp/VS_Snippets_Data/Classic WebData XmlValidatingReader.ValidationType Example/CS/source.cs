// <Snippet1>
using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;

public class Sample
{
  private const String doc1 = "notValid.xml";
  private const String doc2 = "cdDTD.xml";
  private const String doc3 = "book1.xml";

  private XmlTextReader txtreader = null;
  private XmlValidatingReader reader = null;
  private Boolean m_success = true;

  public Sample ()
  {
      //Parse the files and validate when requested.
      Validate(doc1, ValidationType.XDR);  //Validation should fail.
      Validate(doc2, ValidationType.DTD);  //Validation should fail.
      Validate(doc3, ValidationType.None); //No validation performed.

  }    

  public static void Main ()
  {
      Sample validation = new Sample();
  }

  private void Validate(String filename, ValidationType vt)
  {
    try
    {    
        //Implement the readers.  Set the ValidationType.
        txtreader = new XmlTextReader(filename);
        reader = new XmlValidatingReader(txtreader);
        reader.ValidationType = vt;

        //If the reader is set to validate, set the event handler.
        if (vt==ValidationType.None)
           Console.WriteLine("\nParsing XML file " + filename.ToString());
        else{
           Console.WriteLine("\nValidating XML file " + filename.ToString());
           m_success = true;
           //Set the validation event handler.
           reader.ValidationEventHandler += new ValidationEventHandler (ValidationCallBack);
        }

        // Read XML data
        while (reader.Read()){}

        if (vt==ValidationType.None)
           Console.WriteLine("Finished parsing file.");
        else
          Console.WriteLine ("Validation finished. Validation {0}", (m_success==true ? "successful" : "failed"));
     }

     finally
     {
        //Close the reader.
        if (reader != null)
          reader.Close();
     } 

  }
  
  //Display the validation errors.
  private void ValidationCallBack (object sender, ValidationEventArgs args)
  {
     m_success = false;

     Console.Write("\r\n\tValidation error: " + args.Message);

  }
}
   // </Snippet1>

