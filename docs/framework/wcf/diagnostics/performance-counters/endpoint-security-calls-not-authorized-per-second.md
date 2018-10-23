---
title: "Endpoint: Security Calls Not Authorized Per Second"
ms.date: "03/30/2017"
ms.assetid: c8a1547b-986b-45c1-b302-dea0cd4b516d
---
# Endpoint: Security Calls Not Authorized Per Second
Counter Name: Security Calls Not Authorized Per Second.  
  
## Description  
 Number of incoming messages in a second that are from a valid user and protected properly, but the user is not authorized to do specific tasks.  
  
 This counter is incremented when the <xref:System.ServiceModel.ServiceAuthorizationManager.CheckAccess%2A> method returns `false`.  
  
 This counter is of performance counter type [PERF_COUNTER_COUNTER](https://go.microsoft.com/fwlink/?LinkID=94649), whose value is calculated using the following formula.  
  
 (N 1 - N 0 ) / ( (D 1 -D 0 ) / F)
