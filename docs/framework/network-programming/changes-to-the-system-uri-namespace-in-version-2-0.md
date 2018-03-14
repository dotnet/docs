---
title: "Changes to the System.Uri namespace in Version 2.0"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 35883fe9-2d09-4d8b-80ca-cf23a941e459
caps.latest.revision: 9
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Changes to the System.Uri namespace in Version 2.0
Several changes were made to the <xref:System.Uri?displayProperty=nameWithType> class. These changes fixed incorrect behavior, enhanced usability, and enhanced security.  
  
## Obsolete and Deprecated Members  
 Constructors:  
  
-   All constructors that have a `dontEscape` parameter.  
  
 Methods:  
  
-   <xref:System.Uri.CheckSecurity%2A>  
  
-   <xref:System.Uri.Escape%2A>  
  
-   <xref:System.Uri.Canonicalize%2A>  
  
-   <xref:System.Uri.Parse%2A>  
  
-   <xref:System.Uri.IsReservedCharacter%2A>  
  
-   <xref:System.Uri.IsBadFileSystemCharacter%2A>  
  
-   <xref:System.Uri.IsExcludedCharacter%2A>  
  
-   <xref:System.Uri.EscapeString%2A>  
  
## Changes  
  
-   For URI schemes that are known to not have a query part (file, ftp, and others), the '?' character is always escaped and is not considered the beginning of a <xref:System.Uri.Query%2A> part.  
  
-   For implicit file URIs (of the form "c:\directory\file@name.txt"), the fragment character ('#') is always escaped unless full unescaping is requested or <xref:System.Uri.LocalPath%2A> is `true`.  
  
-   UNC hostname support was removed; the IDN specification for representing international hostnames was adopted.  
  
-   <xref:System.Uri.LocalPath%2A> always returns a completely unescaped string.  
  
-   <xref:System.Uri.ToString%2A> does not unescape an escaped '%', '?', or '#' character.  
  
-   <xref:System.Uri.Equals%2A> now includes the <xref:System.Uri.Query%2A> part in the equality check.  
  
-   Operators "==" and "!=" are overridden and linked to the <xref:System.Uri.Equals%2A> method.  
  
-   <xref:System.Uri.IsLoopback%2A> now produces consistent results.  
  
-   The URI "`file:///path`" is no longer translated into "file://path".  
  
-   "#" is now recognized as a host name terminator. That is, "http://consoto.com#fragment" is now converted to "http://contoso.com/#fragment".  
  
-   A bug when combining a base URI with a fragment has been fixed.  
  
-   A bug in <xref:System.Uri.HostNameType%2A> is fixed.  
  
-   A bug in NNTP parsing is fixed.  
  
-   A URI of the form HTTP:contoso.com now throws a parsing exception.  
  
-   The Framework correctly handles userinfo in a URI.  
  
-   URI path compression is fixed so that a broken URI cannot traverse the file system above the root.  
  
## See Also  
 <xref:System.Uri?displayProperty=nameWithType>
