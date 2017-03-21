                // Enter the string to write to the file.
                Console.WriteLine ("Enter the string you want to write:");

                string userInput = Console.ReadLine ();

                // Convert the string to a byte array.
                ASCIIEncoding encoder = new ASCIIEncoding ();
                byte[] byteArray = encoder.GetBytes (userInput);

                // Set the ContentLength property.
                myFileWebRequest.ContentLength = byteArray.Length;

                string contentLength = myFileWebRequest.ContentLength.ToString ();

                Console.WriteLine ("\nThe content length is {0}.", contentLength);

                // Get the file stream handler to write to the file.
                Stream readStream = myFileWebRequest.GetRequestStream ();

                // Write to the file stream. 
                // Note.  For this to work, the file must be accessible
                // on the network. This can be accomplished by setting the property
                // sharing of the folder containg the file. 
                // FileWebRequest.Credentials property cannot be used for this purpose.
                readStream.Write (byteArray, 0, userInput.Length);
                Console.WriteLine ("\nThe String you entered was successfully written to the file.");
