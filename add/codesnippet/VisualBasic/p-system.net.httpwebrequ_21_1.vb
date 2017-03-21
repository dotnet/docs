            ' Create a 'HttpWebRequest' object.
            Dim myHttpWebRequest As HttpWebRequest = WebRequest.Create(myUri)
            ' Set the 'Accept' property to accept an image of any type.
            myHttpWebRequest.Accept = "image/*"
            ' The response object of 'HttpWebRequest' is assigned to a 'HttpWebResponse' variable.
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)