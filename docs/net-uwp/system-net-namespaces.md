---
title: "System.Net namespaces 1 | Microsoft Docs"
ms.custom: ""
ms.date: "12/16/2016"
ms.prod: "windows-client-threshold"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - ".net-for-windows-store-apps"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 440e9bfa-c4ba-4efd-80a5-3bfff9e7caa1
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# System.Net namespaces 1
`System.Net` and its child namespaces (`System.Net.Http`, `System.Net.Http.Headers`, and `System.Net.NetworkInformation`) contain types that provide networking support.  
  
 This topic displays the types in the `System.Net` namespaces that are included in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)]. Note that the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)] does not include all the members of each type. For information about individual types, see the linked topics. The documentation for a type indicates which members are included in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)].  
  
## System.Net namespace  
  
|Types supported in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)]|Description|  
|---------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.Net.AuthenticationSchemes>|Specifies protocols for authentication.|  
|<xref:System.Net.Cookie>|Provides a set of properties and methods that are used to manage cookies. This class cannot be inherited.|  
|<xref:System.Net.CookieCollection>|Provides a collection container for instances of the Cookie class.|  
|<xref:System.Net.CookieContainer>|Provides a container for a collection of CookieCollection objects.|  
|<xref:System.Net.CookieException>|The exception that is thrown when an error is made adding a Cookie to a CookieContainer.|  
|<xref:System.Net.CredentialCache>|Provides storage for multiple credentials.|  
|<xref:System.Net.DecompressionMethods>|Represents the file compression and decompression encoding format to be used to compress the data received in response to an HttpWebRequest.|  
|<xref:System.Net.HttpRequestHeader>|The HTTP headers that may be specified in a client request.|  
|<xref:System.Net.HttpStatusCode>|Contains the values of status codes defined for HTTP.|  
|<xref:System.Net.HttpWebRequest>|Provides an HTTP-specific implementation of the WebRequest class.|  
|<xref:System.Net.HttpWebResponse>|Provides an HTTP-specific implementation of the WebResponse class.|  
|<xref:System.Net.ICredentials>|Provides the base authentication interface for retrieving credentials for Web client authentication.|  
|<xref:System.Net.ICredentialsByHost>|Provides the interface for retrieving credentials for a host, port, and authentication type.|  
|<xref:System.Net.IWebProxy>|Provides the base interface for implementation of proxy access for the WebRequest class.|  
|<xref:System.Net.IWebRequestCreate>|Provides the base interface for creating WebRequest instances.|  
|<xref:System.Net.NetworkCredential>|Provides credentials for password-based authentication schemes such as basic, digest, NTLM, and Kerberos authentication.|  
|<xref:System.Net.ProtocolViolationException>|The exception that is thrown when an error is made while using a network protocol.|  
|<xref:System.Net.TransportContext>|The TransportContext class provides additional context about the underlying transport layer.|  
|<xref:System.Net.WebException>|The exception that is thrown when an error occurs while accessing the network through a pluggable protocol.|  
|<xref:System.Net.WebExceptionStatus>|Defines status codes for the WebException class.|  
|<xref:System.Net.WebHeaderCollection>|Contains protocol headers associated with a request or response.|  
|<xref:System.Net.WebRequest>|Makes a request to a Uniform Resource Identifier (URI). This is an abstract class.|  
|<xref:System.Net.WebResponse>|Provides a response from a Uniform Resource Identifier (URI). This is an abstract class.|  
|<xref:System.Net.WebUtility>|Provides methods for encoding and decoding URLs when processing Web requests.|  
  
## System.Net.Http namespace  
  
|Types supported in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)]|Description|  
|---------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.Net.Http.ByteArrayContent>|Provides HTTP content based on a byte array.|  
|<xref:System.Net.Http.ClientCertificateOption>|Specifies how client certificates are provided.|  
|<xref:System.Net.Http.DelegatingHandler>|A base type for HTTP handlers that delegate the processing of HTTP response messages to another handler, called the inner handler.|  
|<xref:System.Net.Http.FormUrlEncodedContent>|A container for name/value tuples encoded using application/x-www-form-urlencoded MIME type.|  
|<xref:System.Net.Http.HttpClient>|Provides a base class for sending HTTP requests and receiving HTTP responses from a resource identified by a URI.|  
|<xref:System.Net.Http.HttpClientHandler>|A base class for HTTP handler implementations.|  
|<xref:System.Net.Http.HttpCompletionOption>|Indicates if HttpClient operations should be considered completed either as soon as a response is available, or after reading the entire response message including the content.|  
|<xref:System.Net.Http.HttpContent>|A base class representing an HTTP entity body and content headers.|  
|<xref:System.Net.Http.HttpMessageHandler>|A base type for HTTP message handlers.|  
|<xref:System.Net.Http.HttpMessageInvoker>|The base type for HttpClient and other message originators.|  
|<xref:System.Net.Http.HttpMethod>|A helper class for retrieving and comparing standard HTTP methods.|  
|<xref:System.Net.Http.HttpRequestException>|A base class for exceptions thrown by the HttpClient and HttpMessageHandler classes.|  
|<xref:System.Net.Http.HttpRequestMessage>|Represents a HTTP request message.|  
|<xref:System.Net.Http.HttpResponseMessage>|Represents a HTTP response message.|  
|<xref:System.Net.Http.MessageProcessingHandler>|A base type for handlers which only do some small processing of request and/or response messages.|  
|<xref:System.Net.Http.MultipartContent>|Provides a collection of HttpContent objects that get serialized using the multipart content type specification.|  
|<xref:System.Net.Http.MultipartFormDataContent>|Provides a container for content encoded using multipart/form-data MIME type.|  
|<xref:System.Net.Http.RtcRequestFactory>|Represents the class that is used to create special HttpRequestMessage for use with the Real-Time-Communications (RTC) background notification infrastructure.|  
|<xref:System.Net.Http.StreamContent>|Provides HTTP content based on a stream.|  
|<xref:System.Net.Http.StringContent>|Provides HTTP content based on a string.|  
  
