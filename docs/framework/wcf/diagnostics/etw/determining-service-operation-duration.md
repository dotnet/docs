---
title: "Determining service operation duration"
ms.date: "03/30/2017"
ms.assetid: e8a93a2c-2c20-48b3-8986-57e90e9aa908
---
# Determining service operation duration
If analytic tracing is enabled in a Windows Communication Foundation (WCF) application, the duration of execution for a service operation can easily be determined by examining the event log.  This topic demonstrates how to determine the amount of time a service operation takes to complete.  
  
### Determining service operation execution duration  
  
1. Open Event Viewer by clicking **Start**, **Run**, and entering `eventvwr.exe`.  
  
2. If you haven’t enabled analytic tracing, expand **Applications and Services Logs**, **Microsoft**, **Windows**, **Application Server-Applications**. Select **View**, **Show Analytic and Debug Logs**. Right-click **Analytic** and select **Enable Log**. Leave Event Viewer open so that traces can be viewed after the service operation is run.  
  
3. Next, open a WCF application that includes a service project and a client project that interacts with that service.  You can create such an application by following the [Getting Started Tutorial](../../../../../docs/framework/wcf/getting-started-tutorial.md).  If you have the WCF samples installed, you can open the [Getting Started](../../../../../docs/framework/wcf/samples/getting-started-sample.md), which contains the completed project created in the tutorial.  
  
4. Execute the server application by pressing **F5**. Execute the client application by right-clicking on the **Client** project and selecting **Debug**, **Start New Instance**.  
  
5. In Event Viewer, refresh the Analytic log and sort the events by Event ID.  Look for events with Event ID [214 - OperationCompleted](../../../../../docs/framework/wcf/diagnostics/etw/214-operationcompleted.md).  These events will show which operations have completed, and what the duration of the operation was.  The following event shows the duration of an Add operation.  
  
    ```output  
    An OperationInvoker completed the call to the 'Add' method.  The method call duration was '3' ms.  
    ```
