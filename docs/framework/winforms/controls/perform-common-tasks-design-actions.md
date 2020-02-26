---
title: Perform common tasks using designer actions on controls
ms.date: "02/13/2019"
helpviewer_keywords:
  - "designer actions"
ms.assetid: cac337e6-00f6-4584-80f4-75728f5ea113
author: jillre
ms.author: jillfra
manager: jillfra
---
# Walkthrough: Perform common tasks using designer actions

As you construct forms and controls for your Windows Forms application, there are many tasks you'll perform repeatedly. The following list shows some of the commonly performed tasks you'll come across:

- Adding or removing a tab on a <xref:System.Windows.Forms.TabControl>.
- Docking a control to its parent.
- Changing the orientation of a <xref:System.Windows.Forms.SplitContainer> control.

To speed development, many controls offer designer actions, which are context-sensitive menus that allow you to perform common tasks like these in a single gesture at design time. These tasks are called *designer actions verbs*.

Designer actions remain attached to a control instance for its lifetime in the designer and are always available.

## Create the project

The first step is to create the project and set up the form.

1. In Visual Studio, create a Windows-based application project called **DesignerActionsExample**.

2. Select the form in the **Windows Forms Designer**.

## Use designer actions

Designer actions are always available at design time on controls that offer them.

1. Drag a <xref:System.Windows.Forms.TabControl> from the **Toolbox** onto your form. Note the designer actions glyph (![Small black arrow](./media/designer-actions-glyph.gif)) that appears on the side of the <xref:System.Windows.Forms.TabControl>.

2. Click the designer actions glyph. In the shortcut menu that appears next to the glyph, select the **Add Tab** item. Observe that a new tab page is added to the <xref:System.Windows.Forms.TabControl>.

3. Drag a <xref:System.Windows.Forms.TableLayoutPanel> control from the **Toolbox** onto your form.

4. Click the designer actions glyph. In the shortcut menu that appears next to the glyph, select the **Add Column** item. Observe that a new column is added to the <xref:System.Windows.Forms.TableLayoutPanel> control.

5. Drag a <xref:System.Windows.Forms.SplitContainer> control from the **Toolbox** onto your form.

6. Click the designer actions glyph. In the shortcut menu that appears next to the glyph, select the **Horizontal Splitter Orientation** item. Observe that the <xref:System.Windows.Forms.SplitContainer> control's splitter bar is now oriented horizontally.

## See also

- <xref:System.Windows.Forms.TextBox>
- <xref:System.Windows.Forms.TabControl>
- <xref:System.Windows.Forms.SplitContainer>
- <xref:System.ComponentModel.Design.DesignerActionList>
