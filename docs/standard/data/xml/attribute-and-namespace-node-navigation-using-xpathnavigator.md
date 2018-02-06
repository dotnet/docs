---
title: "Attribute and Namespace Node Navigation Using XPathNavigator"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 23975f88-e0af-4b88-93de-9e20e11880ad
caps.latest.revision: 2
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Attribute and Namespace Node Navigation Using XPathNavigator
The <xref:System.Xml.XPath.XPathNavigator> class provides two sets of navigation methods, the first set, found in the [Node Set Navigation Using XPathNavigator](../../../../docs/standard/data/xml/node-set-navigation-using-xpathnavigator.md) topic, are used to navigate *node sets* in an <xref:System.Xml.XPath.XPathDocument> or <xref:System.Xml.XmlDocument> object. The second set, described in this topic, are used to navigate *attribute and namespace nodes* in an <xref:System.Xml.XPath.XPathDocument> or <xref:System.Xml.XmlDocument> object.  
  
## Attribute Node Navigation  
 Attributes are properties of an element, not children of an element. This distinction is important, because of the methods of the <xref:System.Xml.XPath.XPathNavigator> class used to navigate sibling, parent, and child nodes.  
  
 For example, the <xref:System.Xml.XPath.XPathNavigator.MoveToPrevious%2A> and <xref:System.Xml.XPath.XPathNavigator.MoveToNext%2A> methods are not used to navigate from an element to an attribute or between attributes. Instead, attributes have distinct methods of navigation.  
  
 The following are the attribute navigation methods of the <xref:System.Xml.XPath.XPathNavigator> class.  
  
-   <xref:System.Xml.XPath.XPathNavigator.MoveToAttribute%2A>  
  
-   <xref:System.Xml.XPath.XPathNavigator.MoveToFirstAttribute%2A>  
  
-   <xref:System.Xml.XPath.XPathNavigator.MoveToNextAttribute%2A>  
  
 When the current node is an element, you can use the <xref:System.Xml.XPath.XPathNavigator.HasAttributes%2A> property to see if there are any attributes associated with the element. After it is known that an element has attributes, there are multiple methods for accessing attributes. To retrieve a single attribute from the element, use the <xref:System.Xml.XPath.XPathNavigator.GetAttribute%2A> method. To move the <xref:System.Xml.XPath.XPathNavigator> to a particular attribute, use the <xref:System.Xml.XPath.XPathNavigator.MoveToAttribute%2A> method. You can also iterate over each attribute of an element by using the <xref:System.Xml.XPath.XPathNavigator.MoveToFirstAttribute%2A> method, followed by multiple calls to the <xref:System.Xml.XPath.XPathNavigator.MoveToNextAttribute%2A> method.  
  
> [!NOTE]
>  When the <xref:System.Xml.XPath.XPathNavigator> object is positioned on an attribute or namespace node, the <xref:System.Xml.XPath.XPathNavigator.MoveToChild%2A>, <xref:System.Xml.XPath.XPathNavigator.MoveToFirst%2A>, <xref:System.Xml.XPath.XPathNavigator.MoveToFirstChild%2A>, <xref:System.Xml.XPath.XPathNavigator.MoveToFollowing%2A>, <xref:System.Xml.XPath.XPathNavigator.MoveToId%2A>, <xref:System.Xml.XPath.XPathNavigator.MoveToNext%2A> and <xref:System.Xml.XPath.XPathNavigator.MoveToPrevious%2A> methods always return `false`, and have no effect on the position of the <xref:System.Xml.XPath.XPathNavigator>. The exceptions are the <xref:System.Xml.XPath.XPathNavigator.MoveTo%2A>, <xref:System.Xml.XPath.XPathNavigator.MoveToParent%2A>, and <xref:System.Xml.XPath.XPathNavigator.MoveToRoot%2A> methods.  
  
