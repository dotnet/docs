---
title: "Resolve errors and warnings related to readonly struct members"
description: "This article helps you diagnose and correct compiler errors and warnings related to readonly struct members"
f1_keywords:
  - "CS8656"
  - "CS8662"
helpviewer_keywords:
  - "CS8656"
  - "CS8662"
ms.date: 07/16/2026
ai-usage: ai-assisted
---
# Resolve errors and warnings related to readonly struct members

This article covers the following compiler errors and warnings:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS8656**](#readonly-struct-member-restrictions): *Call to non-readonly member 'member' from a 'readonly' member results in an implicit copy of 'type'.*
- [**CS8662**](#readonly-struct-member-restrictions): *Field-like event 'event' cannot be 'readonly'.*

## Readonly struct member restrictions

- **CS8656**: *Call to non-readonly member 'member' from a 'readonly' member results in an implicit copy of 'type'.*
- **CS8662**: *Field-like event 'event' cannot be 'readonly'.*

A [`readonly` instance member](../builtin-types/struct.md#readonly-instance-members) of a struct can't mutate `this`. When a `readonly` member calls a non-`readonly` member, the compiler copies `this` before the call so the non-`readonly` member can't modify the original instance. Mark the called member `readonly` when it doesn't modify instance state, or call only members that are already `readonly` (**CS8656**). If the called member must mutate instance state, remove `readonly` from the caller.

Field-like events can't be marked `readonly` (**CS8662**). Remove the `readonly` modifier from the event, or implement the event manually with `add` and `remove` accessors that follow the readonly rules for the containing struct.
