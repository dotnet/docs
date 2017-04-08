' System.Net.WebClient.UploadData(String,String,byte[]); System.Net.WebClient.Headers

'This program demonstrates the 'UploadData(String,String,byte[])' method and 'Headers' property of 
''WebClient' class.It accepts an Uri and some string content to be posted to the Uri. This string 
'is posted to the Uri provided as input using the 'UploadData(String,String,byte[])' method.
'The 'Headers' property is used to set the "Content-Type" header to "application/x-www-form-urlencoded".
'The custom made site responds back with whatever was posted to it. 
'The contents of the response are displayed to the console.
'
'Note : The results described were obtained using a custom made site. This behaviour may not be the
'same with all other sites. Also certain sites would not support the "Post" method thereby leading to 
'an error.It is advisable to construct a site using files accompanying this and provide
'url name of this site to the program.
'
Imports System
Imports System.Net
Imports System.Text
Imports Microsoft.VisualBasic


Public Class WebClient_UploadData_Headers
    
    Public Shared Sub Main()
        Try
' <Snippet1>
' <Snippet2>
            Dim uriString As String
            Console.Write(ControlChars.Cr + "Please enter the URI to post data to{for example, http://www.contoso.com} : ")
            uriString = Console.ReadLine()

            ' Create a new WebClient instance.
            Dim myWebClient As New WebClient()
            Console.WriteLine(ControlChars.Cr + "Please enter the data to be posted to the URI {0}:", uriString)
            Dim postData As String = Console.ReadLine()
            myWebClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded")
            
            ' Display the headers in the request
            Console.Write("Resulting Request Headers: ")
            Console.Writeline(myWebClient.Headers.ToString())

            ' Apply ASCII Encoding to obtain the string as a byte array.
            Dim byteArray As Byte() = Encoding.ASCII.GetBytes(postData)
            Console.WriteLine("Uploading to {0} ...", uriString)
            ' Upload the input string using the HTTP 1.0 POST method.
            Dim responseArray As Byte() = myWebClient.UploadData(uriString, "POST", byteArray)
            ' Decode and display the response.
            Console.WriteLine(ControlChars.Cr + "Response received was :{0}", Encoding.ASCII.GetString(responseArray))
' </Snippet2>
' </Snippet1>
        Catch e As WebException
            Console.WriteLine(("The following exception was raised: " + e.Message))
        Catch e As Exception
            Console.WriteLine(("The following exception was raised: " + e.Message))
        End Try
    End Sub 'Main
End Class 'WebClient_UploadData_Headers
