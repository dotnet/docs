---
title: "Exceptions, Transactions, and Compensation"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "programming [WF], error handling"
ms.assetid: 694db4f9-7387-4b13-8f9f-b923b18c7490
caps.latest.revision: 12
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Exceptions, Transactions, and Compensation
[!INCLUDE[wf1](../../../includes/wf1-md.md)] provides several different mechanisms for handling run-time error conditions in workflows. Workflows can use a combination of exception handlers, transactions, cancellation, and compensation to handle and recover gracefully from error conditions.  
  
## In This Section  
 [Exceptions](../../../docs/framework/windows-workflow-foundation/exceptions.md)  
 Demonstrates how to use the <xref:System.Activities.Statements.TryCatch> activity to handle exceptions in a workflow.  
  
 [Transactions](../../../docs/framework/windows-workflow-foundation/workflow-transactions.md)  
 Demonstrates how to use the <xref:System.Activities.Statements.TransactionScope> activity to use transactions in a workflow.  
  
 [Compensation](../../../docs/framework/windows-workflow-foundation/compensation.md)  
 Describes compensation in workflows and demonstrates how to use compensation activities such as <xref:System.Activities.Statements.CompensableActivity>, <xref:System.Activities.Statements.Compensate>, and <xref:System.Activities.Statements.Confirm>.  
  
 [Cancellation](../../../docs/framework/windows-workflow-foundation/modeling-cancellation-behavior-in-workflows.md)  
 Describes how to perform cancellation handling in workflows using built-in activities as well as custom activities.  
  
 [Debugging Workflows](../../../docs/framework/windows-workflow-foundation/debugging-workflows.md)  
 Describes how to debug workflows.
