 ' <Snippet1>
Imports System.Net
Imports System

' This example is run at the command line.
' Specify one argument: the name of the host to 
' receive the request.
' If the request is sucessful, the example displays the contents of the cookies
' returned by the host.

Public Class CookieExample
    
    ' <Snippet2>
    Public Shared Sub Main(args() As String)
        If args Is Nothing OrElse args.Length <> 1 Then
            Console.WriteLine("Specify the URL to receive the request.")
            Environment.Exit(1)
        End If
        ' <Snippet3>
        Dim request As HttpWebRequest = CType(WebRequest.Create(args(0)), HttpWebRequest)
        request.CookieContainer = New CookieContainer()
        
        Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)

        
        
        ' Print the properties of each cookie.
        Dim cook As Cookie
        For Each cook In  response.Cookies
            Console.WriteLine("Cookie:")
            Console.WriteLine("{0} = {1}", cook.Name, cook.Value)
            Console.WriteLine("Domain: {0}", cook.Domain)
            Console.WriteLine("Path: {0}", cook.Path)
            Console.WriteLine("Port: {0}", cook.Port)
            Console.WriteLine("Secure: {0}", cook.Secure)
            
            Console.WriteLine("When issued: {0}", cook.TimeStamp)
            Console.WriteLine("Expires: {0} (expired? {1})", cook.Expires, cook.Expired)
            Console.WriteLine("Don't save: {0}", cook.Discard)
            Console.WriteLine("Comment: {0}", cook.Comment)
            Console.WriteLine("Uri for comments: {0}", cook.CommentUri)
            Console.WriteLine("Version: RFC {0}", IIf(cook.Version = 1, "2109", "2965"))
            
            '<Snippet4>
            ' Show the string representation of the cookie.
            Console.WriteLine("String: {0}", cook.ToString())
            ' </Snippet4>
        Next cook
        ' </Snippet3>
    End Sub 'Main
    ' </Snippet2>
End Class 'CookieExample 



' Output from this example will be vary depending on the host name specified,
' but will be similar to the following.
'
'Cookie:
'CustomerID = 13xyz
'Domain: .contoso.com
'Path: /
'Port:
'Secure: False
'When issued: 1/14/2003 3:20:57 PM
'Expires: 1/17/2013 11:14:07 AM (expired? False)
'Don't save: False
'Comment: 
'Uri for comments:
'Version: RFC 2965
'String: CustomerID = 13xyz
'

' </Snippet1>