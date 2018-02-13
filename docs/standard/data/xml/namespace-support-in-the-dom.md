---
title: "Namespace Support in the DOM"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: f0548ead-0fed-41ee-b33e-117ba900d3bc
caps.latest.revision: 3
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Namespace Support in the DOM
The XML Document Object Model (DOM) is completely namespace-aware. Only namespace-aware XML documents are supported. The World Wide Web Consortium (W3C) specifies that DOM applications that implement Level 1 can be non-namespace-aware, and DOM Level 2 features are namespace-aware. However, all features in the XML DOM are namespace-aware, regardless if the method is from the Level 1 or Level 2 DOM Recommendation.  
  
 For example, in a non-namespace-aware setting, calling `setAttribute("A:b", "123")`, as specified in the DOM Level 1 Recommendation, does not result in an attribute with a prefix of `A` and a local name of `b`. It would result in an attribute with the value `A:b`.  
  
 In a namespace-aware environment, the call to the DOM Level 2 `setAttribute("A:b", "123")` results in an attribute with a prefix of `A` and a local name of `b`. This is how the Microsoft .NET Framework DOM works.  
  
 Therefore, for all methods that take a name parameter, these methods also take a prefix to qualify the name. The name parameter, such as the `A:b` in the **setAttribute** DOM Level 1 method, is parsed as follows:  
  
-   If there are no colon (:) characters, then the local name is set to the `name` parameter, and the prefix and NamespaceURI are empty strings.  
  
-   If a colon is found, then the name is split into two parts based on the position of the first colon character. The prefix is set to the string found before the colon, and local name is set to the string found after the colon. For methods that do not take a NamespaceURI value, the NamespaceURI is not resolved and remains set to empty string. Otherwise, the NamespaceURI is set to the string passed to the method. If the prefix is undefined, then the **Save** method and **InnerXml** and **OuterXml** properties fail.  
  
## See Also  
 [XML Document Object Model (DOM)](../../../../docs/standard/data/xml/xml-document-object-model-dom.md)
