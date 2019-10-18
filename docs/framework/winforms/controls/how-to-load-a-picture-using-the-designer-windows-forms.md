---
title: "How to: Load a Picture Using the Designer (Windows Forms)"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "picture formats"
  - "images [Windows Forms], displaying on Windows Forms"
  - "pictures [Windows Forms], displaying"
  - "forms [Windows Forms], displaying images"
  - "PictureBox control [Windows Forms], adding pictures"
ms.assetid: 4dc7b973-afb1-4276-8322-20825af96655
---
# How to: Load a Picture Using the Designer (Windows Forms)

With the Windows Forms <xref:System.Windows.Forms.PictureBox> control, you can load and display a picture on a form at design time by setting the <xref:System.Windows.Forms.PictureBox.Image%2A> property to a valid picture. The following table shows the acceptable file types.

|Type|File name extension|
|---|---|
|Bitmap|.bmp|
|Icon|.ico|
|GIF|.gif|
|Metafile|.wmf|
|JPEG|.jpg|

## To display a picture at design time

1. Draw a <xref:System.Windows.Forms.PictureBox> control on a form.

2. In the **Properties** window, select the <xref:System.Windows.Forms.PictureBox.Image%2A> property, then select the ellipsis button to display the **Open** dialog box.

3. If you're looking for a specific file type (for example, .gif files), select it in the **Files of type** box.

4. Select the file you want to display.

## To clear the picture at design time

1. In the **Properties** window, select the <xref:System.Windows.Forms.PictureBox.Image%2A> property. Right-click the small thumbnail image that appears to the left of the name of the image object, and then choose **Reset**.

## See also

- <xref:System.Windows.Forms.PictureBox>
- [PictureBox Control Overview](picturebox-control-overview-windows-forms.md)
- [How to: Modify the Size or Placement of a Picture at Run Time](how-to-modify-the-size-or-placement-of-a-picture-at-run-time-windows-forms.md)
- [How to: Set Pictures at Run Time](how-to-set-pictures-at-run-time-windows-forms.md)
- [PictureBox Control](picturebox-control-windows-forms.md)
