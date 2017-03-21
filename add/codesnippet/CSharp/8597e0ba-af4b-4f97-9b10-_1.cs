            Console.Write("\nPlease enter the URI to post data to : ");
            string uriString = Console.ReadLine();

            // Create a new WebClient instance.
            WebClient myWebClient = new WebClient();

            // Create a new NameValueCollection instance to hold some custom parameters to be posted to the URL.
            NameValueCollection myNameValueCollection = new NameValueCollection();
            
            Console.WriteLine("Please enter the following parameters to be posted to the URL");
            Console.Write("Name:");
            string name = Console.ReadLine();

            Console.Write("Age:");
            string age = Console.ReadLine();

            Console.Write("Address:");
            string address = Console.ReadLine();

            // Add necessary parameter/value pairs to the name/value container.
            myNameValueCollection.Add("Name",name);            
            myNameValueCollection.Add("Address",address);
            myNameValueCollection.Add("Age",age);

            Console.WriteLine("\nUploading to {0} ...",  uriString);
            // 'The Upload(String,NameValueCollection)' implicitly method sets HTTP POST as the request method.            
            byte[] responseArray = myWebClient.UploadValues(uriString,myNameValueCollection);
            
            // Decode and display the response.
            Console.WriteLine("\nResponse received was :\n{0}",Encoding.ASCII.GetString(responseArray));