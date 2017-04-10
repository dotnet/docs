// <Internal>
// This program contains examples for the following types and methods:
// System.Net.FileWebRequest (Snippet1); System.Net.FileWebRequest.Method (Snippet2); 
// System.Net.FileWebRequest.Timeout (Snippet3); 
// System.Net.FileWebRequest.ContentLength (Snippet4).
// System.Net.FileWebRequest.GetRequestStream (Snippet5);
// </Internal>
// <Snippet1>
// This example creates or opens a text file and stores a string in it. 
// Both the file and the string are passed by the user.
// Note. For this program to work, the folder containing the test file
// must be shared, with its permissions set to allow write access. 
using System.Net;
using System;
using System.IO;
using System.Text;

namespace Mssc.PluggableProtocols.File
{
    class TestGetRequestStream
    {
        private static FileWebRequest myFileWebRequest;

        private static void showUsage ()
        {
            Console.WriteLine ("\nPlease enter file name and timeout :");
            Console.WriteLine ("Usage: cs_getrequeststream <systemname>/<sharedfoldername>/<filename> timeout");
            Console.WriteLine ("Example: cs_getrequeststream ngetrequestrtream() ndpue/temp/hello.txt  1000");
            Console.WriteLine ("Small time-out values (for example, 3 or less) cause a time-out exception.");
        }

        private static void makeFileRequest (string fileName, int timeout)
        {
            try
            {
// <Snippet2>
// <Snippet3>
                // Create a Uri object. 
                Uri myUrl = new Uri ("file://" + fileName);

                // Create a FileWebRequest object.
                myFileWebRequest = (FileWebRequest)WebRequest.CreateDefault (myUrl);

                // Set the time-out to the value selected by the user.
                myFileWebRequest.Timeout = timeout;

// </Snippet3>
                // Set the Method property to POST  
                myFileWebRequest.Method = "POST";
// </Snippet2>
            }
            catch (WebException e)
            {
                Console.WriteLine ("WebException: " + e.Message);
            }
            catch (UriFormatException e)
            {
                Console.WriteLine ("UriFormatWebException: " + e.Message);
            }
        }

        private static void writeToFile ()
        {
            try
            {
// <Snippet5>
                // Enter the string to write to the file.
                Console.WriteLine ("Enter the string you want to write:");

                string userInput = Console.ReadLine ();

                // Convert the string to a byte array.
                ASCIIEncoding encoder = new ASCIIEncoding ();
                byte[] byteArray = encoder.GetBytes (userInput);

// <Snippet4>
                // Set the ContentLength property.
                myFileWebRequest.ContentLength = byteArray.Length;

                string contentLength = myFileWebRequest.ContentLength.ToString ();

                Console.WriteLine ("\nThe content length is {0}.", contentLength);

// </Snippet4>
                // Get the file stream handler to write to the file.
                Stream readStream = myFileWebRequest.GetRequestStream ();

                // Write to the file stream. 
                // Note.  For this to work, the file must be accessible
                // on the network. This can be accomplished by setting the property
                // sharing of the folder containg the file. 
                // FileWebRequest.Credentials property cannot be used for this purpose.
                readStream.Write (byteArray, 0, userInput.Length);
                Console.WriteLine ("\nThe String you entered was successfully written to the file.");

// </Snippet5>
                readStream.Close ();
            }
            catch (WebException e)
            {
                Console.WriteLine ("The WebException: " + e.Message);
            }
            catch (UriFormatException e)
            {
                Console.WriteLine ("The UriFormatWebException: " + e.Message);
            }
        }

        public static void Main (String[] args)
        {
            if (args.Length < 2)
                showUsage ();
            else
            {
                makeFileRequest (args[0], int.Parse (args[1]));
                writeToFile ();
            }
        }
    }
}
// </Snippet1>  