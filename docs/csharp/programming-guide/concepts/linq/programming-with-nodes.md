---
title: "Programming with Nodes (C#)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
ms.assetid: c38df0f2-c805-431a-93ff-9103a4284c2f
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"
---
# Programming with Nodes (C#)
[!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] developers who need to write programs such as an XML editor, a transform system, or a report writer often need to write programs that work at a finer level of granularity than elements and attributes. They often need to work at the node level, manipulating text nodes, processing instructions, and comments. This topic provides some details about programming at the node level.  
  
## Node Details  
 There are a number of details of programming that a programmer working at the node level should know.  
  
### Parent Property of Children Nodes of XDocument is Set to Null  
 The <xref:System.Xml.Linq.XObject.Parent%2A> property contains the parent <xref:System.Xml.Linq.XElement>, not the parent node. Child nodes of <xref:System.Xml.Linq.XDocument> have no parent <xref:System.Xml.Linq.XElement>. Their parent is the document, so the <xref:System.Xml.Linq.XObject.Parent%2A> property for those nodes is set to null.  
  
 The following example demonstrates this:  
  
```csharp  
XDocument doc = XDocument.Parse(@"<!-- a comment --><Root/>");  
Console.WriteLine(doc.Nodes().OfType<XComment>().First().Parent == null);  
Console.WriteLine(doc.Root.Parent == null);  
```  
  
 This example produces the following output:  
  
```  
True  
True  
```  
  
### Adjacent Text Nodes are Possible  
 In a number of XML programming models, adjacent text nodes are always merged. This is sometimes called normalization of text nodes. [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] does not normalize text nodes. If you add two text nodes to the same element, it will result in adjacent text nodes. However, if you add content specified as a string rather than as an <xref:System.Xml.Linq.XText> node, [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] might merge the string with an adjacent text node.  
  
 The following example demonstrates this:  
  
```csharp  
XElement xmlTree = new XElement("Root", "Content");  
  
Console.WriteLine(xmlTree.Nodes().OfType<XText>().Count());  
  
// this does not add a new text node  
xmlTree.Add("new content");  
Console.WriteLine(xmlTree.Nodes().OfType<XText>().Count());  
  
// this does add a new, adjacent text node  
xmlTree.Add(new XText("more text"));  
Console.WriteLine(xmlTree.Nodes().OfType<XText>().Count());  
```  
  
 This example produces the following output:  
  
```  
1  
1  
2  
```  
  
### Empty Text Nodes are Possible  
 In some XML programming models, text nodes are guaranteed to not contain the empty string. The reasoning is that such a text node has no impact on serialization of the XML. However, for the same reason that adjacent text nodes are possible, if you remove the text from a text node by setting its value to the empty string, the text node itself will not be deleted.  
  
```csharp  
XElement xmlTree = new XElement("Root", "Content");  
XText textNode = xmlTree.Nodes().OfType<XText>().First();  
  
// the following line does not cause the removal of the text node.  
textNode.Value = "";  
  
XText textNode2 = xmlTree.Nodes().OfType<XText>().First();  
Console.WriteLine(">>{0}<<", textNode2);   
```  
  
 This example produces the following output:  
  
```  
>><<  
```  
  
### An Empty Text Node Impacts Serialization  
 If an element contains only a child text node that is empty, it is serialized with the long tag syntax: `<Child></Child>`. If an element contains no child nodes whatsoever, it is serialized with the short tag syntax: `<Child />`.  
  
```csharp  
XElement child1 = new XElement("Child1",  
    new XText("")  
);  
XElement child2 = new XElement("Child2");  
Console.WriteLine(child1);  
Console.WriteLine(child2);   
```  
  
 This example produces the following output:  
  
```xml  
<Child1></Child1>  
<Child2 />  
```  
  
### Namespaces are Attributes in the LINQ to XML Tree  
 Even though namespace declarations have identical syntax to attributes, in some programming interfaces, such as XSLT and XPath, namespace declarations are not considered to be attributes. However, in [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)], namespaces are stored as <xref:System.Xml.Linq.XAttribute> objects in the XML tree. If you iterate through the attributes for an element that contains a namespace declaration, you will see the namespace declaration as one of the items in the returned collection.  
  
 The <xref:System.Xml.Linq.XAttribute.IsNamespaceDeclaration%2A> property indicates whether an attribute is a namespace declaration.  
  
```csharp  
XElement root = XElement.Parse(  
@"<Root  
    xmlns='http://www.adventure-works.com'  
    xmlns:fc='www.fourthcoffee.com'  
    AnAttribute='abc'/>");  
foreach (XAttribute att in root.Attributes())  
    Console.WriteLine("{0}  IsNamespaceDeclaration:{1}", att, att.IsNamespaceDeclaration);  
```  
  
 This example produces the following output:  
  
```  
xmlns="http://www.adventure-works.com"  IsNamespaceDeclaration:True  
xmlns:fc="www.fourthcoffee.com"  IsNamespaceDeclaration:True  
AnAttribute="abc"  IsNamespaceDeclaration:False  
```  
  
### XPath Axis Methods Do Not Return Child White Space of XDocument  
 [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] allows for child text nodes of an <xref:System.Xml.Linq.XDocument>, as long as the text nodes contain only white space. However, the XPath object model does not include white space as child nodes of a document, so when you iterate through the children of an <xref:System.Xml.Linq.XDocument> using the <xref:System.Xml.Linq.XContainer.Nodes%2A> axis, white-space text nodes will be returned. However, when you iterate through the children of an <xref:System.Xml.Linq.XDocument> using the XPath axis methods, white-space text nodes will not be returned.  
  
```csharp  
// Create a document with some white-space child nodes of the document.  
XDocument root = XDocument.Parse(  
@"<?xml version='1.0' encoding='utf-8' standalone='yes'?>  
  
<Root/>  
  
<!--a comment-->  
", LoadOptions.PreserveWhitespace);  
  
// count the white-space child nodes using LINQ to XML  
Console.WriteLine(root.Nodes().OfType<XText>().Count());  
  
// count the white-space child nodes using XPathEvaluate  
Console.WriteLine(((IEnumerable)root.XPathEvaluate("text()")).OfType<XText>().Count());   
```  
  
 This example produces the following output:  
  
```  
3  
0  
```  
  
### XDeclaration Objects are not Nodes  
 When you iterate through the children nodes of an <xref:System.Xml.Linq.XDocument>, you will not see the XML declaration object. It is a property of the document, not a child node of it.  
  
```csharp  
XDocument doc = new XDocument(  
    new XDeclaration("1.0", "utf-8", "yes"),  
    new XElement("Root")  
);  
doc.Save("Temp.xml");  
Console.WriteLine(File.ReadAllText("Temp.xml"));  
  
// this shows that there is only one child node of the document  
Console.WriteLine(doc.Nodes().Count());  
```  
  
 This example produces the following output:  
  
```  
<?xml version="1.0" encoding="utf-8" standalone="yes"?>  
<Root />  
1  
```  
  
## See Also  
 [Advanced LINQ to XML Programming (C#)](../../../../csharp/programming-guide/concepts/linq/advanced-linq-to-xml-programming.md)
