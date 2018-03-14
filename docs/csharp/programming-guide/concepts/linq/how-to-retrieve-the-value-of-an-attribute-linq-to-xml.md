---
title: "How to: Retrieve the Value of an Attribute (LINQ to XML) (C#)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"

ms.topic: "article"
ms.assetid: 817bbe89-5979-4234-bf0c-46f63692ac8c
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"

---
# How to: Retrieve the Value of an Attribute (LINQ to XML) (C#)
This topic shows how to obtain the value of attributes. There are two main ways: You can cast an <xref:System.Xml.Linq.XAttribute> to the desired type; the explicit conversion operator then converts the contents of the element or attribute to the specified type. Alternatively, you can use the <xref:System.Xml.Linq.XAttribute.Value%2A> property. However, casting is generally the better approach. If you cast the attribute to a nullable type, the code is simpler to write when retrieving the value of an attribute that might or might not exist. For examples of this technique, see [How to: Retrieve the Value of an Element (LINQ to XML) (C#)](../../../../csharp/programming-guide/concepts/linq/how-to-retrieve-the-value-of-an-element-linq-to-xml.md).  
  
## Example  
 To retrieve the value of an attribute, you just cast the <xref:System.Xml.Linq.XAttribute> object to your desired type.  
  
```csharp  
XElement root = new XElement("Root",  
                    new XAttribute("Attr", "abcde")  
                );  
Console.WriteLine(root);  
string str = (string)root.Attribute("Attr");  
Console.WriteLine(str);  
```  
  
 This example produces the following output:  
  
```  
<Root Attr="abcde" />  
abcde  
```  
  
## Example  
 The following example shows how to retrieve the value of an attribute where the attribute is in a namespace. For more information, see [Working with XML Namespaces (C#)](../../../../csharp/programming-guide/concepts/linq/working-with-xml-namespaces.md).  
  
```csharp  
XNamespace aw = "http://www.adventure-works.com";  
XElement root = new XElement(aw + "Root",  
                    new XAttribute(aw + "Attr", "abcde")  
                );  
string str = (string)root.Attribute(aw + "Attr");  
Console.WriteLine(str);  
```  
  
 This example produces the following output:  
  
```  
abcde  
```  
  
## See Also  
 [LINQ to XML Axes (C#)](../../../../csharp/programming-guide/concepts/linq/linq-to-xml-axes.md)
