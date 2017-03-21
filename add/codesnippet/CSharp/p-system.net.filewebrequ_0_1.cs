                // Set the ContentLength property.
                myFileWebRequest.ContentLength = byteArray.Length;

                string contentLength = myFileWebRequest.ContentLength.ToString ();

                Console.WriteLine ("\nThe content length is {0}.", contentLength);
