                ' Compare the file name and 'RequestUri' is same or not.
                If myFileWebRequest.RequestUri.Equals(myUrl) Then
                    ''GetRequestStream' method returns the stream handler for writing into the file.
                    Dim readStream As Stream = myFileWebRequest.GetRequestStream()
                    ' Write to the stream.
                    readStream.Write(byteArray, 0, userInput.Length)
                    readStream.Close()
                End If

                Console.WriteLine("The String you entered was successfully written into the file.")
                Console.WriteLine((ControlChars.Cr +"The content length sent to the server is " + myFileWebRequest.ContentLength.ToString() + "."))