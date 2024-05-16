---
description: "Learn more about: Microsoft.VisualStudio.Activities.Asr.ClientActivityBuilder..ctor"
title: "Microsoft.VisualStudio.Activities.Asr.ClientActivityBuilder..ctor"
ms.date: "03/30/2017"
api_name: 
  - "Microsoft.VisualStudio.Activities.Asr.ClientActivityBuilder..ctor"
api_location: 
  - "Microsoft.VisualStudio.Activities.dll"
api_type: 
  - "Assembly"
ms.assetid: 6b44b13c-7a23-4df2-8f9f-45e2b1430002
---
# Microsoft.VisualStudio.Activities.Asr.ClientActivityBuilder..ctor

Creates an instance of the [Microsoft.VisualStudio.Activities.Asr.ClientActivityBuilder](microsoft-visualstudio-activities-asr-clientactivitybuilder.md) class.  
  
## Syntax  
  
```csharp  
public ClientActivityBuilder(OperationDescription operationDescription, string configurationName, string proxyNamespace);  
```  
  
## Parameters  
  
## Parameter Values  

 *operationDescription*  
  
 Describes the operation to be performed in the workflow activity that is to be generated, including the operation name, return type, and parameter information. The value of this parameter must not be **null**. It should describe a synchronous operation which uses a message contract and takes an argument with one message. If these conditions are not satisfied, the runtime result of using the constructor and the other methods of this class are undefined.  
  
 *configurationName*  
  
 Specifies the endpoint configuration name. The value of this parameter must not be either **null** or empty. If these conditions are not satisfied, the runtime result of using the constructor and the other methods of this class are undefined.  
  
 *proxyNamespace*  
  
 Specifies the service namespace for the operation. The value of this parameter must not be either **null** or empty. If these conditions are not satisfied, the runtime result of using the constructor and the other methods of this class are undefined.  
  
## See also

- [Microsoft.VisualStudio.Activities.Asr.ClientActivityBuilder](microsoft-visualstudio-activities-asr-clientactivitybuilder.md)
