---
ms.topic: include
ms.date: 04/26/2023
---

.NET rarely removes an API due to the large impact it has of breaking compatibility. Removal is done only when there's an unavoidable and justifiable reason. .NET strives to provide mitigations to such impactful breaking changes in advance, for example, by:

- Marking the API as obsolete or providing build diagnostics.
- Blogging about it.
- Documenting it under [Breaking changes in .NET](../breaking-changes.md).

In most cases, an API that shipped in a long-term support (LTS) release must be obsoleted in the subsequent LTS release before it can be removed. In rare cases based on business needs, exceptions are made to obsolete an API before the subsequent LTS release. All obsoletions are documented and communicated to customers.
