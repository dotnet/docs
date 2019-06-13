---
title: "Service: Calls Per Second"
ms.date: "03/30/2017"
ms.assetid: 6261d28d-d449-425a-b9fc-a4ee14079134
---
# Service: Calls Per Second
Counter Name: Calls Per Second.  
  
## Description  
 Number of calls to this service in a second.  
  
 This counter is of performance counter type [PERF_COUNTER_COUNTER](https://go.microsoft.com/fwlink/?LinkID=94649), whose value is calculated using the following formula.  
  
 (N 1 - N 0 ) / ( (D 1 -D 0 ) / F) where the numerator (N) represents the number of operations performed during the last sample interval, the denominator (D) represents the number of ticks elapsed during the last sample interval, and F is the frequency of the ticks.
