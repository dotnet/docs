---
title: "How to: Create Graphics Objects for Drawing"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "graphics [Windows Forms], creating"
  - "images [Windows Forms], creating"
  - "GDI+, creating images"
ms.assetid: 162861f9-f050-445e-8abb-b2c43a918b8b
caps.latest.revision: 17
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Create Graphics Objects for Drawing
Before you can draw lines and shapes, render text, or display and manipulate images with [!INCLUDE[ndptecgdiplus](../../../../includes/ndptecgdiplus-md.md)], you need to create a <xref:System.Drawing.Graphics> object. The <xref:System.Drawing.Graphics> object represents a [!INCLUDE[ndptecgdiplus](../../../../includes/ndptecgdiplus-md.md)] drawing surface, and is the object that is used to create graphical images.  
  
 There are two steps in working with graphics:  
  
1.  Creating a <xref:System.Drawing.Graphics> object.  
  
2.  Using the <xref:System.Drawing.Graphics> object to draw lines and shapes, render text, or display and manipulate images.  
  
## Creating a Graphics Object  
 A graphics object can be created in a variety of ways.  
  
#### To create a graphics object  
  
-   Receive a reference to a graphics object as part of the <xref:System.Windows.Forms.PaintEventArgs> in the <xref:System.Windows.Forms.Control.Paint> event of a form or control. This is usually how you obtain a reference to a graphics object when creating painting code for a control. Similarly, you can also obtain a graphics object as a property of the <xref:System.Drawing.Printing.PrintPageEventArgs> when handling the <xref:System.Drawing.Printing.PrintDocument.PrintPage> event for a <xref:System.Drawing.Printing.PrintDocument>.  
  
     -or-  
  
-   Call the <xref:System.Windows.Forms.Control.CreateGraphics%2A> method of a control or form to obtain a reference to a <xref:System.Drawing.Graphics> object that represents the drawing surface of that control or form. Use this method if you want to draw on a form or control that already exists.  
  
     -or-  
  
-   Create a <xref:System.Drawing.Graphics> object from any object that inherits from <xref:System.Drawing.Image>. This approach is useful when you want to alter an already existing image.  
  
     The following sections give details about each of these processes.  
  
## PaintEventArgs in the Paint Event Handler  
 When programming the <xref:System.Windows.Forms.PaintEventHandler> for controls or the <xref:System.Drawing.Printing.PrintDocument.PrintPage> for a <xref:System.Drawing.Printing.PrintDocument>, a graphics object is provided as one of the properties of <xref:System.Windows.Forms.PaintEventArgs> or <xref:System.Drawing.Printing.PrintPageEventArgs>.  
  
#### To obtain a reference to a Graphics object from the PaintEventArgs in the Paint event  
  
1.  Declare the <xref:System.Drawing.Graphics> object.  
  
2.  Assign the variable to refer to the <xref:System.Drawing.Graphics> object passed as part of the <xref:System.Windows.Forms.PaintEventArgs>.  
  
3.  Insert code to paint the form or control.  
  
     The following example shows how to reference a <xref:System.Drawing.Graphics> object from the <xref:System.Windows.Forms.PaintEventArgs> in the <xref:System.Windows.Forms.Control.Paint> event:  
  
    ```vb  
    Private Sub Form1_Paint(sender As Object, pe As PaintEventArgs) Handles _  
       MyBase.Paint  
       ' Declares the Graphics object and sets it to the Graphics object  
       ' supplied in the PaintEventArgs.  
       Dim g As Graphics = pe.Graphics  
       ' Insert code to paint the form here.  
    End Sub  
    ```  
  
    ```csharp  
    private void Form1_Paint(object sender,   
       System.Windows.Forms.PaintEventArgs pe)   
    {  
       // Declares the Graphics object and sets it to the Graphics object  
       // supplied in the PaintEventArgs.  
       Graphics g = pe.Graphics;  
       // Insert code to paint the form here.  
    }  
    ```  
  
    ```cpp  
    private:  
       void Form1_Paint(System::Object ^ sender,  
          System::Windows::Forms::PaintEventArgs ^ pe)  
       {  
          // Declares the Graphics object and sets it to the Graphics object  
          // supplied in the PaintEventArgs.  
          Graphics ^ g = pe->Graphics;  
          // Insert code to paint the form here.  
       }  
    ```  
  
## CreateGraphics Method  
 You can also use the <xref:System.Windows.Forms.Control.CreateGraphics%2A> method of a control or form to obtain a reference to a <xref:System.Drawing.Graphics> object that represents the drawing surface of that control or form.  
  
