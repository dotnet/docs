---
title: "Walkthrough: Arranging Controls on Windows Forms Using Snaplines"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "controls [Windows Forms], arranging with snaplines"
  - "snaplines [Windows Forms], arranging Windows Forms controls"
  - "SnapLine class [Windows Forms], walkthroughs"
  - "Windows Forms controls, arranging"
ms.assetid: d5c9edc7-cf30-4a97-8ebe-201d569340f8
caps.latest.revision: 24
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Walkthrough: Arranging Controls on Windows Forms Using Snaplines
Precise placement of controls on your form is a high priority for many applications. The Windows Forms Designer gives you many layout tools to accomplish this. One of the most important is the <xref:System.Windows.Forms.Design.Behavior.SnapLine> feature.  
  
 Snaplines show you precisely where to line up controls with other controls. They also show you the recommended distances for margins between controls, as specified by the Windows User Interface Guidelines. For details, see [User Interface Design and Development](http://go.microsoft.com/FWLink/?LinkId=83878).  
  
 Snaplines make it easy to align your controls, for crisp, professional appearance and behavior (look and feel).  
  
 Tasks illustrated in this walkthrough include:  
  
-   Creating a Windows Forms project  
  
-   Spacing and Aligning Controls Using Snaplines  
  
-   Aligning to Form and Container Margins  
  
-   Aligning to Grouped Controls  
  
-   Using Snaplines to Place a Control by Outlining Its Size  
  
-   Using Snaplines When Dragging a Control from the Toolbox  
  
-   Resizing Controls Using Snaplines  
  
-   Aligning a Label to a Control's Text  
  
-   Using Snaplines with Keyboard Navigation  
  
-   Snaplines and Layout Panels  
  
-   Disabling Snaplines  
  
 When you are finished, you will have an understanding of the layout role played by the snaplines feature.  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
## Creating the Project  
 The first step is to create the project and set up the form.  
  
#### To create the project  
  
1.  Create a Windows-based application project called "SnaplineExample". For details, see [How to: Create a Windows Application Project](http://msdn.microsoft.com/library/b2f93fed-c635-4705-8d0e-cf079a264efa).  
  
2.  Select the form in the Forms Designer.  
  
## Spacing and Aligning Controls Using Snaplines  
 Snaplines give you an accurate and intuitive way to align controls on your form. They appear when you are moving a selected control or controls near a position that would align with another control or set of controls. Your selection will "snap" to the suggested position as you move it past the other controls.  
  
#### To arrange controls using snaplines  
  
1.  Drag a <xref:System.Windows.Forms.Button> control from the **Toolbox** onto your form.  
  
2.  Move the <xref:System.Windows.Forms.Button> control to the lower-right corner of the form. Note the snaplines that appear as the <xref:System.Windows.Forms.Button> control approaches the bottom and right borders of the form. These snaplines display the recommended distance between the borders of the control and the form.  
  
3.  Move the <xref:System.Windows.Forms.Button> control around the borders of the form and note where the snaplines appear. When you are finished, move the <xref:System.Windows.Forms.Button> control near the center of the form.  
  
4.  Drag another <xref:System.Windows.Forms.Button> control from the **Toolbox** onto your form.  
  
5.  Move the second <xref:System.Windows.Forms.Button> control until it is nearly level with the first. Note the snapline that appears at the text baseline of both buttons, and note that the control you are moving snaps to a position that is exactly level with the other control.  
  
6.  Move the second <xref:System.Windows.Forms.Button> control until it is positioned directly above the first. Note the snaplines that appear along the left and right edges of both buttons, and note that the control you are moving snaps to a position that is exactly aligned with the other control.  
  
7.  Select one of the <xref:System.Windows.Forms.Button> controls and move it close to the other, until they are almost touching. Note the snapline that appears between them. This distance is the recommended distance between the borders of the controls. Also note that the control you are moving snaps to this position.  
  
8.  Drag two <xref:System.Windows.Forms.Panel> controls from the **Toolbox** onto your form.  
  
9. Move one of the <xref:System.Windows.Forms.Panel> controls until it is nearly level with the first. Note the snaplines that appear along the top and bottom edges of both controls, and note that the control you are moving snaps to a position that is exactly level with the other control.  
  
## Aligning to Form and Container Margins  
 Snaplines help you to align your controls to form and container margins in a consistent manner.  
  
#### To align controls to form and container margins  
  
1.  Select one of the <xref:System.Windows.Forms.Button> controls and move it close to the right border of the form until a snapline appears. The snapline's distance from the right border is the sum of the control's <xref:System.Windows.Forms.Control.Margin%2A> property and the form's <xref:System.Windows.Forms.Control.Padding%2A> property values.  
  
> [!NOTE]
>  If the form's <xref:System.Windows.Forms.Control.Padding%2A> property is set to 0,0,0,0, the Windows Forms Designer gives the form a shadowed <xref:System.Windows.Forms.Control.Padding%2A> value of 9,9,9,9. To override this behavior, assign a value other than 0,0,0,0.  
  
1.  Change the value of the <xref:System.Windows.Forms.Button> control's <xref:System.Windows.Forms.Control.Margin%2A> property by expanding the <xref:System.Windows.Forms.Control.Margin%2A> entry in the **Properties** window and setting the <xref:System.Windows.Forms.Padding.All%2A> property to 0. For details, see [Walkthrough: Laying Out Windows Forms Controls with Padding, Margins, and the AutoSize Property](../../../../docs/framework/winforms/controls/windows-forms-controls-padding-autosize.md).  
  
2.  Move the <xref:System.Windows.Forms.Button> control close to the right border of the form until a snapline appears. This distance is now given by the value of the form's <xref:System.Windows.Forms.Control.Padding%2A> property.  
  
3.  Drag a <xref:System.Windows.Forms.GroupBox> control from the **Toolbox** onto your form.  
  
4.  Change the value of the <xref:System.Windows.Forms.GroupBox> control's <xref:System.Windows.Forms.Control.Padding%2A> property by expanding the <xref:System.Windows.Forms.Control.Padding%2A> entry in the **Properties** window and setting the <xref:System.Windows.Forms.Padding.All%2A> property to 10.  
  
5.  Drag a <xref:System.Windows.Forms.Button> control from the **Toolbox** into the <xref:System.Windows.Forms.GroupBox> control.  
  
6.  Move the <xref:System.Windows.Forms.Button> control close to the right border of the <xref:System.Windows.Forms.GroupBox> control until a snapline appears. Move the <xref:System.Windows.Forms.Button> control within the <xref:System.Windows.Forms.GroupBox> control and note where the snaplines appear.  
  
## Aligning to Grouped Controls  
 You can use snaplines to align grouped controls as well as controls within a <xref:System.Windows.Forms.GroupBox> control.  
  
#### To align to grouped controls  
  
1.  Select two of the controls on your form. Move the selection around and note the snaplines that appear between your selection and the other controls.  
  
2.  Drag a <xref:System.Windows.Forms.GroupBox> control from the **Toolbox** onto your form.  
  
3.  Drag a <xref:System.Windows.Forms.Button> control from the **Toolbox** into the <xref:System.Windows.Forms.GroupBox> control.  
  
4.  Select one of the <xref:System.Windows.Forms.Button> controls and move it around the <xref:System.Windows.Forms.GroupBox> control. Note the snaplines that appear at the edges of the <xref:System.Windows.Forms.GroupBox> control. Also note the snaplines that appear at the edges of the <xref:System.Windows.Forms.Button> control that is contained by the <xref:System.Windows.Forms.GroupBox> control. Controls that are children of a container control also support snaplines.  
  
## Using Snaplines to Place a Control by Outlining Its Size  
 Snaplines help you align controls when you first place them on a form.  
  
#### To use snaplines to place a control by outlining its size  
  
1.  In the **Toolbox**, click the <xref:System.Windows.Forms.Button> control icon. Do not drag it onto the form.  
  
2.  Move the mouse pointer over the form's design surface. Note that the pointer changes to a crosshair with the <xref:System.Windows.Forms.Button> control icon attached. Also note the snaplines that appear to suggest aligned positions for the <xref:System.Windows.Forms.Button> control.  
  
3.  Click and hold the mouse button.  
  
4.  Drag the mouse pointer around the form. Note that an outline is drawn, indicating the position and the size of the control.  
  
5.  Drag the pointer until it aligns with another control on the form. Note that a snapline appears to indicate alignment.  
  
6.  Release the mouse button. The control is created at the position and size indicated by the outline.  
  
## Using Snaplines When Dragging a Control from the Toolbox  
 Snaplines help you align controls when you drag them from the **Toolbox** onto your form.  
  
#### To use snaplines when dragging a control from the Toolbox  
  
1.  Drag a <xref:System.Windows.Forms.Button> control from the **Toolbox** onto your form, but do not release the mouse button.  
  
2.  Move the mouse pointer over the form's design surface. Note that the pointer changes to indicate the position at which the new <xref:System.Windows.Forms.Button> control will be created.  
  
3.  Drag the mouse pointer around the form. Note the snaplines that appear to suggest aligned positions for the <xref:System.Windows.Forms.Button> control. Find a position that is aligned with other controls.  
  
4.  Release the mouse button. The control is created at the position indicated by the snaplines.  
  
## Resizing Controls Using Snaplines  
 Snaplines help you align controls as you resize them.  
  
#### To resize a control using snaplines  
  
1.  Drag a <xref:System.Windows.Forms.Button> control from the **Toolbox** onto your form.  
  
2.  Resize the <xref:System.Windows.Forms.Button> control by grabbing one of the corner sizing handles and dragging. For details, see [How to: Resize Controls on Windows Forms](../../../../docs/framework/winforms/controls/how-to-resize-controls-on-windows-forms.md).  
  
3.  Drag the sizing handle until one of the <xref:System.Windows.Forms.Button> control's borders is aligned with another control. Note that a snapline appears. Also note that the sizing handle snaps to the position indicated by the snapline.  
  
4.  Resize the <xref:System.Windows.Forms.Button> control in different directions and align the sizing handle to different controls. Note how the snaplines appear in various orientations to indicate alignment.  
  
## Aligning a Label to a Control's Text  
 Some controls offer a snapline for aligning other controls to displayed text.  
  
#### To align a label to a control's text  
  
1.  Drag a <xref:System.Windows.Forms.TextBox> control from the **Toolbox** onto your form. When you drop the <xref:System.Windows.Forms.TextBox> control onto the form, click the smart-tag glyph and select the **Set text to textBox1** option. For details, see [Walkthrough: Performing Common Tasks Using Smart Tags on Windows Forms Controls](../../../../docs/framework/winforms/controls/performing-common-tasks-using-smart-tags-on-wf-controls.md).  
  
2.  Drag a <xref:System.Windows.Forms.Label> control from the **Toolbox** onto your form.  
  
3.  Change the value of the <xref:System.Windows.Forms.Label> control's <xref:System.Windows.Forms.Control.AutoSize%2A> property to `true`. Note that the control's borders are adjusted to fit the display text.  
  
4.  Move the <xref:System.Windows.Forms.Label> control to the left of the <xref:System.Windows.Forms.TextBox> control, so it is aligned with the bottom edge of the <xref:System.Windows.Forms.TextBox> control. Note the snapline that appears along the bottom edges of the two controls.  
  
5.  Move the <xref:System.Windows.Forms.Label> control slightly upward, until the <xref:System.Windows.Forms.Label> text and the <xref:System.Windows.Forms.TextBox> text are aligned. Note the differently styled snapline that appears, indicating when the text fields of both controls are aligned.  
  
## Using Snaplines with Keyboard Navigation  
 Snaplines help you align controls when you are arranging them using the keyboard's arrow keys.  
  
#### To use snaplines with keyboard navigation  
  
1.  Drag a <xref:System.Windows.Forms.Button> control from the **Toolbox** onto your form. Place it in the upper-left corner of the form.  
  
2.  Press CTRL+DOWN ARROW. Note that the control moves down the form to the first available horizontal alignment position.  
  
3.  Press CTRL+DOWN ARROW until the control reaches the bottom of the form. Note the positions it occupies as it moves down the form.  
  
4.  Press CTRL+RIGHT ARROW. Note that the control moves across the form to the first available vertical alignment position.  
  
5.  Press CTRL+RIGHT ARROW until the control reaches the side of the form. Note the positions it occupies as it moves across the form.  
  
6.  Move the control around the form with a combination of arrow keys. Note the positions the control occupies and the snaplines that accompany them.  
  
7.  Press SHIFT+any arrow key to resize the <xref:System.Windows.Forms.Button> control by increments of one pixel.  
  
8.  Press CTRL+SHIFT+any arrow key to resize the <xref:System.Windows.Forms.Button> control in snapline increments.  
  
## Snaplines and Layout Panels  
 Snaplines are disabled within layout panels.  
  
#### To selectively disable snaplines  
  
1.  Drag a <xref:System.Windows.Forms.TableLayoutPanel> control from the **Toolbox** onto your form.  
  
2.  Double-click the <xref:System.Windows.Forms.Button> control icon in the **Toolbox**. Note that a new button control appears in the <xref:System.Windows.Forms.TableLayoutPanel> control's first cell.  
  
3.  Double-click the <xref:System.Windows.Forms.Button> control icon in the **Toolbox** twice more. This leaves one empty cell in the <xref:System.Windows.Forms.TableLayoutPanel> control.  
  
4.  Drag a <xref:System.Windows.Forms.Button> control from the **Toolbox** into the empty cell of the <xref:System.Windows.Forms.TableLayoutPanel> control. Note that no snaplines appear.  
  
5.  Drag the <xref:System.Windows.Forms.Button> control out of the <xref:System.Windows.Forms.TableLayoutPanel> control and move it around the <xref:System.Windows.Forms.TableLayoutPanel> control. Note that snaplines appear again.  
  
## Disabling Snaplines  
 Snaplines are turned on by default. You can disable snaplines selectively, or you can disable them in the design environment.  
  
#### To selectively disable snaplines  
  
-   Press the ALT key and while moving a control around the form.  
  
     Note that no snaplines appear and the control does not snap to any potential alignment positions.  
  
#### To disable snaplines in the design environment  
  
1.  From the **Tools** menu, open the **Options** dialog box. Open the Windows Forms Designer dialog box. For details, see [General, Windows Forms Designer, Options Dialog Box](http://msdn.microsoft.com/library/8dd170af-72f0-4212-b04b-034ceee92834).  
  
2.  Select the **General** node. In the **Layout Mode** section, change the selection from **SnapLines** to **SnapToGrid**.  
  
3.  Click OK to apply the setting.  
  
4.  Select a control on your form and move it around the other controls. Note that snaplines do not appear.  
  
## Next Steps  
 Snaplines offer an intuitive means of aligning controls on your form. Suggestions for more exploration include:  
  
-   Try nesting a <xref:System.Windows.Forms.GroupBox> control within another <xref:System.Windows.Forms.GroupBox> control. Place a <xref:System.Windows.Forms.Button> control within the child <xref:System.Windows.Forms.GroupBox> control, and another within the parent <xref:System.Windows.Forms.GroupBox> control. Move the <xref:System.Windows.Forms.Button> controls around to see how the snaplines cross container boundaries.  
  
-   Create a column of <xref:System.Windows.Forms.TextBox> controls and a corresponding column of <xref:System.Windows.Forms.Label> controls. Set the value of the <xref:System.Windows.Forms.Label> controls' <xref:System.Windows.Forms.Control.AutoSize%2A> property to `true`. Use snaplines to move the <xref:System.Windows.Forms.Label> controls so their displayed text is aligned with the text in the <xref:System.Windows.Forms.TextBox> controls.  
  
 For information about Windows user interface design, see the book *Microsoft Windows User Experience, Official Guidelines for User Interface Developers and Designers* Redmond, WA: Microsoft Press, 1999. (USBN: 0-7356-0566-1).  
  
## See Also  
 <xref:System.Windows.Forms.Design.Behavior.SnapLine>  
 [Walkthrough: Arranging Controls on Windows Forms Using a FlowLayoutPanel](../../../../docs/framework/winforms/controls/walkthrough-arranging-controls-on-windows-forms-using-a-flowlayoutpanel.md)  
 [Walkthrough: Arranging Controls on Windows Forms Using a TableLayoutPanel](../../../../docs/framework/winforms/controls/walkthrough-arranging-controls-on-windows-forms-using-a-tablelayoutpanel.md)  
 [Walkthrough: Laying Out Windows Forms Controls with Padding, Margins, and the AutoSize Property](../../../../docs/framework/winforms/controls/windows-forms-controls-padding-autosize.md)  
 [Arranging Controls on Windows Forms](../../../../docs/framework/winforms/controls/arranging-controls-on-windows-forms.md)
