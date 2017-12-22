---
title: "&lt;sqlWorkflowInstanceStore&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "reference"
ms.assetid: 8a4e4214-fc51-4f4d-b968-0427c37a9520
caps.latest.revision: 5
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;sqlWorkflowInstanceStore&gt;
A service behavior that allows you to configure the <xref:System.Activities.DurableInstancing.SqlWorkflowInstanceStore> feature, which supports persisting state information for workflow service instances into an SQL Server 2005 or SQL Server 2008 database. For more information on this feature, see [SQL Workflow Instance Store](../../../../../docs/framework/windows-workflow-foundation/sql-workflow-instance-store.md).  
  
\<system.ServiceModel>  
\<behaviors>  
\<serviceBehaviors>  
\<behavior>  
\<sqlWorkflowInstanceStore>  
  
## Syntax  
  
```xml  
<behaviors>
  <serviceBehaviors>
    <behavior name="String">
      <sqlWorkflowInstanceStore connectionStringName="String" 
                                honstLockRenewalPeriod="TimeSpan" 
                                instanceCompletionAction="DeleteNothing/DeleteAll" 
                                instanceEncodingAction="None/GZip" 
                                instanceLockedExceptionAction="NoRetry/BasicRetry/AggressiveRetry" 
                                runnableInstancesDetectionPeriod="TimeSpan" />
    </behavior>
  </serviceBehaviors>
</behaviors>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|connectionString|A string that contains a connection string used to connect to an underlying persistence database.|  
|connectionStringName|A string that contains a named connection string to the database server. An example of a named connection string is "DefaultConnectionString".|  
|honstLockRenewalPeriod|A Timespan value that specifies the time period in which the host must renew the lock on an instance. If the host does not renew the lock in the specified time period, the instance is unlocked and may be picked up by another host.<br /><br /> Unloading a workflow implies that it is also persisted. If this attribute is set to zero the workflow instance is persisted and unloaded immediately after the workflow becomes idle. Setting this attribute to TimeSpan.MaxValue effectively disables the unload operation. Idle workflow instances are never unloaded.|  
|instanceCompletionAction|A value that specifies whether workflow instance data is kept in the persistence store after the workflow instance completes or if it is deleted at that point. This value is of type <xref:System.Activities.DurableInstancing.InstanceCompletionAction>.<br /><br /> The enumerated actions consist of deleting the instance data from the persistence store or not deleting the instance data from the persistence store, when the instance has completed its operation.<br /><br /> Keeping instances after completion causes the persistence database to grow rapidly and this affects the performance of the database. You should configure a database purge policy to delete these records periodically to ensure that the performance of the database is at the level that satisfy your performance requirements.|  
|instanceEncodingOption|An optional value that specifies  whether the instance state information is compressed using the GZip algorithm before the information is saved in the persistence store.. This value is of type `System.Activities.DurableInstancing.InstanceEncodingAction`. Possible values for this property are "None", which specifies no compression, and "GZip", which specifies that instance data is compressed and uses the gzip algorithm.|  
|instanceLockedExceptionAction|A value that specifies the action that occurs in response to an exception that is thrown when the host tries to lock an instance because the instance is currently locked by another host. This value is of type <xref:System.Activities.DurableInstancing.InstanceLockedExceptionAction>.<br /><br /> The options allowed for this field are: None, Basic Retry, and Aggressive Retry. The default value is None. The following list provides you with the descriptions for these three options:<br /><br /> -   None. The service host does not attempt to lock the instance and passes the <xref:System.Runtime.DurableInstancing.InstanceLockedException> to the caller.<br />-   Basic Retry. The service host reattempts to lock the instance with a linear retry interval and passes the exception to the caller at the end of the sequence.<br />-   Aggressive Retry. The service host reattempts to lock the instance with an exponentially increasing delay and passes the <xref:System.Runtime.DurableInstancing.InstanceLockedException> to the caller at the end of the sequence.|  
|runnableInstancesDetectionPeriod||  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<behavior> of \<serviceBehaviors>](../../../../../docs/framework/configure-apps/file-schema/windows-workflow-foundation/behavior-of-servicebehaviors-of-workflow.md)|Specifies a behavior element.|  
  
## See Also  
 <xref:System.ServiceModel.Activities.Description.SqlWorkflowInstanceStoreBehavior>  
 <xref:System.ServiceModel.Activities.Configuration.SqlWorkflowInstanceStoreElement>  
 <xref:System.Activities.DurableInstancing.SqlWorkflowInstanceStore>  
 [SQL Workflow Instance Store](../../../../../docs/framework/windows-workflow-foundation/sql-workflow-instance-store.md)
