---
title: "Composition Analysis Tool (Mefx)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "Composition Analysis Tool [MEF]"
  - "MEF, Composition Analysis Tool"
  - "Mefx [MEF], Composition Analysis Tool"
ms.assetid: c48a7f93-83bb-4a06-aea0-d8e7bd1502ad
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Composition Analysis Tool (Mefx)
The Composition Analysis Tool (Mefx) is a command-line application that analyzes library (.dll) and application (.exe) files containing Managed Extensibility Framework (MEF) parts. The primary purpose of Mefx is to provide developers a way to diagnose composition failures in their MEF applications without the requirement to add cumbersome tracing code to the application itself. It can also be useful to help understand parts from a library provided by a third party. This topic describes how to use Mefx and provides a reference for its syntax.  
  
<a name="getting_mefx"></a>   
## Getting Mefx  
 Mefx is available on GitHub at [Managed Extensibility Framework](https://github.com/MicrosoftArchive/mef/releases/tag/4.0). Simply download and unzip the tool.  
  
<a name="basic_syntax"></a>   
## Basic Syntax  
 Mefx is invoked from the command line in the following format:  
  
```  
mefx [files and directories] [action] [options]  
```  
  
 The first set of arguments specify the files and directories from which to load parts for analysis. Specify a file with the `/file:` switch, and a directory with the `/directory:` switch. You can specify multiple files or directories, as shown in the following example:  
  
```  
mefx /file:MyAddIn.dll /directory:Program\AddIns [action...]  
```  
  
> [!NOTE]
>  Each .dll or .exe should only be loaded one time. If a file is loaded multiple times, the tool may return incorrect information.  
  
 After the list of files and directories, you must specify a command, and any options for that command.  
  
<a name="listing_available_parts"></a>   
## Listing Available Parts  
 Use the `/parts` action to list all the parts declared in the files loaded. The result is a simple list of part names.  
  
```  
mefx /file:MyAddIn.dll /parts  
MyAddIn.AddIn  
MyAddIn.MemberPart  
```  
  
 For more information about the parts, use the `/verbose` option. This will output more information for all available parts. To get more information about a single part, use the `/type` action instead of `/parts`.  
  
```  
mefx /file:MyAddIn.dll /type:MyAddIn.AddIn /verbose  
[Part] MyAddIn.MemberPart from: AssemblyCatalog (Assembly=" MyAddIn, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")  
  [Export] MyAddIn.MemberPart (ContractName=" MyAddIn.MemberPart")  
```  
  
<a name="listing_imports_and_exports"></a>   
## Listing Imports and Exports  
 The `/imports` and `/exports` actions will list all the imported parts and all the exported parts, respectively. You can also list the parts that import or export a particular type by using the `/importers` or `/exporters` actions.  
  
```  
mefx /file:MyAddIn.dll /importers:MyAddin.MemberPart  
MyAddin.AddIn  
```  
  
 You can also apply the `/verbose` option to these actions.  
  
<a name="finding_rejected_parts"></a>   
## Finding Rejected Parts  
 Once it has loaded the available parts, Mefx uses the MEF composition engine to compose them. Parts that cannot be successfully composed are referred to as *rejected*. To list all the rejected parts, use the `/rejected` action.  
  
 You can use the `/verbose` option with the `/rejected` action to print detailed information about rejected parts. In the following example, the `ClassLibrary1` DLL contains the `AddIn` part, which imports the `MemberPart` and `ChainOne` parts. `ChainOne` imports `ChainTwo`, but `ChainTwo` does not exist. This means that `ChainOne` is rejected, which causes `AddIn` to be rejected.  
  
```  
mefx /file:ClassLibrary1.dll /rejected /verbose  
```  
  
 The following shows the complete output of the previous command:  
  
```  
[Part] ClassLibrary1.AddIn from: AssemblyCatalog (Assembly="ClassLibrary1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")  
  [Export] ClassLibrary1.AddIn (ContractName="ClassLibrary1.AddIn")  
  [Import] ClassLibrary1.AddIn.memberPart (ContractName="ClassLibrary1.MemberPart")  
    [SatisfiedBy] ClassLibrary1.MemberPart (ContractName="ClassLibrary1.MemberPart") from: ClassLibrary1.MemberPart from: AssemblyCatalog (Assembly="ClassLibrar  
y1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")  
  [Import] ClassLibrary1.AddIn.chain (ContractName="ClassLibrary1.ChainOne")  
    [Exception] System.ComponentModel.Composition.ImportCardinalityMismatchException: No valid exports were found that match the constraint '((exportDefinition.ContractName == "ClassLibrary1.ChainOne") AndAlso (exportDefinition.Metadata.ContainsKey("ExportTypeIdentity") AndAlso "ClassLibrary1.ChainOne".Equals(exportDefinition.Metadata.get_Item("ExportTypeIdentity"))))', invalid exports may have been rejected.  
   at System.ComponentModel.Composition.Hosting.ExportProvider.GetExports(ImportDefinition definition, AtomicComposition atomicComposition)  
   at Microsoft.ComponentModel.Composition.Diagnostics.CompositionInfo.AnalyzeImportDefinition(ExportProvider host, IEnumerable`1 availableParts, ImportDefinition id)  
    [Unsuitable] ClassLibrary1.ChainOne (ContractName="ClassLibrary1.ChainOne")  
