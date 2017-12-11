---
title: "Walkthrough: Displaying Data in a DataRepeater Control (Visual Studio)"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "DataRepeater, walkthrough"
ms.assetid: 65dcdb95-6c3e-47cc-987d-190000f71653
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
---
# Walkthrough: Displaying Data in a DataRepeater Control (Visual Studio)
This walkthrough provides a basic start-to-finish scenario for displaying bound data in a <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control.  
  
## Prerequisite  
 This walkthrough requires the Northwind sample database.  
  
 If you do not have this database on your development computer, you can download it from the [Microsoft Download Center](http://go.microsoft.com/fwlink/?LinkID=98088). For instructions, see [Downloading Sample Databases](../../../framework/data/adonet/sql/linq/downloading-sample-databases.md).  
  
## Overview  
 The first part of this walkthrough consists of four main tasks:  
  
-   Creating a solution.  
  
-   Adding a <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control.  
  
-   Adding a data source.  
  
-   Adding data-bound controls.  
  
[!INCLUDE[note_settings_general](~/includes/note-settings-general-md.md)]  
  
## Creating a DataRepeater Solution  
 In the first step, you create a project and solution.  
  
#### To create a DataRepeater solution  
  
1.  On the Visual Studio **File** menu, click **New Project**.  
  
2.  In the **Project types** pane in the **New Project** dialog box, expand **Visual Basic**, and then click **Windows**.  
  
3.  In the **Templates** pane, click **Windows Forms Application**.  
  
4.  In the **Name** box, type `DataRepeaterApp`.  
  
5.  Click **OK**.  
  
     The Windows Forms Designer opens.  
  
6.  Select the form in the Windows Forms Designer. In the **Properties** window, set the **Size** property to `800, 700`.  
  
## Adding a DataRepeater Control  
 In this step, you add a <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control to the form.  
  
#### To add a DataRepeater control  
  
1.  On the **View** menu, click **Toolbox**.  
  
     The **Toolbox** opens.  
  
2.  Select the **Visual Basic PowerPacks** tab.  
  
3.  Drag a <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control onto **Form1**.  
  
4.  In the Properties window, set the **Location** property to `0, 25`.  
  
5.  Set the **Size** property to `460, 600`.  
  
## Adding a Data Source  
 In this step, you add a data source for the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control.  
  
#### To add a data source  
  
1.  On the **Data** menu, click **Show Data Sources**.  
  
2.  In the **Data Sources** window, click **Add New Data Source**.  
  
3.  Select **Database** on the **Choose a Data Source Type** page, and then click **Next**.  
  
4.  On the **Choose Your Data Connection** page, perform one of the following steps:  
  
    -   If a data connection to the Northwind sample database is available in the drop-down list, click it.  
  
         -or-  
  
    -   Click **New Connection** to configure a new data connection. For more information, see [Add new connections](/visualstudio/data-tools/add-new-connections).  
  
5.  If the database requires a password, select the option to include sensitive data, and then click **Next**.  
  
    > [!NOTE]
    >  If a dialog box appears, click **Yes** to save the file to your project.  
  
6.  Click **Next** on the **Save Connection String to the Application Configuration file** page.  
  
7.  Expand the **Tables** node on the **Choose Your Database Objects** page.  
  
8.  Select the check boxes next to the **Customers** and **Orders** tables, and then click **Finish**.  
  
     **NorthwindDataSet** is added to your project and the **Customers** and **Orders** tables appear in the **Data Sources** window.  
  
## Adding Data-Bound Controls  
 In this step, you add data-bound controls to the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater>.  
  
#### To add data-bound controls  
  
1.  In the **Data Sources** window, select the top-level node for the **Customers** table.  
  
2.  Change the drop type of the table to **Details** by clicking **Details** in the drop-down list on the table node.  
  
3.  Select the **Customers** table node and drag it onto the item template region (the upper region) of the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control.  
  
     A <xref:System.Windows.Forms.BindingNavigator> control is added to the form, and the **NorthwindDataSet**, **CustomersBindingSource**, **CustomersTableAdapter**, **TableAdapterManager**, and **CustomersBindingNavigator** components are added to the Component Tray.  
  
4.  Select all of the fields and their associated labels and position them near the left edge of the item template region.  
  
5.  Select the last five fields (**Region**, **Postal Code**, **Country**, **Phone**, and **Fax**) and their associated labels and move them up and to the right of the first six fields.  
  
6.  Select the item template (the upper region of the control).  
  
7.  In the Properties window, set the **Size** property to `427, 170`.  
  
 At this point, you have a working application that will display a repeating list of customers. You can press F5 to run the application, change the data, and add or delete customer records.  
  
 In the next optional steps, you will learn how to customize the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control.  
  
## Next Steps (Optional)  
 This part of the walkthrough consists of four optional tasks:  
  
-   Changing the appearance of the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control.  
  
-   Preventing users from adding or deleting records.  
  
-   Adding search capability to the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control.  
  
-   Adding a master and detail table to the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control.  
  
## Changing the Appearance of the DataRepeater Control  
 In this optional step, you change the `BackColor` of the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control at design time. You also add code to display rows in alternating colors and to change a label's `ForeColor` conditionally.  
  
#### To change the appearance of the control  
  
1.  In the Windows Forms Designer, select the main (lower) region of the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control.  
  
2.  In the Properties window, set the `BackColor` property to white.  
  
3.  Double-click the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> to open the Code Editor.  
  
4.  In the Code Editor, in the Event drop-down list, click **DrawItem**.  
  
5.  In the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater.DrawItem> event handler, add the following code to alternate the `BackColor`:  
  
     [!code-csharp[VbPowerPacksDataRepeaterWalkthrough#1](../../../visual-basic/developing-apps/windows-forms/codesnippet/CSharp/walkthrough-displaying-data-in-a-datarepeater-control-visual-studio_1.cs)]
     [!code-vb[VbPowerPacksDataRepeaterWalkthrough#1](../../../visual-basic/developing-apps/windows-forms/codesnippet/VisualBasic/walkthrough-displaying-data-in-a-datarepeater-control-visual-studio_1.vb)]  
  
6.  In the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater.DrawItem> event handler, add the following code to change the `ForeColor` of a label depending on a condition:  
  
     [!code-csharp[VbPowerPacksDataRepeaterWalkthrough#2](../../../visual-basic/developing-apps/windows-forms/codesnippet/CSharp/walkthrough-displaying-data-in-a-datarepeater-control-visual-studio_2.cs)]
     [!code-vb[VbPowerPacksDataRepeaterWalkthrough#2](../../../visual-basic/developing-apps/windows-forms/codesnippet/VisualBasic/walkthrough-displaying-data-in-a-datarepeater-control-visual-studio_2.vb)]  
  
7.  Press F5 to run the application and see the customizations.  
  
## Preventing Users from Adding or Deleting Records  
 In this optional step, you add code that prevents users from adding or deleting records in the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control.  
  
#### To prevent users from adding and deleting records  
  
1.  In the Windows Forms Designer, double-click the form to open the Code Editor.  
  
2.  Add the following code to the `Form_Load` event:  
  
     [!code-csharp[VbPowerPacksDataRepeaterWalkthrough#3](../../../visual-basic/developing-apps/windows-forms/codesnippet/CSharp/walkthrough-displaying-data-in-a-datarepeater-control-visual-studio_3.cs)]
     [!code-vb[VbPowerPacksDataRepeaterWalkthrough#3](../../../visual-basic/developing-apps/windows-forms/codesnippet/VisualBasic/walkthrough-displaying-data-in-a-datarepeater-control-visual-studio_3.vb)]  
  
3.  In the Class Name drop-down list, click **BindingNavigatorDeleteItem**. In the Method Name drop-down list, click **EnabledChanged**.  
  
4.  Add the following code to the `BindingNavigatorDeleteItem_EnabledChanged` event handler:  
  
     [!code-csharp[VbPowerPacksDataRepeaterWalkthrough#4](../../../visual-basic/developing-apps/windows-forms/codesnippet/CSharp/walkthrough-displaying-data-in-a-datarepeater-control-visual-studio_4.cs)]
     [!code-vb[VbPowerPacksDataRepeaterWalkthrough#4](../../../visual-basic/developing-apps/windows-forms/codesnippet/VisualBasic/walkthrough-displaying-data-in-a-datarepeater-control-visual-studio_4.vb)]  
  
    > [!NOTE]
    >  This step is necessary because the <xref:System.Windows.Forms.BindingSource> will enable the **DeleteItem** button every time that the current record changes.  
  
5.  Press F5 to run the application. Notice that the **DeleteItem** button is disabled and that you cannot delete items by pressing the DELETE key.  
  
## Adding Search Capability to the DataRepeater Control  
 In this optional step, you implement the capability to search for a value in the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control. If the search string is found, the control selects the item that contains the value and scrolls the item into view.  
  
#### To add search capability  
  
1.  Drag a <xref:System.Windows.Forms.TextBox> control from the **Toolbox** onto the form that contains the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control.  
  
     Position it under the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control.  
  
2.  In the Properties window, change the **Name** property to **SearchTextBox**.  
  
3.  Drag a <xref:System.Windows.Forms.Button> control from the **Toolbox** onto the form that contains the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control. Position it under the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control.  
  
4.  In the Properties window, change the **Name** property to **SearchButton**. Change the **Text** property to **Search**.  
  
5.  Double-click the <xref:System.Windows.Forms.Button> control to open the Code Editor, and add the following code to the `SearchButton_Click` event handler.  
  
     [!code-csharp[VbPowerPacksDataRepeaterWalkthrough#5](../../../visual-basic/developing-apps/windows-forms/codesnippet/CSharp/walkthrough-displaying-data-in-a-datarepeater-control-visual-studio_5.cs)]
     [!code-vb[VbPowerPacksDataRepeaterWalkthrough#5](../../../visual-basic/developing-apps/windows-forms/codesnippet/VisualBasic/walkthrough-displaying-data-in-a-datarepeater-control-visual-studio_5.vb)]  
  
6.  Press F5 to run the application. Type a customer ID in **SearchTextBox** and click the **Search** button.  
  
## Adding a Master and Detail Table to the DataRepeater  
 In this optional step, you add a second <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control to display related orders for each customer.  
  
#### To add a master and detail table  
  
1.  Drag a second <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control from the **Visual Basic PowerPacks** tab in the **Toolbox** onto the form.  
  
2.  In the Properties window, set the **Location** property to `465, 25`.  
  
3.  Set the **Size** property to `315, 600`.  
  
4.  In the **Data Sources** window, expand the **Customers** table node and select the detail node for the **Orders** table.  
  
5.  Change the drop type of this **Orders** table to Details by clicking **Details** in the drop-down list on the table node.  
  
6.  Drag this **Orders** table node onto the item template region (the upper region) of the second <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control.  
  
     An **OrdersBindingSource** component and an **OrdersTableAdapter** component are added to the Component Tray.  
  
7.  Press F5 to run the application. When you select each customer in the first <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control, the orders for that customer are displayed in the second <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control.  
  
## See Also  
 [Introduction to the DataRepeater Control](../../../visual-basic/developing-apps/windows-forms/introduction-to-the-datarepeater-control-visual-studio.md)  
 [How to: Display Bound Data in a DataRepeater Control](../../../visual-basic/developing-apps/windows-forms/how-to-display-bound-data-in-a-datarepeater-control-visual-studio.md)  
 [How to: Display Unbound Controls in a DataRepeater Control](../../../visual-basic/developing-apps/windows-forms/how-to-display-unbound-controls-in-a-datarepeater-control-visual-studio.md)  
 [How to: Change the Layout of a DataRepeater Control](../../../visual-basic/developing-apps/windows-forms/how-to-change-the-layout-of-a-datarepeater-control-visual-studio.md)  
 [How to: Display Item Headers in a DataRepeater Control](../../../visual-basic/developing-apps/windows-forms/how-to-display-item-headers-in-a-datarepeater-control-visual-studio.md)  
 [How to: Search Data in a DataRepeater Control](../../../visual-basic/developing-apps/windows-forms/how-to-search-data-in-a-datarepeater-control-visual-studio.md)  
 [How to: Create a Master/Detail Form by Using Two DataRepeater Controls (Visual Studio)](../../../visual-basic/developing-apps/windows-forms/how-to-create-a-master-detail-form-by-using-two-datarepeater-controls.md)  
 [How to: Change the Appearance of a DataRepeater Control](../../../visual-basic/developing-apps/windows-forms/how-to-change-the-appearance-of-a-datarepeater-control-visual-studio.md)  
 [How to: Disable Adding and Deleting DataRepeater Items](../../../visual-basic/developing-apps/windows-forms/how-to-disable-adding-and-deleting-datarepeater-items-visual-studio.md)  
 [Troubleshooting the DataRepeater Control](../../../visual-basic/developing-apps/windows-forms/troubleshooting-the-datarepeater-control-visual-studio.md)
