---
title: "App Resources for Libraries That Target Multiple Platforms"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "multiple platforms, resources for"
  - "resources [.NET Framework]"
  - ".NET Framework, resources when targeting multiple platforms"
  - "resources, for multiple platforms"
  - "targeting multiple platforms, resources for"
ms.assetid: 72c76f0b-7255-4576-9261-3587f949669c
caps.latest.revision: 20
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# App Resources for Libraries That Target Multiple Platforms
You can use the .NET Framework [Portable Class Library](../../../docs/standard/cross-platform/cross-platform-development-with-the-portable-class-library.md) project type to ensure that resources in your class libraries can be accessed from multiple platforms. This project type is available in [!INCLUDE[vs_dev11_long](../../../includes/vs-dev11-long-md.md)] and targets the portable subset of the .NET Framework class library. Using  a [!INCLUDE[net_portable](../../../includes/net-portable-md.md)] ensures that your library can be accessed from desktop apps, Silverlight apps, Windows Phone apps, and [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] apps.  
  
 The [!INCLUDE[net_portable](../../../includes/net-portable-md.md)] project makes only a very limited subset of the types in the <xref:System.Resources> namespace available to your application, but it does allow you to use the <xref:System.Resources.ResourceManager> class to retrieve resources. However, if you are creating an app by using Visual Studio, you should use the strongly typed wrapper created by Visual Studio instead of using the <xref:System.Resources.ResourceManager> class directly.  
  
 To create a strongly typed wrapper in Visual Studio, set the main resource file's **Access Modifier** in the Visual Studio Resource Designer to **Public**. This creates a [resourceFileName].designer.cs or [resourceFileName].designer.vb file that contains the strongly typed ResourceManager wrapper. For more information about using a strongly typed resource wrapper, see the "Generating a Strongly Typed Resource Class" section in the [Resgen.exe (Resource File Generator)](../../../docs/framework/tools/resgen-exe-resource-file-generator.md) topic.  
  
## Resource Manager in the [!INCLUDE[net_portable](../../../includes/net-portable-md.md)]  
 In a [!INCLUDE[net_portable](../../../includes/net-portable-md.md)] project, all access to resources is handled by the <xref:System.Resources.ResourceManager> class. Because types in the <xref:System.Resources> namespace, such as <xref:System.Resources.ResourceReader> and <xref:System.Resources.ResourceSet>, are not accessible from a [!INCLUDE[net_portable](../../../includes/net-portable-md.md)] project, they cannot be used to access resources.  
  
 The [!INCLUDE[net_portable](../../../includes/net-portable-md.md)] project includes the four <xref:System.Resources.ResourceManager> members listed in the following table. These constructors and methods enable you to instantiate a <xref:System.Resources.ResourceManager> object and retrieve string resources.  
  
|`ResourceManager` member|Description|  
|------------------------------|-----------------|  
|<xref:System.Resources.ResourceManager.%23ctor%28System.String%2CSystem.Reflection.Assembly%29>|Creates a <xref:System.Resources.ResourceManager> instance to access the named resource file found in the specified assembly.|  
|<xref:System.Resources.ResourceManager.%23ctor%28System.Type%29>|Creates a <xref:System.Resources.ResourceManager> instance that corresponds to the specified type.|  
|<xref:System.Resources.ResourceManager.GetString%28System.String%29>|Retrieves a named resource for the current culture.|  
|<xref:System.Resources.ResourceManager.GetString%28System.String%2CSystem.Globalization.CultureInfo%29>|Retrieves a named resource belonging to the specified culture.|  
  
 The exclusion of other <xref:System.Resources.ResourceManager> members from the [!INCLUDE[net_portable](../../../includes/net-portable-md.md)] means that serialized objects, non-string data, and images cannot be retrieved from a resource file. To use resources from a [!INCLUDE[net_portable](../../../includes/net-portable-md.md)], you should store all  object data in string form. For example, you can store numeric values in a resource file by converting them to strings, and you can retrieve them and then convert them back to numbers by using the numeric data type's `Parse` or `TryParse` method. You can convert images or other binary data to a string representation by calling the <xref:System.Convert.ToBase64String%2A?displayProperty=nameWithType> method, and restore them to a byte array by calling the <xref:System.Convert.FromBase64String%2A?displayProperty=nameWithType> method.  
  
