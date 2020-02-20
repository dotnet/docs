---
title: "ColorConvertedBitmap Markup Extension"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "XAML [WPF], ColorConvertedBitmap markup extension"
  - "ColorConvertedBitmap markup extension [WPF]"
ms.assetid: 18321c18-c898-4470-93fa-a702b47770c1
---
# ColorConvertedBitmap Markup Extension
Provides a way to specify a bitmap source that does not have an embedded profile. Color contexts / profiles are specified by URI, as is the image source URI.  
  
## XAML Attribute Usage  
  
```xml  
<object property="{ColorConvertedBitmap imageSource sourceIIC destinationIIC}" .../>  
```  
  
## XAML Values  
  
|||  
|-|-|  
|`imageSource`|The URI of the nonprofiled bitmap.|  
|`sourceIIC`|The URI of the source profile configuration.|  
|`destinationIIC`|The URI of the destination profile configuration|  
  
## Remarks  
 This markup extension is intended to fill a related set of image-source property values such as <xref:System.Windows.Media.Imaging.BitmapImage.UriSource%2A>.  
  
 Attribute syntax is the most common syntax used with this markup extension. `ColorConvertedBitmap` (or `ColorConvertedBitmapExtension`) cannot be used in property element syntax, because the values can only be set as values on the initial constructor, which is the string following the extension identifier.  
  
 `ColorConvertedBitmap` is a markup extension. Markup extensions are typically implemented when there is a requirement to escape attribute values to be other than literal values or handler names, and the requirement is more global than just putting type converters on certain types or properties. All markup extensions in [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] use the { and } characters in their attribute syntax, which is the convention by which a [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] processor recognizes that a markup extension must process the attribute. For more information, see [Markup Extensions and WPF XAML](markup-extensions-and-wpf-xaml.md).  
  
## See also

- <xref:System.Windows.Media.Imaging.BitmapImage.UriSource%2A>
- [Markup Extensions and WPF XAML](markup-extensions-and-wpf-xaml.md)
- [Imaging Overview](../graphics-multimedia/imaging-overview.md)
