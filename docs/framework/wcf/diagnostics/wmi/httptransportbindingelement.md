---
title: "HttpTransportBindingElement"
ms.date: "03/30/2017"
ms.assetid: 088a7bce-6bb2-4839-ad74-f68d4b1aa0f9
---
# HttpTransportBindingElement
HttpTransportBindingElement  
  
## Syntax  
  
```csharp
class HttpTransportBindingElement : TransportBindingElement  
{  
  boolean AllowCookies;  
  string AuthenticationScheme;  
  boolean BypassProxyOnLocal;  
  string HostNameComparisonMode;  
  boolean KeepAliveEnabled;  
  sint32 MaxBufferSize;  
  string ProxyAddress;  
  string ProxyAuthenticationScheme;  
  string Realm;  
  string TransferMode;  
  boolean UnsafeConnectionNtlmAuthentication;  
  boolean UseDefaultWebProxy;  
};  
```  
  
## Methods  
 The HttpTransportBindingElement class does not define any methods.  
  
## Properties  
 The HttpTransportBindingElement class has the following properties:  
  
### AllowCookies  
 Data type: boolean  
  
 Access type: Read-only  
  
 A value that indicates whether the client accepts cookies and propagates them on future requests.  
  
### AuthenticationScheme  
 Data type: string  
  
 Access type: Read-only  
  
 The authentication scheme used to authenticate client requests being processed by an HTTP listener.  
  
### BypassProxyOnLocal  
 Data type: boolean  
  
 Access type: Read-only  
  
 A value that indicates whether proxies are ignored for local addresses.  
  
### HostNameComparisonMode  
 Data type: string  
  
 Access type: Read-only  
  
 A value that indicates whether the hostname is used to reach the service when matching on the URI.  
  
### KeepAliveEnabled  
 Data type: boolean  
  
 Access type: Read-only  
  
 When enabled, HTTP connections are kept alive regardless of activity level.  
  
### MaxBufferSize  
 Data type: sint32  
  
 Access type: Read-only  
  
 The maximum size of the buffer pool.  
  
### ProxyAddress  
 Data type: string  
  
 Access type: Read-only  
  
 A URI that contains the address of the proxy to use for HTTP requests.  
  
### ProxyAuthenticationScheme  
 Data type: string  
  
 Access type: Read-only  
  
 The authentication scheme used to authenticate client requests being processed by an HTTP proxy.  
  
### Realm  
 Data type: string  
  
 Access type: Read-only  
  
 The authentication realm.  
  
### TransferMode  
 Data type: string  
  
 Access type: Read-only  
  
 A value that specifies whether messages are buffered or streamed or a request or response.  
  
### UnsafeConnectionNtlmAuthentication  
 Data type: boolean  
  
 Access type: Read-only  
  
 A value that indicates whether Unsafe Connection Sharing is enabled on the server.  
  
### UseDefaultWebProxy  
 Data type: boolean  
  
 Access type: Read-only  
  
 A value that indicates whether the machine-wide proxy settings are used rather than the user specific settings.  
  
## Requirements  
  
|MOF|Declared in Servicemodel.mof.|  
|---------|-----------------------------------|  
|Namespace|Defined in root\ServiceModel|  
  
## See also

- <xref:System.ServiceModel.Channels.HttpTransportBindingElement>
