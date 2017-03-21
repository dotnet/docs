        ' Initialize the WebRequest.
        Dim myRequest As WebRequest = WebRequest.Create("http://www.contoso.com")
        
        ' Return the response. 
        Dim myResponse As WebResponse = myRequest.GetResponse()
        
        ' Code to use the WebResponse goes here.
        ' Close the response to free resources.
        myResponse.Close()
