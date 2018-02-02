---
title: "Peer Channel Scenarios"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: dae6e0f7-900c-45ee-8be9-3647698382fb
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Peer Channel Scenarios
The Peer Channel APIs support the following development scenarios.  
  
## Publication/Subscription Messaging  
 Companies that build publication/subscription applications (for example, stock tickers, and publishers of news headlines, sports scores, and weather reports) can use Peer Channel to server-less applications. For example, users can obtain the latest sports scores by joining a common mesh (or group of clients) and propagate the large amount of up-to-date game data without increasing the server load. This helps the data provider to give higher quality of service without substantially increasing the investment in server-based technologies.  
  
## Collaboration  
 Independent software vendors (ISVs) can create applications that let people create tight groups for participation in peer-to-peer activities. For example, this can include teams working on collaborative projects, picture-sharing between friends, party-planning activities, and more. Traditionally, these activities always involve servers; however, Peer Channel provides a way of doing this in a more cost-efficient way by enabling offline access scenarios that are not as easily implemented under a traditional server-client model.  
  
## Distributed Processing and Compute Clusters  
 Compute clusters and distributed processing are typically used for large-scale computations, such as financial/weather modeling and decoding human DNA. Typically, this is done by having servers individually assign tasks to all clients participating in the computation cluster. These servers may also have additional demands; for example, all tasks may need to be completed within a certain duration, requiring more than one machine for each task. Additionally, if any client running a task goes down, another client must be able to take over that task and perform work on it. Likewise, more than one client may have to run the same task to ensure consistent results. Although servers can run this type of client coordination, you can create a peer-to-peer solution where the clients receiving a task independently determine the server requirements around the task and use a compute mesh to determine how to complete that task.  
  
## Gaming  
 Using Peer Channel, application developers can create server-less versions of their games where game moves get transmitted to and synchronized with other players by a peer-to-peer mechanism rather than through a central server. For small ISVs, this helps remove operational costs associated with deploying, maintaining, and servicing central servers. Games written using a peer-to-peer architecture can be played across the Internet, or in wired or wireless local networks. Secondary gaming activities, such as lobby and in-game chat can be developed using a peer-to-peer network.  
  
## See Also  
 [Peer Channel Concepts](../../../../docs/framework/wcf/feature-details/peer-channel-concepts.md)
