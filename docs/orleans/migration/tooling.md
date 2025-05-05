---
title: Migration Tooling
description: Learn how to utilize Migration Tooling to migrate your Orleans 3.x app to Orleans 7.x+.
ms.date: 07/03/2024
---

# Migration Tooling

> [!NOTE]
> If you are running app with Orleans version higher or equal to 7.0 (further in article will be called 7.x+ - i.e. can be 7.2.6 / 8.1.0 / 9.0.0 etc), then you dont need to use migration tooling.

[Migrate from Orleans 3.x to 7.0](./guide.md) describes various new features introduced in Orleans 7.x+, and how to migrate from 3.x versions. One of (if not) the most burdensome change in Orleans 7.x+ is the change in [serialization](./guide.md#serialization) and the underlying [grain identity representation](./guide.md#grain-identities). Migration tooling introduces a set of advanced APIs which allow migration of the data in Orleans7.x+ format.

Current article explains Migration Tooling usage details, and hopefully users running Orleans3.x today will eventually migrate to Orleans 7.x+ to get latest improvements.

Prerequisites:
- you are running Orleans 3.x app
- your net version is 6.0 or higher

## 
