' System.Net.WebClient.QueryString

 'This program demonstrates the 'QueryString' property of 'WebClient' class.
' It accepts a search phrase as user input and invokes the search of www.example.com for  
' the user-entered search-phrase,using the 'QueryString' property of WebClient. The result is 
' then saved into the current 
' filesystem folder as 'searchresult.htm'. 
' 

Imports System
Imports System.Collections.Specialized
Imports System.Net
Imports Microsoft.VisualBasic


Public Class WebClient_QueryString
    
    Public Shared Sub Main()
        Try
' <Snippet1>			
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
' </Snippet1>
            ' ResponseHeaders property is a WebHeaderCollection instance which contains the ; 
            ' Headers sent back in response to the WebClient request. 
            Dim myWebHeaderCollection As WebHeaderCollection = myWebClient.ResponseHeaders
            Console.WriteLine(ControlChars.Cr + "Displaying Response Headers" + ControlChars.Cr)
            ' Loop through the ResponseHeaders and display the Headers as name/value pairs.
            Dim i As Integer
            For i = 0 To myWebHeaderCollection.Count - 1
                ' Display the Headers as 'Name = Value' pairs.
                Console.WriteLine((ControlChars.Tab + myWebHeaderCollection.GetKey(i) + " " + ChrW(61) + " " + myWebHeaderCollection.Get(i)))
            Next i
        Catch e As WebException
            Console.WriteLine(("The following WebException was raised: " + e.Message))
        Catch e As Exception
            Console.WriteLine(("The following Exception was raised: " + e.Message))
        End Try
    End Sub 'Main
End Class 'WebClient_QueryString
