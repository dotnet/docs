---
title: "FTP - .NET"
description: Learn about the comprehensive support for the FTP protocol that the .NET Framework provides by using the FtpWebRequest and FtpWebResponse classes.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "FTP"
ms.assetid: 9b43f8b4-89d7-46a7-89fc-71aca916dd32
---
# FTP

The .NET Framework provides comprehensive support for the FTP protocol with the <xref:System.Net.FtpWebRequest> and <xref:System.Net.FtpWebResponse> classes. These classes are derived from <xref:System.Net.WebRequest> and <xref:System.Net.WebResponse>. In most cases, the <xref:System.Net.WebRequest> and <xref:System.Net.WebResponse> classes provide all that is necessary to make the request, but if you need access to the FTP-specific features exposed as properties, you can typecast these classes to <xref:System.Net.FtpWebRequest> or <xref:System.Net.FtpWebResponse>.

> [!NOTE]
> This article is specific to projects that target .NET Framework. For projects that target .NET 6 and later versions, [FTP is no longer supported](../../core/compatibility/networking/6.0/webrequest-deprecated.md).

## Examples

For more information, see the following topics: [How to: Download Files with FTP](how-to-download-files-with-ftp.md), [How to: Upload Files with FTP](how-to-upload-files-with-ftp.md), and [How to: List Directory Contents with FTP](how-to-list-directory-contents-with-ftp.md).

## FTP and proxies

If a proxy (specified by the <xref:System.Net.FtpWebRequest.Proxy%2A> property) is an HTTP proxy, then only the <xref:System.Net.WebRequestMethods.Ftp.DownloadFile>, <xref:System.Net.WebRequestMethods.Ftp.ListDirectory>, and <xref:System.Net.WebRequestMethods.Ftp.ListDirectoryDetails> commands are supported.

## See also

- [Accessing the Internet Through a Proxy](accessing-the-internet-through-a-proxy.md)
- [Network Programming Samples](network-programming-samples.md)
- [Using Application Protocols](using-application-protocols.md)
