---
title: "Handling Errors"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "Internet, WebRequest and WebResponse classes exceptions"
  - "Status property"
  - "WebExceptions class, about WebExceptions class"
  - "Timeout enumeration member"
  - "ConnectFailure enumeration member"
  - "TrustFailure enumeration member"
  - "WebRequest class, exceptions"
  - "requesting data from Internet, error handling"
  - "Success enumeration member"
  - "receiving data, errors"
  - "ProtocolError enumeration member"
  - "downloading Internet resources, error handling"
  - "WebResponse class, exceptions"
  - "SendFailure enumeration member"
  - "errors [.NET Framework], WebRequest and WebResponse classes exceptions"
  - "sending data, errors"
  - "response to Internet request, error handling"
  - "NameResolutionFailure enumeration member"
  - "KeepAliveFailure enumeration member"
  - "network resources, WebRequest and WebResponse classes exceptions"
  - "RequestCanceled enumeration member"
  - "ReceiveFailure enumeration member"
  - "ServerProtocolViolation enumeration member"
  - "ConnectionClosed enumeration member"
  - "SecureChannelFailure enumeration member"
ms.assetid: 657141cd-5cf5-4fdb-a4b2-4c040eba84b5
caps.latest.revision: 12
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Handling Errors
The <xref:System.Net.WebRequest> and <xref:System.Net.WebResponse> classes throw both system exceptions (such as <xref:System.ArgumentException>) and Web-specific exceptions (which are <xref:System.Net.WebException> thrown by the <xref:System.Net.WebRequest.GetResponse%2A> method).  
  
 Each **WebException** includes a <xref:System.Net.WebException.Status%2A> property that contains a value from the <xref:System.Net.WebExceptionStatus> enumeration. You can examine the **Status** property to determine the error that occurred and take the proper steps to resolve the error.  
  
 The following table describes the possible values for the **Status** property.  
  
|Status|Description|  
|------------|-----------------|  
|ConnectFailure|The remote service could not be contacted at the transport level.|  
|ConnectionClosed|The connection was closed prematurely.|  
|KeepAliveFailure|The server closed a connection made with the Keep-alive header set.|  
|NameResolutionFailure|The name service could not resolve the host name.|  
|ProtocolError|The response received from the server was complete but indicated an error at the protocol level.|  
|ReceiveFailure|A complete response was not received from the remote server.|  
|RequestCanceled|The request was canceled.|  
|SecureChannelFailure|An error occurred in a secure channel link.|  
|SendFailure|A complete request could not be sent to the remote server.|  
|ServerProtocolViolation|The server response was not a valid HTTP response.|  
|Success|No error was encountered.|  
|Timeout|No response was received within the time-out set for the request.|  
|TrustFailure|A server certificate could not be validated.|  
|MessageLengthLimitExceeded|A message was received that exceeded the specified limit when sending a request or receiving a response from the server.|  
|Pending|An internal asynchronous request is pending.|  
|PipelineFailure|This value supports the .NET Framework infrastructure and is not intended to be used directly in your code.|  
|ProxyNameResolutionFailure|The name resolver service could not resolve the proxy host name.|  
|UnknownError|An exception of unknown type has occurred.|  
  
 When the **Status** property is **WebExceptionStatus.ProtocolError**, a **WebResponse** that contains the response from the server is available. You can examine this response to determine the actual source of the protocol error.  
  
 The following example shows how to catch a **WebException**.  
  
