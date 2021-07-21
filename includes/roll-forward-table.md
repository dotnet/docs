---
author: adegeo
ms.author: adegeo
ms.date: 07/08/2021
ms.topic: include
recommendations: false
---

| Value         | Description                                                                                                                                                               |
|---------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| `Minor`       | **Default** if not specified.<br>Roll-forward to the lowest higher minor version, if requested minor version is missing. If the requested minor version is present, then the `LatestPatch` policy is used. |
| `Major`       | Roll-forward to the next available higher major version, and lowest minor version, if requested major version is missing. If the requested major version is present, then the `Minor` policy is used. |
| `LatestPatch` | Roll-forward to the highest patch version. This value disables minor version roll-forward.                                                                                      |
| `LatestMinor` | Roll-forward to highest minor version, even if requested minor version is present.                                                                                        |
| `LatestMajor` | Roll-forward to highest major and highest minor version, even if requested major is present.                                                                              |
| `Disable`     | Don't roll-forward, only bind to the specified version. This policy isn't recommended for general use since it disables the ability to roll-forward to the latest patches. This value is only recommended for testing. |
