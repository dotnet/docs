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