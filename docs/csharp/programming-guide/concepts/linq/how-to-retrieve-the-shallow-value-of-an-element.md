---
title: "How to: Retrieve the Shallow Value of an Element (C#)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"

ms.topic: "article"
ms.assetid: 924a2699-72f6-4be1-aaa6-de62f8ec73b9
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"

---
# How to: Retrieve the Shallow Value of an Element (C#)
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
  
```csharp  
public static class MyExtensions  
{  
    public static string ShallowValue(this XElement xe)  
    {  
        return xe  
               .Nodes()  
               .OfType<XText>()  
               .Aggregate(new StringBuilder(),  
                          (s, c) => s.Append(c),  
                          s => s.ToString());  
    }  
}  
  
class Program  
{  
    static void Main(string[] args)  
    {  
        XElement root = XElement.Load("Report.xml");  
  
        IEnumerable<XElement> query = from el in root.Descendants()  
                                      where el.ShallowValue().StartsWith("=")  
                                      select el;  
  
        foreach (var q in query)  
        {  
            Console.WriteLine("{0}{1}{2}",  
                q.Name.ToString().PadRight(8),  
                q.Attribute("Name").ToString().PadRight(20),  
                q.ShallowValue());  
        }  
    }  
}  
```  
  
 This example produces the following output:  
  
```  
Column  Name="CustomerId"   =Customer.CustomerId.Heading  
Column  Name="Name"         =Customer.Name.Heading  
Column  Name="CustomerId"   =Customer.CustomerId  
Column  Name="Name"         =Customer.Name  
```  
  
## See Also  
 [LINQ to XML Axes (C#)](../../../../csharp/programming-guide/concepts/linq/linq-to-xml-axes.md)
