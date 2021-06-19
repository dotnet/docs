---
description: "Learn more about: Transaction Activities in WF"
title: "Transaction Activities in WF"
ms.date: "03/30/2017"
ms.topic: "reference"
---
# Transaction Activities in WF

The [!INCLUDE[netfx_current_long](../../../includes/netfx-current-long-md.md)] has several system-provided activities for modeling transactions, compensation, and cancellation. These programming models allow the workflow to continue forward progress in the event of changes in business logic and error handling. For more information about transactions, compensation, and cancellation, see [Transactions](workflow-transactions.md), [Compensation](compensation.md), and [Cancellation](modeling-cancellation-behavior-in-workflows.md).  
  
## Transaction Activities  
  
|||  
|-|-|  
|<xref:System.Activities.Statements.CancellationScope>|Associates cancellation logic, in the form of an activity, with a main path of execution, also expressed as an activity.|  
|<xref:System.Activities.Statements.CompensableActivity>|Supports compensation of its child activities.|  
|<xref:System.Activities.Statements.Compensate>|Explicitly invokes the compensation handler of a <xref:System.Activities.Statements.CompensableActivity>.|  
|<xref:System.Activities.Statements.Confirm>|Explicitly invokes the confirmation handler of a <xref:System.Activities.Statements.CompensableActivity>.|  
|<xref:System.Activities.Statements.TransactionScope>|Demarcates a transaction boundary.|  
|<xref:System.ServiceModel.Activities.TransactedReceiveScope>|Scopes the lifetime of a transaction that is initiated by a received message. The transaction may be flowed into the workflow on the initiating message, or created by the dispatcher when the message is received. **Note:**  The <xref:System.ServiceModel.Activities.TransactedReceiveScope> is located in the **Messaging** section of the **Toolbox**.|
