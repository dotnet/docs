---
title: Hydra Devices
description: Hydra Devices (POS for .NET v1.14 SDK Documentation)
ms.date: 02/27/2008
ms.update-cycle: 1825-days
ms.topic: how-to
ms.custom: "pos-restored-from-archive,UpdateFrequency5"
---

# Hydra Devices (POS for .NET v1.14 SDK Documentation)

Some peripheral POS devices combine UPOS device types. These are referred to as Hydra devices, and their interface to the POS application requires more than one Service Object.

For example, a magnetic ink character recognition (MICR) device may include a POS printer. In that case, the device is represented by both a MICR Service Object and a POS printer Service Object. Even though they interact with the same peripheral device, both Service Objects must be created and controlled separately. The MICR Service Object manages the MICR check scanning and character recognition function and the POS printer Service Object manages the receipt and validation printers.

However, both MICR and POS printer Service Objects must work together in a single transaction. Check processing combines check insertion and removal operations in the MICR device with validation printing functions in the POS printer.

## Considerations

In the normal case, a Service Object would simply open a connection to the device and perform its read and write operations. With **Hydra** devices, however, the task is more complicated since IO ports are normally exclusive. Therefore, multiple Service Objects accessing the same device must synchronize with each other, typically with some variety of inter-process communication.

POS for .NET offers no features to help multiple Service Objects synchronize with each other. The Service Object developer must write this code and tailor it to the specific system configuration.

## See Also

#### Concepts

- [Service Object Overview](service-object-overview.md)

#### Other Resources

- [POS for .NET Service Object Architecture](pos-for-net-service-object-architecture.md)
