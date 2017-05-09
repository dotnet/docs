// <Snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample
{
  public static void Main()
  {
    XmlValidatingReader reader = null;
    XmlTextReader txtreader = null;

    try
    {           
        //Create the validating reader.
        txtreader = new XmlTextReader("http://localhost/uri.xml");
        reader = new XmlValidatingReader(txtreader);
        reader.ValidationType = ValidationType.None;

        //Parse the file and display the base URI for each node.
        while (reader.Read())
        {
            Console.WriteLine("({0}) {1}", reader.NodeType, reader.BaseURI);
         }           
     }

     finally
     {
       if (reader!=null)
         reader.Close();
     }
  }
} // End class
   // </Snippet1>

