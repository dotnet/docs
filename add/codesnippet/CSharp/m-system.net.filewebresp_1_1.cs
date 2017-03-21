            Uri fileUrl = new Uri("file://"+url);
            // Create a 'FileWebrequest' object with the specified Uri. 
            FileWebRequest myFileWebRequest = (FileWebRequest)WebRequest.Create(fileUrl);
            // Send the 'FileWebRequest' object and wait for response. 
            FileWebResponse myFileWebResponse = (FileWebResponse)myFileWebRequest.GetResponse();
                        
            // Get the stream object associated with the response object.
            Stream receiveStream = myFileWebResponse.GetResponseStream();
            
            Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
            // Pipe the stream to a higher level stream reader with the required encoding format. 
            StreamReader readStream = new StreamReader( receiveStream, encode );
            Console.WriteLine("\r\nResponse stream received");
    
            Char[] read = new Char[256];
            // Read 256 characters at a time.    
            int count = readStream.Read( read, 0, 256 );
            Console.WriteLine("File Data...\r\n");
            while (count > 0) 
            {
                // Dump the 256 characters on a string and display the string onto the console.
                String str = new String(read, 0, count);
                Console.Write(str);
                count = readStream.Read(read, 0, 256);
            }
            Console.WriteLine("");
            // Release resources of stream object.
            readStream.Close();
            // Release resources of response object.
            myFileWebResponse.Close();