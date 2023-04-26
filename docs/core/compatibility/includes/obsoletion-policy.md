---
ms.topic: include
ms.date: 04/26/2023
---

.NET rarely removes an API due to the large impact it has by breaking compatibility. Removal is done only when there's an unavoidable and justifiable reason. .NET strives to provide mitigations to such impactful breaking changes in advance, for example, by:

- Posting in [dotnet/announcements](https://github.com/dotnet/announcements).
- Blogging about it.
- Marking the API as obsolete or providing build diagnostics.

In most cases, an API that shipped in a long-term support (LTS) release must be obsoleted in the subsequent LTS release before it can be removed. In rare cases based on business needs, exceptions are made to obsolete an API before the subsequent LTS release. All obsoletions are documented and communicated to customers.
