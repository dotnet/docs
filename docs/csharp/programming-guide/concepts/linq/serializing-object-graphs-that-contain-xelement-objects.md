---
title: "Serializing Object Graphs that Contain XElement Objects (C#) | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "CSharp"
ms.assetid: fcbc3951-3cc4-4d0f-9259-e97549ed68f0
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# Serializing Object Graphs that Contain XElement Objects (C#)
[!INCLUDE[csharpbanner](../../../../includes/csharpbanner.md)]

This topic introduces the capability of serializing object graphs that contain references to objects of type <xref:System.Xml.Linq.XElement>. To facility this type of serializing, <xref:System.Xml.Linq.XElement> implements the <xref:System.Xml.Serialization.IXmlSerializable> interface.  
  
 Note that only the <xref:System.Xml.Linq.XElement> class implements serialization.  
  
## In This Section  
  
|Topic|Description|  
|-----------|-----------------|  
|[How to: Serialize Using XmlSerializer (C#)](../../../../csharp/programming-guide/concepts/linq/how-to-serialize-using-xmlserializer.md)|Demonstrates how to serialize using <xref:System.Xml.Serialization.XmlSerializer>.|  
|[How to: Serialize Using DataContractSerializer (C#)](../../../../csharp/programming-guide/concepts/linq/how-to-serialize-using-datacontractserializer.md)|Demonstrates how to serialize using <xref:System.Runtime.Serialization.DataContractSerializer>.|  
  
## See Also  
 [Advanced LINQ to XML Programming (C#)](../../../../csharp/programming-guide/concepts/linq/advanced-linq-to-xml-programming.md)