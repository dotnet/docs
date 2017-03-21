            // Create a web request for "www.msn.com".
             HttpWebRequest myHttpWebRequest = (HttpWebRequest) WebRequest.Create("http://www.msn.com");
            myHttpWebRequest.Timeout = 1000;
            // Get the associated response for the above request.
             HttpWebResponse myHttpWebResponse = (HttpWebResponse) myHttpWebRequest.GetResponse();

            // Get the headers associated with the response.
            WebHeaderCollection myWebHeaderCollection = myHttpWebResponse.Headers;

            for(int i = 0; i < myWebHeaderCollection.Count; i++) {
                String header = myWebHeaderCollection.GetKey(i);
                String[] values = myWebHeaderCollection.GetValues(header);
                if(values.Length > 0) {
                    Console.WriteLine("The values of {0} header are : ", header);
                    for(int j = 0; j < values.Length; j++) 
                        Console.WriteLine("\t{0}", values[j]);
                }
                else
                    Console.WriteLine("There is no value associated with the header");
            }
            myHttpWebResponse.Close();