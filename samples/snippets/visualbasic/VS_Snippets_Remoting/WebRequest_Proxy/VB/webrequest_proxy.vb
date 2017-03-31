'System.Net.WebRequest.Proxy
'This program demonstrates the 'Proxy' property of the 'WebRequest' class.
'A WebRequest object is created and a new Proxy Object is created.
'The Proxy Object is assigned the 'Proxy' Property of the WebRequest Object and then printed to the console,this is the default Proxy setting.
'New Proxy address and the credentials are requested from the User.
'A new Proxy object is then constructed from the inputs.
'Then the 'Proxy' property of the request is associated with the new Proxy object constructed

Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports Microsoft.VisualBasic


Class WebRequest_Proxy
    
    Shared Sub Main()
	Try
' <Snippet1>

            ' Create a new request to the mentioned URL.				
            Dim myWebRequest As WebRequest = WebRequest.Create("http://www.contoso.com")
            Dim myProxy As New WebProxy()

            ' Obtain the Proxy Prperty of the  Default browser. 
             myProxy = CType(myWebRequest.Proxy, WebProxy)

            ' Print myProxy address to the console.
            Console.WriteLine(ControlChars.Cr + "The actual default Proxy settings are {0}", myProxy.Address)

            Try
                Console.WriteLine(ControlChars.Cr + "Please enter the new Proxy Address to be set ")
                Console.WriteLine("The format of the address should be http://proxyUriAddress:portaddress")
                Console.WriteLine("Example:http://moon.proxy.com:8080")
                Dim proxyAddress As String
                proxyAddress = Console.ReadLine()

                If proxyAddress.Length = 0 Then
                    myWebRequest.Proxy = myProxy
                Else
                    Console.WriteLine(ControlChars.Cr + "Please enter the Credentials")
                    Console.WriteLine("Username:")
                    Dim username As String
                    username = Console.ReadLine()
                    Console.WriteLine(ControlChars.Cr + "Password:")
                    Dim password As String
                    password = Console.ReadLine()

                   ' Create a new Uri object.
                    Dim newUri As New Uri(proxyAddress)

                    ' Associate the new Uri object to the myProxy object.
                    myProxy.Address = newUri

                    ' Create a NetworkCredential object and is assign to the Credentials property of the Proxy object.
                    myProxy.Credentials = New NetworkCredential(username, password)
                    myWebRequest.Proxy = myProxy
                    
                End If
                Console.WriteLine(ControlChars.Cr + "The Address of the  new Proxy settings are {0}", myProxy.Address)
                Dim myWebResponse As WebResponse = myWebRequest.GetResponse()

                ' Print the  HTML contents of the page to the console.
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
                Console.WriteLine(ControlChars.Cr + "The format of the myProxy address you entered is invalid")
             End Try
             
' </Snippet1> 
	    Catch e As WebException
            Console.WriteLine(ControlChars.Cr + "Exception is raised ")
            Console.WriteLine(ControlChars.Cr + "{0} ", e.Message)
            Console.WriteLine(ControlChars.Cr + "{0}", e.Status)
        Catch e As Exception
            Console.WriteLine(ControlChars.Cr + "Exception is raised ")
            Console.WriteLine(ControlChars.Cr + "{0} ", e.Message)
        End Try
    End Sub ' Main
End Class ' WebRequest_Proxy
