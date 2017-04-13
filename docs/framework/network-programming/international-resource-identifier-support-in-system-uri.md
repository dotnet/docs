---
title: "International Resource Identifier Support in System.Uri | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "VB"
  - "CSharp"
  - "C++"
  - "jsharp"
ms.assetid: b5e994c3-3535-4aff-8e1b-b69be22e9a22
caps.latest.revision: 9
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
---
# International Resource Identifier Support in System.Uri
The <xref:System.Uri?displayProperty=fullName> class has been extended with International Resource Identifier (IRI) and Internationalized Domain Names (IDN) support. These enhancements are available in .NET Framework 3.5, 3.0 SP1, and 2.0 SP1.  
  
## IRI and IDN Support  
 Web addresses are typically expressed using Uniform Resource Identifiers (URI) that consist of a very restricted set of characters:  
  
-   Upper and lower case ASCII letters from the English alphabet.  
  
-   Digits from 0 to 9.  
  
-   A small number of other ASCII symbols.  
  
 The specifications for URIs are documented in RFC 2396 and RFC 3986 published by the Internet Engineering Task Force (IETF).  
  
 With the growth of the Internet, there is a growing need to identify resources using languages other than English. Identifiers which facilitate this need and allow non-ASCII characters (characters in the Unicode/ISO 10646 character set) are known as International Resource Identifiers (IRIs). The specifications for IRIs are documented in RFC 3987 published by IETF. Using IRIs allows a URL to contain Unicode characters.  
  
 The existing <xref:System.Uri?displayProperty=fullName> class has been extended to provide IRI support based on RFC 3987. Current users will not see any change from the .NET Framework 2.0 behavior unless they specifically enable IRI. This ensures application compatibility with prior versions of the .NET Framework.  
  
 An application can specify whether to use Internationalized Domain Name (IDN) parsing applied to domain names and whether IRI parsing rules should be applied. This can be done in the machine.config or in the app.config file.  
  
 Enabling IDN will convert all Unicode labels in a domain name to their Punycode equivalents. Punycode names contain only ASCII characters and always start with the xn-- prefix. The reason for this is to support existing DNS servers on the Internet, since most DNS servers only support ASCII characters (see RFC 3940).  
  
 Enabling IRI and IDN affects the value of the <xref:System.Uri.DnsSafeHost%2A?displayProperty=fullName> property. Enabling IRI and IDN can also change the behavior of the <xref:System.Uri.Equals%2A?displayProperty=fullName>, <xref:System.Uri.OriginalString%2A?displayProperty=fullName>, <xref:System.Uri.GetComponents%2A?displayProperty=fullName>, and <xref:System.Uri.IsWellFormedOriginalString%2A> methods.  
  
 The <xref:System.GenericUriParser?displayProperty=fullName> class has also been extended to allow creating a customizable parser that supports IRI and IDN. The behavior of a <xref:System.GenericUriParser?displayProperty=fullName> object is specified by passing a bitwise combination of the values available in the <xref:System.GenericUriParserOptions?displayProperty=fullName> enumeration to the <xref:System.GenericUriParser?displayProperty=fullName> constructor. The <xref:System.GenericUriParserOptions?displayProperty=fullName> type indicates the parser supports the parsing rules specified in RFC 3987 for International Resource Identifiers (IRI). Whether IRI is actually used depends on if IRI is enabled.  
  
 The <xref:System.GenericUriParserOptions?displayProperty=fullName> type indicates the parser supports Internationalized Domain Name (IDN) parsing (IDN) of host names. Whether IDN is actually used depends on if IDN is enabled.  
  
 Enabling IRI parsing will do normalization and character checking according to the latest IRI rules in RFC 3987. The default value is for IRI parsing to be disabled so normalization and character checking are done according to RFC 2396 and RFC 3986.  
  
 IRI and IDN processing in the <xref:System.Uri?displayProperty=fullName> class can also be controlled using the <xref:System.Configuration.IriParsingElement?displayProperty=fullName> and <xref:System.Configuration.IdnElement?displayProperty=fullName> configuration setting classes. The <xref:System.Configuration.IriParsingElement?displayProperty=fullName> setting enables or disables IRI processing in the <xref:System.Uri?displayProperty=fullName> class. The <xref:System.Configuration.IdnElement?displayProperty=fullName> setting enables or disables IDN processing in the <xref:System.Uri> class. The <xref:System.Configuration.IriParsingElement?displayProperty=fullName> setting also indirectly controls IDN. IRI processing must be enabled for IDN processing to be possible. If IRI processing is disabled, then IDN processing will be set to the default setting where the .NET Framework 2.0 behavior is used for compatibility and IDN names are not used.  
  
 The configuration setting for the <xref:System.Configuration.IriParsingElement?displayProperty=fullName> and <xref:System.Configuration.IdnElement?displayProperty=fullName> configuration classes will be read once when the first <xref:System.Uri?displayProperty=fullName> class is constructed. Changes to configuration settings after that time are ignored.  
  
## See Also  
 <xref:System.Configuration.IdnElement?displayProperty=fullName>   
 <xref:System.Configuration.IriParsingElement?displayProperty=fullName>   
 <xref:System.Uri?displayProperty=fullName>   
 <xref:System.Uri.DnsSafeHost%2A?displayProperty=fullName>