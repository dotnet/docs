---
title: "Cloning vs. Attaching (C#)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
ms.assetid: 357c5efa-7b73-4f14-aa67-6bebdba4e7ea
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"
---
# Cloning vs. Attaching (C#)
When adding <xref:System.Xml.Linq.XNode> (including <xref:System.Xml.Linq.XElement>) or <xref:System.Xml.Linq.XAttribute> objects to a new tree, if the new content has no parent, the objects are simply attached to the XML tree. If the new content already is parented, and is part of another XML tree, the new content is cloned. The newly cloned content is then attached to the XML tree.  
  
## Example  
 The following code demonstrates the behavior when you add a parented element to a tree, and when you add an element with no parent to a tree.  
  
```csharp  
// Create a tree with a child element.  
XElement xmlTree1 = new XElement("Root",  
    new XElement("Child1", 1)  
);  
  
// Create an element that is not parented.  
XElement child2 = new XElement("Child2", 2);  
  
// Create a tree and add Child1 and Child2 to it.  
XElement xmlTree2 = new XElement("Root",  
    xmlTree1.Element("Child1"),  
    child2  
);  
  
// Compare Child1 identity.  
Console.WriteLine("Child1 was {0}",  
    xmlTree1.Element("Child1") == xmlTree2.Element("Child1") ?  
    "attached" : "cloned");  
  
// Compare Child2 identity.  
Console.WriteLine("Child2 was {0}",  
    child2 == xmlTree2.Element("Child2") ?  
    "attached" : "cloned");  
```  
  
 This example produces the following output:  
  
```  
Child1 was cloned  
Child2 was attached  
```  
  
## See Also  
 [Creating XML Trees (C#)](../../../../csharp/programming-guide/concepts/linq/creating-xml-trees.md)
