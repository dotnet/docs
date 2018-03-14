---
title: "How to: Use the XML Documentation Features (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "XML documentation [C#]"
  - "C# language, XML documentation features"
ms.assetid: 8f33917b-9577-4c9a-818a-640dbbb0b399
caps.latest.revision: 19
author: "BillWagner"
ms.author: "wiwagn"
---
# How to: Use the XML Documentation Features (C# Programming Guide)
The following sample provides a basic overview of a type that has been documented.  
  
## Example  
 [!code-csharp[csProgGuideDocComments#15](../../../csharp/programming-guide/xmldoc/codesnippet/CSharp/how-to-use-the-xml-documentation-features_1.cs)]  
  
 **// This .xml file was generated with the previous code sample.**  
**\<?xml version="1.0"?>**  
**\<doc>**  
 **\<assembly>**  
 **\<name>xmlsample\</name>**  
 **\</assembly>**  
 **\<members>**  
 **\<member name="T:SomeClass">**  
 **\<summary>**  
 **Class level summary documentation goes here.\</summary>**  
 **\<remarks>**  
 **Longer comments can be associated with a type or member**  
 **through the remarks tag\</remarks>**  
 **\</member>**  
 **\<member name="F:SomeClass.m_Name">**  
 **\<summary>**  
 **Store for the name property\</summary>**  
 **\</member>**  
 **\<member name="M:SomeClass.#ctor">**  
 **\<summary>The class constructor.\</summary>**  
 **\</member>**  
 **\<member name="M:SomeClass.SomeMethod(System.String)">**  
 **\<summary>**  
 **Description for SomeMethod.\</summary>**  
 **\<param name="s"> Parameter description for s goes here\</param>**  
 **\<seealso cref="T:System.String">**  
 **You can use the cref attribute on any tag to reference a type or member**  
 **and the compiler will check that the reference exists. \</seealso>**  
 **\</member>**  
 **\<member name="M:SomeClass.SomeOtherMethod">**  
 **\<summary>**  
 **Some other method. \</summary>**  
 **\<returns>**  
 **Return results are described through the returns tag.\</returns>**  
 **\<seealso cref="M:SomeClass.SomeMethod(System.String)">**  
 **Notice the use of the cref attribute to reference a specific method \</seealso>**  
 **\</member>**  
 **\<member name="M:SomeClass.Main(System.String[])">**  
 **\<summary>**  
 **The entry point for the application.**  
 **\</summary>**  
 **\<param name="args"> A list of command line arguments\</param>**  
 **\</member>**  
 **\<member name="P:SomeClass.Name">**  
 **\<summary>**  
 **Name property \</summary>**  
 **\<value>**  
 **A value tag is used to describe the property value\</value>**  
 **\</member>**  
 **\</members>**  
**\</doc>**   
## Compiling the Code  
 To compile the example, type the following command line:  
  
 `csc XMLsample.cs /doc:XMLsample.xml`  
  
 This will create the XML file XMLsample.xml, which you can view in your browser or by using the TYPE command.  
  
## Robust Programming  
 XML documentation starts with ///. When you create a new project, the wizards put some starter /// lines in for you. The processing of these comments has some restrictions:  
  
-   The documentation must be well-formed XML. If the XML is not well-formed, a warning is generated and the documentation file will contain a comment that says that an error was encountered.  
  
-   Developers are free to create their own set of tags. There is a recommended set of tags (see the Further Reading section). Some of the recommended tags have special meanings:  
  
    -   The \<param> tag is used to describe parameters. If used, the compiler will verify that the parameter exists and that all parameters are described in the documentation. If the verification failed, the compiler issues a warning.  
  
    -   The `cref` attribute can be attached to any tag to provide a reference to a code element. The compiler will verify that this code element exists. If the verification failed, the compiler issues a warning. The compiler respects any `using` statements when it looks for a type described in the `cref` attribute.  
  
    -   The \<summary> tag is used by IntelliSense inside Visual Studio to display additional information about a type or member.  
  
        > [!NOTE]
        >  The XML file does not provide full information about the type and members (for example, it does not contain any type information). To get full information about a type or member, the documentation file must be used together with reflection on the actual type or member.  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [/doc (C# Compiler Options)](../../../csharp/language-reference/compiler-options/doc-compiler-option.md)  
 [XML Documentation Comments](../../../csharp/programming-guide/xmldoc/xml-documentation-comments.md)
