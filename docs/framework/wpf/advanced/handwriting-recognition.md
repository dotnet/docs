---
title: "Handwriting Recognition"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "handwriting recognition [WPF]"
  - "recognition of handwriting [WPF]"
ms.assetid: f4e8576d-e731-4bac-9818-22e2ae636636
---
# Handwriting Recognition
This section discusses the fundamentals of recognition as it pertains to digital ink in the WPF platform.  
  
## Recognition Solutions  
 The following example shows how to recognize ink using the [Microsoft.Ink.InkCollector](https://docs.microsoft.com/previous-versions/dotnet/netframework-3.5/ms583683(v=vs.90)) class.  
  
> [!NOTE]
>  This sample requires that handwriting recognizers be installed on the system.  
  
 Create a new WPF application project in Visual Studio called **InkRecognition**. Replace the contents of the Window1.xaml file with the following XAML code. This code renders the application's user interface.  
  
 [!code-xaml[InkRecognition#1](~/samples/snippets/csharp/VS_Snippets_Wpf/InkRecognition/CSharp/Window1.xaml#1)]  
  
 Add a reference to the Microsoft Ink assembly, Microsoft.Ink.dll, which can be found in \Program Files\Common Files\Microsoft Shared\Ink. Replace the contents of the code behind file with the following code.  
  
 [!code-csharp[InkRecognition#2](~/samples/snippets/csharp/VS_Snippets_Wpf/InkRecognition/CSharp/Window1.xaml.cs#2)]
 [!code-vb[InkRecognition#2](~/samples/snippets/visualbasic/VS_Snippets_Wpf/InkRecognition/VisualBasic/Window1.xaml.vb#2)]  
  
## See also

- [Microsoft.Ink.InkCollector](https://docs.microsoft.com/previous-versions/dotnet/netframework-3.5/ms583683(v=vs.90))
