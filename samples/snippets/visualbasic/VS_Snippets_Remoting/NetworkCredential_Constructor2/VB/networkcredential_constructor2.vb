' System.Net.NetworkCredential.NetworkCredential(string,string)
 
'This program demontrates the 'NetworkCredential(string,string)' constructor of 'NetworkCredential' class.
'  It takes an URL, username, password and domainname from console and forms a 'NetworkCredential' object with 
'  these arguments.Then a 'WebRequest' object is created and the 'NetworkCredential' object is associated with 
'  it.A message is displayed onto the console on successful reception of response otherwise an exception is thrown.
' 

Imports System
Imports System.Net
Imports Microsoft.VisualBasic


Class NetworkCredentialSnippet
    
    'Entry point which delegates to C-style main Private Function
    Public Overloads Shared Sub Main()
        Main(System.Environment.GetCommandLineArgs())
    End Sub
    
    Overloads Public Shared Sub Main(args() As String)
        
        If args.Length < 5 Then
            Console.WriteLine(ControlChars.Cr + "Please enter a protected resource Url and other details as command line parameter as below:")
            Console.WriteLine(ControlChars.Cr + "Usage: NetworkCredential_Constructor2 URLname username password domainname")
            Console.WriteLine(ControlChars.Cr + "Example: NetworkCredential_Constructor2 http://www.microsoft.com/net/ george george123 microsoft")
        Else
            GetPage(args(1), args(2), args(3), args(4))
        End If
        
        Console.WriteLine(ControlChars.Cr + ControlChars.Cr + "Press 'Enter key' to continue...")
        Console.ReadLine()
        Return
    End Sub 'Main
    
    
    Public Shared Sub GetPage(url As String, username As String, passwd As String, domain As String)
        Try
' <Snippet1>            
            ' Call the constructor  to create an instance of NetworkCredential with the
            ' specified user name and password.
            Dim myCredentials As New NetworkCredential(username, passwd)
            ' Create a WebRequest with the specified URL. 
            Dim myWebRequest As WebRequest = WebRequest.Create(url)
            myCredentials.Domain = domain
            myWebRequest.Credentials = myCredentials
            Console.WriteLine(ControlChars.Cr + ControlChars.Cr + "Credentials Domain : {0} , UserName : {1} , Password : {2}", myCredentials.Domain, myCredentials.UserName, myCredentials.Password)
            Console.WriteLine(ControlChars.Cr + ControlChars.Cr + "Request to Url is sent.Waiting for response...")
            ' Send the request and wait for a response.
            Dim myWebResponse As WebResponse = myWebRequest.GetResponse()
            ' Process the response.
            Console.WriteLine(ControlChars.Cr + "Response received successfully.")
            ' Release the resources of the response object.
            myWebResponse.Close()
' </Snippet1>
        Catch e As WebException
            Console.WriteLine(ControlChars.Lf + ControlChars.Cr + "WebException is raised.The Reason for failure is : {0}", e.Status)
        Catch e As Exception
            Console.WriteLine(ControlChars.Cr + "The following exception was raised : {0}", e.Message)
        End Try
    End Sub 'GetPage 
End Class 'NetworkCredentialSnippet
