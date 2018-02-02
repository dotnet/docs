---
title: "Persistence Database Schema"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 34f69f4c-df81-4da7-b281-a525a9397a5c
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Persistence Database Schema
This topic describes the public views supported by the SQL Workflow Instance Store.  
  
## Instances view  
 The **Instances** view contains general information about all workflow Instances in the Database.  
  
|Column Name|Column Type|Description|  
|-----------------|-----------------|-----------------|  
|InstanceId|UniqueIdentifier|The ID of a workflow instance.|  
|PendingTimer|DateTime|Indicates that the workflow is blocked on a Delay activity and will be resumed after the timer expires. This value can be null if the workflow is not blocked waiting on a timer to expire.|  
|CreationTime|DateTime|Indicates when the workflow was created.|  
|LastUpdatedTime|DateTime|Indicates the last time that the workflow was persisted to the database.|  
|ServiceDeploymentId|BigInt|Acts as a foreign key to the [ServiceDeployments] view. If the current workflow instance is an instance of a web-hosted service, then this column has a value, otherwise it is set to NULL.|  
|SuspensionExceptionName|Nvarchar(450)|Indicates the type of exception (e.g. InvalidOperationException) that caused the workflow to suspend.|  
|SuspensionReason|Nvarchar(max)|Indicates why the Workflow Instance was suspended. If an exception caused the instance to suspend, then this column contains the message associated with the exception.<br /><br /> If the instance was manually suspended, then this column contains the user-specified reason for suspending the instance.|  
|ActiveBookmarks|Nvarchar(max)|If the workflow Instance is Idle, this property indicates what bookmarks the instance is blocked on. If the Instance is not idle, then this column is NULL.|  
|CurrentMachine|Nvarchar(128)|Indicates the name of the computer currently has the workflow Instance loaded in memory.|  
|LastMachine|Nvarchar(450)|Indicates the last computer that loaded the workflow instance.|  
|ExecutionStatus|Nvarchar(450)|Indicates the current execution state of the Workflow. Possible states include **Executing**, **Idle**, **Closed**.|  
|IsInitialized|Bit|Indicates whether the workflow instance has been initialized. An initialized workflow instance is a workflow instance that has been persisted at least once.|  
|IsSuspended|Bit|Indicates whether the workflow instance has been suspended.|  
|IsCompleted|Bit|Indicates whether the Workflow Instance has finished executing. **Note:**  Iif the **InstanceCompletionAction** property is set to **DeleteAll**, the instances are removed from the view upon completion.|  
|EncodingOption|TinyInt|Describes the encoding used to serialize the data properties.<br /><br /> -   0 – No encoding<br />-   1 – GzipStream|  
|ReadWritePrimitiveDataProperties|Varbinary(max)|Contains serialized instance data properties that will be provided back to the workflow Runtime when the instance is loaded.<br /><br /> Each primitive property is a native CLR type, which means that no special assemblies are needed to deserialize the blob.|  
|WriteOnlyPrimitiveDataProperties|Varbinary(max)|Contains serialized instance data properties that are not provided back to the workflow runtime when the instance is loaded.<br /><br /> Each primitive property is a native CLR type, which means that no special assemblies are needed to deserialize the blob.|  
|ReadWriteComplexDataProperties|Varbinary(max)|Contains serialized instance data properties that will be provided back to the workflow runtime when the instance is loaded.<br /><br /> A deserializer would require knowledge of all object types stored in this blob.|  
|WriteOnlyComplexDataProperties|Varbinary(max)|Contains serialized instance data properties that are not provided back to the workflow runtime when the instance is loaded.<br /><br /> A deserializer would require knowledge of all object types stored in this blob.|  
|IdentityName|Nvarchar(max)|The name of the workflow definition.|  
|IdentityPackage|Nvarchar(max)|The package information given when the workflow was created (such as the assembly name).|  
|Build|BigInt|The build number of the workflow version.|  
|Major|BigInt|The major number of the workflow version.|  
|Minor|BigInt|The minor number of the workflow version.|  
|Revision|BigInt|The revision number of the workflow version.|  
  
