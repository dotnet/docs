---
author: tdykstra
ms.author: tdykstra
ms.date: 01/25/2022
ms.topic: include
---
We recommend that you minimize the number of option aliases that you define, and avoid defining certain aliases in particular. The .NET CLI has several aliases that are the same across all the commands. Avoid using these aliases for other options in your apps. Here are the aliases that are defined in multiple .NET CLI commands:

* `-i` for `--interactive`.
* `-o` for `--output`.
* `-p` for `--property`.
* `-v` for `--verbosity`.
