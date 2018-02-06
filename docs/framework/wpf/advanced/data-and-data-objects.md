---
title: "Data and Data Objects"
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
helpviewer_keywords: 
  - "data transfer [WPF], drag-and-drop"
  - "DataFormats class [WPF]"
  - "DataObject class [WPF]"
ms.assetid: 5967d557-1867-420f-a524-ae3af78402da
caps.latest.revision: 5
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Data and Data Objects
Data that is transferred as part of a drag-and-drop operation is stored in a data object.  Conceptually, a data object consists of one or more of the following pairs:  
  
-   An <xref:System.Object> that contains the actual data.  
  
-   A corresponding data format identifier.  
  
 The data itself can consist of anything that can be represented as a base <xref:System.Object>.  The corresponding data format is a string or <xref:System.Type> that provides a hint about what format the data is in.  Data objects support hosting multiple data/data format pairs; this enables a single data object to provide data in multiple formats.  
  
<a name="Data_and_Data_Objects"></a>   
## Data Objects  
 All data objects must implement the <xref:System.Windows.IDataObject> interface, which provides the following standard set of methods that enable and facilitate data transfer.  
  
|Method|Summary|  
|------------|-------------|  
|<xref:System.Windows.IDataObject.GetData%2A>|Retrieves a data object in a specified data format.|  
|<xref:System.Windows.IDataObject.GetDataPresent%2A>|Checks to see whether the data is available in, or can be converted to, a specified format.|  
|<xref:System.Windows.IDataObject.GetFormats%2A>|Returns a list of formats that the data in this data object is stored in, or can be converted to.|  
|<xref:System.Windows.IDataObject.SetData%2A>|Stores the specified data in this data object.|  
  
 [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] provides a basic implementation of <xref:System.Windows.IDataObject> in the <xref:System.Windows.DataObject> class. The stock <xref:System.Windows.DataObject> class is sufficient for many common data transfer scenarios.  
  
 There are several pre-defined formats, such as bitmap, CSV, file, HTML, RTF, string, text, and audio. For information about pre-defined data formats provided with [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)], see the <xref:System.Windows.DataFormats> class reference topic.  
  
 Data objects commonly include a facility for automatically converting data stored in one format to a different format while extracting data; this facility is referred to as auto-convert. When querying for the data formats available in a data object, auto-convertible data formats can be filtered from native data formats by calling the <xref:System.Windows.DataObject.GetFormats%28System.Boolean%29> or <xref:System.Windows.DataObject.GetDataPresent%28System.String%2CSystem.Boolean%29> method and specifying the `autoConvert` parameter as `false`.  When adding data to a data object with the <xref:System.Windows.DataObject.SetData%28System.String%2CSystem.Object%2CSystem.Boolean%29> method, auto-conversion of data can be prohibited by setting the `autoConvert` parameter to `false`.  
  
<a name="Working_with_Data_Objects"></a>   
## Working with Data Objects  
 This section describes common techniques for creating and working with data objects.  
  
