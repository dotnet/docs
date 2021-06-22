---
description: "Learn more about: Runnable Instances Detection Period"
title: "Runnable Instances Detection Period"
ms.date: "03/30/2017"
ms.topic: "reference"
---
# Runnable Instances Detection Period

The SQL Workflow Instance Store runs an internal task that periodically wakes up and detects runnable or activatable instances in the persistence database. The **Runnable Instances Detection Period** property of the SQL Workflow Instance Store specifies the time period after which the SQL Workflow Instance Store runs a detection task to detect any runnable or activatable workflow instances in the persistence database after the previous detection cycle.  
  
 Setting a shorter interval for this property reduces the time between the expiration of a timer associated with a workflow instance and the signaling of the event and subsequent loading of the instance. However, it also increases the processing load on a host and may not be desirable in scenarios where durable timers and/or host failures are rare. The type of the property is TimeSpan and the value of the property follows the format: hh:mm:ss. The minimum value for this property is 00:00:01. The default value for the property is 00:00:05.  
  
 For more information detecting and activating runnable and activatable workflow instances, see [Instance Activation](instance-activation.md).
