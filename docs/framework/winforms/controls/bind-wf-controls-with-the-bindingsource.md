---
title: "How to: Bind Windows Forms Controls with the BindingSource Component Using the Designer"
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
  - "controls [Windows Forms], binding"
  - "BindingSource component [Windows Forms], binding controls"
  - "data binding [Windows Forms], BindingSource component"
ms.assetid: 391ae170-de5c-40f8-8233-91cb2ee4683a
caps.latest.revision: 18
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Bind Windows Forms Controls with the BindingSource Component Using the Designer
After you have added controls to your form and determined the user interface for your application, you can bind the controls to a data source, so that, at run time, users can alter and save data related to the application.  
  
 Binding a control or series of controls in Windows Forms is most easily accomplished using the <xref:System.Windows.Forms.BindingSource> control as a bridge between the controls on the form and the data source.  
  
 One or more controls on a form can be bound to data; in the following procedure, a <xref:System.Windows.Forms.TextBox> control is bound to a data source.  
  
 To complete the procedure, it is assumed that you will bind to a data source derived from a database. For more information on creating data sources from other stores of data, see [Add new data sources](/visualstudio/data-tools/add-new-data-sources).  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
### To bind a control at design time  
  
1.  Drag a <xref:System.Windows.Forms.TextBox> control on to the form.  
  
2.  In the **Properties** window:  
  
    1.  Expand the **(DataBindings)** node.  
  
    2.  Click the arrow next to the <xref:System.Windows.Forms.TextBox.Text%2A> property.  
  
         The **DataSource** UI type editor opens.  
  
         If a data source has previously been configured for the project or form, it will appear.  
  
3.  Click **Add Project Data Source** to connect to data and create a data source.  
  
4.  On the **Data Source Configuration Wizard** welcome page, click **Next**.  
  
5.  On the **Choose a Data Source Type** page, select **Database**.  
  
6.  On the **Choose Your Data Connection** page, select a data connection from the list of available connections. If your desired data connection is not available select **New Connection** to create a new data connection.  
  
7.  Select **Yes, save the connection** to save the connection string in the application configuration file.  
  
8.  Select the database objects to bring into your application. In this case, select a field in a table that you would like the <xref:System.Windows.Forms.TextBox> to display.  
  
9. Replace the default dataset name if you want.  
  
10. Click **Finish**.  
  
11. In the **Properties** window, click the arrow next to the <xref:System.Windows.Forms.TextBox.Text%2A> property again. In the **DataSource** UI type editor, select the name of the field to bind the <xref:System.Windows.Forms.TextBox> to.  
  
     The **DataSource** UI type editor closes and the data set, <xref:System.Windows.Forms.BindingSource> and table adapter specific to that data connection are added to your form.  
  
## See Also  
 <xref:System.Windows.Forms.BindingSource>  
 <xref:System.Windows.Forms.BindingNavigator>  
 [Add new data sources](/visualstudio/data-tools/add-new-data-sources)  
 [Data Sources Window](http://msdn.microsoft.com/library/0d20f699-cc95-45b3-8ecb-c7edf1f67992)
