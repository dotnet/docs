---
title: XpsDocumentWriter._WritingProgressChanged Event (System.Windows.Xps)
TOCTitle: _WritingProgressChanged Event
ms:assetid: E:System.Windows.Xps.XpsDocumentWriter._WritingProgressChanged
ms:mtpsurl: https://msdn.microsoft.com/en-us/library/System.Windows.Xps.XpsDocumentWriter._WritingProgressChanged(v=VS.110)
ms:contentKeyID: 35842053
ms.date: 10/17/2017
mtps_version: v=VS.110
f1_keywords:
- System.Windows.Xps.XpsDocumentWriter._WritingProgressChanged
- System::Windows::Xps::XpsDocumentWriter::_WritingProgressChanged
dev_langs:
- CSharp
- C++
- VB
- FSharp
api_location:
- system.printing.dll
api_name:
- System.Windows.Xps.XpsDocumentWriter._WritingProgressChanged
- System.Windows.Xps.XpsDocumentWriter.add__WritingProgressChanged
- System.Windows.Xps.XpsDocumentWriter.remove__WritingProgressChanged
api_type:
- Assembly
topic_type:
- apiref
product_family_name: VS
ROBOTS: INDEX,FOLLOW
---

# XpsDocumentWriter.\_WritingProgressChanged Event

 


> [!NOTE]
> <P>The .NET API Reference documentation has a new home. Visit the <A href="https://docs.microsoft.com/dotnet/api/?view=netframework-4.7.1">.NET API Browser</A> on docs.microsoft.com to see the new experience.</P>



Occurs when the [XpsDocumentWriter](https://msdn.microsoft.com/en-us/library/ms607827\(v=vs.110\)) updates its progress.

**Namespace:**   [System.Windows.Xps](https://msdn.microsoft.com/en-us/library/ms604617\(v=vs.110\))  
**Assembly:**  System.Printing (in System.Printing.dll)  
  

## Syntax

``` csharp
internal event WritingProgressChangedEventHandler _WritingProgressChanged
```

``` c++
internal:
event WritingProgressChangedEventHandler^ _WritingProgressChanged {
    void add(WritingProgressChangedEventHandler^ value);
    void remove(WritingProgressChangedEventHandler^ value);
}
```

``` fsharp
internal member _WritingProgressChanged : IEvent<WritingProgressChangedEventHandler,
    WritingProgressChangedEventArgs>
```

``` vb
Friend Event _WritingProgressChanged As WritingProgressChangedEventHandler
```

## See Also

[XpsDocumentWriter Class](https://msdn.microsoft.com/en-us/library/ms607827\(v=vs.110\))  
[System.Windows.Xps Namespace](https://msdn.microsoft.com/en-us/library/ms604617\(v=vs.110\))  

Return to top

