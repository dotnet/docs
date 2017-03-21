                    ' Set the ContentLength property.
                    myFileWebRequest.ContentLength = byteArray.Length

                    Dim contentLength As String = myFileWebRequest.ContentLength.ToString()

                    Console.WriteLine(ControlChars.Lf + "The content length is {0}.", contentLength)
