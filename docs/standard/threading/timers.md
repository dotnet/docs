---
title: "Timers"
ms.date: "07/02/2018"
ms.technology: dotnet-standard
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "threading [.NET Framework], timers"
  - "timers, about timers"
ms.assetid: 7091500d-be18-499b-a942-95366ce185e5
author: "rpetrusha"
ms.author: "ronpet"
---
# Timers

The <xref:System.Threading.Timer?displayProperty=nameWithType> class enables you to continuously call a delegate at specified time intervals. You also can use this class to schedule the single call to a delegate in a specified time interval. The delegate is executed each time on a <xref:System.Threading.ThreadPool> thread.

The following example creates a timer that starts after one second (1000 milliseconds) and calls the provided delegate every two seconds. When you create a timer, you can provide the object that will be passed to every delegate call. In the example, such an object is used to count how many times the delegate is called. The timer is stopped when the delegate has been called at least 10 times.

[!code-cpp[System.Threading.Timer#2](../../../samples/snippets/cpp/VS_Snippets_CLR_System/system.Threading.Timer/CPP/source2.cpp#2)]
[!code-csharp[System.Threading.Timer#2](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.Threading.Timer/CS/source2.cs#2)]
[!code-vb[System.Threading.Timer#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.Threading.Timer/VB/source2.vb#2)]

For more information and examples, see <xref:System.Threading.Timer?displayProperty=nameWithType>.

Another timer that can be used in a multithreaded environment is <xref:System.Timers.Timer?displayProperty=nameWithType> that by default raises events on a <xref:System.Threading.ThreadPool> thread.
  
## See also

 <xref:System.Threading.Timer?displayProperty=nameWithType>  
 <xref:System.Timers.Timer?displayProperty=nameWithType>  
 [Threading Objects and Features](threading-objects-and-features.md)
