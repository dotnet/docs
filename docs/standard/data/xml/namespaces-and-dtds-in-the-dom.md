---
title: "Namespaces and DTDs in the DOM"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 1e9b55c4-76ad-4f54-8d96-7ce4b4cf1e05
caps.latest.revision: 3
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Namespaces and DTDs in the DOM
Document type definitions (DTDs) complicate namespace support. For example, the following XML contains default attributes containing colons in their names.  
  
```xml  
<!ATTLIST item x:id CDATA #IMPLIED>  
```  
  
 The following are possible resolutions if this construct is allowed:  
  
-   The `x:` is treated as a namespace prefix, but this prefix must be resolvable using an `xmlns:x` namespace declaration, which must also exist somewhere in the DTD. It is an error to map this prefix to something different in the instance document.  
  
-   The `x:` is treated as a namespace prefix, but this prefix is always resolved in the context of the instance elements. This means the prefix could actually map to different namespace Uniform Resource Identifiers (URIs), depending on the namespace scope in which the `item` element appears. This behavior is more predictable than the resolution given in the earlier bullet, but it has other complicated ramifications because it requires the default attributes be materialized.  
  
-   The colon is ignored because it is in a DTD, and the name of the attribute is `x:y`, no prefix and no namespace URI.  
  
-   The colon in the default attribute throws an exception, saying that colons in names inside a DTD are not supported. This results in a predictable behavior, but means you cannot load many of the World Wide Web Consortium (W3C) published DTDs.  
  
-   When the user requests DTD validation, namespace support for the entire document is turned off. This makes it possible to load W3C DTDs and results in a predictable behavior.  
  
 The XML in the Microsoft .NET Framework implements the second option for maximum W3C compatibility.  
  
## See Also  
 [XML Document Object Model (DOM)](../../../../docs/standard/data/xml/xml-document-object-model-dom.md)
