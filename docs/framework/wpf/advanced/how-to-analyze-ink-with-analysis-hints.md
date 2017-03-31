---
title: "How to: Analyze Ink with Analysis Hints | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework-4.6"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "ink, analyzing"
  - "analyzing ink"
  - "ink, AnalysisHintNode objects"
  - "AnalysisHintNode objects"
ms.assetid: d4421ed4-77f5-4640-829e-9f1de50b2ff2
caps.latest.revision: 4
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# How to: Analyze Ink with Analysis Hints
An <xref:System.Windows.Ink.AnalysisHintNode> provides a hint for the <xref:System.Windows.Ink.InkAnalyzer> to which it is attached.  The hint applies to the area specified by the <xref:System.Windows.Ink.ContextNode.Location%2A> property of the <xref:System.Windows.Ink.AnalysisHintNode> and provides extra context to the ink analyzer to improve recognition accuracy. The <xref:System.Windows.Ink.InkAnalyzer> applies this context information when analyzing ink obtained from within the hint's area.  
  
## Example  
 The following example is an application that uses multiple <xref:System.Windows.Ink.AnalysisHintNode> objects on a form that accepts ink input. The application uses the <xref:System.Windows.Ink.AnalysisHintNode.Factoid%2A> property to provide context information for each entry on the form.  The application uses background analysis to analyze the ink and clears the form of all ink five seconds after the user stops adding ink.  
  
 [!code-xml[HowToAnalyzeInk#1](../../../../samples/snippets/csharp/VS_Snippets_Wpf/HowToAnalyzeInk/CSharp/FormAnalyzer.xaml#1)]  
  
 [!code-csharp[HowToAnalyzeInk#2](../../../../samples/snippets/csharp/VS_Snippets_Wpf/HowToAnalyzeInk/CSharp/FormAnalyzer.xaml.cs#2)]
 [!code-vb[HowToAnalyzeInk#2](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/HowToAnalyzeInk/VisualBasic/FormAnalyzer.xaml.vb#2)]