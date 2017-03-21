

            ' Set the 'ContentType' property of the WebRequest.
            myWebRequest.ContentType = "application/x-www-form-urlencoded"

            ' Set the 'ContentLength' property of the WebRequest.
            myWebRequest.ContentLength = byteArray.Length
            Dim newStream As Stream = myWebRequest.GetRequestStream()
            newStream.Write(byteArray, 0, byteArray.Length)

            ' Close the Stream object.
            newStream.Close()

            ' Assign the response object of 'WebRequest' to a 'WebResponse' variable.
            Dim myWebResponse As WebResponse = myWebRequest.GetResponse()
