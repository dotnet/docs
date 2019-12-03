---
title: "How to: Add or Remove ImageList Images with the Designer"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "ImageList component [Windows Forms], adding images"
  - "ImageList component [Windows Forms], removing images"
  - "images [Windows Forms], adding to ImageList component"
ms.assetid: 5699b244-e37c-4d20-bc35-7441e55c1e3a
---
# How to: Add or Remove ImageList Images with the Designer

You can add images to an <xref:System.Windows.Forms.ImageList> component several different ways. You can add images very quickly by using the smart tag associated with the <xref:System.Windows.Forms.ImageList>, or if you are setting several other properties on the <xref:System.Windows.Forms.ImageList>, you may find it more convenient to add images with the Properties window. You can also add images by using code. For more information about how to add images with code, see [How to: Add or Remove Images with the Windows Forms ImageList Component](how-to-add-or-remove-images-with-the-windows-forms-imagelist-component.md). Typically you populate the <xref:System.Windows.Forms.ImageList> component with images before it is associated with a control, but this is not required.

### To add or remove images by using the Properties window

1. Select the <xref:System.Windows.Forms.ImageList> component, or add one to the form.

2. In the Properties window, click the ellipsis button (![The Ellipsis button (...) in the Properties window of Visual Studio.](./media/visual-studio-ellipsis-button.png)) next to the <xref:System.Windows.Forms.ImageList.Images%2A> property.

3. In the **Image Collection Editor**, click **Add** or **Remove** to add or remove images from the list.

### To add or remove images using the smart tag

1. Select the <xref:System.Windows.Forms.ImageList> component, or add one to the form.

2. Click the smart tag glyph (![Smart Tag Glyph](./media/vs-winformsmttagglyph.gif "VS_WinFormSmtTagGlyph"))

3. In the **ImageList Tasks** dialog box, select **Choose Images**.

4. In the **Images Collection Editor** click **Add** or **Remove** to add or remove images from the list.

## See also

- [Images, Bitmaps, and Metafiles](../advanced/images-bitmaps-and-metafiles.md)
- [Walkthrough: Performing Common Tasks Using Smart Tags on Windows Forms Controls](performing-common-tasks-using-smart-tags-on-wf-controls.md)
- [ImageList Component](imagelist-component-windows-forms.md)
