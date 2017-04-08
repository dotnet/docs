'System.Net.HttpWebRequest.Proxy
'This program demonstrates the 'Proxy' property of the 'HttpWebRequest' class.
'A HttpWebRequest object is created and a new Proxy Object is created.
'The Proxy Object is assigned the 'Proxy' Property of the HttpWebRequest Object and then printed to the console,this is the default Proxy setting.
'New Proxy address and the credentials are requested from the User.
'A new Proxy object is then constructed from the inputs.
'Then the 'Proxy' property of the request is associated with the new Proxy object constructed.
'Note:No credentials are required if the Proxy does not require any authentication.


Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports Microsoft.VisualBasic



Class HttpWebRequest_Proxy
    
    Shared Sub Main()
	Try
' <Snippet1>
            ' Create a new request to the mentioned URL.				
            Dim myWebRequest As HttpWebRequest = CType(WebRequest.Create("http://www.microsoft.com"), HttpWebRequest)

			      ' Obtain the 'Proxy' of the  Default browser.  
			      Dim proxy as IWebProxy = CType(myWebRequest.Proxy, IWebProxy)
			      ' Print the Proxy Url to the console.
            If Not proxy Is Nothing Then
                Console.WriteLine("Proxy: {0}", proxy.GetProxy(myWebRequest.RequestUri))
            Else
                Console.WriteLine("Proxy is null; no proxy will be used")
            End If

            Dim myProxy As New WebProxy()

            Console.WriteLine(ControlChars.Cr + "Please enter the new Proxy Address that is to be set ")
            Console.WriteLine("(Example:http://myproxy.example.com:port)")
            Dim proxyAddress As String
            Try
                proxyAddress = Console.ReadLine()
                If proxyAddress.Length = 0 Then
                    myWebRequest.Proxy = myProxy
                Else
                    Console.WriteLine(ControlChars.Cr + "Please enter the Credentials (may not be needed)")
                    Console.WriteLine("Username:")
                    Dim username As String
                    username = Console.ReadLine()
                    Console.WriteLine(ControlChars.Cr + "Password:")
                    Dim password As String
                    password = Console.ReadLine()
                    ' Create a new Uri object.
                    Dim newUri As New Uri(proxyAddress)
                    ' Associate the newUri object to 'myProxy' object so that new myProxy settings can be set.
                    myProxy.Address = newUri
                    ' Create a NetworkCredential object and associate it with the Proxy property of request object.
                    myProxy.Credentials = New NetworkCredential(username, password)
                    myWebRequest.Proxy = myProxy
                End If
                Console.WriteLine(ControlChars.Cr + "The Address of the  new Proxy settings are {0}", myProxy.Address)
                Dim myWebResponse As HttpWebResponse = CType(myWebRequest.GetResponse(), HttpWebResponse)
' </Snippet1>  
                ' Print the HTML contents of the page to the console.
                Dim streamResponse As Stream = myWebResponse.GetResponseStream()
                Dim streamRead As New StreamReader(streamResponse)
                Dim readBuff(256) As [Char]
                Dim count As Integer = streamRead.Read(readBuff, 0, 256)
                Console.WriteLine(ControlChars.Cr + "The contents of the Html pages are :")
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
                Console.WriteLine(ControlChars.Cr + "Press any key to continue.........")
                Console.Read()
            Catch e As UriFormatException
                Console.WriteLine(ControlChars.Cr + "{0}", e.Message)
                Console.WriteLine(ControlChars.Cr + "The format of the Proxy address you entered is invalid")
             End Try
        Catch e As WebException
            Console.WriteLine(ControlChars.Cr + "Exception is raised ")
            Console.WriteLine(ControlChars.Cr + "{0} ", e.Message)
            Console.WriteLine(ControlChars.Cr + "{0}", e.Status)
	   
        Catch e As Exception
            Console.WriteLine(ControlChars.Cr + "Exception is raised ")
            Console.WriteLine(ControlChars.Cr + "{0} ", e.Message)
	    
        End Try
    End Sub ' Main
End Class ' HttpWebRequest_Proxy
