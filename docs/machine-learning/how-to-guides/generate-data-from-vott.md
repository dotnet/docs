---
title: Generate Data from VoTT
description: How to use VoTT to generate data for object detection in Model Builder
ms.date: 07/16/2021
author: luisquintanilla
ms.author: luquinta
ms.custom: mvc,how-to
#Customer intent: As a non-developer, I want to be able to tag images and use the data in Model Builder.
---

# Generate JSON Data from VoTT

Learn how to use VoTT (Visual Object Tagging Tool) to tag images for object detection to be used within Model Builder.

## Create a new VoTT Project

1. [Download VoTT](https://github.com/Microsoft/VoTT/releases) (Visual Object Tagging Tool).
1. Open VoTT and select **New Project**.

      ![VoTT Home Screen](../media/vott.png)

1. In **Project Settings**, change the **Display Name** to the name of your choosing.
1. Change the **Security Token** to *Generate New Security Token*.
1. Next to **Source Connection**, select **Add Connection**.
1. In **Connection Settings**, change the **Display Name** for the source connection to a name of your choosing, and select *Local File System* as the **Provider**. For the **Folder Path**, select the folder that contains the training images, and then select **Save Connection**.
