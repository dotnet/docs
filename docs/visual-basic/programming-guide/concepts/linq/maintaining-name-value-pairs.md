---
title: "Maintaining Name-Value Pairs (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 57ac2072-d9f5-432b-84f0-a889c62fd813
caps.latest.revision: 3
author: dotnet-bot
ms.author: dotnetcontent

---
# Maintaining Name/Value Pairs (Visual Basic)
Many applications have to maintain information that is best kept as name/value pairs. This information might be configuration information or global settings. [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] contains some methods that make it easy to keep a set of name/value pairs. You can either keep the information as attributes or as a set of child elements.  
  
 One difference between keeping the information as attributes or as child elements is that attributes have the constraint that there can be only one attribute with a particular name for an element. This limitation does not apply to child elements.  
  
## SetAttributeValue and SetElementValue  
 The two methods that facilitate keeping name/value pairs are <xref:System.Xml.Linq.XElement.SetAttributeValue%2A> and <xref:System.Xml.Linq.XElement.SetElementValue%2A>. These two methods have similar semantics.  
  
 <xref:System.Xml.Linq.XElement.SetAttributeValue%2A> can add, modify, or remove attributes of an element.  
  
-   If you call <xref:System.Xml.Linq.XElement.SetAttributeValue%2A> with a name of an attribute that does not exist, the method creates a new attribute and adds it to the specified element.  
  
-   If you call <xref:System.Xml.Linq.XElement.SetAttributeValue%2A> with a name of an existing attribute and with some specified content, the contents of the attribute are replaced with the specified content.  
  
-   If you call <xref:System.Xml.Linq.XElement.SetAttributeValue%2A> with a name of an existing attribute, and specify null for the content, the attribute is removed from its parent.  
  
 <xref:System.Xml.Linq.XElement.SetElementValue%2A> can add, modify, or remove child elements of an element.  
  
-   If you call <xref:System.Xml.Linq.XElement.SetElementValue%2A> with a name of a child element that does not exist, the method creates a new element and adds it to the specified element.  
  
-   If you call <xref:System.Xml.Linq.XElement.SetElementValue%2A> with a name of an existing element and with some specified content, the contents of the element are replaced with the specified content.  
  
-   If you call <xref:System.Xml.Linq.XElement.SetElementValue%2A> with a name of an existing element, and specify null for the content, the element is removed from its parent.  
  
## Example  
 The following example creates an element with no attributes. It then uses the <xref:System.Xml.Linq.XElement.SetAttributeValue%2A> method to create and maintain a list of name/value pairs.  
  
```vb  
' Create an element with no content.  
Dim root As XElement = <Root/>  
  
' Add a number of name/value pairs as attributes.  
root.SetAttributeValue("Top", 22)  
root.SetAttributeValue("Left", 20)  
root.SetAttributeValue("Bottom", 122)  
root.SetAttributeValue("Right", 300)  
root.SetAttributeValue("DefaultColor", "Color.Red")  
Console.WriteLine(root)  
  
' Replace the value of Top.  
root.SetAttributeValue("Top", 10)  
Console.WriteLine(root)  
  
' Remove DefaultColor.  
root.SetAttributeValue("DefaultColor", Nothing)  
Console.WriteLine(root)  
```  
  
 This example produces the following output:  
  
```xml  
<Root Top="22" Left="20" Bottom="122" Right="300" DefaultColor="Color.Red" />  
<Root Top="10" Left="20" Bottom="122" Right="300" DefaultColor="Color.Red" />  
<Root Top="10" Left="20" Bottom="122" Right="300" />  
```  
  
## Example  
 The following example creates an element with no child elements. It then uses the <xref:System.Xml.Linq.XElement.SetElementValue%2A> method to create and maintain a list of name/value pairs.  
  
```vb  
' Create an element with no content.  
Dim root As XElement = <Root/>  
  
' Add a number of name/value pairs as elements.  
root.SetElementValue("Top", 22)  
root.SetElementValue("Left", 20)  
root.SetElementValue("Bottom", 122)  
root.SetElementValue("Right", 300)  
root.SetElementValue("DefaultColor", "Color.Red")  
Console.WriteLine(root)  
Console.WriteLine("----")  
  
' Replace the value of Top.  
root.SetElementValue("Top", 10)  
Console.WriteLine(root)  
Console.WriteLine("----")  
  
' Remove DefaultColor.  
root.SetElementValue("DefaultColor", Nothing)  
Console.WriteLine(root)  
```  
  
 This example produces the following output:  
  
```xml  
<Root>  
  <Top>22</Top>  
  <Left>20</Left>  
  <Bottom>122</Bottom>  
  <Right>300</Right>  
  <DefaultColor>Color.Red</DefaultColor>  
</Root>  
----  
<Root>  
  <Top>10</Top>  
  <Left>20</Left>  
  <Bottom>122</Bottom>  
  <Right>300</Right>  
  <DefaultColor>Color.Red</DefaultColor>  
</Root>  
----  
<Root>  
  <Top>10</Top>  
  <Left>20</Left>  
  <Bottom>122</Bottom>  
  <Right>300</Right>  
</Root>  
```  
  
## See Also  
 <xref:System.Xml.Linq.XElement.SetAttributeValue%2A>  
 <xref:System.Xml.Linq.XElement.SetElementValue%2A>  
 [Modifying XML Trees (LINQ to XML) (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/modifying-xml-trees-linq-to-xml.md)
