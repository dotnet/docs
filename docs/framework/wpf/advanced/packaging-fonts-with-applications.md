---
title: "Packaging Fonts with Applications"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "applications [WPF], packaging fonts with"
  - "fonts [WPF], packaging with applications"
  - "typography [WPF], packaging fonts with applications"
  - "packaging fonts with applications [WPF]"
ms.assetid: db15ee48-4d24-49f5-8b9d-a64460865286
caps.latest.revision: 29
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Packaging Fonts with Applications
This topic provides an overview of how to package fonts with your [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] application.  
  
> [!NOTE]
>  As with most types of software, font files are licensed, rather than sold. Licenses that govern the use of fonts vary from vendor to vendor but in general most licenses, including those covering the fonts [!INCLUDE[TLA#tla_ms#initcap](../../../../includes/tlasharptla-mssharpinitcap-md.md)] supplies with applications and [!INCLUDE[TLA#tla_mswin](../../../../includes/tlasharptla-mswin-md.md)], do not allow the fonts to be embedded within applications or otherwise redistributed. Therefore, as a developer it is your responsibility to ensure that you have the required license rights for any font you embed within an application or otherwise redistribute.  
  

  
<a name="introduction_to_packaging_fonts"></a>   
## Introduction to Packaging Fonts  
 You can easily package fonts as resources within your [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] applications to display user interface text and other types of text based content. The fonts can be separate from or embedded within the application's assembly files. You can also create a resource-only font library, which your application can reference.  
  
 [!INCLUDE[TLA#tla_opentype](../../../../includes/tlasharptla-opentype-md.md)] and [!INCLUDE[TLA#tla_truetype](../../../../includes/tlasharptla-truetype-md.md)] fonts contain a type flag, fsType, that indicates font embedding licensing rights for the font. However, this type flag only refers to embedded fonts stored in a document–it does not refer to fonts embedded in an application. You can retrieve the font embedding rights for a font by creating a <xref:System.Windows.Media.GlyphTypeface> object and referencing its <xref:System.Windows.Media.GlyphTypeface.EmbeddingRights%2A> property. Refer to the "OS/2 and Windows Metrics" section of the [OpenType Specification](http://www.microsoft.com/typography/otspec/os2.htm) for more information on the fsType flag.  
  
 The [Microsoft Typography](http://www.microsoft.com/typography/links/) Web site includes contact information that can help you locate a particular font vendor or find a font vendor for custom work.  
  
<a name="adding_fonts_as_content_items"></a>   
## Adding Fonts as Content Items  
 You can add fonts to your application as project content items that are separate from the application's assembly files. This means that content items are not embedded as resources within an assembly. The following project file example shows how to define content items.  
  
```xml  
<Project DefaultTargets="Build"  
                xmlns="http://schemas.microsoft.com/developer/msbuild/2003">  
  <!-- Other project build settings ... -->  
  
  <ItemGroup>  
    <Content Include="Peric.ttf" />  
    <Content Include="Pericl.ttf" />  
  </ItemGroup>  
</Project>  
```  
  
 In order to ensure that the application can use the fonts at run time, the fonts must be accessible in the application's deployment directory. The `<CopyToOutputDirectory>` element in the application's project file allows you to automatically copy the fonts to the application deployment directory during the build process. The following project file example shows how to copy fonts to the deployment directory.  
  
```xml  
<ItemGroup>  
  <Content Include="Peric.ttf">  
    <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>  
  </Content>  
  <Content Include="Pericl.ttf">  
    <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>  
  </Content>  
</ItemGroup>  
```  
  
 The following code example shows how to reference the application's font as a content item—the referenced content item must be in the same directory as the application's assembly files.  
  
 [!code-xaml[FontSnippets#FontPackageSnippet8](../../../../samples/snippets/csharp/VS_Snippets_Wpf/FontSnippets/CSharp/FontPackageSnippets.xaml#fontpackagesnippet8)]  
  
<a name="adding_fonts_as_resource_items"></a>   
## Adding Fonts as Resource Items  
 You can add fonts to your application as project resource items that are embedded within the application's assembly files. Using a separate subdirectory for resources helps to organize the application's project files. The following project file example shows how to define fonts as resource items in a separate subdirectory.  
  
```xml  
<Project DefaultTargets="Build"  
                xmlns="http://schemas.microsoft.com/developer/msbuild/2003">  
  <!-- Other project build settings ... -->  
  
  <ItemGroup>  
    <Resource Include="resources\Peric.ttf" />  
    <Resource Include="resources\Pericl.ttf" />  
  </ItemGroup>  
</Project>  
```  
  
> [!NOTE]
>  When you add fonts as resources to your application, make sure you are setting the `<Resource>` element, and not the `<EmbeddedResource>` element in your application's project file. The `<EmbeddedResource>` element for the build action is not supported.  
  
 The following markup example shows how to reference the application's font resources.  
  
 [!code-xaml[FontSnippets#FontPackageSnippet1](../../../../samples/snippets/csharp/VS_Snippets_Wpf/FontSnippets/CSharp/FontPackageSnippets.xaml#fontpackagesnippet1)]  
  
### Referencing Font Resource Items from Code  
 In order to reference font resource items from code, you must supply a two-part font resource reference: the base [!INCLUDE[TLA#tla_uri](../../../../includes/tlasharptla-uri-md.md)]; and the font location reference. These values are used as the parameters for the <xref:System.Windows.Media.FontFamily.%23ctor%2A> method. The following code example shows how to reference the application's font resources in the project subdirectory called `resources`.  
  
 [!code-csharp[FontSnippets#FontPackageSnippet2](../../../../samples/snippets/csharp/VS_Snippets_Wpf/FontSnippets/CSharp/FontPackageSnippets.xaml.cs#fontpackagesnippet2)]
 [!code-vb[FontSnippets#FontPackageSnippet2](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/FontSnippets/visualbasic/fontpackagesnippets.xaml.vb#fontpackagesnippet2)]  
  
 The base [!INCLUDE[TLA#tla_uri](../../../../includes/tlasharptla-uri-md.md)] can include the application subdirectory where the font resource resides. In this case, the font location reference would not need to specify a directory, but would have to include a leading "`./`", which indicates the font resource is in the same directory specified by the base [!INCLUDE[TLA#tla_uri](../../../../includes/tlasharptla-uri-md.md)]. The following code example shows an alternate way of referencing the font resource item—it is equivalent to the previous code example.  
  
 [!code-csharp[FontSnippets#FontPackageSnippet5](../../../../samples/snippets/csharp/VS_Snippets_Wpf/FontSnippets/CSharp/FontPackageSnippets.xaml.cs#fontpackagesnippet5)]
 [!code-vb[FontSnippets#FontPackageSnippet5](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/FontSnippets/visualbasic/fontpackagesnippets.xaml.vb#fontpackagesnippet5)]  
  
### Referencing Fonts from the Same Application Subdirectory  
 You can place both application content and resource files within the same user-defined subdirectory of your application project. The following project file example shows a content page and font resources defined in the same subdirectory.  
  
```xml  
<ItemGroup>  
  <Page Include="pages\HomePage.xaml" />  
</ItemGroup>  
<ItemGroup>  
  <Resource Include="pages\Peric.ttf" />  
  <Resource Include="pages\Pericl.ttf" />  
</ItemGroup>  
```  
  
 Since the application content and font are in the same subdirectory, the font reference is relative to the application content. The following examples show how to reference the application's font resource when the font is in the same directory as the application.  
  
 [!code-xaml[FontSnippets#FontPackageSnippet3](../../../../samples/snippets/csharp/VS_Snippets_Wpf/FontSnippets/CSharp/pages/HomePage.xaml#fontpackagesnippet3)]  
  
 [!code-csharp[FontSnippets#FontPackageSnippet4](../../../../samples/snippets/csharp/VS_Snippets_Wpf/FontSnippets/CSharp/pages/HomePage.xaml.cs#fontpackagesnippet4)]
 [!code-vb[FontSnippets#FontPackageSnippet4](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/FontSnippets/visualbasic/pages/homepage.xaml.vb#fontpackagesnippet4)]  
  
### Enumerating Fonts in an Application  
 To enumerate fonts as resource items in your application, use either the <xref:System.Windows.Media.Fonts.GetFontFamilies%2A> or <xref:System.Windows.Media.Fonts.GetTypefaces%2A> method. The following example shows how to use the <xref:System.Windows.Media.Fonts.GetFontFamilies%2A> method to return the collection of <xref:System.Windows.Media.FontFamily> objects from the application font location. In this case, the application contains a subdirectory named "resources".  
  
 [!code-csharp[FontSnippets#FontsSnippet3](../../../../samples/snippets/csharp/VS_Snippets_Wpf/FontSnippets/CSharp/FontFamilySnippets.xaml.cs#fontssnippet3)]
 [!code-vb[FontSnippets#FontsSnippet3](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/FontSnippets/visualbasic/fontfamilysnippets.xaml.vb#fontssnippet3)]  
  
 The following example shows how to use the <xref:System.Windows.Media.Fonts.GetTypefaces%2A> method to return the collection of <xref:System.Windows.Media.Typeface> objects from the application font location. In this case, the application contains a subdirectory named "resources".  
  
 [!code-csharp[FontSnippets#FontsSnippet7](../../../../samples/snippets/csharp/VS_Snippets_Wpf/FontSnippets/CSharp/FontFamilySnippets.xaml.cs#fontssnippet7)]
 [!code-vb[FontSnippets#FontsSnippet7](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/FontSnippets/visualbasic/fontfamilysnippets.xaml.vb#fontssnippet7)]  
  
<a name="creating_a_font_resource_library"></a>   
## Creating a Font Resource Library  
 You can create a resource-only library that contains only fonts—no code is part of this type of library project. Creating a resource-only library is a common technique for decoupling resources from the application code that uses them. This also allows the library assembly to be included with multiple application projects. The following project file example shows the key portions of a resource-only library project.  
  
```xml  
<PropertyGroup>  
  <AssemblyName>FontLibrary</AssemblyName>  
  <OutputType>library</OutputType>  
  ...  
</PropertyGroup>  
...  
<ItemGroup>  
  <Resource Include="Kooten.ttf" />  
  <Resource Include="Pesca.ttf" />  
</ItemGroup  
```  
  
### Referencing a Font in a Resource Library  
 To reference a font in a resource library from your application, you must prefix the font reference with the name of the library assembly. In this case, the font resource assembly is "FontLibrary". To separate the assembly name from the reference within the assembly, use a ';' character. Adding the "Component" keyword followed by the reference to the font name completes the full reference to the font library's resource. The following code example shows how to reference a font in a resource library assembly.  
  
 [!code-xaml[OpenTypeFontsSample#OpenTypeFontsSample1](../../../../samples/snippets/csharp/VS_Snippets_Wpf/OpenTypeFontsSample/CS/Kootenay.xaml#opentypefontssample1)]  
  
> [!NOTE]
>  This SDK contains a set of sample [!INCLUDE[TLA#tla_opentype](../../../../includes/tlasharptla-opentype-md.md)] fonts that you can use with [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] applications. The fonts are defined in a resource-only library. For more information, see [Sample OpenType Font Pack](../../../../docs/framework/wpf/advanced/sample-opentype-font-pack.md).  
  
<a name="limitations_on_font_usage"></a>   
## Limitations on Font Usage  
 The following list describes several limitations on the packaging and use of fonts in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] applications:  
  
-   **Font embedding permission bits:** [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] applications do not check or enforce any font embedding permission bits. See the [Introduction_to_Packing Fonts](#introduction_to_packaging_fonts) section for more information.  
  
-   **Site of origin fonts:** [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] applications do not allow a font reference to an http or ftp [!INCLUDE[TLA#tla_uri](../../../../includes/tlasharptla-uri-md.md)].  
  
-   **Absolute URI using the pack: notation:** [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] applications do not allow you to create a <xref:System.Windows.Media.FontFamily> object programmatically using "pack:" as part of the absolute [!INCLUDE[TLA#tla_uri](../../../../includes/tlasharptla-uri-md.md)] reference to a font. For example, `"pack://application:,,,/resources/#Pericles Light"` is an invalid font reference.  
  
-   **Automatic font embedding:** During design time, there is no support for searching an application's use of fonts and automatically embedding the fonts in the application's resources.  
  
-   **Font subsets:** [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] applications do not support the creation of font subsets for non-fixed documents.  
  
-   In cases where there is an incorrect reference, the application falls back to using an available font.  
  
## See Also  
 <xref:System.Windows.Documents.Typography>  
 <xref:System.Windows.Media.FontFamily>  
 [Microsoft Typography: Links, News, and Contacts](http://www.microsoft.com/typography/links/)  
 [OpenType Specification](http://www.microsoft.com/typography/otspec/)  
 [OpenType Font Features](../../../../docs/framework/wpf/advanced/opentype-font-features.md)  
 [Sample OpenType Font Pack](../../../../docs/framework/wpf/advanced/sample-opentype-font-pack.md)
