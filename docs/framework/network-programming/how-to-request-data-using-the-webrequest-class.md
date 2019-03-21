---
title: "How to: Request data by using the WebRequest class"
ms.date: "03/21/2019"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "downloading Internet resources, steps"
  - "requesting data from Internet, steps"
  - "WebRequest class, receiving data"
  - "receiving data, using WebRequest class"
  - "Internet, requesting data"
ms.assetid: 368b8d0f-dc5e-4469-a8b8-b2adbf5dd800
---
# How to: Request data by using the WebRequest class
The following procedure describes the steps to request a resource, such as a Web page or a file, from a server. The resource must be identified by a URI.  
  
### To request data from a host server  
  
1.  Create a <xref:System.Net.WebRequest> instance by calling <xref:System.Net.WebRequest.Create%2A> with the URI of the resource.  
  
    ```csharp  
    WebRequest request = WebRequest.Create("http://www.contoso.com/");  
    ```  
  
    ```vb  
    Dim request as WebRequest = WebRequest.Create("http://www.contoso.com/")  
    ```  
  
    > [!NOTE]
    >  The .NET Framework provides protocol-specific classes derived from the <xref:System.Net.WebRequest> and <xref:System.Net.WebResponse> classes for URIs that begin with *http:*, *https:*, *ftp:*, and *file:*. To access resources by using other protocols, implement protocol-specific classes that derive from `WebRequest` and `WebResponse`. For more information, see [Programming pluggable protocols](programming-pluggable-protocols.md).  
  
2.  Set any property values that you need in your `WebRequest` object. For example, to enable authentication, set the `Credentials` property to an instance of the <xref:System.Net.NetworkCredential> class.  
  
    ```csharp  
    request.Credentials = CredentialCache.DefaultCredentials;  
    ```  
  
    ```vb  
    request.Credentials = CredentialCache.DefaultCredentials  
    ```  
  
     In most cases, a `WebRequest` object is sufficient to receive data. However, if you need to set protocol-specific properties, you must cast your `WebRequest` object to the protocol-specific object type. For example, to access the HTTP-specific properties of <xref:System.Net.HttpWebRequest>, cast your `WebRequest` object to an `HttpWebRequest` reference. The following code example shows how to set the HTTP-specific <xref:System.Net.HttpWebRequest.UserAgent%2A> property.  
  
    ```csharp  
    ((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";  
    ```  
  
    ```vb  
    Ctype(request,HttpWebRequest).UserAgent = ".NET Framework Example Client"  
    ```  
  
3.  To send the request to the server, call the <xref:System.Net.HttpWebRequest.GetResponse%2A> method. The actual type of the returned `WebResponse` object is determined by the scheme of the requested URI.  
  
    ```csharp  
    WebResponse response = request.GetResponse();  
    ```  
  
    ```vb  
    Dim response As WebResponse = request.GetResponse()  
    ```  
  
    > [!NOTE]
    >  After you're finished with your <xref:System.Net.WebResponse> object, close it by calling the <xref:System.Net.WebResponse.Close%2A> method. Alternatively, if you've obtained a response stream from the response object, you can close the stream by calling the <xref:System.IO.Stream.Close%2A?displayProperty=nameWithType> method. If you don't close either the response or the stream, your application can run out of server connections and thus become unable to process additional requests.  
  
4.  You can access the properties of your `WebResponse` object or cast it to a protocol-specific instance to read protocol-specific properties. For example, to access the HTTP-specific properties of <xref:System.Net.HttpWebResponse>, cast `WebResponse` to an `HttpWebResponse` reference. The following code example shows how to display the status information sent with a response:  
  
    ```csharp  
    Console.WriteLine (((HttpWebResponse)response).StatusDescription);  
    ```  
  
    ```vb  
    Console.WriteLine(CType(response,HttpWebResponse).StatusDescription)  
    ```  
  
5.  To get the stream containing response data sent by the server, use the <xref:System.Net.HttpWebResponse.GetResponseStream%2A> method of your `WebResponse` object:  
  
    ```csharp  
    Stream dataStream = response.GetResponseStream();  
    ```  
  
    ```vb  
    Dim dataStream As Stream = response.GetResponseStream()  
    ```  
  
6.  After you've read the data from the `WebResonse` object, you must either close the response stream with the `Stream.Close` method or close the response object with the `WebResponse.Close` method. Because the `WebResponse.Close` method calls `Stream.Close` when it closes the response, it's not necessary to call `Close` on both the stream and response objects. However, doing so isn't harmful.
  
    ```csharp  
    response.Close();  
    ```  
  
    ```vb  
    response.Close()  
    ```  
  
## Example  
  
```csharp  
using System;  
using System.IO;  
using System.Net;  
using System.Text;  
  
namespace Examples.System.Net  
{  
    public class WebRequestGetExample  
    {  
        public static void Main()  
        {  
            // Create a request for the URL.   
            WebRequest request = WebRequest.Create(  
              "http://www.contoso.com/default.html");  
            // If required by the server, set the credentials.  
            request.Credentials = CredentialCache.DefaultCredentials;  

            // Get the response.  
            WebResponse response = request.GetResponse();  
            // Display the status.  
            Console.WriteLine (((HttpWebResponse)response).StatusDescription);  

            // Get the stream containing content returned by the server.  
            Stream dataStream = response.GetResponseStream();  
            // Open the stream by using a StreamReader for easy access.  
            StreamReader reader = new StreamReader(dataStream);  

            // Read the content.  
            string responseFromServer = reader.ReadToEnd();  
            // Display the content.  
            Console.WriteLine(responseFromServer);  

            // Clean up the streams and the response.  
            reader.Close();  
            response.Close();  
        }  
    }  
}  
```  
  
```vb  
Imports System  
Imports System.IO  
Imports System.Net  
Imports System.Text  

Namespace Examples.System.Net 

    Public Class WebRequestGetExample  

        Public Shared Sub Main()  

            ' Create a request for the URL.   
            Dim request As WebRequest = _  
              WebRequest.Create("http://www.contoso.com/default.html")  
            ' If required by the server, set the credentials.  
            request.Credentials = CredentialCache.DefaultCredentials  

            ' Get the response.  
            Dim response As WebResponse = request.GetResponse()  
            ' Display the status.  
            Console.WriteLine(CType(response,HttpWebResponse).StatusDescription)  

            ' Get the stream containing content returned by the server.  
            Dim dataStream As Stream = response.GetResponseStream()  
            ' Open the stream by using a StreamReader for easy access.  
            Dim reader As New StreamReader(dataStream)  

            ' Read the content.  
            Dim responseFromServer As String = reader.ReadToEnd()  
            ' Display the content.  
            Console.WriteLine(responseFromServer)  

            ' Clean up the streams and the response.  
            reader.Close()  
            response.Close() 

        End Sub   

    End Class  
 
End Namespace  
```  
  
## See also
- [Creating internet requests](creating-internet-requests.md)
- [Using Streams on the network](using-streams-on-the-network.md)
- [Accessing the internet through a proxy](accessing-the-internet-through-a-proxy.md)
- [Requesting data](requesting-data.md)
- [How to: Send data by using the WebRequest class](how-to-send-data-using-the-webrequest-class.md)
