---
title: "Monitoring Service Operation Failures"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 59472ba3-8ebf-4479-bd7b-f440d5e636cb
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Monitoring Service Operation Failures
If analytic tracing is enabled for an application, service failures can easily be monitored in the event viewer.  This topic demonstrates how to determine when a service operation fails, and how to determine what caused the failure.  
  
### Determining service operation failure information  
  
1.  Open Event Viewer by clicking **Start**, **Run**, and entering `eventvwr.exe`.  
  
2.  If you haven’t enabled analytic tracing, expand **Applications and Services Logs**, **Microsoft**, **Windows**, **Application Server-Applications**. Select **View**, **Show Analytic and Debug Logs**. Right-click **Analytic** and select **Enable Log**. Leave Event Viewer open so that traces can be viewed after the service operation fails.  
  
3.  Next, open the sample created in the [Getting Started Tutorial](../../../../../docs/framework/wcf/getting-started-tutorial.md) in [!INCLUDE[vs_current_long](../../../../../includes/vs-current-long-md.md)] Note that you must run [!INCLUDE[vs_current_long](../../../../../includes/vs-current-long-md.md)] as an administrator so that the service can be created. If you have the [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] samples installed, you can open the [Getting Started](../../../../../docs/framework/wcf/samples/getting-started-sample.md), which contains the completed project created in the tutorial.  
  
4.  In the Program.cs file in the Server project, add the following line of code to the start of the `Divide` method in the `CalculatorService` class:  
  
    ```  
    if (n2 == 0) throw new DivideByZeroException();  
    ```  
  
5.  In the Program.cs file in the Client project, change the value assigned to value2 to zero:  
  
    ```  
    //Call the Divide service operation  
    value1 = 22.00D;  
    value2 = 0.00D;  
    result = client.Divide(value1, value2);  
    Console.WriteLine("Divide({0}, {1}) = {2}", value1, value2, result);  
    ```  
  
6.  Execute the server application without debugging by pressing **Ctrl+F5**.  
  
7.  Open a Visual Studio command prompt.  Navigate to the client directory and execute the client from the command line.  
  
8.  In Event Viewer, disable and refresh the Analytic log and sort the events by Event ID.  Look for an event with Event ID [219 - ServiceException](../../../../../docs/framework/wcf/diagnostics/etw/219-serviceexception.md), which describes the service failure.  
  
    ```Output  
    There was an unhandled exception of type 'System.DivideByZeroException' during message processing.  Full Exception ToString: System.DivideByZeroException: Attempted to divide by zero.  
    ```  
  
    > [!NOTE]
    >  Events are buffered when being sent to the event viewer; the failure event may not appear right away.
