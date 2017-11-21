---
title: "&lt;include&gt; (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "include"
  - "<include>"
helpviewer_keywords: 
  - "<include> C# XML tag"
  - "include C# XML tag"
ms.assetid: a8a70302-6196-4643-bd09-ef33f411f18f
caps.latest.revision: 19
author: "BillWagner"
ms.author: "wiwagn"
---
# &lt;include&gt; (C# Programming Guide)
## Syntax  
  
```xml  
<include file='filename' path='tagpath[@name="id"]' />  
```  
  
#### Parameters  
 `filename`  
 The name of the XML file containing the documentation. The file name can be qualified with a path. Enclose `filename` in single quotation marks (' ').  
  
 `tagpath`  
 The path of the tags in `filename` that leads to the tag `name`. Enclose the path in single quotation marks (' ').  
  
 `name`  
 The name specifier in the tag that precedes the comments; `name` will have an `id`.  
  
 `id`  
 The ID for the tag that precedes the comments. Enclose the ID in double quotation marks (" ").  
  
## Remarks  
 The \<include> tag lets you refer to comments in another file that describe the types and members in your source code. This is an alternative to placing documentation comments directly in your source code file. By putting the documentation in a separate file, you can apply source control to the documentation separately from the source code. One person can have the source code file checked out and someone else can have the documentation file checked out.  
  
 The \<include> tag uses the XML XPath syntax. Refer to XPath documentation for ways to customize your \<include> use.  
  
## Example  
 This is a multifile example. The first file, which uses \<include>, is listed below:  
  
 [!code-csharp[csProgGuideDocComments#5](../../../csharp/programming-guide/xmldoc/codesnippet/CSharp/include_1.cs)]  
  
 The second file, xml_include_tag.doc, contains the following documentation comments:  
  
```xml  
<MyDocs>  
  
<MyMembers name="test">  
<summary>  
The summary for this type.  
</summary>  
</MyMembers>  
  
<MyMembers name="test2">  
<summary>  
The summary for this other type.  
</summary>  
</MyMembers>  
  
</MyDocs>  
```  
  
## Program Output  
 The following output is generated when you compile the Test and Test2 classes with the following command line: `/doc:DocFileName.xml.` In Visual Studio, you specify the XML doc comments option in the Build pane of the Project Designer. When the C# compiler sees the \<include> tag, it will search for documentation comments in xml_include_tag.doc instead of the current source file. The compiler then generates DocFileName.xml, and this is the file that is consumed by documentation tools such as [Sandcastle](https://github.com/EWSoftware/SHFB) to produce the final documentation.  
  
```xml  
<?xml version="1.0"?>   
<doc>   
    <assembly>   
        <name>xml_include_tag</name>   
    </assembly>   
    <members>   
        <member name="T:Test">   
            <summary>   
The summary for this type.   
</summary>   
        </member>   
        <member name="T:Test2">   
            <summary>   
The summary for this other type.   
</summary>   
        </member>   
    </members>   
</doc>   
```  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Recommended Tags for Documentation Comments](../../../csharp/programming-guide/xmldoc/recommended-tags-for-documentation-comments.md)
