---
title: "Introduction to XML Literals in Visual Basic2"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 94fc0e03-978e-4c08-ab6c-0dc3c1e64f10
caps.latest.revision: 3
author: dotnet-bot
ms.author: dotnetcontent
---
# Introduction to XML Literals in Visual Basic
This section provides information about creating XML trees in [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)].  
  
 For information about using the results of LINQ queries as the content for an XML tree, see [Functional Construction (LINQ to XML) (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/functional-construction-linq-to-xml.md).  
  
 For more information on XML literals in [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)], see [Overview of LINQ to XML in Visual Basic](../../../../visual-basic/programming-guide/language-features/xml/overview-of-linq-to-xml.md).  
  
## Creating XML Trees  
 The following example shows how to create an <xref:System.Xml.Linq.XElement>, in this case `contacts`:  
  
```vb  
Dim contacts As XElement = _  
    <Contacts>  
        <Contact>  
            <Name>Patrick Hines</Name>  
            <Phone>206-555-0144</Phone>  
            <Address>  
                <Street1>123 Main St</Street1>  
                <City>Mercer Island</City>  
                <State>WA</State>  
                <Postal>68042</Postal>  
            </Address>  
        </Contact>  
    </Contacts>  
```  
  
### Creating an XElement with Simple Content  
 You can create an <xref:System.Xml.Linq.XElement> that contains simple content, as follows:  
  
```vb  
Dim n as XElement = <Customer>Adventure Works</Customer>  
Console.WriteLine(n)   
```  
  
 This example produces the following output:  
  
```xml  
<Customer>Adventure Works</Customer>  
```  
  
### Creating an Empty Element  
 You can create an empty <xref:System.Xml.Linq.XElement>, as follows:  
  
```vb  
Dim n As XElement = <Customer/>  
Console.WriteLine(n)  
```  
  
 This example produces the following output:  
  
```xml  
<Customer />  
```  
  
### Using Embedded Expressions  
 An important feature of XML literals is that they allow embedded expressions. Embedded expressions enable you to evaluate an expression and insert the results of the expression into the XML tree. If the expression evaluates to a type of <xref:System.Xml.Linq.XElement>, an element is inserted into the tree. If the expression evaluates to a type of <xref:System.Xml.Linq.XAttribute>, an attribute is inserted into the tree. You can insert elements and attributes into the tree only where they are valid.  
  
 It is important to note that only a single expression can go into an embedded expression. You cannot embed multiple statements. If an expression extends beyond a single line, you must use the line continuation character.  
  
 If you use an embedded expression to add existing nodes (including elements) and attributes to a new XML tree and if the existing nodes are already parented, the nodes are cloned. The newly cloned nodes are attached to the new XML tree. If the existing nodes are not parented, the nodes are simply attached to the new XML tree. The last example in this topic demonstrates this.  
  
 The following example uses an embedded expression to insert an element into the tree:  
  
```vb  
xmlTree1 As XElement = _  
    <Root>  
        <Child>Contents</Child>  
    </Root>  
Dim xmlTree2 As XElement = _  
    <Root>  
        <%= xmlTree1.<Child> %>  
    </Root>  
Console.WriteLine(xmlTree2)  
```  
  
 This example produces the following output:  
  
```xml  
<Root>  
  <Child>Contents</Child>  
</Root>  
```  
  
### Using Embedded Expressions for Content  
 You can use an embedded expression to supply the content of an element:  
  
```vb  
Dim str As String  
str = "Some content"  
Dim root As XElement = <Root><%= str %></Root>  
Console.WriteLine(root)  
```  
  
 This example produces the following output:  
  
```xml  
<Root>Some content</Root>  
```  
  
### Using a LINQ Query in an Embedded Expression  
 You can use the results of a LINQ query for the content of an element:  
  
```vb  
Dim arr As Integer() = {1, 2, 3}  
  
Dim n As XElement = _  
    <Root>  
        <%= From i In arr Select <Child><%= i %></Child> %>  
    </Root>  
  
Console.WriteLine(n)  
```  
  
 This example produces the following output:  
  
```xml  
<Root>  
  <Child>1</Child>  
  <Child>2</Child>  
  <Child>3</Child>  
</Root>  
```  
  
### Using Embedded Expressions for Node Names  
 You can also use embedded expressions to calculate attribute names, attribute values, element names, and element values:  
  
```vb  
Dim eleName As String = "ele"  
Dim attName As String = "att"  
Dim attValue As String = "aValue"  
Dim eleValue As String = "eValue"  
Dim n As XElement = _  
    <Root <%= attName %>=<%= attValue %>>  
        <<%= eleName %>>  
            <%= eleValue %>  
        </>  
    </Root>  
Console.WriteLine(n)  
```  
  
 This example produces the following output:  
  
```xml  
<Root att="aValue">  
  <ele>eValue</ele>  
</Root>  
```  
  
### Cloning vs. Attaching  
 As mentioned earlier, if you use an embedded expression to add existing nodes (including elements) and attributes to a new XML tree, if the existing nodes are already parented, the nodes are cloned and the newly cloned nodes are attached to the new XML tree. If the existing nodes are not parented, they are simply attached to the new XML tree.  
  
```vb  
' Create a tree with a child element.  
Dim xmlTree1 As XElement = _  
    <Root>  
        <Child1>1</Child1>  
    </Root>  
  
' Create an element that is not parented.  
Dim child2 As XElement = <Child2>2</Child2>  
  
' Create a tree and add Child1 and Child2 to it.  
Dim xmlTree2 As XElement = _  
    <Root>  
        <%= xmlTree1.<Child1>(0) %>  
        <%= child2 %>  
    </Root>  
  
' Compare Child1 identity.  
Console.WriteLine("Child1 was {0}", _  
    IIf(xmlTree1.Element("Child1") Is xmlTree2.Element("Child1"), _  
    "attached", "cloned"))  
  
' Compare Child2 identity.  
Console.WriteLine("Child2 was {0}", _  
    IIf(child2 Is xmlTree2.Element("Child2"), _  
    "attached", "cloned"))  
```  
  
 This example produces the following output:  
  
```  
Child1 was cloned  
Child2 was attached  
```  
  
## See Also  
 [Creating XML Trees (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/creating-xml-trees.md)
