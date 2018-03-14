---
title: "AutoSize Property Overview"
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
  - "sizing [Windows Forms], automatic"
  - "layout [Windows Forms], AutoSize"
  - "automatic sizing"
  - "AutoSizeMode property"
ms.assetid: 62fd82a2-9565-4f65-925b-9d1e66dc4e7d
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# AutoSize Property Overview
The <xref:System.Windows.Forms.Control.AutoSize%2A> property enables a control to change its size, if necessary, to attain the value specified by the <xref:System.Windows.Forms.Control.PreferredSize%2A> property. You adjust the sizing behavior for specific controls by setting the `AutoSizeMode` property.  
  
## AutoSize Behavior  
 Only some controls support the <xref:System.Windows.Forms.Control.AutoSize%2A> property. In addition, some controls that support the <xref:System.Windows.Forms.Control.AutoSize%2A> property also support the `AutoSizeMode` property.  
  
 The <xref:System.Windows.Forms.Control.AutoSize%2A> property produces somewhat different behavior, depending on the specific control type and the value of the `AutoSizeMode` property, if the property exists. The following table describes the behaviors that are always true and provides a brief description of each:  
  
|Always true behavior|Description|  
|--------------------------|-----------------|  
|Automatic sizing is a run-time feature.|This means it never grows or shrinks a control and then has no further effect.|  
|If a control changes size, the value of its <xref:System.Windows.Forms.Control.Location%2A> property always remains constant.|When a control's contents cause it to grow, the control grows toward the right and downward. Controls do not grow to the left.|  
|The <xref:System.Windows.Forms.Control.Dock%2A> and <xref:System.Windows.Forms.Control.Anchor%2A> properties are honored when <xref:System.Windows.Forms.Control.AutoSize%2A> is `true`.|The value of the control's <xref:System.Windows.Forms.Control.Location%2A> property is adjusted to the correct value.<br /><br /> **Note** The <xref:System.Windows.Forms.Label> control is the exception to this rule. When you set the value of a docked <xref:System.Windows.Forms.Label> control's <xref:System.Windows.Forms.Control.AutoSize%2A> property to `true`, the <xref:System.Windows.Forms.Label> control will not stretch.|  
|A control's <xref:System.Windows.Forms.Control.MaximumSize%2A> and <xref:System.Windows.Forms.Control.MinimumSize%2A> properties are always honored, regardless of the value of its <xref:System.Windows.Forms.Control.AutoSize%2A> property.|The <xref:System.Windows.Forms.Control.MaximumSize%2A> and <xref:System.Windows.Forms.Control.MinimumSize%2A> properties are not affected by the <xref:System.Windows.Forms.Control.AutoSize%2A> property.|  
|There is no minimum size set by default.|This means that if a control is set to shrink under <xref:System.Windows.Forms.Control.AutoSize%2A> and it has no contents, the value of its <xref:System.Windows.Forms.Control.Size%2A> property is 0,0. In this case, your control will shrink to a point, and it will not be readily visible.|  
|If a control does not implement the <xref:System.Windows.Forms.Control.GetPreferredSize%2A> method, the <xref:System.Windows.Forms.Control.GetPreferredSize%2A> method returns last value assigned to the <xref:System.Windows.Forms.Control.Size%2A> property.|This means that setting <xref:System.Windows.Forms.Control.AutoSize%2A> to `true` will have no effect.|  
|A control in a <xref:System.Windows.Forms.TableLayoutPanel> cell always shrinks to fit in the cell until its <xref:System.Windows.Forms.Control.MinimumSize%2A> is reached.|This size is enforced as a maximum size. This is not the case when the cell is part of an <xref:System.Windows.Forms.SizeType.AutoSize> row or column.|  
  
## AutoSizeMode Property  
 The `AutoSizeMode` property provides more fine-grained control over the default <xref:System.Windows.Forms.Control.AutoSize%2A> behavior. The `AutoSizeMode` property specifies how a control sizes itself to its content. The content, for example, could be the text for a <xref:System.Windows.Forms.Button> control or the child controls for a container.  
  
 The following table shows the <xref:System.Windows.Forms.AutoSizeMode> settings and a description of the behavior each setting elicits.  
  
|AutoSizeMode setting|Behavior|  
|--------------------------|--------------|  
|GrowAndShrink|The control grows or shrinks to encompass its contents.<br /><br /> The <xref:System.Windows.Forms.Control.MinimumSize%2A> and <xref:System.Windows.Forms.Control.MaximumSize%2A> values are honored, but the current value of the <xref:System.Windows.Forms.Control.Size%2A> property is ignored.<br /><br /> This is the same behavior as controls with the <xref:System.Windows.Forms.Control.AutoSize%2A> property and no `AutoSizeMode` property.|  
|GrowOnly|The control grows as much as necessary to encompass its contents, but it will not shrink smaller than the value specified by its <xref:System.Windows.Forms.Control.Size%2A> property.<br /><br /> This is the default value for `AutoSizeMode`.|  
  
## Controls That Support the AutoSize Property  
 The following table lists the controls that support the <xref:System.Windows.Forms.Control.AutoSize%2A> and `AutoSizeMode` properties.  
  