## Namespace Node Navigation  
 Each element has an associated set of namespace nodes, one for each distinct namespace prefix that is bound to a namespace URI in scope for the element (including the XML prefix bound to the `http://www.w3.org/XML/1998/namespace` namespace, which is implicitly declared in every XML document) and one for the default namespace if one is in scope for the element. The element is the parent of each of these namespace nodes; however, a namespace node is not a child of its parent element.  
  
 As with attributes, the <xref:System.Xml.XPath.XPathNavigator.MoveToPrevious%2A> and <xref:System.Xml.XPath.XPathNavigator.MoveToNext%2A> methods are not used to navigate from an element to a namespace node, or between namespace nodes. Instead, namespace nodes have distinct methods of navigation.  
  
 The following are the namespace navigation methods of the <xref:System.Xml.XPath.XPathNavigator> class.  
  
-   <xref:System.Xml.XPath.XPathNavigator.MoveToNamespace%2A>  
  
-   <xref:System.Xml.XPath.XPathNavigator.MoveToFirstNamespace%2A>  
  
-   <xref:System.Xml.XPath.XPathNavigator.MoveToNextNamespace%2A>  
  
 There is always at least one namespace node in scope for any element in an XML document. This is the namespace node with the prefix `xml` and namespace URI `http://www.w3.org/XML/1998/namespace`. To retrieve a namespace URI in scope given a particular prefix, use the <xref:System.Xml.XPath.XPathNavigator.GetNamespace%2A> method. To move the <xref:System.Xml.XPath.XPathNavigator> object to a particular namespace node, use the <xref:System.Xml.XPath.XPathNavigator.MoveToNamespace%2A> method. You can also iterate over each namespace node in scope for an element by using the <xref:System.Xml.XPath.XPathNavigator.MoveToFirstNamespace%2A> method followed by multiple calls to the <xref:System.Xml.XPath.XPathNavigator.MoveToNextNamespace%2A> method.  
  
> [!NOTE]
>  When the <xref:System.Xml.XPath.XPathNavigator> object is positioned on an attribute or namespace node, the <xref:System.Xml.XPath.XPathNavigator.MoveToChild%2A>, <xref:System.Xml.XPath.XPathNavigator.MoveToFirst%2A>, <xref:System.Xml.XPath.XPathNavigator.MoveToFirstChild%2A>, <xref:System.Xml.XPath.XPathNavigator.MoveToFollowing%2A>, <xref:System.Xml.XPath.XPathNavigator.MoveToId%2A>, <xref:System.Xml.XPath.XPathNavigator.MoveToNext%2A> and <xref:System.Xml.XPath.XPathNavigator.MoveToPrevious%2A> methods always return `false`, and have no effect on the position of the <xref:System.Xml.XPath.XPathNavigator>. The exceptions are the <xref:System.Xml.XPath.XPathNavigator.MoveTo%2A>, <xref:System.Xml.XPath.XPathNavigator.MoveToParent%2A>, and <xref:System.Xml.XPath.XPathNavigator.MoveToRoot%2A> methods.  
  
### The XPathNamespaceScope Enumeration  
 When navigating namespace nodes the <xref:System.Xml.XPath.XPathNavigator.MoveToFirstNamespace%2A> and <xref:System.Xml.XPath.XPathNavigator.MoveToNextNamespace%2A> methods can be called with an <xref:System.Xml.XPath.XPathNamespaceScope> parameter. These methods behave differently than their counterparts called with no parameters. The <xref:System.Xml.XPath.XPathNamespaceScope> enumeration has values of <xref:System.Xml.XPath.XPathNamespaceScope.All>, <xref:System.Xml.XPath.XPathNamespaceScope.ExcludeXml>, or <xref:System.Xml.XPath.XPathNamespaceScope.Local>.  
  
 The following examples show what namespaces are returned by the <xref:System.Xml.XPath.XPathNavigator.MoveToFirstNamespace%2A> and <xref:System.Xml.XPath.XPathNavigator.MoveToNextNamespace%2A> methods at various scopes in an XML document.  
  
```xml  
<root>  
    <element1 xmlns="http://www.contoso.com" xmlns:books="http://www.contoso.com/books">  
        <element2 />  
    </element1>  
</root>  
```  
  
 The namespace sequence (the namespace the <xref:System.Xml.XPath.XPathNavigator> is positioned upon after calling the <xref:System.Xml.XPath.XPathNavigator.MoveToFirstNamespace%2A> method followed by a series of calls to the <xref:System.Xml.XPath.XPathNavigator.MoveToNextNamespace%2A> method) is as follows.  
  
