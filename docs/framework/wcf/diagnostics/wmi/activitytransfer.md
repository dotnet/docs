---
title: "ActivityTransfer"
ms.date: "03/30/2017"
ms.assetid: fc40ef17-2a92-4ce2-853c-6ba8e5d571f3
---
# ActivityTransfer
Activity Transfer Event  
  
## Syntax  
  
```csharp
class ActivityTransfer : WSAT_TraceEvent  
{  
  object ActivityID;  
  object RelatedActivityID;  
};  
```  
  
## Methods  
 The ActivityTransfer class does not define any methods.  
  
## Properties  
 The ActivityTransfer class has the following properties:  
  
### ActivityID  
  
- Data type: object  
    Access type: Read-only  
  
- Activity ID  
  
### RelatedActivityID  
  
- Data type: object  
    Access type: Read-only  
  
- Related Activity ID  
  
## Requirements  
  
|MOF|Declared in Servicemodel.mof.|  
|---------|-----------------------------------|  
|Namespace|Defined in root\ServiceModel.|
