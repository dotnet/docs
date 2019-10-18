---
title: "Walkthrough: Performing Common Tasks Using Smart Tags on Windows Forms Controls"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "DesignerAction object model"
  - "smart tags"
  - "designer actions"
ms.assetid: cac337e6-00f6-4584-80f4-75728f5ea113
author: gewarren
ms.author: gewarren
manager: jillfra
---
# Walkthrough: Perform Common Tasks Using Smart Tags

As you construct forms and controls for your Windows Forms application, there are many tasks you will perform repeatedly. These are some of the commonly performed tasks you will encounter:

- Adding or removing a tab on a <xref:System.Windows.Forms.TabControl>.

- Docking a control to its parent.

- Changing the orientation of a <xref:System.Windows.Forms.SplitContainer> control.

To speed development, many controls offer smart tags, which are context-sensitive menus that allow you to perform common tasks like these in a single gesture at design time. These tasks are called *smart-tag verbs*.

Smart tags remain attached to a control instance for its lifetime in the designer and are always available.

## Create the project

The first step is to create the project and set up the form.

1. In Visual Studio, create a Windows-based application project called **SmartTagsExample**.

2. Select the form in the **Windows Forms Designer**.

## Use smart tags

Smart tags are always available at design time on controls that offer them.

1. Drag a <xref:System.Windows.Forms.TabControl> from the **Toolbox** onto your form. Note the smart-tag glyph (![Smart Tag Glyph](./media/vs-winformsmttagglyph.gif)) that appears on the side of the <xref:System.Windows.Forms.TabControl>.

2. Click the smart-tag glyph. In the shortcut menu that appears next to the glyph, select the **Add Tab** item. Observe that a new tab page is added to the <xref:System.Windows.Forms.TabControl>.

3. Drag a <xref:System.Windows.Forms.TableLayoutPanel> control from the **Toolbox** onto your form.

4. Click the smart-tag glyph. In the shortcut menu that appears next to the glyph, select the **Add Column** item. Observe that a new column is added to the <xref:System.Windows.Forms.TableLayoutPanel> control.

5. Drag a <xref:System.Windows.Forms.SplitContainer> control from the **Toolbox** onto your form.

6. Click the smart-tag glyph. In the shortcut menu that appears next to the glyph, select the **Horizontal splitter orientation** item. Observe that the <xref:System.Windows.Forms.SplitContainer> control's splitter bar is now oriented horizontally.

## See also

- <xref:System.Windows.Forms.TextBox>
- <xref:System.Windows.Forms.TabControl>
- <xref:System.Windows.Forms.SplitContainer>
- <xref:System.ComponentModel.Design.DesignerActionList>
