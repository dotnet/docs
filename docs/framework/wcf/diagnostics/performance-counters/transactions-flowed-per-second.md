---
title: "Transactions Flowed Per Second"
ms.date: "03/30/2017"
ms.assetid: b9f661e1-576c-48fc-9fdf-91853e0749e8
---
# Transactions Flowed Per Second
Counter Name:  Transactions Flowed Per Second  
  
## Description  
 Number of transactions flowed to this operation in a second. This counter is incremented any time a transaction ID is present in a message that is sent to the operation.  
  
 This counter is of performance counter type [PERF_COUNTER_COUNTER](https://go.microsoft.com/fwlink/?LinkID=94649), whose value is calculated using the following formula.  
  
 (N 1 - N 0 ) / ( (D 1 -D 0 ) / F)
