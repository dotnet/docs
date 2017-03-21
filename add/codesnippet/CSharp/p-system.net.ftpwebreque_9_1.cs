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