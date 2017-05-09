// <Snippet1>
using System;
using System.IO;
using System.Xml;

public class Sample {

  private const string filename = "binary.xml";

  public static void Main() {

     XmlTextReader reader = null;

     try {
     
        reader = new XmlTextReader(filename);
        reader.WhitespaceHandling = WhitespaceHandling.None;

        // Read the file. Stop at the Base64 element.
        while (reader.Read()) {
           if ("Base64" == reader.Name) break;
        }
        	
        // Read the Base64 data. Write the decoded 
        // bytes to the console.
        Console.WriteLine("Reading Base64... ");
        int base64len = 0;
        byte[] base64 = new byte[1000];
        do {
           base64len = reader.ReadBase64(base64, 0, 50);            
           for (int i=0; i < base64len; i++) Console.Write(base64[i]);
        } while (reader.Name == "Base64");
	
        // Read the BinHex data. Write the decoded 
        // bytes to the console.
        Console.WriteLine("\r\nReading BinHex...");
        int binhexlen = 0;
        byte[] binhex = new byte[1000];
        do {
           binhexlen = reader.ReadBinHex(binhex, 0, 50);            
           for (int i=0; i < binhexlen; i++) Console.Write(binhex[i]);
        }  while (reader.Name == "BinHex");
            
     }

     finally {
        Console.WriteLine();
        Console.WriteLine("Processing of the file {0} complete.", filename);
        if (reader != null)
          reader.Close();
     }
  }
}
   // </Snippet1>

