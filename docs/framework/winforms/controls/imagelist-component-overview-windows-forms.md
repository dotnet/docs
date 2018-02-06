---
title: "ImageList Component Overview (Windows Forms)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "ImageList"
helpviewer_keywords: 
  - "collection controls [Windows Forms], images"
  - "icon list control"
  - "ImageList component [Windows Forms], about ImageList component"
ms.assetid: 7e25d89b-5633-40c1-afc3-82e0e301ffa2
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# ImageList Component Overview (Windows Forms)
The Windows Forms <xref:System.Windows.Forms.ImageList> component is used to store images, which can then be displayed by controls. An image list allows you to write code for a single, consistent catalog of images. For example, you can rotate images displayed by a <xref:System.Windows.Forms.Button> control simply by changing the button's <xref:System.Windows.Forms.ButtonBase.ImageIndex%2A> or <xref:System.Windows.Forms.ButtonBase.ImageKey%2A> property. You can also associate the same image list with multiple controls. For example, if you are using both a <xref:System.Windows.Forms.ListView> control and a <xref:System.Windows.Forms.TreeView> control to display the same list of files, changing a file's icon in the image list will cause the new icon to appear in both views.  
  
## Using ImageList with Controls  
 You can use an image list with any control that has an `ImageList` property — or in the case of the <xref:System.Windows.Forms.ListView> control, <xref:System.Windows.Forms.ListView.SmallImageList%2A> and <xref:System.Windows.Forms.ListView.LargeImageList%2A> properties. The controls that can be associated with an image list include: the <xref:System.Windows.Forms.ListView>, <xref:System.Windows.Forms.TreeView>, <xref:System.Windows.Forms.ToolBar>, <xref:System.Windows.Forms.TabControl>, <xref:System.Windows.Forms.Button>, <xref:System.Windows.Forms.CheckBox>, <xref:System.Windows.Forms.RadioButton>, and <xref:System.Windows.Forms.Label> controls. To associate the image list with a control, set the control's `ImageList` property to the name of the <xref:System.Windows.Forms.ImageList> component.  
  
## Key Properties  
 The key property of the <xref:System.Windows.Forms.ImageList> component is <xref:System.Windows.Forms.ImageList.Images%2A>, which contains the pictures to be used by the associated control. Each individual image can be accessed by its index value or by its key. The <xref:System.Windows.Forms.ImageList.ColorDepth%2A> property determines the number of colors that the images are rendered with. The images will all be displayed at the same size, set by the <xref:System.Windows.Forms.ImageList.ImageSize%2A> property. Images that are larger will be scaled to fit.  
  
 If you are using [!INCLUDE[vsprvslong](../../../../includes/vsprvslong-md.md)], you have access to a large library of standard images that you can use in your applications.  
  
## See Also  
 <xref:System.Windows.Forms.ImageList>  
 [How to: Add or Remove Images with the Windows Forms ImageList Component](../../../../docs/framework/winforms/controls/how-to-add-or-remove-images-with-the-windows-forms-imagelist-component.md)
