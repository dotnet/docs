---
title: "How to: Add Data to the Clipboard"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "Clipboard [Windows Forms], copying data to"
  - "data [Windows Forms], copying to Clipboard"
ms.assetid: 25152454-0e78-40a9-8a9e-a2a5a274e517
caps.latest.revision: 14
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Add Data to the Clipboard
The <xref:System.Windows.Forms.Clipboard> class provides methods that you can use to interact with the Windows operating system Clipboard feature. Many applications use the Clipboard as a temporary repository for data. For example, word processors use the Clipboard during cut-and-paste operations. The Clipboard is also useful for transferring data from one application to another.  
  
 When you add data to the Clipboard, you can indicate the data format so that other applications can recognize the data if they can use that format. You can also add data to the Clipboard in multiple different formats to increase the number of other applications that can potentially use the data.  
  
 A Clipboard format is a string that identifies the format so that an application that uses that format can retrieve the associated data. The <xref:System.Windows.Forms.DataFormats> class provides predefined format names for your use. You can also use your own format names or use the type of an object as its format.  
  
 To add data to the Clipboard in one or multiple formats, use the <xref:System.Windows.Forms.Clipboard.SetDataObject%2A> method. You can pass any object to this method, but to add data in multiple formats, you must first add the data to a separate object designed to work with multiple formats. Typically, you will add your data to a <xref:System.Windows.Forms.DataObject>, but you can use any type that implements the <xref:System.Windows.Forms.IDataObject> interface.  
  
 In [!INCLUDE[dnprdnext](../../../../includes/dnprdnext-md.md)], you can add data directly to the Clipboard by using new methods designed to make basic Clipboard tasks easier. Use these methods when you work with data in a single, common format such as text.  
  
> [!NOTE]
>  All Windows-based applications share the Clipboard. Therefore, the contents are subject to change when you switch to another application.  
>   
>  The <xref:System.Windows.Forms.Clipboard> class can only be used in threads set to single thread apartment (STA) mode. To use this class, ensure that your `Main` method is marked with the <xref:System.STAThreadAttribute> attribute.  
>   
>  An object must be serializable for it to be put on the Clipboard. To make a type serializable, mark it with the <xref:System.SerializableAttribute> attribute. If you pass a non-serializable object to a Clipboard method, the method will fail without throwing an exception. For more information about serialization, see <xref:System.Runtime.Serialization>.  
  
### To add data to the Clipboard in a single, common format  
  
1.  Use the <xref:System.Windows.Forms.Clipboard.SetAudio%2A>, <xref:System.Windows.Forms.Clipboard.SetFileDropList%2A>, <xref:System.Windows.Forms.Clipboard.SetImage%2A>, or <xref:System.Windows.Forms.Clipboard.SetText%2A> method. These methods are available only in [!INCLUDE[dnprdnext](../../../../includes/dnprdnext-md.md)].  
  
     [!code-csharp[System.Windows.Forms.Clipboard#2](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.Clipboard/CS/form1.cs#2)]
     [!code-vb[System.Windows.Forms.Clipboard#2](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.Clipboard/vb/form1.vb#2)]  
  
### To add data to the Clipboard in a custom format  
  
1.  Use the <xref:System.Windows.Forms.Clipboard.SetData%2A> method with a custom format name. This method is available only in [!INCLUDE[dnprdnext](../../../../includes/dnprdnext-md.md)].  
  
     You can also use predefined format names with the <xref:System.Windows.Forms.Clipboard.SetData%2A> method. For more information, see <xref:System.Windows.Forms.DataFormats>.  
  
     [!code-csharp[System.Windows.Forms.Clipboard#3](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.Clipboard/CS/form1.cs#3)]
     [!code-vb[System.Windows.Forms.Clipboard#3](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.Clipboard/vb/form1.vb#3)]  
    [!code-csharp[System.Windows.Forms.Clipboard#100](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.Clipboard/CS/form1.cs#100)]
    [!code-vb[System.Windows.Forms.Clipboard#100](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.Clipboard/vb/form1.vb#100)]  
  
### To add data to the Clipboard in multiple formats  
  
1.  Use the <xref:System.Windows.Forms.Clipboard.SetDataObject%2A> method and pass in a <xref:System.Windows.Forms.DataObject> that contains your data. You must use this method to add data to the Clipboard on versions earlier than [!INCLUDE[dnprdnlong](../../../../includes/dnprdnlong-md.md)].  
  
     [!code-csharp[System.Windows.Forms.Clipboard#4](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.Clipboard/CS/form1.cs#4)]
     [!code-vb[System.Windows.Forms.Clipboard#4](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.Clipboard/vb/form1.vb#4)]  
    [!code-csharp[System.Windows.Forms.Clipboard#100](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.Clipboard/CS/form1.cs#100)]
    [!code-vb[System.Windows.Forms.Clipboard#100](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.Clipboard/vb/form1.vb#100)]  
  
## See Also  
 [Drag-and-Drop Operations and Clipboard Support](../../../../docs/framework/winforms/advanced/drag-and-drop-operations-and-clipboard-support.md)  
 [How to: Retrieve Data from the Clipboard](../../../../docs/framework/winforms/advanced/how-to-retrieve-data-from-the-clipboard.md)
