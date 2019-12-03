---
title: "Walkthrough: Arranging Controls on Windows Forms Using Snaplines"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "controls [Windows Forms], arranging with snaplines"
  - "snaplines [Windows Forms], arranging Windows Forms controls"
  - "SnapLine class [Windows Forms], walkthroughs"
  - "Windows Forms controls, arranging"
ms.assetid: d5c9edc7-cf30-4a97-8ebe-201d569340f8
author: jillre
ms.author: jillfra
manager: jillfra
---
# Walkthrough: Arrange controls on Windows Forms using snaplines

Precise placement of controls on your form is a high priority for many applications. The Windows Forms Designer gives you many layout tools to accomplish this. One of the most important is the <xref:System.Windows.Forms.Design.Behavior.SnapLine> feature.

Snaplines show you precisely where to line up controls with other controls. They also show you the recommended distances for margins between controls, as specified by the [Windows User Interface guidelines](/windows/win32/uxguide/guidelines).

Snaplines make it easy to align your controls, for crisp, professional appearance and behavior (look and feel).

## Create the project

1. In Visual Studio, create a Windows-based application project called "SnaplineExample".

2. Select the form in the Forms Designer.

## Space and align controls

Snaplines give you an accurate and intuitive way to align controls on your form. They appear when you are moving a selected control or controls near a position that would align with another control or set of controls. Your selection will "snap" to the suggested position as you move it past the other controls.

### To arrange controls using snaplines

1. Drag a <xref:System.Windows.Forms.Button> control from the **Toolbox** onto your form.

2. Move the <xref:System.Windows.Forms.Button> control to the lower-right corner of the form. Note the snaplines that appear as the <xref:System.Windows.Forms.Button> control approaches the bottom and right borders of the form. These snaplines display the recommended distance between the borders of the control and the form.

3. Move the <xref:System.Windows.Forms.Button> control around the borders of the form and note where the snaplines appear. When you are finished, move the <xref:System.Windows.Forms.Button> control near the center of the form.

4. Drag another <xref:System.Windows.Forms.Button> control from the **Toolbox** onto your form.

5. Move the second <xref:System.Windows.Forms.Button> control until it is nearly level with the first. Note the snapline that appears at the text baseline of both buttons, and note that the control you are moving snaps to a position that is exactly level with the other control.

6. Move the second <xref:System.Windows.Forms.Button> control until it is positioned directly above the first. Note the snaplines that appear along the left and right edges of both buttons, and note that the control you are moving snaps to a position that is exactly aligned with the other control.

7. Select one of the <xref:System.Windows.Forms.Button> controls and move it close to the other, until they are almost touching. Note the snapline that appears between them. This distance is the recommended distance between the borders of the controls. Also note that the control you are moving snaps to this position.

8. Drag two <xref:System.Windows.Forms.Panel> controls from the **Toolbox** onto your form.

9. Move one of the <xref:System.Windows.Forms.Panel> controls until it is nearly level with the first. Note the snaplines that appear along the top and bottom edges of both controls, and note that the control you are moving snaps to a position that is exactly level with the other control.

## Align to form and container margins

Snaplines help you to align your controls to form and container margins in a consistent manner.

1. Select one of the <xref:System.Windows.Forms.Button> controls and move it close to the right border of the form until a snapline appears. The snapline's distance from the right border is the sum of the control's <xref:System.Windows.Forms.Control.Margin%2A> property and the form's <xref:System.Windows.Forms.Control.Padding%2A> property values.

   > [!NOTE]
   > If the form's <xref:System.Windows.Forms.Control.Padding%2A> property is set to 0,0,0,0, the Windows Forms Designer gives the form a shadowed <xref:System.Windows.Forms.Control.Padding%2A> value of 9,9,9,9. To override this behavior, assign a value other than 0,0,0,0.

2. Change the value of the <xref:System.Windows.Forms.Button> control's <xref:System.Windows.Forms.Control.Margin%2A> property by expanding the <xref:System.Windows.Forms.Control.Margin%2A> entry in the **Properties** window and setting the <xref:System.Windows.Forms.Padding.All%2A> property to 0. For details, see [Walkthrough: Laying Out Windows Forms Controls with Padding, Margins, and the AutoSize Property](windows-forms-controls-padding-autosize.md).

3. Move the <xref:System.Windows.Forms.Button> control close to the right border of the form until a snapline appears. This distance is now given by the value of the form's <xref:System.Windows.Forms.Control.Padding%2A> property.

4. Drag a <xref:System.Windows.Forms.GroupBox> control from the **Toolbox** onto your form.