```csharp  
try   
{  
    // Create a request instance.  
    WebRequest myRequest =   
    WebRequest.Create("http://www.contoso.com");  
    // Get the response.  
    WebResponse myResponse = myRequest.GetResponse();  
    //Get a readable stream from the server.   
    Stream sr = myResponse.GetResponseStream();  
  
    //Read from the stream and write any data to the console.  
    bytesread = sr.Read( myBuffer, 0, length);  
    while( bytesread > 0 )   
    {  
        for (int i=0; i<bytesread; i++) {  
            Console.Write( "{0}", myBuffer[i]);  
        }  
        Console.WriteLine();  
        bytesread = sr.Read( myBuffer, 0, length);  
    }  
    sr.Close();  
    myResponse.Close();  
}  
catch (WebException webExcp)   
{  
    // If you reach this point, an exception has been caught.  
    Console.WriteLine("A WebException has been caught.");  
    // Write out the WebException message.  
    Console.WriteLine(webExcp.ToString());  
    // Get the WebException status code.  
    WebExceptionStatus status =  webExcp.Status;  
    // If status is WebExceptionStatus.ProtocolError,   
    //   there has been a protocol error and a WebResponse   
    //   should exist. Display the protocol error.  
    if (status == WebExceptionStatus.ProtocolError) {  
        Console.Write("The server returned protocol error ");  
        // Get HttpWebResponse so that you can check the HTTP status code.  
        HttpWebResponse httpResponse = (HttpWebResponse)webExcp.Response;  
        Console.WriteLine((int)httpResponse.StatusCode + " - "  
           + httpResponse.StatusCode);  
    }  
}  
catch (Exception e)   
{  
    // Code to catch other exceptions goes here.  
}  
```  
  
```vb  
Try  
    ' Create a request instance.  
    Dim myRequest As WebRequest = WebRequest.Create("http://www.contoso.com")  
    ' Get the response.  
    Dim myResponse As WebResponse = myRequest.GetResponse()  
    'Get a readable stream from the server.   
    Dim sr As Stream = myResponse.GetResponseStream()  
  
    Dim i As Integer      
    'Read from the stream and write any data to the console.  
    bytesread = sr.Read(myBuffer, 0, length)  
    While bytesread > 0  
        For i = 0 To bytesread - 1  
            Console.Write("{0}", myBuffer(i))  
        Next i  
        Console.WriteLine()  
        bytesread = sr.Read(myBuffer, 0, length)  
    End While  
    sr.Close()  
    myResponse.Close()  
Catch webExcp As WebException  
    ' If you reach this point, an exception has been caught.  
    Console.WriteLine("A WebException has been caught.")  
    ' Write out the WebException message.  
    Console.WriteLine(webExcp.ToString())  
    ' Get the WebException status code.  
    Dim status As WebExceptionStatus = webExcp.Status  
    ' If status is WebExceptionStatus.ProtocolError,   
    '   there has been a protocol error and a WebResponse   
    '   should exist. Display the protocol error.  
    If status = WebExceptionStatus.ProtocolError Then  
        Console.Write("The server returned protocol error ")  
        ' Get HttpWebResponse so that you can check the HTTP status code.  
        Dim httpResponse As HttpWebResponse = _  
           CType(webExcp.Response, HttpWebResponse)  
        Console.WriteLine(CInt(httpResponse.StatusCode).ToString() & _  
           " - " & httpResponse.StatusCode.ToString())  
    End If  
Catch e As Exception  
    ' Code to catch other exceptions goes here.  
End Try  
```  
  
 Applications that use the <xref:System.Net.Sockets.Socket> class throw <xref:System.Net.Sockets.SocketException> when errors occur on the Windows socket. The <xref:System.Net.Sockets.TcpClient>, <xref:System.Net.Sockets.TcpListener>, and <xref:System.Net.Sockets.UdpClient> classes are built on top of the **Socket** class and throw **SocketExceptions** as well.  
  
 When a **SocketException** is thrown, the **SocketException** class sets the <xref:System.Net.Sockets.SocketException.ErrorCode%2A> property to the last operating system socket error that occurred. For more information about socket error codes, see the Winsock 2.0 API error code documentation in MSDN.  
  
## See Also  
 [Exception Handling Fundamentals](../../../docs/standard/exceptions/exception-handling-fundamentals.md)  
 [Requesting Data](../../../docs/framework/network-programming/requesting-data.md)
