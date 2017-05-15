' System.Net.WebClient.DownloadFile

'This program demonstrates the 'DownloadFile' method of 'WebClient' class.
'It creates a URI to access a web resource at 'http://www.microsoft.com'. The Uri can point 
'to any text or binary web resource, like images etc. The 'DownloadFile' method then downloads 
'the target web resource which is a combination of the Uri and the actual web resource required,
'into the current filesystem folder with a specified name.
'Information regarding the sucess or failure of this operation is displayed on the console.
'

Imports System
Imports System.Net
Imports System.Windows.Forms
Imports Microsoft.VisualBasic


Public Class WebClient_DownloadFile
    
    Public Shared Sub Main()
        Try
' <Snippet1>
            Dim remoteUri As String = "http://www.contoso.com/library/homepage/images/"
            Dim fileName As String = "ms-banner.gif"
            Dim myStringWebResource As String = Nothing
            ' Create a new WebClient instance.
            Dim myWebClient As New WebClient()
            ' Concatenate the domain with the Web resource filename. Because DownloadFile 
            'requires a fully qualified resource name, concatenate the domain with the Web resource file name.
            myStringWebResource = remoteUri + fileName
            Console.WriteLine("Downloading File ""{0}"" from ""{1}"" ......." + ControlChars.Cr + ControlChars.Cr, fileName, myStringWebResource)
            ' The DownloadFile() method downloads the Web resource and saves it into the current file-system folder.
            myWebClient.DownloadFile(myStringWebResource, fileName)
            Console.WriteLine("Successfully Downloaded file ""{0}"" from ""{1}""", fileName, myStringWebResource)
            Console.WriteLine((ControlChars.Cr + "Downloaded file saved in the following file system folder:" + ControlChars.Cr + ControlChars.Tab + Application.StartupPath))
' </Snippet1>
        Catch e As WebException
            ' Display the exception.
            Console.WriteLine(("Download failed!!! WebException : " + e.Message))
        Catch e As Exception
            ' Display the exception.
            Console.WriteLine(("The following general exception was raised: " + e.Message))
        End Try
    End Sub 'Main
End Class 'WebClient_DownloadFile
