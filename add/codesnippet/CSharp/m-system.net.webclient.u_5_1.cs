            Console.Write("\nPlease enter the URL to post data to : ");
            String uriString = Console.ReadLine();

            // Create a new WebClient instance.
            WebClient myWebClient = new WebClient();

            Console.WriteLine("\nPlease enter the fully qualified path of the file to be uploaded to the URL");
            string fileName = Console.ReadLine();

            Console.WriteLine("Uploading {0} to {1} ...",fileName,uriString);						
            // Upload the file to the URL using the HTTP 1.0 POST.
            byte[] responseArray = myWebClient.UploadFile(uriString,"POST",fileName);

            // Decode and display the response.
            Console.WriteLine("\nResponse Received.The contents of the file uploaded are:\n{0}",
                System.Text.Encoding.ASCII.GetString(responseArray));
