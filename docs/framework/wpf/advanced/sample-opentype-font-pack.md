---
title: "Sample OpenType Font Pack"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "OpenType font pack [WPF]"
  - "fonts [WPF], OpenType font pack"
  - "typography [WPF], OpenType font pack"
ms.assetid: 56b46fa1-a44e-419b-8f14-25ad51c715c3
---
# Sample OpenType Font Pack
This topic provides an overview of the sample OpenType fonts that are distributed with the Windows SDK. The sample fonts support extended OpenType features that can be used by [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] applications.  

<a name="overview"></a>   
## Fonts in the OpenType Font Pack  
 The Windows SDK provides a set of sample OpenType fonts that you can use in creating [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] applications. The sample fonts are supplied under license from Ascender Corporation. These fonts implement only a subset of the total features defined by the OpenType format. The following table lists the names of the sample OpenType fonts.  
  
|**Name**|**File**|  
|--------------|--------------|  
|Kootenay|Kooten.ttf|  
|Lindsey|Linds.ttf|  
|Miramonte|Miramo.ttf|  
|Miramonte Bold|Miramob.ttf|  
|Pericles|Peric.ttf|  
|Pericles Light|Pericl.ttf|  
|Pescadero|Pesca.ttf|  
|Pescadero Bold|Pescab.ttf|  
  
 The following illustration shows what the sample OpenType fonts look like.  
  
 ![List of font names in sample font pack](./media/sample-opentype-font-pack/font-names-sample-pack.gif)  
  
 The sample fonts are supplied under license from Ascender Corporation. Ascender is a provider of advanced font products. To license extended or custom versions of the sample fonts, see [Ascender Corporation's Web site](https://go.microsoft.com/fwlink/?LinkId=182627).  
  
> [!NOTE]
> As a developer it is your responsibility to ensure that you have the required license rights for any font you embed within an application or otherwise redistribute.  
  
<a name="installing_the_fonts"></a>   
## Installing the Fonts  
 You have the option of installing the sample OpenType fonts to the default Windows Fonts directory, **\WINDOWS\Fonts**. Use the Fonts control panel to install the fonts. Once these fonts are on your computer, they are accessible to all applications that reference default Windows fonts. You can display a representative set of characters in several font sizes by doubling-clicking the font file. The following screenshot shows the Lindsey font file, Linds.ttf.  
  
 ![Lindsey font &#40;OpenType&#41;](./media/typographyinwpf-04.png "TypographyInWPF_04")  
Displaying the Lindsey font  
  
<a name="using_the_fonts"></a>   
## Using the Fonts  
 There are two ways that you can use fonts in your application. You can add fonts to your application as project content items that are not embedded as resources within an assembly. Alternatively, you can add fonts to your application as project resource items that are embedded within the application's assembly files. For more information, see [Packaging Fonts with Applications](packaging-fonts-with-applications.md).  
  
## See also

- <xref:System.Windows.Documents.Typography>
- [OpenType Font Features](opentype-font-features.md)
- [Packaging Fonts with Applications](packaging-fonts-with-applications.md)