|AutoSize support|Control type|  
|----------------------|------------------|  
|-   <xref:System.Windows.Forms.Control.AutoSize%2A> property supported.<br />-   No `AutoSizeMode` property.|<xref:System.Windows.Forms.CheckBox><br /><br /> <xref:System.Windows.Forms.DomainUpDown><br /><br /> <xref:System.Windows.Forms.Label><br /><br /> <xref:System.Windows.Forms.LinkLabel><br /><br /> <xref:System.Windows.Forms.MaskedTextBox> (<xref:System.Windows.Forms.TextBox> base)<br /><br /> <xref:System.Windows.Forms.NumericUpDown><br /><br /> <xref:System.Windows.Forms.RadioButton><br /><br /> <xref:System.Windows.Forms.TextBox><br /><br /> <xref:System.Windows.Forms.TrackBar>|  
|-   <xref:System.Windows.Forms.Control.AutoSize%2A> property supported.<br />-   `AutoSizeMode` property supported.|<xref:System.Windows.Forms.Button><br /><br /> <xref:System.Windows.Forms.CheckedListBox><br /><br /> <xref:System.Windows.Forms.FlowLayoutPanel><br /><br /> <xref:System.Windows.Forms.Form><br /><br /> <xref:System.Windows.Forms.GroupBox><br /><br /> <xref:System.Windows.Forms.Panel><br /><br /> <xref:System.Windows.Forms.TableLayoutPanel>|  
|-   No <xref:System.Windows.Forms.Control.AutoSize%2A> property.|<xref:System.Windows.Forms.CheckedListBox><br /><br /> <xref:System.Windows.Forms.ComboBox><br /><br /> <xref:System.Windows.Forms.DataGridView><br /><br /> <xref:System.Windows.Forms.DateTimePicker><br /><br /> <xref:System.Windows.Forms.ListBox><br /><br /> <xref:System.Windows.Forms.ListView><br /><br /> <xref:System.Windows.Forms.MaskedTextBox><br /><br /> <xref:System.Windows.Forms.MonthCalendar><br /><br /> <xref:System.Windows.Forms.ProgressBar><br /><br /> <xref:System.Windows.Forms.PropertyGrid><br /><br /> <xref:System.Windows.Forms.RichTextBox><br /><br /> <xref:System.Windows.Forms.SplitContainer><br /><br /> <xref:System.Windows.Forms.TabControl><br /><br /> <xref:System.Windows.Forms.TabPage><br /><br /> <xref:System.Windows.Forms.TreeView><br /><br /> <xref:System.Windows.Forms.WebBrowser><br /><br /> <xref:System.Windows.Forms.ScrollBar>|  
  
## AutoSize in the Design Environment  
 The following table describes the sizing behavior of a control at design time, based on the value of its <xref:System.Windows.Forms.Control.AutoSize%2A> and `AutoSizeMode` properties.  
  
 Override the <xref:System.Windows.Forms.Design.ControlDesigner.SelectionRules%2A> property to determine whether a given control is in a user-resizable state. In the following table, "cannot" means <xref:System.Windows.Forms.Design.SelectionRules.Moveable> only, "can" means <xref:System.Windows.Forms.Design.SelectionRules.AllSizeable> and <xref:System.Windows.Forms.Design.SelectionRules.Moveable>.  
  
|AutoSize settings|Design-time sizing gesture|  
|-----------------------|---------------------------------|  
|-   <xref:System.Windows.Forms.Control.AutoSize%2A> = `true`<br />-   No `AutoSizeMode` property.|The user cannot resize the control at design time, except for the following controls:<br /><br /> -   <xref:System.Windows.Forms.TextBox><br />-   <xref:System.Windows.Forms.MaskedTextBox><br />-   <xref:System.Windows.Forms.RichTextBox><br />-   <xref:System.Windows.Forms.TrackBar>|  
|-   <xref:System.Windows.Forms.Control.AutoSize%2A> = `true`<br />-   `AutoSizeMode` = <xref:System.Windows.Forms.AutoSizeMode.GrowAndShrink>|The user cannot resize the control at design time.|  
|-   <xref:System.Windows.Forms.Control.AutoSize%2A> = `true`<br />-   `AutoSizeMode` = <xref:System.Windows.Forms.AutoSizeMode.GrowOnly>|The user can resize the control at design time. When the <xref:System.Windows.Forms.Control.Size%2A> property is set, the user can only increase the size of the control.|  
|-   <xref:System.Windows.Forms.Control.AutoSize%2A> = `false`, or <xref:System.Windows.Forms.Control.AutoSize%2A> property is hidden.|User can resize the control at design time.|  
  
> [!NOTE]
>  To maximize productivity, the Windows Forms Designer shadows the <xref:System.Windows.Forms.Control.AutoSize%2A> property for the <xref:System.Windows.Forms.Form> class. At design time, the form behaves as though the <xref:System.Windows.Forms.Control.AutoSize%2A> property is set to `false`, regardless of its actual setting. At runtime, no special accommodation is made, and the <xref:System.Windows.Forms.Control.AutoSize%2A> property is applied as specified by the property setting.  
  
## See Also  
 <xref:System.Windows.Forms.Control.AutoSize%2A>  
 <xref:System.Windows.Forms.Control.PreferredSize%2A>  
 <xref:System.Windows.Forms.Control.GetPreferredSize%2A>
