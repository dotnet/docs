---
title: "<inheritdoc> - C# Programming Guide"
ms.date: 01/21/2020
f1_keywords: 
  - "inheritdoc"
  - "<inheritdoc>"
helpviewer_keywords: 
  - "<inheritdoc> C# XML tag"
  - "inheritdoc C# XML tag"
ms.assetid: 46d329b1-5b84-4537-9e17-73ca97313e4e
---
# \<inheritdoc> (C# Programming Guide)
## Syntax  
  
```xml  
<inheritdoc/> 
```  
  
## InheritDoc  
Inherit XML comments from base classes, interfaces, and similar methods. This eliminates unwanted copying and pasting of duplicate XML comments and automatically keeps XML comments sychronized. 
  
## Remarks  
Add your XML comments in base classes and let InheritDoc copy the comments to implementing classes.

Add your XML comments in interfaces and let InheritDoc copy the comments to implementing classes.

Add your XML comments to your synchronous methods and let InheritDoc copy the comments to your asynchronous versions of the same methods.  
  
## See also

- [C# Programming Guide](../index.md)
- [Recommended Tags for Documentation Comments](./recommended-tags-for-documentation-comments.md)
