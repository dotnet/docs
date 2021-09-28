---
description: "Learn more about: Names of Declared XML Elements and Attributes (Visual Basic)"
title: "Names of Declared XML Elements and Attributes"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "declarations [XML in Visual Basic]"
  - "element names [XML in Visual Basic]"
  - "names in XML literals [Visual Basic]"
  - "attribute names [XML in Visual Basic]"
  - "XML literals [Visual Basic], element names"
ms.assetid: cc110118-b6cf-4ff9-a4e4-6233c90c9fbf
---
# Names of Declared XML Elements and Attributes (Visual Basic)

This topic provides Visual Basic guidelines for naming XML elements and attributes in XML literals.  In an XML literal, you can specify a local name or a qualified name. A qualified name consists of an XML namespace prefix, a colon, and a local name. For more information about XML namespace prefixes, see [XML Element Literal](../../../language-reference/xml-literals/xml-element-literal.md).  
  
## Rules  

 A local name of an element or attribute in Visual Basic must adhere to the following rules.  
  
- It can begin with a namespace. It must begin with an alphabetical character or an underscore (`_`).  
  
- It must contain only alphabetical characters, decimal digits, underscores, periods (.), and hyphens (-).  
  
- It must not be more than 1,024 characters long.  
  
- Colons that appear in names indicate namespace demarcation. Therefore, you can use colons only to specify an XML namespace for a particular name.  
  
 In addition, you should adhere to the following guideline.  
  
- The XML 1.0 specification reserves all names starting with the string "xml", of any capitalization variation. Therefore, do not use those names for your element and attribute names.  
  
### Name Length Guidelines  

 As a practical matter, a name should be as short as possible while still clearly identifying the nature of the element. This improves the readability of your code and reduces line length and source-file size.  
  
 However, your name should not be so short that it does not adequately describe the element or how your code uses it. This is important for the readability of your code. If somebody else is trying to understand it, or if you yourself are looking at it a long time after you wrote it, appropriate element names can save time.  
  
## Case Sensitivity in Names  

 XML element names are case sensitive. This means that when the Visual Basic compiler compares two names that differ in alphabetical case only, it interprets them as different names. For example, it interprets `ABC` and `abc` as referring to separate elements.  
  
## XML Namespaces  

 When creating an XML element literal, you can specify the XML namespace prefix for the element name. For more information, see [XML Element Literal](../../../language-reference/xml-literals/xml-element-literal.md).  
  
## See also

- [Creating XML in Visual Basic](creating-xml.md)
- [XML Element Literal](../../../language-reference/xml-literals/xml-element-literal.md)
