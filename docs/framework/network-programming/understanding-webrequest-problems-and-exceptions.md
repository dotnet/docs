---
title: "Understanding WebRequest Problems and Exceptions"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 74a361a5-e912-42d3-8f2e-8e9a96880a2b
caps.latest.revision: 6
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Understanding WebRequest Problems and Exceptions
<xref:System.Net.WebRequest> and its derived classes (<xref:System.Net.HttpWebRequest>, <xref:System.Net.FtpWebRequest>, and <xref:System.Net.FileWebRequest>) throw exceptions to signal an abnormal condition. Sometimes the resolution of these problems is not obvious.  
  
## Solutions  
 Examine the <xref:System.Net.WebException.Status%2A> property of the <xref:System.Net.WebException> to determine the problem. The following table shows several status values and some possible resolutions.  
  
|Status|Details|Solution|  
|------------|-------------|--------------|  
|<xref:System.Net.WebExceptionStatus.SendFailure><br /><br /> -or-<br /><br /> <xref:System.Net.WebExceptionStatus.ReceiveFailure>|There is a problem with the underlying socket. The connection may have been reset.|Reconnect and resend the request.<br /><br /> Make sure the latest service pack is installed.<br /><br /> Increase the value of the <xref:System.Net.ServicePointManager.MaxServicePointIdleTime%2A?displayProperty=nameWithType> property.<br /><br /> Set <xref:System.Net.HttpWebRequest.KeepAlive%2A?displayProperty=nameWithType> to `false`.<br /><br /> Increase the number of maximum connections with the <xref:System.Net.ServicePointManager.DefaultConnectionLimit%2A> property.<br /><br /> Check the proxy configuration.<br /><br /> If using SSL, make sure the server process has permission to access the Certificate store.<br /><br /> If sending a large amount of data, set <xref:System.Net.HttpWebRequest.AllowWriteStreamBuffering%2A> to `false`.|  
|<xref:System.Net.WebExceptionStatus.TrustFailure>|The server certificate could not be validated.|Try to open the URI using Internet Explorer. Resolve any Security Alerts displayed by IE. If you cannot resolve the security alert, then you can create a certificate policy class that implements <xref:System.Net.ICertificatePolicy> that returns `true`, and pass it to <xref:System.Net.ServicePointManager.CertificatePolicy%2A>.<br /><br /> Refer to [http://support.microsoft.com/?id=823177](http://go.microsoft.com/fwlink/?LinkID=179653).<br /><br /> Make sure that the certificate of the Certificate Authority that signed the server certificate is added to the Trusted Certificate Authority list in Internet Explorer.<br /><br /> Make sure that the host name in the URL matches the common name on the server certificate.|  
|<xref:System.Net.WebExceptionStatus.SecureChannelFailure>|An error occurred in the SSL transaction, or there is a certificate problem.|The .NET Framework version 1.1 only supports SSL version 3.0. If the server is using only TLS version 1.0 or SSL version 2.0, the exception is thrown. Upgrade to .NET Framework version 2.0, and set <xref:System.Net.ServicePointManager.SecurityProtocol%2A> to match the server.<br /><br /> The client certificate was signed by a Certificate Authority (CA) that the server does not trust. Install the CA's certificate on the server. See [http://support.microsoft.com/?id=332077](http://go.microsoft.com/fwlink/?LinkID=179654).<br /><br /> Make sure you have the latest service pack installed.|  
|<xref:System.Net.WebExceptionStatus.ConnectFailure>|The connection failed.|A firewall or proxy is blocking the connection. Modify the firewall or proxy to allow the connection.<br /><br /> Explicitly designate a <xref:System.Net.WebProxy> in the client application by calling the <xref:System.Net.WebProxy> constructor (WebServiceProxyClass.Proxy = new WebProxy([http://server:80](http://server/), true)).<br /><br /> Run Filemon or Regmon to ensure that the worker process identity has the necessary permissions to access WSPWSP.dll, HKLM\System\CurrentControlSet\Services\DnsCache or HKLM\System\CurrentControlSet\Services\WinSock2.|  
|<xref:System.Net.WebExceptionStatus.NameResolutionFailure>|The Domain Name Service could not resolve the host name.|Configure the proxy correctly. See [http://support.microsoft.com/?id=318140](http://go.microsoft.com/fwlink/?LinkID=179655).<br /><br /> Ensure that any installed anti-virus software or firewall is not blocking the connection.|  
|<xref:System.Net.WebExceptionStatus.RequestCanceled>|<xref:System.Net.WebRequest.Abort%2A> was called, or an error occurred.|This problem might be caused by a heavy load on the client or server. Reduce the load.<br /><br /> Increase the <xref:System.Net.ServicePointManager.DefaultConnectionLimit%2A> setting.<br /><br /> See [http://support.microsoft.com/?id=821268](http://go.microsoft.com/fwlink/?LinkID=179656) to modify Web service performance settings.|  
|<xref:System.Net.WebExceptionStatus.ConnectionClosed>|The application attempted to write to a socket that has already been closed.|The client or server is overloaded. Reduce the load.<br /><br /> Increase the <xref:System.Net.ServicePointManager.DefaultConnectionLimit%2A> setting.<br /><br /> See [http://support.microsoft.com/?id=821268](http://go.microsoft.com/fwlink/?LinkID=179656) to modify Web service performance settings.|  
|<xref:System.Net.WebExceptionStatus.MessageLengthLimitExceeded>|The limit set (<xref:System.Net.HttpWebRequest.MaximumResponseHeadersLength%2A>) on the message length was exceeded.|Increase the value of the <xref:System.Net.HttpWebRequest.MaximumResponseHeadersLength%2A> property.|  
|<xref:System.Net.WebExceptionStatus.ProxyNameResolutionFailure>|The Domain Name Service could not resolve the proxy host name.|Configure the proxy correctly. See [http://support.microsoft.com/?id=318140](http://go.microsoft.com/fwlink/?LinkID=179655).<br /><br /> Force <xref:System.Net.HttpWebRequest> to use no proxy by setting the <xref:System.Net.HttpWebRequest.Proxy%2A> property to `null`.|  
|<xref:System.Net.WebExceptionStatus.ServerProtocolViolation>|The response from the server is not a valid HTTP response. This problem occurs when the .NET Framework detects that the server response does not comply with HTTP 1.1 RFC. This problem may occur when the response contains incorrect headers or incorrect header delimiters.RFC 2616 defines HTTP 1.1 and the valid format for the response from the server. For more information, see [http://www.ietf.org](http://go.microsoft.com/fwlink/?LinkID=147388).|Get a network trace of the transaction and examine the headers in the response.<br /><br /> If your application requires the server response without parsing (this could be a security issue), set `useUnsafeHeaderParsing` to `true` in the configuration file. See [\<httpWebRequest> Element (Network Settings)](../../../docs/framework/configure-apps/file-schema/network/httpwebrequest-element-network-settings.md).|  
  
## See Also  
 <xref:System.Net.HttpWebRequest>  
 <xref:System.Net.HttpWebResponse>  
 <xref:System.Net.Dns>
