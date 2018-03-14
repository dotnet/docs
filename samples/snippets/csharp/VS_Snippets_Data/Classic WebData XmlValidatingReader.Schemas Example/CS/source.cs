// <Snippet1>
 using System;
 using System.IO;
 using System.Xml;
 using System.Xml.Schema;
 
 public class SchemaCollectionSample
 {
   private const String doc1 = "booksSchema.xml";
   private const String doc2 = "booksSchemaFail.xml";
   private const String doc3 = "newbooks.xml";
   private const String schema = "books.xsd";
   private const String schema1 = "schema1.xdr";
   
   private XmlTextReader reader=null;
   private XmlValidatingReader vreader = null;
   private Boolean m_success = true;
 
   public SchemaCollectionSample ()
   {
     //Load the schema collection.
     XmlSchemaCollection xsc = new XmlSchemaCollection();
     xsc.Add("urn:bookstore-schema", schema);  //XSD schema
     xsc.Add("urn:newbooks-schema", schema1);  //XDR schema
 
     //Validate the files using schemas stored in the collection.
     Validate(doc1, xsc); //Should pass.
     Validate(doc2, xsc); //Should fail.   
     Validate(doc3, xsc); //Should fail. 
 
   }    
 
   public static void Main ()
   {
       SchemaCollectionSample validation = new SchemaCollectionSample();
   }
 
   private void Validate(String filename, XmlSchemaCollection xsc)
   {
    
      m_success = true;
      Console.WriteLine();
      Console.WriteLine("Validating XML file {0}...", filename.ToString());
      reader = new XmlTextReader (filename);
         
      //Create a validating reader.
     vreader = new XmlValidatingReader (reader);

      //Validate using the schemas stored in the schema collection.
      vreader.Schemas.Add(xsc);
  
      //Set the validation event handler
      vreader.ValidationEventHandler += new ValidationEventHandler (ValidationCallBack);
      //Read and validate the XML data.
      while (vreader.Read()){}
      Console.WriteLine ("Validation finished. Validation {0}", (m_success==true ? "successful" : "failed"));
      Console.WriteLine();

      //Close the reader.
      vreader.Close();
 
   } 
 
 
   private void ValidationCallBack (object sender, ValidationEventArgs args)
   {
      m_success = false;
 
      Console.Write("\r\n\tValidation error: " + args.Message);

   }  
 }
   // </Snippet1>

