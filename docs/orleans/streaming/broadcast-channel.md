---
title: Broadcast channels
description: Learn how to work with Orleans broadcast channels.
ms.date: 12/19/2022
---

# Broadcast channels in Orleans

Broadcast channels are a special type of broadcasting mechanism that can be used to send messages to all subscribers. Unlike streaming providers, broadcast channels are not persistent and do not store messages, but they're not a replacement for persistent streams. With broadcast channels, a grain subscribes to the broadcast channel and receives broadcast messages from a producer. This decouples the sender and receiver of the message, which is useful for scenarios where the sender and receiver are not known in advance.
