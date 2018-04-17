---
title: "XSLT Extension Objects"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: a4ebdbad-087c-4cfe-acc0-17c48142f81a
caps.latest.revision: 3
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# XSLT Extension Objects
Extension objects are used to extend the functionality of style sheets. Extension objects are maintained by the <xref:System.Xml.Xsl.XsltArgumentList> class.  
  
 The following are advantages to using an extension object rather than embedded script:  
  
-   Provides better encapsulation and reuse of classes.  
  
-   Allows style sheets to be smaller and more maintainable.  
  
 XSLT extension objects are added to the <xref:System.Xml.Xsl.XsltArgumentList> object using the <xref:System.Xml.Xsl.XsltArgumentList.AddExtensionObject%2A> method. A qualified name and namespace URI are associated with the extension object at that time.  
  
> [!NOTE]
>  The FullTrust permission set is required to call the <xref:System.Xml.Xsl.XsltArgumentList.AddExtensionObject%2A> method. For more information, see [Code Access Security](http://msdn.microsoft.com/library/23a20143-241d-4fe5-9d9f-3933fd594c03) and [NIB: Named Permission Sets](https://msdn.microsoft.com/library/08250d67-c99d-4ab0-8d2b-b0e12019f6e3).  
  
 The data types returned from extension objects are one of the four basic XPath data types of `number`, `string`, `Boolean`, and `node set`.  
  
 Any method that is defined with the `params` keyword, which allows an unspecified number of parameters to be passed, is not currently supported by the <xref:System.Xml.Xsl.XslCompiledTransform> class. XSLT style sheets that utilize any method defined with the `params` keyword will not work correctly. For details, see [params](~/docs/csharp/language-reference/keywords/params.md).  
  
### To use an XSLT extension object  
  
1.  Create an <xref:System.Xml.Xsl.XsltArgumentList> object and add the extension object using <xref:System.Xml.Xsl.XsltArgumentList.AddExtensionObject%2A> method.  
  
2.  Call the extension object from the style sheet.  
  
3.  Pass the <xref:System.Xml.Xsl.XsltArgumentList> object to the <xref:System.Xml.Xsl.XslCompiledTransform.Transform%2A> method.  
  
## See Also  
 [XSLT Transformations](../../../../docs/standard/data/xml/xslt-transformations.md)  
 [XSLT Security Considerations](../../../../docs/standard/data/xml/xslt-security-considerations.md)
