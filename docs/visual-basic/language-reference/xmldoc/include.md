---
description: "Learn more about: <include> (Visual Basic)"
title: "<include>"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "include XML tag"
  - "<include> XML tag"
ms.assetid: ba8e9173-82cd-460b-8938-a075a2dfb36d
---
# \<include> (Visual Basic)

Refers to another file that describes the types and members in your source code.  
  
## Syntax  
  
```xml  
<include file="filename" path="tagpath[@name='id']" />  
```  
  
## Parameters  

 `filename`  
 Required. The name of the file containing the documentation. The file name can be qualified with a path. Enclose `filename` in double quotation marks (" ").  
  
 `tagpath`  
 Required. The path of the tags in `filename` that leads to the tag `name`. Enclose the path in double quotation marks (" ").  
  
 `name`  
 Required. The name specifier in the tag that precedes the comments. `Name` will have an `id`.  
  
 `id`  
 Required. The ID for the tag that precedes the comments. Enclose the ID in single quotation marks (' ').  
  
## Remarks  

 Use the `<include>` tag to refer to comments in another file that describe the types and members in your source code. This is an alternative to placing documentation comments directly in your source code file.  
  
 The `<include>` tag uses the W3C XML Path Language (XPath) Version 1.0 Recommendation. For more information about ways to customize your `<include>` use, see <https://www.w3.org/TR/xpath>.  
  
## Example  

 This example uses the `<include>` tag to import member documentation comments from a file called `commentFile.xml`.  
  
 [!code-vb[VbVbcnXmlDocComments#4](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnXmlDocComments/VB/Class1.vb#4)]  
  
 The format of the `commentFile.xml` is as follows.  
  
```xml  
<Docs>  
<Members name="Open">  
<summary>Opens a file.</summary>  
<param name="filename">File name to open.</param>  
</Members>  
<Members name="Close">  
<summary>Closes a file.</summary>  
<param name="filename">File name to close.</param>  
</Members>  
</Docs>  
```  
  
## See also

- [XML Comment Tags](index.md)
