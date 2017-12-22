---
title: "Documents in WPF"
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
  - "documents [WPF], packaging"
  - "documents [WPF], text layout"
  - "documents [WPF], XPS"
  - "XPS documents [WPF], , "
  - "documents [WPF], controls"
  - "documents [WPF], types of"
  - "documents [WPF], browser-viewable"
ms.assetid: 6e8db7bc-050a-4070-aa72-bb8c46e87ff8
caps.latest.revision: 36
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Documents in WPF
[!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] offers a wide range of document features that enable the creation of high-fidelity content that is designed to be more easily accessed and read than in previous generations of [!INCLUDE[TLA#tla_mswin](../../../../includes/tlasharptla-mswin-md.md)]. In addition to enhanced capabilities and quality, [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] also provides integrated services for document display, packaging, and security. This topic provides an introduction to [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] document types and document packaging.  
  
  
<a name="types_of_documents"></a>   
## Types of Documents  
 [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] divides documents into two broad categories based on their intended use; these document categories are termed "fixed documents" and "flow documents."  
  
 Fixed documents are intended for applications that require a precise [!INCLUDE[TLA#tla_wys](../../../../includes/tlasharptla-wys-md.md)] presentation, independent of the display or printer hardware used. Typical uses for fixed documents include desktop publishing, word processing, and form layout, where adherence to the original page design is critical. As part of its layout, a fixed document maintains the precise positional placement of content elements independent of the display or print device in use. For example, a fixed document page viewed on 96 dpi display will appear exactly the same when it is output to a 600 dpi laser printer as when it is output to a 4800 dpi phototypesetter. The page layout remains the same in all cases, while the document quality maximizes to the capabilities of each device.  
  
 By comparison, flow documents are designed to optimize viewing and readability and are best utilized when ease of reading is the primary document consumption scenario. Rather than being set to one predefined layout, flow documents dynamically adjust and reflow their content based on run-time variables such as window size, device resolution, and optional user preferences. A Web page is a simple example of a flow document where the page content is dynamically formatted to fit the current window. Flow documents optimize the viewing and reading experience for the user, based on the runtime environment. For example, the same flow document will dynamically reformat for optimal readability on either high-resolution 19-inch display or a small 2x3-inch PDA screen. In addition, flow documents have a number of built in features including search, viewing modes that optimize readability, and the ability to change the size and appearance of fonts.  See [Flow Document Overview](../../../../docs/framework/wpf/advanced/flow-document-overview.md) for illustrations, examples, and in-depth information on flow documents.  
  
<a name="document_viewer"></a>   
## Document Controls and Text Layout  
 The [!INCLUDE[TLA2#tla_avalonwinfx](../../../../includes/tla2sharptla-avalonwinfx-md.md)] provides a set of pre-built controls that simplify using fixed documents, flow documents, and general text within your application.  The display of fixed document content is supported using the <xref:System.Windows.Controls.DocumentViewer> control.  Display of flow document content is supported by three different controls: <xref:System.Windows.Controls.FlowDocumentReader>, <xref:System.Windows.Controls.FlowDocumentPageViewer>, and <xref:System.Windows.Controls.FlowDocumentScrollViewer> which map to different user scenarios (see sections below).  Other [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] controls provide simplified layout to support general text uses (see [Text in the User Interface](#text_in_the_user_interface), below).  
  
### Fixed Document Control - DocumentViewer  
 The <xref:System.Windows.Controls.DocumentViewer> control is designed to display <xref:System.Windows.Documents.FixedDocument> content. The <xref:System.Windows.Controls.DocumentViewer> control provides an intuitive user interface that provides built-in support for common operations including print output, copy to clipboard, zoom, and text search features. The control provides access to pages of content through a familiar scrolling mechanism. Like all [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] controls, <xref:System.Windows.Controls.DocumentViewer> supports complete or partial restyling, which enables the control to be visually integrated into virtually any application or environment.  
  
 <xref:System.Windows.Controls.DocumentViewer> is designed to display content in a read-only manner; editing or modification of content is not available and is not supported.  
  
<a name="flow_document"></a>   
### Flow Document Controls  
 **Note:** For more detailed information on flow document features and how to create them, see [Flow Document Overview](../../../../docs/framework/wpf/advanced/flow-document-overview.md).  
  
 Display of flow document content is supported by three controls: <xref:System.Windows.Controls.FlowDocumentReader>, <xref:System.Windows.Controls.FlowDocumentPageViewer>, and <xref:System.Windows.Controls.FlowDocumentScrollViewer>.  
  
#### FlowDocumentReader  
 <xref:System.Windows.Controls.FlowDocumentReader> includes features that enable the user to dynamically choose between various viewing modes, including a single-page (page-at-a-time) viewing mode, a two-page-at-a-time (book reading format) viewing mode, and a continuous scrolling (bottomless) viewing mode.  For more information about these viewing modes, see <xref:System.Windows.Controls.FlowDocumentReaderViewingMode>.  If you do not need the ability to dynamically switch between different viewing modes, <xref:System.Windows.Controls.FlowDocumentPageViewer> and <xref:System.Windows.Controls.FlowDocumentScrollViewer> provide lighter-weight flow content viewers that are fixed in a particular viewing mode.  
  
#### FlowDocumentPageViewer and FlowDocumentScrollViewer  
 <xref:System.Windows.Controls.FlowDocumentPageViewer> shows content in page-at-a-time viewing mode, while <xref:System.Windows.Controls.FlowDocumentScrollViewer> shows content in continuous scrolling mode.  Both <xref:System.Windows.Controls.FlowDocumentPageViewer> and <xref:System.Windows.Controls.FlowDocumentScrollViewer> are fixed to a particular viewing mode. Compare to <xref:System.Windows.Controls.FlowDocumentReader>, which includes features that enable the user to dynamically choose between various viewing modes (as provided by the <xref:System.Windows.Controls.FlowDocumentReaderViewingMode> enumeration), at the cost of being more resource intensive than <xref:System.Windows.Controls.FlowDocumentPageViewer> or <xref:System.Windows.Controls.FlowDocumentScrollViewer>.  
  
 By default, a vertical scrollbar is always shown, and a horizontal scrollbar becomes visible if needed. The default [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)] for <xref:System.Windows.Controls.FlowDocumentScrollViewer> does not include a toolbar; however, the <xref:System.Windows.Controls.FlowDocumentScrollViewer.IsToolBarVisible%2A> property can be used to enable a built-in toolbar.  
  
<a name="text_in_the_user_interface"></a>   
### Text in the User Interface  
 Besides adding text to documents, text can obviously be used in application UI such as forms. [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] includes multiple controls for drawing text to the screen. Each control is targeted to a different scenario and has its own list of features and limitations. In general, the <xref:System.Windows.Controls.TextBlock> element should be used when limited text support is required, such as a brief sentence in a [!INCLUDE[TLA#tla_ui](../../../../includes/tlasharptla-ui-md.md)]. <xref:System.Windows.Controls.Label> can be used when minimal text support is required. For more information, see [TextBlock Overview](../../../../docs/framework/wpf/controls/textblock-overview.md).  
  
<a name="packaging"></a>   
## Document Packaging  
 The <xref:System.IO.Packaging> [!INCLUDE[TLA2#tla_api#plural](../../../../includes/tla2sharptla-apisharpplural-md.md)] provide an efficient means to organize application data, document content, and related resources in a single container that is simple to access, portable, and easy to distribute. A ZIP file is an example of a <xref:System.IO.Packaging.Package> type capable of holding multiple objects as a single unit. The packaging [!INCLUDE[TLA2#tla_api#plural](../../../../includes/tla2sharptla-apisharpplural-md.md)] provide a default <xref:System.IO.Packaging.ZipPackage> implementation designed using an Open Packaging Conventions standard with XML and ZIP file architecture. The [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] packaging [!INCLUDE[TLA2#tla_api#plural](../../../../includes/tla2sharptla-apisharpplural-md.md)] make it simple to create packages, and to store and access objects within them. An object stored in a <xref:System.IO.Packaging.Package> is referred to as a <xref:System.IO.Packaging.PackagePart> ("part"). Packages can also include signed digital certificates that can be used to identify the originator of a part and to validate that the contents of a package have not been modified.  Packages also include a <xref:System.IO.Packaging.PackageRelationship> feature that allows additional information to be added to a package or associated with specific parts without actually modifying the content of existing parts.  Package services also support [!INCLUDE[TLA#tla_rm](../../../../includes/tlasharptla-rm-md.md)].  
  
 The [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] Package architecture serves as the foundation for a number of key technologies:  
  
-   [!INCLUDE[TLA2#tla_xps](../../../../includes/tla2sharptla-xps-md.md)] documents conforming to the [!INCLUDE[TLA#tla_xps](../../../../includes/tlasharptla-xps-md.md)].  
  
-   Microsoft Office "12" open XML format documents (.docx).  
  
-   Custom storage formats for your own application design.  
  
 Based on the packaging APIs, an <xref:System.Windows.Xps.Packaging.XpsDocument> is specifically designed for storing [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] fixed content documents. An <xref:System.Windows.Xps.Packaging.XpsDocument> is a self-contained document that can be opened in a viewer, displayed in a <xref:System.Windows.Controls.DocumentViewer> control, routed to a print spool, or output directly to an [!INCLUDE[TLA2#tla_xps](../../../../includes/tla2sharptla-xps-md.md)]-compatible printer.  
  
 The following sections provide additional information on the <xref:System.IO.Packaging.Package> and <xref:System.Windows.Xps.Packaging.XpsDocument> [!INCLUDE[TLA2#tla_api#plural](../../../../includes/tla2sharptla-apisharpplural-md.md)] provided with [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)].  
  
<a name="packages"></a>   
### Package Components  
 The [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] packaging APIs allow application data and documents to be organized into a single portable unit. A ZIP file is one of the most common types of packages and is the default package type provided with [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)].  <xref:System.IO.Packaging.Package> itself is an abstract class from which <xref:System.IO.Packaging.ZipPackage> is implemented using an open standard XML and ZIP file architecture.  The <xref:System.IO.Packaging.Package.Open%2A> method uses <xref:System.IO.Packaging.ZipPackage> to create and use ZIP files by default. A package can contain three basic types of items:  
  
|||  
|-|-|  
|<xref:System.IO.Packaging.PackagePart>|Application content, data, documents, and resource files.|  
|<xref:System.IO.Packaging.PackageDigitalSignature>|[X.509 Certificate] for identification, authentication and validation.|  
|<xref:System.IO.Packaging.PackageRelationship>|Added information related to the package or a specific part.|  
  
<a name="PackageParts"></a>   
#### PackageParts  
 A <xref:System.IO.Packaging.PackagePart> ("part") is an abstract class that refers to an object stored in a <xref:System.IO.Packaging.Package>. In a ZIP file, the package parts correspond to the individual files stored within the ZIP file.  <xref:System.IO.Packaging.ZipPackagePart> provides the default implementation for serializable objects stored in a <xref:System.IO.Packaging.ZipPackage>.  Like a file system, parts contained in the package are stored in hierarchical directory or "folder-style" organization.  Using the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] packaging APIs, applications can write, store, and read multiple <xref:System.IO.Packaging.PackagePart> objects using a single ZIP file container.  
  
<a name="PackageDigitalSignatures"></a>   
#### PackageDigitalSignatures  
 For security, a <xref:System.IO.Packaging.PackageDigitalSignature> ("digital signature") can be associated with parts within a package. A <xref:System.IO.Packaging.PackageDigitalSignature> incorporates a [509] that provides two features:  
  
1.  Identifies and authenticates the originator of the part.  
  
2.  Validates that the part has not been modified.  
  
 The digital signature does not preclude a part from being modified, but a validation check against the digital signature will fail if the part is altered in any way. The application can then take appropriate action—for example, block opening the part or notify the user that the part has been modified and is not secure.  
  
<a name="PackageRelationships"></a>   
#### PackageRelationships  
 A <xref:System.IO.Packaging.PackageRelationship> ("relationship") provides a mechanism for associating additional information with the package or a part within the package. A relationship is a package-level facility that can associate additional information with a part without modifying the actual part content. Inserting new data directly into the part content of is usually not practical in many cases:  
  
-   The actual type of the part and its content schema is not known.  
  
-   Even if known, the content schema might not provide a means for adding new information.  
  
-   The part might be digitally signed or encrypted, precluding any modification.  
  
 Package relationships provide a discoverable means for adding and associating additional information with individual parts or with the entire package. Package relationships are used for two primary functions:  
  
1.  Defining dependency relationships from one part to another part.  
  
2.  Defining information relationships that add notes or other data related to the part.  
  
 A <xref:System.IO.Packaging.PackageRelationship> provides a quick, discoverable means to define dependencies and add other information associated with a part of the package or the package as a whole.  
  
<a name="Dependency_Relationships"></a>   
##### Dependency Relationships  
 Dependency relationships are used to describe dependencies that one part makes to other parts. For example, a package might contain an HTML part that includes one or more \<img> image tags. The image tags refer to images that are located either as other parts internal to the package or external to the package (such as accessible over the Internet). Creating a <xref:System.IO.Packaging.PackageRelationship> associated with HTML file makes discovering and accessing the dependent resources quick and easy. A browser or viewer application can directly access the part relationships and immediately begin assembling the dependent resources without knowing the schema or parsing the document.  
  
<a name="Information_Relationships"></a>   
##### Information Relationships  
 Similar to a note or annotation, a <xref:System.IO.Packaging.PackageRelationship> can also be used to store other types of information to be associated with a part without having to actually modify the part content itself.  
  
<a name="XPS_Documents"></a>   
## XPS Documents  
 [!INCLUDE[TLA#tla_xps](../../../../includes/tlasharptla-xps-md.md)] document is a package that contains one or more fixed-documents along with all the resources and information required for rendering.  [!INCLUDE[TLA2#tla_xps](../../../../includes/tla2sharptla-xps-md.md)] is also the native [!INCLUDE[TLA#tla_winvista](../../../../includes/tlasharptla-winvista-md.md)] print spool file format.  An <xref:System.Windows.Xps.Packaging.XpsDocument> is stored in standard ZIP dataset, and can include a combination of XML and binary components, such as image and font files. [PackageRelationships](#PackageRelationships) are used to define the dependencies between the content and the resources required to fully render the document.  The <xref:System.Windows.Xps.Packaging.XpsDocument> design provides a single, high-fidelity document solution that supports multiple uses:  
  
-   Reading, writing, and storing fixed-document content and resources as a single, portable, and easy-to-distribute file.  
  
-   Displaying documents with the [!INCLUDE[TLA2#tla_xps](../../../../includes/tla2sharptla-xps-md.md)] Viewer application.  
  
-   Outputting documents in the native print spool output format of [!INCLUDE[TLA#tla_winvista](../../../../includes/tlasharptla-winvista-md.md)].  
  
-   Routing documents directly to an [!INCLUDE[TLA2#tla_xps](../../../../includes/tla2sharptla-xps-md.md)]-compatible printer.  
  
## See Also  
 <xref:System.Windows.Documents.FixedDocument>  
 <xref:System.Windows.Documents.FlowDocument>  
 <xref:System.Windows.Xps.Packaging.XpsDocument>  
 <xref:System.IO.Packaging.ZipPackage>  
 <xref:System.IO.Packaging.ZipPackagePart>  
 <xref:System.IO.Packaging.PackageRelationship>  
 <xref:System.Windows.Controls.DocumentViewer>  
 [Text](../../../../docs/framework/wpf/advanced/optimizing-performance-text.md)  
 [Flow Document Overview](../../../../docs/framework/wpf/advanced/flow-document-overview.md)  
 [Printing Overview](../../../../docs/framework/wpf/advanced/printing-overview.md)  
 [Document Serialization and Storage](../../../../docs/framework/wpf/advanced/document-serialization-and-storage.md)
