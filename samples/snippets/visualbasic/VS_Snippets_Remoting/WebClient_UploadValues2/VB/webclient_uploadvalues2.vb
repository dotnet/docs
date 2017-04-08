' System.Net.WebClient.UploadValues(String,String,NameValueCollection)

'This program demonstrates the 'UploadValues(String,String,NameValueCollection)' method of "WebClient" class.
'It accepts an Uri.Forms a 'NameValueCollection' instance using 
'a set of pre-defined name-value pairs. These are posted to the Uri provided as input using the 
''UploadValues(String,String,NameValueCollection)'method. The custom made site responds back 
'with whatever was posted to it. This is displayed to the console.
'
'Note : The results described were obtained using a custom made site. This behaviour may not be the
'same with all other sites. Also certain sites would not accept "Post" method thereby leading to 
'an error.It is advisable to construct a site using files accompanying this and provide
'url name of this site to the program.
'
Imports System
Imports System.Collections.Specialized
Imports System.Net
Imports System.Text
Imports Microsoft.VisualBasic


Public Class WebClient_UpLoadValues2
    
    Public Shared Sub Main()
        Try
' <Snippet1>
            Console.Write(ControlChars.Cr + "Please enter the URL to post data to : ")
            Dim uriString As String = Console.ReadLine()

            ' Create a new WebClient instance.
            Dim myWebClient As New WebClient()

            ' Create a new NameValueCollection instance to hold some custom parameters to be posted to the URL.
            Dim myNameValueCollection As New NameValueCollection()
            
            Console.WriteLine("Please enter the following parameters to be posted to the Url")
            Console.Write("Name:")
            Dim name As String = Console.ReadLine()

            Console.Write("Age:")
            Dim age As String = Console.ReadLine()

            Console.Write("Address:")
            Dim address As String = Console.ReadLine()

            ' Add necessary parameter/value pairs to the name/value container.
            myNameValueCollection.Add("Name", name)
            myNameValueCollection.Add("Address", address)
            myNameValueCollection.Add("Age", age)

            Console.WriteLine(ControlChars.Cr + "Uploading to {0} ...", uriString)

            ' Upload the NameValueCollection.
            Dim responseArray As Byte() = myWebClient.UploadValues(uriString, "POST", myNameValueCollection)
            
            ' Decode and display the response.
            Console.WriteLine(ControlChars.Cr + "Response received was :" + ControlChars.Cr + "{0}", Encoding.ASCII.GetString(responseArray))
' </Snippet1>
        Catch e As WebException
            Console.WriteLine(("The following exception was raised: " + e.Message))
        Catch e As Exception
            Console.WriteLine(("The following exception was raised: " + e.Message))
        End Try
    End Sub 'Main
End Class 'WebClient_UpLoadValues2
