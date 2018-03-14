---
title: "Absolute Delay"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: b483139a-39bb-4560-8003-8969a8fc2cd1
caps.latest.revision: 3
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Absolute Delay
The main scenario for this sample is to delay until a specified <xref:System.DateTime> using durable timers in a workflow application. This is different from using the built-in <xref:System.Activities.Statements.Delay> activity as this will only allow you to delay for a given <xref:System.TimeSpan> (or number of minutes/seconds).  
  
 Some real-life scenarios in which you may want to make this distinction include the following:  
  
1.  You want to delay sending a mail for 30 seconds to make sure you didn’t make any errors.  
  
2.  You are working overtime and want to delay all of your mails until normal business hours (such as 8 am).  
  
## Demonstrates  
  
1.  <xref:System.Activities.Statements.DurableTimerExtension> for implementing Absolute Delay  
  
2.  Setting up persistence using <xref:System.Activities.WorkflowApplication> for Durable Timers  
  
3.  Use of <xref:System.Activities.NativeActivity%601> for using Extensibility points  
  
4.  Use of <xref:System.Activities.CodeActivity%601> in the SendEmail activity  
  
5.  <xref:System.Activities.Statements.Delay>  
  
6.  XAML-only workflow  
  
 This sample demonstrates how to create a custom activity which takes in a <xref:System.DateTime> and uses durable timers to register the delay duration. When using durable timers, you must use a <xref:System.Activities.NativeActivity> to create a bookmark, as you will need to register this bookmark with the timer extension. In this sample, when the durable timer expires, the `OnTimerExpired` method will be called. Make sure that you are adding the timer extension in the <xref:System.Activities.NativeActivity%601.CacheMetadata%2A> event to ensure you are providing the runtime with this information. The only other implementation detail is that you will need to implement logic to convert from <xref:System.DateTime> to <xref:System.TimeSpan>, as durable timers only take in a <xref:System.DateTime>. Do note that there is a small lapse in accuracy by doing  
  
> [!NOTE]
>  There is a small loss of accuracy by converting from <xref:System.DateTime> to <xref:System.TimeSpan>.  
  
 This sample also demonstrates how to turn on persistence for a <xref:System.Activities.WorkflowApplication>. For this particular sample, we will be using durable timers in which the workflow data will be unloaded into the persistence database during the idle time while waiting for timer to expire. This implementation can also be used for other persistence actions. This sample shows how to set up the persistence connection string with SQL Server, and how to create the instance store in order to persist the data for workflow instances. Logic is provided on how to resume the workflow once an event is raised which makes the workflow instance runnable.  
  
 As you step through this sample, you will see the time in which the built-in delay begins and completes, which in turn will cause an email message to be sent. From there, the AbsoluteDelay activity will halt until a specified <xref:System.DateTime> (or 0 seconds if the <xref:System.DateTime> has expired) which in turn will send out an email upon expiration. This will show the two different use cases of the built-in <xref:System.Activities.Statements.Delay> functionality versus using an AbsoluteDelay activity.  
  
#### To set up, build, and run the sample  
  
1.  Ensure you have SQL Server Express (or higher) installed on your machine  
  
2.  Run setup.cmd (from WF/Basic/Services/AbsoluteDelay/CS) in a [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)] command prompt to create the AbsoluteDelaySampleDB database, create the persistence schema and create the persistence logic.  
  
3.  Open the solution in [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)].  
  
4.  Specify the Duration in the Delay activity.  
  
5.  Specify the ExpirationTime in the AbsoluteDelay activity.  
  
6.  Update the SendMailTo, SendMailFrom, SendMailSubject, SendMailBody, and SmtpHost fields in the SendMail activity.  
  
    > [!NOTE]
    >  If you do not enter a valid SMTP host, the application will throw a SMTP exception.  
  
7.  Build the solution by selecting **Build**, **Build Solution**.  
  
8.  Run the solution by pressing **F5**.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Basic\Services\AbsoluteDelay`
