   
	    'This method creates a new HttpWebRequest Object to the mentioned URL.
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create("http://www.contoso.com"), HttpWebRequest)
            myHttpWebRequest.MaximumAutomaticRedirections = 1
            myHttpWebRequest.AllowAutoRedirect = True
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)