---
description: "Learn more about: Exceptions, Transactions, and Compensation"
title: "Exceptions, Transactions, and Compensation"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "programming [WF], error handling"
ms.assetid: 694db4f9-7387-4b13-8f9f-b923b18c7490
---
# Exceptions, Transactions, and Compensation

WF provides several different mechanisms for handling run-time error conditions in workflows. Workflows can use a combination of exception handlers, transactions, cancellation, and compensation to handle and recover gracefully from error conditions.

## In This Section

 [Exceptions](exceptions.md)
 Demonstrates how to use the <xref:System.Activities.Statements.TryCatch> activity to handle exceptions in a workflow.

 [Transactions](workflow-transactions.md)
 Demonstrates how to use the <xref:System.Activities.Statements.TransactionScope> activity to use transactions in a workflow.

 [Compensation](compensation.md)
 Describes compensation in workflows and demonstrates how to use compensation activities such as <xref:System.Activities.Statements.CompensableActivity>, <xref:System.Activities.Statements.Compensate>, and <xref:System.Activities.Statements.Confirm>.

 [Cancellation](modeling-cancellation-behavior-in-workflows.md)
 Describes how to perform cancellation handling in workflows using built-in activities as well as custom activities.

 [Debugging Workflows](debugging-workflows.md)
 Describes how to debug workflows.
