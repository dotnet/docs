---
title: "How to: Find an Element with a Specific Child Element (C#)"
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
ms.assetid: 00cf5555-374e-4369-bf93-7bd2e7f21db3
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# How to: Find an Element with a Specific Child Element (C#)
This topic shows how to find a particular element that has a child element with a specific value.  
  
## Example  
 The example finds the `Test` element that has a `CommandLine` child element with the value of "Examp2.EXE".  
  
 This example uses the following XML document: [Sample XML File: Test Configuration (LINQ to XML)](../linq/sample-xml-file--test-configuration--linq-to-xml-1.md).  
  
```c#  
XElement root = XElement.Load("TestConfig.xml");  
IEnumerable<XElement> tests =  
    from el in root.Elements("Test")  
    where (string)el.Element("CommandLine") == "Examp2.EXE"  
    select el;  
foreach (XElement el in tests)  
    Console.WriteLine((string)el.Attribute("TestId"));  
```  
  
 This code produces the following output:  
  
```  
0002  
0006  
```  
  
## Example  
 The following example shows the same query for XML that is in a namespace. For more information, see [Working with XML Namespaces (C#)](../linq/working-with-xml-namespaces--csharp-.md).  
  
 This example uses the following XML document: [Sample XML File: Test Configuration in a Namespace](../linq/sample-xml-file--test-configuration-in-a-namespace1.md).  
  
```c#  
XElement root = XElement.Load("TestConfigInNamespace.xml");  
XNamespace ad = "http://www.adatum.com";  
IEnumerable<XElement> tests =  
    from el in root.Elements(ad + "Test")  
    where (string)el.Element(ad + "CommandLine") == "Examp2.EXE"  
    select el;  
foreach (XElement el in tests)  
    Console.WriteLine((string)el.Attribute("TestId"));  
```  
  
 This code produces the following output:  
  
```  
0002  
0006  
```  
  
## See Also  
 <xref:System.Xml.Linq.XElement.Attribute*>   
 <xref:System.Xml.Linq.XContainer.Elements*>   
 [Basic Queries (LINQ to XML) (C#)](../linq/basic-queries--linq-to-xml---csharp-.md)   
 [Standard Query Operators Overview (C#)](../linq/standard-query-operators-overview--csharp-.md)   
 [Projection Operations (C#)](../linq/projection-operations--csharp-.md)