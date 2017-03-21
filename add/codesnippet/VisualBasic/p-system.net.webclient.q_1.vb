            Dim uriString As String = "http://www.contoso.com/search"
            ' Create a new WebClient instance.
            Dim myWebClient As New WebClient()
            ' Create a new NameValueCollection instance to hold the QueryString parameters and values.
            Dim myQueryStringCollection As New NameValueCollection()
            Console.Write(("Enter the word(s), separated by space characters, to search for in " + uriString + ": "))
            ' Read user input phrase to search in uriString.
            Dim searchPhrase As String = Console.ReadLine()
            If searchPhrase.Length > 1 Then
                'Assign the user-defined search phrase.
                myQueryStringCollection.Add("q", searchPhrase)
            ' If error, default to search 'Microsoft'.
            Else
                myQueryStringCollection.Add("q", "Microsoft")
            End If 
            ' Assign auxilliary parameters required for the search.
            Console.WriteLine(("Searching " + uriString + " ......."))
            ' Attach QueryString to the WebClient.
            myWebClient.QueryString = myQueryStringCollection
            ' Download the search results Web page into 'searchresult.htm' for inspection.
            myWebClient.DownloadFile(uriString, "searchresult.htm")
            Console.WriteLine((ControlChars.Cr + "Download of " + uriString + " was successful. Please see 'searchresult.htm' for results."))