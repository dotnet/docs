---
title: "Activity Library"
ms.date: "03/30/2017"
ms.assetid: 5323e9d4-71d6-47eb-bfa6-31feac62044d
---
# Activity Library
This section contains samples that demonstrate advanced custom activities in Windows Workflow Foundation (WF).  
  
## In This Section

 [SendMail Custom Activity](sendmail-custom-activity.md)  
 Demonstrates how to create a custom activity that derives from <xref:System.Activities.AsyncCodeActivity> to send mail using SMTP for use within a workflow application.  
  
 [Throttled Parallel ForEach](throttled-parallel-foreach.md)  
 Demonstrates how the `ThrottleParallelForEach` activity is similar to the <xref:System.Activities.Statements.ParallelForEach%601> activity with the one exception that it allows setting a concurrency factor to restrict the number of simultaneous branches to execute.
  
 [Database Access Activities](database-access-activities.md)  
 Demonstrates how to create activities that allow accessing databases to retrieve or modify information and use [ADO.NET](https://go.microsoft.com/fwlink/?LinkId=166081) to access the database.  
  
 [Externalized Policy Activity in .NET Framework 4.5](externalized-policy-activity-in-net-framework-4-5.md)  
 Demonstrates how the ExternalizedPolicy4 activity allows executing existing Windows Workflow Foundation in .NET Framework 3.5 (WF 3.5) <xref:System.Workflow.Activities.Rules.RuleSet> objects in Windows Workflow Foundation in [!INCLUDE[netfx_current_long](../../../../includes/netfx-current-long-md.md)] (WF 4.5) directly by using the rules engine that is shipped in WF 3.5. 
  
 [Non-Generic ForEach](non-generic-foreach.md)  
 Demonstrates how to create a non-generic version of the <xref:System.Activities.Statements.ForEach%601> activity.  
  
 [Non-Generic ParallelForEach](non-generic-parallelforeach.md)  
 Demonstrates how to create a non-generic version of the <xref:System.Activities.Statements.ParallelForEach%601> activity.  
  
 [Get WorkflowInstanceId](get-workflowinstanceid.md)  
 Demonstrates how to use the custom activity, `GetWorkflowInstanceId`, to return the workflow instance ID.
