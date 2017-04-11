/* 
   System.Net.HttpWebRequest.Method,System.Net.HttpWebRequest.ContentLength,System.Net.HttpWebRequest.ContentType
    System.Net.HttpWebRequest.GetRequestStream
    This program demonstrates 'Method', 'ContentLength' and 'ContentType' properties and 'GetRequestStream'
   method of HttpWebRequest Class.
   It creates a 'HttpWebRequest' object.The 'Method' property of 'HttpWebRequestClass' is set to 'POST'.
   The 'ContentType' property is set to 'application/x-www-form-urlencoded'.The 'ContentLength' property 
   is set to the length of the Byte stream to be posted.A new 'Stream' object is obtained from the 
   'GetRequestStream' method of the 'HttpWebRequest' class. Data to be posted is requested from the user.
   Data is posted using the stream object.The HTML contents of the page are then displayed to the console 
   after the Posted data is accepted by the URL.
    Note: This program POSTs data to the Uri: http://www20.Brinkster.com/codesnippets/next.asp 
    
*/
using System;
using System.IO;
using System.Net;
using System.Text;

class HttpWebRequest_ContentLength
{
    static void Main ()
    {
        try
        {
            // Create a new WebRequest Object to the mentione Uri.                
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create ("http://www.contoso.com/codesnippets/next.asp");

            Console.WriteLine ("\nThe value of 'ContentLength' property before sending the data is {0}", myHttpWebRequest.ContentLength);

// <Snippet1>
// <Snippet4>
            // Set the 'Method' property of the 'Webrequest' to 'POST'.
            myHttpWebRequest.Method = "POST";
            Console.WriteLine ("\nPlease enter the data to be posted to the (http://www.contoso.com/codesnippets/next.asp) Uri :");

            // Create a new string object to POST data to the Url.
            string inputData = Console.ReadLine ();

// <Snippet2>
// <Snippet3>

            string postData = "firstone=" + inputData;
            ASCIIEncoding encoding = new ASCIIEncoding ();
            byte[] byte1 = encoding.GetBytes (postData);

            // Set the content type of the data being posted.
            myHttpWebRequest.ContentType = "application/x-www-form-urlencoded";

            // Set the content length of the string being posted.
            myHttpWebRequest.ContentLength = byte1.Length;

            Stream newStream = myHttpWebRequest.GetRequestStream ();

            newStream.Write (byte1, 0, byte1.Length);
            Console.WriteLine ("The value of 'ContentLength' property after sending the data is {0}", myHttpWebRequest.ContentLength);

            // Close the Stream object.
            newStream.Close ();

// </Snippet4>
// </Snippet3>
// </Snippet2>
// </Snippet1>
            Console.WriteLine ("\nThe string entered is successfully posted to the  Uri ");
            Console.WriteLine ("Please wait for the response.......");

            // Assign the response object of 'HttpWebRequest' to a 'HttpWebResponse' variable.
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse ();
            Stream streamResponse = myHttpWebResponse.GetResponseStream ();
            StreamReader streamRead = new StreamReader (streamResponse);
            Char[] readBuff = new Char[256];
            int count = streamRead.Read (readBuff, 0, 256);

            Console.WriteLine ("\nThe contents of the HTML page are :  ");
            while (count > 0)
            {
                String outputData = new String (readBuff, 0, count);

                Console.WriteLine (outputData);
                count = streamRead.Read (readBuff, 0, 256);
            }

            // Close the Stream object.
            streamResponse.Close ();
            streamRead.Close ();

            // Release the resources held by  response object.
            myHttpWebResponse.Close ();
            Console.WriteLine ("\nPress 'Enter' Key to Continue.............");
            Console.Read ();
        }
        catch (WebException e)
        {
            Console.WriteLine ("WebException raised!");
            Console.WriteLine ("\n{0}", e.Message);
            Console.WriteLine ("\n{0}", e.Status);
        }
        catch (Exception e)
        {
            Console.WriteLine ("Exception raised!");
            Console.WriteLine ("Source : " + e.Source);
            Console.WriteLine ("Message : " + e.Message);
        }
    }
}

