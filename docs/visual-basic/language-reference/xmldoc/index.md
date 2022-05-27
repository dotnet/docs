---
description: "Learn more about: Recommended XML Tags for Documentation Comments (Visual Basic)"
title: "Recommended XML Tags for Documentation Comments"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.XmlDocComment"
helpviewer_keywords: 
  - "tags, XML"
  - "XML comments, recommended tags [Visual Basic]"
  - "comments, recommended XML tags"
ms.assetid: 294e0736-ff1e-498e-af83-6db71ed41a72
---
# Recommended XML Tags for Documentation Comments (Visual Basic)

The Visual Basic compiler can process documentation comments in your code to an XML file. You can use additional tools to process the XML file into documentation.  
  
 XML comments are allowed on code constructs such as types and type members. For partial types, only one part of the type can have XML comments, although there is no restriction on commenting its members.  
  
> [!NOTE]
> Documentation comments cannot be applied to namespaces. The reason is that one namespace can span several assemblies, and not all assemblies have to be loaded at the same time.  
  
 The compiler processes any tag that is valid XML. The following tags provide commonly used functionality in user documentation.  
  
- [\<c>](c.md)
- [\<code>](code.md)
- [\<example>](example.md)
- [\<exception>](exception.md) <sup>1</sup>
- [\<include>](include.md) <sup>1</sup>
- [\<list>](list.md)
- [\<para>](para.md)
- [\<param>](param.md) <sup>1</sup>
- [\<paramref>](paramref.md)
- [\<permission>](permission.md) <sup>1</sup>
- [\<remarks>](remarks.md)
- [\<returns>](returns.md)
- [\<see>](see.md) <sup>1</sup>
- [\<seealso>](seealso.md) <sup>1</sup>
- [\<summary>](summary.md)
- [\<typeparam>](typeparam.md) <sup>1</sup>
- [\<value>](value.md)
  
(<sup>1</sup> The compiler verifies syntax.)  
  
> [!NOTE]
> If you want angle brackets to appear in the text of a documentation comment, use `&lt;` and `&gt;`. For example, the string `"&lt;text in angle brackets&gt;"` will appear as `<text in angle brackets>`.  
  
## See also

- [Documenting Your Code with XML](../../programming-guide/program-structure/documenting-your-code-with-xml.md)
- [-doc](../../reference/command-line-compiler/doc.md)
- [How to: Create XML Documentation](../../programming-guide/program-structure/how-to-create-xml-documentation.md)
