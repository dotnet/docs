---
title: "How to: Use Resources in Localizable Applications"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "applications [WPF], localizable"
  - "localizable applications [WPF]"
ms.assetid: 08539ad6-7fca-4f34-b82b-ff439e11dfa7
---
# How to: Use resources in localizable apps

Localization means to adapt a user interface to different cultures. To do this, text such as titles, captions, and list box items must be translated. To make translation easier, the items to be translated are collected into resource files. See [Localize an app](how-to-localize-an-application.md) for information on how to create a resource file for localization. To make a WPF application localizable, developers need to build all the localizable resources into a resource assembly. The resource assembly is localized into different languages, and the code-behind uses resource management API to load.

## Example

One of the files required for a WPF application is a project file (.proj). All resources that you use in your application should be included in the project file. The following XAML example shows this.

```xaml
<Resource Include="data\picture1.jpg"/>  
<EmbeddedResource Include="data\stringtable.en-US.restext"/>
```

To use a resource in your application, instantiate <xref:System.Resources.ResourceManager> and load the resource you want to use. The following C# code demonstrates how to do this.

[!code-csharp[LocalizationResources#2](~/samples/snippets/csharp/VS_Snippets_Wpf/LocalizationResources/CSharp/page1.xaml.cs#2)]

## See also

- [Localize an app](how-to-localize-an-application.md)
