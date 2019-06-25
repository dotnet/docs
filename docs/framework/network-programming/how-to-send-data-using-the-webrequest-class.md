---
title: "How to: Send data by using the WebRequest class"
ms.date: "03/25/2019"
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
  
1. Create a <xref:System.Net.WebRequest> instance by calling <xref:System.Net.WebRequest.Create%2A?displayProperty=nameWithType> with the URI of a resource, such as a script or ASP.NET page, that accepts data. For example: 
  
    ```csharp  
    WebRequest request = WebRequest.Create("http://www.contoso.com/PostAccepter.aspx");  
    ```  
  
    ```vb  
    Dim request as WebRequest = WebRequest.Create("http://www.contoso.com/PostAccepter.aspx")  
    ```  
  
    > [!NOTE]
    > The .NET Framework provides protocol-specific classes derived from the <xref:System.Net.WebRequest> and <xref:System.Net.WebResponse> classes for URIs that begin with *http:*, *https:*, *ftp:*, and *file:*.
    If you need to set or read protocol-specific properties, you must cast your <xref:System.Net.WebRequest> or <xref:System.Net.WebResponse> object to a protocol-specific object type. For more information, see [Programming pluggable protocols](programming-pluggable-protocols.md). 
  
2. Set any property values that you need in your `WebRequest` object. For example, to enable authentication, set the <xref:System.Net.WebRequest.Credentials%2A?displayProperty=nameWithType> property to an instance of the <xref:System.Net.NetworkCredential> class:
  
    ```csharp  
    request.Credentials = CredentialCache.DefaultCredentials;  
    ```  
  
    ```vb  
    request.Credentials = CredentialCache.DefaultCredentials  
    ```  
  
3. Specify a protocol method that permits data to be sent with a request, such as the HTTP `POST` method:  
  
    ```csharp  
    request.Method = "POST";  
    ```  
  
    ```vb  
    request.Method = "POST"  
    ```  
  
4. Set the <xref:System.Web.HttpRequest.ContentLength> property to the number of bytes you're including with your request. For example: 
  
    ```csharp  
    request.ContentLength = byteArray.Length;  
    ```  
  
    ```vb  
    request.ContentLength = byteArray.Length  
    ```  
  
5. Set the <xref:System.Web.HttpRequest.ContentType> property to an appropriate value. For example:
  
    ```csharp  
    request.ContentType = "application/x-www-form-urlencoded";  
    ```  
  
    ```vb  
    request.ContentType = "application/x-www-form-urlencoded"  
    ```  
  
6. Get the stream that holds request data by calling the <xref:System.Net.WebRequest.GetRequestStream%2A> method. For example:
  
    ```csharp  
    Stream dataStream = request.GetRequestStream();  
    ```  
  
    ```vb
    Dim dataStream As Stream = request.GetRequestStream()  
    ```  
  
7. Write the data to the <xref:System.IO.Stream> object returned by the `GetRequestStream` method. For example:
  
    ```csharp  
    dataStream.Write(byteArray, 0, byteArray.Length);  
    ```  
  
    ```vb  
    dataStream.Write(byteArray, 0, byteArray.Length)  
    ```  
  
8. Close the request stream by calling the <xref:System.IO.Stream.Close%2A?displayProperty=nameWithType> method. For example:
  
    ```csharp  
    dataStream.Close();  
    ```  
  
    ```vb  
    dataStream.Close()  
    ```  
  
9. Send the request to the server by calling <xref:System.Net.WebRequest.GetResponse%2A?displayProperty=nameWithType>. This method returns an object containing the server's response. The returned `WebResponse` object's type is determined by the scheme of the request's URI. For example:
  
    ```csharp  
    WebResponse response = request.GetResponse();  
    ```  
  
    ```vb  
    Dim response As WebResponse = request.GetResponse()  
    ```  
  
10. You can access the properties of your `WebResponse` object or cast it to a protocol-specific instance to read protocol-specific properties. 

    For example, to access the HTTP-specific properties of <xref:System.Net.HttpWebResponse>, cast your `WebResponse` object to an <xref:System.Net.HttpWebResponse> reference. The following code example shows how to display the HTTP-specific <xref:System.Net.HttpWebResponse.StatusDescription%2A?displayProperty=nameWithType> property sent with a response:
  
    ```csharp  
    Console.WriteLine(((HttpWebResponse)response).StatusDescription);    
    ```  
  
    ```vb  
    Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)  
    ```  
  
11. To get the stream containing response data sent by the server, call the <xref:System.Net.WebResponse.GetResponseStream%2A?displayProperty=nameWithType> method of your `WebResponse` object. For example:
  
    ```csharp  
    Stream dataStream = response.GetResponseStream();  
    ```  
  
    ```vb  
    Dim dataStream As Stream = response.GetResponseStream()  
    ```  
  
12. After you've read the data from the response object, either close it with the <xref:System.Net.WebResponse.Close%2A?displayProperty=nameWithType> method or close the response stream with the <xref:System.IO.Stream.Close%2A?displayProperty=nameWithType> method. If you don't close either the response or the stream, your application can run out of server connections and become unable to process additional requests. Because the `WebResponse.Close` method calls `Stream.Close` when it closes the response, it's not necessary to call `Close` on both the response and stream objects, although doing so isn't harmful. For example:
  
    ```csharp  
    response.Close();  
    ```  
  
    ```vb  
    response.Close()  
    ```  
  
## Example  
  
The following example shows how to send data to a web server and read the data in its response:  

[!code-csharp[SendDataUsingWebRequest](../../../samples/snippets/csharp/VS_Snippets_Network/SendDataUsingWebRequest/cs/WebRequestPostExample.cs)]
[!code-vb[SendDataUsingWebRequest](../../../samples/snippets/visualbasic/VS_Snippets_Network/SendDataUsingWebRequest/vb/WebRequestPostExample.vb)]

## See also

- [Creating internet requests](creating-internet-requests.md)
- [Using streams on the network](using-streams-on-the-network.md)
- [Accessing the internet through a proxy](accessing-the-internet-through-a-proxy.md)
- [Requesting data](requesting-data.md)
- [How to: Request data by using the WebRequest class](how-to-request-data-using-the-webrequest-class.md)