## The [!INCLUDE[net_portable](../../../includes/net-portable-md.md)] and Windows Store Apps  
 [!INCLUDE[net_portable](../../../includes/net-portable-md.md)] projects store resources in .resx files, which are then compiled into .resources files and embedded in the main assembly or in satellite assemblies at compile time. [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] apps, on the other hand, require resources to be stored in .resw files, which are then compiled into a single package resource index (PRI) file. However, despite the incompatible file formats, your [!INCLUDE[net_portable](../../../includes/net-portable-md.md)] will work in a [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] app.  
  
 To consume your class library from a [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] app, add a reference to it in your Windows Store app project. Visual Studio will transparently extract the resources from your assembly into a .resw file and use it to generate a PRI file from which the [!INCLUDE[wrt](../../../includes/wrt-md.md)] can extract resources. At run time, the [!INCLUDE[wrt](../../../includes/wrt-md.md)] executes the code in your [!INCLUDE[net_portable](../../../includes/net-portable-md.md)], but it retrieves your Portable Class Library's resources from the PRI file.  
  
 If your [!INCLUDE[net_portable](../../../includes/net-portable-md.md)] project includes localized resources, you use the hub-and-spoke model to deploy them just as you would for a library in a desktop app. To consume your main resource file and any localized resource files in your [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] app, you add a reference to the main assembly. At compile time, Visual Studio extracts the resources from your main resource file and any localized resource files into separate .resw files. It then compiles the .resw files into a single PRI file that the [!INCLUDE[wrt](../../../includes/wrt-md.md)] accesses at run time.  
  
<a name="NonLoc"></a>   
## Example: Non-Localized [!INCLUDE[net_portable](../../../includes/net-portable-md.md)]  
 The following simple, non-localized [!INCLUDE[net_portable](../../../includes/net-portable-md.md)] example uses resources to store the names of columns and to determine the number of characters to reserve for tabular data. The example uses a file named LibResources.resx to store the string resources listed in the following table.  
  
|Resource name|Resource value|  
|-------------------|--------------------|  
|Born|Birthdate|  
|BornLength|12|  
|Hired|Hire Date|  
|HiredLength|12|  
|ID|ID|  
|ID.Length|12|  
|Name|Name|  
|NameLength|25|  
|Title|Employee Database|  
  
 The following code defines a `UILibrary` class that uses the Resource Manager wrapper named `resources` generated by Visual Studio when the **Access Modifier** for the file is changed to **Public**. The UILibrary class parses the string data as necessary. . Note that the class is in the `MyCompany.Employees` namespace.  
  
 [!code-csharp[Conceptual.Resources.Portable#1](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.resources.portable/cs/uilibrary.cs#1)]
 [!code-vb[Conceptual.Resources.Portable#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.resources.portable/vb/uilibrary.vb#1)]  
  
 The following code illustrates how the `UILibrary` class and its resources can be accessed from a console-mode app. It requires a reference to UILIbrary.dll to be added to the console app project.  
  
 [!code-csharp[Conceptual.Resources.Portable#2](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.resources.portable/cs/program.cs#2)]
 [!code-vb[Conceptual.Resources.Portable#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.resources.portable/vb/module1.vb#2)]  
  
 The following code illustrates how the `UILibrary` class and its resources can be accessed from a [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] app. It requires a reference to UILIbrary.dll to be added to the Windows Store app project.  
  
 [!code-csharp[Conceptual.Resources.PortableMetro#1](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.resources.portablemetro/cs/blankpage.xaml.cs#1)]  
  
## Example: Localized [!INCLUDE[net_portable](../../../includes/net-portable-md.md)]  
 The following localized [!INCLUDE[net_portable](../../../includes/net-portable-md.md)] example includes resources for the French (France) and English (United States) cultures. The English (United States) culture is the app's default culture; its resources are shown in the table in the [previous section](../../../docs/standard/cross-platform/app-resources-for-libraries-that-target-multiple-platforms.md#NonLoc). The resources file for the French (France) culture is named LibResources.fr-FR.resx and consists of the string resources listed in the following table. The source code for the `UILibrary` class is the same as that shown in the previous section.  
  
|Resource name|Resource value|  
|-------------------|--------------------|  
|Born|Date de naissance|  
|BornLength|20|  
|Hired|Date embauché|  
|HiredLength|16|  
|ID|ID|  
|Name|Nom|  
|Title|Base de données des employés|  
  
 The following code illustrates how the `UILibrary` class and its resources can be accessed from a console-mode app. It requires a reference to UILIbrary.dll to be added to the console app project.  
  
 [!code-csharp[Conceptual.Resources.Portable#3](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.resources.portable/cs/program2.cs#3)]
 [!code-vb[Conceptual.Resources.Portable#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.resources.portable/vb/module2.vb#3)]  
  
 The following code illustrates how the `UILibrary` class and its resources can be accessed from a [!INCLUDE[win8_appname_long](../../../includes/win8-appname-long-md.md)] app. It requires a reference to UILIbrary.dll to be added to the Windows Store app project. It uses the static `ApplicationLanguages.PrimaryLanguageOverride` property to set the app's preferred language to French.  
  
 [!code-csharp[Conceptual.Resources.PortableMetroLoc#1](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.resources.portablemetroloc/cs/blankpage.xaml.cs#1)]
 [!code-vb[Conceptual.Resources.PortableMetroLoc#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.resources.portablemetroloc/vb/blankpage.xaml.vb#1)]  
  
## See Also  
 <xref:System.Resources.ResourceManager>  
 [Resources in Desktop Apps](../../../docs/framework/resources/index.md)  
 [Packaging and Deploying Resources](../../../docs/framework/resources/packaging-and-deploying-resources-in-desktop-apps.md)
