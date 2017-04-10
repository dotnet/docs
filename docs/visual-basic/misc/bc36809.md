---
title: "XML descendant elements cannot be selected from type &#39;type&#39; | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net


ms.technology: 
  - "devlang-visual-basic"

ms.topic: "article"
f1_keywords: 
  - "vbc36809"
  - "bc36809"
helpviewer_keywords: 
  - "BC36809"
ms.assetid: 560a3370-f24d-4ca3-93b1-39aabe13c238
caps.latest.revision: 7
author: dotnet-bot
ms.author: dotnetcontent

translation.priority.ht: 
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "ru-ru"
  - "zh-cn"
  - "zh-tw"
translation.priority.mt: 
  - "cs-cz"
  - "pl-pl"
  - "pt-br"
  - "tr-tr"
---
# XML descendant elements cannot be selected from type &#39;type&#39;
An XML descendant has been referenced for an object that is not of type <xref:System.Xml.Linq.XElement>, <xref:System.Xml.Linq.XDocument>, or `IEnumerable(Of XElement)`. For more information, see [XML Descendant Axis Property](../../visual-basic/language-reference/xml-axis/xml-descendant-axis-property.md).  
  
```vb  
' Generates an error.  
Dim var = "sample text"...<childElement>  
```  
  
 **Error ID:** BC36809  
  
## To correct this error  
  
-   Ensure that the object of which you are referencing a descendant element is strongly typed as <xref:System.Xml.Linq.XElement>, <xref:System.Xml.Linq.XDocument>, or `IEnumerable(Of XElement)`. Following is an example:  
  
```vb  
Dim elem As XElement = <root>  
                         <child />  
                       </root>  
Dim var = elem...<child>  
```  
  
## See Also  
 [XML Descendant Axis Property](../../visual-basic/language-reference/xml-axis/xml-descendant-axis-property.md)   
 [XML Axis Properties](../../visual-basic/language-reference/xml-axis/xml-axis-properties.md)   
 [XML](../../visual-basic/programming-guide/language-features/xml/index.md)