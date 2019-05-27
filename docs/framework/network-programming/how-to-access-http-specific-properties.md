---
title: "How to: Access HTTP-Specific Properties"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: f8848c7e-f5c5-4d42-b86d-9951ff8f4146
---
# How to: Access HTTP-Specific Properties
This sample shows how to turn off the HTTP **Keep-alive** behavior and get the protocol version number from the Web server.  
  
## Example  
  
```vb  
Dim HttpWReq As HttpWebRequest= _  
    CType(WebRequest.Create("http://www.contoso.com"), HttpWebRequest)  
' Turn off connection keep-alives.  
HttpWReq.KeepAlive = False  
  
Dim HttpWResp As HttpWebResponse = _  
    CType(HttpWReq.GetResponse(), HttpWebResponse)  
  
' Get the HTTP protocol version number returned by the server.  
Dim ver As String = HttpWResp.ProtocolVersion.ToString()  
HttpWResp.Close()  
```  
  
```csharp  
HttpWebRequest HttpWReq =   
    (HttpWebRequest)WebRequest.Create("http://www.contoso.com");  
// Turn off connection keep-alives.  
HttpWReq.KeepAlive = false;  
  
HttpWebResponse HttpWResp = (HttpWebResponse)HttpWReq.GetResponse();  
  
// Get the HTTP protocol version number returned by the server.  
String ver = HttpWResp.ProtocolVersion.ToString();  
HttpWResp.Close();  
```  
  
## Compiling the Code  
 This example requires:  
  
- References to the **System.Net** namespace.  
  
## See also

- [Accessing the Internet Through a Proxy](../../../docs/framework/network-programming/accessing-the-internet-through-a-proxy.md)
- [Using Application Protocols](../../../docs/framework/network-programming/using-application-protocols.md)
- [HTTP](../../../docs/framework/network-programming/http.md)
