---
title: "Programming with Nodes (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: d8422a9b-dd37-44a3-8aac-2237ed9561e0
caps.latest.revision: 3
author: dotnet-bot
ms.author: dotnetcontent
---
# Programming with Nodes (Visual Basic)
[!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] developers who need to write programs such as an XML editor, a transform system, or a report writer often need to write programs that work at a finer level of granularity than elements and attributes. They often need to work at the node level, manipulating text nodes, processing instructions, and comments. This topic provides some details about programming at the node level.  
  
## Node Details  
 There are a number of details of programming that a programmer working at the node level should know.  
  
### Parent Property of Children Nodes of XDocument is Set to Null  
 The <xref:System.Xml.Linq.XObject.Parent%2A> property contains the parent <xref:System.Xml.Linq.XElement>, not the parent node. Child nodes of <xref:System.Xml.Linq.XDocument> have no parent <xref:System.Xml.Linq.XElement>. Their parent is the document, so the <xref:System.Xml.Linq.XObject.Parent%2A> property for those nodes is set to null.  
  
 The following example demonstrates this:  
  
```vb  
Dim doc As XDocument = XDocument.Parse("<!-- a comment --><Root/>")  
Console.WriteLine(doc.Nodes().OfType(Of XComment).First().Parent Is Nothing)  
Console.WriteLine(doc.Root.Parent Is Nothing)  
```  
  
 This example produces the following output:  
  
```  
True  
True  
```  
  
### Adjacent Text Nodes are Possible  
 In a number of XML programming models, adjacent text nodes are always merged. This is sometimes called normalization of text nodes. [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] does not normalize text nodes. If you add two text nodes to the same element, it will result in adjacent text nodes. However, if you add content specified as a string rather than as an <xref:System.Xml.Linq.XText> node, [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] might merge the string with an adjacent text node.  
  
 The following example demonstrates this:  
  
```vb  
Dim xmlTree As XElement = <Root>Content</Root>  
Console.WriteLine(xmlTree.Nodes().OfType(Of XText)().Count())  
  
' This does not add a new text node.  
xmlTree.Add("new content")  
Console.WriteLine(xmlTree.Nodes().OfType(Of XText)().Count())  
  
'// This does add a new, adjacent text node.  
xmlTree.Add(New XText("more text"))  
Console.WriteLine(xmlTree.Nodes().OfType(Of XText)().Count())  
```  
  
 This example produces the following output:  
  
```  
1  
1  
2  
```  
  
### Empty Text Nodes are Possible  
 In some XML programming models, text nodes are guaranteed to not contain the empty string. The reasoning is that such a text node has no impact on serialization of the XML. However, for the same reason that adjacent text nodes are possible, if you remove the text from a text node by setting its value to the empty string, the text node itself will not be deleted.  
  
```vb  
Dim xmlTree As XElement = <Root>Content</Root>  
Dim textNode As XText = xmlTree.Nodes().OfType(Of XText)().First()  
  
' The following line does not cause the removal of the text node.  
textNode.Value = ""  
  
Dim textNode2 As XText = xmlTree.Nodes().OfType(Of XText)().First()  
Console.WriteLine(">>{0}<<", textNode2)  
```  
  
 This example produces the following output:  
  
```  
>><<  
```  
  
### An Empty Text Node Impacts Serialization  
 If an element contains only a child text node that is empty, it is serialized with the long tag syntax: `<Child></Child>`. If an element contains no child nodes whatsoever, it is serialized with the short tag syntax: `<Child />`.  
  
```vb  
Dim child1 As XElement = New XElement("Child1", _  
    New XText("") _  
)  
Dim child2 As XElement = New XElement("Child2")  
Console.WriteLine(child1)  
Console.WriteLine(child2)  
```  
  
 This example produces the following output:  
  
```xml  
<Child1></Child1>  
<Child2 />  
```  
  
### Namespaces are Attributes in the LINQ to XML Tree  
 Even though namespace declarations have identical syntax to attributes, in some programming interfaces, such as XSLT and XPath, namespace declarations are not considered to be attributes. However, in [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)], namespaces are stored as <xref:System.Xml.Linq.XAttribute> objects in the XML tree. If you iterate through the attributes for an element that contains a namespace declaration, you will see the namespace declaration as one of the items in the returned collection.  
  
 The <xref:System.Xml.Linq.XAttribute.IsNamespaceDeclaration%2A> property indicates whether an attribute is a namespace declaration.  
  
```vb  
Dim root As XElement = _   
<Root  
    xmlns='http://www.adventure-works.com'  
    xmlns:fc='www.fourthcoffee.com'  
    AnAttribute='abc'/>  
For Each att As XAttribute In root.Attributes()  
    Console.WriteLine("{0}  IsNamespaceDeclaration:{1}", att, _  
                      att.IsNamespaceDeclaration)  
Next  
```  
  
 This example produces the following output:  
  
```  
xmlns="http://www.adventure-works.com"  IsNamespaceDeclaration:True  
xmlns:fc="www.fourthcoffee.com"  IsNamespaceDeclaration:True  
AnAttribute="abc"  IsNamespaceDeclaration:False  
```  
  
### XPath Axis Methods Do Not Return Child White Space of XDocument  
 [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] allows for child text nodes of an <xref:System.Xml.Linq.XDocument>, as long as the text nodes contain only white space. However, the XPath object model does not include white space as child nodes of a document, so when you iterate through the children of an <xref:System.Xml.Linq.XDocument> using the <xref:System.Xml.Linq.XContainer.Nodes%2A> axis, white space text nodes will be returned. However, when you iterate through the children of an <xref:System.Xml.Linq.XDocument> using the XPath axis methods, white space text nodes will not be returned.  
  
```vb  
' Create a document with some white space child nodes of the document.  
Dim root As XDocument = XDocument.Parse( _  
"<?xml version='1.0' encoding='utf-8' standalone='yes'?>" & _  
vbNewLine & "<Root/>" & vbNewLine & "<!--a comment-->" & vbNewLine, _  
LoadOptions.PreserveWhitespace)  
  
' Count the white space child nodes using LINQ to XML.  
Console.WriteLine(root.Nodes().OfType(Of XText)().Count())  
  
' Count the white space child nodes using XPathEvaluate.  
Dim nodes As IEnumerable = CType(root.XPathEvaluate("text()"), IEnumerable)  
Console.WriteLine(nodes.OfType(Of XText)().Count())  
```  
  
 This example produces the following output:  
  
```  
3  
0  
```  
  
### XDeclaration Objects are not Nodes  
 When you iterate through the children nodes of an <xref:System.Xml.Linq.XDocument>, you will not see the XML declaration object. It is a property of the document, not a child node of it.  
  
```vb  
Dim doc As XDocument = _  
<?xml version='1.0' encoding='utf-8' standalone='yes'?>  
<Root/>  
  
doc.Save("Temp.xml")  
Console.WriteLine(File.ReadAllText("Temp.xml"))  
  
' This shows that there is only one child node of the document.  
Console.WriteLine(doc.Nodes().Count())  
```  
  
 This example produces the following output:  
  
```xml  
<?xml version="1.0" encoding="utf-8" standalone="yes"?>  
<Root />  
1  
```  
  
## See Also  
 [Advanced LINQ to XML Programming (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/advanced-linq-to-xml-programming.md)
