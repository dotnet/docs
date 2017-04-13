Imports System
Imports System.Net
Imports System.Text
Imports System.Collections.Specialized



Public Class WebClientSample

    '<snippet1>    
    Public Shared Sub Main()


        Try
            Dim client As New WebClient()
            Dim pageData As [Byte]() = client.DownloadData("http://www.contoso.com")
            Dim pageHtml As String = Encoding.ASCII.GetString(pageData)

            ' Download the data to a buffer.
            Console.WriteLine(pageHtml)
            
            ' Download the data to a file.
            client.DownloadFile("http://www.contoso.com", "page.htm")
            
            
            ' Upload some form post values.
            dim form as New NameValueCollection()
			   form.Add("MyName", "MyValue")  

			   ' Note that you need to replace "http://localhost/somefile.aspx" with the name of 
			   ' a file that is available to your computer.
			   Dim responseData As [Byte]() = client.UploadValues("http://www.contoso.com/form.aspx", form)      
            Console.WriteLine(Encoding.ASCII.GetString(responseData))
        
        Catch webEx As WebException
            if webEx.Status = WebExceptionStatus.ConnectFailure then
               Console.WriteLine("Are you behind a firewall?  If so, go through the proxy server.")
            end if
            Console.Write(webEx.ToString())
        End Try
        
    
    End Sub 'Main
    '</snippet1>
End Class 'WebClientSample
