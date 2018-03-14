' System.Net.NetworkCredential.Username;System.Net.NetworkCredential.Domain;System.Net.NetworkCredential.Password

 'This program demontrates the 'UserName','Domain' and 'Password' properties of 'NetworkCredential' class.
'  It takes an URL, username, password and domainname from console. An empty 'NetworkCredential' object 
'  is created.The 'UserName' ,'Password' and 'Domain' porperties of 'NetworkCredential' class are initialised 
'  with the respective values taken from console. Then a 'WebRequest' object is created and the 'NetworkCredential'
'  object is associated with it.A message is displayed onto the console on successful reception of response 
'  otherwise an exception is thrown.
' 

Imports System
Imports System.Net
Imports Microsoft.VisualBasic


Class CredentialCacheSnippet
    
    'Entry point which delegates to C-style main Private Function
    Public Overloads Shared Sub Main()
        Main(System.Environment.GetCommandLineArgs())
    End Sub
    
    Overloads Public Shared Sub Main(args() As String)
        
        If args.Length < 5 Then
            Console.WriteLine(ControlChars.Cr + "Please enter a protected resource Url and other details as command line parameter as below:")
            Console.WriteLine(ControlChars.Cr + "Usage: NetworkCredential_UserName_Password_Domain URLname username password domainname")
            Console.WriteLine(ControlChars.Cr + "Example: NetworkCredential_UserName_Password_Domain http://www.microsoft.com/net/ george george123 microsoft")
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
' <Snippet2>
' <Snippet3>
            ' Create an empty instance of the NetworkCredential class.
            Dim myCredentials As New NetworkCredential("", "", "")
            myCredentials.Domain = domain
            myCredentials.UserName = username
            myCredentials.Password = passwd
            
            ' Create a WebRequest with the specified URL. 
            Dim myWebRequest As WebRequest = WebRequest.Create(url)
            myWebRequest.Credentials = myCredentials
            Console.WriteLine(ControlChars.Cr + ControlChars.Cr + "User Credentials:- Domain : {0} , UserName : {1} , Password : {2}", myCredentials.Domain, myCredentials.UserName, myCredentials.Password)
            
            ' Send the request and wait for a response.
            Console.WriteLine(ControlChars.Cr + ControlChars.Cr + "Request to Url is sent.Waiting for response...Please wait ...")
            Dim myWebResponse As WebResponse = myWebRequest.GetResponse()
            ' Process the response.
            Console.WriteLine(ControlChars.Cr + "Response received sucessfully")
            ' Release the resources of the response object.
            myWebResponse.Close()
' </Snippet3>
' </Snippet2>
' </Snippet1>
        Catch e As WebException
            Console.WriteLine(ControlChars.Lf + ControlChars.Cr + "WebException is raised.The Reason for failure is : {0}", e.Status)
        Catch e As Exception
            Console.WriteLine(ControlChars.Cr + "The following exception was raised : {0}", e.Message)
        End Try
  End Sub 'GetPage 
End Class 'CredentialCacheSnippet 
