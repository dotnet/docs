---
title: "Packaging and deploying custom My extensions (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "My namespace [Visual Basic], customizing"
  - "My namespace"
  - "My namespace [Visual Basic], extending"
ms.assetid: fd89c54b-0290-4c50-95a3-ff17d4487a21
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
---
# Packaging and deploying custom My extensions (Visual Basic)
Visual Basic provides an easy way for you to deploy your custom `My` namespace extensions by using Visual Studio templates. If you are creating a project template for which your `My` extensions are an integral part of the new project type, you can just include your custom `My` extension code with the project when you export the template. For more information about exporting project templates, see [How to: Create Project Templates](/visualstudio/ide/how-to-create-project-templates).  
  
 If your custom `My` extension is in a single code file, you can export the file as an item template that users can add to any type of Visual Basic project. You can then customize the item template to enable additional capabilities and behavior for your custom `My` extension in a Visual Basic project. Those capabilities include the following:  
  
-   Allowing users to manage your custom `My` extension from the **My Extensions** page of the Visual Basic Project Designer.  
  
-   Automatically adding your custom `My` extension when a reference to a specified assembly is added to a project.  
  
-   Hiding the `My` extension item template in the **Add Item** dialog box so that it is not included in the list of project items.  
  
 This topic discusses how to package a custom `My` extension as a hidden item template that can be managed from the **My Extensions** page of the Visual Basic Project Designer. The custom `My` extension can also be added automatically when a reference to a specified assembly is added to a project.  
  
## Create a My namespace extension  
 The first step in creating a deployment package for a custom `My` extension is to create the extension as a single code file. For details and guidance about how to create a custom `My` extension, see [Extending the My Namespace in Visual Basic](../../../visual-basic/developing-apps/customizing-extending-my/extending-the-my-namespace.md).  
  
## Export a My namespace extension as an item template  
 After you have a code file that includes your `My` namespace extension, you can export the code file as a Visual Studio item template. For instructions on how to export a file as a Visual Studio item template, see [How to: Create Item Templates](/visualstudio/ide/how-to-create-item-templates).  
  
> [!NOTE]
>  If your `My` namespace extension has a dependency on a particular assembly, you can customize your item template to automatically install your `My` namespace extension when a reference to that assembly is added. As a result, you will want to exclude that assembly reference when you export the code file as a Visual Studio item template.  
  
## Customize the item template  
 You can enable your item template to be managed from the **My Extensions** page of the Visual Basic Project Designer. You can also enable the item template to be added automatically when a reference to a specified assembly is added to a project. To enable these customizations, you will add a new file, called the CustomData file, to your template, and then add a new element to the XML in your .vstemplate file.  
  
### Add the CustomData file  
 The CustomData file is a text file that has a file name extension of .CustomData (the file name can be set to any value meaningful to your template) and that contains XML. The XML in the CustomData file instructs Visual Basic to include your `My` extension when users use the **My Extensions** page of the Visual Basic Project Designer. You can optionally add the <`AssemblyFullName>` attribute to your CustomData file XML. This instructs Visual Basic to automatically install your custom `My` extension when a reference to a particular assembly is added to the project. You can use any text editor or XML editor to create the CustomData file, and then add it to your item template's compressed folder (.zip file).  
  
 For example, the following XML shows the contents of a CustomData file that will add the template item to the My Extensions folder of a Visual Basic project when a reference to the Microsoft.VisualBasic.PowerPacks.Vs.dll assembly is added to the project.  
  
```xml  
<VBMyExtensionTemplate   
    ID="Microsoft.VisualBasic.Samples.MyExtensions.MyPrinterInfo"   
    Version="1.0.0.0"  
    AssemblyFullName="Microsoft.VisualBasic.PowerPacks.vs"  
/>  
```  
  
 The CustomData file contains a <`VBMyExtensionTemplate>` element that has attributes as listed in the following table.  
  
|Attribute|Description|  
|---|---|  
|`ID`|Required. A unique identifier for the extension. If the extension that has this ID has already been added to the project, the user will not be prompted to add it again.|  
|`Version`|Required. A version number for the item template.|  
|`AssemblyFullName`|Optional. An assembly name. When a reference to this assembly is added to the project, the user will be prompted to add the `My` extension from this item template.|  
  
### Add the \<CustomDataSignature> element to the .vstemplate file  
 To identify your Visual Studio item template as a `My` namespace extension, you must also modify the .vstemplate file for your item template. You must add a `<CustomDataSignature>` element to the `<TemplateData>` element. The `<CustomDataSignature>` element must contain the text `Microsoft.VisualBasic.MyExtension`, as shown in the following example.  
  
```xml  
<CustomDataSignature>Microsoft.VisualBasic.MyExtension</CustomDataSignature>  
```  
  
 You cannot modify files in a compressed folder (.zip file) directly. You must copy the .vstemplate file from the compressed folder, modify it, and then replace the .vstemplate file in the compressed folder with your updated copy.  
  
 The following example shows the contents of a .vstemplate file that has the `<CustomDataSignature>` element added.  
  
```xml  
<VSTemplate Version="2.0.0" xmlns="http://schemas.microsoft.com/developer/vstemplate/2005" Type="Item">  
  <TemplateData>  
    <DefaultName>MyCustomExtensionModule.vb</DefaultName>  
    <Name>MyPrinterInfo</Name>  
    <Description>Custom My Extensions Item Template</Description>  
    <ProjectType>VisualBasic</ProjectType>  
    <SortOrder>10</SortOrder>  
    <Icon>__TemplateIcon.ico</Icon>  
    <CustomDataSignature      >Microsoft.VisualBasic.MyExtension</CustomDataSignature>  
  </TemplateData>  
  <TemplateContent>  
    <References />  
    <ProjectItem SubType="Code"   
                 TargetFileName="$fileinputname$.vb"  
                 ReplaceParameters="true"  
     >MyCustomExtensionModule.vb</ProjectItem>  
  </TemplateContent>  
</VSTemplate>  
```  
  
## Install the template  
 To install the template, you can copy the compressed folder (.zip file) to the Visual Basic item templates folder (for example, My Documents\Visual Studio 2008\Templates\Item Templates\Visual Basic). Alternatively, you can publish the template as a Visual Studio Installer (.vsi) file.  
  
## See also  
 [Extending the My Namespace in Visual Basic](../../../visual-basic/developing-apps/customizing-extending-my/extending-the-my-namespace.md)  
 [Extending the Visual Basic Application Model](../../../visual-basic/developing-apps/customizing-extending-my/extending-the-visual-basic-application-model.md)  
 [Customizing Which Objects are Available in My](../../../visual-basic/developing-apps/customizing-extending-my/customizing-which-objects-are-available-in-my.md)  
 [My Extensions Page, Project Designer](/visualstudio/ide/reference/my-extensions-page-project-designer-visual-basic)
