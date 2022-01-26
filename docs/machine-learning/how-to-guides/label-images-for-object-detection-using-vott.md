---
title: Label images for object detection
description: How to use VoTT to label images for object detection in Model Builder
ms.date: 07/25/2021
author: luisquintanilla
ms.author: luquinta
ms.custom: mvc,how-to
ms.topic: how-to
#Customer intent: As a non-developer, I want to be able to tag images and use the data in Model Builder.
---

# Label Images for Object Detection using VoTT

Learn how to use VoTT (Visual Object Tagging Tool) to label images for object detection to be used within Model Builder.

## Create a new VoTT Project

1. [Download VoTT](https://github.com/Microsoft/VoTT/releases) (Visual Object Tagging Tool).
1. Open VoTT and select **New Project**.

      ![VoTT Home Screen](./media/vott/vott.png#lightbox)

1. In **Project Settings**, change the **Display Name** to the name of your choosing.
1. Change the **Security Token** to *Generate New Security Token*.
1. Next to **Source Connection**, select **Add Connection**.
1. In **Connection Settings**, change the **Display Name** for the source connection to a name of your choosing, and select *Local File System* as the **Provider**. For the **Folder Path**, select the folder that contains the training images, and then select **Save Connection**.
1. In **Project Settings**, change the **Source Connection** to the connection you just created.
1. Change the **Target Connection** to the same connection as well.
1. Select **Save Project**.

## Add tag and label images

You should now see a window with preview images of all the training images on the left, a preview of the selected image in the middle, and a **Tags** column on the right. This screen is the **Tags editor**.

1. Select the first (plus-shaped) icon in the **Tags** toolbar to add a new tag.

    ![VoTT New Tag Icon](./media/vott/vott-new-tag-icon.png#lightbox)

1. Name the tag and hit <kbd>Enter</kbd> on your keyboard.

1. Click and drag to draw a rectangle around each item in the image you want to tag. If the cursor does not let you draw a rectangle, try selecting the **Draw Rectangle** tool from the toolbar on the top, or use the keyboard shortcut <kbd>R</kbd>.

1. After drawing your rectangle, select the appropriate tag that you created in the previous steps to add the tag to the bounding box.

1. Click on the preview image for the next image in the dataset and repeat this process.

1. Continue steps 3-4 for every image.

## Export your VoTT JSON

Once you have labeled all of your training images, you can export the file that will be used by Model Builder for training.

1. Select the fourth icon in the left toolbar (the one with the diagonal arrow in a box) to go to the **Export Settings**.

1. Leave the **Provider** as *VoTT JSON*.

1. Change the **Asset State** to *Only tagged Assets*.

1. Uncheck **Include Images**. If you include the images, then the training images will be copied to the export folder that is generated, which is not necessary.

1. Select **Save Export Settings**..

    ![VoTT Export Button](./media/vott/vott-export-button.png#lightbox)

This export will create a new folder called *vott-json-export* in your project folder and will generate a JSON file named *ProjectName-export* in that new folder. You will use this JSON file for training an object detection model in Model Builder.

## Next steps

- To use VoTT with an object detection scenario in Model Builder, see [Detect stop signs in images with Model Builder](../tutorials/object-detection-model-builder.md).
