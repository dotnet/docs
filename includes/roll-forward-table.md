---
author: adegeo
ms.author: adegeo
ms.date: 05/16/2025
ms.topic: include
recommendations: false
---

| Value         | Description                                                                                                                                                               |
|---------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| `Minor`       | **Default** if not specified.<br>Roll-forward to the lowest higher minor version (and highest available patch version within that minor version), if requested minor version is missing. If the requested minor version is present, then the `LatestPatch` policy is used. |
| `Major`       | Roll-forward to the next available higher major version (at its lowest available minor version, and highest available patch version within that minor version), if requested major version is missing. If the requested major version is present, then the `Minor` policy is used. |
| `LatestPatch` | Roll-forward to the highest patch version available for the requested major and minor versions. This value disables minor version roll-forward.                                                                                      |
| `LatestMinor` | Roll-forward to the highest minor version available for the requested major version (and highest available patch version within that minor version), even if requested minor version is present.                                                                                        |
| `LatestMajor` | Roll-forward to highest available major version (and highest available minor and patch version within that major version), even if requested major is present.                                                                              |
| `Disable`     | Don't roll-forward, only bind to the specified version. This policy isn't recommended for general use since it disables the ability to roll-forward to the latest patches. This value is only recommended for testing. |

For example, suppose an application requests version `8.0.0`, while the locally available versions are `8.2.0`, `8.2.3`, `8.4.5`, `9.0.0`, `9.0.6`, `9.7.8`.
Then the resolved version is as follows in each case:

| Value         | Resolved version | Resolved version if `8.0.1` were also available |
|---------------|------------------|-------------------------------------------------|
| `Minor`       | `8.2.3`          | `8.0.1`                                         |
| `Major`       | `8.2.3`          | `8.0.1`                                         |
| `LatestPatch` | (fails)          | `8.0.1`                                         |
| `LatestMinor` | `8.4.5`          | `8.4.5`                                         |
| `LatestMajor` | `9.7.8`          | `9.7.8`                                         |
| `Disable`     | (fails)          | (fails)                                         |

