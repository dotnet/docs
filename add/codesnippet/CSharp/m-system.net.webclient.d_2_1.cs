            Console.Write("\nPlease enter a URI (for example, http://www.contoso.com): ");
            string remoteUri = Console.ReadLine();

            // Create a new WebClient instance.
            WebClient myWebClient = new WebClient();
            // Download home page data.
            Console.WriteLine("Downloading " + remoteUri);                        
            // Download the Web resource and save it into a data buffer.
            byte[] myDataBuffer = myWebClient.DownloadData (remoteUri);

            // Display the downloaded data.
            string download = Encoding.ASCII.GetString(myDataBuffer);
            Console.WriteLine(download);
                                
            Console.WriteLine("Download successful.");