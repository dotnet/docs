 ' System.Net.WebClient.UploadData(String,byte[])

'This program demonstrates the 'UploadData(String,byte[])' method of "WebClient" class.
'It accepts an Uri and some string content to be posted to the Uri. This string is posted to the Uri 
'provided as input using the 'UploadData(String,byte[])' method. The custom made site responds back 
'with whatever was posted to it. The contents of the response are displayed to the console.
'
'Note : The results described were obtained using a custom made site. This behaviour may not be the
'same with all other sites. Also certain sites would not accept "Post" method thereby leading to 
'an error. It is advisable to construct a site using files accompanying this and provide
'url name of this site to the program.
'
Imports System
Imports System.Net
Imports System.Text
Imports Microsoft.VisualBasic


Public Class WebClient_UploadData2
    
    Public Shared Sub Main()
        Try
' <Snippet1>			
            Console.Write(ControlChars.Cr + "Please enter the URI to post data to : ")
            Dim uriString As String = Console.ReadLine()

            ' Create a new WebClient instance.
            Dim myWebClient As New WebClient()
            Console.WriteLine(ControlChars.Cr + "Please enter the data to be posted to the URI {0}:", uriString)
            Dim postData As String = Console.ReadLine()
            ' Apply ASCII Encoding to obtain the string as a byte array.
            Dim postArray As Byte() = Encoding.ASCII.GetBytes(postData)
            Console.WriteLine("Uploading to {0} ...", uriString)
            myWebClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded")

            ' UploadData implicitly sets HTTP POST as the request method.
            Dim responseArray As Byte() = myWebClient.UploadData(uriString, postArray)

            ' Decode and display the response.
            Console.WriteLine(ControlChars.Cr + "Response received was :{0}", Encoding.ASCII.GetString(responseArray))
' </Snippet1>
        Catch e As WebException
            Console.WriteLine(("The following exception was raised: " + e.Message))
        Catch e As Exception
            Console.WriteLine(("The following exception was raised: " + e.Message))
        End Try
    End Sub 'Main
End Class 'WebClient_UploadData2
