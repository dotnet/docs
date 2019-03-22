---
title: "How to: Send data by using the WebRequest class"
ms.date: "03/22/2019"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "WebRequest class, sending data to a host"
  - "Sending data to a host, using WebRequest class"
ms.assetid: 66686878-38ac-4aa6-bf42-ffb568ffc459
---
# How to: Send data by using the WebRequest class
The following procedure describes the steps to send data to a server. This procedure is commonly used to post data to a Web page. 
  
## To send data to a host server  
  
1.  Create a <xref:System.Net.WebRequest> instance by calling <xref:System.Net.WebRequest.Create%2A> with the URI of a resource, such as a script or ASP.NET page, that accepts data.  
  
    ```csharp  
    WebRequest request = WebRequest.Create("http://www.contoso.com/");  
    ```  
  
    ```vb  
    Dim request as WebRequest = WebRequest.Create("http://www.contoso.com/")  
    ```  
  
    > [!NOTE]
    > The .NET Framework provides protocol-specific classes derived from the <xref:System.Net.WebRequest> and <xref:System.Net.WebResponse> classes for URIs that begin with *http:*, *https:*, *ftp:*, and *file:*. To access resources by using other protocols, implement protocol-specific classes that derive from `WebRequest` and `WebResponse`. For more information, see [Programming pluggable protocols](programming-pluggable-protocols.md). 
  
2.  Set any property values that you need in your `WebRequest` object. For example, to enable authentication, set the `Credentials` property to an instance of the <xref:System.Net.NetworkCredential> class:  
  
    ```csharp  
    request.Credentials = CredentialCache.DefaultCredentials;  
    ```  
  
    ```vb  
    request.Credentials = CredentialCache.DefaultCredentials  
    ```  
  
     In most cases, a `WebRequest` object is sufficient to receive data. However, if you need to set protocol-specific properties, you must cast your `WebRequest` object to the protocol-specific object type. For example, to access the HTTP-specific properties of <xref:System.Net.HttpWebRequest>, cast your `WebRequest` object to an `HttpWebRequest` reference. The following code example shows how to set the HTTP-specific <xref:System.Net.HttpWebRequest.UserAgent%2A> property:  
  
    ```csharp  
    ((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";  
    ```  
  
    ```vb  
    Ctype(request,HttpWebRequest).UserAgent = ".NET Framework Example Client"  
    ```  
  
3.  Specify a protocol method that permits data to be sent with a request, such as the HTTP `POST` method.  
  
    ```csharp  
    request.Method = "POST";  
    ```  
  
    ```vb  
    request.Method = "POST"  
    ```  
  
4.  Set the `ContentLength` property.  
  
    ```csharp  
    request.ContentLength = byteArray.Length;  
    ```  
  
    ```vb  
    request.ContentLength = byteArray.Length  
    ```  
  
5.  Set the `ContentType` property to an appropriate value.  
  
    ```csharp  
    request.ContentType = "application/x-www-form-urlencoded";  
    ```  
  
    ```vb  
    request.ContentType = "application/x-www-form-urlencoded"  
    ```  
  
6.  Get the stream that holds request data by calling the <xref:System.Net.WebRequest.GetRequestStream%2A> method.  
  
    ```csharp  
    Stream dataStream = request.GetRequestStream ();  
    ```  
  
    ```vb  
    Stream dataStream = request.GetRequestStream ()  
    ```  
  
7.  Write the data to the <xref:System.IO.Stream> object returned by the `GetRequestStream` method.  
  
    ```csharp  
    dataStream.Write (byteArray, 0, byteArray.Length);  
    ```  
  
    ```vb  
    dataStream.Write (byteArray, 0, byteArray.Length)  
    ```  
  
8.  Close the request stream by calling the <xref:System.IO.Stream.Close%2A?displayProperty=nameWithType> method.  
  
    ```csharp  
    dataStream.Close ();  
    ```  
  
    ```vb  
    dataStream.Close ()  
    ```  
  
9. Send the request to the server by calling <xref:System.Net.WebRequest.GetResponse%2A>. This method returns an object containing the server's response. The returned <xref:System.Net.WebResponse> object's type is determined by the scheme of the request's URI.  
  
    ```csharp  
    WebResponse response = request.GetResponse();  
    ```  
  
    ```vb  
    Dim response As WebResponse = request.GetResponse()  
    ```  

    > [!NOTE]
    >  After you're finished with your <xref:System.Net.WebResponse> object, close it by calling the <xref:System.Net.WebResponse.Close%2A> method. Alternatively, if you've obtained a response stream from the response object, you can close the stream by calling the <xref:System.IO.Stream.Close%2A?displayProperty=nameWithType> method. If you don't close either the response or the stream, your application can run out of server connections and thus become unable to process additional requests.  
  
