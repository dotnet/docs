using System;
using System.Net;
using System.Text;
using System.IO;
using System.Threading;
using System.Security.Cryptography.X509Certificates;
namespace Examples
{
    public class FtpRequestTest
    { 

        // FxCop rule requires a private constructor.
        FtpRequestTest() {}
        //<snippet1>
        public static bool ListFilesOnServer(Uri serverUri)
        {
            // The serverUri should start with the ftp:// scheme.
            if (serverUri.Scheme != Uri.UriSchemeFtp)
            {
                return false;
            }
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(serverUri);
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            
            // Get the ServicePoint object used for this request, and limit it to one connection.
            // In a real-world application you might use the default number of connections (2),
            // or select a value that works best for your application.
            
            ServicePoint sp = request.ServicePoint;
            Console.WriteLine("ServicePoint connections = {0}.", sp.ConnectionLimit);
            sp.ConnectionLimit = 1;
            
            FtpWebResponse response = (FtpWebResponse) request.GetResponse();
             
            // The following streams are used to read the data returned from the server.
            Stream responseStream = null;
            StreamReader readStream = null;
            try
            {
                responseStream = response.GetResponseStream(); 
                readStream = new StreamReader(responseStream, System.Text.Encoding.UTF8);
 
                if (readStream != null)
                {
                    // Display the data received from the server.
                    Console.WriteLine(readStream.ReadToEnd());
                } 
                Console.WriteLine("List status: {0}",response.StatusDescription);            
            }
            finally
            {
                if (readStream != null)
                {
                    readStream.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
            }
           
            return true;
        }
        //</snippet1>

// new content
        //<snippet20>
        public static bool NameListFilesOnServer (Uri serverUri)
        {
            // The serverUri should start with the ftp:// scheme.
            if (serverUri.Scheme != Uri.UriSchemeFtp)
            {
                return false;
            }

            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create (serverUri);

            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            FtpWebResponse response = (FtpWebResponse)request.GetResponse ();

            // The following streams are used to read the data returned from the server.
            Stream responseStream = null;
            StreamReader readStream = null;
            try
            {
                responseStream = response.GetResponseStream ();
                readStream = new StreamReader (responseStream, System.Text.Encoding.UTF8);
                if (readStream != null)
                {
                    // Display the data received from the server.
                    Console.WriteLine (readStream.ReadToEnd ());
                }

                Console.WriteLine ("Status: {0}", response.StatusDescription);
            }
            finally
            {
                if (readStream != null)
                {
                    readStream.Close ();
                }

                if (response != null)
                {
                    response.Close ();
                }
            }
            return true;
        }
        //</snippet20>
        //<snippet21>
        public static bool GetDateTimestampOnServer (Uri serverUri)
        {
            // The serverUri should start with the ftp:// scheme.
            if (serverUri.Scheme != Uri.UriSchemeFtp)
            {
                return false;
            }

            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create (serverUri);
            request.Method = WebRequestMethods.Ftp.GetDateTimestamp;
            FtpWebResponse response = (FtpWebResponse)request.GetResponse ();
            Console.WriteLine ("{0} {1}",serverUri,response.LastModified);

            // The output from this method will vary depending on the 
            // file specified and your regional settings. It is similar to:
            // ftp://contoso.com/Data.txt 4/15/2003 10:46:02 AM
            return true;
        }
        //</snippet21>
        //<snippet22>
        public static bool MakeDirectoryOnServer (Uri serverUri)
        {
            // The serverUri should start with the ftp:// scheme.
            if (serverUri.Scheme != Uri.UriSchemeFtp)
            {
                return false;
            }

            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create (serverUri);
            request.KeepAlive = true;
            request.Method = WebRequestMethods.Ftp.MakeDirectory;
            FtpWebResponse response = (FtpWebResponse)request.GetResponse ();
            Console.WriteLine ("Status: {0}", response.StatusDescription);
            return true;
        }
        //</snippet22>
        //<snippet23>
        public static bool UploadUniqueFileOnServer (Uri serverUri, string fileName)
        {
            // The URI described by serverUri should use the ftp:// scheme.
            // It contains the name of the directory on the server.
            // Example: ftp://contoso.com.
            // 
            // The fileName parameter identifies the file containing the data to be uploaded.

            if (serverUri.Scheme != Uri.UriSchemeFtp)
            {
                return false;
            }
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(serverUri);
            request.Method = WebRequestMethods.Ftp.UploadFileWithUniqueName;
            // Set a time limit for the operation to complete.
            request.Timeout = 600000;
            
            // Copy the file contents to the request stream.
            const int bufferLength = 2048;
            byte[] buffer = new byte[bufferLength];
            int count = 0;
            int readBytes = 0;
            FileStream stream = File.OpenRead(fileName);
            Stream requestStream = request.GetRequestStream();
            do
            {
                readBytes = stream.Read(buffer, 0, bufferLength);
                requestStream.Write(buffer, 0, bufferLength);
                count += readBytes;
            }
            while (readBytes != 0);
            
            Console.WriteLine ("Writing {0} bytes to the stream.", count);
            // IMPORTANT: Close the request stream before sending the request.
            requestStream.Close();
            FtpWebResponse response = (FtpWebResponse) request.GetResponse();
            Console.WriteLine("Upload status: {0}, {1}",response.StatusCode, response.StatusDescription);         
            Console.WriteLine ("File name: {0}", response.ResponseUri);
            response.Close();
            return true;
        }
        //</snippet23>
        //<snippet24>
        public static bool RemoveDirectoryOnServer (Uri serverUri)
        {
            // The serverUri should start with the ftp:// scheme.
            if (serverUri.Scheme != Uri.UriSchemeFtp)
            {
                return false;
            }

            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create (serverUri);
            request.Method = WebRequestMethods.Ftp.RemoveDirectory;
            FtpWebResponse response = (FtpWebResponse)request.GetResponse ();
            Console.WriteLine ("Status: {0}", response.StatusDescription);
            return true;
        }
        //</snippet24>
        //<snippet2>
        public static bool UploadFileToServer(string fileName, Uri serverUri)
        {
            // The URI described by serverUri should use the ftp:// scheme.
            // It contains the name of the file on the server.
            // Example: ftp://contoso.com/someFile.txt.
            // 
            // The fileName parameter identifies the file containing the data to be uploaded.

            if (serverUri.Scheme != Uri.UriSchemeFtp)
            {
                return false;
            }
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(serverUri);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            // Don't set a time limit for the operation to complete.
            request.Timeout = System.Threading.Timeout.Infinite;            
            
            // Copy the file contents to the request stream.
            const int bufferLength = 2048;
            byte[] buffer = new byte[bufferLength];
           
            int count = 0;
            int readBytes = 0;
            FileStream stream = File.OpenRead(fileName);
            Stream requestStream = request.GetRequestStream();
            do
            {
                readBytes = stream.Read(buffer, 0, bufferLength);
                requestStream.Write(buffer, 0, bufferLength);
                count += readBytes;
            }
            while (readBytes != 0);
            
            Console.WriteLine ("Writing {0} bytes to the stream.", count);
            // IMPORTANT: Close the request stream before sending the request.
            requestStream.Close();

            FtpWebResponse response = (FtpWebResponse) request.GetResponse();
            Console.WriteLine("Upload status: {0}, {1}", response.StatusCode, response.StatusDescription);
            
            response.Close();
            return true;
        }
        //</snippet2>
        //<snippet3>
        public static bool AppendFileOnServer(string fileName, Uri serverUri)
        {
            // The URI described by serverUri should use the ftp:// scheme.
            // It contains the name of the file on the server.
            // Example: ftp://contoso.com/someFile.txt. 
            // The fileName parameter identifies the file containing 
            // the data to be appended to the file on the server.
            
            if (serverUri.Scheme != Uri.UriSchemeFtp)
            {
                return false;
            }
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(serverUri);
            request.Method = WebRequestMethods.Ftp.AppendFile;
            
            StreamReader sourceStream = new StreamReader(fileName);
            byte [] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            sourceStream.Close();
            request.ContentLength = fileContents.Length;
 
            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential ("anonymous","janeDoe@contoso.com");
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();
            FtpWebResponse response = (FtpWebResponse) request.GetResponse();
            
            Console.WriteLine("Append status: {0}",response.StatusDescription);
            
            response.Close();  
            return true;
        }
        //</snippet3>
        //<snippet4>
        public static bool DeleteFileOnServer(Uri serverUri)
        {
            // The serverUri parameter should use the ftp:// scheme.
            // It contains the name of the server file that is to be deleted.
            // Example: ftp://contoso.com/someFile.txt.
            // 
            
            if (serverUri.Scheme != Uri.UriSchemeFtp)
            {
                return false;
            }
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(serverUri);
            request.Method = WebRequestMethods.Ftp.DeleteFile;
         
            FtpWebResponse response = (FtpWebResponse) request.GetResponse();
            Console.WriteLine("Delete status: {0}",response.StatusDescription);  
            response.Close();
            return true;
        }
        //</snippet4>
        //<snippet5>
        public static bool DisplayFileFromServer(Uri serverUri)
        {
            // The serverUri parameter should start with the ftp:// scheme.
            if (serverUri.Scheme != Uri.UriSchemeFtp)
            {
                return false;
            }
            // Get the object used to communicate with the server.
            WebClient request = new WebClient();
            
            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential ("anonymous","janeDoe@contoso.com");
            try 
            {
                byte [] newFileData = request.DownloadData (serverUri.ToString());
                string fileString = System.Text.Encoding.UTF8.GetString(newFileData);
                Console.WriteLine(fileString);
            }
            catch (WebException e)
            {
                Console.WriteLine(e.ToString());
            }
            return true;
        }
        //</snippet5>
        //<snippet6>
        // DisplayRequestProperties prints a request's properties.
        // This method should be called after the request is sent to the server.
       
        private static void DisplayRequestProperties(FtpWebRequest request)
        {
        //<snippet14>
            Console.WriteLine("User {0} {1}", 
                request.Credentials.GetCredential(request.RequestUri,"basic").UserName,
                request.RequestUri
            );
        //</snippet14>    
            Console.WriteLine("Request: {0} {1}", 
                request.Method,
                request.RequestUri
            );
        //<snippet15>
            Console.WriteLine("Passive: {0}  Keep alive: {1}  Binary: {2} Timeout: {3}.", 
                request.UsePassive, 
                request.KeepAlive, 
                request.UseBinary,
                request.Timeout == -1 ? "none" : request.Timeout.ToString()
            );
        //</snippet15>  
        //<snippet16>      
            IWebProxy proxy = request.Proxy;
            if (proxy != null)
            {
                Console.WriteLine("Proxy: {0}", proxy.GetProxy(request.RequestUri));
            } 
            else
            {
                Console.WriteLine("Proxy: (none)");
            }
            
            Console.WriteLine("ConnectionGroup: {0}",
                request.ConnectionGroupName == null ? "none" : request.ConnectionGroupName
            );
        //</snippet16>

            Console.WriteLine("Encrypted connection: {0}", 
                request.EnableSsl);

            Console.WriteLine("Method: {0}", request.Method);
        }
        //</snippet6>


        //<snippet7>
        public static bool RestartDownloadFromServer(string fileName, Uri serverUri, long offset)
        {
            // The serverUri parameter should use the ftp:// scheme.
            // It identifies the server file that is to be downloaded
            // Example: ftp://contoso.com/someFile.txt.

            // The fileName parameter identifies the local file.
            //The serverUri parameter identifies the remote file.
            // The offset parameter specifies where in the server file to start reading data.
            
            if (serverUri.Scheme != Uri.UriSchemeFtp)
            {
                return false;
            }
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(serverUri);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.ContentOffset = offset;
            FtpWebResponse response = null;
            try 
            {
                response = (FtpWebResponse) request.GetResponse();
            }
            catch (WebException e)
            {
                Console.WriteLine (e.Status);
                Console.WriteLine (e.Message);
                return false;
            }
            // Get the data stream from the response.
            Stream newFile = response.GetResponseStream();
            // Use a StreamReader to simplify reading the response data.
            StreamReader reader  = new StreamReader(newFile);
            string newFileData = reader.ReadToEnd();
            // Append the response data to the local file
            // using a StreamWriter.
            StreamWriter writer = File.AppendText(fileName);
            writer.Write(newFileData);
            // Display the status description.

            // Cleanup.
            writer.Close();
            reader.Close();
            response.Close();
            Console.WriteLine("Download restart - status: {0}",response.StatusDescription);
            return true;
        }
        //</snippet7>
        
         // not enabled in M2
        // Sample call: SendCommandToServer("ftp://contoso.com/", "pwd");
        // The output can only return  status information. 
        
        public static bool SendCommandToServer(string serverUri, string command)
        {
            // The serverUri parameter should start with the ftp:// scheme.
            // It contains the name of the file on the server that will be appended.
            // Example: ftp://contoso.com/someFile.txt.
            // 
            // The command parameter identifies the command to send to the server.
            
            if (serverUri.ToLower().StartsWith(Uri.UriSchemeFtp) == false)
            {
                return false;
            }
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(serverUri);
            request.Method = command;
            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential ("anonymous","janeDoe@contoso.com");
            FtpWebResponse response = (FtpWebResponse) request.GetResponse();
            Console.WriteLine("{0} status: {1}",command, response.StatusDescription);  
            
            response.Close();
            return true;
        }
        
        //<snippet9>
        public static bool DownloadFileFromServer(Uri serverUri, string localFileName)
        {
            // The serverUri parameter should start with the ftp:// scheme.
            if (serverUri.Scheme != Uri.UriSchemeFtp)
            {
                return false;
            }
            // Get the object used to communicate with the server.
            // Note that the cast to FtpWebRequest is done only
            // for the purposes of illustration. If your application
            // does not set any properties other than those defined in the
            // System.Net.WebRequest class, you can use the following line instead:
            // WebRequest request = WebRequest.Create(serverUri);
            //
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(serverUri);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            
            FtpWebResponse response = (FtpWebResponse) request.GetResponse();
            
            Stream responseStream = null;
            StreamReader readStream = null;
            StreamWriter writeStream = null;
            try
            {
                responseStream = response.GetResponseStream(); 
                readStream = new StreamReader(responseStream, System.Text.Encoding.UTF8);
                // Display information about the data received from the server.
                Console.WriteLine("Bytes received: {0}",response.ContentLength);   
                 
                Console.WriteLine("Message from server: {0}", response.StatusDescription);
                Console.WriteLine("Resource: {0}", response.ResponseUri);
               
                // Write the bytes received from the server to the local file.
                if (readStream != null)
                {
                    writeStream = new StreamWriter(localFileName, false);
                    writeStream.Write(readStream.ReadToEnd());
                }
            }
            finally
            {
                if (readStream != null)
                {
                    readStream.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
                if (writeStream != null)
                {
                    writeStream.Close();
                }
            }
            return true;
        }
        //</snippet9>

       // Make a request to show the request properties
       public static void GetRequestProperties(Uri serverUri)
      {
           FtpWebRequest request = (FtpWebRequest)WebRequest.Create(serverUri);
           // This example assumes the FTP site uses anonymous logon.
           request.Credentials = new NetworkCredential ("anonymous","janeDoe@contoso.com");
           request.Proxy = new WebProxy();
      
              request.Method = WebRequestMethods.Ftp.DownloadFile;
              DisplayRequestProperties(request);
       }

       //<snippet11>
        public static bool GetFileSizeFromServer(Uri serverUri) 
        {
            // The serverUri parameter should start with the ftp:// scheme.
            if (serverUri.Scheme != Uri.UriSchemeFtp)
            {
                return false;
            }
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(serverUri);
            request.Method = WebRequestMethods.Ftp.GetFileSize;
        
            FtpWebResponse response = (FtpWebResponse) request.GetResponse();
            
            // Display information about the server response.
            Console.WriteLine("size of file: {0}", response.ContentLength);
            
            response.Close();
            return true;
        }
        //</snippet11>
       //<snippet8>
        public static bool ListFilesOnServerSsl(Uri serverUri)
        {
            // The serverUri should start with the ftp:// scheme.
            if (serverUri.Scheme != Uri.UriSchemeFtp)
            {
                return false;
            }
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(serverUri);
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            request.EnableSsl = true;
            
            // Get the ServicePoint object used for this request, and limit it to one connection.
            // In a real-world application you might use the default number of connections (2),
            // or select a value that works best for your application.
            
            ServicePoint sp = request.ServicePoint;
            Console.WriteLine("ServicePoint connections = {0}.", sp.ConnectionLimit);
            sp.ConnectionLimit = 1;
            
            FtpWebResponse response = (FtpWebResponse) request.GetResponse();
             Console.WriteLine("The content length is {0}", response.ContentLength);
            // The following streams are used to read the data returned from the server.
            Stream responseStream = null;
            StreamReader readStream = null;
            try
            {
                responseStream = response.GetResponseStream(); 
                readStream = new StreamReader(responseStream, System.Text.Encoding.UTF8);
 
                if (readStream != null)
                {
                    // Display the data received from the server.
                    Console.WriteLine(readStream.ReadToEnd());
                } 
                Console.WriteLine("List status: {0}",response.StatusDescription);            
            }
            finally
            {
                if (readStream != null)
                {
                    readStream.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
            }
           

                //<snippet12>
            Console.WriteLine("Banner message: {0}", 
                response.BannerMessage);
                //</snippet12>

               //<snippet13>
            Console.WriteLine("Welcome message: {0}", 
                response.WelcomeMessage);
                //</snippet13>

           //<snippet17>
            Console.WriteLine("Exit message: {0}", 
                response.ExitMessage);
            //</snippet17>
            return true;
        }
 
        // </snippet8>
        

        internal static FtpStatusCode WaitForFinalStatus(FtpWebResponse response)
        {
            int status = (int)response.StatusCode;
            // < 200 is undefined or informational messages.
            // 300 and 400 are intermediate and temporary errors respectively.
            // 200- 299 and 500- 599 are final statuses indicating
            // sucess or failure respectively.
            while (status < 200 || (status >= 300 && status < 500))
            {
                Console.Write("{0}. ", status);
                System.Threading.Thread.Sleep(100);
                status = (int)response.StatusCode;
            }
            return response.StatusCode;
        }
/*

// use this Main to test sync snippets. COmment out the mail in the asycn.
        public static void Main(string [] args)
        {
            // tests for snippets:
            // snippet 1  - works m3.3 
             // ListFilesOnServer(new Uri("ftp://sharriso1/")); 
             // snippet 20
            //ListFilesOnServerSsl(new Uri("ftp://sharriso1")); 

            // snippet 20
           // NameListFilesOnServer (new Uri ("ftp://sharriso1")); 

            //snippet 21
             // throws
            //GetDateTimestampOnServer (new Uri ("ftp://sharriso1")); 
            //GetDateTimestampOnServer (new Uri ("ftp://sharriso1/localfile.txt"));


          //snippet 22
          //  MakeDirectoryOnServer (new Uri ("ftp://sharriso1/DirtyDir2"));
          // snippet 24
         //  RemoveDirectoryOnServer (new Uri ("ftp://sharriso1/DirtyDir2"));
           // snippet 23
        //   UploadUniqueFileOnServer (new Uri ("ftp://sharriso1/SherdieDir/"), "alltwos.txt"); 
         //   ListFilesOnServer (new Uri ("ftp://sharriso1")); 
            // snippet 8 - not working 
            //SendCommandToServer("ftp://sharriso1/", "rename localfile.txt loc2.txt");
           
            // new snippet 7
                    // upload is just helper
                    //UploadFileToServer("NCLFtpClient.xml", new Uri("ftp://sharriso1/NCLFtpClient.xml"));
            //   RestartDownloadFromServer("restart.txt", new Uri("ftp://sharriso1/NCLFtpClient2.xml"), 8);
            //        DownloadFileFromServer(new Uri("ftp://sharriso1/onesandtwos.txt"), "downloadedFile0320_1.txt");
                   
                // snippet 11 - works m3.1
             // GetFileSizeFromServer(new Uri("ftp://sharriso1/localfile.txt"));
           
            // snippet 5
            // DisplayFileFromServer(new Uri("ftp://sharriso1/onesandtwos.txt"));
            
            // snippet 2
           // UploadFileToServer("out.txt", new Uri("ftp://sharriso1/out.txt"));
           
           // snippet 3
            // AppendFileOnServer("out.txt", new Uri("ftp://sharriso1/out.txt"));

              //Snippet 4
              //DeleteFileOnServer(new Uri("ftp://sharriso1/out.txt"));
             
            // Snippets 6, 14, 15, and 16
          //  GetRequestProperties(new Uri("ftp://sharriso1/localfile.txt"));

            
            // Snippet 9
          //   DownloadFileFromServer(new Uri("ftp://sharriso1/localFile.txt"), "dlagain.txt");
           
            //AsynchronousUploadFileToServer( "system.pdb","ftp://sharriso1/localFile.pdb");
           // ListFilesOnServer(new Uri("ftp://sharriso1"));
            //DownloadFileFromServer(new Uri("ftp://sharriso1/localFileagain.txt"), "dlagain.txt");
            //UploadPartialFileOnServer("allOnes.txt", "ftp://sharriso1/babyones.txt", 20 );
           // TestCloning();
           
          //  test the async methods 
        //    ManualResetEvent wait = new ManualResetEvent(false);
         //   AsynchronousFtpUpLoader uploader = new AsynchronousFtpUpLoader(wait);
         //   uploader.AsynchronousUploadFileToServer("ftptests.cs", "ftp://sharriso1/ftptests.txt");
           //   wait.WaitOne();

        }  
        */
    }
    /*
        // The RequestState class is the state object used to store the request information
        // during asynchronous operations.
        internal  class RequestState
        {
            internal FtpWebRequest request;
            internal object requestData;
        
            internal RequestState(FtpWebRequest theRequest, object data)
            {
                request = theRequest;
                requestData = data;
            }
        }
       
        */
    
//<snippet10>
public class ApplicationMain
{
    public static void Main()
    {
          ManualResetEvent wait = new ManualResetEvent(false);
          AsynchronousFtpUpLoader uploader = new AsynchronousFtpUpLoader(wait);
          uploader.AllowAbortUpload("out.txt", "ftp://sharriso1/ftptests.txt");
          wait.WaitOne();
          if (uploader.AsyncException != null)
          {
                Console.WriteLine(uploader.AsyncException.ToString());
          }
    }
}
    public class AsynchronousFtpUpLoader
    {
        ManualResetEvent wait;
        FtpWebRequest request;
        byte [] fileContents;
        Exception asyncException = null;
        
        public AsynchronousFtpUpLoader(ManualResetEvent wait)
        {
            this.wait = wait;
        }

        public Exception AsyncException
        {
            get { return asyncException;}
        }
        
        private void EndGetStreamCallback(IAsyncResult ar)
        {
            Stream requestStream = null;
            // End the asynchronous call to get the request stream.
            try
            {
                requestStream = request.EndGetRequestStream(ar);
            } 
            // Return exceptions to the main application thread.
            catch (Exception e)
            {
                Console.WriteLine("Could not get the request stream.");
                asyncException = e;
                wait.Set();
                return;
            }
            // Write the file contents to the request stream.
            requestStream.Write(fileContents, 0, fileContents.Length);
            Console.WriteLine ("Writing {0} bytes to the stream.", fileContents.Length);
            // IMPORTANT: Close the request stream before sending the request.
            requestStream.Close();
        }
   
    
        // The EndGetResponseCallback method  
        // completes a call to BeginGetResponse.
        private void EndGetResponseCallback(IAsyncResult ar)
        {
            FtpWebResponse response = null;
            try 
            {
                response = (FtpWebResponse) request.EndGetResponse(ar);
            }
            // Return exceptions to the main application thread.
            catch (Exception e)
            {
                Console.WriteLine ("Error getting response.");
                asyncException = e;
                wait.Set();
            }
            Console.WriteLine("Upload status: {0}",response.StatusDescription);
            // Signal the application thread that this operation is complete.
            wait.Set();
        }
        internal void AbortRequest(FtpWebRequest request)
        {
            request.Abort();
            Console.WriteLine("Request aborted!");
            wait.Set();
        }
        
       public void AllowAbortUpload(string fileName, string serverUri)
       {
            request = (FtpWebRequest)WebRequest.Create(serverUri);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            // Get the file to be uploaded and convert it to bytes.
            StreamReader sourceStream = new StreamReader(fileName);
            fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            sourceStream.Close();
            // Set the content length to the number of bytes in the file.
            request.ContentLength = fileContents.Length;
            // Asynchronously get the stream for the file contents.
            IAsyncResult ar = request.BeginGetRequestStream(
                new AsyncCallback (EndGetStreamCallback), null);
             while (!ar.IsCompleted)
            {
                Console.WriteLine("Press 'a' to abort writing to the request stream. Press any other key to continue...");
                string input = Console.ReadLine();
                if (input == "a")
                {
                    AbortRequest(request);
                    return;
                }
            }
            Console.WriteLine("Sending the request asynchronously...");
            IAsyncResult responseAR = request.BeginGetResponse(
                new AsyncCallback (EndGetResponseCallback), null);

            while (!responseAR.IsCompleted)
            {
                Console.WriteLine("Press 'a' to abort the upload. Press any other key to continue.");
                string input = Console.ReadLine();
                if (input == "a")
                {
                    AbortRequest(request);
                    return;
                }
            }
        }
        //</snippet10>
    }
      
}
