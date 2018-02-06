---
title: "How to: Find Descendants of a Child Element (XPath-LINQ to XML) (C#)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"

ms.topic: "article"
ms.assetid: 505b7512-bb8b-4f85-abbf-491f039c961e
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"

---
# How to: Find Descendants of a Child Element (XPath-LINQ to XML) (C#)
This topic shows how to get the descendant elements of a child element with a particular name.  
  
 The XPath expression is:  
  
 `./Paragraph//Text/text()`  
  
## Example  
 This example simulates the problems of extracting text from an XML representation of a word processing document. It first selects all `Paragraph` elements, and then it selects all `Text` descendant elements of each `Paragraph` element. This doesn't select the descendant `Text` elements of the `Comment` element.  
  
```csharp  
XElement root = XElement.Parse(  
@"<Root>  
  <Paragraph>  
    <Text>This is the start of</Text>  
  </Paragraph>  
  <Comment>  
    <Text>This comment is not part of the paragraph text.</Text>  
  </Comment>  
  <Paragraph>  
    <Annotation Emphasis='true'>  
      <Text> a sentence.</Text>  
    </Annotation>  
  </Paragraph>  
  <Paragraph>  
    <Text>  This is a second sentence.</Text>  
  </Paragraph>  
</Root>");  
  
// LINQ to XML query  
string str1 =  
    root  
    .Elements("Paragraph")  
    .Descendants("Text")  
    .Select(s => s.Value)  
    .Aggregate(  
        new StringBuilder(),  
        (s, i) => s.Append(i),  
        s => s.ToString()  
    );  
  
// XPath expression  
string str2 =  
    ((IEnumerable)root.XPathEvaluate("./Paragraph//Text/text()"))  
    .Cast<XText>()  
    .Select(s => s.Value)  
    .Aggregate(  
        new StringBuilder(),  
        (s, i) => s.Append(i),  
        s => s.ToString()  
    );  
  
if (str1 == str2)  
    Console.WriteLine("Results are identical");  
else  
    Console.WriteLine("Results differ");  
Console.WriteLine(str2);  
```  
  
 This example produces the following output:  
  
```  
Results are identical  
This is the start of a sentence.  This is a second sentence.  
```  
  
## See Also  
 [LINQ to XML for XPath Users (C#)](../../../../csharp/programming-guide/concepts/linq/linq-to-xml-for-xpath-users.md)