10. You can access the properties of your `WebResponse` object or cast it to a protocol-specific instance to read protocol-specific properties. For example, to access the HTTP-specific properties of <xref:System.Net.HttpWebResponse>, cast `WebResponse` to an `HttpWebResponse` reference. The following code example shows how to display the status information sent with a response:  
  
    ```csharp  
    Console.WriteLine (((HttpWebResponse)response).StatusDescription);  
    ```  
  
    ```vb  
    Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)  
    ```  
  
11. To get the stream containing response data sent by the server, call the <xref:System.Net.WebResponse.GetResponseStream%2A> method of your `WebResponse` object.  
  
    ```csharp  
    Stream data = response.GetResponseStream;  
    ```  
  
    ```vb  
    Dim data As Stream = response.GetResponseStream  
    ```  
  
12. After you've read the data from the response object, you must either close it with the `WebResponse.Close` method or close the response stream with the `Stream.Close` method. Because the `WebResponse.Close` method calls `Stream.Close` when it closes the response, it's not necessary to call `Close` on both the response and stream objects. However, doing so isn't harmful.
  
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
    public class WebRequestPostExample  
    {  
        public static void Main ()  
        {  
            // Create a request by using a URL that can receive a post.   
            WebRequest request = WebRequest.Create ("http://www.contoso.com/PostAccepter.aspx ");  
            // Set the Method property of the request to POST.  
            request.Method = "POST";  

            // Create POST data and convert it to a byte array.  
            string postData = "This is a test that posts this string to a Web server.";  
            byte[] byteArray = Encoding.UTF8.GetBytes (postData);  

            // Set the ContentType property of the WebRequest.  
            request.ContentType = "application/x-www-form-urlencoded";  
            // Set the ContentLength property of the WebRequest.  
            request.ContentLength = byteArray.Length;  

            // Get the request stream.  
            Stream dataStream = request.GetRequestStream ();  
            // Write the data to the request stream.  
            dataStream.Write (byteArray, 0, byteArray.Length);  
            // Close the stream.  
            dataStream.Close ();  

            // Get the response.  
            WebResponse response = request.GetResponse ();  
            // Display the status.  
            Console.WriteLine (((HttpWebResponse)response).StatusDescription);  

            // Get the stream containing content returned by the server.  
            dataStream = response.GetResponseStream ();  
            // Open the stream by using a StreamReader for easy access.  
            StreamReader reader = new StreamReader (dataStream);  

            // Read the content.  
            string responseFromServer = reader.ReadToEnd ();  
            // Display the content.  
            Console.WriteLine (responseFromServer);  

            // Clean up the stream.  
            reader.Close ();  
            dataStream.Close ();  
            response.Close ();  
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

    Public Class WebRequestPostExample  
  
        Public Shared Sub Main()  

            ' Create a request by using a URL that can receive a post.   
            Dim request As WebRequest = WebRequest.Create("http://www.contoso.com/PostAccepter.aspx ")  
            ' Set the Method property of the request to POST.  
            request.Method = "POST"  

            ' Create POST data and convert it to a byte array.  
            Dim postData As String = "This is a test that posts this string to a Web server."  
            Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)  

            ' Set the ContentType property of the WebRequest.  
            request.ContentType = "application/x-www-form-urlencoded"  
            ' Set the ContentLength property of the WebRequest.  
            request.ContentLength = byteArray.Length  

            ' Get the request stream.  
            Dim dataStream As Stream = request.GetRequestStream()  
            ' Write the data to the request stream.  
            dataStream.Write(byteArray, 0, byteArray.Length)  
            ' Close the stream.  
            dataStream.Close()  

            ' Get the response.  
            Dim response As WebResponse = request.GetResponse()  
            ' Display the status.  
            Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)  

            ' Get the stream containing content returned by the server.  
            dataStream = response.GetResponseStream()  
            ' Open the stream by using a StreamReader for easy access.  
            Dim reader As New StreamReader(dataStream)  

            ' Read the content.  
            Dim responseFromServer As String = reader.ReadToEnd()  
            ' Display the content.  
            Console.WriteLine(responseFromServer)  

            ' Clean up the stream.  
            reader.Close()  
            dataStream.Close()  
            response.Close()  

        End Sub  

    End Class  

End Namespace  
```  
  
## See also
- [Creating internet requests](creating-internet-requests.md)
- [Using streams on the network](using-streams-on-the-network.md)
- [Accessing the internet through a proxy](accessing-the-internet-through-a-proxy.md)
- [Requesting data](network-programming/requesting-data.md)
- [How to: Request data by using the WebRequest class](how-to-request-data-using-the-webrequest-class.md)
