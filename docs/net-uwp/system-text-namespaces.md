---
title: "System.Text namespaces1 | Microsoft Docs"
ms.custom: ""
ms.date: "12/16/2016"
ms.prod: "windows-client-threshold"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - ".net-for-windows-store-apps"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 6eea8bdd-b135-458e-81f7-4f458d897c31
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# System.Text namespaces1
The `System.Text` and `System.Text.RegularExpressions` namespaces contain types for character encoding, string manipulation, and processing text using regular expressions.  
  
 This topic displays the types in the `System.Text` and `System.Text.RegularExpressions` namespaces that are included in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)]. Note that the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)] does not include all the members of each type. For information about individual types, see the linked topics. The documentation for a type indicates which members are included in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)].  
  
## System.Text namespace  
  
|Types supported in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)]|Description|  
|---------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.Text.Decoder>|Converts a sequence of encoded bytes into a set of characters.|  
|<xref:System.Text.DecoderFallbackException>|The exception that is thrown when a decoder fallback operation fails. This class cannot be inherited.|  
|<xref:System.Text.Encoder>|Converts a set of characters into a sequence of bytes.|  
|<xref:System.Text.EncoderFallbackException>|The exception that is thrown when an encoder fallback operation fails. This class cannot be inherited.|  
|<xref:System.Text.Encoding>|Represents a character encoding.|  
|<xref:System.Text.StringBuilder>|Represents a mutable string of characters. This class cannot be inherited.|  
|<xref:System.Text.UnicodeEncoding>|Represents a UTF-16 encoding of Unicode characters.|  
|<xref:System.Text.UTF8Encoding>|Represents a UTF-8 encoding of Unicode characters.|  
  
## System.Text.RegularExpressions namespace  
  
|Types supported in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)]|Description|  
|---------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.Text.RegularExpressions.Capture>|Represents the results from a single successful subexpression capture.|  
|<xref:System.Text.RegularExpressions.CaptureCollection>|Represents the set of captures made by a single capturing group.|  
|<xref:System.Text.RegularExpressions.Group>|Represents the results from a single capturing group.|  
|<xref:System.Text.RegularExpressions.GroupCollection>|Returns the set of captured groups in a single match.|  
|<xref:System.Text.RegularExpressions.Match>|Represents the results from a single regular expression match.|  
|<xref:System.Text.RegularExpressions.MatchCollection>|Represents the set of successful matches found by iteratively applying a regular expression pattern to the input string.|  
|<xref:System.Text.RegularExpressions.MatchEvaluator>|Represents the method that is called each time a regular expression match is found during a Replace method operation.|  
|<xref:System.Text.RegularExpressions.Regex>|Represents an immutable regular expression.|  
|<xref:System.Text.RegularExpressions.RegexMatchTimeoutException>|The exception that is thrown when the execution time of a regular expression pattern-matching method exceeds its time-out interval.|  
|<xref:System.Text.RegularExpressions.RegexOptions>|Provides enumerated values to use to set regular expression options.|  
  
## See Also  
 [.NET for Windows apps](../net-uwp/dotnet-for-windows-apps.md)