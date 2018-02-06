---
title: "How to: Enumerate a Subset of Print Queues"
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
  - "cpp"
helpviewer_keywords: 
  - "enumerating [WPF], subset of print queues"
  - "print queues [WPF], enumerating subset of"
ms.assetid: cc4a1b5b-d46f-4c5e-bc26-22c226e4bee0
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Enumerate a Subset of Print Queues
A common situation faced by information technology (IT) professionals managing a company-wide set of printers is to generate a list of printers having certain characteristics. This functionality is provided by the <xref:System.Printing.PrintServer.GetPrintQueues%2A> method of a <xref:System.Printing.PrintServer> object and the <xref:System.Printing.EnumeratedPrintQueueTypes> enumeration.  
  
## Example  
 In the example below, the code begins by creating an array of flags that specify the characteristics of the print queues we want to list. In this example, we are looking for print queues that are installed locally on the print server and are shared. The <xref:System.Printing.EnumeratedPrintQueueTypes> enumeration provides many other possibilities.  
  
 The code then creates a <xref:System.Printing.LocalPrintServer> object, a class derived from <xref:System.Printing.PrintServer>. The local print server is the computer on which the application is running.  
  
 The last significant step is to pass the array to the <xref:System.Printing.PrintServer.GetPrintQueues%2A> method.  
  
 Finally, the results are presented to the user.  
  
 [!code-cpp[EnumerateSubsetOfPrintQueues#ListSubsetOfPrintQueues](../../../../samples/snippets/cpp/VS_Snippets_Wpf/EnumerateSubsetOfPrintQueues/CPP/Program.cpp#listsubsetofprintqueues)]
 [!code-csharp[EnumerateSubsetOfPrintQueues#ListSubsetOfPrintQueues](../../../../samples/snippets/csharp/VS_Snippets_Wpf/EnumerateSubsetOfPrintQueues/CSharp/Program.cs#listsubsetofprintqueues)]
 [!code-vb[EnumerateSubsetOfPrintQueues#ListSubsetOfPrintQueues](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/EnumerateSubsetOfPrintQueues/visualbasic/program.vb#listsubsetofprintqueues)]  
  
 You could extend this example by having the `foreach` loop that steps through each print queue do further screening. For example, you could screen out printers that do not support two-sided printing by having the loop call each print queue's <xref:System.Printing.PrintQueue.GetPrintCapabilities%2A> method and test the returned value for the presence of duplexing.  
  
## See Also  
 <xref:System.Printing.PrintServer.GetPrintQueues%2A>  
 <xref:System.Printing.PrintServer>  
 <xref:System.Printing.LocalPrintServer>  
 <xref:System.Printing.EnumeratedPrintQueueTypes>  
 <xref:System.Printing.PrintQueue>  
 <xref:System.Printing.PrintQueue.GetPrintCapabilities%2A>  
 [Documents in WPF](../../../../docs/framework/wpf/advanced/documents-in-wpf.md)  
 [Printing Overview](../../../../docs/framework/wpf/advanced/printing-overview.md)  
 [Microsoft XPS Document Writer](http://go.microsoft.com/fwlink/?LinkId=147319)