#### To create a Graphics object with the CreateGraphics method  
  
-   Call the <xref:System.Windows.Forms.Control.CreateGraphics%2A> method of the form or control upon which you want to render graphics.  
  
    ```vb  
    Dim g as Graphics  
    ' Sets g to a Graphics object representing the drawing surface of the  
    ' control or form g is a member of.  
    g = Me.CreateGraphics  
    ```  
  
    ```csharp  
    Graphics g;  
    // Sets g to a graphics object representing the drawing surface of the  
    // control or form g is a member of.  
    g = this.CreateGraphics();  
    ```  
  
    ```cpp  
    Graphics ^ g;  
    // Sets g to a graphics object representing the drawing surface of the  
    // control or form g is a member of.  
    g = this->CreateGraphics();  
    ```  
  
## Create from an Image Object  
 Additionally, you can create a graphics object from any object that derives from the <xref:System.Drawing.Image> class.  
  
#### To create a Graphics object from an Image  
  
-   Call the <xref:System.Drawing.Graphics.FromImage%2A?displayProperty=nameWithType> method, supplying the name of the Image variable from which you want to create a <xref:System.Drawing.Graphics> object.  
  
     The following example shows how to use a <xref:System.Drawing.Bitmap> object:  
  
    ```vb  
    Dim myBitmap as New Bitmap("C:\Documents and Settings\Joe\Pics\myPic.bmp")  
    Dim g as Graphics = Graphics.FromImage(myBitmap)  
    ```  
  
    ```csharp  
    Bitmap myBitmap = new Bitmap(@"C:\Documents and   
       Settings\Joe\Pics\myPic.bmp");  
    Graphics g = Graphics.FromImage(myBitmap);  
    ```  
  
    ```cpp  
    Bitmap ^ myBitmap = gcnew  
       Bitmap("D:\\Documents and Settings\\Joe\\Pics\\myPic.bmp");  
    Graphics ^ g = Graphics::FromImage(myBitmap);  
    ```  
  
> [!NOTE]
>  You can only create <xref:System.Drawing.Graphics> objects from nonindexed .bmp files, such as 16-bit, 24-bit, and 32-bit .bmp files. Each pixel of nonindexed .bmp files holds a color, in contrast to pixels of indexed .bmp files, which hold an index to a color table.  
  
-  
  
## Drawing and Manipulating Shapes and Images  
 After it is created, a <xref:System.Drawing.Graphics> object may be used to draw lines and shapes, render text, or display and manipulate images. The principal objects that are used with the <xref:System.Drawing.Graphics> object are:  
  
-   The <xref:System.Drawing.Pen> class—Used for drawing lines, outlining shapes, or rendering other geometric representations.  
  
-   The <xref:System.Drawing.Brush> class—Used for filling areas of graphics, such as filled shapes, images, or text.  
  
-   The <xref:System.Drawing.Font> class—Provides a description of what shapes to use when rendering text.  
  
-   The <xref:System.Drawing.Color> structure—Represents the different colors to display.  
  
#### To use the Graphics object you have created  
  
-   Work with the appropriate object listed above to draw what you need.  
  
     For more information, see the following topics:  
  
    |To render|See|  
    |---------------|---------|  
    |Lines|[How to: Draw a Line on a Windows Form](../../../../docs/framework/winforms/advanced/how-to-draw-a-line-on-a-windows-form.md)|  
    |Shapes|[How to: Draw an Outlined Shape](../../../../docs/framework/winforms/advanced/how-to-draw-an-outlined-shape.md)|  
    |Text|[How to: Draw Text on a Windows Form](../../../../docs/framework/winforms/advanced/how-to-draw-text-on-a-windows-form.md)|  
    |Images|[How to: Render Images with GDI+](../../../../docs/framework/winforms/advanced/how-to-render-images-with-gdi.md)|  
  
## See Also  
 [Getting Started with Graphics Programming](../../../../docs/framework/winforms/advanced/getting-started-with-graphics-programming.md)  
 [Graphics and Drawing in Windows Forms](../../../../docs/framework/winforms/advanced/graphics-and-drawing-in-windows-forms.md)  
 [Lines, Curves, and Shapes](../../../../docs/framework/winforms/advanced/lines-curves-and-shapes.md)  
 [How to: Render Images with GDI+](../../../../docs/framework/winforms/advanced/how-to-render-images-with-gdi.md)
