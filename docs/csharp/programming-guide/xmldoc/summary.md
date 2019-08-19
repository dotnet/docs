---
title: "<summary> - C# Programming Guide"
ms.custom: seodec18
ms.date: 07/20/2015
f1_keywords: 
  - "<summary>"
  - "summary"
helpviewer_keywords: 
  - "<summary> C# XML tag"
  - "summary C# XML tag"
ms.assetid: b4c43d92-2067-4eac-a59a-d32f5248c08b
---
# \<summary> (C# Programming Guide)
## Syntax  
  
```xml  
<summary>description</summary>  
```  
  
## Parameters  
 `description`  
 A summary of the object.  
  
## Remarks  
 The \<summary> tag should be used to describe a type or a type member. Use [\<remarks>](./remarks.md) to add supplemental information to a type description. Use the [cref Attribute](./cref-attribute.md) to enable documentation tools such as [DocFX](https://dotnet.github.io/docfx/) and [Sandcastle](https://github.com/EWSoftware/SHFB) to create internal hyperlinks to documentation pages for code elements.  
  
 The text for the \<summary> tag is the only source of information about the type in IntelliSense, and is also displayed in the Object Browser Window.  
  
 Compile with [/doc](../../language-reference/compiler-options/doc-compiler-option.md) to process documentation comments to a file. To create the final documentation based on the compiler-generated file, you can create a custom tool, or use a tool such as [DocFX](https://dotnet.github.io/docfx/) or [Sandcastle](https://github.com/EWSoftware/SHFB).  
  
## Example  
 [!code-csharp[csProgGuideDocComments#12](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideDocComments/CS/DocComments.cs#12)]  
  
 The previous example produces the following XML file.  
  
```xml  
<?xml version="1.0"?>  
<doc>  
    <assembly>  
        <name>YourNamespace</name>  
    </assembly>  
    <members>  
        <member name="T:DotNetEvents.TestClass">  
            text for class TestClass  
        </member>  
        <member name="M:DotNetEvents.TestClass.DoWork(System.Int32)">  
            <summary>DoWork is a method in the TestClass class.  
            <para>Here's how you could make a second paragraph in a description. <see cref="M:System.Console.WriteLine(System.String)"/> for information about output statements.</para>  
            <seealso cref="M:DotNetEvents.TestClass.Main"/>  
            </summary>  
        </member>  
        <member name="M:DotNetEvents.TestClass.Main">  
            text for Main  
        </member>  
    </members>  
</doc>  
```  
  
## Example  
 The following example shows how to make a `cref` reference to a generic type.  
  
 [!code-csharp[csProgGuideDocComments#11](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideDocComments/CS/DocComments.cs#11)]  
  
 The previous example produces the following XML file.  
  
```xml  
<?xml version="1.0"?>  
<doc>  
    <assembly>  
        <name>YourNamespace</name>  
    </assembly>  
    <members>  
        <member name="T:ExtensionMethodsDemo1.A">  
            <summary cref="T:ExtensionMethodsDemo1.C`1">  
            </summary>  
        </member>  
        <member name="T:ExtensionMethodsDemo1.B">  
            <summary cref="T:C`1">  
            </summary>  
        </member>  
        <member name="T:ExtensionMethodsDemo1.C`1">  
            <summary cref="T:ExtensionMethodsDemo1.A">  
            </summary>  
            <typeparam name="T"></typeparam>  
        </member>  
    </members>  
</doc>  
```  
  
## See also

- [C# Programming Guide](../index.md)
- [Recommended Tags for Documentation Comments](./recommended-tags-for-documentation-comments.md)
