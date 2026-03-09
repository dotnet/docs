---
title: System.Net.FtpWebRequest.Proxy property
description: Learn about the System.Net.FtpWebRequest.Proxy property.
ms.date: 01/24/2024
---
# System.Net.FtpWebRequest.Proxy property

[!INCLUDE [context](includes/context.md)]

> [!NOTE]
> This property is not supported on .NET Core, and setting it has no effect. Getting the property value returns `null`.

The <xref:System.Net.FtpWebRequest.Proxy> property identifies the <xref:System.Net.IWebProxy> instance that communicates with the FTP server. The proxy is set by the system by using configuration files and the Local Area Network settings. To specify that no proxy should be used, set <xref:System.Net.FtpWebRequest.Proxy*> to the proxy instance returned by the <xref:System.Net.GlobalProxySelection.GetEmptyWebProxy*?displayProperty=nameWithType> method. For more information about automatic proxy detection, see [Automatic Proxy Detection](/dotnet/framework/network-programming/automatic-proxy-detection).

You must set <xref:System.Net.FtpWebRequest.Proxy*> before writing data to the request's stream or getting the response. Changing <xref:System.Net.FtpWebRequest.Proxy*> after calling the <xref:System.Net.FtpWebRequest.GetRequestStream*>, <xref:System.Net.FtpWebRequest.BeginGetRequestStream*>, <xref:System.Net.FtpWebRequest.GetResponse*>, or <xref:System.Net.FtpWebRequest.BeginGetResponse*> method causes an <xref:System.InvalidOperationException> exception.

The <xref:System.Net.FtpWebRequest> class supports HTTP and ISA Firewall Client proxies.

If the specified proxy is an HTTP proxy, only the <xref:System.Net.WebRequestMethods.Ftp.DownloadFile>, <xref:System.Net.WebRequestMethods.Ftp.ListDirectory>, and <xref:System.Net.WebRequestMethods.Ftp.ListDirectoryDetails> commands are supported.
