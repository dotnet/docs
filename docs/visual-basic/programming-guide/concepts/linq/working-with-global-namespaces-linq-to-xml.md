---
title: "Working with Global Namespaces (Visual Basic) (LINQ to XML)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 0a8064d5-e02f-4315-ad48-6deaa443a2f0
caps.latest.revision: 3
author: dotnet-bot
ms.author: dotnetcontent
---
# Working with Global Namespaces (Visual Basic) (LINQ to XML)
One of the key features of XML literals in Visual Basic is the capability to declare XML namespaces by using the `Imports` statement. Using this feature, you can declare an XML namespace that uses a prefix, or you can declare a default XML namespace.  
  
 This capability is useful in two situations. First, namespaces declared in XML literals do not carry over into embedded expressions. Declaring global namespaces reduces the amount of work that you have to do to use embedded expressions with namespaces. Second, you must declare global namespaces in order to use namespaces with XML properties.  
  
 You can declare global namespaces at the project level. You can also declare global namespaces at the module level, which overrides the project-level global namespaces. Finally, you can override global namespaces in an XML literal.  
  
 When using XML literals or XML properties that are in globally-declared namespaces, you can see the expanded name of XML literals or properties by hovering over them in Visual Studio. You will see the expanded name in a tooltip.  
  
 You can get an <xref:System.Xml.Linq.XNamespace> object that corresponds to a global namespace using the `GetXmlNamespace` method.  
  
## Examples of Global Namespaces  
 The following example declares a default global namespace by using the `Imports` statement, and then uses an XML literal to initialize an <xref:System.Xml.Linq.XElement> object in that namespace:  
  
```vb  
Imports <xmlns="http://www.adventure-works.com">  
  
Module Module1  
    Sub Main()  
        Dim root As XElement = <Root/>  
        Console.WriteLine(root)  
    End Sub  
End Module  
```  
  
 This example produces the following output:  
  
```xml  
<Root xmlns="http://www.adventure-works.com" />  
```  
  
 The following example declares a global namespace with a prefix, and then uses an XML literal to initialize an element:  
  
```vb  
Imports <xmlns:aw="http://www.adventure-works.com">  
  
Module Module1  
    Sub Main()  
        Dim root As XElement = <aw:Root/>  
        Console.WriteLine(root)  
    End Sub  
End Module  
```  
  
 This example produces the following output:  
  
```xml  
<aw:Root xmlns:aw="http://www.adventure-works.com" />  
```  
  
## Global Namespaces and Embedded Expressions  
 Namespaces that are declared in XML literals do not carry over into embedded expressions. The following example declares a default namespace. It then uses an embedded expression for the `Child` element.  
  
```vb  
Dim root As XElement = _  
    <Root xmlns="http://www.adventure-works.com">  
        <%= <Child/> %>  
    </Root>  
Console.WriteLine(root)  
```  
  
 This example produces the following output:  
  
```xml  
<Root xmlns="http://www.adventure-works.com">  
  <Child xmlns="" />  
</Root>  
```  
  
 As you can see, the resulting XML includes a declaration of a default namespace so that the `Child` element is in no namespace.  
  
 You could re-declare the namespace in the embedded expression, as follows:  
  
```vb  
Dim root As XElement = _  
    <Root xmlns="http://www.adventure-works.com">  
        <%= <Child xmlns="http://www.adventure-works.com"/> %>  
    </Root>  
Console.WriteLine(root)  
```  
  
 This example produces the following output:  
  
```xml  
<Root xmlns="http://www.adventure-works.com">  
  <Child xmlns="http://www.adventure-works.com" />  
</Root>  
```  
  
 However, this is more cumbersome to use than the global default namespace, which is a better approach. With the global default namespace, you can use XML literals without declaring namespaces. The resulting XML will be in the globally-declared default namespace.  
  
```vb  
Imports <xmlns="http://www.adventure-works.com">  
  
Module Module1  
    Sub Main()  
        Dim root As XElement = <Root>  
                                   <%= <Child/> %>  
                               </Root>  
        Console.WriteLine(root)  
    End Sub  
End Module  
```  
  
 This example produces the following output:  
  
```xml  
<Root xmlns="http://www.adventure-works.com">  
  <Child />  
</Root>  
```  
  
## Using Namespaces with XML Properties  
 If you are working with an XML tree that is in a namespace, and you use XML properties, then you must use a global namespace so that the XML properties will also be in the correct namespace. The following example declares an XML tree in a namespace. It then prints the count of `Child` elements.  
  
```vb  
Dim root As XElement = _  
    <Root xmlns="http://www.adventure-works.com">  
        <Child>content</Child>  
    </Root>  
Console.WriteLine(root.<Child>.Count())  
```  
  
 This example indicates that there are no `Child` elements. It produces the following output:  
  
```  
0  
```  
  
 If, however, you declare a default global namespace, then both the XML literal and the XML property are in the default global namespace:  
  
```vb  
Imports <xmlns="http://www.adventure-works.com">  
  
Module Module1  
    Sub Main()  
        Dim root As XElement = _  
            <Root>  
                <Child>content</Child>  
            </Root>  
        Console.WriteLine(root.<Child>.Count())  
    End Sub  
End Module  
```  
  
 This example indicates that there is one `Child` element. It produces the following output:  
  
```  
1  
```  
  
 If you declare a global namespace that has a prefix, you can use the prefix for both XML literals and XML properties:  
  
```vb  
Imports <xmlns:aw="http://www.adventure-works.com">  
  
Module Module1  
    Sub Main()  
        Dim root As XElement = _  
            <aw:Root>  
                <aw:Child>content</aw:Child>  
            </aw:Root>  
        Console.WriteLine(root.<aw:Child>.Count())  
    End Sub  
End Module  
```  
  
## XNamespace and Global Namespaces  
 You can get an <xref:System.Xml.Linq.XNamespace> object by using the `GetXmlNamespace` method:  
  
```vb  
Imports <xmlns:aw="http://www.adventure-works.com">  
  
Module Module1  
    Sub Main()  
        Dim root As XElement = <aw:Root/>  
        Dim xn As XNamespace = GetXmlNamespace(aw)  
        Console.WriteLine(xn)  
    End Sub  
End Module  
```  
  
 This example produces the following output:  
  
```  
http://www.adventure-works.com  
```  
  
## See Also  
 [Working with XML Namespaces (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/working-with-xml-namespaces.md)
