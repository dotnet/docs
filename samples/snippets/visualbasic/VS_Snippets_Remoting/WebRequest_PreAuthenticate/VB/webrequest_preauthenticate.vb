'System.Net.WebRequest.PreAuthenticate,System.Net.WebRequest.Credentials
'This program demonstrates the 'PreAuthenticate' and 'Credentials' properties of the WebRequest Class.
'The PreAuthenticate Property has a default value set to False.
'This is set to True and new NetwrokCredential object is created with UserName and Password.  
'This NetworkCredential Object associated to the WebRequest Object to be able to authenticate the requested Uri
'To check the validity of this program, please try with some authenticated sites with appropriate credentials

Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports Microsoft.VisualBasic
Imports System.Environment

Class WebRequest_Preauthenticate
    Public Overloads Shared Sub Main()
        Main(GetCommandLineArgs())
    End Sub
    
    Overloads Shared Sub Main(args() As String)
        If args.Length < 2 Then
            Console.WriteLine(ControlChars.Cr + "Please type the url which requires authentication as command line parameter")
            Console.WriteLine("Example:WebRequest_PreAuthenticate http://www.microsoft.com")
        Else
            GetPage(args(1))
        End If
        Console.WriteLine(ControlChars.Cr + "Press any key to continue...")
        Console.ReadLine()
        Return
    End Sub ' Main
    
    Public Shared Sub GetPage(url As String)
    Try
' <Snippet1>
' <Snippet2>

            ' Create a new webrequest to the mentioned URL.
            Dim myWebRequest As WebRequest = WebRequest.Create(url)

            ' Set 'Preauthenticate'  property to true.
            myWebRequest.PreAuthenticate = True
            Console.WriteLine(ControlChars.Cr + "Please enter your credentials for the requested Url")
            Console.WriteLine("UserName")
            Dim UserName As String = Console.ReadLine()
            Console.WriteLine("Password")
            Dim Password As String = Console.ReadLine()

            ' Create a New 'NetworkCredential' object.
            Dim networkCredential As New NetworkCredential(UserName, Password)

            ' Associate the 'NetworkCredential' object with the 'WebRequest' object.
            myWebRequest.Credentials = networkCredential

            ' Assign the response object of 'WebRequest' to a 'WebResponse' variable.
            Dim myWebResponse As WebResponse = myWebRequest.GetResponse()

' </Snippet2>
' </Snippet1>
            ' Read the 'Response' into a Stream object and then print to the console.		
            Dim streamResponse As Stream = myWebResponse.GetResponseStream()
            Dim streamRead As New StreamReader(streamResponse)
            Dim readBuff(256) As [Char]
            Dim count As Integer = streamRead.Read(readBuff, 0, 256)
            Console.WriteLine(ControlChars.Cr + "The contents of the Html page of the requested Uri are : ")
            While count > 0
                Dim outputData As New [String](readBuff, 0, count)
                Console.Write(outputData)
                count = streamRead.Read(readBuff, 0, 256)
            End While
	   ' Close the Stream object.
            streamResponse.Close()
	    streamRead.Close()
	  ' Release the HttpWebResponse Resource.
	    myWebResponse.Close()
        Catch e As WebException
            Console.WriteLine(ControlChars.Cr + "WebException is raised. ")
            Console.WriteLine(ControlChars.Cr + "Message:{0} ", e.Message)
        Catch e As Exception
            Console.WriteLine(ControlChars.Cr + "Exception is raised. ")
            Console.WriteLine(ControlChars.Cr + "Message:{0} ", e.Message)
        End Try
    End Sub ' GetPage
End Class ' WebRequest_Preauthenticate 



