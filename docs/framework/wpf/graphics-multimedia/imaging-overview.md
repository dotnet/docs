---
title: "Imaging Overview"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "metadata [WPF], images"
  - "displaying images [WPF]"
  - "Imaging API [WPF]"
  - "image metadata [WPF]"
  - "converting images [WPF]"
  - "encoding image formats [WPF]"
  - "format decoding for images [WPF]"
  - "painting with images [WPF]"
  - "stretching images [WPF]"
  - "images [WPF], about imaging"
  - "format encoding for images [WPF]"
  - "cropping images [WPF]"
  - "decoding image formats [WPF]"
  - "rotating images [WPF]"
ms.assetid: 72aad87a-e6f3-4937-94cd-a18b7766e990
---
# Imaging Overview
This topic provides an introduction to the [!INCLUDE[TLA#tla_wic](../../../../includes/tlasharptla-wic-md.md)]. [!INCLUDE[TLA2#tla_wic](../../../../includes/tla2sharptla-wic-md.md)] enables developers to display, transform, and format images.  

## WPF Imaging Component  
 [!INCLUDE[TLA2#tla_wic](../../../../includes/tla2sharptla-wic-md.md)] provides significant enhancements in imaging capabilities within [!INCLUDE[TLA#tla_win](../../../../includes/tlasharptla-win-md.md)]. Imaging capabilities, such as displaying a bitmap or using an image on a common control were previously reliant upon the Microsoft Windows Graphics Device Interface (GDI) or Microsoft Windows GDI+ libraries. These API provide baseline imaging functionality, but lack features such as support for codec extensibility and high fidelity image support. [!INCLUDE[TLA2#tla_wic](../../../../includes/tla2sharptla-wic-md.md)] is designed to overcome the shortcomings of GDI and GDI+ and provide a new set of API to display and use images within your applications.  
  
 There are two ways to access the [!INCLUDE[TLA2#tla_wic](../../../../includes/tla2sharptla-wic-md.md)] API, a managed component and an unmanaged component. The unmanaged component provides the following features.  
  
- Extensibility model for new or proprietary image formats.  
  
- Improved performance and security on native image formats including bitmap (BMP), Joint Photographics Experts Group (JPEG), Portable Network Graphics (PNG), Tagged Image File Format (TIFF), [!INCLUDE[TLA#tla_wdp](../../../../includes/tlasharptla-wdp-md.md)], Graphics Interchange Format (GIF), and icon (.ico).  
  
- Preservation of high bit-depth image data up to 8 bits per channel (32 bits per pixel).  
  
- Nondestructive image scaling, cropping, and rotations.  
  
- Simplified color management.  
  
- Support for in-file, proprietary metadata.  
  
- The managed component utilizes the unmanaged infrastructure to provide seamless integration of images with other [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] features such as [!INCLUDE[TLA#tla_ui](../../../../includes/tlasharptla-ui-md.md)], animation, and graphics. The managed component also benefits from the Windows Presentation Foundation (WPF) imaging codec extensibility model which enables automatic recognition of new image formats in [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] applications.  
  
 The majority of the managed [!INCLUDE[TLA2#tla_wic](../../../../includes/tla2sharptla-wic-md.md)] API reside in the <xref:System.Windows.Media.Imaging?displayProperty=nameWithType> namespace, though several important types, such as <xref:System.Windows.Media.ImageBrush> and <xref:System.Windows.Media.ImageDrawing> reside in the <xref:System.Windows.Media?displayProperty=nameWithType> namespace and <xref:System.Windows.Controls.Image> resides in the <xref:System.Windows.Controls?displayProperty=nameWithType> namespace.  
  
 This topic provides additional information about the managed component. For more information on the unmanaged API see the [Unmanaged WPF Imaging Component](/windows/desktop/wic/-wic-lh) documentation.  
  
<a name="_imageformats"></a>   
## WPF Image Formats  
 A codec is used to decode or encode a specific media format. [!INCLUDE[TLA2#tla_wic](../../../../includes/tla2sharptla-wic-md.md)] includes a codec  for BMP, JPEG, PNG, [!INCLUDE[TLA2#tla_tiff](../../../../includes/tla2sharptla-tiff-md.md)], [!INCLUDE[TLA2#tla_wdp](../../../../includes/tla2sharptla-wdp-md.md)], GIF, and ICON image formats. Each of these codecs enable applications to decode and, with the exception of ICON, encode their respective image formats.  
  
 <xref:System.Windows.Media.Imaging.BitmapSource> is an important class used in the decoding and encoding of images. It is the basic building block of the [!INCLUDE[TLA2#tla_wic](../../../../includes/tla2sharptla-wic-md.md)] pipeline and represents a single, constant set of pixels at a certain size and resolution. A <xref:System.Windows.Media.Imaging.BitmapSource> can be an individual frame of a multiple frame image, or it can be the result of a transform performed on a <xref:System.Windows.Media.Imaging.BitmapSource>. It is the parent of many of the primary classes used in [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] imaging such as <xref:System.Windows.Media.Imaging.BitmapFrame>.  
  
 A <xref:System.Windows.Media.Imaging.BitmapFrame> is used to store the actual bitmap data of an image format. Many image formats only support a single <xref:System.Windows.Media.Imaging.BitmapFrame>, although formats such as GIF and [!INCLUDE[TLA2#tla_tiff](../../../../includes/tla2sharptla-tiff-md.md)] support multiple frames per image. Frames are used by decoders as input data and are passed to encoders to create image files.  
  
 The following example demonstrates how a <xref:System.Windows.Media.Imaging.BitmapFrame> is created from a <xref:System.Windows.Media.Imaging.BitmapSource> and then added to a [!INCLUDE[TLA2#tla_tiff](../../../../includes/tla2sharptla-tiff-md.md)] image.  
  
 [!code-csharp[BitmapFrameExample#10](~/samples/snippets/csharp/VS_Snippets_Wpf/BitmapFrameExample/CSharp/BitmapFrame.cs#10)]
 [!code-vb[BitmapFrameExample#10](~/samples/snippets/visualbasic/VS_Snippets_Wpf/BitmapFrameExample/VB/BitmapFrame.vb#10)]  
  
### Image Format Decoding  
 Image decoding is the translation of an image format to image data that can be used by the system. The image data can then be used to display, process, or encode to a different format. Decoder selection is based on the image format. Codec selection is automatic unless a specific decoder is specified. The examples in the [Displaying Images in WPF](#_displayingimages) section demonstrate automatic decoding. Custom format decoders developed using the unmanaged [!INCLUDE[TLA2#tla_wic](../../../../includes/tla2sharptla-wic-md.md)] interfaces and registered with the system automatically participate in decoder selection. This allows custom formats to be displayed automatically in [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] applications.  
  
 The following example demonstrates the use of a bitmap decoder to decode a BMP format image.  
  
 [!code-cpp[BmpBitmapDecoderEncoder#5](~/samples/snippets/cpp/VS_Snippets_Wpf/BmpBitmapDecoderEncoder/CPP/anotherfile.cpp#5)]
 [!code-csharp[BmpBitmapDecoderEncoder#5](~/samples/snippets/csharp/VS_Snippets_Wpf/BmpBitmapDecoderEncoder/CSharp/BitmapFrame.cs#5)]
 [!code-vb[BmpBitmapDecoderEncoder#5](~/samples/snippets/visualbasic/VS_Snippets_Wpf/BmpBitmapDecoderEncoder/VB/BitmapFrame.vb#5)]  
  
### Image Format Encoding  
 Image encoding is the translation of image data to a specific image format. The encoded image data can then be used to create new image files. [!INCLUDE[TLA2#tla_wic](../../../../includes/tla2sharptla-wic-md.md)] provides encoders for each of the image formats described above.  
  
 The following example demonstrates the use of an encoder to save a newly created bitmap image.  
  
 [!code-cpp[BmpBitmapDecoderEncoder#3](~/samples/snippets/cpp/VS_Snippets_Wpf/BmpBitmapDecoderEncoder/CPP/anotherfile.cpp#3)]
 [!code-csharp[BmpBitmapDecoderEncoder#3](~/samples/snippets/csharp/VS_Snippets_Wpf/BmpBitmapDecoderEncoder/CSharp/BitmapFrame.cs#3)]
 [!code-vb[BmpBitmapDecoderEncoder#3](~/samples/snippets/visualbasic/VS_Snippets_Wpf/BmpBitmapDecoderEncoder/VB/BitmapFrame.vb#3)]  
  
<a name="_displayingimages"></a>   
## Displaying Images in WPF  
 There are several ways to display an image in a Windows Presentation Foundation (WPF) application. Images can be displayed using an <xref:System.Windows.Controls.Image> control, painted on a visual using an <xref:System.Windows.Media.ImageBrush>, or drawn using an <xref:System.Windows.Media.ImageDrawing>.  
  
### Using the Image Control  
 <xref:System.Windows.Controls.Image> is a framework element and the primary way to display images in applications. In [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)], <xref:System.Windows.Controls.Image> can be used in two ways; attribute syntax or property syntax. The following example shows how to render an image 200 pixels wide using both attribute syntax and property tag syntax. For more information on attribute syntax and property syntax, see [Dependency Properties Overview](../advanced/dependency-properties-overview.md).  
  
 [!code-xaml[ImageElementExample_snip#ImageSimpleExampleInlineMarkup](~/samples/snippets/csharp/VS_Snippets_Wpf/ImageElementExample_snip/CSharp/ImageSimpleExample.xaml#imagesimpleexampleinlinemarkup)]  
  
 Many of the examples use a <xref:System.Windows.Media.Imaging.BitmapImage> object to reference an image file. <xref:System.Windows.Media.Imaging.BitmapImage> is a specialized <xref:System.Windows.Media.Imaging.BitmapSource> that is optimized for [!INCLUDE[TLA#tla_xaml](../../../../includes/tlasharptla-xaml-md.md)] loading and is an easy way to display images as the <xref:System.Windows.Controls.Image.Source%2A> of an <xref:System.Windows.Controls.Image> control.  
  
 The following example shows how to render an image 200 pixels wide using code.  
  
> [!NOTE]
> <xref:System.Windows.Media.Imaging.BitmapImage> implements the <xref:System.ComponentModel.ISupportInitialize> interface to optimize initialization on multiple properties. Property changes can only occur during object initialization. Call <xref:System.Windows.Media.Imaging.BitmapImage.BeginInit%2A> to signal that initialization has begun and <xref:System.Windows.Media.Imaging.BitmapImage.EndInit%2A> to signal that initialization has completed. Once initialized, property changes are ignored.  
  
 [!code-csharp[ImageElementExample_snip#ImageSimpleExampleInlineCode1](~/samples/snippets/csharp/VS_Snippets_Wpf/ImageElementExample_snip/CSharp/ImageSimpleExample.xaml.cs#imagesimpleexampleinlinecode1)]
 [!code-vb[ImageElementExample_snip#ImageSimpleExampleInlineCode1](~/samples/snippets/visualbasic/VS_Snippets_Wpf/ImageElementExample_snip/VB/ImageSimpleExample.xaml.vb#imagesimpleexampleinlinecode1)]  
  
#### Rotating, Converting, and Cropping Images  
 [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] enables users to transform images by using properties of <xref:System.Windows.Media.Imaging.BitmapImage> or by using additional <xref:System.Windows.Media.Imaging.BitmapSource> objects such as <xref:System.Windows.Media.Imaging.CroppedBitmap> or <xref:System.Windows.Media.Imaging.FormatConvertedBitmap>. These image transformations can scale or rotate an image, change the pixel format of an image, or crop an image.  
  
 Image rotations are performed using the <xref:System.Windows.Media.Imaging.BitmapImage.Rotation%2A> property of <xref:System.Windows.Media.Imaging.BitmapImage>. Rotations can only be done in 90 degree increments. In the following example, an image is rotated 90 degrees.  
  
 [!code-xaml[ImageElementExample#TransformedXAML2](~/samples/snippets/csharp/VS_Snippets_Wpf/ImageElementExample/CSharp/TransformedImageExample.xaml#transformedxaml2)]  
  
 [!code-csharp[ImageElementExample#TransformedCSharp1](~/samples/snippets/csharp/VS_Snippets_Wpf/ImageElementExample/CSharp/TransformedImageExample.xaml.cs#transformedcsharp1)]
 [!code-vb[ImageElementExample#TransformedCSharp1](~/samples/snippets/visualbasic/VS_Snippets_Wpf/ImageElementExample/VB/TransformedImageExample.xaml.vb#transformedcsharp1)]  
  
 Converting an image to a different pixel format such as grayscale is done using <xref:System.Windows.Media.Imaging.FormatConvertedBitmap>. In the following examples, an image is converted to <xref:System.Windows.Media.PixelFormats.Gray4%2A>.  
  
 [!code-xaml[ImageElementExample_snip#ConvertedXAML2](~/samples/snippets/csharp/VS_Snippets_Wpf/ImageElementExample_snip/CSharp/FormatConvertedExample.xaml#convertedxaml2)]  
  
 [!code-csharp[ImageElementExample_snip#ConvertedCSharp1](~/samples/snippets/csharp/VS_Snippets_Wpf/ImageElementExample_snip/CSharp/FormatConvertedExample.xaml.cs#convertedcsharp1)]
 [!code-vb[ImageElementExample_snip#ConvertedCSharp1](~/samples/snippets/visualbasic/VS_Snippets_Wpf/ImageElementExample_snip/VB/FormatConvertedExample.xaml.vb#convertedcsharp1)]  
  
 To crop an image, either the <xref:System.Windows.UIElement.Clip%2A> property of <xref:System.Windows.Controls.Image> or <xref:System.Windows.Media.Imaging.CroppedBitmap> can be used. Typically, if you just want to display a portion of an image, <xref:System.Windows.UIElement.Clip%2A> should be used. If you need to encode and save a cropped image, the <xref:System.Windows.Media.Imaging.CroppedBitmap> should be used. In the following example, an image is cropped using the Clip property using an <xref:System.Windows.Media.EllipseGeometry>.  
  
 [!code-xaml[ImageElementExample_snip#CroppedXAMLUsingClip1](~/samples/snippets/csharp/VS_Snippets_Wpf/ImageElementExample_snip/CSharp/CroppedImageExample.xaml#croppedxamlusingclip1)]  
  
 [!code-csharp[ImageElementExample_snip#CroppedCSharpUsingClip1](~/samples/snippets/csharp/VS_Snippets_Wpf/ImageElementExample_snip/CSharp/CroppedImageExample.xaml.cs#croppedcsharpusingclip1)]
 [!code-vb[ImageElementExample_snip#CroppedCSharpUsingClip1](~/samples/snippets/visualbasic/VS_Snippets_Wpf/ImageElementExample_snip/VB/CroppedImageExample.xaml.vb#croppedcsharpusingclip1)]  
  
#### Stretching Images  
 The <xref:System.Windows.Controls.Image.Stretch%2A> property controls how an image is stretched to fill its container. The <xref:System.Windows.Controls.Image.Stretch%2A> property accepts the following values, defined by the <xref:System.Windows.Media.Stretch> enumeration:  
  
- <xref:System.Windows.Media.Stretch.None>: The image is not stretched to fill the output area. If the image is larger than the output area, the image is drawn to the output area, clipping what does not fit.  
  
- <xref:System.Windows.Media.Stretch.Fill>: The image is scaled to fit the output area. Because the image height and width are scaled independently, the original aspect ratio of the image might not be preserved. That is, the image might be warped in order to completely fill the output container.  
  
- <xref:System.Windows.Media.Stretch.Uniform>: The image is scaled so that it fits completely within the output area. The image's aspect ratio is preserved.  
  
- <xref:System.Windows.Media.Stretch.UniformToFill>: The image is scaled so that it completely fills the output area while preserving the image's original aspect ratio.  
  
 The following example applies each of the available <xref:System.Windows.Media.Stretch> enumerations to an <xref:System.Windows.Controls.Image>.  
  
 The following image shows the output from the example and demonstrates the affect the different <xref:System.Windows.Controls.Image.Stretch%2A> settings have when applied to an image.  
  
 ![Different TileBrush Stretch settings](./media/img-mmgraphics-stretchenum.jpg "img_mmgraphics_stretchenum")  
Different stretch settings  
  
 [!code-xaml[ImageElementExample_snip#ImageStretchExampleWholePage](~/samples/snippets/csharp/VS_Snippets_Wpf/ImageElementExample_snip/CSharp/ImageStretchExample.xaml#imagestretchexamplewholepage)]  
  
### Painting with Images  
 Images can also be displayed in an application by painting with a <xref:System.Windows.Media.Brush>. Brushes enable you to paint [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)] objects with anything from simple, solid colors to complex sets of patterns and images. To paint with images, use an <xref:System.Windows.Media.ImageBrush>. An <xref:System.Windows.Media.ImageBrush> is a type of <xref:System.Windows.Media.TileBrush> that defines its content as a bitmap image. An <xref:System.Windows.Media.ImageBrush> displays a single image, which is specified by its <xref:System.Windows.Media.ImageBrush.ImageSource%2A> property. You can control how the image is stretched, aligned, and tiled, enabling you to prevent distortion and produce patterns and other effects. The following illustration shows some effects that can be achieved with an <xref:System.Windows.Media.ImageBrush>.  
  
 ![ImageBrush output examples](./media/wcpsdk-mmgraphics-imagebrushexamples.gif "wcpsdk_mmgraphics_imagebrushexamples")  
Image brushes can fill shapes, controls, text, and more  
  
 The following example demonstrates how to paint the background of a button with an image using an <xref:System.Windows.Media.ImageBrush>.  
  
 [!code-xaml[UsingImageBrush#4](~/samples/snippets/csharp/VS_Snippets_Wpf/UsingImageBrush/CS/PaintingWithImages.xaml#4)]  
  
 For additional information about <xref:System.Windows.Media.ImageBrush> and painting images see [Painting with Images, Drawings, and Visuals](painting-with-images-drawings-and-visuals.md).  
  
<a name="_metadata"></a>   
## Image Metadata  
 Some image files contain metadata that describes the content or the characteristics of the file. For example, most digital cameras create images that contain metadata about the make and model of the camera used to capture the image. Each image format handles metadata differently but [!INCLUDE[TLA2#tla_wic](../../../../includes/tla2sharptla-wic-md.md)] provides a uniform way of storing and retrieving metadata for each supported image format.  
  
 Access to metadata is provided through the <xref:System.Windows.Media.Imaging.BitmapSource.Metadata%2A> property of a <xref:System.Windows.Media.Imaging.BitmapSource> object. <xref:System.Windows.Media.Imaging.BitmapSource.Metadata%2A> returns a <xref:System.Windows.Media.Imaging.BitmapMetadata> object that includes all the metadata contained by the image. This data may be in one metadata schema or a combination of different schemes. [!INCLUDE[TLA2#tla_wic](../../../../includes/tla2sharptla-wic-md.md)] supports the following image metadata schemas: Exchangeable image file (Exif), tEXt (PNG Textual Data), image file directory (IFD), International Press Telecommunications Council (IPTC), and [!INCLUDE[TLA#tla_xmp](../../../../includes/tlasharptla-xmp-md.md)].  
  
 In order to simplify the process of reading metadata, <xref:System.Windows.Media.Imaging.BitmapMetadata> provides several named properties that can be easily accessed such as <xref:System.Windows.Media.Imaging.BitmapMetadata.Author%2A>, <xref:System.Windows.Media.Imaging.BitmapMetadata.Title%2A>, and <xref:System.Windows.Media.Imaging.BitmapMetadata.CameraModel%2A>. Many of these named properties can also be used to write metadata. Additional support for reading metadata is provided by the metadata query reader. The <xref:System.Windows.Media.Imaging.BitmapMetadata.GetQuery%2A> method is used to retrieve a metadata query reader by providing a string query such as *"/app1/exif/"*. In the following example, <xref:System.Windows.Media.Imaging.BitmapMetadata.GetQuery%2A> is used to obtain the text stored in the *"/Text/Description"* location.  
  
 [!code-cpp[BitmapMetadata#GetQuery](~/samples/snippets/cpp/VS_Snippets_Wpf/BitMapMetadata/CPP/BitmapMetadata.cpp#getquery)]
 [!code-csharp[BitmapMetadata#GetQuery](~/samples/snippets/csharp/VS_Snippets_Wpf/BitMapMetadata/CSharp/BitmapMetadata.cs#getquery)]
 [!code-vb[BitmapMetadata#GetQuery](~/samples/snippets/visualbasic/VS_Snippets_Wpf/BitMapMetadata/VB/BitmapMetadata.vb#getquery)]  
  
 To write metadata, a metadata query writer is used. <xref:System.Windows.Media.Imaging.BitmapMetadata.SetQuery%2A> obtains the query writer and sets the desired value. In the following example, <xref:System.Windows.Media.Imaging.BitmapMetadata.SetQuery%2A> is used to write the text stored in the *"/Text/Description"* location.  
  
 [!code-cpp[BitmapMetadata#SetQuery](~/samples/snippets/cpp/VS_Snippets_Wpf/BitMapMetadata/CPP/BitmapMetadata.cpp#setquery)]
 [!code-csharp[BitmapMetadata#SetQuery](~/samples/snippets/csharp/VS_Snippets_Wpf/BitMapMetadata/CSharp/BitmapMetadata.cs#setquery)]
 [!code-vb[BitmapMetadata#SetQuery](~/samples/snippets/visualbasic/VS_Snippets_Wpf/BitMapMetadata/VB/BitmapMetadata.vb#setquery)]  
  
<a name="_extensibility"></a>   
## Codec Extensibility  
 A core feature of [!INCLUDE[TLA2#tla_wic](../../../../includes/tla2sharptla-wic-md.md)] is the extensibility model for new image codecs. These unmanaged interfaces enable codec developers to integrate codecs with [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] so new image formats can automatically be used by [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] applications.  
  
 For a sample of the extensibility API, see the [Win32 Sample Codec](https://go.microsoft.com/fwlink/?LinkID=160052). This sample demonstrates how to create a decoder and encoder for a custom image format.  
  
> [!NOTE]
> The codec must be digitally signed for the system to recognize it.  
  
## See also

- <xref:System.Windows.Media.Imaging.BitmapSource>
- <xref:System.Windows.Media.Imaging.BitmapImage>
- <xref:System.Windows.Controls.Image>
- <xref:System.Windows.Media.Imaging.BitmapMetadata>
- [2D Graphics and Imaging](../advanced/optimizing-performance-2d-graphics-and-imaging.md)
- [Win32 Sample Codec](https://go.microsoft.com/fwlink/?LinkID=160052)
