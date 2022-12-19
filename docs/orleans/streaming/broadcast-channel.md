---
title: Broadcast channels
description: Learn how to work with Orleans broadcast channels.
ms.date: 12/14/2022
---

# Broadcast channels in Orleans

Broadcast channels are a special type of broadcasting mechanism that can be used to send messages to all subscribers. Unlike streaming providers, broadcast channels are not persistent and do not store messages. They are also not fault-tolerant and do not guarantee delivery. Broadcast channels are useful for sending messages to all subscribers, but they are not a replacement for persistent streams. With broadcast channels, one grain can easily communicate with another grain without having to know the identity of the other grain. This decouples the sender and receiver of the message, which is useful for scenarios where the sender and receiver are not known in advance.