-   When positioned on `element2`: `xmlns:books="http://www.contoso.com/books"`, `xmlns="http://www.contoso.com"`, and `xmlns:xml="http://www.w3.org/XML/1998/namespace"`.  
  
-   When positioned on `element1`: `xmlns:books="http://www.contoso.com/books"`, `xmlns="http://www.contoso.com"`, and `xmlns:xml="http://www.w3.org/XML/1998/namespace"`.  
  
-   When positioned on `root`: `xmlns:xml="http://www.w3.org/XML/1998/namespace".`  
  
> [!NOTE]
>  The <xref:System.Xml.XPath.XPathNavigator> class returns namespace nodes in reverse document order. Therefore, <xref:System.Xml.XPath.XPathNavigator.MoveToFirstNamespace%2A> essentially moves to the last namespace node in the current scope.  
  
 The following examples show what namespaces are returned by the <xref:System.Xml.XPath.XPathNavigator.MoveToFirstNamespace%2A> and <xref:System.Xml.XPath.XPathNavigator.MoveToNextNamespace%2A> methods with the <xref:System.Xml.XPath.XPathNamespaceScope> enumeration specified at various scopes in an XML document.  
  
```xml  
<root xmlns="http://www.contoso.com" xmlns:a="http://www.contoso.com/a" xmlns:b="http://www.contoso.com/b">  
    <child1 xmlns="" xmlns:a="urn:a">  
        <child2 xmlns:c="urn:c" />  
    </child1>  
</root>  
```  
  
 When positioned on `child2`, the namespace sequence (the namespace the <xref:System.Xml.XPath.XPathNavigator> is positioned upon after calling the <xref:System.Xml.XPath.XPathNavigator.MoveToFirstNamespace%2A> method followed by a series of calls to the <xref:System.Xml.XPath.XPathNavigator.MoveToNextNamespace%2A> method) is as follows.  
  
-   <xref:System.Xml.XPath.XPathNamespaceScope.All>: `xmlns:c="urn:c"`, `xmlns:a="urn:a"`, `xmlns=""`, `xmlns:b="http://www.contoso.com/b"`, `xmlns:a="http://www.contoso.com/a"`, `xmlns="http://www.contoso.com"`, and `xmlns:xml="http://www.w3.org/XML/1998/namespace"`.  
  
-   <xref:System.Xml.XPath.XPathNamespaceScope.ExcludeXml>: `xmlns:c="urn:c"`, `xmlns:a="urn:a"`, `xmlns=""`, `xmlns:b="http://www.contoso.com/b"`, `xmlns:a="http://www.contoso.com/a"`, and `xmlns="http://www.contoso.com"`.  
  
-   <xref:System.Xml.XPath.XPathNamespaceScope.Local>: `xmlns:c="urn:c"`.  
  
> [!NOTE]
>  The <xref:System.Xml.XPath.XPathNavigator> class returns namespace nodes in reverse document order. Therefore, <xref:System.Xml.XPath.XPathNavigator.MoveToFirstNamespace%2A> essentially moves to the last namespace node in the current scope.  
  
## See Also  
 <xref:System.Xml.XmlDocument>  
 <xref:System.Xml.XPath.XPathDocument>  
 <xref:System.Xml.XPath.XPathNavigator>  
 [Process XML Data Using the XPath Data Model](../../../../docs/standard/data/xml/process-xml-data-using-the-xpath-data-model.md)  
 [Node Set Navigation Using XPathNavigator](../../../../docs/standard/data/xml/node-set-navigation-using-xpathnavigator.md)  
 [Extract XML Data Using XPathNavigator](../../../../docs/standard/data/xml/extract-xml-data-using-xpathnavigator.md)  
 [Accessing Strongly Typed XML Data Using XPathNavigator](../../../../docs/standard/data/xml/accessing-strongly-typed-xml-data-using-xpathnavigator.md)
