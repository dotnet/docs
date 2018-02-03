---
title: "How to: Read Image Metadata"
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
  - "metadata [Windows Forms], property item"
  - "metadata [Windows Forms], reading image"
ms.assetid: 72ec0b31-0be7-444a-9575-1dbcb864e0be
caps.latest.revision: 15
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Read Image Metadata
Some image files contain metadata that you can read to determine features of the image. For example, a digital photograph might contain metadata that you can read to determine the make and model of the camera used to capture the image. With [!INCLUDE[ndptecgdiplus](../../../../includes/ndptecgdiplus-md.md)], you can read existing metadata, and you can also write new metadata to image files.  
  
 [!INCLUDE[ndptecgdiplus](../../../../includes/ndptecgdiplus-md.md)] stores an individual piece of metadata in a <xref:System.Drawing.Imaging.PropertyItem> object. You can read the <xref:System.Drawing.Image.PropertyItems%2A> property of an <xref:System.Drawing.Image> object to retrieve all the metadata from a file. The <xref:System.Drawing.Image.PropertyItems%2A> property returns an array of <xref:System.Drawing.Imaging.PropertyItem> objects.  
  
 A <xref:System.Drawing.Imaging.PropertyItem> object has the following four properties: `Id`, `Value`, `Len`, and `Type`.  
  
## Id  
 A tag that identifies the metadata item. Some values that can be assigned to <xref:System.Drawing.Imaging.PropertyItem.Id%2A> are shown in the following table.  
  
|Hexadecimal value|Description|  
|-----------------------|-----------------|  
|0x0320<br /><br /> 0x010F<br /><br /> 0x0110<br /><br /> 0x9003<br /><br /> 0x829A<br /><br /> 0x5090<br /><br /> 0x5091|Image title<br /><br /> Equipment manufacturer<br /><br /> Equipment model<br /><br /> ExifDTOriginal<br /><br /> Exif exposure time<br /><br /> Luminance table<br /><br /> Chrominance table|  
  
## Value  
 An array of values. The format of the values is determined by the <xref:System.Drawing.Imaging.PropertyItem.Type%2A> property.  
  
## Len  
 The length (in bytes) of the array of values pointed to by the <xref:System.Drawing.Imaging.PropertyItem.Value%2A> property.  
  
## Type  
 The data type of the values in the array pointed to by the `Value` property. The formats indicated by the `Type` property values are shown in the following table  
  
|Numeric value|Description|  
|-------------------|-----------------|  
|1|A `Byte`|  
|2|An array of `Byte` objects encoded as ASCII|  
|3|A 16-bit integer|  
|4|A 32-bit integer|  
|5|An array of two `Byte` objects that represent a rational number|  
|6|Not used|  
|7|Undefined|  
|8|Not used|  
|9|`SLong`|  
|10|`SRational`|  
  
## Example  
  
### Description  
 The following code example reads and displays the seven pieces of metadata in the file `FakePhoto.jpg`. The second (index 1) property item in the list has <xref:System.Drawing.Imaging.PropertyItem.Id%2A> 0x010F (equipment manufacturer) and <xref:System.Drawing.Imaging.PropertyItem.Type%2A> 2 (ASCII-encoded byte array). The code example displays the value of that property item.  
  
 The code produces output similar to the following:  
  
 `Property Item 0`  
  
 `id: 0x320`  
  
 `type: 2`  
  
 `length: 16 bytes`  
  
 `Property Item 1`  
  
 `id: 0x10f`  
  
 `type: 2`  
  
 `length: 17 bytes`  
  
 `Property Item 2`  
  
 `id: 0x110`  
  
 `type: 2`  
  
 `length: 7 bytes`  
  
 `Property Item 3`  
  
 `id: 0x9003`  
  
 `type: 2`  
  
 `length: 20 bytes`  
  
 `Property Item 4`  
  
 `id: 0x829a`  
  
 `type: 5`  
  
 `length: 8 bytes`  
  
 `Property Item 5`  
  
 `id: 0x5090`  
  
 `type: 3`  
  
 `length: 128 bytes`  
  
 `Property Item 6`  
  
 `id: 0x5091`  
  
 `type: 3`  
  
 `length: 128 bytes`  
  
 `The equipment make is Northwind Camera.`  
  
### Code  
 [!code-csharp[System.Drawing.WorkingWithImages#51](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Drawing.WorkingWithImages/CS/Class1.cs#51)]
 [!code-vb[System.Drawing.WorkingWithImages#51](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Drawing.WorkingWithImages/VB/Class1.vb#51)]  
  
## Compiling the Code  
 The preceding example is designed for use with Windows Forms, and it requires <xref:System.Windows.Forms.PaintEventArgs> `e`, which is a parameter of the <xref:System.Windows.Forms.Control.Paint> event handler. Handle the form's <xref:System.Windows.Forms.Control.Paint> event and paste this code into the paint event handler. You must replace `FakePhoto.jpg` with an image name and path valid on your system and import the `System.Drawing.Imaging` namespace.  
  
## See Also  
 [Images, Bitmaps, and Metafiles](../../../../docs/framework/winforms/advanced/images-bitmaps-and-metafiles.md)  
 [Working with Images, Bitmaps, Icons, and Metafiles](../../../../docs/framework/winforms/advanced/working-with-images-bitmaps-icons-and-metafiles.md)
