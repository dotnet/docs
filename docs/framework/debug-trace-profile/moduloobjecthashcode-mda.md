---
title: "moduloObjectHashcode MDA"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "managed debugging assistants (MDAs), hashcode modulus"
  - "Modulo object hash code"
  - "moduloObjectHashcode MDA"
  - "hashcode modulus"
  - "MDAs (managed debugging assistants), hashcode modulus"
  - "GetHashCode method"
  - "modulus of hashcodes"
ms.assetid: b45366ff-2a7a-4b8e-ab01-537b72e9de68
caps.latest.revision: 10
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# moduloObjectHashcode MDA
The `moduloObjectHashcode` managed debugging assistant (MDA) changes the behavior of the <xref:System.Object> class to perform a modulo operation on the hash code returned by the <xref:System.Object.GetHashCode%2A> method. The default modulus for this MDA is 1, which causes <xref:System.Object.GetHashCode%2A> to return 0 for all objects.  
  
## Symptoms  
 After moving to a new version of the common language runtime (CLR), a program no longer executes properly:  
  
-   The program is getting the wrong object from a <xref:System.Collections.Hashtable>.  
  
-   The order of enumeration from a <xref:System.Collections.Hashtable> has a change that breaks the program.  
  
-   Two objects that used to be equal are no longer equal.  
  
-   Two objects that used to not be equal are now equal.  
  
## Cause  
 Your program may be getting the wrong object from a <xref:System.Collections.Hashtable> because the implementation of the <xref:System.Object.Equals%2A> method on the class for the key into the <xref:System.Collections.Hashtable> tests for equality of objects by comparing the results of the call to the <xref:System.Object.GetHashCode%2A> method. Hash codes should not be used to test for object equality because two objects may have the same hash code even if their respective fields have different values. These hash code collisions, although rare in practice, do occur. The effect this has on a <xref:System.Collections.Hashtable> lookup is that two keys which are not equal appear to be equal, and the wrong object is returned from the <xref:System.Collections.Hashtable>. For performance reasons, the implementation of <xref:System.Object.GetHashCode%2A> can change between runtime versions, so collisions that might not occur on one version might occur on subsequent versions. Enable this MDA to test whether your code has bugs when hash codes collide. When enabled, this MDA causes the <xref:System.Object.GetHashCode%2A> method to return 0, resulting in all hash codes colliding. The only effect enabling this MDA should have on your program is that your program runs slower.  
  
 The order of enumeration from a <xref:System.Collections.Hashtable> may change from one version of the runtime to another if the algorithm used to compute the hash codes for the key change. To test whether your program has taken a dependency on the order of enumeration of keys or values out of a hash table, you can enable this MDA.  
  
## Resolution  
 Never use hash codes as a substitute for object identity. Implement the override of the <xref:System.Object.Equals%2A?displayProperty=nameWithType> method to not compare hash codes.  
  
 Do not create dependencies on the order of enumerations of keys or values in hash tables.  
  
## Effect on the Runtime  
 Applications run more slowly when this MDA is enabled. This MDA simply takes the hash code that would have been returned and instead returns the remainder when divided by a modulus.  
  
## Output  
 There is no output for this MDA.  
  
## Configuration  
 The `modulus` attribute specifies the modulus used on the hash code. The default value is 1.  
  
```xml  
<mdaConfig>  
  <assistants>  
    <moduloObjectHashcode modulus="1" />  
  </assistants>  
</mdaConfig>  
```  
  
## See Also  
 <xref:System.Object.GetHashCode%2A?displayProperty=nameWithType>  
 <xref:System.Object.Equals%2A?displayProperty=nameWithType>  
 [Diagnosing Errors with Managed Debugging Assistants](../../../docs/framework/debug-trace-profile/diagnosing-errors-with-managed-debugging-assistants.md)