### Creating New Data Objects  
 The <xref:System.Windows.DataObject> class provides several overloaded constructors that facilitate populating a new <xref:System.Windows.DataObject> instance with a single data/data format pair.  
  
 The following example code creates a new data object and uses one of the overloaded constructors <xref:System.Windows.DataObject.%23ctor%2A>(<xref:System.Windows.DataObject.%23ctor(System.String,System.Object)>) to initialize the data object with a string and a specified data format.  In this case, the data format is specified by a string; the <xref:System.Windows.DataFormats> class provides a set of pre-defined type strings. Auto-conversion of the stored data is allowed by default.  
  
 [!code-csharp[DragDrop_DragDropMiscCode#_DragDrop_CreateDataObject_TypeString](../../../../samples/snippets/csharp/VS_Snippets_Wpf/DragDrop_DragDropMiscCode/CSharp/Window1.xaml.cs#_dragdrop_createdataobject_typestring)]
 [!code-vb[DragDrop_DragDropMiscCode#_DragDrop_CreateDataObject_TypeString](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/DragDrop_DragDropMiscCode/visualbasic/window1.xaml.vb#_dragdrop_createdataobject_typestring)]  
  
 For more examples of code that creates a data object, see [Create a Data Object](../../../../docs/framework/wpf/advanced/how-to-create-a-data-object.md).  
  
### Storing Data in Multiple Formats  
 A single data object is able to store data in multiple formats.   Strategic use of multiple data formats within a single data object potentially makes the data object consumable by a wider variety of drop targets than if only a single data format could be represented.  Note that, in general, a drag source must be agnostic about the data formats that are consumable by potential drop targets.  
  
 The following example shows how to use the <xref:System.Windows.DataObject.SetData%28System.String%2CSystem.Object%29> method to add data to a data object in multiple formats.  
  
 [!code-csharp[DragDrop_DragDropMiscCode#_DragDrop_StoreMultipleFormats](../../../../samples/snippets/csharp/VS_Snippets_Wpf/DragDrop_DragDropMiscCode/CSharp/Window1.xaml.cs#_dragdrop_storemultipleformats)]
 [!code-vb[DragDrop_DragDropMiscCode#_DragDrop_StoreMultipleFormats](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/DragDrop_DragDropMiscCode/visualbasic/window1.xaml.vb#_dragdrop_storemultipleformats)]  
  
### Querying a Data Object for Available Formats  
 Because a single data object can contain an arbitrary number of data formats, data objects include facilities for retrieving a list of available data formats.  
  
 The following example code uses the <xref:System.Windows.DataObject.GetFormats%2A> overload to get an array of strings denoting all data formats available in a data object (both native and by auto-convert).  
  
 [!code-csharp[DragDrop_DragDropMiscCode#_DragDrop_GetAllDataFormats](../../../../samples/snippets/csharp/VS_Snippets_Wpf/DragDrop_DragDropMiscCode/CSharp/Window1.xaml.cs#_dragdrop_getalldataformats)]
 [!code-vb[DragDrop_DragDropMiscCode#_DragDrop_GetAllDataFormats](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/DragDrop_DragDropMiscCode/visualbasic/window1.xaml.vb#_dragdrop_getalldataformats)]  
  
 For more examples of code that queries a data object for available data formats, see [List the Data Formats in a Data Object](../../../../docs/framework/wpf/advanced/how-to-list-the-data-formats-in-a-data-object.md).  For examples of querying a data object for the presence of a particular data format, see [Determine if a Data Format is Present in a Data Object](../../../../docs/framework/wpf/advanced/how-to-determine-if-a-data-format-is-present-in-a-data-object.md).  
  
### Retrieving Data from a Data Object  
 Retrieving data from a data object in a particular format simply involves calling one of the <xref:System.Windows.DataObject.GetData%2A> methods and specifying the desired data format.  One of the <xref:System.Windows.DataObject.GetDataPresent%2A> methods can be used to check for the presence of a particular data format.  <xref:System.Windows.DataObject.GetData%2A> returns the data in an <xref:System.Object>; depending on the data format, this object can be cast to a type-specific container.  
  
 The following example code uses the <xref:System.Windows.DataObject.GetDataPresent%28System.String%29> overload to check if a specified data format is available (native or by auto-convert). If the specified format is available, the example retrieves the data by using the <xref:System.Windows.DataObject.GetData%28System.String%29> method.  
  
 [!code-csharp[DragDrop_DragDropMiscCode#_DragDrop_GetSpecificDataFormat](../../../../samples/snippets/csharp/VS_Snippets_Wpf/DragDrop_DragDropMiscCode/CSharp/Window1.xaml.cs#_dragdrop_getspecificdataformat)]
 [!code-vb[DragDrop_DragDropMiscCode#_DragDrop_GetSpecificDataFormat](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/DragDrop_DragDropMiscCode/visualbasic/window1.xaml.vb#_dragdrop_getspecificdataformat)]  
  
 For more examples of code that retrieves data from a data object, see [Retrieve Data in a Particular Data Format](../../../../docs/framework/wpf/advanced/how-to-retrieve-data-in-a-particular-data-format.md).  
  
### Removing Data From a Data Object  
 Data cannot be directly removed from a data object.  To effectively remove data from a data object, follow these steps:  
  
1.  Create a new data object that will contain only the data you want to retain.  
  
2.  "Copy" the desired data from the old data object to the new data object.  To copy the data, use one of the <xref:System.Windows.DataObject.GetData%2A> methods to retrieve an <xref:System.Object> that contains the raw data, and then use one of the <xref:System.Windows.DataObject.SetData%2A> methods to add the data to the new data object.  
  
3.  Replace the old data object with the new one.  
  
> [!NOTE]
>  The <xref:System.Windows.DataObject.SetData%2A> methods only add data to a data object; they do not replace data, even if the data and data format are exactly the same as a previous call. Calling <xref:System.Windows.DataObject.SetData%2A> twice for the same data and data format will result in the data/data format being present twice in the data object.
