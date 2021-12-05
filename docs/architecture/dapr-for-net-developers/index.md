---
title: Dapr for .NET Developers
description: A guide for .NET developers to understand and leverage the full power of Microsoft's open source Distributed Application Runtime.
author: robvet
ms.date: 11/19/2021
---

# Dapr for .NET Developers

![cover image](./media/cover.png)

**EDITION v1.1**

PUBLISHED BY

Microsoft Developer Division, .NET, and Azure Incubations teams

A division of Microsoft Corporation

One Microsoft Way

Redmond, Washington 98052-6399

Copyright &copy; 2021 by Microsoft Corporation

All rights reserved. No part of the contents of this book may be reproduced or transmitted in any form or by any means without the written permission of the publisher.

This book is provided "as-is" and expresses the author's views and opinions. The views, opinions, and information expressed in this book, including URL and other Internet website references, may change without notice.

Some examples depicted herein are provided for illustration only and are fictitious. No real association or connection is intended or should be inferred.

Microsoft and the trademarks listed at <https://www.microsoft.com> on the "Trademarks" webpage are trademarks of the Microsoft group of companies.

Mac and macOS are trademarks of Apple Inc.

The Docker whale logo is a registered trademark of Docker, Inc. Used by permission.

All other marks and logos are property of their respective owners.

Authors:

> **Rob Vettor**, Principal Cloud Solution Architect - [thinkingincloudnative.com](https://thinkingincloudnative.com/about/), Microsoft
>
> **Sander Molenkamp**, Principal Cloud Architect/Microsoft MVP - [sandermolenkamp.com](https://www.sandermolenkamp.com), [Info Support](https://www.infosupport.com/en/)
>
> **Edwin van Wijk**, Principal Solution Architect/Microsoft MVP - [defaultconstructor.com](https://defaultconstructor.com), [Info Support](https://www.infosupport.com/en/)

Participants and Reviewers:

> **Mark Russinovich**, Azure CTO and Technical Fellow, Azure Office of CTO, Microsoft
>
> **Nish Anil**, Senior Program Manager, .NET team, Microsoft
>
> **Mark Fussell**, Principal Program Manager, Azure Incubations, Microsoft
>
> **Yaron Schneider**, Principal Software Engineer, Azure Incubations, Microsoft
>
> **Ori Zohar**, Senior Program Manager, Azure Incubations, Microsoft

Editors:

> **David Pine**, Senior Content Developer, .NET team, Microsoft
>
> **Maira Wenzel**, Senior Program Manager, .NET team, Microsoft

## Version

This guide has been written to cover the **Dapr 1.5** version. .NET samples are based on **.NET 6**.

## Who should use this guide

The audience for this guide is mainly developers, development leads, and architects who are interested in learning how to build applications designed for the cloud.

A secondary audience is technical decision-makers who plan to choose whether to build their applications using a cloud-native approach.

## How you can use this guide

This guide is available both in [PDF](https://aka.ms/dapr-ebook) form and online. Feel free to forward this document or links to its online version to your team to help ensure common understanding of these topics. Most of these topics benefit from a consistent understanding of the underlying principles and patterns, as well as the trade-offs involved in decisions related to these topics. Our goal with this document is to equip teams and their leaders with the information they need to make well-informed decisions for their applications' architecture, development, and hosting.

## Send your feedback

This book and related samples are constantly evolving, so your feedback is welcomed! If you have comments about how this book can be improved, use the feedback section at the bottom of any page built on [GitHub issues](https://github.com/dotnet/docs/issues).

>[!div class="step-by-step"]
>[Next](foreword.md)
