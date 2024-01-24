---
title: System.Printing.PrintTicket.OutputQuality property
description: Learn about the System.Printing.PrintTicket.OutputQuality property.
ms.date: 01/24/2024
---
# System.Printing.PrintTicket.OutputQuality property

[!INCLUDE [context](includes/context.md)]

Values returned by the <xref:System.Printing.PrintTicket.OutputQuality> property are used primarily for these purposes:

- As members of the <xref:System.Printing.PrintCapabilities.OutputQualityCapability%2A> collection, which is a property of <xref:System.Printing.PrintCapabilities>, these values indicate the types of output quality that a printer supports.
- As the value of the <xref:System.Printing.PrintTicket.OutputQuality> property of a <xref:System.Printing.PrintTicket>, they direct a printer to produce a particular quality.

The `Unknown` value is never used in properties of <xref:System.Printing.PrintCapabilities> objects.

You should never set a <xref:System.Printing.PrintTicket> property to `Unknown`. If some other <xref:System.Printing.PrintTicket> producing application has created a *PrintTicket document* that sets the output quality feature to an unrecognized option (that is, an option that is not defined in the [Print Schema](https://go.microsoft.com/fwlink/?LinkId=186397)), then a <xref:System.Printing.PrintTicket> object in your application that is constructed with that document will have `Unknown` as the value of the <xref:System.Printing.PrintTicket.OutputQuality> property.

Although the <xref:System.Printing.PrintTicket> and <xref:System.Printing.PrintCapabilities> classes cannot be inherited, you can extend the [Print Schema](https://go.microsoft.com/fwlink/?LinkId=186397) to recognize print device features that are not accounted for in the <xref:System.Printing.PrintTicket> or <xref:System.Printing.PrintCapabilities> classes. For more information see [How to: Extend the Print Schema and Create New Print System Classes](/previous-versions/aa970573(v=vs.100)).

## Notes on OutputQuality.Photographic

The Photographic value produces documents with high output quality. Producing documents with better output quality requires larger print spooler files and longer wait times. If these side effects are undesirable, you can use the High value instead.
