---
title: "Connection Grouping"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "Internet, connections"
  - "connections [.NET Framework], grouping"
  - "WebRequest class, connection grouping"
  - "network resources, connections"
  - "connection pooling"
ms.assetid: 2ec502e8-4ba0-4c22-9410-f28eaf4eee63
caps.latest.revision: 7
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Connection Grouping
Connection grouping associates specific requests within a single application to a defined connection pool. This can be required by a middle-tier application that connects to a back-end server on behalf of a user and uses an authentication protocol that supports delegation, such as Kerberos, or by a middle-tier application that supplies its own credentials, as in the example below. For example, suppose a user, Joe, visits an internal Web site that displays his payroll information. After authenticating Joe, the middle-tier application server uses Joe's credentials to connect to the back-end server to retrieve his payroll information. Next, Susan visits the site and requests her payroll information. Because the middle-tier application has already made a connection using Joe's credentials, the back-end server responds with Joe's information. However, if the application assigns each request sent to the back-end server to a connection group formed from the user name, then each user belongs to a separate connection pool and cannot accidentally share authentication information with another user.  
  
 To assign a request to a specific connection group, you must assign a name to the <xref:System.Net.WebRequest.ConnectionGroupName%2A> property of your <xref:System.Net.WebRequest> before making the request.  
  
## See Also  
 [Managing Connections](../../../docs/framework/network-programming/managing-connections.md)  
 [How to: Assign User Information to Group Connections](../../../docs/framework/network-programming/how-to-assign-user-information-to-group-connections.md)
