---
title: "Serialization Limitations of XamlWriter.Save"
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
  - "XamlWriter.Save [WPF], serialization limitations of"
  - "limitations of XamlWriter.Save"
  - "serialization limitations of XamlWriter.Save"
ms.assetid: f86acc91-2b67-4039-8555-505734491d36
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Serialization Limitations of XamlWriter.Save
The [!INCLUDE[TLA#tla_api](../../../../includes/tlasharptla-api-md.md)] <xref:System.Windows.Markup.XamlWriter.Save%2A> can be used to serialize the contents of a [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] application as a [!INCLUDE[TLA#tla_xaml](../../../../includes/tlasharptla-xaml-md.md)] file. However, there are some notable limitations in exactly what is serialized. These limitations and some general considerations are documented in this topic.  
  
 
  
<a name="Run_Time__Not_Design_Time_Representation"></a>   
## Run-Time, Not Design-Time Representation  
 The basic philosophy of what is serialized by a call to <xref:System.Windows.Markup.XamlWriter.Save%2A> is that the result will be a representation of the object being serialized, at run-time. Many design-time properties of the original [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] file may already be optimized or lost by the time that the [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] is loaded as in-memory objects, and are not preserved when you call <xref:System.Windows.Markup.XamlWriter.Save%2A> to serialize. The serialized result is an effective representation of the constructed logical tree of the application, but not necessarily of the original [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] that produced it. These issues make it extremely difficult to use the <xref:System.Windows.Markup.XamlWriter.Save%2A> serialization as part of an extensive [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] design surface.  
  
<a name="Serialization_is_Self_Contained"></a>   
## Serialization is Self-Contained  
 The serialized output of <xref:System.Windows.Markup.XamlWriter.Save%2A> is self-contained; everything that is serialized is contained inside a [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] single page, with a single root element, and no external references other than [!INCLUDE[TLA2#tla_uri#plural](../../../../includes/tla2sharptla-urisharpplural-md.md)]. For instance, if your page referenced resources from application resources, these will appear as if they were a component of the page being serialized.  
  
<a name="Extension_References_are_Dereferenced"></a>   
## Extension References are Dereferenced  
 Common references to objects made by various markup extension formats, such as `StaticResource` or `Binding`, will be dereferenced by the serialization process. These were already dereferenced at the time that in-memory objects were created by the application runtime, and the <xref:System.Windows.Markup.XamlWriter.Save%2A> logic does not revisit the original [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] to restore such references to the serialized output. This potentially freezes any databound or resource obtained value to be the value last used by the run-time representation, with only limited or indirect ability to distinguish such a value from any other value set locally. Images are also serialized as object references to images as they exist in the project, rather than as original source references, losing whatever filename or [!INCLUDE[TLA2#tla_uri](../../../../includes/tla2sharptla-uri-md.md)] was originally referenced. Even resources declared within the same page are seen serialized into the point where they were referenced, rather than being preserved as a key of a resource collection.  
  
<a name="Event_Handling_is_Not_Preserved"></a>   
## Event Handling is Not Preserved  
 When event handlers that are added through [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] are serialized, they are not preserved. [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] without code-behind (and also without the related x:Code mechanism) has no way of serializing runtime procedural logic. Because serialization is self-contained and limited to the logical tree, there is no facility for storing the event handlers. As a result, event handler attributes, both the attribute itself and the string value that names the handler, are removed from the output [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)].  
  
<a name="Realistic_Scenarios_for_Use_of_XAMLWriter_Save"></a>   
## Realistic Scenarios for Use of XAMLWriter.Save  
 While the limitations listed here are fairly substantial, there are still several appropriate scenarios for using <xref:System.Windows.Markup.XamlWriter.Save%2A> for serialization.  
  
-   Vector or graphical output: The output of the rendered area can be used to reproduce the same vector or graphics when reloaded.  
  
-   Rich text and flow documents: Text and all element formatting and element containment within it is preserved in the output. This can be useful for mechanisms that approximate a clipboard functionality.  
  
-   Preserving business object data: If you have stored data in custom elements, such as [!INCLUDE[TLA2#tla_xml](../../../../includes/tla2sharptla-xml-md.md)] data, so long as your business objects follow basic [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] rules such as providing custom constructors and conversion for by-reference property values, these business objects can be perpetuated through serialization.
