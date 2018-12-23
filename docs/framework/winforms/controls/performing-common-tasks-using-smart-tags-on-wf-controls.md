---
title: "Walkthrough: Performing Common Tasks Using Smart Tags on Windows Forms Controls"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "DesignerAction object model"
  - "smart tags"
  - "designer actions"
ms.assetid: cac337e6-00f6-4584-80f4-75728f5ea113
---
# Walkthrough: Performing Common Tasks Using Smart Tags on Windows Forms Controls
As you construct forms and controls for your Windows Forms application, there are many tasks you will perform repeatedly. These are some of the commonly performed tasks you will encounter:  
  
-   Adding or removing a tab on a <xref:System.Windows.Forms.TabControl>.  
  
-   Docking a control to its parent.  
  
-   Changing the orientation of a <xref:System.Windows.Forms.SplitContainer> control.  
  
 To speed development, many controls offer smart tags, which are context-sensitive menus that allow you to perform common tasks like these in a single gesture at design time. These tasks are called *smart-tag verbs*.  
  
 Smart tags remain attached to a control instance for its lifetime in the designer and are always available.  
  
 Tasks illustrated in this walkthrough include:  
  
-   Creating a Windows Forms project  
  
-   Using smart tags  
  
-   Enabling and Disabling Smart Tags  
  
 When you are finished, you will have an understanding of the role played by these important layout features.  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Personalize the Visual Studio IDE](/visualstudio/ide/personalizing-the-visual-studio-ide).  
  
## Creating the Project  
 The first step is to create the project and set up the form.  
  
#### To create the project  
  
1.  Create a Windows-based application project called "SmartTagsExample" (**File** > **New** > **Project** > **Visual C#** or **Visual Basic** > **Classic Desktop** > **Windows Forms Application**).  
  
2.  Select the form in the **Windows Forms Designer**.  
  
## Using Smart Tags  
 Smart tags are always available at design time on controls that offer them.  
  
#### To use smart tags  
  
1.  Drag a <xref:System.Windows.Forms.TabControl> from the **Toolbox** onto your form. Note the smart-tag glyph (![Smart Tag Glyph](../../../../docs/framework/winforms/controls/media/vs-winformsmttagglyph.gif "VS_WinFormSmtTagGlyph")) that appears on the side of the <xref:System.Windows.Forms.TabControl>.  
  
2.  Click the smart-tag glyph. In the shortcut menu that appears next to the glyph, select the **Add Tab** item. Observe that a new tab page is added to the <xref:System.Windows.Forms.TabControl>.  
  
3.  Drag a <xref:System.Windows.Forms.TableLayoutPanel> control from the **Toolbox** onto your form.  
  
4.  Click the smart-tag glyph. In the shortcut menu that appears next to the glyph, select the **Add Column** item. Observe that a new column is added to the <xref:System.Windows.Forms.TableLayoutPanel> control.  
  
5.  Drag a <xref:System.Windows.Forms.SplitContainer> control from the **Toolbox** onto your form.  
  
6.  Click the smart-tag glyph. In the shortcut menu that appears next to the glyph, select the **Horizontal splitter orientation** item. Observe that the <xref:System.Windows.Forms.SplitContainer> control's splitter bar is now oriented horizontally.  
  
## See Also  
 <xref:System.Windows.Forms.TextBox>  
 <xref:System.Windows.Forms.TabControl>  
 <xref:System.Windows.Forms.SplitContainer>  
 <xref:System.ComponentModel.Design.DesignerActionList>  
 [Walkthrough: Adding Smart Tags to a Windows Forms Component](https://msdn.microsoft.com/library/a6814169-fa7d-4527-808c-637ca5c95f63)
