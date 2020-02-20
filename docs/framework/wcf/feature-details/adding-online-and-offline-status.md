---
title: "Adding Online and Offline Status"
ms.date: "03/30/2017"
ms.assetid: 05e5f51d-81b6-4c17-b364-9dda447a5fce
---
# Adding Online and Offline Status
In many cases, it is important for an application to monitor specific details about the status of a Peer Channel connection. You can obtain this information by calling the `GetProperty` method on an implementation of the <xref:System.ServiceModel.IOnlineStatus> interface. An object with an implementation of this interface can monitor connection status or register for event handlers, such as `OnOnline` and `OnOffline`, and react immediately as changes to online status occur.  
  
 In the Peer Channel infrastructure, a client is considered to be online if it is connected to at least one other peer and offline otherwise. This can be particularly useful in both debugging a developing applications or displaying detailed information to the end user.  
  
> [!NOTE]
> An online event handler should first ensure that the node is open before sending any messages.  
  
## See also

- [Building a Peer Channel Application](../../../../docs/framework/wcf/feature-details/building-a-peer-channel-application.md)
