---
title: Broadcast channels
description: Learn how to work with Orleans broadcast channels.
ms.date: 12/14/2022
---

# Broadcast channels in Orleans

Broadcast channels are a special type of streaming mechanism that can be used to broadcast messages to all connected clients. Broadcast channels are useful for scenarios where you want to send a message within a producer and consumer model, but you don't want to keep track of the consumers. For example, you can use broadcast channels to send a message to all connected clients when a new user joins a chat room.
