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