---
title: XpsDocumentWriter._WritingCancelled Event (System.Windows.Xps)
TOCTitle: _WritingCancelled Event
ms:assetid: E:System.Windows.Xps.XpsDocumentWriter._WritingCancelled
ms:mtpsurl: https://msdn.microsoft.com/en-us/library/System.Windows.Xps.XpsDocumentWriter._WritingCancelled(v=VS.110)
ms:contentKeyID: 35842077
ms.date: 10/17/2017
mtps_version: v=VS.110
f1_keywords:
- System.Windows.Xps.XpsDocumentWriter._WritingCancelled
- System::Windows::Xps::XpsDocumentWriter::_WritingCancelled
dev_langs:
- CSharp
- C++
- VB
- FSharp
api_location:
- system.printing.dll
api_name:
- System.Windows.Xps.XpsDocumentWriter._WritingCancelled
- System.Windows.Xps.XpsDocumentWriter.add__WritingCancelled
- System.Windows.Xps.XpsDocumentWriter.remove__WritingCancelled
api_type:
- Assembly
topic_type:
- apiref
product_family_name: VS
ROBOTS: INDEX,FOLLOW
---

# XpsDocumentWriter.\_WritingCancelled Event

 


> [!NOTE]
> <P>The .NET API Reference documentation has a new home. Visit the <A href="https://docs.microsoft.com/dotnet/api/?view=netframework-4.7.1">.NET API Browser</A> on docs.microsoft.com to see the new experience.</P>



Occurs when a [Write](https://msdn.microsoft.com/en-us/library/ms604841\(v=vs.110\)) or [WriteAsync](https://msdn.microsoft.com/en-us/library/ms604845\(v=vs.110\)) operation is canceled.

**Namespace:**   [System.Windows.Xps](https://msdn.microsoft.com/en-us/library/ms604617\(v=vs.110\))  
**Assembly:**  System.Printing (in System.Printing.dll)  
  

## Syntax

``` csharp
internal event WritingCancelledEventHandler _WritingCancelled
```

``` c++
internal:
event WritingCancelledEventHandler^ _WritingCancelled {
    void add(WritingCancelledEventHandler^ value);
    void remove(WritingCancelledEventHandler^ value);
}
```

``` fsharp
internal member _WritingCancelled : IEvent<WritingCancelledEventHandler,
    WritingCancelledEventArgs>
```

``` vb
Friend Event _WritingCancelled As WritingCancelledEventHandler
```

## See Also

[XpsDocumentWriter Class](https://msdn.microsoft.com/en-us/library/ms607827\(v=vs.110\))  
[System.Windows.Xps Namespace](https://msdn.microsoft.com/en-us/library/ms604617\(v=vs.110\))  

Return to top

