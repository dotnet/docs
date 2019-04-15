---
title: "How to: Determine the Parameters Supported by an Encoder"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "encoder parameters [Windows Forms], determining supported"
ms.assetid: f47ae459-e3ce-4d41-a140-2f6c6aea3f44
---
# How to: Determine the Parameters Supported by an Encoder
You can adjust image parameters, such as quality and compression level, but you must know which parameters are supported by a given image encoder. The <xref:System.Drawing.Image> class provides the <xref:System.Drawing.Image.GetEncoderParameterList%2A> method so that you can determine which image parameters are supported for a particular encoder. You specify the encoder with a GUID. The <xref:System.Drawing.Image.GetEncoderParameterList%2A> method returns an array of <xref:System.Drawing.Imaging.EncoderParameter> objects.  
  
## Example  
 The following example code outputs the supported parameters for the JPEG encoder. Use the list of parameter categories and associated GUIDs in the <xref:System.Drawing.Imaging.Encoder> class overview to determine the category for each parameter.  
  
 [!code-csharp[UsingImageEncodersDecoders#3](~/samples/snippets/csharp/VS_Snippets_Winforms/UsingImageEncodersDecoders/CS/Form1.cs#3)]
 [!code-vb[UsingImageEncodersDecoders#3](~/samples/snippets/visualbasic/VS_Snippets_Winforms/UsingImageEncodersDecoders/VB/Form1.vb#3)]  
  
## Compiling the Code  
 This example requires:  
  
-   A Windows Forms application.  
  
-   A <xref:System.Windows.Forms.PaintEventArgs>, which is a parameter of <xref:System.Windows.Forms.PaintEventHandler>.  
  
## See also

- [How to: List Installed Encoders](how-to-list-installed-encoders.md)
- [Types of Bitmaps](types-of-bitmaps.md)
- [Using Image Encoders and Decoders in Managed GDI+](using-image-encoders-and-decoders-in-managed-gdi.md)
