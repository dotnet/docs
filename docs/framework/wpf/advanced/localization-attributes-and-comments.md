---
title: "Localization Attributes and Comments"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "localization [WPF], attributes"
  - "localization [WPF], comments"
ms.assetid: ead2d9ac-b709-4ec1-a924-39927a29d02f
caps.latest.revision: 15
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Localization Attributes and Comments
[!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] localization comments are properties, inside [!INCLUDE[TLA#tla_titlexaml](../../../../includes/tlasharptla-titlexaml-md.md)] source code, supplied by developers to provide rules and hints for localization. [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] localization comments contain two sets of information: localizability attributes and free-form localization comments. Localizability attributes are used by the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] Localization API to indicate which resources are to be localized. Free-form comments are any information that the application author wants to include.  
  

  
<a name="Localizer_Comments_"></a>   
## Localization Comments  
 If markup application authors have requirements for specific elements in [!INCLUDE[TLA#tla_titlexaml](../../../../includes/tlasharptla-titlexaml-md.md)], such as constraints on text length, font family, or font size, they can convey this information to localizers with comments in the [!INCLUDE[TLA#tla_titlexaml](../../../../includes/tlasharptla-titlexaml-md.md)] code. The process for adding comments to source code is as follows:  
  
1.  Application developer adds localization comments to [!INCLUDE[TLA#tla_titlexaml](../../../../includes/tlasharptla-titlexaml-md.md)] source code.  
  
2.  During the build process, you can specify in the .proj file whether to leave the free-form localization comments in the assembly, strip out part of the comments, or strip out all the comments. The stripped-out comments are placed in a separate file. You specify your option using a `LocalizationDirectivesToLocFile` tag, eg:  
  
     `<LocalizationDirectivesToLocFile>` *value* `</LocalizationDirectivesToLocFile>`  
  
3.  The values that can be assigned are:  
  
    -   **None** - Both comments and attributes stay inside the assembly and no separate file is generated.  
  
    -   **CommentsOnly** - Strips only the comments from the assembly and places them in the separate LocFile.  
  
    -   **All** - Strips both the comments and the attributes from the assembly and places them both in a separate LocFile.  
  
4.  When localizable resources are extracted from [!INCLUDE[TLA2#tla_baml](../../../../includes/tla2sharptla-baml-md.md)], the localizability attributes are respected by the [!INCLUDE[TLA2#tla_baml](../../../../includes/tla2sharptla-baml-md.md)] Localization API.  
  
5.  Localization comment files, containing only free-form comments, are incorporated into the localization process at a later time.  
  
 The following example shows how to add localization comments to a [!INCLUDE[TLA#tla_titlexaml](../../../../includes/tlasharptla-titlexaml-md.md)] file.  
  
 `<TextBlock x:Id = "text01"`  
  
 `FontFamily = "Microsoft Sans Serif"`  
  
 `FontSize = "12"`  
  
 `Localization.Attributes = "$Content (Unmodifiable Readable Text)`  
  
 `FontFamily (Unmodifiable Readable)"`  
  
 `Localization.Comments = "$Content (Trademark)`  
  
 `FontSize (Trademark font size)" >`  
  
 `Microsoft`  
  
 `</TextBlock>`  
  
 In the previous sample the Localization.Attributes section contains the localization attributes and the Localization.Comments section the free-form comments. The following tables show the attributes and comments and their meaning to the localizer.  
  
|Localization attributes|Meaning|  
|-----------------------------|-------------|  
|$Content (Unmodifiable Readable Text)|Contents of the TextBlock element cannot be modified. Localizers cannot change the word "Microsoft". The content is visible (Readable) to the localizer. The category of the content is text.|  
|FontFamily (Unmodifiable Readable)|The font family property of the TextBlock element cannot be changed but it is visible to the localizer.|  
  
|Localization free-form comments|Meaning|  
|--------------------------------------|-------------|  
|$Content (Trademark)|The application author tells the localizer that the content in the TextBlock element is a trademark.|  
|FontSize (Trademark font size)|The application author indicates that the font size property should follow the standard trademark size.|  
  
### Localizability Attributes  
 The information in Localization.Attributes contains a list of pairs: the targeted value name and the associated localizability values. The target name can be a property name or the special $Content name. If it is a property name, the targeted value is the value of the property. If it is $Content, the target value is the content of the element.  
  
 There are three types of attributes:  
  
-   **Category**. This specifies whether a value should be modifiable from a localizer tool. See <xref:System.Windows.LocalizabilityAttribute.Category%2A>.  
  
-   **Readability**. This specifies whether a localizer tool should read (and display) a value. See <xref:System.Windows.LocalizabilityAttribute.Readability%2A>.  
  
-   **Modifiability**. This specifies whether a localizer tool allows a value to be modified. See <xref:System.Windows.LocalizabilityAttribute.Modifiability%2A>.  
  
 These attributes can be specified in any order delimited by a space. In case duplicate attributes are specified, the last attribute will override former ones. For example, Localization.Attributes = "Unmodifiable Modifiable" sets Modifiability to Modifiable because it is the last value.  
  
 Modifiability and Readability are self-explanatory. The Category attribute provides predefined categories that help the localizer when translating text. Categories, such as, Text, Label, and Title give the localizer information about how to translate the text. There are also special categories: None, Inherit, Ignore, and NeverLocalize.  
  
 The following table shows the meaning of the special categories.  
  
|Category|Meaning|  
|--------------|-------------|  
|None|Targeted value has no defined category.|  
|Inherit|Targeted value inherits its category from its parent.|  
|Ignore|Targeted value is ignored in the localization process. Ignore affects only the current value. It will not affect child nodes.|  
|NeverLocalize|Current value cannot be localized. This category is inherited by the children of an element.|  
  
<a name="Localization_Comments"></a>   
## Localization Comments  
 Localization.Comments contains free-form strings concerning the targeted value. Application developers can add information to give localizers hints about how the applications text should be translated. The format of the comments can be any string surrounded by "()". Use '\\' to escape characters.  
  
## See Also  
 [Globalization for WPF](../../../../docs/framework/wpf/advanced/globalization-for-wpf.md)  
 [Use Automatic Layout to Create a Button](../../../../docs/framework/wpf/advanced/how-to-use-automatic-layout-to-create-a-button.md)  
 [Use a Grid for Automatic Layout](../../../../docs/framework/wpf/advanced/how-to-use-a-grid-for-automatic-layout.md)  
 [Localize an Application](../../../../docs/framework/wpf/advanced/how-to-localize-an-application.md)
