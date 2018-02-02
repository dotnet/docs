---
title: "Printing Overview"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "print path [WPF], XPS"
  - "printers [WPF], XPSDrv-based"
  - "printing [WPF]"
  - "PrintQueue class PrintServer class [WPF]"
  - "XML Paper Specification (XPS) file format"
  - "XPS (XML Paper Specification) file format"
  - "XPSDrv-based printers"
  - "GDI print path [WPF]"
ms.assetid: 0de8ac41-9aa6-413d-a121-7aa6f41539b1
caps.latest.revision: 35
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Printing Overview
With [!INCLUDE[TLA#tla_winfx](../../../../includes/tlasharptla-winfx-md.md)], application developers using [!INCLUDE[TLA#tla_wpf](../../../../includes/tlasharptla-wpf-md.md)] have a rich new set of printing and print system management [!INCLUDE[TLA#tla_api#plural](../../../../includes/tlasharptla-apisharpplural-md.md)]. With [!INCLUDE[TLA#tla_winvista](../../../../includes/tlasharptla-winvista-md.md)], some of these print system enhancements are also available to developers creating [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] applications and developers using unmanaged code. At the core of this new functionality is the new [!INCLUDE[TLA#tla_xps](../../../../includes/tlasharptla-xps-md.md)] file format and the [!INCLUDE[TLA2#tla_xps](../../../../includes/tla2sharptla-xps-md.md)] print path.  
  
 This topic contains the following sections.  
  
<a name="introduction_to_XPS"></a>   
## About XPS  
 [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] is an electronic document format, a spool file format and a page description language. It is an open document format that uses [!INCLUDE[TLA#tla_xml](../../../../includes/tlasharptla-xml-md.md)], [!INCLUDE[TLA#tla_opc](../../../../includes/tlasharptla-opc-md.md)], and other industry standards to create cross-platform documents. [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] simplifies the process by which digital documents are created, shared, printed, viewed, and archived. For additional information on [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)], see the [XPS Web Site](http://www.microsoft.com/xps).  
  
 Several techniques for printing [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] based content using [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] are demonstrated in [Programmatically Print XPS Files](../../../../docs/framework/wpf/advanced/how-to-programmatically-print-xps-files.md). You may find it useful to reference these samples during review of content contained in this topic. (Unmanaged code developers should see documentation for the [MXDC_ESCAPE function](https://msdn.microsoft.com/library/windows/desktop/dd162739.aspx). [!INCLUDE[TLA2#tla_winforms#initcap](../../../../includes/tla2sharptla-winformssharpinitcap-md.md)] developers must use the [!INCLUDE[TLA2#tla_api](../../../../includes/tla2sharptla-api-md.md)] in the <xref:System.Drawing.Printing> namespace which does not support the full [!INCLUDE[TLA2#tla_xps](../../../../includes/tla2sharptla-xps-md.md)] print path, but does support a hybrid GDI-to-XPS print path. See **Print Path Architecture** below.)  
  
<a name="XPS_print_path_intro"></a>   
## XPS Print Path  
 The [!INCLUDE[TLA#tla_metro](../../../../includes/tlasharptla-metro-md.md)] print path is a new [!INCLUDE[TLA#tla_mswin](../../../../includes/tlasharptla-mswin-md.md)] feature that redefines how printing is handled in [!INCLUDE[TLA2#tla_mswin](../../../../includes/tla2sharptla-mswin-md.md)] applications. Because [!INCLUDE[TLA2#tla_xps](../../../../includes/tla2sharptla-xps-md.md)] can replace a document presentation language (such as RTF), a print spooler format (such as WMF), and a page description language (such as PCL or Postscript); the new print path maintains the [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] format from application publication to the final processing in the print driver or device.  
  
 The [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] print path is built upon the [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] printer driver model (XPSDrv), which provides several benefits for developers such as [!INCLUDE[TLA#tla_wys](../../../../includes/tlasharptla-wys-md.md)] printing, improved color support, and significantly improved print performance. (For more on XPSDrv, see the [Windows Driver Development Kit](https://msdn.microsoft.com/library/windows/hardware/ff557573.aspx).)  
  
 The operation of the print spooler for [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] documents is essentially the same as in previous versions of [!INCLUDE[TLA2#tla_mswin](../../../../includes/tla2sharptla-mswin-md.md)]. However, it has been enhanced to support the [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] print path in addition to the existing [!INCLUDE[TLA2#tla_gdi](../../../../includes/tla2sharptla-gdi-md.md)] print path. The new print path natively consumes an [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] spool file. While user-mode printer drivers written for previous versions of [!INCLUDE[TLA#tla_mswin](../../../../includes/tlasharptla-mswin-md.md)] will continue to work, an [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] printer driver (XPSDrv) is required in order to use the [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] print path.  
  
 The benefits of the [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] print path are significant, and include:  
  
-   [!INCLUDE[TLA2#tla_wys](../../../../includes/tla2sharptla-wys-md.md)] print support  
  
-   Native support of advanced color profiles, which include 32 bits per channel (bpc), CMYK, named-colors, n-inks, and native support of transparency and gradients.  
  
-   Improved print performance for both [!INCLUDE[TLA2#tla_winfx](../../../../includes/tla2sharptla-winfx-md.md)] and [!INCLUDE[TLA#tla_win32](../../../../includes/tlasharptla-win32-md.md)] based applications.  
  
-   Industry standard [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] format.  
  
 For basic print scenarios, a simple and intuitive [!INCLUDE[TLA2#tla_api](../../../../includes/tla2sharptla-api-md.md)] is available with a single entry point for user interface, configuration and job submission. For advanced scenarios, an additional support is added for [!INCLUDE[TLA#tla_ui](../../../../includes/tlasharptla-ui-md.md)] customization (or no [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)] at all), synchronous or asynchronous printing, and batch printing capabilities. Both options provide print support in full or partial trust mode.  
  
 [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] was designed with extensibility in mind. By using the extensibility framework, features and capabilities can be added to [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] in a modular manner. Extensibility features include:  
  
-   Print Schema. The public schema is updated regularly and enables rapid extension of device capabilities. (See **PrintTicket and PrintCapabilities** below.)  
  
-   Extensible Filter Pipeline. The [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] printer driver (XPSDrv) filter pipeline was designed to enable both direct and scalable printing of [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] documents. (Lookup "XPSDrv" in the [Windows Driver Kit](https://msdn.microsoft.com/library/windows/hardware/ff557573.aspx).)  
  
### Print Path Architecture  
 While both [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] and [!INCLUDE[TLA2#tla_winfx](../../../../includes/tla2sharptla-winfx-md.md)] applications support [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)], [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] and [!INCLUDE[TLA2#tla_winforms](../../../../includes/tla2sharptla-winforms-md.md)] applications use a [!INCLUDE[TLA2#tla_gdi](../../../../includes/tla2sharptla-gdi-md.md)] to [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] conversion in order to create [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] formatted content for the [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] printer driver (XPSDrv). These applications are not required to use the [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] print path, and can continue to use [!INCLUDE[TLA#tla_emf](../../../../includes/tlasharptla-emf-md.md)] based printing. However, most [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] features and enhancements are only available to applications that target the [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] print path.  
  
 To enable the use of XPSDrv-based printers by [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] and [!INCLUDE[TLA2#tla_winforms](../../../../includes/tla2sharptla-winforms-md.md)] applications, the [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] printer driver (XPSDrv) supports conversion of [!INCLUDE[TLA2#tla_gdi](../../../../includes/tla2sharptla-gdi-md.md)] to [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] format. The XPSDrv model also provides a converter for [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] to [!INCLUDE[TLA2#tla_gdi](../../../../includes/tla2sharptla-gdi-md.md)] format so that [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] applications can print [!INCLUDE[TLA2#tla_xps](../../../../includes/tla2sharptla-xps-md.md)] Documents. For [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] applications, conversion of [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] to [!INCLUDE[TLA2#tla_gdi](../../../../includes/tla2sharptla-gdi-md.md)] format is done automatically by the <xref:System.Windows.Xps.XpsDocumentWriter.Write%2A> and <xref:System.Windows.Xps.XpsDocumentWriter.WriteAsync%2A> methods of the <xref:System.Windows.Xps.XpsDocumentWriter> class whenever the target print queue of the write operation does not have an XPSDrv driver. ([!INCLUDE[TLA2#tla_winforms#initcap](../../../../includes/tla2sharptla-winformssharpinitcap-md.md)] applications cannot print [!INCLUDE[TLA2#tla_xps](../../../../includes/tla2sharptla-xps-md.md)] Documents.)  
  
 The following illustration depicts the print subsystem and defines the portions provided by [!INCLUDE[TLA#tla_ms](../../../../includes/tlasharptla-ms-md.md)], and the portions defined by software and hardware vendors.  
  
 ![The XPS Print System](../../../../docs/framework/wpf/advanced/media/xpsprint.PNG "XPSPrint")  
  
### Basic XPS Printing  
 [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] defines both a basic and advanced [!INCLUDE[TLA#tla_api](../../../../includes/tlasharptla-api-md.md)]. For those applications that do not require extensive print customization or access to the complete [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] feature set, basic print support is available. Basic print support is exposed through a print dialog control that requires minimal configuration and features a familiar [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)]. Many [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] features are available using this simplified print model.  
  
#### PrintDialog  
 The <xref:System.Windows.Controls.PrintDialog?displayProperty=nameWithType> control provides a single entry point for [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)], configuration, and [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] job submission. For information about how to instantiate and use the control, see [Invoke a Print Dialog](../../../../docs/framework/wpf/advanced/how-to-invoke-a-print-dialog.md).  
  
### Advanced XPS Printing  
 To access the complete set of [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] features, the advanced print [!INCLUDE[TLA2#tla_api](../../../../includes/tla2sharptla-api-md.md)] must be used. Several relevant [!INCLUDE[TLA2#tla_api](../../../../includes/tla2sharptla-api-md.md)] are described in greater detail below. For a complete list of [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] print path [!INCLUDE[TLA2#tla_api#plural](../../../../includes/tla2sharptla-apisharpplural-md.md)], see the <xref:System.Windows.Xps> and <xref:System.Printing> namespace references.  
  
#### PrintTicket and PrintCapabilities  
 The <xref:System.Printing.PrintTicket> and <xref:System.Printing.PrintCapabilities> classes are the foundation of the advanced [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] features. Both types of objects are [!INCLUDE[TLA#tla_xml](../../../../includes/tlasharptla-xml-md.md)] formatted structures of print-oriented features such as collation, two-sided printing, stapling, etc. These structures are defined by the print schema. A <xref:System.Printing.PrintTicket> instructs a printer how to process a print job. The <xref:System.Printing.PrintCapabilities> class defines the capabilities of a printer. By querying the capabilities of a printer, a <xref:System.Printing.PrintTicket> can be created that takes full advantage of a printer's supported features. Similarly, unsupported features can be avoided.  
  
 The following example demonstrates how to query the <xref:System.Printing.PrintCapabilities> of a printer and create a <xref:System.Printing.PrintTicket> using code.  
  
 [!code-cpp[xpscreate#PrinterCapabilities](../../../../samples/snippets/cpp/VS_Snippets_Wpf/XpsCreate/CPP/XpsCreate.cpp#printercapabilities)]
 [!code-csharp[xpscreate#PrinterCapabilities](../../../../samples/snippets/csharp/VS_Snippets_Wpf/XpsCreate/CSharp/XpsCreate.cs#printercapabilities)]
 [!code-vb[xpscreate#PrinterCapabilities](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/XpsCreate/visualbasic/xpscreate.vb#printercapabilities)]  
  
#### PrintServer and PrintQueue  
 The <xref:System.Printing.PrintServer> class represents a network print server and the <xref:System.Printing.PrintQueue> class represents a printer and the output job queue associated with it. Together, these [!INCLUDE[TLA2#tla_api#plural](../../../../includes/tla2sharptla-apisharpplural-md.md)] allow advanced management of a server's print jobs. A <xref:System.Printing.PrintServer>, or one of its derived classes, is used to manage a <xref:System.Printing.PrintQueue>. The <xref:System.Printing.PrintQueue.AddJob%2A> method is used to insert a new print job into the queue.  
  
 The following example demonstrates how to create a <xref:System.Printing.LocalPrintServer> and access its default <xref:System.Printing.PrintQueue> by using code.  
  
 [!code-csharp[xpsprint#PrintQueueSnip](../../../../samples/snippets/csharp/VS_Snippets_Wpf/XpsPrint/CSharp/XpsPrintHelper.cs#printqueuesnip)]
 [!code-vb[xpsprint#PrintQueueSnip](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/XpsPrint/visualbasic/xpsprinthelper.vb#printqueuesnip)]  
  
#### XpsDocumentWriter  
 An <xref:System.Windows.Xps.XpsDocumentWriter>, with its many the <xref:System.Windows.Xps.XpsDocumentWriter.Write%2A> and <xref:System.Windows.Xps.XpsDocumentWriter.WriteAsync%2A> methods, is used to write [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] documents to a <xref:System.Printing.PrintQueue>. For example, the <xref:System.Windows.Xps.XpsDocumentWriter.Write%28System.Windows.Documents.FixedPage%2CSystem.Printing.PrintTicket%29> method is used to output an [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] document and <xref:System.Printing.PrintTicket> synchronously. The <xref:System.Windows.Xps.XpsDocumentWriter.WriteAsync%28System.Windows.Documents.FixedDocument%2CSystem.Printing.PrintTicket%29> method is used to output an [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] document and <xref:System.Printing.PrintTicket> asynchronously.  
  
 The following example demonstrates how to create an <xref:System.Windows.Xps.XpsDocumentWriter> using code.  
  
 [!code-csharp[XpsPrint#PrintQueueSnip](../../../../samples/snippets/csharp/VS_Snippets_Wpf/XpsPrint/CSharp/XpsPrintHelper.cs#printqueuesnip)]
 [!code-vb[XpsPrint#PrintQueueSnip](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/XpsPrint/visualbasic/xpsprinthelper.vb#printqueuesnip)]  
  
 The <xref:System.Printing.PrintQueue.AddJob%2A> methods also provide ways to print. See [Programmatically Print XPS Files](../../../../docs/framework/wpf/advanced/how-to-programmatically-print-xps-files.md). for details.  
  
<a name="GDI_Print_Path_intro"></a>   
## GDI Print Path  
 While [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] applications natively support the [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] print path, [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] and [!INCLUDE[TLA2#tla_winforms](../../../../includes/tla2sharptla-winforms-md.md)] applications can also take advantage of some [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] features. The [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] printer driver (XPSDrv) can convert [!INCLUDE[TLA2#tla_gdi](../../../../includes/tla2sharptla-gdi-md.md)] based output to [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] format. For advanced scenarios, custom conversion of content is supported using the [Microsoft XPS Document Converter (MXDC)](https://msdn.microsoft.com/library/windows/desktop/ff686803.aspx). Similarly, [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] applications can also output to the [!INCLUDE[TLA2#tla_gdi](../../../../includes/tla2sharptla-gdi-md.md)] print path by calling one of the <xref:System.Windows.Xps.XpsDocumentWriter.Write%2A> or <xref:System.Windows.Xps.XpsDocumentWriter.WriteAsync%2A> methods of the <xref:System.Windows.Xps.XpsDocumentWriter> class and designating a non-XpsDrv printer as the target print queue.  

For applications that do not require [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] functionality or support, the current [!INCLUDE[TLA2#tla_gdi](../../../../includes/tla2sharptla-gdi-md.md)] print path remains unchanged.  
  
-   For additional reference material on the [!INCLUDE[TLA2#tla_gdi](../../../../includes/tla2sharptla-gdi-md.md)] print path and the various [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] conversion options, see [Microsoft XPS Document Converter (MXDC)](https://msdn.microsoft.com/library/windows/desktop/ff686803.aspx) and "XPSDrv" in the [Windows Driver Kit](https://msdn.microsoft.com/library/windows/hardware/ff557573.aspx).  
  
<a name="XPS_Driver_Model_intro"></a>   
## XPSDrv Driver Model  
 The [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] print path improves spooler efficiency by using [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] as the native print spool format when printing to an [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] -enabled printer or driver. The simplified spooling process eliminates the need to generate an intermediate spool file, such as an [!INCLUDE[TLA2#tla_emf](../../../../includes/tla2sharptla-emf-md.md)] data file, before the document is spooled. Through smaller spool file sizes, the [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] print path can reduce network traffic and improve print performance.  
  
 [!INCLUDE[TLA2#tla_emf](../../../../includes/tla2sharptla-emf-md.md)] is a closed format that represents application output as a series of calls into [!INCLUDE[TLA2#tla_gdi](../../../../includes/tla2sharptla-gdi-md.md)] for rendering services. Unlike [!INCLUDE[TLA2#tla_emf](../../../../includes/tla2sharptla-emf-md.md)], the [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] spool format represents the actual document without requiring further interpretation when output to an [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)]-based printer driver (XPSDrv). The drivers can operate directly on the data in the format. This capability eliminates the data and color space conversions required when you use [!INCLUDE[TLA2#tla_emf](../../../../includes/tla2sharptla-emf-md.md)] files and [!INCLUDE[TLA2#tla_gdi](../../../../includes/tla2sharptla-gdi-md.md)]-based print drivers.  
  
 Spool file sizes are usually reduced when you use [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] Documents that target an [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] printer driver (XPSDrv) compared with their [!INCLUDE[TLA2#tla_emf](../../../../includes/tla2sharptla-emf-md.md)] equivalents; however, there are exceptions:  
  
-   A vector graphic that is very complex, multi-layered, or inefficiently written can be larger than a bitmapped version of the same graphic.  
  
-   For screen display purposes, XPS files embed device fonts as well as computer-based fonts; whereas GDI spool files do not embed device fonts. But both kinds of fonts are subsetted (see below) and printer drivers can remove the device fonts before transmitting the file to the printer.  
  
 Spool size reduction is performed through several mechanisms:  
  
-   **Font subsetting**. Only characters used within the actual document are stored in the [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] file.  
  
-   **Advanced Graphics Support**. Native support for transparency and gradient primitives avoids rasterization of content in the [!INCLUDE[TLA2#tla_xps](../../../../includes/tla2sharptla-xps-md.md)] Document.  
  
-   **Identification of common resources**. Resources that are used multiple times (such as an image that represents a corporate logo) are treated as shared resources and are loaded only once.  
  
-   **ZIP compression**. All [!INCLUDE[TLA2#tla_metro](../../../../includes/tla2sharptla-metro-md.md)] documents use ZIP compression.  
  
## See Also  
 <xref:System.Windows.Controls.PrintDialog>  
 <xref:System.Windows.Xps.XpsDocumentWriter>  
 <xref:System.Windows.Xps.Packaging.XpsDocument>  
 <xref:System.Printing.PrintTicket>  
 <xref:System.Printing.PrintCapabilities>  
 <xref:System.Printing.PrintServer>  
 <xref:System.Printing.PrintQueue>  
 [How-to Topics](../../../../docs/framework/wpf/advanced/printing-how-to-topics.md)  
 [Documents in WPF](../../../../docs/framework/wpf/advanced/documents-in-wpf.md)  
 [XPS](http://www.microsoft.com/xps)  
 [Document Serialization and Storage](../../../../docs/framework/wpf/advanced/document-serialization-and-storage.md)  
 [Microsoft XPS Document Converter (MXDC)](https://msdn.microsoft.com/library/windows/desktop/ff686803.aspx)
