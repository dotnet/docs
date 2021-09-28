---
description: "Learn more about: BC31535: Friend assembly reference <reference> is invalid"
title: "Friend assembly reference <reference> is invalid"
ms.date: 07/20/2015
f1_keywords:
  - "vbc31535"
  - "bc31535"
helpviewer_keywords:
  - "BC31535"
ms.assetid: 6540c1d0-bb19-4051-a579-2e4f9094585e
---
# BC31535: Friend assembly reference \<reference> is invalid

Friend assembly reference \<reference> is invalid. Strong-name signed assemblies must specify a public key in their InternalsVisibleTo declarations.

 The assembly name passed to the <xref:System.Runtime.CompilerServices.InternalsVisibleToAttribute> attribute constructor identifies a strong-named assembly, but it does not include a `PublicKey` attribute.

 **Error ID:** BC31535

## To correct this error

1. Determine the public key for the strong-named friend assembly. Include the public key as part of the assembly name passed to the <xref:System.Runtime.CompilerServices.InternalsVisibleToAttribute> attribute constructor by using the `PublicKey` attribute.

## See also

- <xref:System.Reflection.AssemblyName>
- [Friend Assemblies](../../../standard/assembly/friend.md)
