' System.Net.NetworkCredential.GetCredential

 'This program demontrates the 'GetCredential' of 'NetworkCredential' class.
'  It accepts an URL, username and password from console. Creates a 'NetworkCredential' object 
'  using these parameters. A 'WebRequest' object is created to access the Uri "http://www.microsoft.com"
'  and the 'NetworkCredential' object is assigned as it's Credentials.
'  A message is displayed onto the console on successful reception of response 
'  otherwise an exception is thrown.

Imports System
Imports System.Net
Imports Microsoft.VisualBasic

Class NetworkCredential_GetCredential
    
    'Entry point which delegates to C-style main Private Function
    Public Overloads Shared Sub Main()
        Main(System.Environment.GetCommandLineArgs())
    End Sub
    
    Overloads Public Shared Sub Main(args() As String)
        If args.Length < 4 Then
            Console.WriteLine(ControlChars.Cr + "Please enter a protected resource Url and other details as command line parameter as below:")
            Console.WriteLine(ControlChars.Cr + "Usage: NetworkCredential_GetCredential URLname username password")
            Console.WriteLine(ControlChars.Cr + "Example: NetworkCredential_GetCredential http://www.microsoft.com/net/ george george123")
        Else
            GetPage(args(1), args(2), args(3))
        End If
        Console.WriteLine(ControlChars.Cr + ControlChars.Cr + "Press 'Enter' to continue...")
        Console.ReadLine()
        Return
    End Sub 'Main
    
    
    Public Shared Sub GetPage(url As String, userName As String, password As String)
        Try
' <Snippet1>
            ' Create an empty instance of the NetworkCredential class.
            Dim myCredentials As New NetworkCredential(userName, password)
            ' Create a WebRequest with the specified URL. 
            Dim myWebRequest As WebRequest = WebRequest.Create(url)
            ' GetCredential returns the same NetworkCredential instance that invoked it, 
            ' irrespective of what parameters were provided to it. 
             myWebRequest.Credentials = myCredentials.GetCredential(New Uri(url), "")
            Console.WriteLine(ControlChars.Cr + ControlChars.Cr + "User Credentials:- UserName : {0} , Password : {1}", myCredentials.UserName, myCredentials.Password)
            ' Send the request and wait for a response.
            Console.WriteLine(ControlChars.Cr + ControlChars.Cr + "Request to Url is sent.Waiting for response...Please wait ...")
            Dim myWebResponse As WebResponse = myWebRequest.GetResponse()
            ' Process the response.
            Console.WriteLine(ControlChars.Cr + "Response received sucessfully")
            ' Release the resources of the response object.
            myWebResponse.Close()
' </Snippet1>
        Catch e As WebException
            Console.WriteLine(ControlChars.Lf + ControlChars.Cr + "WebException is raised.The Reason for failure is : {0}", e.Status)
        Catch e As Exception
            Console.WriteLine(ControlChars.Cr + "The following exception was raised : {0}", e.Message)
        End Try
    End Sub 'GetPage
End Class 'NetworkCredential_GetCredential