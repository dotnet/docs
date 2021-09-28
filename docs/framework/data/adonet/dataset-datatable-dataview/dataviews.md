---
description: "Learn more about: DataViews"
title: "DataViews"
ms.date: "03/30/2017"
ms.assetid: 0fe5dfa2-c1cd-435f-90b6-b4dd2e3ef34b
---
# DataViews

A <xref:System.Data.DataView> enables you to create different views of the data stored in a <xref:System.Data.DataTable>, a capability that is often used in data-binding applications. Using a **DataView**, you can expose the data in a table with different sort orders, and you can filter the data by row state or based on a filter expression.

 A **DataView** provides a dynamic view of data in the underlying **DataTable**: the content, ordering, and membership reflect changes as they occur. This behavior differs from the **Select** method of the **DataTable**, which returns a <xref:System.Data.DataRow> array from a table based on a particular filter and/or sort order: this content reflects changes to the underlying table, but its membership and ordering remain static. The dynamic capabilities of the **DataView** make it ideal for data-binding applications.

 A **DataView** provides you with a dynamic view of a single set of data, much like a database view, to which you can apply different sorting and filtering criteria. Unlike a database view, however, a **DataView** cannot be treated as a table and cannot provide a view of joined tables. You also cannot exclude columns that exist in the source table or append columns that do not exist in the source table, such as computational columns.

 You can use a <xref:System.Data.DataView.DataViewManager%2A> to manage view settings for all the tables in a **DataSet**. The **DataViewManager** provides you with a convenient way to manage default view settings for each table. When binding a control to more than one table of a **DataSet**, binding to a **DataViewManager** is the ideal choice.

## In This Section

 [Creating a DataView](creating-a-dataview.md)
 Describes how to create a **DataView** for a **DataTable**.

 [Sorting and Filtering Data](sorting-and-filtering-data.md)
 Describes how to set the properties of a **DataView** to return subsets of data rows meeting specific filter criteria, or to return data in a particular sort order.

 [DataRows and DataRowViews](datarows-and-datarowviews.md)
 Describes how to access the data exposed by the **DataView**.

 [Finding Rows](finding-rows.md)
 Describes how to find a particular row in a **DataView**.

 [ChildViews and Relations](childviews-and-relations.md)
 Describes how to create views of data from a parent-child relationship using a **DataView**.

 [Modifying DataViews](modifying-dataviews.md)
 Describes how to modify the data in the underlying **DataTable** via the **DataView**, including enabling or disabling updates.

 [Handling DataView Events](handling-dataview-events.md)
 Describes how to use the **ListChanged** event to receive notification when the contents or order of a **DataView** is being updated.

 [Managing DataViews](managing-dataviews.md)
 Describes how to use a **DataViewManager** to manage **DataView** settings for each table in a **DataSet**.

## Related Sections

 [ASP.NET Web Applications](/previous-versions/655cec97(v=vs.100))
 Provides overviews and detailed, step-by-step procedures for creating ASP.NET applications, Web Forms, and Web Services.

 [Windows Applications](/previous-versions/ms184421(v=vs.100))
 Provides detailed information about working with Windows Forms and console applications.

 [DataSets, DataTables, and DataViews](index.md)
 Describes the **DataSet** object and how you can use it to manage application data.

 [DataTables](datatables.md)
 Describes the **DataTable** object and how you can use it to manage application data by itself or as part of a **DataSet**.

 [ADO.NET](../index.md)
 Describes the ADO.NET architecture and components, and how to use ADO.NET to access existing data sources and manage application data.

## See also

- [ADO.NET Overview](../ado-net-overview.md)
