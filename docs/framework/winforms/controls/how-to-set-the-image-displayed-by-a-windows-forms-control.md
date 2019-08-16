---
title: "How to: Set the Image Displayed by a Windows Forms Control"
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords:
  - "Button control [Windows Forms], images"
  - "Windows Forms controls, images"
  - "controls [Windows Forms], images"
  - "images [Windows Forms], Windows Forms controls"
  - "examples [Windows Forms], controls"
ms.assetid: 9445af8f-4f62-48b0-a3f6-068058964b9f
---
# How to: Set the image displayed by a Windows Forms control

Several Windows Forms controls can display images. These images can be icons that clarify the purpose of the control, such as a diskette icon on a button denoting the Save command. Alternatively, the icons can be background images to give the control the appearance and behavior you want.

## Programmatic

1. Set the control's `Image` or `BackgroundImage` property to an object of type <xref:System.Drawing.Image>. Generally, you'll be loading the image from a file by using the <xref:System.Drawing.Image.FromFile%2A> method.

   In the following code example, the path set for the location of the image is the **My Pictures** folder. Most computers running the Windows operating system include this directory. This also enables users with minimal system access levels to run the application safely. The following code example requires that you already have a form with a <xref:System.Windows.Forms.PictureBox> control added.

    ```vb
    ' Replace the image named below
    ' with an icon of your own choosing.
    PictureBox1.Image = Image.FromFile _
       (System.Environment.GetFolderPath _
       (System.Environment.SpecialFolder.MyPictures) _
       & "\Image.gif")
    ```

    ```csharp
    // Replace the image named below
    // with an icon of your own choosing.
    // Note the escape character used (@) when specifying the path.
    pictureBox1.Image = Image.FromFile
       (System.Environment.GetFolderPath
       (System.Environment.SpecialFolder.MyPictures)
       + @"\Image.gif");
    ```

    ```cpp
    // Replace the image named below
    // with an icon of your own choosing.
    pictureBox1->Image = Image::FromFile(String::Concat
       (System::Environment::GetFolderPath
       (System::Environment::SpecialFolder::MyPictures),
       "\\Image.gif"));
    ```

## Designer

1. In the **Properties** window of Visual Studio, select the **Image** or **BackgroundImage** property of the control, and then select the ellipsis (![Ellipsis button in Visual Studio](./media/visual-studio-ellipsis-button.png)) to display the **Select Resource** dialog box.

2. Select the image you want to display.

## See also

- <xref:System.Drawing.Image.FromFile%2A>
- <xref:System.Drawing.Image>
- <xref:System.Windows.Forms.Control.BackgroundImage%2A>
