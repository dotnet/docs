---
title: "How to: Retrieve the Shallow Value of an Element (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 730a6670-fb8c-41fc-8a1b-eb97a837e432
caps.latest.revision: 4
author: dotnet-bot
ms.author: dotnetcontent

---
# How to: Retrieve the Shallow Value of an Element (Visual Basic)
This topic shows how to get the shallow value of an element. The shallow value is the value of the specific element only, as opposed to the deep value, which includes the values of all descendent elements concatenated into a single string.  
  
 When you retrieve an element value by using either casting or the <xref:System.Xml.Linq.XElement.Value%2A?displayProperty=nameWithType> property, you retrieve the deep value. To retrieve the shallow value, you can use the `ShallowValue` extension method, as shown in the follwing example. Retrieving the shallow value is useful when you want to select elements based on their content.  
  
 The following example declares an extension method that retrieves the shallow value of an element. It then uses the extension method in a query to list all elements that contain a calculated value.  
  
## Example  
 The following text file, Report.xml, is the source for this example.  
  
```xml  
<?xml version="1.0" encoding="utf-8" ?>  
<Report>  
  <Section>  
    <Heading>  
      <Column Name="CustomerId">=Customer.CustomerId.Heading</Column>  
      <Column Name="Name">=Customer.Name.Heading</Column>  
    </Heading>  
    <Detail>  
      <Column Name="CustomerId">=Customer.CustomerId</Column>  
      <Column Name="Name">=Customer.Name</Column>  
    </Detail>  
  </Section>  
</Report>  
```  
  
```vb  
Module Module1  
    <System.Runtime.CompilerServices.Extension()> _  
    Public Function ShallowValue(ByVal xe As XElement)  
        Return xe _  
               .Nodes() _  
               .OfType(Of XText)() _  
               .Aggregate(New StringBuilder(), _  
                              Function(s, c) s.Append(c), _  
                              Function(s) s.ToString())  
    End Function  
  
    Sub Main()  
        Dim root As XElement = XElement.Load("Report.xml")  
  
        Dim query As IEnumerable(Of XElement) = _  
            From el In root.Descendants() _  
            Where (el.ShallowValue().StartsWith("=")) _  
            Select el  
  
        For Each q As XElement In query  
            Console.WriteLine("{0}{1}{2}", _  
                q.Name.ToString().PadRight(8), _  
                q.Attribute("Name").ToString().PadRight(20), _  
                q.ShallowValue())  
        Next  
    End Sub  
End Module  
```  
  
 This example produces the following output:  
  
```  
Column  Name="CustomerId"   =Customer.CustomerId.Heading  
Column  Name="Name"         =Customer.Name.Heading  
Column  Name="CustomerId"   =Customer.CustomerId  
Column  Name="Name"         =Customer.Name  
```  
  
## See Also  
 [LINQ to XML Axes (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/linq-to-xml-axes.md)
