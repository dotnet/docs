---
title: "How to: Write Queries on XML in Namespaces (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 7d4131b5-3288-414f-b77c-b2edc2a1f465
caps.latest.revision: 3
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Write Queries on XML in Namespaces (Visual Basic)
To write a query on XML that is in a namespace, you must use <xref:System.Xml.Linq.XName> objects that have the correct namespace.  
  
 In Visual Basic, the most common approach is to define a global namespace, and then use XML literals and XML properties that use the global namespace. You can define a global default namespace, in which case elements in the XML literals will be in the namespace by default. Alternatively, you can define a global namespace with a prefix, and then use the prefix as required in the XML literals, and in XML properties. As with other forms of XML, attributes are always in no namespace by default.  
  
 The first set of examples in this topic shows how to create an XML tree in a default namespace. The second set shows how to create an XML tree in a namespace with a prefix.  
  
## Example  
 The following example creates an XML tree that is in a default namespace. It then retrieves a collection of elements.  
  
```vb  
Imports <xmlns="http://www.adventure-works.com">  
  
Module Module1  
    Sub Main()  
        Dim root As XElement = _  
            <Root>  
                <Child>1</Child>  
                <Child>2</Child>  
                <Child>3</Child>  
                <AnotherChild>4</AnotherChild>  
                <AnotherChild>5</AnotherChild>  
                <AnotherChild>6</AnotherChild>  
            </Root>  
        Dim c1 As IEnumerable(Of XElement) = _  
            From el In root.<Child> _  
            Select el  
        For Each el As XElement In c1  
            Console.WriteLine(el.Value)  
        Next  
    End Sub  
End Module  
```  
  
 This example produces the following output:  
  
```  
1  
2  
3  
```  
  
## Example  
 In Visual Basic, however, writing queries on an XML tree that uses a namespace with a prefix is quite different from querying an XML tree in a default namespace. Typically you use the `Imports` statement to import the namespace with a prefix. You then use the prefix in the element and attribute names when you construct the XML tree. You also use the prefix when querying an XML tree using XML properties.  
  
 The following example creates an XML tree that is in a namespace with a prefix. It then retrieves a collection of elements.  
  
```vb  
Imports <xmlns:aw="http://www.adventure-works.com">  
  
Module Module1  
    Sub Main()  
        Dim root As XElement = _  
            <aw:Root>  
                <aw:Child>1</aw:Child>  
                <aw:Child>2</aw:Child>  
                <aw:Child>3</aw:Child>  
                <aw:AnotherChild>4</aw:AnotherChild>  
                <aw:AnotherChild>5</aw:AnotherChild>  
                <aw:AnotherChild>6</aw:AnotherChild>  
            </aw:Root>  
        Dim c1 As IEnumerable(Of XElement) = _  
            From el In root.<aw:Child> _  
            Select el  
        For Each el As XElement In c1  
            Console.WriteLine(CInt(el))  
        Next  
    End Sub  
End Module  
```  
  
 This example produces the following output:  
  
```  
1  
2  
3  
```  
  
## See Also  
 [Working with XML Namespaces (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/working-with-xml-namespaces.md)
