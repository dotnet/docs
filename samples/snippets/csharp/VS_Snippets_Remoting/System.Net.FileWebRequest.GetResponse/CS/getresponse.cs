// <Internal>
// This program contains examples for the following types and methods:
// System.Net.FileWebRequest.GetResponse;
// </Internal>

// <Snippet1>
//
// This example shows how to use the FileWebRequest.GetResponse method 
// to read and display the contents of a file passed by the user.
// Note.  For this program to work, the folder containing the test file
// must be shared, with its permissions set to allow read access. 

using System;
using System.Net;
using System.IO;

namespace Mssc.PluggableProtocols.File
{
  
  class TestGetResponse
  {
    private static FileWebResponse myFileWebResponse;

    private static void showUsage()
    {
      Console.WriteLine("\nPlease enter file name:");
      Console.WriteLine("Usage: cs_getresponse <systemname>/<sharedfoldername>/<filename>");
    }

    private static bool makeFileRequest(string fileName)
    {
      bool requestOk = false;
      try
      {
        Uri myUrl = new Uri("file://" + fileName);
    
        // Create a FileWebRequest object using the passed URI. 
        FileWebRequest myFileWebRequest = (FileWebRequest)WebRequest.Create(myUrl);

        // Get the FileWebResponse object.
        myFileWebResponse =(FileWebResponse)myFileWebRequest.GetResponse();
        
        requestOk = true;
      }
      catch(WebException e)
      {
        Console.WriteLine("WebException: "+e.Message);
      }
      catch(UriFormatException e)
      {
        Console.WriteLine("UriFormatWebException: "+e.Message);
      }
      
      return requestOk;

    }
    
    private static void readFile()
    {
      try
      {
        // Create the file stream. 
        Stream receiveStream=myFileWebResponse.GetResponseStream();
        
        // Create a reader object to read the file content.
        StreamReader readStream = new StreamReader( receiveStream );
        
        // Create a local buffer for a temporary storage of the 
        // read data.
        char[] readBuffer = new Char[256];
        
        // Read the first 256 bytes.
        int count = readStream.Read( readBuffer, 0, 256 );

        Console.WriteLine("The file content is:");
        Console.WriteLine("");
     
        // Loop to read the remaining data in blocks of 256 bytes
        // and display the data on the console.
        while (count > 0) 
        {
          String str = new String(readBuffer, 0, count);
          Console.WriteLine(str+"\n");
          count = readStream.Read(readBuffer, 0, 256);
        }
 
        readStream.Close();
        
        // Release the response object resources.
        myFileWebResponse.Close();
      
      }
      catch(WebException e)
      {
        Console.WriteLine("The WebException: "+e.Message);
      }
      catch(UriFormatException e)
      {
        Console.WriteLine("The UriFormatException: "+e.Message);
      }
      
    }

    static void Main(string[] args)
    {

      if (args.Length < 1)
        showUsage();
      else
      {
        if (makeFileRequest(args[0])== true)
          readFile();
      }   
    }
  }
}
// </Snippet1>