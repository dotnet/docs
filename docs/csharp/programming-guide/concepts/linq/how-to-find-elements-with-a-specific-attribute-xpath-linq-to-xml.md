---
title: "How to: Find Elements with a Specific Attribute (XPath-LINQ to XML) (C#)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"

ms.topic: "article"
ms.assetid: daed00dd-923a-43be-8a90-eee406f6f574
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"

---
# How to: Find Elements with a Specific Attribute (XPath-LINQ to XML) (C#)
Sometimes you want to find all elements that have a specific attribute. You are not concerned about the contents of the attribute. Instead, you want to select based on the existence of the attribute.  
  
 The XPath expression is:  
  
 `./*[@Select]`  
  
## Example  
 The following code selects just the elements that have the `Select` attribute.  
  
```csharp  
XElement doc = XElement.Parse(  
@"<Root>  
    <Child1>1</Child1>  
    <Child2 Select='true'>2</Child2>  
    <Child3>3</Child3>  
    <Child4 Select='true'>4</Child4>  
    <Child5>5</Child5>  
</Root>");  
  
// LINQ to XML query  
IEnumerable<XElement> list1 =  
    from el in doc.Elements()  
    where el.Attribute("Select") != null  
    select el;  
  
// XPath expression  
IEnumerable<XElement> list2 =  
    ((IEnumerable)doc.XPathEvaluate("./*[@Select]")).Cast<XElement>();  
  
if (list1.Count() == list2.Count() &&  
        list1.Intersect(list2).Count() == list1.Count())  
    Console.WriteLine("Results are identical");  
else  
    Console.WriteLine("Results differ");  
foreach (XElement el in list1)  
    Console.WriteLine(el);  
```  
  
 This example produces the following output:  
  
```  
Results are identical  
<Child2 Select="true">2</Child2>  
<Child4 Select="true">4</Child4>  
```  
  
## See Also  
 [LINQ to XML for XPath Users (C#)](../../../../csharp/programming-guide/concepts/linq/linq-to-xml-for-xpath-users.md)
