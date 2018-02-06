---
title: "How to: Discover Whether a Print Job Can Be Printed At This Time of Day"
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
  - "print queues [WPF], timing"
  - "printers [WPF], availability"
  - "print jobs [WPF], timing"
ms.assetid: 7e9c8ec1-abf6-4b3d-b1c6-33b35d3c4063
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Discover Whether a Print Job Can Be Printed At This Time of Day
Print queues are not always available for 24 hours a day. They have start and end time properties that can be set to make them unavailable at certain times of day. This feature can be used, for example, to reserve a printer for the exclusive use of a certain department after 5 P.M.. That department would have a different queue servicing the printer than other departments use. The queue for the other departments would be set to be unavailable after 5 P.M., while queue for the favored department could be set to be available at all times.  
  
 Moreover, print jobs themselves can be set to be printable only within a specified span of time.  
  
 The <xref:System.Printing.PrintQueue> and <xref:System.Printing.PrintSystemJobInfo> classes exposed in the [!INCLUDE[TLA#tla_api#plural](../../../../includes/tlasharptla-apisharpplural-md.md)] of [!INCLUDE[TLA#tla_winfx](../../../../includes/tlasharptla-winfx-md.md)] provide a means for remotely checking whether a given print job can print on a given queue at the current time.  
  
## Example  
 The example below is a sample that can diagnose problems with a print job.  
  
 There are two major steps for this kind of function as follows.  
  
1.  Read the <xref:System.Printing.PrintQueue.StartTimeOfDay%2A> and <xref:System.Printing.PrintQueue.UntilTimeOfDay%2A> properties of the <xref:System.Printing.PrintQueue> to determine whether the current time is between them.  
  
2.  Read the <xref:System.Printing.PrintSystemJobInfo.StartTimeOfDay%2A> and <xref:System.Printing.PrintSystemJobInfo.UntilTimeOfDay%2A> properties of the <xref:System.Printing.PrintSystemJobInfo> to determine whether the current time is between them.  
  
 But complications arise from the fact that these properties are not <xref:System.DateTime> objects. Instead they are <xref:System.Int32> objects that express the time of day as the number of minutes since midnight. Moreover, this is not midnight in the current time zone, but midnight UTC (Coordinated Universal Time).  
  
 The first code example presents the static method **ReportQueueAndJobAvailability**, which is passed a <xref:System.Printing.PrintSystemJobInfo> and calls helper methods to determine whether the job can print at the current time and, if not, when it can print. Notice that a <xref:System.Printing.PrintQueue> is not passed to the method. This is because the <xref:System.Printing.PrintSystemJobInfo> includes a reference to the queue in its <xref:System.Printing.PrintSystemJobInfo.HostingPrintQueue%2A> property.  
  
 The subordinate methods include the overloaded **ReportAvailabilityAtThisTime** method which can take either a <xref:System.Printing.PrintQueue> or a <xref:System.Printing.PrintSystemJobInfo> as a parameter. There is also a **TimeConverter.ConvertToLocalHumanReadableTime**. All of these methods are discussed below.  
  
 The **ReportQueueAndJobAvailability** method begins by checking to see if either the queue or the print job is unavailable at this time. If either of them is unavailable, it then checks to see if the queue unavailable. If it is not available, then the method reports this fact and the time when the queue will become available again. It then checks the job and if it is unavailable, it reports the next time span when it when it can print. Finally, the method reports the earliest time when the job can print. This is the later of following two times.  
  
-   The time when the print queue is next available.  
  
-   The time when the print job is next available.  
  
 When reporting times of day, the <xref:System.DateTime.ToShortTimeString%2A> method is also called because this method suppresses the years, months, and days from the output. You cannot restrict the availability of either a print queue or a print job to particular years, months, or days.  
  
 [!code-cpp[DiagnoseProblematicPrintJob#ReportQueueAndJobAvailability](../../../../samples/snippets/cpp/VS_Snippets_Wpf/DiagnoseProblematicPrintJob/CPP/Program.cpp#reportqueueandjobavailability)]
 [!code-csharp[DiagnoseProblematicPrintJob#ReportQueueAndJobAvailability](../../../../samples/snippets/csharp/VS_Snippets_Wpf/DiagnoseProblematicPrintJob/CSharp/Program.cs#reportqueueandjobavailability)]
 [!code-vb[DiagnoseProblematicPrintJob#ReportQueueAndJobAvailability](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/DiagnoseProblematicPrintJob/visualbasic/program.vb#reportqueueandjobavailability)]  
  
 The two overloads of the **ReportAvailabilityAtThisTime** method are identical except for the type passed to them, so only the <xref:System.Printing.PrintQueue> version is presented below.  
  
> [!NOTE]
>  The fact that the methods are identical except for type raises the question of why the sample does not create a generic method **ReportAvailabilityAtThisTime\<T>**. The reason is that such a method would have to be restricted to a class that has the **StartTimeOfDay** and **UntilTimeOfDay** properties that the method calls, but a generic method can only be restricted to a single class and the only class common to both <xref:System.Printing.PrintQueue> and <xref:System.Printing.PrintSystemJobInfo> in the inheritance tree is <xref:System.Printing.PrintSystemObject> which has no such properties.  
  
 The **ReportAvailabilityAtThisTime** method (presented in the code example below) begins by initializing a <xref:System.Boolean> sentinel variable to `true`. It will be reset to `false`, if the queue is not available.  
  
 Next, the method checks to see if the start and "until" times are identical. If they are, the queue is always available, so the method returns `true`.  
  
 If the queue is not available all the time, the method uses the static <xref:System.DateTime.UtcNow%2A> property to get the current time as a <xref:System.DateTime> object. (We do not need local time because the <xref:System.Printing.PrintQueue.StartTimeOfDay%2A> and <xref:System.Printing.PrintQueue.UntilTimeOfDay%2A> properties are themselves in UTC time.)  
  
 However, these two properties are not <xref:System.DateTime> objects. They are <xref:System.Int32>s expressing the time as the number of minutes-after-UTC-midnight. So we do have to convert our <xref:System.DateTime> object to minutes-after-midnight. When that is done, the method simply checks to see whether "now" is between the queue's start and "until" times, sets the sentinel to false if "now" is not between the two times, and returns the sentinel.  
  
 [!code-cpp[DiagnoseProblematicPrintJob#PrintQueueStartUntil](../../../../samples/snippets/cpp/VS_Snippets_Wpf/DiagnoseProblematicPrintJob/CPP/Program.cpp#printqueuestartuntil)]
 [!code-csharp[DiagnoseProblematicPrintJob#PrintQueueStartUntil](../../../../samples/snippets/csharp/VS_Snippets_Wpf/DiagnoseProblematicPrintJob/CSharp/Program.cs#printqueuestartuntil)]
 [!code-vb[DiagnoseProblematicPrintJob#PrintQueueStartUntil](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/DiagnoseProblematicPrintJob/visualbasic/program.vb#printqueuestartuntil)]  
  
 The **TimeConverter.ConvertToLocalHumanReadableTime** method (presented in the code example below) does not use any methods introduced with [!INCLUDE[TLA#tla_winfx](../../../../includes/tlasharptla-winfx-md.md)], so the discussion is brief. The method has a double conversion task: it must take an integer expressing minutes-after-midnight and convert it to a human-readable time and it must convert this to the local time. It accomplishes this by first creating a <xref:System.DateTime> object that is set to midnight UTC and then it uses the <xref:System.DateTime.AddMinutes%2A> method to add the minutes that were passed to the method. This returns a new <xref:System.DateTime> expressing the original time that was passed to the method. The <xref:System.DateTime.ToLocalTime%2A> method then converts this to local time.  
  
 [!code-cpp[DiagnoseProblematicPrintJob#TimeConverter](../../../../samples/snippets/cpp/VS_Snippets_Wpf/DiagnoseProblematicPrintJob/CPP/Program.cpp#timeconverter)]
 [!code-csharp[DiagnoseProblematicPrintJob#TimeConverter](../../../../samples/snippets/csharp/VS_Snippets_Wpf/DiagnoseProblematicPrintJob/CSharp/Program.cs#timeconverter)]
 [!code-vb[DiagnoseProblematicPrintJob#TimeConverter](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/DiagnoseProblematicPrintJob/visualbasic/program.vb#timeconverter)]  
  
## See Also  
 <xref:System.DateTime>  
 <xref:System.Printing.PrintSystemJobInfo>  
 <xref:System.Printing.PrintQueue>  
 [Documents in WPF](../../../../docs/framework/wpf/advanced/documents-in-wpf.md)  
 [Printing Overview](../../../../docs/framework/wpf/advanced/printing-overview.md)
