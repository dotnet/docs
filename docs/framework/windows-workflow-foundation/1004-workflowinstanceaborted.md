---
title: "1004 - WorkflowInstanceAborted"
ms.date: "03/30/2017"
ms.assetid: edb9ab8c-0b9a-488d-aa96-9c8c7984b53c
---

# 1004 - WorkflowInstanceAborted

## Properties

|||
|-|-|
|ID|1004|
|Keywords|WFRuntime|
|Level|Information|
|Channel|Microsoft-Windows-Application Server-Applications/Debug|

## Description

Indicates a workflow instance has aborted with an exception.

## Message

WorkflowInstance Id: '%1' was aborted with an exception.

## Details

|Data Item Name|Data Item Type|Description|
|--------------------|--------------------|-----------------|
|WorkflowInstanceId|`xs:string`|The instance id for the workflow|
|Exception|`xs:string`|The exception details for the exception|
|AppDomain|`xs:string`|The string returned by AppDomain.CurrentDomain.FriendlyName.|