## System.Net.Http.Headers namespace  
  
|Types supported in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)]|Description|  
|---------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.Net.Http.Headers.AuthenticationHeaderValue>|Represents authentication information in Authorization, ProxyAuthorization, WWW-Authneticate, and Proxy-Authenticate header values.|  
|<xref:System.Net.Http.Headers.CacheControlHeaderValue>|Represents the value of the Cache-Control header.|  
|<xref:System.Net.Http.Headers.ContentDispositionHeaderValue>|Represents the value of the Content-Disposition header.|  
|<xref:System.Net.Http.Headers.ContentRangeHeaderValue>|Represents the value of the Content-Range header.|  
|<xref:System.Net.Http.Headers.EntityTagHeaderValue>|Represents an entity-tag header value.|  
|<xref:System.Net.Http.Headers.HttpContentHeaders>|Represents the collection of Content Headers as defined in RFC 2616.|  
|<xref:System.Net.Http.Headers.HttpHeaders>|A collection of headers and their values as defined in RFC 2616.|  
|<xref:System.Net.Http.Headers.HttpHeaderValueCollection%601>|Represents a collection of header values.|  
|<xref:System.Net.Http.Headers.HttpRequestHeaders>|Represents the collection of Request Headers as defined in RFC 2616.|  
|<xref:System.Net.Http.Headers.HttpResponseHeaders>|Represents the collection of Response Headers as defined in RFC 2616.|  
|<xref:System.Net.Http.Headers.MediaTypeHeaderValue>|Represents a media-type as defined in the RFC 2616.|  
|<xref:System.Net.Http.Headers.MediaTypeWithQualityHeaderValue>|Represents a content-type header value with an additional quality.|  
|<xref:System.Net.Http.Headers.NameValueHeaderValue>|Represents a name/value pair.|  
|<xref:System.Net.Http.Headers.NameValueWithParametersHeaderValue>|Represents a name/value pair with parameters.|  
|<xref:System.Net.Http.Headers.ProductHeaderValue>|Represents a product header value.|  
|<xref:System.Net.Http.Headers.ProductInfoHeaderValue>|Represents a value which can either be a product or a comment.|  
|<xref:System.Net.Http.Headers.RangeConditionHeaderValue>|Represents a header value which can either be a date/time or an entity-tag value.|  
|<xref:System.Net.Http.Headers.RangeHeaderValue>|Represents the value of the Range header.|  
|<xref:System.Net.Http.Headers.RangeItemHeaderValue>|Represents a byte-range header value.|  
|<xref:System.Net.Http.Headers.RetryConditionHeaderValue>|Represents a header value which can either be a date/time or a timespan value.|  
|<xref:System.Net.Http.Headers.StringWithQualityHeaderValue>|Represents a string header value with an optional quality.|  
|<xref:System.Net.Http.Headers.TransferCodingHeaderValue>|Represents a transfer-coding header value.|  
|<xref:System.Net.Http.Headers.TransferCodingWithQualityHeaderValue>|Represents a transfer-coding header value with optional quality.|  
|<xref:System.Net.Http.Headers.ViaHeaderValue>|Represents the value of a Via header.|  
|<xref:System.Net.Http.Headers.WarningHeaderValue>|Represents a warning value used by the Warning header.|  
  
## System.Net.NetworkInformation namespace  
  
|Types supported in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)]|Description|  
|---------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.Net.NetworkInformation.NetworkAddressChangedEventHandler>|References one or more methods to be called when the address of a network interface changes.|  
|<xref:System.Net.NetworkInformation.NetworkChange>|Allows applications to receive notification when the Internet Protocol (IP) address of a network interface, also called a network card or adapter, changes.|  
|<xref:System.Net.NetworkInformation.NetworkInterface>|Provides configuration and statistical information for a network interface.|  
  
## See Also  
 [.NET for Windows apps](../net-uwp/dotnet-for-windows-apps.md)