5. Change the value of the <xref:System.Windows.Forms.GroupBox> control's <xref:System.Windows.Forms.Control.Padding%2A> property by expanding the <xref:System.Windows.Forms.Control.Padding%2A> entry in the **Properties** window and setting the <xref:System.Windows.Forms.Padding.All%2A> property to 10.

6. Drag a <xref:System.Windows.Forms.Button> control from the **Toolbox** into the <xref:System.Windows.Forms.GroupBox> control.

7. Move the <xref:System.Windows.Forms.Button> control close to the right border of the <xref:System.Windows.Forms.GroupBox> control until a snapline appears. Move the <xref:System.Windows.Forms.Button> control within the <xref:System.Windows.Forms.GroupBox> control and note where the snaplines appear.

## Align to grouped controls

You can use snaplines to align grouped controls as well as controls within a <xref:System.Windows.Forms.GroupBox> control.

1. Select two of the controls on your form. Move the selection around and note the snaplines that appear between your selection and the other controls.

2. Drag a <xref:System.Windows.Forms.GroupBox> control from the **Toolbox** onto your form.

3. Drag a <xref:System.Windows.Forms.Button> control from the **Toolbox** into the <xref:System.Windows.Forms.GroupBox> control.

4. Select one of the <xref:System.Windows.Forms.Button> controls and move it around the <xref:System.Windows.Forms.GroupBox> control. Note the snaplines that appear at the edges of the <xref:System.Windows.Forms.GroupBox> control. Also note the snaplines that appear at the edges of the <xref:System.Windows.Forms.Button> control that is contained by the <xref:System.Windows.Forms.GroupBox> control. Controls that are children of a container control also support snaplines.

## Use snaplines to place a control by outlining its size

1. In the **Toolbox**, click the <xref:System.Windows.Forms.Button> control icon. Do not drag it onto the form.

2. Move the mouse pointer over the form's design surface. Note that the pointer changes to a crosshair with the <xref:System.Windows.Forms.Button> control icon attached. Also note the snaplines that appear to suggest aligned positions for the <xref:System.Windows.Forms.Button> control.

3. Click and hold the mouse button.

4. Drag the mouse pointer around the form. Note that an outline is drawn, indicating the position and the size of the control.

5. Drag the pointer until it aligns with another control on the form. Note that a snapline appears to indicate alignment.

6. Release the mouse button. The control is created at the position and size indicated by the outline.

## Use snaplines when dragging a control from the Toolbox

1. Drag a <xref:System.Windows.Forms.Button> control from the **Toolbox** onto your form, but do not release the mouse button.

2. Move the mouse pointer over the form's design surface. Note that the pointer changes to indicate the position at which the new <xref:System.Windows.Forms.Button> control will be created.

3. Drag the mouse pointer around the form. Note the snaplines that appear to suggest aligned positions for the <xref:System.Windows.Forms.Button> control. Find a position that is aligned with other controls.

4. Release the mouse button. The control is created at the position indicated by the snaplines.

## Resize a control using snaplines

1. Drag a <xref:System.Windows.Forms.Button> control from the **Toolbox** onto your form.

2. Resize the <xref:System.Windows.Forms.Button> control by grabbing one of the corner sizing handles and dragging. For details, see [How to: Resize Controls on Windows Forms](how-to-resize-controls-on-windows-forms.md).

3. Drag the sizing handle until one of the <xref:System.Windows.Forms.Button> control's borders is aligned with another control. Note that a snapline appears. Also note that the sizing handle snaps to the position indicated by the snapline.

4. Resize the <xref:System.Windows.Forms.Button> control in different directions and align the sizing handle to different controls. Note how the snaplines appear in various orientations to indicate alignment.

## Align a label to a control's text

1. Drag a <xref:System.Windows.Forms.TextBox> control from the **Toolbox** onto your form. When you drop the <xref:System.Windows.Forms.TextBox> control onto the form, click the smart-tag glyph and select the **Set text to textBox1** option. For details, see [Walkthrough: Performing Common Tasks Using Smart Tags on Windows Forms Controls](performing-common-tasks-using-smart-tags-on-wf-controls.md).

2. Drag a <xref:System.Windows.Forms.Label> control from the **Toolbox** onto your form.

3. Change the value of the <xref:System.Windows.Forms.Label> control's <xref:System.Windows.Forms.Control.AutoSize%2A> property to `true`. Note that the control's borders are adjusted to fit the display text.

