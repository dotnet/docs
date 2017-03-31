//<snippet1>
using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;

public class Sample
{

  public static void Main (){

    //Create the schema collection.
    XmlSchemaCollection xsc = new XmlSchemaCollection();

    //Set an event handler to manage invalid schemas.
    xsc.ValidationEventHandler += new ValidationEventHandler (ValidationCallBack);

    //Add the schema to the collection.  
    xsc.Add(null, "invalid.xsd");

  }    

  //Display the schema error information.
  private static void ValidationCallBack (object sender, ValidationEventArgs args){
     Console.WriteLine("Invalid XSD schema: " + args.Exception.Message);
  }  
}
//</snippet1>



