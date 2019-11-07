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

## To request data from a host server

1. Create a <xref:System.Net.WebRequest> instance by calling <xref:System.Net.WebRequest.Create%2A?displayProperty=nameWithType> with the URI of a resource. For example:

    ```csharp
    WebRequest request = WebRequest.Create("https://docs.microsoft.com");
    ```

    ```vb
    Dim request as WebRequest = WebRequest.Create("https://docs.microsoft.com")
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

3. Send the request to the server by calling <xref:System.Net.WebRequest.GetResponse%2A?displayProperty=nameWithType>. This method returns an object containing the server's response. The returned <xref:System.Net.WebResponse> object's type is determined by the scheme of the request's URI. For example:

    ```csharp
    WebResponse response = request.GetResponse();
    ```

    ```vb
    Dim response As WebResponse = request.GetResponse()
    ```

4. You can access the properties of your `WebResponse` object or cast it to a protocol-specific instance to read protocol-specific properties.

    For example, to access the HTTP-specific properties of <xref:System.Net.HttpWebResponse>, cast your `WebResponse` object to an `HttpWebResponse` reference. The following code example shows how to display the HTTP-specific <xref:System.Net.HttpWebResponse.StatusDescription%2A?displayProperty=nameWithType> property sent with a response:

    ```csharp
    Console.WriteLine (((HttpWebResponse)response).StatusDescription);
    ```

    ```vb
    Console.WriteLine(CType(response,HttpWebResponse).StatusDescription)
    ```

5. To get the stream containing response data sent by the server, call the <xref:System.Net.WebResponse.GetResponseStream%2A?displayProperty=nameWithType> method. For example:

    ```csharp
    Stream dataStream = response.GetResponseStream();
    ```

    ```vb
    Dim dataStream As Stream = response.GetResponseStream()
    ```

6. After you've read the data from the response object, either close it with the <xref:System.Net.WebResponse.Close%2A?displayProperty=nameWithType> method or close the response stream with the <xref:System.IO.Stream.Close%2A?displayProperty=nameWithType> method. If you don't close either the response object or the stream, your application can run out of server connections and become unable to process additional requests. Because the `WebResponse.Close` method calls `Stream.Close` when it closes the response, it's not necessary to call `Close` on both the response and stream objects, although doing so isn't harmful. For example:

    ```csharp
    response.Close();
    ```

    ```vb
    response.Close()
    ```

## Example

The following code example shows how to create a request to a web server and read the data in its response:

[!code-csharp[RequestDataUsingWebRequest](../../../samples/snippets/csharp/VS_Snippets_Network/RequestDataUsingWebRequest/cs/WebRequestGetExample.cs)]
[!code-vb[RequestDataUsingWebRequest](../../../samples/snippets/visualbasic/VS_Snippets_Network/RequestDataUsingWebRequest/vb/WebRequestGetExample.vb)]

## See also

- [Creating internet requests](creating-internet-requests.md)
- [Using Streams on the network](using-streams-on-the-network.md)
- [Accessing the internet through a proxy](accessing-the-internet-through-a-proxy.md)
- [Requesting data](requesting-data.md)
- [How to: Send data by using the WebRequest class](how-to-send-data-using-the-webrequest-class.md)
