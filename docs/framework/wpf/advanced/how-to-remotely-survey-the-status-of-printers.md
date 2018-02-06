---
title: "How to: Remotely Survey the Status of Printers"
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
  - "surveying printer status remotely [WPF]"
  - "printer status [WPF], surveying remotely"
  - "remotely surveying printer status [WPF]"
  - "status [WPF], printers [WPF], surveying remotely"
ms.assetid: d6324759-8292-4c23-9584-9c708887dc94
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Remotely Survey the Status of Printers
At any given time at medium and large companies there may be multiple printers that are not working due to a paper jam or being out of paper or some other problematic situation. The rich set of printer properties exposed in the [!INCLUDE[TLA#tla_api#plural](../../../../includes/tlasharptla-apisharpplural-md.md)] of [!INCLUDE[TLA#tla_winfx](../../../../includes/tlasharptla-winfx-md.md)] provide a means for performing a rapid survey of the states of printers.  
  
## Example  
 The major steps for creating this kind of utility are as follows.  
  
1.  Obtain a list of all print servers.  
  
2.  Loop through the servers to query their print queues.  
  
3.  Within each pass of the server loop, loop through all the server's queues and read each property that might indicate that the queue is not currently working.  
  
 The code below is a series of snippets. For simplicity, this example assumes that there is a CRLF-delimited list of print servers. The variable `fileOfPrintServers` is a <xref:System.IO.StreamReader> object for this file. Since each server name is on its own line, any call of <xref:System.IO.StreamReader.ReadLine%2A> gets the name of the next server and moves the <xref:System.IO.StreamReader>'s cursor to the beginning of the next line.  
  
 Within the outer loop, the code creates a <xref:System.Printing.PrintServer> object for the latest print server and specifies that the application is to have administrative rights to the server.  
  
> [!NOTE]
>  If there are a lot of servers, you can improve performance by using the <xref:System.Printing.PrintServer.%23ctor%28System.String%2CSystem.String%5B%5D%2CSystem.Printing.PrintSystemDesiredAccess%29> constructors that only initialize the properties you are going to need.  
  
 The example then uses <xref:System.Printing.PrintServer.GetPrintQueues%2A> to create a collection of all of the server's queues and begins to loop through them. This inner loop contains a branching structure corresponding to the two ways of checking a printer's status:  
  
-   You can read the flags of the <xref:System.Printing.PrintQueue.QueueStatus%2A> property which is of type <xref:System.Printing.PrintQueueStatus>.  
  
-   You can read each relevant property such as <xref:System.Printing.PrintQueue.IsOutOfPaper%2A>, and <xref:System.Printing.PrintQueue.IsPaperJammed%2A>.  
  
 This example demonstrates both methods, so the user was previously prompted as to which method to use and responded with "y" if he or she wanted to use the flags of the <xref:System.Printing.PrintQueue.QueueStatus%2A> property. See below for the details of the two methods.  
  
 Finally, the results are presented to the user.  
  
 [!code-cpp[PrinterStatusSurvey#SurveyQueues](../../../../samples/snippets/cpp/VS_Snippets_Wpf/PrinterStatusSurvey/CPP/Program.cpp#surveyqueues)]
 [!code-csharp[PrinterStatusSurvey#SurveyQueues](../../../../samples/snippets/csharp/VS_Snippets_Wpf/PrinterStatusSurvey/CSharp/Program.cs#surveyqueues)]
 [!code-vb[PrinterStatusSurvey#SurveyQueues](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/PrinterStatusSurvey/visualbasic/program.vb#surveyqueues)]  
  
 To check printer status using the flags of the <xref:System.Printing.PrintQueue.QueueStatus%2A> property, you check each relevant flag to see if it is set. The standard way to see if one bit is set in a set of bit flags is to perform a logical AND operation with the set of flags as one operand and the flag itself as the other. Since the flag itself has only one bit set, the result of the logical AND is that, at most, that same bit is set. To find out whether it is or not, just compare the result of the logical AND with the flag itself. For more information, see <xref:System.Printing.PrintQueueStatus>, the [& Operator (C# Reference)](~/docs/csharp/language-reference/operators/and-operator.md), and <xref:System.FlagsAttribute>.  
  
 For each attribute whose bit is set, the code adds a notice to the final report that will be presented to the user. (The **ReportAvailabilityAtThisTime** method that is called at the end of the code is discussed below.)  
  
 [!code-cpp[PrinterStatusSurvey#SpotTroubleUsingQueueAttributes](../../../../samples/snippets/cpp/VS_Snippets_Wpf/PrinterStatusSurvey/CPP/Program.cpp#spottroubleusingqueueattributes)]
 [!code-csharp[PrinterStatusSurvey#SpotTroubleUsingQueueAttributes](../../../../samples/snippets/csharp/VS_Snippets_Wpf/PrinterStatusSurvey/CSharp/Program.cs#spottroubleusingqueueattributes)]
 [!code-vb[PrinterStatusSurvey#SpotTroubleUsingQueueAttributes](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/PrinterStatusSurvey/visualbasic/program.vb#spottroubleusingqueueattributes)]  
  
 To check printer status using each property, you simply read each property and add a note to the final report that will be presented to the user if the property is `true`. (The **ReportAvailabilityAtThisTime** method that is called at the end of the code is discussed below.)  
  
 [!code-cpp[PrinterStatusSurvey#SpotTroubleUsingQueueProperties](../../../../samples/snippets/cpp/VS_Snippets_Wpf/PrinterStatusSurvey/CPP/Program.cpp#spottroubleusingqueueproperties)]
 [!code-csharp[PrinterStatusSurvey#SpotTroubleUsingQueueProperties](../../../../samples/snippets/csharp/VS_Snippets_Wpf/PrinterStatusSurvey/CSharp/Program.cs#spottroubleusingqueueproperties)]
 [!code-vb[PrinterStatusSurvey#SpotTroubleUsingQueueProperties](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/PrinterStatusSurvey/visualbasic/program.vb#spottroubleusingqueueproperties)]  
  
 The **ReportAvailabilityAtThisTime** method was created in case you need to determine if the queue is available at the current time of day.  
  
 The method will do nothing if the <xref:System.Printing.PrintQueue.StartTimeOfDay%2A> and <xref:System.Printing.PrintQueue.UntilTimeOfDay%2A> properties are equal; because in that case the printer is available at all times. If they are different, the method gets the current time which then has to be converted into total minutes past midnight because the <xref:System.Printing.PrintQueue.StartTimeOfDay%2A> and <xref:System.Printing.PrintQueue.UntilTimeOfDay%2A> properties are <xref:System.Int32>s representing minutes-after-midnight, not <xref:System.DateTime> objects. Finally, the method checks to see if the current time is between the start and "until" times.  
  
 [!code-cpp[PrinterStatusSurvey#UsingStartAndUntilTimes](../../../../samples/snippets/cpp/VS_Snippets_Wpf/PrinterStatusSurvey/CPP/Program.cpp#usingstartanduntiltimes)]
 [!code-csharp[PrinterStatusSurvey#UsingStartAndUntilTimes](../../../../samples/snippets/csharp/VS_Snippets_Wpf/PrinterStatusSurvey/CSharp/Program.cs#usingstartanduntiltimes)]
 [!code-vb[PrinterStatusSurvey#UsingStartAndUntilTimes](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/PrinterStatusSurvey/visualbasic/program.vb#usingstartanduntiltimes)]  
  
## See Also  
 <xref:System.Printing.PrintQueue.StartTimeOfDay%2A>  
 <xref:System.Printing.PrintQueue.UntilTimeOfDay%2A>  
 <xref:System.DateTime>  
 <xref:System.Printing.PrintQueueStatus>  
 <xref:System.FlagsAttribute>  
 <xref:System.Printing.PrintServer.GetPrintQueues%2A>  
 <xref:System.Printing.PrintServer>  
 <xref:System.Printing.LocalPrintServer>  
 <xref:System.Printing.EnumeratedPrintQueueTypes>  
 <xref:System.Printing.PrintQueue>  
 [& Operator (C# Reference)](~/docs/csharp/language-reference/operators/and-operator.md)  
 [Documents in WPF](../../../../docs/framework/wpf/advanced/documents-in-wpf.md)  
 [Printing Overview](../../../../docs/framework/wpf/advanced/printing-overview.md)
