        // Command line arguments are two strings:
        // 1. The url that is the name of the file being uploaded to the server.
        // 2. The name of the file on the local machine.
        //
        public static void Main(string[] args)
        {
            // Create a Uri instance with the specified URI string.
            // If the URI is not correctly formed, the Uri constructor
            // will throw an exception.
            ManualResetEvent waitObject;
            
            Uri target = new Uri (args[0]);
            string fileName = args[1];
            FtpState state = new FtpState();
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(target);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            
            // This example uses anonymous logon.
            // The request is anonymous by default; the credential does not have to be specified. 
            // The example specifies the credential only to
            // control how actions are logged on the server.
            
            request.Credentials = new NetworkCredential ("anonymous","janeDoe@contoso.com");
            
            // Store the request in the object that we pass into the
            // asynchronous operations.
            state.Request = request;
            state.FileName = fileName;
            
            // Get the event to wait on.
            waitObject = state.OperationComplete;
            
            // Asynchronously get the stream for the file contents.
            request.BeginGetRequestStream(
                new AsyncCallback (EndGetStreamCallback), 
                state
            );
            
            // Block the current thread until all operations are complete.
            waitObject.WaitOne();
            
            // The operations either completed or threw an exception.
            if (state.OperationException != null)
            {
                throw state.OperationException;
            }
            else
            {
                Console.WriteLine("The operation completed - {0}", state.StatusDescription);
            }
        }