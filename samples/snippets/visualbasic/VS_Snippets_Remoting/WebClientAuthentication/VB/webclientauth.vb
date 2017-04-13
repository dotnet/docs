
Imports System
Imports System.Net
Imports System.Text



Public Class WebClientAuthSample
    '<snippet1>
    Public Shared Sub Main()
        Try
            Dim client As New WebClient()

            client.Credentials = CredentialCache.DefaultCredentials

            Dim pageData As [Byte]() = client.DownloadData("http://www.contoso.com")
            Dim pageHtml As String = Encoding.ASCII.GetString(pageData)
            
            Console.WriteLine(pageHtml)

        Catch webEx As WebException
            Console.Write(webEx.ToString())
        End Try
    End Sub 
'</snippet1>
End Class 