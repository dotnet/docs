---
title: "XAMLServices Class and Basic XAML Reading or Writing"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "XAML [XAML Services], XamlServices class"
  - "XamlServices class [XAML Services], how to use"
ms.assetid: 6ac27fad-3687-4d7a-add1-3e90675fdfde
caps.latest.revision: 11
author: "wadepickett"
ms.author: "wpickett"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# XAMLServices Class and Basic XAML Reading or Writing
<xref:System.Xaml.XamlServices> is a class provided by .NET Framework XAML Services that can be used to address XAML scenarios that do not require specific access to the XAML node stream, or XAML type system information obtained from those nodes. <xref:System.Xaml.XamlServices> API can be summarized as the following: `Load` or `Parse` to support a XAML load path, `Save` to support a XAML save path, and `Transform` to provide a technique that joins a load path and save path. `Transform` can be used to change from one XAML schema to another. This topic summarizes each of these API classifications and describes the differences between particular method overloads.  
  
<a name="load"></a>   
## Load  
 Various overloads of <xref:System.Xaml.XamlServices.Load%2A> implement the complete logic for a load path. The load path uses XAML in some form and outputs a XAML node stream. Most of these load paths use XAML in an encoded XML text-file form. However, you can also load a general stream, or you can load a preloaded XAML source that is already contained in a different <xref:System.Xaml.XamlReader> implementation.  
  
 The simplest overload for most scenarios is <xref:System.Xaml.XamlServices.Load%28System.String%29>. This overload has a `fileName` parameter that is simply the name of a text file that contains the XAML to load. This is appropriate for application scenarios such as full trust applications that have previously serialized state or data to the local computer. This is also useful for frameworks where you are defining the application model and want to load one of the standard files that defines application behavior, starting UI, or other framework-defined capabilities that use XAML.  
  
 <xref:System.Xaml.XamlServices.Load%28System.IO.Stream%29> has similar scenarios. This overload might be useful if you have the user choose files to load, because a <xref:System.IO.Stream> is a frequent output of other <xref:System.IO> APIs that can access a file system. Or you could be accessing XAML sources through asynchronous downloads or other network techniques that also provide a stream. (Loading from a stream or user-selected source may have security implications. For more information, see [XAML Security Considerations](../../../docs/framework/xaml-services/xaml-security-considerations.md).)  
  
 <xref:System.Xaml.XamlServices.Load%28System.IO.TextReader%29> and <xref:System.Xaml.XamlServices.Load%28System.Xml.XmlReader%29> are overloads that rely on readers of formats from previous versions of the .NET Framework. To use these overloads , you should have already created a reader instance and used its `Create` API to load the XAML in the relevant form (text or XML). If you have already moved record pointers in the other readers or performed other operations with them, this is not important. The load path logic from <xref:System.Xaml.XamlServices.Load%2A> always processes the entire XAML input from the root down. Scenarios for these overloads might include the following:  
  
-   Design surfaces where you provide simple XAML editing capability from an existing XML-specific text editor.  
  
-   Variants of the core <xref:System.IO> scenarios, where you use the dedicated readers to open files or streams. Your logic performs rudimentary checking or processing of the contents before it tries to load as XAML.  
  
 You can either load a file or stream, or you can load an <xref:System.Xml.XmlReader>, <xref:System.IO.TextReader>, or <xref:System.Xaml.XamlReader> that wrap your XAML input by loading with the reader's APIs.  
  
 Internally, each of the preceding overloads is ultimately <xref:System.Xaml.XamlServices.Load%28System.Xml.XmlReader%29>, and the passed <xref:System.Xml.XmlReader> is used to create a new <xref:System.Xaml.XamlXmlReader>.  
  
 The `Load` signature that provides for more advanced scenarios is <xref:System.Xaml.XamlServices.Load%28System.Xaml.XamlReader%29>. You can use this signature for one of the following cases:  
  
-   You have defined your own implementation of a <xref:System.Xaml.XamlReader>.  
  
-   You need to specify settings for <xref:System.Xaml.XamlReader> that vary from the default settings.  
  
 Examples of non-default settings are setting any of the following: <xref:System.Xaml.XamlReaderSettings.AllowProtectedMembersOnRoot%2A>; <xref:System.Xaml.XamlReaderSettings.BaseUri%2A>; <xref:System.Xaml.XamlReaderSettings.IgnoreUidsOnPropertyElements%2A>; <xref:System.Xaml.XamlReaderSettings.LocalAssembly%2A>; <xref:System.Xaml.XamlReaderSettings.ValuesMustBeString%2A>. The default reader for <xref:System.Xaml.XamlServices> is <xref:System.Xaml.XamlXmlReader>. If you provide your own <xref:System.Xaml.XamlXmlReader>, with settings, the following are properties to set non-default <xref:System.Xaml.XamlXmlReaderSettings>: <xref:System.Xaml.XamlXmlReaderSettings.CloseInput%2A>; <xref:System.Xaml.XamlXmlReaderSettings.SkipXmlCompatibilityProcessing%2A>; <xref:System.Xaml.XamlXmlReaderSettings.XmlLang%2A>; <xref:System.Xaml.XamlXmlReaderSettings.XmlSpacePreserve%2A>.  
  
