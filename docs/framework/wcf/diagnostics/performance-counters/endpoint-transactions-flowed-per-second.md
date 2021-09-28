---
description: "Learn more about: Endpoint: Transactions Flowed Per Second"
title: "Endpoint: Transactions Flowed Per Second"
ms.date: "03/30/2017"
ms.assetid: 0f370ff1-a913-450b-bccb-c279ad165b3d
---
# Endpoint: Transactions Flowed Per Second

Counter Name: Transactions Flowed Per Second.  
  
## Description  

 Number of transactions flowed to operations at this endpoint in a second. This counter is incremented any time a transaction ID is present in a message sent to the endpoint.  
  
 This counter is of performance counter type [PERF_COUNTER_COUNTER](/previous-versions/windows/it-pro/windows-server-2003/cc740048(v=ws.10)), whose value is calculated using the following formula.  
  
 (N 1 - N 0 ) / ( (D 1 -D 0 ) / F)
