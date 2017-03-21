       public static void RequestResource(Uri resource)
        {
            // Set policy to send credentials when using HTTPS and basic authentication.

            // Create a new HttpWebRequest object for the specified resource.
            WebRequest request=(WebRequest) WebRequest.Create(resource);
            // Supply client credentials for basic authentication.
            request.UseDefaultCredentials = true;
            request.AuthenticationLevel = AuthenticationLevel.MutualAuthRequired;
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            // Determine mutual authentication was used.
            Console.WriteLine("Is mutually authenticated? {0}", response.IsMutuallyAuthenticated);

             System.Collections.Specialized.StringDictionary spnDictionary = AuthenticationManager.CustomTargetNameDictionary;
            foreach (System.Collections.DictionaryEntry e in spnDictionary)
            {
                Console.WriteLine("Key: {0}  - {1}", e.Key as string, e.Value as string);
            }
            // Read and display the response.
            System.IO.Stream streamResponse = response.GetResponseStream();
            System.IO.StreamReader streamRead = new System.IO.StreamReader(streamResponse);
            string responseString = streamRead.ReadToEnd();
            Console.WriteLine(responseString);
            // Close the stream objects.
            streamResponse.Close();
            streamRead.Close();
            // Release the HttpWebResponse.
            response.Close();
        }
        
/*

The output from this example will differ based on the requested resource
and whether mutual authentication was successful. For the purpose of illustration,
a sample of the output is shown here:

Is mutually authenticated? True
Key: http://server1.someDomain.contoso.com  - HTTP/server1.someDomain.contoso.com

<html>
...
</html>

*/
