---
title: "MsmqBindingElementBase"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 210d41ab-a2a4-4d7a-afd2-0916c08a4015
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# MsmqBindingElementBase
MsmqBindingElementBase  
  
## Syntax  
  
```  
class MsmqBindingElementBase : TransportBindingElement  
{  
  string CustomDeadLetterQueue;  
  string DeadLetterQueue;  
  boolean Durable;  
  boolean ExactlyOnce;  
  sint32 MaxRetryCycles;  
  string ReceiveErrorHandling;  
  sint32 ReceiveRetryCount;  
  datetime RetryCycleDelay;  
  datetime TimeToLive;  
  boolean UseMsmqTracing;  
  boolean UseSourceJournal;  
};  
```  
  
## Methods  
 The MsmqBindingElementBase class does not define any methods.  
  
## Properties  
 The MsmqBindingElementBase class has the following properties:  
  
### CustomDeadLetterQueue  
 Data type: string  
  
 Access type: Read-only  
  
 A URI that contains the location of the dead letter queue for each application, where messages that have expired or that have failed transfer or delivery are placed.  
  
### DeadLetterQueue  
 Data type: string  
  
 Access type: Read-only  
  
 An enumeration value that indicates the type of dead letter queue to use.  
  
### Durable  
 Data type: boolean  
  
 Access type: Read-only  
  
 A value that indicates whether the messages processed by this binding are durable or volatile.  
  
### ExactlyOnce  
 Data type: boolean  
  
 Access type: Read-only  
  
 A Boolean value that indicates whether messages processed by this binding are received exactly once.  
  
### MaxRetryCycles  
 Data type: sint32  
  
 Access type: Read-only  
  
 The maximum number of retry cycles to attempt delivery of messages to the receiving application.  
  
### ReceiveErrorHandling  
 Data type: string  
  
 Access type: Read-only  
  
 The settings for poison message handling.  
  
### ReceiveRetryCount  
 Data type: sint32  
  
 Access type: Read-only  
  
 The maximum number of immediate retry attempts on a message that is read from the application queue.  
  
### RetryCycleDelay  
 Data type: datetime  
  
 Access type: Read-only  
  
 A value that indicates the time delay between retry cycles when attempting to deliver a message that could not be delivered immediately.  
  
### TimeToLive  
 Data type: datetime  
  
 Access type: Read-only  
  
 The interval of time that indicates how long the messages processed by this binding can be in the queue before they expire.  
  
### UseMsmqTracing  
 Data type: boolean  
  
 Access type: Read-only  
  
 A Boolean value that indicates whether messages processed by this binding should be traced.  
  
### UseSourceJournal  
 Data type: boolean  
  
 Access type: Read-only  
  
 A Boolean value that indicates whether copies of messages processed by this binding should be stored in the source journal queue.  
  
## Requirements  
  
|MOF|Declared in Servicemodel.mof.|  
|---------|-----------------------------------|  
|Namespace|Defined in root\ServiceModel|  
  
## See Also  
 <xref:System.ServiceModel.NetMsmqBinding>  
 <xref:System.ServiceModel.MsmqBindingBase>