4. Move the <xref:System.Windows.Forms.Label> control to the left of the <xref:System.Windows.Forms.TextBox> control, so it is aligned with the bottom edge of the <xref:System.Windows.Forms.TextBox> control. Note the snapline that appears along the bottom edges of the two controls.

5. Move the <xref:System.Windows.Forms.Label> control slightly upward, until the <xref:System.Windows.Forms.Label> text and the <xref:System.Windows.Forms.TextBox> text are aligned. Note the differently styled snapline that appears, indicating when the text fields of both controls are aligned.

## Use snaplines with keyboard navigation

1. Drag a <xref:System.Windows.Forms.Button> control from the **Toolbox** onto your form. Place it in the upper-left corner of the form.

2. Press **Ctrl**+**down arrow**. Note that the control moves down the form to the first available horizontal alignment position.

3. Press **Ctrl**+**down arrow** until the control reaches the bottom of the form. Note the positions it occupies as it moves down the form.

4. Press **Ctrl**+**right arrow**. Note that the control moves across the form to the first available vertical alignment position.

5. Press **Ctrl**+**right arrow** until the control reaches the side of the form. Note the positions it occupies as it moves across the form.

6. Move the control around the form with a combination of arrow keys. Note the positions the control occupies and the snaplines that accompany them.

7. Press **Shift**+**arrow keys** to resize the <xref:System.Windows.Forms.Button> control by increments of one pixel.

8. Press **Ctrl**+**Shift**+**arrow keys** to resize the <xref:System.Windows.Forms.Button> control in snapline increments.

## Selectively disable snaplines

1. Drag a <xref:System.Windows.Forms.TableLayoutPanel> control from the **Toolbox** onto your form.

2. Double-click the <xref:System.Windows.Forms.Button> control icon in the **Toolbox**. Note that a new button control appears in the <xref:System.Windows.Forms.TableLayoutPanel> control's first cell.

3. Double-click the <xref:System.Windows.Forms.Button> control icon in the **Toolbox** twice more. This leaves one empty cell in the <xref:System.Windows.Forms.TableLayoutPanel> control.

4. Drag a <xref:System.Windows.Forms.Button> control from the **Toolbox** into the empty cell of the <xref:System.Windows.Forms.TableLayoutPanel> control. Note that no snaplines appear.

5. Drag the <xref:System.Windows.Forms.Button> control out of the <xref:System.Windows.Forms.TableLayoutPanel> control and move it around the <xref:System.Windows.Forms.TableLayoutPanel> control. Note that snaplines appear again.

## Disable snaplines

Press the **Alt** key and while moving a control around the form.

No snaplines appear and the control does not snap to any potential alignment positions.

### To disable snaplines in the design environment

1. From the **Tools** menu, open the **Options** dialog box. Select **Windows Forms Designer**.

2. Select the **General** node. In the **Layout Mode** section, change the selection from **SnapLines** to **SnapToGrid**.

3. Select **OK** to apply the setting.

4. Select a control on your form and move it around the other controls. Note that snaplines do not appear.

## Next steps

Snaplines offer an intuitive means of aligning controls on your form. Suggestions for more exploration include:

- Try nesting a <xref:System.Windows.Forms.GroupBox> control within another <xref:System.Windows.Forms.GroupBox> control. Place a <xref:System.Windows.Forms.Button> control within the child <xref:System.Windows.Forms.GroupBox> control, and another within the parent <xref:System.Windows.Forms.GroupBox> control. Move the <xref:System.Windows.Forms.Button> controls around to see how the snaplines cross container boundaries.

- Create a column of <xref:System.Windows.Forms.TextBox> controls and a corresponding column of <xref:System.Windows.Forms.Label> controls. Set the value of the <xref:System.Windows.Forms.Label> controls' <xref:System.Windows.Forms.Control.AutoSize%2A> property to `true`. Use snaplines to move the <xref:System.Windows.Forms.Label> controls so their displayed text is aligned with the text in the <xref:System.Windows.Forms.TextBox> controls.

## See also

- <xref:System.Windows.Forms.Design.Behavior.SnapLine>
- [Walkthrough: Arranging Controls on Windows Forms Using a FlowLayoutPanel](walkthrough-arranging-controls-on-windows-forms-using-a-flowlayoutpanel.md)
- [Walkthrough: Arranging Controls on Windows Forms Using a TableLayoutPanel](walkthrough-arranging-controls-on-windows-forms-using-a-tablelayoutpanel.md)
- [Walkthrough: Laying Out Windows Forms Controls with Padding, Margins, and the AutoSize Property](windows-forms-controls-padding-autosize.md)
