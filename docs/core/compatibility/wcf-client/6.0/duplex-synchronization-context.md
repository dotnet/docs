---
title: "Breaking change: DuplexChannelFactory captures synchronization context"
description: Learn about the breaking change in WCF Client 6.0 where the DuplexChannelFactory now captures the synchronization context when it's opened.
ms.date: 04/06/2023
---
# Duplex contract captures synchronization context

<xref:System.ServiceModel.DuplexChannelFactory%601> now captures the synchronization context when it's opened, and it dispatches callbacks to the captured context.

## Previous behavior

In previous versions, the duplex contract failed to capture synchronization context when the channel factory was opened.

## New behavior

Starting in WCF Client 6.0 RC, the duplex channel captures synchronization context and dispatches callbacks to the captured context. This behavior matches that of .NEt Framework.

## Version introduced

WCF Client 6.0 RC

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change was made to fix a bug where callbacks were happening on the wrong thread. The new behavior matches .NET Framework functionality.

## Recommended action

If the new behavior is undesirable, you can revert to version 4.x behavior by applying the <xref:System.ServiceModel.CallbackBehaviorAttribute> to your callback contract with the <xref:System.ServiceModel.CallbackBehaviorAttribute.UseSynchronizationContext> property set to `false`.

## Affected APIs

- [DuplexChannelFactory\<TChannel>.Open](xref:System.ServiceModel.Channels.CommunicationObject.Open)
- [DuplexChannelFactory\<TChannel>.BeginOpen](xref:System.ServiceModel.Channels.CommunicationObject.BeginOpen%2A)
- [DuplexChannelFactory\<TChannel>.EndOpen](xref:System.ServiceModel.Channels.CommunicationObject.EndOpen%2A)
