' This is a client program to test the "CloneBasic" class of IAuthenticationModule_Methods_Props.dll.
'   
'  To demonstrate the functionality of CloneBasic, Client class has been made which makes
'  the webrequest for the protected resource. A site for such a protected resource (http://gopik/clonebasicsite/WebForm1.aspx),
'  which would use CloneBasic authentication, has been developed. Pl. see the guidelines.txt file for more 
'  information in setting up the site at your environment. 
' 
'  While running this program make sure to refer the 'Authorization_Construstor3.dll'
' 
Imports System
Imports System.Net
Imports System.Text
Imports System.IO
Imports System.Collections
Imports CloneBasicAuthentication
Imports Microsoft.VisualBasic

Namespace CloneBasicAuthenticationClient
    
    
    ' To test our authentication module, we write a client class 
    Class Client
        
        'Entry point which delegates to C-style main Private Function
        
        
        Overloads Public Shared Sub Main(args() As String)
            Try
                Dim url, userName, passwd, domain As String
                If args.Length < 5 Then
                    'Proceed with defaults
                    Client.PrintUsage()
                    Console.WriteLine(ControlChars.Cr + "To proceed with defaults values press 'y' ,press any other character to exit:")
                    Dim [option] As String = Console.ReadLine()
                    If [option] = "Y" Or [option] = "y" Then
                        url = "http://gopik/clonebasicsite/WebForm1.aspx"
                        userName = "user1"
                        passwd = "passwd1"
                        domain = "gopik"
                    Else
                        Return
                    End If
                Else
                    url = args(1)
                    userName = args(2)
                    passwd = args(3)
                    domain = args(4)
                End If
                Console.WriteLine()
                
                Dim authenticationModule As New CloneBasic()
                ' Register CloneBasic authentication module with the system
                AuthenticationManager.Register(authenticationModule)
                Console.WriteLine(ControlChars.Cr + "Successfully registered our custom authentication module ""CloneBasic"" ")
                ' The AuthenticationManager calls all authentication modules sequentially until one of them responds with
		          ' an authorization instance. We have to unregister "Basic" here as it almost always returns an authorization,
		          ' thereby defeating our purpose to test CloneBasic
                AuthenticationManager.Unregister("Basic")
                
                Dim registeredModules As IEnumerator = AuthenticationManager.RegisteredModules
                Console.WriteLine(ControlChars.Lf + ControlChars.Cr + "The following authentication modules are now registered with the system")
                While registeredModules.MoveNext()
                    Console.WriteLine(ControlChars.Lf + " " + ControlChars.Cr + " Module : {0}", registeredModules.Current)
                    Dim currentAuthenticationModule As IAuthenticationModule = CType(registeredModules.Current, IAuthenticationModule)
                    Console.WriteLine(ControlChars.Tab + "  CanPreAuthenticate : {0}", currentAuthenticationModule.CanPreAuthenticate)
                End While
                ' Calling Our Test Client 
                GetPage(url, userName, passwd, domain)
            Catch e As Exception
                Console.WriteLine(ControlChars.Cr + " The following exception was raised : {0}", e.Message)
            End Try
        End Sub 'Main
        
        Public Shared Sub PrintUsage()
            Console.WriteLine(ControlChars.Lf + ControlChars.Cr + "Usage: Try a site which requires CloneBasic(custom made) authentication as below")
            Console.WriteLine("   ClientCloneBasic URLname username password domainname")
            Console.WriteLine(ControlChars.Cr + "Example:")
            Console.WriteLine(ControlChars.Cr + "   ClientCloneBasic http://www.microsoft.com/net/ george george123 microsoft")
        End Sub 'PrintUsage
        
        Public Shared Sub GetPage(url As String, username As String, passwd As String, domain As String)
            Try
                Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
                Dim credentials As New NetworkCredential(username, passwd, domain)
                myHttpWebRequest.Credentials = credentials
                Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
                Console.WriteLine(ControlChars.Cr + "Request for protected resource {0} sent", url)
                
                Dim receiveStream As Stream = myHttpWebResponse.GetResponseStream()
                Dim encode As Encoding = System.Text.Encoding.GetEncoding("utf-8")
                Dim readStream As New StreamReader(receiveStream, encode)
                Console.WriteLine(ControlChars.Lf + ControlChars.Cr + "Response stream received")
                
                Dim read(256) As [Char]
                ' Read 256 characters at a time    
                Dim count As Integer = readStream.Read(read, 0, 256)
                Console.WriteLine("Contents of the response received follows..." + ControlChars.Lf + ControlChars.Cr)
                
                While count > 0
                    ' Dump the 256 characters on a string and display the string onto the console
                    Console.Write(read)
                    count = readStream.Read(read, 0, 256)
                End While
                Console.WriteLine("")
		          ' Release resources of stream object
                readStream.Close()
		          ' Release resources of response object
                myHttpWebResponse.Close()
            
            Catch e As WebException
                If Not (e.Response Is Nothing) Then
                    Console.WriteLine(ControlChars.Lf + ControlChars.Cr + " Exception Raised. The following error occured : {0}", CType(e.Response, HttpWebResponse).StatusDescription)
                Else
                    Console.WriteLine(ControlChars.Lf + ControlChars.Cr + " Exception Raised. The following error occured : {0}", e.Status)
                End If
            Catch e As Exception
                Console.WriteLine(ControlChars.Cr + " The following exception was raised : {0}", e.Message)
            End Try
        End Sub 'GetPage
    End Class 'Client 
End Namespace 'CloneBasicAuthenticationClient 
