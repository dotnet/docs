                    ' Enter the string to write to the file.
                    Console.WriteLine("Enter the string you want to write:")
                    Dim userInput As String = Console.ReadLine()

                    ' Convert the string to a byte array.
                    Dim encoder As New ASCIIEncoding
                    Dim byteArray As Byte() = encoder.GetBytes(userInput)

                    ' Set the ContentLength property.
                    myFileWebRequest.ContentLength = byteArray.Length

                    Dim contentLength As String = myFileWebRequest.ContentLength.ToString()

                    Console.WriteLine(ControlChars.Lf + "The content length is {0}.", contentLength)


                    ' Get the file stream handler to write to the file.
                    Dim readStream As Stream = myFileWebRequest.GetRequestStream()

                    ' Write to the stream. 
                    ' Note. For this to work the file must be accessible
                    ' on the network. This can be accomplished by setting the property
                    ' sharing of the folder containg the file.  
                    ' FileWebRequest.Credentials property cannot be used for this purpose.
                    readStream.Write(byteArray, 0, userInput.Length)


                    Console.WriteLine(ControlChars.Lf + "The String you entered was successfully written to the file.")
