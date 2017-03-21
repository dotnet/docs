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