from: ClassLibrary1.ChainOne from: AssemblyCatalog (Assembly="ClassLibrary1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")  
      [Because] PartDefinitionIsRejected, The part providing the export is rejected because of other issues.  
  
[Part] ClassLibrary1.ChainOne from: AssemblyCatalog (Assembly="ClassLibrary1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")  
  [Primary Rejection]  
  [Export] ClassLibrary1.ChainOne (ContractName="ClassLibrary1.ChainOne")  
  [Import] ClassLibrary1.ChainOne.chain (ContractName="ClassLibrary1.ChainTwo")  
    [Exception] System.ComponentModel.Composition.ImportCardinalityMismatchException: No valid exports were found that match the constraint '((exportDefinition.ContractName == "ClassLibrary1.ChainTwo") AndAlso (exportDefinition.Metadata.ContainsKey("ExportTypeIdentity") AndAlso "ClassLibrary1.ChainTwo".Equals(exportDefinition.Metadata.get_Item("ExportTypeIdentity"))))', invalid exports may have been rejected.  
   at System.ComponentModel.Composition.Hosting.ExportProvider.GetExports(ImportDefinition definition, AtomicComposition atomicComposition)  
   at Microsoft.ComponentModel.Composition.Diagnostics.CompositionInfo.AnalyzeImportDefinition(ExportProvider host, IEnumerable`1 availableParts, ImportDefinition id)  
```  
  
 The interesting information is contained in the `[Exception]` and `[Unsuitable]` results. The `[Exception]` result provides information about why a part was rejected. The `[Unsuitable]` result indicates why an otherwise-matching part could not be used to fill an import; in this case, because that part was itself rejected for missing imports.  
  
<a name="analyzing_primary_causes"></a>   
## Analyzing Primary Causes  
 If several parts are linked in a long dependency chain, a problem involving a part near the bottom may cause the entire chain to be rejected. Diagnosing these problems can be difficult because the root cause of the failure is not always obvious. To help with the problem, you can use the `/causes` action, which attempts to find the root cause of any cascading rejection.  
  
 Using the `/causes` action on the previous example would list only information for `ChainOne`, whose unfilled import is the root cause of the rejection of `AddIn`. The `/causes` action can be used in both normal and `/verbose` options.  
  
> [!NOTE]
>  In most cases, Mefx will be able to diagnose the root cause of a cascading failure. However, in cases where parts are added programmatically to a container, cases involving hierarchical containers, or cases involving custom `ExportProvider` implementations, Mefx will not be able to diagnose the cause. In general, the previously described cases should be avoided where possible, as failures are generally difficult to diagnose.  
  
<a name="white_lists"></a>   
## White Lists  
 The `/whitelist` option enables you to specify a text file that lists parts that are expected to be rejected. Unexpected rejections will then be flagged. This can be useful when you analyze an incomplete library, or a sub-library that is missing some dependencies. The `/whitelist` option can be applied to the `/rejected` or `/causes` actions.  
  
 Consider a file named test.txt that contains the text "ClassLibrary1.ChainOne". If you run the `/rejected` action with the `/whitelist` option on the previous example, it will produce the following output:  
  
```  
mefx /file:ClassLibrary1.dll /rejected /whitelist:test.txt  
[Unexpected] ClassLibrary1.AddIn  
ClassLibrary1.ChainOne  
```
