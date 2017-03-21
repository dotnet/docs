            // Create a new WebClient instance.
            WebClient myWebClient = new WebClient();

            // Set the BaseAddress of the Web Resource in the WebClient.
            myWebClient.BaseAddress = hostUri;
            Console.WriteLine("Downloading from " + hostUri + "/" + uriSuffix);
            Console.WriteLine("\nPress Enter key to continue");
            Console.ReadLine();	

            // Download the target Web Resource into a byte array.
            byte[] myDatabuffer = myWebClient.DownloadData (uriSuffix);

            // Display the downloaded data.
            string download = Encoding.ASCII.GetString(myDatabuffer);
            Console.WriteLine(download);

            Console.WriteLine("Download of " + myWebClient.BaseAddress.ToString() + uriSuffix + " was successful.");