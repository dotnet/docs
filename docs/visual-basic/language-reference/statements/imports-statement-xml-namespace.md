---
title: "Imports Statement (XML Namespace)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.ImportsXmlns"
helpviewer_keywords: 
  - "XML namespace [Visual Basic], importing"
  - "imports [Visual Basic]"
  - "Imports statement [Visual Basic]"
  - "namespaces [Visual Basic], importing"
ms.assetid: 1f4d50a6-08c7-4c2e-8206-ccae35fcd1b4
caps.latest.revision: 18
author: dotnet-bot
ms.author: dotnetcontent
---
# Imports Statement (XML Namespace)
Imports XML namespace prefixes for use in XML literals and XML axis properties.  
  
## Syntax  
  
```  
Imports <xmlns:xmlNamespacePrefix = "xmlNamespaceName">  
```  
  
## Parts  
 `xmlNamespacePrefix`  
 Optional. The string by which XML elements and attributes can refer to `xmlNamespaceName`. If no `xmlNamespacePrefix` is supplied, the imported XML namespace is the default XML namespace. Must be a valid XML identifier. For more information, see [Names of Declared XML Elements and Attributes](../../../visual-basic/programming-guide/language-features/xml/names-of-declared-xml-elements-and-attributes.md).  
  
 `xmlNamespaceName`  
 Required. The string identifying the XML namespace being imported.  
  
## Remarks  
 You can use the `Imports` statement to define global XML namespaces that you can use with XML literals and XML axis properties, or as parameters passed to the `GetXmlNamespace` operator. (For information about using the `Imports` statement to import an alias that can be used where type names are used in your code, see [Imports Statement (.NET Namespace and Type)](../../../visual-basic/language-reference/statements/imports-statement-net-namespace-and-type.md).) The syntax for declaring an XML namespace by using the `Imports` statement is identical to the syntax used in XML. Therefore, you can copy a namespace declaration from an XML file and use it in an `Imports` statement.  
  
 XML namespace prefixes are useful when you want to repeatedly create XML elements that are from the same namespace. The XML namespace prefix declared with the `Imports` statement is global in the sense that it is available to all code in the file. You can use it when you create XML element literals and when you access XML axis properties. For more information, see [XML Element Literal](../../../visual-basic/language-reference/xml-literals/xml-element-literal.md) and [XML Axis Properties](../../../visual-basic/language-reference/xml-axis/xml-axis-properties.md).  
  
 If you define a global XML namespace without a namespace prefix (for example, `Imports <xmlns="http://SomeNameSpace>"`), that namespace is considered the default XML namespace. The default XML namespace is used for any XML element literals or XML attribute axis properties that do not explicitly specify a namespace. The default namespace is also used if the specified namespace is the empty namespace (that is, `xmlns=""`). The default XML namespace does not apply to XML attributes in XML literals or to XML attribute axis properties that do not have a namespace.  
  
 XML namespaces that are defined in an XML literal, which are called *local XML namespaces*, take precedence over XML namespaces that are defined by the `Imports` statement as global. XML namespaces that are defined by the `Imports` statement take precedence over XML namespaces imported for a Visual Basic project. If an XML literal defines an XML namespace, that local namespace does not apply to embedded expressions.  
  
 Global XML namespaces follow the same scoping and definition rules as .NET Framework namespaces. As a result, you can include an `Imports` statement to define a global XML namespace anywhere you can import a .NET Framework namespace. This includes both code files and project-level imported namespaces. For information about project-level imported namespaces, see [References Page, Project Designer (Visual Basic)](/visualstudio/ide/reference/references-page-project-designer-visual-basic).  
  
 Each source file can contain any number of `Imports` statements. These must follow option declarations, such as the `Option Strict` statement, and they must precede programming element declarations, such as `Module` or `Class` statements.  
  
## Example  
 The following example imports a default XML namespace and an XML namespace identified with the prefix `ns`. It then creates XML literals that use both namespaces.  
  
 [!code-vb[VbXMLSamples#45](../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/imports-statement-xml-namespace_1.vb)]  
  
 This code displays the following text:  
  
```xml  
<ns:outer xmlns="http://DefaultNamespace"   
          xmlns:ns="http://NewNamespace">  
  <ns:innerElement></ns:innerElement>  
  <siblingElement></siblingElement>  
  <innerElement />  
</ns:outer>  
```  
  
## Example  
 The following example imports the XML namespace prefix `ns`. It then creates an XML literal that uses the namespace prefix and displays the element's final form.  
  
 [!code-vb[VbXMLSamples#22](../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/imports-statement-xml-namespace_2.vb)]  
  
 This code displays the following text:  
  
```xml  
<ns:outer xmlns:ns="http://SomeNamespace">  
  <ns:middle xmlns:ns="http://NewNamespace">  
    <ns:inner1 />  
    <inner2 xmlns="http://SomeNamespace" />  
  </ns:middle>  
</ns:outer>  
```  
  
 Notice that the compiler converted the XML namespace prefix from a global prefix to a local prefix definition.  
  
## Example  
 The following example imports the XML namespace prefix `ns`. It then uses the prefix of the namespace to create an XML literal and access the first child node with the qualified name `ns:name`.  
  
 [!code-vb[VbXMLSamples#19](../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/imports-statement-xml-namespace_3.vb)]  
  
 This code displays the following text:  
  
 `Patrick Hines`  
  
## See Also  
 [XML Element Literal](../../../visual-basic/language-reference/xml-literals/xml-element-literal.md)  
 [XML Axis Properties](../../../visual-basic/language-reference/xml-axis/xml-axis-properties.md)  
 [Names of Declared XML Elements and Attributes](../../../visual-basic/programming-guide/language-features/xml/names-of-declared-xml-elements-and-attributes.md)  
 [GetXmlNamespace Operator](../../../visual-basic/language-reference/operators/getxmlnamespace-operator.md)
