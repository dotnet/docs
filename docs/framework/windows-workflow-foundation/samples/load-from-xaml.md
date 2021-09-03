---
description: "Learn more about: Load From XAML"
title: "Load From XAML"
ms.date: "03/30/2017"
ms.assetid: 1f103ef6-7bed-4f16-ae52-9e665c5a43d7
---
# Load From XAML

The [LoadFromXAML sample](https://github.com/dotnet/samples/tree/main/framework/windows-workflow-foundation/basic/Built-InActivities/LoadFromXAML/CS) demonstrates how to dynamically load a XAML workflow without having to run the XamlBuildTask tool. Instead, the sample calls the <xref:System.Activities.XamlIntegration.ActivityXamlServices.Load%2A> method. The sample is a Windows Presentation Foundation (WPF) client application that loads XAML workflows using the <xref:System.Activities.XamlIntegration.ActivityXamlServices> class and executes them. After they have been loaded using the <xref:System.Activities.XamlIntegration.ActivityXamlServices> class, a <xref:System.Activities.DynamicActivity%601> is returned that can be executed.

## To use this sample

1. Using Visual Studio, open the LoadFromXAML.sln solution file.

2. To build the solution, press CTRL+SHIFT+B.

3. To run the solution, press CTRL+F5.
