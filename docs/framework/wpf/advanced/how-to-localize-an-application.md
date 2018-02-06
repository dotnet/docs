---
title: "How to: Localize an Application"
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "localization [WPF], applications"
  - "LocBaml tool [WPF]"
  - "applications [WPF], localizing"
ms.assetid: 5001227e-9326-48a4-9dcd-ba1b89ee6653
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Localize an Application
This tutorial explains how to create a localized application by using the LocBaml tool.  
  
> [!NOTE]
>  The LocBaml tool is not a production-ready application. It is presented as a sample that uses some of the localization APIs and illustrates how you might write a localization tool.  
  
<a name="Introduction"></a>   
## Overview  
 This discussion gives you a step-by-step approach to localizing an application. First, you will prepare your application so that the text that will be translated can be extracted. After the text is translated, you will merge the translated text into a new copy of the original application.  
  
<a name="Requirements"></a>   
## Requirements  
 Over the course of this discussion, you will use [!INCLUDE[TLA#tla_msbuild](../../../../includes/tlasharptla-msbuild-md.md)], which is a compiler that runs from the command line.  
  
 Also, you will be instructed to use a project file. For instructions on how to use [!INCLUDE[TLA2#tla_msbuild](../../../../includes/tla2sharptla-msbuild-md.md)] and project files, see [Build and Deploy](../../../../docs/framework/wpf/app-development/building-and-deploying-wpf-applications.md).  
  
 All the examples in this discussion use en-US (English-US) as the culture. This enables you to work through the steps of the examples without installing a different language.  
  
<a name="create_sample_app"></a>   
## Create a Sample Application  
 In this step, you will prepare your application for localization. In the [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] samples, a HelloApp sample is supplied that will be used for the code examples in this discussion. If you would like to use this sample, download the [!INCLUDE[TLA#tla_xaml](../../../../includes/tlasharptla-xaml-md.md)] files from the [LocBaml Tool Sample](http://go.microsoft.com/fwlink/?LinkID=160016).  
  
1.  Develop your application to the point where you want to start localization.  
  
2.  Specify the development language in the project file so that [!INCLUDE[TLA2#tla_msbuild](../../../../includes/tla2sharptla-msbuild-md.md)] generates a main assembly and a satellite assembly (a file with the .resources.dll extension) to contain the neutral language resources. The project file in the HelloApp sample is HelloApp.csproj. In that file, you will find the development language identified as follows:  
  
     `<UICulture>en-US</UICulture>`  
  
3.  Add Uids to your [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] files. Uids are used to keep track of changes to files and to identify items that must be translated. To add Uids to your files, run **updateuid** on your project file:  
  
     **msbuild /t:updateuid helloapp.csproj**  
  
     To verify that you have no missing or duplicate Uids, run **checkuid**:  
  
     **msbuild /t:checkuid helloapp.csproj**  
  
     After running **updateuid**, your files should contain Uids. For example, in the Pane1.xaml file of HelloApp, you should find the following:  
  
     `<StackPanel x:Uid="StackPanel_1">`  
  
     `<TextBlock x:Uid="TextBlock_1">Hello World</TextBlock>`  
  
     `<TextBlock x:Uid="TextBlock_2">Goodbye World</TextBlock>`  
  
     `</StackPanel>`  
  
<a name="create_dll"></a>   
## Create the Neutral Language Resources Satellite Assembly  
 After the application is configured to generate a neutral language resources satellite assembly, you build the application. This generates the main application assembly, as well as the neutral language resources satellite assembly that is required by LocBaml for localization. To build the application:  
  
1.  Compile HelloApp to create a [!INCLUDE[TLA#tla_dll](../../../../includes/tlasharptla-dll-md.md)]:  
  
     **msbuild helloapp.csproj**  
  
2.  The newly created main application assembly, HelloApp.exe, is created in the following folder:  
  
     `C:\HelloApp\Bin\Debug\`  
  
3.  The newly created neutral language resources satellite assembly, HelloApp.resources.dll, is created in the following folder:  
  
     `C:\HelloApp\Bin\Debug\en-US\`  
  
<a name="build_locbaml"></a>   
## Build the LocBaml Tool  
  
1.  All the files necessary to build LocBaml are located in the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] samples. Download the [!INCLUDE[TLA#tla_lhcshrp](../../../../includes/tlasharptla-lhcshrp-md.md)] files from the [LocBaml Tool Sample](http://go.microsoft.com/fwlink/?LinkID=160016).  
  
2.  From the command line, run the project file (locbaml.csproj) to build the tool:  
  
     **msbuild locbaml.csproj**  
  
3.  Go to the Bin\Release directory to find the newly created executable file (locbaml.exe). Example:C:\LocBaml\Bin\Release\locbaml.exe.  
  
4.  The options that you can specify when you run LocBaml are as follows:  
  
    -   **parse** or **-p:** Parses Baml, resources, or [!INCLUDE[TLA2#tla_dll](../../../../includes/tla2sharptla-dll-md.md)] files to generate a .csv or .txt file.  
  
    -   **generate** or **-g:** Generates a localized binary file by using a translated file.  
  
    -   **out** or **-o** {*filedirectory*] **:** Output file name.  
  
    -   **culture** or **-cul** {*culture*] **:** Locale of output assemblies.  
  
    -   **translation** or **-trans** {*translation.csv*] **:** Translated or localized file.  
  
    -   **asmpath** or **-asmpath:** {*filedirectory*] **:** If your [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] code contains custom controls, you must supply the **asmpath** to the custom control assembly.  
  
    -   **nologo:** Displays no logo or copyright information.  
  
    -   **verbose:** Displays verbose mode information.  
  
    > [!NOTE]
    >  If you need a list of the options when you are running the tool, type     **LocBaml.exe** and press ENTER.  
  
<a name="parse_dll"></a>   
## Use LocBaml to Parse a File  
 Now that you have created the LocBaml tool, you are ready to use it to parse HelloApp.resources.dll to extract the text content that will be localized.  
  
1.  Copy LocBaml.exe to your application's bin\debug folder, where the main application assembly was created.  
  
2.  To parse the satellite assembly file and store the output as a .csv file, use the following command:  
  
     **LocBaml.exe /parse HelloApp.resources.dll /out:Hello.csv**  
  
    > [!NOTE]
    >  If the input file, HelloApp.resources.dll, is not in the same directory as LocBaml.exe move one of the files so that both files are in the same directory.  
  
3.  When you run LocBaml to parse files, the output consists of seven fields delimited by commas (.csv files) or tabs (.txt files). The following shows the parsed .csv file for the HelloApp.resources.dll:

   | |
   |-|
   |HelloApp.g.en-US.resources:window1.baml,Stack1:System.Windows.Controls.StackPanel.$Content,Ignore,FALSE, FALSE,,#Text1;#Text2;|
   |HelloApp.g.en-US.resources:window1.baml,Text1:System.Windows.Controls.TextBlock.$Content,None,TRUE, TRUE,,Hello World|
   |HelloApp.g.en-US.resources:window1.baml,Text2:System.Windows.Controls.TextBlock.$Content,None,TRUE, TRUE,,Goodbye World|

   The seven fields are:  
  
   1.  **BAML Name**. The name of the BAML resource with respect to the source language satellite assembly.  
  
   2.  **Resource Key**. The localized resource identifier.  
  
   3.  **Category**. The value type. See [Localization Attributes and Comments](../../../../docs/framework/wpf/advanced/localization-attributes-and-comments.md).  
  
   4.  **Readability**. Whether the value can be read by a localizer. See [Localization Attributes and Comments](../../../../docs/framework/wpf/advanced/localization-attributes-and-comments.md).  
  
   5.  **Modifiability**. Whether the value can be modified by a localizer. See [Localization Attributes and Comments](../../../../docs/framework/wpf/advanced/localization-attributes-and-comments.md).  
  
   6.  **Comments**. Additional description of the value to help determine how a value is localized. See [Localization Attributes and Comments](../../../../docs/framework/wpf/advanced/localization-attributes-and-comments.md).  
  
   7.  **Value**. The text value to translate to the desired culture.  
  
   The following table shows how these fields map to the delimited values of the .csv file:  
  
   |BAML name|Resource key|Category|Readability|Modifiability|Comments|Value|  
   |---------------|------------------|--------------|-----------------|-------------------|--------------|-----------|
   |HelloApp.g.en-US.resources:window1.baml|Stack1:System.Windows.Controls.StackPanel.$Content|Ignore|FALSE|FALSE||#Text1;#Text2|
   |HelloApp.g.en-US.resources:window1.baml|Text1:System.Windows.Controls.TextBlock.$Content|None|TRUE|TRUE||Hello World|
   |HelloApp.g.en-US.resources:window1.baml|Text2:System.Windows.Controls.TextBlock.$Content|None|TRUE|TRUE||Goodbye World|
  
   Notice that all the values for the **Comments** field contain no values; if a field doesn't have a value, it is empty. Also notice that the item in the first row is neither readable nor modifiable, and has "Ignore" as its **Category** value, all of which indicates that the value is not localizable.  
  
4.  To facilitate discovery of localizable items in parsed files, particularly in large files, you can sort or filter the items by **Category**, **Readability**, and **Modifiability**. For example, you can filter out unreadable and unmodifiable values.  
  
<a name="translate_loc_content"></a>   
## Translate the Localizable Content  
 Use any tool that you have available to translate the extracted content. A good way to do this is to write the resources to a .csv file and view them in [!INCLUDE[TLA#tla_xl](../../../../includes/tlasharptla-xl-md.md)], making translation changes to the last column (value).  
  
<a name="merge_translations"></a>   
## Use LocBaml to Generate a New .resources.dll File  
 The content that was identified by parsing HelloApp.resources.dll with LocBaml has been translated and must be merged back into the original application. Use the **generate** or **-g** option to generate a new .resources.dll file.  
  
1.  Use the following syntax to generate a new HelloApp.resources.dll file. Mark the culture as en-US (/cul:en-US).  
  
     **LocBaml.exe /generate HelloApp.resources.dll /trans:Hello.csv /out:c:\ /cul:en-US**  
  
    > [!NOTE]
    >  If the input file, Hello.csv, is not in the same directory as the executable, LocBaml.exe, move one of the files so that both files are in the same directory.  
  
2.  Replace the old HelloApp.resources.dll file in the C:\HelloApp\Bin\Debug\en-US\HelloApp.resources.dll directory with your newly created HelloApp.resources.dll file.  
  
3.  "Hello World" and "Goodbye World" should now be translated in your application.  
  
4.  To translate to a different culture, use the culture of the language that you are translating to. The following example shows how to translate to French-Canadian:  
  
     **LocBaml.exe /generate HelloApp.resources.dll /trans:Hellofr-CA.csv /out:c:\ /cul:fr-CA**  
  
5.  In the same assembly as the main application assembly, create a new culture-specific folder to house the new satellite assembly. For French-Canadian, the folder would be fr-CA.  
  
6.  Copy the generated satellite assembly to the new folder.  
  
7.  To test the new satellite assembly, you need to change the culture under which your application will run. You can do this in one of two ways:  
  
    -   Change your operating system's regional settings (**Start** &#124; **Control Panel** &#124; **Regional and Language Options**).  
  
    -   In your application, add the following code to App.xaml.cs:  
  
   [!code-xaml[LocBamlChangeCultureSnippets#LocBamlChangeCultureMARKUP](../../../../samples/snippets/csharp/VS_Snippets_Wpf/LocBamlChangeCultureSnippets/CSharp/App.xaml#locbamlchangeculturemarkup)]
   [!code-csharp[LocBamlChangeCultureSnippets#LocBamlChangeCultureCODEBEHIND](../../../../samples/snippets/csharp/VS_Snippets_Wpf/LocBamlChangeCultureSnippets/CSharp/App.xaml.cs#locbamlchangeculturecodebehind)]
   [!code-vb[LocBamlChangeCultureSnippets#LocBamlChangeCultureCODEBEHIND](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/LocBamlChangeCultureSnippets/VisualBasic/Application.xaml.vb#locbamlchangeculturecodebehind)]  
  
<a name="Some_Tips_for_Using_LocBaml"></a>   
## Some Tips for Using LocBaml  
  
-   All dependent assemblies that define custom controls must be copied into the local directory of LocBaml or installed into the GAC. This is necessary because the localization API must have access to the dependent assemblies when it reads the [!INCLUDE[TLA#tla_baml](../../../../includes/tlasharptla-baml-md.md)].  
  
-   If the main assembly is signed, the generated resource DLL must also be signed in order for it to be loaded.  
  
-   The version of the localized resource DLL needs to be synchronized with the main assembly.  
  
<a name="Whats_Next"></a>   
## What's Next  
 You should now have a basic understanding of how to use the LocBaml tool.  You should be able to make a file that contains Uids. By using the LocBaml tool, you should be able to parse a file to extract the localizable content, and after the content is translated, you should be able to generate a .resources.dll file that merges the translated content. This topic does not include every possible detail, but you now have the knowledge necessary to use LocBaml for localizing your applications.  
  
## See Also  
 [Globalization for WPF](../../../../docs/framework/wpf/advanced/globalization-for-wpf.md)  
 [Use Automatic Layout Overview](../../../../docs/framework/wpf/advanced/use-automatic-layout-overview.md)
