---
title: "How to: Diagnose Problematic Print Job"
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
  - "troubleshooting print job problems [WPF]"
  - "print jobs [WPF], troubleshooting"
  - "print jobs [WPF], diagnosing problems"
ms.assetid: b081a170-84c6-48f9-a487-5766a8d58a82
caps.latest.revision: 7
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Diagnose Problematic Print Job
Network administrators often field complaints from users about print jobs that do not print or print slowly. The rich set of print job properties exposed in the [!INCLUDE[TLA#tla_api#plural](../../../../includes/tlasharptla-apisharpplural-md.md)] of [!INCLUDE[TLA#tla_winfx](../../../../includes/tlasharptla-winfx-md.md)] provide a means for performing a rapid remote diagnosis of print jobs.  
  
## Example  
 The major steps for creating this kind of utility are as follows.  
  
1.  Identify the print job that the user is complaining about. Users often cannot do this precisely. They may not know the names of the print servers or printers. They may describe the location of the printer in different terminology than was used in setting its <xref:System.Printing.PrintQueue.Location%2A> property. Accordingly, it is a good idea to generate a list of the user's currently submitted jobs. If there is more than one, then communication between the user and the print system administrator can be used to pinpoint the job that is having problems. The substeps are as follows.  
  
    1.  Obtain a list of all print servers.  
  
    2.  Loop through the servers to query their print queues.  
  
    3.  Within each pass of the server loop, loop through all the server's queues to query their jobs  
  
    4.  Within each pass of the queue loop, loop through its jobs and gather identifying information about those that were submitted by the complaining user.  
  
2.  When the problematic print job has been identified, examine relevant properties to see what might be the problem. For example, is job in an error state or did the printer servicing the queue go offline before the job could print?  
  
 The code below is series of code examples. The first code example contains the loop through the print queues. (Step 1c above.) The variable `myPrintQueues` is the <xref:System.Printing.PrintQueueCollection> object for the current print server.  
  
 The code example begins by refreshing the current print queue object with <xref:System.Printing.PrintQueue.Refresh%2A?displayProperty=nameWithType>. This ensures that the object's properties accurately represent the state of the physical printer that it represents. Then the application gets the collection of print jobs currently in the print queue by using <xref:System.Printing.PrintQueue.GetPrintJobInfoCollection%2A>.  
  
 Next the application loops through the <xref:System.Printing.PrintSystemJobInfo> collection and compares each <xref:System.Printing.PrintSystemJobInfo.Submitter%2A> property with the alias of the complaining user. If they match, the application adds identifying information about the job to the string that will be presented. (The `userName` and `jobList` variables are initialized earlier in the application.)  
  
 [!code-cpp[DiagnoseProblematicPrintJob#EnumerateJobsInQueues](../../../../samples/snippets/cpp/VS_Snippets_Wpf/DiagnoseProblematicPrintJob/CPP/Program.cpp#enumeratejobsinqueues)]
 [!code-csharp[DiagnoseProblematicPrintJob#EnumerateJobsInQueues](../../../../samples/snippets/csharp/VS_Snippets_Wpf/DiagnoseProblematicPrintJob/CSharp/Program.cs#enumeratejobsinqueues)]
 [!code-vb[DiagnoseProblematicPrintJob#EnumerateJobsInQueues](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/DiagnoseProblematicPrintJob/visualbasic/program.vb#enumeratejobsinqueues)]  
  
 The next code example picks up the application at Step 2. (See above.) The problematic job has been identified and the application prompts for the information that will identify it. From this information it creates <xref:System.Printing.PrintServer>, <xref:System.Printing.PrintQueue>, and <xref:System.Printing.PrintSystemJobInfo> objects.  
  
 At this point the application contains a branching structure corresponding to the two ways of checking a print job's status:  
  
-   You can read the flags of the <xref:System.Printing.PrintSystemJobInfo.JobStatus%2A> property which is of type <xref:System.Printing.PrintJobStatus>.  
  
-   You can read each relevant property such as <xref:System.Printing.PrintSystemJobInfo.IsBlocked%2A> and <xref:System.Printing.PrintSystemJobInfo.IsInError%2A>.  
  
 This example demonstrates both methods, so the user was previously prompted as to which method to use and responded with "Y" if he or she wanted to use the flags of the <xref:System.Printing.PrintSystemJobInfo.JobStatus%2A> property. See below for the details of the two methods. Finally, the application uses a method called **ReportQueueAndJobAvailability** to report on whether the job can be printed at this time of day. This method is discussed in [Discover Whether a Print Job Can Be Printed At This Time of Day](../../../../docs/framework/wpf/advanced/how-to-discover-whether-a-print-job-can-be-printed-at-this-time-of-day.md).  
  
 [!code-cpp[DiagnoseProblematicPrintJob#IdentifyAndDiagnoseProblematicJob](../../../../samples/snippets/cpp/VS_Snippets_Wpf/DiagnoseProblematicPrintJob/CPP/Program.cpp#identifyanddiagnoseproblematicjob)]
 [!code-csharp[DiagnoseProblematicPrintJob#IdentifyAndDiagnoseProblematicJob](../../../../samples/snippets/csharp/VS_Snippets_Wpf/DiagnoseProblematicPrintJob/CSharp/Program.cs#identifyanddiagnoseproblematicjob)]
 [!code-vb[DiagnoseProblematicPrintJob#IdentifyAndDiagnoseProblematicJob](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/DiagnoseProblematicPrintJob/visualbasic/program.vb#identifyanddiagnoseproblematicjob)]  
  
 To check print job status using the flags of the <xref:System.Printing.PrintSystemJobInfo.JobStatus%2A> property, you check each relevant flag to see if it is set. The standard way to see if one bit is set in a set of bit flags is to perform a logical AND operation with the set of flags as one operand and the flag itself as the other. Since the flag itself has only one bit set, the result of the logical AND is that, at most, that same bit is set. To find out whether it is or not, just compare the result of the logical AND with the flag itself. For more information, see <xref:System.Printing.PrintJobStatus>, the [& Operator (C# Reference)](~/docs/csharp/language-reference/operators/and-operator.md), and <xref:System.FlagsAttribute>.  
  
 For each attribute whose bit is set, the code reports this to the console screen and sometimes suggests a way to respond. (The **HandlePausedJob** method that is called if the job or queue is paused is discussed below.)  
  
 [!code-cpp[DiagnoseProblematicPrintJob#SpotTroubleUsingJobAttributes](../../../../samples/snippets/cpp/VS_Snippets_Wpf/DiagnoseProblematicPrintJob/CPP/Program.cpp#spottroubleusingjobattributes)]
 [!code-csharp[DiagnoseProblematicPrintJob#SpotTroubleUsingJobAttributes](../../../../samples/snippets/csharp/VS_Snippets_Wpf/DiagnoseProblematicPrintJob/CSharp/Program.cs#spottroubleusingjobattributes)]
 [!code-vb[DiagnoseProblematicPrintJob#SpotTroubleUsingJobAttributes](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/DiagnoseProblematicPrintJob/visualbasic/program.vb#spottroubleusingjobattributes)]  
  
 To check print job status using separate properties, you simply read each property and, if the property is `true`, report to the console screen and possibly suggest a way to respond. (The **HandlePausedJob** method that is called if the job or queue is paused is discussed below.)  
  
 [!code-cpp[DiagnoseProblematicPrintJob#SpotTroubleUsingJobProperties](../../../../samples/snippets/cpp/VS_Snippets_Wpf/DiagnoseProblematicPrintJob/CPP/Program.cpp#spottroubleusingjobproperties)]
 [!code-csharp[DiagnoseProblematicPrintJob#SpotTroubleUsingJobProperties](../../../../samples/snippets/csharp/VS_Snippets_Wpf/DiagnoseProblematicPrintJob/CSharp/Program.cs#spottroubleusingjobproperties)]
 [!code-vb[DiagnoseProblematicPrintJob#SpotTroubleUsingJobProperties](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/DiagnoseProblematicPrintJob/visualbasic/program.vb#spottroubleusingjobproperties)]  
  
 The **HandlePausedJob** method enables the application's user to remotely resume paused jobs. Because there might be a good reason why the print queue was paused, the method begins by prompting for a user decision about whether to resume it. If the answer is "Y", then the <xref:System.Printing.PrintQueue.Resume%2A?displayProperty=nameWithType> method is called.  
  
 Next the user is prompted to decide if the job itself should be resumed, just in case it is paused independently of the print queue. (Compare <xref:System.Printing.PrintQueue.IsPaused%2A?displayProperty=nameWithType> and <xref:System.Printing.PrintSystemJobInfo.IsPaused%2A?displayProperty=nameWithType>.) If the answer is "Y", then <xref:System.Printing.PrintSystemJobInfo.Resume%2A?displayProperty=nameWithType> is called; otherwise <xref:System.Printing.PrintSystemJobInfo.Cancel%2A> is called.  
  
 [!code-cpp[DiagnoseProblematicPrintJob#HandlePausedJob](../../../../samples/snippets/cpp/VS_Snippets_Wpf/DiagnoseProblematicPrintJob/CPP/Program.cpp#handlepausedjob)]
 [!code-csharp[DiagnoseProblematicPrintJob#HandlePausedJob](../../../../samples/snippets/csharp/VS_Snippets_Wpf/DiagnoseProblematicPrintJob/CSharp/Program.cs#handlepausedjob)]
 [!code-vb[DiagnoseProblematicPrintJob#HandlePausedJob](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/DiagnoseProblematicPrintJob/visualbasic/program.vb#handlepausedjob)]  
  
## See Also  
 <xref:System.Printing.PrintJobStatus>  
 <xref:System.Printing.PrintSystemJobInfo>  
 <xref:System.FlagsAttribute>  
 <xref:System.Printing.PrintQueue>  
 [& Operator (C# Reference)](~/docs/csharp/language-reference/operators/and-operator.md)  
 [Documents in WPF](../../../../docs/framework/wpf/advanced/documents-in-wpf.md)  
 [Printing Overview](../../../../docs/framework/wpf/advanced/printing-overview.md)
