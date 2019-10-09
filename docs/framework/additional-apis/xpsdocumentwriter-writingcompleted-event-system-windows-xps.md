---
title: XpsDocumentWriter._WritingCompleted Event (System.Windows.Xps)
TOCTitle: _WritingCompleted Event
ms:assetid: E:System.Windows.Xps.XpsDocumentWriter._WritingCompleted
ms:mtpsurl: https://msdn.microsoft.com/en-us/library/System.Windows.Xps.XpsDocumentWriter._WritingCompleted(v=VS.110)
ms:contentKeyID: 35841851
ms.date: 10/17/2017
mtps_version: v=VS.110
f1_keywords:
- System.Windows.Xps.XpsDocumentWriter._WritingCompleted
- System::Windows::Xps::XpsDocumentWriter::_WritingCompleted
dev_langs:
- CSharp
- C++
- VB
- FSharp
api_location:
- system.printing.dll
api_name:
- System.Windows.Xps.XpsDocumentWriter._WritingCompleted
- System.Windows.Xps.XpsDocumentWriter.remove__WritingCompleted
- System.Windows.Xps.XpsDocumentWriter.add__WritingCompleted
api_type:
- Assembly
topic_type:
- apiref
product_family_name: VS
ROBOTS: INDEX,FOLLOW
---

# XpsDocumentWriter.\_WritingCompleted Event

 


> [!NOTE]
> <P>The .NET API Reference documentation has a new home. Visit the <A href="https://docs.microsoft.com/dotnet/api/?view=netframework-4.7.1">.NET API Browser</A> on docs.microsoft.com to see the new experience.</P>



Occurs when a write operation finishes.

**Namespace:**   [System.Windows.Xps](https://msdn.microsoft.com/en-us/library/ms604617\(v=vs.110\))  
**Assembly:**  System.Printing (in System.Printing.dll)  
  

## Syntax

``` csharp
internal event WritingCompletedEventHandler _WritingCompleted
```

``` c++
internal:
event WritingCompletedEventHandler^ _WritingCompleted {
    void add(WritingCompletedEventHandler^ value);
    void remove(WritingCompletedEventHandler^ value);
}
```

``` fsharp
internal member _WritingCompleted : IEvent<WritingCompletedEventHandler,
    WritingCompletedEventArgs>
```

``` vb
Friend Event _WritingCompleted As WritingCompletedEventHandler
```

## See Also

[XpsDocumentWriter Class](https://msdn.microsoft.com/en-us/library/ms607827\(v=vs.110\))  
[System.Windows.Xps Namespace](https://msdn.microsoft.com/en-us/library/ms604617\(v=vs.110\))  

Return to top

