---
title: "Recommended Tags for Documentation Comments (C# Programming Guide)"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "XML [C#], tags"
  - "XML documentation [C#], tags"
ms.assetid: 6e98f7a9-38f4-4d74-b644-1ff1b23320fd
caps.latest.revision: 20
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
translation.priority.ht: 
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "ru-ru"
  - "zh-cn"
  - "zh-tw"
translation.priority.mt: 
  - "cs-cz"
  - "pl-pl"
  - "pt-br"
  - "tr-tr"
---
# Recommended Tags for Documentation Comments (C# Programming Guide)
The C# compiler processes documentation comments in your code and formats them as XML in a file whose name you specify in the **/doc** command-line option. To create the final documentation based on the compiler-generated file, you can create a custom tool, or use a tool such as [Sandcastle](http://shfb.codeplex.com/).  
  
 Tags are processed on code constructs such as types and type members.  
  
> [!NOTE]
>  Documentation comments cannot be applied to a namespace.  
  
 The compiler will process any tag that is valid XML. The following tags provide generally used functionality in user documentation.  
  
## Tags  
  
||||  
|-|-|-|  
|[\<c>](../xmldoc/-c---csharp-programming-guide-.md)|[\<para>](../xmldoc/-para---csharp-programming-guide-.md)|[\<see>](../xmldoc/-see---csharp-programming-guide-.md)*|  
|[\<code>](../xmldoc/-code---csharp-programming-guide-.md)|[\<param>](../xmldoc/-param---csharp-programming-guide-.md)*|[\<seealso>](../xmldoc/-seealso---csharp-programming-guide-.md)*|  
|[\<example>](../xmldoc/-example---csharp-programming-guide-.md)|[\<paramref>](../xmldoc/-paramref---csharp-programming-guide-.md)|[\<summary>](../xmldoc/-summary---csharp-programming-guide-.md)|  
|[\<exception>](../xmldoc/-exception---csharp-programming-guide-.md)*|[\<permission>](../xmldoc/-permission---csharp-programming-guide-.md)*|[\<typeparam>](../xmldoc/-typeparam---csharp-programming-guide-.md)*|  
|[\<include>](../xmldoc/-include---csharp-programming-guide-.md)*|[\<remarks>](../xmldoc/-remarks---csharp-programming-guide-.md)|[\<typeparamref>](../xmldoc/-typeparamref---csharp-programming-guide-.md)|  
|[\<list>](../xmldoc/-list---csharp-programming-guide-.md)|[\<returns>](../xmldoc/-returns---csharp-programming-guide-.md)|[\<value>](../xmldoc/-value---csharp-programming-guide-.md)|  
  
 (* denotes that the compiler verifies syntax.)  
  
 If you want angle brackets to appear in the text of a documentation comment, use `<` and `>`, as shown in the following example.  
  
```xml  
/// <summary cref="C < T >">  
/// </summary>  
```  
  
## See Also  
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [/doc (C# Compiler Options)](../compiler-options/-doc--csharp-compiler-options-.md)   
 [XML Documentation Comments](../xmldoc/xml-documentation-comments--csharp-programming-guide-.md)