> [!CAUTION]
>  The **Instances** view also contains a Delete trigger. Users with the appropriate permissions can execute delete statements against this view that will forcefully remove workflow Instances from the Database. We recommend deleting directly from the view only as a last resort because deleting an instance from underneath the workflow runtime could result in unintended consequences. Instead, use the Workflow Instance Management Endpoint to have the workflow runtime terminate the instance. If you want to delete a large number of Instances from the view, make sure there are no active runtimes that could be operating on these instances.  
  
## ServiceDeployments view  
 The **ServiceDeployments** view contains deployment information for all Web (IIS/WAS) hosted workflow services. Each workflow instance that is Web-hosted will contain a **ServiceDeploymentId** that refers to a row in this view.  
  
|Column Name|Column Type|Description|  
|-----------------|-----------------|-----------------|  
|ServiceDeploymentId|BigInt|The primary key for this view.|  
|SiteName|Nvarchar(max)|Represents the name of the site that contains the workflow service (e.g. **Default Web Site**).|  
|RelativeServicePath|Nvarchar(max)|Represents the virtual path relative to the site that points to the workflow service. (e.g.  **/app1/PurchaseOrderService.svc**).|  
|RelativeApplicationPath|Nvarchar(max)|Represents the virtual path relative to the site that points to an application that contains the workflow service. (e.g. **/app1**).|  
|ServiceName|Nvarchar(max)|Represents the name of the workflow Service. (e.g. **PurchaseOrderService**).|  
|ServiceNamespace|Nvarchar(max)|Represents the namespace of the workflow Service. (e.g. **MyCompany**).|  
  
 The ServiceDeployments View also contains a Delete trigger. Users with the appropriate permissions can execute delete statements against this view to remove ServiceDeployment entries from the Database. Note that:  
  
1.  Deleting entries from this view is costly since the entire Database must be locked prior to performing this operation. This is necessary to avoid the scenario where a workflow Instance could refer to a non-existent ServiceDeployment entry. Delete from this view only during down times / maintenance windows.  
  
2.  Any attempt to delete a ServiceDeployment row which is referenced to by entries in the **Instances** view will result in a no-op. You can only delete ServiceDeployment rows with zero references.  
  
## InstancePromotedProperties view  
 The **InstancePromotedProperties** view contains information for all the promoted properties that are specified by the user. A promoted property functions as a first-class property, which a user can use in queries to retrieve instances.  For example, a user could add a PurchaseOrder promotion which always stores the cost of an order in the **Value1** column. This would enable a user to query for all purchase orders whose cost exceeds a certain value.  
  
|Column Type|Column Type|Description|  
|-|-|-|  
|InstanceId|UniqueIdentifier|The ID of the Workflow Instance|  
|EncodingOption|TinyInt|Describes the encoding used to serialize the promoted binary properties.<br /><br /> -   0 – No encoding<br />-   1 – GZipStream|  
|PromotionName|Nvarchar(400)|The name of the Promotion associated with this instance. The PromotionName is needed to add context to the generic columns in this row.<br /><br /> For example, a PromotionName of PurchaseOrder could indicate that Value1 contains the cost of the order, Value2 contains the name of the customer who placed the order, Value 3 contains the address of the customer, and so on.|  
|Value[1-32]|SqlVariant|Value[1-32] contains values that can be stored in a SqlVariant column. A single promotion cannot contain more than 32 SqlVariants.|  
|Value[33-64]|Varbinary(max)|Value[33-64] contains serialized values.For instance, Value33 could contain a JPEG of an item being purchased. A single promotion cannot contain more than 32 binary properties|  
  
 The InstancePromotedProperties view is schema bound, which means that users can add indices on one or more columns in order to optimize queries against this view.  
  
> [!NOTE]
>  An indexed view requires more storage and adds additional processing overhead. Please refer to [Improving Performance with SQL Server 2008 Indexed Views](http://go.microsoft.com/fwlink/?LinkId=179529) for more information.
