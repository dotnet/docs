---
title: "Recommended Tags for Documentation Comments (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "XML [C#], tags"
  - "XML documentation [C#], tags"
ms.assetid: 6e98f7a9-38f4-4d74-b644-1ff1b23320fd
caps.latest.revision: 20
author: "BillWagner"
ms.author: "wiwagn"
---
# Recommended Tags for Documentation Comments (C# Programming Guide)
The C# compiler processes documentation comments in your code and formats them as XML in a file whose name you specify in the **/doc** command-line option. To create the final documentation based on the compiler-generated file, you can create a custom tool, or use a tool such as [Sandcastle](https://github.com/EWSoftware/SHFB).  
  
 Tags are processed on code constructs such as types and type members.  
  
> [!NOTE]
>  Documentation comments cannot be applied to a namespace.  
  
 The compiler will process any tag that is valid XML. The following tags provide generally used functionality in user documentation.  
  
## Tags  
  
||||  
|---|---|---|  
|[\<c>](../../../csharp/programming-guide/xmldoc/code-inline.md)|[\<para>](../../../csharp/programming-guide/xmldoc/para.md)|[\<see>](../../../csharp/programming-guide/xmldoc/see.md)*|  
|[\<code>](../../../csharp/programming-guide/xmldoc/code.md)|[\<param>](../../../csharp/programming-guide/xmldoc/param.md)*|[\<seealso>](../../../csharp/programming-guide/xmldoc/seealso.md)*|  
|[\<example>](../../../csharp/programming-guide/xmldoc/example.md)|[\<paramref>](../../../csharp/programming-guide/xmldoc/paramref.md)|[\<summary>](../../../csharp/programming-guide/xmldoc/summary.md)|  
|[\<exception>](../../../csharp/programming-guide/xmldoc/exception.md)*|[\<permission>](../../../csharp/programming-guide/xmldoc/permission.md)*|[\<typeparam>](../../../csharp/programming-guide/xmldoc/typeparam.md)*|  
|[\<include>](../../../csharp/programming-guide/xmldoc/include.md)*|[\<remarks>](../../../csharp/programming-guide/xmldoc/remarks.md)|[\<typeparamref>](../../../csharp/programming-guide/xmldoc/typeparamref.md)|  
|[\<list>](../../../csharp/programming-guide/xmldoc/list.md)|[\<returns>](../../../csharp/programming-guide/xmldoc/returns.md)|[\<value>](../../../csharp/programming-guide/xmldoc/value.md)|  
  
 (* denotes that the compiler verifies syntax.)  
  
 If you want angle brackets to appear in the text of a documentation comment, use `<` and `>`, as shown in the following example.  
  
```xml  
/// <summary cref="C < T >">  
/// </summary>  
```  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [/doc (C# Compiler Options)](../../../csharp/language-reference/compiler-options/doc-compiler-option.md)  
 [XML Documentation Comments](../../../csharp/programming-guide/xmldoc/xml-documentation-comments.md)
