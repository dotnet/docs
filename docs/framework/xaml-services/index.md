---
title: "XAML Services"
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
  - "XAML [XAML Services], System.Xaml concepts"
  - "XAML Services in WPF [XAML Services]"
  - "System.Xaml [XAML Services], conceptual documentation"
ms.assetid: 0e11f386-808c-4eae-9ba6-029ad7ba2211
caps.latest.revision: 13
author: "wadepickett"
ms.author: "wpickett"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# XAML Services
This topic describes the capabilities of a technology set known as .NET Framework XAML Services. The majority of the services and APIs described are located in the assembly System.Xaml, which is an assembly introduced with the [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)] set of .NET core assemblies. Services include readers and writers, schema classes and schema support, factories, attributing of classes, XAML language intrinsic support, and other XAML language features.  
  
## About This Documentation  
 Conceptual documentation for .NET Framework XAML Services assumes that you have previous experience with the XAML language and how it might apply to a specific framework, for example [!INCLUDE[TLA#tla_winclient](../../../includes/tlasharptla-winclient-md.md)] or [!INCLUDE[TLA#tla_workflow](../../../includes/tlasharptla-workflow-md.md)], or a specific technology feature area, for example the build customization features in <xref:Microsoft.Build.Framework.XamlTypes>. This documentation does not attempt to explain the basics of XAML as a markup language, XAML syntax terminology, or other introductory material. Instead, this documentation focuses on specifically using the .NET Framework XAML Services that are enabled in the System.Xaml assembly library. Most of these APIs are for scenarios of XAML language integration and extensibility. This might include any of the following:  
  
-   Extending the capabilities of the base XAML readers or XAML writers (processing the XAML node stream directly; deriving your own XAML reader or XAML writer).  
  
-   Defining XAML-usable custom types that do not have specific framework dependencies, and attributing the types to convey their XAML type system characteristics to .NET Framework XAML Services.  
  
-   Hosting XAML readers or XAML writers as a component of an application, such as a visual designer or interactive editor for XAML markup sources.  
  
-   Writing XAML value converters (markup extensions; type converters for custom types).  
  
-   Defining a custom XAML schema context (using alternate assembly-loading techniques for backing type sources; using known-types lookup techniques instead of always reflecting assemblies; using loaded assembly concepts that do not use the CLR `AppDomain` and its associated security model).  
  
-   Extending the base XAML type system.  
  
-   Using the `Lookup` or `Invoker` techniques to influence the XAML type system and how type backings are evaluated.  
  
 If you are looking for introductory material on XAML as a language, you might try [XAML Overview (WPF)](../../../docs/framework/wpf/advanced/xaml-overview-wpf.md). That topic discusses XAML for an audience that is new both to [!INCLUDE[TLA#tla_winclient](../../../includes/tlasharptla-winclient-md.md)] and also to using XAML markup and XAML language features. Another useful document is the introductory material in the [XAML language specification](http://go.microsoft.com/fwlink/?LinkId=114525).  
  
## .NET Framework XAML Services and System.Xaml in the .NET Architecture  
 In previous versions of [!INCLUDE[TLA#tla_netframewk](../../../includes/tlasharptla-netframewk-md.md)], support for XAML language features was implemented by frameworks that built on [!INCLUDE[TLA#tla_netframewk](../../../includes/tlasharptla-netframewk-md.md)] ([!INCLUDE[TLA#tla_winclient](../../../includes/tlasharptla-winclient-md.md)], [!INCLUDE[TLA#tla_workflow](../../../includes/tlasharptla-workflow-md.md)] and [!INCLUDE[vsindigo](../../../includes/vsindigo-md.md)]), and therefore varied in its behavior and the API used depending on which specific framework you were using. This included the XAML parser and its object graph creation mechanism, XAML language intrinsics, serialization support, and so on.  
  
 In [!INCLUDE[net_v40_long](../../../includes/net-v40-long-md.md)], .NET Framework XAML Services and the System.Xaml assembly define much of what is needed for supporting XAML language features. This includes base classes for XAML readers and XAML writers. The most important feature added to .NET Framework XAML Services that was not present in any of the framework-specific XAML implementations is a type system representation for XAML. The type system representation presents XAML in an object-oriented way that centers on XAML capabilities without taking dependencies on specific capabilities of frameworks.  
  
 The XAML type system is not limited by the markup form or run-time specifics of the XAML origin; nor is it limited by any specific backing type system. The XAML type system includes object representations for types, members, XAML schema contexts, XML-level concepts, and other XAML language concepts or XAML intrinsics. Using or extending the XAML type system makes it possible to derive from classes like XAML readers and XAML writers, and extend the functionality of XAML representations into specific features enabled by a framework, a technology, or an application that consumes or emits XAML. The concept of a XAML schema context enables practical object graph write operations from the combination of a XAML object writer implementation, a technology's backing type system as communicated through assembly information in the context, and the XAML node source. For more information on the XAML schema concept. see [Default XAML Schema Context and WPF XAML Schema Context](../../../docs/framework/xaml-services/default-xaml-schema-context-and-wpf-xaml-schema-context.md).  
  
## XAML Node Streams, XAML Readers, and XAML Writers  
 To understand the role that .NET Framework XAML Services plays in the relationship between the XAML language and specific technologies that use XAML as a language, it is helpful to understand the concept of a XAML node stream and how that concept shapes the API and terminology. The XAML node stream is a conceptual intermediate between a XAML language representation and the object graph that the XAML represents or defines.  
  
-   A XAML reader is an entity that processes XAML in some form, and produces a XAML node stream. In the API, a XAML reader is represented by the base class <xref:System.Xaml.XamlReader>.  
  
-   A XAML writer is an entity that processes a XAML node stream and produces something else. In the API, a XAML writer is represented by the base class <xref:System.Xaml.XamlWriter>.  
  
 The two most common scenarios involving XAML are loading XAML to instantiate an object graph, and saving an object graph from an application or tool and producing a XAML representation (typically in markup form saved as text file). Loading XAML and creating an object graph is often referred to in this documentation as the load path. Saving or serializing an existing object graph to XAML is often referred to in this documentation as the save path.  
  
 The most common type of load path can be described as follows:  
  
-   Start with a XAML representation, in UTF-encoded XML format and saved as a text file.  
  
-   Load that XAML into <xref:System.Xaml.XamlXmlReader>. <xref:System.Xaml.XamlXmlReader> is a <xref:System.Xaml.XamlReader> subclass.  
  
-   The result is a XAML node stream. You can access individual nodes of the XAML node stream using <xref:System.Xaml.XamlXmlReader> / <xref:System.Xaml.XamlReader> API. The most typical operation here is to advance through the XAML node stream, processing each node using a "current record" metaphor.  
  
-   Pass the resulting nodes from the XAML node stream to a <xref:System.Xaml.XamlObjectWriter> API. <xref:System.Xaml.XamlObjectWriter> is a <xref:System.Xaml.XamlWriter> subclass.  
  
-   The <xref:System.Xaml.XamlObjectWriter> writes an object graph, one object at a time, in accordance to progress through the source XAML node stream. This is done with the assistance of a XAML schema context and an implementation that can access the assemblies and types of a backing type system and framework.  
  
-   Call <xref:System.Xaml.XamlObjectWriter.Result%2A> at the end of the XAML node stream to obtain the root object of the object graph.  
  
 The most common type of save path can be described as follows:  
  
-   Start with the object graph of an entire application run time, the UI content and state of a run time, or a smaller segment of an overall application's object representation at run time.  
  
-   From a logical start object, such as an application root or document root, load the objects into <xref:System.Xaml.XamlObjectReader>. <xref:System.Xaml.XamlObjectReader> is a <xref:System.Xaml.XamlReader> subclass.  
  
-   The result is a XAML node stream. You can access individual nodes of the XAML node stream using <xref:System.Xaml.XamlObjectReader> and <xref:System.Xaml.XamlReader> API. The most typical operation here is to advance through the XAML node stream, processing each node using a "current record" metaphor.  
  
-   Pass the resulting nodes from the XAML node stream to a <xref:System.Xaml.XamlXmlWriter> API. <xref:System.Xaml.XamlXmlWriter> is a <xref:System.Xaml.XamlWriter> subclass.  
  
-   The <xref:System.Xaml.XamlXmlWriter> writes XAML in an XML UTF encoding. You can save this as a text file, as a stream, or in other forms.  
  
-   Call <xref:System.Xaml.XamlXmlWriter.Flush%2A> to obtain the final output.  
  
 For more information about XAML node stream concepts, see [Understanding XAML Node Stream Structures and Concepts](../../../docs/framework/xaml-services/understanding-xaml-node-stream-structures-and-concepts.md).  
  
### The XamlServices Class  
 It is not always necessary to deal with a XAML node stream. If you want a basic load path or a basic save path, you can use APIs in the <xref:System.Xaml.XamlServices> class.  
  
-   Various signatures of <xref:System.Xaml.XamlServices.Load%2A> implement a load path. You can either load a file or stream, or can load an <xref:System.Xml.XmlReader>, <xref:System.IO.TextReader> or <xref:System.Xaml.XamlReader> that wrap your XAML input by loading with that reader's APIs.  
  
-   Various signatures of <xref:System.Xaml.XamlServices.Save%2A> save an object graph and produce output as a stream, file, or <xref:System.Xml.XmlWriter>/<xref:System.IO.TextWriter> instance.  
  
-   <xref:System.Xaml.XamlServices.Transform%2A> converts XAML by linking a load path and a save path as a single operation. A different schema context or different backing type system could be used for <xref:System.Xaml.XamlReader> and <xref:System.Xaml.XamlWriter>, which is what influences how the resulting XAML is transformed.  
  
 For more information about how to use <xref:System.Xaml.XamlServices>, see [XAMLServices Class and Basic XAML Reading or Writing](../../../docs/framework/xaml-services/xamlservices-class-and-basic-xaml-reading-or-writing.md).  
  
## XAML Type System  
 The XAML type system provides the APIs that are required to work with a given individual node of a XAML node stream.  
  
 <xref:System.Xaml.XamlType> is the representation for an object - what you are processing between a start object node and end object node.  
  
 <xref:System.Xaml.XamlMember> is the representation for a member of an object - what you are processing between a start member node and end member node.  
  
 APIs such as <xref:System.Xaml.XamlType.GetAllMembers%2A> and <xref:System.Xaml.XamlType.GetMember%2A> and <xref:System.Xaml.XamlMember.DeclaringType%2A> report the relationships between a <xref:System.Xaml.XamlType> and <xref:System.Xaml.XamlMember>.  
  
 The default behavior of the XAML type system as implemented by .NET Framework XAML Services is based on the common language runtime (CLR), and static analysis of CLR types in assemblies by using reflection. Therefore, for a specific CLR type, the default implementation of the XAML type system can expose the XAML schema of that type and its members and report it in terms of the XAML type system. In the default XAML type system, the concept of assignability of types is mapped onto CLR inheritance, and the concepts of instances, value types and so on are also mapped to the supporting behaviors and features of the CLR.  
  
## Reference for XAML Language Features  
 To support XAML, .NET Framework XAML Services provides specific implementation of XAML language concepts as defined for the XAML language XAML namespace. These are documented as specific reference pages. The language features are documented from the perspective of how these language features behave when they are processed by a XAML reader or XAML writer that is defined by .NET Framework XAML Services. For more information, see [XAML Namespace (x:) Language Features](../../../docs/framework/xaml-services/xaml-namespace-x-language-features.md).
