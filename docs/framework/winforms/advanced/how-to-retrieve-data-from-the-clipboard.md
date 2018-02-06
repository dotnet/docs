---
title: "How to: Retrieve Data from the Clipboard"
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
  - "pasting Clipboard data"
  - "Clipboard [Windows Forms], retrieving data"
ms.assetid: 99612537-2c8a-449f-aab5-2b3b28d656e7
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Retrieve Data from the Clipboard
The <xref:System.Windows.Forms.Clipboard> class provides methods that you can use to interact with the Windows operating system Clipboard feature. Many applications use the Clipboard as a temporary repository for data. For example, word processors use the Clipboard during cut-and-paste operations. The Clipboard is also useful for transferring information from one application to another.  
  
 Some applications store data on the Clipboard in multiple formats to increase the number of other applications that can potentially use the data. A Clipboard format is a string that identifies the format. An application that uses the identified format can retrieve the associated data on the Clipboard. The <xref:System.Windows.Forms.DataFormats> class provides predefined format names for your use. You can also use your own format names or use an object's type as its format. For information about adding data to the Clipboard, see [How to: Add Data to the Clipboard](../../../../docs/framework/winforms/advanced/how-to-add-data-to-the-clipboard.md).  
  
 To determine whether the Clipboard contains data in a particular format, use one of the `Contains`*Format* methods or the <xref:System.Windows.Forms.Clipboard.GetData%2A> method. To retrieve data from the Clipboard, use one of the `Get`*Format* methods or the <xref:System.Windows.Forms.Clipboard.GetData%2A> method. These methods are new in [!INCLUDE[dnprdnext](../../../../includes/dnprdnext-md.md)].  
  
 To access data from the Clipboard by using versions earlier than [!INCLUDE[dnprdnlong](../../../../includes/dnprdnlong-md.md)], use the <xref:System.Windows.Forms.Clipboard.GetDataObject%2A> method and call the methods of the returned <xref:System.Windows.Forms.IDataObject>. To determine whether a particular format is available in the returned object, for example, call the <xref:System.Windows.Forms.IDataObject.GetDataPresent%2A> method.  
  
> [!NOTE]
>  All Windows-based applications share the system Clipboard. Therefore, the contents are subject to change when you switch to another application.  
>   
>  The <xref:System.Windows.Forms.Clipboard> class can only be used in threads set to single thread apartment (STA) mode. To use this class, ensure that your `Main` method is marked with the <xref:System.STAThreadAttribute> attribute.  
  
### To retrieve data from the Clipboard in a single, common format  
  
1.  Use the <xref:System.Windows.Forms.Clipboard.GetAudioStream%2A>, <xref:System.Windows.Forms.Clipboard.GetFileDropList%2A>, <xref:System.Windows.Forms.Clipboard.GetImage%2A>, or <xref:System.Windows.Forms.Clipboard.GetText%2A> method. Optionally, use the corresponding `Contains`*Format* methods first to determine whether data is available in a particular format. These methods are available only in [!INCLUDE[dnprdnext](../../../../includes/dnprdnext-md.md)].  
  
     [!code-csharp[System.Windows.Forms.Clipboard#2](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.Clipboard/CS/form1.cs#2)]
     [!code-vb[System.Windows.Forms.Clipboard#2](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.Clipboard/vb/form1.vb#2)]  
  
### To retrieve data from the Clipboard in a custom format  
  
1.  Use the <xref:System.Windows.Forms.Clipboard.GetData%2A> method with a custom format name. This method is available only in [!INCLUDE[dnprdnext](../../../../includes/dnprdnext-md.md)].  
  
     You can also use predefined format names with the <xref:System.Windows.Forms.Clipboard.SetData%2A> method. For more information, see <xref:System.Windows.Forms.DataFormats>.  
  
     [!code-csharp[System.Windows.Forms.Clipboard#3](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.Clipboard/CS/form1.cs#3)]
     [!code-vb[System.Windows.Forms.Clipboard#3](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.Clipboard/vb/form1.vb#3)]  
    [!code-csharp[System.Windows.Forms.Clipboard#100](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.Clipboard/CS/form1.cs#100)]
    [!code-vb[System.Windows.Forms.Clipboard#100](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.Clipboard/vb/form1.vb#100)]  
  
### To retrieve data from the Clipboard in multiple formats  
  
1.  Use the <xref:System.Windows.Forms.Clipboard.GetDataObject%2A> method. You must use this method to retrieve data from the Clipboard on versions earlier than [!INCLUDE[dnprdnlong](../../../../includes/dnprdnlong-md.md)].  
  
     [!code-csharp[System.Windows.Forms.Clipboard#4](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.Clipboard/CS/form1.cs#4)]
     [!code-vb[System.Windows.Forms.Clipboard#4](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.Clipboard/vb/form1.vb#4)]  
    [!code-csharp[System.Windows.Forms.Clipboard#100](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.Clipboard/CS/form1.cs#100)]
    [!code-vb[System.Windows.Forms.Clipboard#100](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.Clipboard/vb/form1.vb#100)]  
  
## See Also  
 [Drag-and-Drop Operations and Clipboard Support](../../../../docs/framework/winforms/advanced/drag-and-drop-operations-and-clipboard-support.md)  
 [How to: Add Data to the Clipboard](../../../../docs/framework/winforms/advanced/how-to-add-data-to-the-clipboard.md)
