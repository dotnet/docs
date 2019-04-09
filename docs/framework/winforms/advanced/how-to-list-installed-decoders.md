---
title: "How to: List Installed Decoders"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "image codecs [Windows Forms], listing"
  - "image decoders [Windows Forms], listing"
ms.assetid: 11417191-8c95-40ca-8024-779e61706fb6
---
# How to: List Installed Decoders
You may want to list the image decoders available on a computer, to determine whether your application can read a particular image file format. The <xref:System.Drawing.Imaging.ImageCodecInfo> class provides the <xref:System.Drawing.Imaging.ImageCodecInfo.GetImageDecoders%2A> static methods so that you can determine which image decoders are available. <xref:System.Drawing.Imaging.ImageCodecInfo.GetImageDecoders%2A> returns an array of <xref:System.Drawing.Imaging.ImageCodecInfo> objects.  
  
## Example  
 The following code example outputs the list of installed decoders and their property values.  
  
 [!code-csharp[UsingImageEncodersDecoders#2](~/samples/snippets/csharp/VS_Snippets_Winforms/UsingImageEncodersDecoders/CS/Form1.cs#2)]
 [!code-vb[UsingImageEncodersDecoders#2](~/samples/snippets/visualbasic/VS_Snippets_Winforms/UsingImageEncodersDecoders/VB/Form1.vb#2)]  
  
## Compiling the Code  
 This example requires:  
  
-   A Windows Forms application.  
  
-   A <xref:System.Windows.Forms.PaintEventArgs>, which is a parameter of <xref:System.Windows.Forms.PaintEventHandler>.  
  
## See also

- [How to: List Installed Encoders](how-to-list-installed-encoders.md)
- [Using Image Encoders and Decoders in Managed GDI+](using-image-encoders-and-decoders-in-managed-gdi.md)
