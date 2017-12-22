---
title: "Security and Race Conditions"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "security [.NET Framework], race conditions"
  - "race conditions"
  - "secure coding, race conditions"
  - "code security, race conditions"
ms.assetid: ea3edb80-b2e8-4e85-bfed-311b20cb59b6
caps.latest.revision: 9
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Security and Race Conditions
Another area of concern is the potential for security holes exploited by race conditions. There are several ways in which this might happen. The subtopics that follow outline some of the major pitfalls that the developer must avoid.  
  
## Race Conditions in the Dispose Method  
 If a class's **Dispose** method (for more information, see [Garbage Collection](../../../docs/standard/garbage-collection/index.md)) is not synchronized, it is possible that cleanup code inside **Dispose** can be run more than once, as shown in the following example.  
  
```vb  
Sub Dispose()  
    If Not (myObj Is Nothing) Then  
       Cleanup(myObj)  
       myObj = Nothing  
    End If  
End Sub  
```  
  
```csharp  
void Dispose()   
{  
    if( myObj != null )   
    {  
        Cleanup(myObj);  
        myObj = null;  
    }  
}  
```  
  
 Because this **Dispose** implementation is not synchronized, it is possible for `Cleanup` to be called by first one thread and then a second thread before `_myObj` is set to **null**. Whether this is a security concern depends on what happens when the `Cleanup` code runs. A major issue with unsynchronized **Dispose** implementations involves the use of resource handles such as files. Improper disposal can cause the wrong handle to be used, which often leads to security vulnerabilities.  
  
## Race Conditions in Constructors  
 In some applications, it might be possible for other threads to access class members before their class constructors have completely run. You should review all class constructors to make sure that there are no security issues if this should happen, or synchronize threads if necessary.  
  
## Race Conditions with Cached Objects  
 Code that caches security information or uses the code access security [Assert](../../../docs/framework/misc/using-the-assert-method.md) operation might also be vulnerable to race conditions if other parts of the class are not appropriately synchronized, as shown in the following example.  
  
```vb  
Sub SomeSecureFunction()  
    If SomeDemandPasses() Then  
        fCallersOk = True  
        DoOtherWork()  
        fCallersOk = False()  
    End If  
End Sub  
  
Sub DoOtherWork()  
    If fCallersOK Then  
        DoSomethingTrusted()  
    Else  
        DemandSomething()  
        DoSomethingTrusted()  
    End If  
End Sub  
```  
  
```csharp  
void SomeSecureFunction()   
{  
    if(SomeDemandPasses())   
    {  
        fCallersOk = true;  
        DoOtherWork();  
        fCallersOk = false();  
    }  
}  
void DoOtherWork()   
{  
    if( fCallersOK )   
    {  
        DoSomethingTrusted();  
    }  
    else   
    {  
        DemandSomething();  
        DoSomethingTrusted();  
    }  
}  
```  
  
 If there are other paths to `DoOtherWork` that can be called from another thread with the same object, an untrusted caller can slip past a demand.  
  
 If your code caches security information, make sure that you review it for this vulnerability.  
  
## Race Conditions in Finalizers  
 Race conditions can also occur in an object that references a static or unmanaged resource that it then frees in its finalizer. If multiple objects share a resource that is manipulated in a class's finalizer, the objects must synchronize all access to that resource.  
  
## See Also  
 [Secure Coding Guidelines](../../../docs/standard/security/secure-coding-guidelines.md)
