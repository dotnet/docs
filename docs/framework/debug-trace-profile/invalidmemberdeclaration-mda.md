---
title: "invalidMemberDeclaration MDA"
description: Review the invalidMemberDeclaration managed debugging assistant, which is invoked if a failure HRESULT is returned to COM without calling the managed method.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "invalid member declaration"
  - "InvalidMemberDeclaration MDA"
  - "marshaling, run-time errors"
  - "managed debugging assistants (MDAs), marshaling"
  - "MDAs (managed debugging assistants), marshaling"
ms.assetid: a84dd9a3-d6cf-4824-989a-ecbbf443eeb4
---
# invalidMemberDeclaration MDA

The `invalidMemberDeclaration` managed debugging assistant (MDA) is activated to report an error that occurs while determining how to marshal the parameters of a member to be called from COM.  
  
## Symptoms  

 A failure HRESULT is returned to COM without the managed method having been called.  
  
## Cause  

 This is most likely due to an incompatible <xref:System.Runtime.InteropServices.MarshalAsAttribute> attribute on one of the parameters.  
  
## Resolution  

 Specify valid <xref:System.Runtime.InteropServices.MarshalAsAttribute> attributes on the parameters.  
  
## Effect on the Runtime  

 This MDA has no effect on the CLR.  
  
## Output  

 An informational message containing the member name, type name, and error message.  
  
## Configuration  
  
```xml  
<mdaConfig>  
  <assistants>  
    <invalidMemberDeclaration/>  
  </assistants>  
</mdaConfig>  
```  
  
## See also

- <xref:System.Runtime.InteropServices.MarshalAsAttribute>
- [Diagnosing Errors with Managed Debugging Assistants](diagnosing-errors-with-managed-debugging-assistants.md)
- [Interop Marshaling](../interop/interop-marshaling.md)
