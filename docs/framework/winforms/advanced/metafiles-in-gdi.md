---
title: "Metafiles in GDI+"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "images [Windows Forms], metafiles"
  - "GDI+, metafiles"
  - "metafiles"
ms.assetid: 51da872c-c783-440f-8bf6-1e580a966c31
---
# Metafiles in GDI+
GDI+ provides the <xref:System.Drawing.Imaging.Metafile> class so that you can record and display metafiles. A metafile, also called a vector image, is an image that is stored as a sequence of drawing commands and settings. The commands and settings recorded in a <xref:System.Drawing.Imaging.Metafile> object can be stored in memory or saved to a file or stream.  
  
## Metafile Formats  
 GDI+ can display metafiles that have been stored in the following formats:  
  
- Windows Metafile (WMF)  
  
- Enhanced Metafile (EMF)  
  
- EMF+  
  
 GDI+ can record metafiles in the EMF and EMF+ formats, but not in the WMF format.  
  
 EMF+ is an extension to EMF that allows GDI+ records to be stored. There are two variations on the EMF+ format: EMF+ Only and EMF+ Dual. EMF+ Only metafiles contain only GDI+ records. Such metafiles can be displayed by GDI+ but not by GDI. EMF+ Dual metafiles contain GDI+ and GDI records. Each GDI+ record in an EMF+ Dual metafile is paired with an alternate GDI record. Such metafiles can be displayed by GDI+ or by GDI.  
  
 The following example displays a metafile that was previously saved as a file. The metafile is displayed with its upper-left corner at (100, 100).  
  
 [!code-csharp[System.Drawing.ImagesBitmapsMetafiles#21](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Drawing.ImagesBitmapsMetafiles/CS/Class1.cs#21)]
 [!code-vb[System.Drawing.ImagesBitmapsMetafiles#21](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Drawing.ImagesBitmapsMetafiles/VB/Class1.vb#21)]  
  
## See also

- [Images, Bitmaps, and Metafiles](images-bitmaps-and-metafiles.md)
