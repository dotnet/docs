---
title: "Document Serialization and Storage"
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
  - "serialization of documents [WPF], , "
  - "documents [WPF], storage"
  - "documents [WPF], serialization"
ms.assetid: 4839cd87-e206-4571-803f-0200098ad37b
caps.latest.revision: 24
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Document Serialization and Storage
[!INCLUDE[TLA#tla_winfx](../../../../includes/tlasharptla-winfx-md.md)] provides a powerful environment for creating and displaying high quality documents.  Enhanced features that support both fixed-documents and flow-documents, advanced viewing controls, combined with powerful 2D and 3D graphic capabilities take [!INCLUDE[TLA2#tla_winfx](../../../../includes/tla2sharptla-winfx-md.md)] applications to a new level of quality and user experience.  Being able to flexibly manage an in-memory representation of a document is a key feature of [!INCLUDE[TLA2#tla_winfx](../../../../includes/tla2sharptla-winfx-md.md)], and being able to efficiently save and load documents from a data store is a need of almost every application.  The process of converting a document from an internal in-memory representation to an external data store is termed serialization.  The reverse process of reading a data store and recreating the original in-memory instance is termed deserialization.  
  
 
  
<a name="AboutSerialization"></a>   
## About Document Serialization  
 Ideally the process of serializing and deserializing a document from and then back into memory is transparent to the application.  The application calls a serializer "write" method to save the document, while a deserializer "read" method accesses the data store and recreates the original instance in memory.  The specific format that the data is stored in is generally not a concern of the application as long as the serialize and deserialize process recreates the document back to its original form.  
  
 Applications often provide multiple serialization options which allow the user to save documents to different medium or to a different format.  For example, an application might offer "Save As" options to store a document to a disk file, database, or web service.  Similarly, different serializers could store the document in different formats such as in HTML, RTF, XML, XPS, or alternately to a third-party format.  To the application, serialization defines an interface that isolates the details of the storage medium within the implementation of each specific serializer.  In addition to the benefits of encapsulating storage details, the [!INCLUDE[TLA2#tla_winfx](../../../../includes/tla2sharptla-winfx-md.md)] <xref:System.Windows.Documents.Serialization> [!INCLUDE[TLA2#tla_api#plural](../../../../includes/tla2sharptla-apisharpplural-md.md)] provide several other important features.  
  
### Features of .NET Framework 3.0 Document Serializers  
  
-   Direct access to the high-level document objects (logical tree and visuals) enable efficient storage of paginated content, 2D/3D elements, images, media, hyperlinks, annotations, and other support content.  
  
-   Synchronous and asynchronous operation.  
  
-   Support for plug-in serializers with enhanced capabilities:  
  
    -   System-wide access for use by all [!INCLUDE[TLA2#tla_winfx](../../../../includes/tla2sharptla-winfx-md.md)] applications.  
  
    -   Simple application plug-in discoverability.  
  
    -   Simple deployment, installation, and update for custom third-party plug-ins.  
  
    -   User interface support for custom run-time settings and options.  
  
### XPS Print Path  
 The [!INCLUDE[TLA#tla_winfx](../../../../includes/tlasharptla-winfx-md.md)] [!INCLUDE[TLA2#tla_xps](../../../../includes/tla2sharptla-xps-md.md)] print path also provides an extensible mechanism for writing documents through print output.  [!INCLUDE[TLA2#tla_xps](../../../../includes/tla2sharptla-xps-md.md)] serves as both a document file format and is the native print spool format for [!INCLUDE[TLA#tla_winvista](../../../../includes/tlasharptla-winvista-md.md)].  [!INCLUDE[TLA2#tla_xps](../../../../includes/tla2sharptla-xps-md.md)] documents can be sent directly to [!INCLUDE[TLA2#tla_xps](../../../../includes/tla2sharptla-xps-md.md)]-compatible printers without the need for conversion to an intermediate format.  See the [Printing Overview](../../../../docs/framework/wpf/advanced/printing-overview.md) for additional information on print path output options and capabilities.  
  
<a name="PluginSerializers"></a>   
## Plug-in Serializers  
 The <xref:System.Windows.Documents.Serialization> APIs provide support for both plug-in serializers and linked serializers that are installed separately from the application, bind at run time, and are accessed by using the <xref:System.Windows.Documents.Serialization.SerializerProvider> discovery mechanism.  Plug-in serializers offer enhanced benefits for ease of deployment and system-wide use.  Linked serializers can also be implemented for partial trust environments such as [!INCLUDE[TLA#tla_xbap#plural](../../../../includes/tlasharptla-xbapsharpplural-md.md)] where plug-in serializers are not accessible.  Linked serializers, which are based on a derived implementation of the <xref:System.Windows.Documents.Serialization.SerializerWriter> class, are compiled and linked directly into the application.  Both plug-in serializers and linked serializers operate through identical public methods and events which make it easy to use either or both types of serializers in the same application.  
  
 Plug-in serializers aid application developers by providing extensibility to new storage designs and file formats without having to code directly for every potential format at build time.  Plug-in serializers also benefit third-party developers by providing a standardized means to deploy, install, and update system accessible plug-ins for custom or proprietary file formats.  
  
### Using a Plug-in Serializer  
 Plug-in serializers are simple to use.  The <xref:System.Windows.Documents.Serialization.SerializerProvider> class enumerates a <xref:System.Windows.Documents.Serialization.SerializerDescriptor> object for each plug-in installed on the system.  The <xref:System.Windows.Documents.Serialization.SerializerDescriptor.IsLoadable%2A> property filters the installed plug-ins based on the current configuration and verifies that the serializer can be loaded and used by the application.  The <xref:System.Windows.Documents.Serialization.SerializerDescriptor> also provides other properties, such as <xref:System.Windows.Documents.Serialization.SerializerDescriptor.DisplayName%2A> and <xref:System.Windows.Documents.Serialization.SerializerDescriptor.DefaultFileExtension%2A>, which the application can use to prompt the user in selecting a serializer for an available output format.  A default plug-in serializer for [!INCLUDE[TLA2#tla_xps](../../../../includes/tla2sharptla-xps-md.md)] is provided with [!INCLUDE[TLA2#tla_winfx](../../../../includes/tla2sharptla-winfx-md.md)] and is always enumerated.  After the user selects an output format, the <xref:System.Windows.Documents.Serialization.SerializerProvider.CreateSerializerWriter%2A> method is used to create a <xref:System.Windows.Documents.Serialization.SerializerWriter> for the specific format.  The <xref:System.Windows.Documents.Serialization.SerializerWriter>.<xref:System.Windows.Documents.Serialization.SerializerWriter.Write%2A> method can then be called to output the document stream to the data store.  
  
 The following example illustrates an application that uses the <xref:System.Windows.Documents.Serialization.SerializerProvider> method in a "PlugInFileFilter" property.  PlugInFileFilter enumerates the installed plug-ins and builds a filter string with the available file options for a <xref:Microsoft.Win32.SaveFileDialog>.  
  
 [!code-csharp[DocumentSerialize#DocSerializeFileFilter](../../../../samples/snippets/csharp/VS_Snippets_Wpf/DocumentSerialize/CSharp/ThumbViewer.cs#docserializefilefilter)]  
  
 After an output file name has been selected by the user, the following example illustrates use of the <xref:System.Windows.Documents.Serialization.SerializerProvider.CreateSerializerWriter%2A> method to store a given document in a specified format.  
  
 [!code-csharp[DocumentSerialize#DocSerializePlugIn](../../../../samples/snippets/csharp/VS_Snippets_Wpf/DocumentSerialize/CSharp/ThumbViewer.cs#docserializeplugin)]  
  
<a name="InstallingPluginSerializers"></a>   
### Installing Plug-in Serializers  
 The <xref:System.Windows.Documents.Serialization.SerializerProvider> class supplies the upper-level application interface for plug-in serializer discovery and access.  <xref:System.Windows.Documents.Serialization.SerializerProvider> locates and provides the application a list of the serializers that are installed and accessible on the system.  The specifics of the installed serializers are defined through registry settings.  Plug-in serializers can be added to the registry by using the <xref:System.Windows.Documents.Serialization.SerializerProvider.RegisterSerializer%2A> method; or if [!INCLUDE[TLA2#tla_winfx](../../../../includes/tla2sharptla-winfx-md.md)] is not yet installed, the plug-in installation script can directly set the registry values itself.  The <xref:System.Windows.Documents.Serialization.SerializerProvider.UnregisterSerializer%2A> method can be used to remove a previously installed plug-in, or the registry settings can be reset similarly by an uninstall script.  
  
### Creating a Plug-in Serializer  
 Both plug-in serializers and linked serializers use the same exposed public methods and events, and similarly can be designed to operate either synchronously or asynchronously.  There are three basic steps normally followed to create a plug-in serializer:  
  
1.  Implement and debug the serializer first as a linked serializer.  Initially creating the serializer compiled and linked directly in a test application provides full access to breakpoints and other debug services helpful for testing.  
  
2.  After the serializer is fully tested, an <xref:System.Windows.Documents.Serialization.ISerializerFactory> interface is added to create a plug-in.  The <xref:System.Windows.Documents.Serialization.ISerializerFactory> interface permits full access to all [!INCLUDE[TLA2#tla_winfx](../../../../includes/tla2sharptla-winfx-md.md)] objects which includes the logical tree, <xref:System.Windows.UIElement> objects, <xref:System.Windows.Documents.IDocumentPaginatorSource>, and <xref:System.Windows.Media.Visual> elements.  Additionally <xref:System.Windows.Documents.Serialization.ISerializerFactory> provides the same synchronous and asynchronous methods and events used by linked serializers.  Since large documents can take time to output, asynchronous operations are recommended to maintain responsive user interaction and offer a "Cancel" option if some problem occurs with the data store.  
  
3.  After the plug-in serializer is created, an installation script is implemented for distributing and installing (and uninstalling) the plug-in (see above, "[Installing Plug-in Serializers](#InstallingPluginSerializers)").  
  
## See Also  
 <xref:System.Windows.Documents.Serialization>  
 <xref:System.Windows.Xps.XpsDocumentWriter>  
 <xref:System.Windows.Xps.Packaging.XpsDocument>  
 [Documents in WPF](../../../../docs/framework/wpf/advanced/documents-in-wpf.md)  
 [Printing Overview](../../../../docs/framework/wpf/advanced/printing-overview.md)  
 [XML Paper Specification: Overview](http://go.microsoft.com/fwlink?LinkID=106246)
