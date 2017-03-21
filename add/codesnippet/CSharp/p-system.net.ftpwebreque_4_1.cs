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