<a name="parse"></a>   
## Parse  
 <xref:System.Xaml.XamlServices.Parse%2A> is like `Load` because it is a load path API that creates a XAML node stream from XAML input. However, in this case, the XAML input is provided directly as a string that contains all the XAML to load. <xref:System.Xaml.XamlServices.Parse%2A> is a lightweight approach that is more appropriate for application scenarios than framework scenarios. For more information, see <xref:System.Xaml.XamlServices.Parse%2A>. <xref:System.Xaml.XamlServices.Parse%2A> is really just a wrapped <xref:System.Xaml.XamlServices.Load%28System.Xml.XmlReader%29> call that involves a <xref:System.IO.StringReader> internally.  
  
<a name="save"></a>   
## Save  
 Various overloads  of <xref:System.Xaml.XamlServices.Save%2A> implement the save path. All of the <xref:System.Xaml.XamlServices.Save%2A> methods all take an object graph as input and produce output as a stream, file, or <xref:System.Xml.XmlWriter>/<xref:System.IO.TextWriter> instance.  
  
 The input object is expected to be the root object of some object representation. This might be the single root of a business object, the root of an object tree for a page in a UI scenario, the working editing surface from a design tool, or other root object concepts that are appropriate for scenarios.  
  
 In many scenarios the object tree that you save is related to an original operation that loaded XAML either with <xref:System.Xaml.XamlServices.Load%2A> or with other API implemented by a framework/application model. There might be differences captured in the object tree that are due to state changes, changes where your application captured runtime settings from a user, changed XAML because your application is a XAML design surface, etc. With or without changes, the concept of first loading XAML from markup and then saving it again and comparing the two XAML markup forms is sometimes referred as a round-trip representation of the XAML.  
  
 The challenge with saving and serializing a complex object that is set in a markup form is in achieving a balance between full representation without information loss, versus verbosity that makes the XAML less human-readable. Moreover, different customers for XAML might have different definitions or expectations for how that balance should be set. The <xref:System.Xaml.XamlServices.Save%2A> APIs represent one definition of that balance. The <xref:System.Xaml.XamlServices.Save%2A> APIs use available XAML schema context and the default CLR-based characteristics of <xref:System.Xaml.XamlType>, <xref:System.Xaml.XamlMember>, and other XAML intrinsic and XAML type system concepts to determine where certain XAML node stream constructs can be optimized when they are saved back into markup. For example, <xref:System.Xaml.XamlServices> save paths can use CLR-based default XAML schema context to resolve <xref:System.Xaml.XamlType> for objects, can determine a <xref:System.Xaml.XamlType.ContentProperty%2A?displayProperty=nameWithType>, and then can omit property element tags when they write the property to the XAML content of the object.  
  
<a name="transform"></a>   
## Transform  
 <xref:System.Xaml.XamlServices.Transform%2A> converts or transforms XAML by linking a load path and a save path as a single operation. A different schema context or different backing type system can be used for <xref:System.Xaml.XamlReader> and <xref:System.Xaml.XamlWriter>, which is what influences how the resulting XAML is transformed. This works well for broad transform operations.  
  
 For operations that rely on examining each node in a XAML node stream, you typically do not use <xref:System.Xaml.XamlServices.Transform%2A>. Instead you need to define your own load path-save path operation series and interject your own logic. In one of the paths, use a XAML reader/XAML writer pair around your own node loop. For example, load the initial XAML using <xref:System.Xaml.XamlXmlReader> and step into the nodes with successive <xref:System.Xaml.XamlXmlReader.Read%2A> calls. Operating at the XAML node stream level you can now adjust individual nodes (types, members, other nodes) to apply a transformation, or leave the node as-is. Then you send the node onwards to the relevant `Write` API of a <xref:System.Xaml.XamlObjectWriter> and write out the object. For more information, see [Understanding XAML Node Stream Structures and Concepts](../../../docs/framework/xaml-services/understanding-xaml-node-stream-structures-and-concepts.md).  
  
## See Also  
 <xref:System.Xaml.XamlObjectWriter>  
 <xref:System.Xaml.XamlServices>  
 [XAML Services](../../../docs/framework/xaml-services/index.md)
