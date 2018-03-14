' System.Net.CredentialCache.DefaultCredentials.

 ' This program demonstrates the 'DefaultCredentials' property of the 'CredentialCache' 
'   class.
'   Creates an 'HttpWebRequest' object to access the local Uri "http://localhost"(IIS documentation start page)
'   Assigns the static property 'DefaultCredentials' of 'CredentialCache' as 'Credentials' for the 'HttpWebRequest'
'   object. DefaultCredentials returns the system credentials for the current security context in which 
'   the application is running. For a client-side application, these are usually the Windows credentials 
'   (user name, password, and domain) of the user running the application.
'   These credentials are used internally to authenticate the request.
'   The html contents of the start page are displayed to the console. 
'
'Note: Make sure that "Windows Authentication" has been set as  Directory Security settings
'      for default web site in IIS  
' 

Imports System
Imports System.Net
Imports System.IO
Imports System.Text
Imports Microsoft.VisualBasic


Class CredentialCache_DefaultCredentials
    
    Public Shared Sub Main()
        Try
            ' <Snippet1>            
            ' Assuming "Windows Authentication" has been set as; 
            ' Directory Security settings for default web site in IIS.
            Dim url As String = "http://localhost"
            ' Create a 'HttpWebRequest' object with the specified url. 
            Dim myHttpWebRequest As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
            ' Assign the credentials of the logged in user or the user being impersonated.
            myHttpWebRequest.Credentials = CredentialCache.DefaultCredentials
            ' Send the 'HttpWebRequest' and wait for response.            
            Dim myHttpWebResponse As HttpWebResponse = CType(myHttpWebRequest.GetResponse(), HttpWebResponse)
            Console.WriteLine("Authentication successful")
            Console.WriteLine("Response received successfully")
            ' </Snippet1>
            Console.WriteLine(ControlChars.Cr + "Press enter to continue")
            Console.ReadLine()
            ' Get the stream associated with the response object.
            Dim receiveStream As Stream = myHttpWebResponse.GetResponseStream()
            Dim encode As Encoding = System.Text.Encoding.GetEncoding("utf-8")
            ' Pipe the stream to a higher level stream reader with the required encoding format .
            Dim readStream As New StreamReader(receiveStream, encode)
            Console.WriteLine(ControlChars.Lf + ControlChars.Cr + "Response stream received")
            Dim read(256) As [Char]
            ' Read 256 characters at a time.    
            Dim count As Integer = readStream.Read(read, 0, 256)
            Console.WriteLine("HTML..." + ControlChars.Lf + ControlChars.Cr)
            While count > 0
                ' Dump the 256 characters on a string and display the string onto the console.
                Dim output As New [String](read, 0, count)
                Console.WriteLine(output)
                count = readStream.Read(read, 0, 256)
            End While
            Console.WriteLine("")
            ' Release resources of response object.
            myHttpWebResponse.Close()
            ' Release resources of stream object.
            readStream.Close()
        Catch e As WebException
            Console.WriteLine(ControlChars.Lf + ControlChars.Cr + "Exception Raised. The following error occured : {0}", e.Message)
        Catch e As Exception
            Console.WriteLine(ControlChars.Cr + "The following exception was raised : {0}", e.Message)
        End Try
    End Sub 'Main
End Class 'CredentialCache_DefaultCredentials
