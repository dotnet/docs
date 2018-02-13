---
title: "Implementing Virtual Mode with Just-In-Time Data Loading in the Windows Forms DataGridView Control"
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
helpviewer_keywords: 
  - "examples [Windows Forms], just-in-time data loading"
  - "data [Windows Forms], managing large data sets"
  - "DataGridView control [Windows Forms], virtual mode"
  - "just-in-time data loading"
  - "DataGridView control [Windows Forms], large data sets"
  - "virtual mode [Windows Forms], just-in-time data loading"
ms.assetid: c2a052b9-423c-4ff7-91dc-d8c7c79345f6
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Implementing Virtual Mode with Just-In-Time Data Loading in the Windows Forms DataGridView Control
One reason to implement virtual mode in the <xref:System.Windows.Forms.DataGridView> control is to retrieve data only as it is needed. This is called *just-in-time data loading*.  
  
 If you are working with a very large table in a remote database, for example, you might want to avoid startup delays by retrieving only the data that is necessary for display and retrieving additional data only when the user scrolls new rows into view. If the client computers running your application have a limited amount of memory available for storing data, you might also want to discard unused data when retrieving new values from the database.  
  
 The following sections describe how to use a <xref:System.Windows.Forms.DataGridView> control with a just-in-time cache.  
  
 To copy the code in this topic as a single listing, see [How to: Implement Virtual Mode with Just-In-Time Data Loading in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/virtual-mode-with-just-in-time-data-loading-in-the-datagrid.md).  
  
## The Form  
 The following code example defines a form containing a read-only <xref:System.Windows.Forms.DataGridView> control that interacts with a `Cache` object through a <xref:System.Windows.Forms.DataGridView.CellValueNeeded> event handler. The `Cache` object manages the locally stored values and uses a `DataRetriever` object to retrieve values from the Orders table of the sample Northwind database. The `DataRetriever` object, which implements the `IDataPageRetriever` interface required by the `Cache` class, is also used to initialize the <xref:System.Windows.Forms.DataGridView> control rows and columns.  
  
 The `IDataPageRetriever`, `DataRetriever`, and `Cache` types are described later in this topic.  
  
> [!NOTE]
>  Storing sensitive information, such as a password, within the connection string can affect the security of your application. Using Windows Authentication (also known as integrated security) is a more secure way to control access to a database. For more information, see [Protecting Connection Information](../../../../docs/framework/data/adonet/protecting-connection-information.md).  
  
 [!code-csharp[System.Windows.Forms.DataGridView.Virtual_lazyloading#100](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridView.Virtual_lazyloading/CS/lazyloading.cs#100)]
 [!code-vb[System.Windows.Forms.DataGridView.Virtual_lazyloading#100](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridView.Virtual_lazyloading/VB/lazyloading.vb#100)]  
  
## The IDataPageRetriever Interface  
 The following code example defines the `IDataPageRetriever` interface, which is implemented by the `DataRetriever` class. The only method declared in this interface is the `SupplyPageOfData` method, which requires an initial row index and a count of the number of rows in a single page of data. These values are used by the implementer to retrieve a subset of data from a data source.  
  
 A `Cache` object uses an implementation of this interface during construction to load two initial pages of data. Whenever an uncached value is needed, the cache discards one of these pages and requests a new page containing the value from the `IDataPageRetriever`.  
  
 [!code-csharp[System.Windows.Forms.DataGridView.Virtual_lazyloading#201](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridView.Virtual_lazyloading/CS/lazyloading.cs#201)]
 [!code-vb[System.Windows.Forms.DataGridView.Virtual_lazyloading#201](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridView.Virtual_lazyloading/VB/lazyloading.vb#201)]  
  
## The DataRetriever Class  
 The following code example defines the `DataRetriever` class, which implements the `IDataPageRetriever` interface to retrieve pages of data from a server. The `DataRetriever` class also provides `Columns` and `RowCount` properties, which the <xref:System.Windows.Forms.DataGridView> control uses to create the necessary columns and to add the appropriate number of empty rows to the <xref:System.Windows.Forms.DataGridView.Rows%2A> collection. Adding the empty rows is necessary so that the control will behave as though it contains all the data in the table. This means that the scroll box in the scroll bar will have the appropriate size, and the user will be able to access any row in the table. The rows are filled by the <xref:System.Windows.Forms.DataGridView.CellValueNeeded> event handler only when they are scrolled into view.  
  
 [!code-csharp[System.Windows.Forms.DataGridView.Virtual_lazyloading#200](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridView.Virtual_lazyloading/CS/lazyloading.cs#200)]
 [!code-vb[System.Windows.Forms.DataGridView.Virtual_lazyloading#200](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridView.Virtual_lazyloading/VB/lazyloading.vb#200)]  
  
## The Cache Class  
 The following code example defines the `Cache` class, which manages two pages of data populated through an `IDataPageRetriever` implementation. The `Cache` class defines an inner `DataPage` structure, which contains a <xref:System.Data.DataTable> to store the values in a single cache page and which calculates the row indexes that represent the upper and lower boundaries of the page.  
  
 The `Cache` class loads two pages of data at construction time. Whenever the <xref:System.Windows.Forms.DataGridView.CellValueNeeded> event requests a value, the `Cache` object determines if the value is available in one of its two pages and, if so, returns it. If the value is not available locally, the `Cache` object determines which of its two pages is farthest from the currently displayed rows and replaces the page with a new one containing the requested value, which it then returns.  
  
 Assuming that the number of rows in a data page is the same as the number of rows that can be displayed on screen at once, this model allows users paging through the table to efficiently return to the most recently viewed page.  
  
 [!code-csharp[System.Windows.Forms.DataGridView.Virtual_lazyloading#300](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridView.Virtual_lazyloading/CS/lazyloading.cs#300)]
 [!code-vb[System.Windows.Forms.DataGridView.Virtual_lazyloading#300](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridView.Virtual_lazyloading/VB/lazyloading.vb#300)]  
  
## Additional Considerations  
 The previous code examples are provided as a demonstration of just-in-time data loading. You will need to modify the code for your own needs to achieve maximum efficiency. At minimum, you will need to choose an appropriate value for the number of rows per page of data in the cache. This value is passed into the `Cache` constructor. The number of rows per page should be no less than the number of rows that can be displayed simultaneously in your <xref:System.Windows.Forms.DataGridView> control.  
  
 For best results, you will need to conduct performance testing and usability testing to determine the requirements of your system and your users. Several factors that you will need to take into consideration include the amount of memory in the client machines running your application, the available bandwidth of the network connection used, and the latency of the server used. The bandwidth and latency should be determined at times of peak usage.  
  
 To improve the scrolling performance of your application, you can increase the amount of data stored locally. To improve startup time, however, you must avoid loading too much data initially. You may want to modify the `Cache` class to increase the number of data pages it can store. Using more data pages can improve scrolling efficiency, but you will need to determine the ideal number of rows in a data page, depending on the available bandwidth and the server latency. With smaller pages, the server will be accessed more frequently, but will take less time to return the requested data. If latency is more of an issue than bandwidth, you may want to use larger data pages.  
  
## See Also  
 <xref:System.Windows.Forms.DataGridView>  
 <xref:System.Windows.Forms.DataGridView.VirtualMode%2A>  
 [Performance Tuning in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/performance-tuning-in-the-windows-forms-datagridview-control.md)  
 [Best Practices for Scaling the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/best-practices-for-scaling-the-windows-forms-datagridview-control.md)  
 [Virtual Mode in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/virtual-mode-in-the-windows-forms-datagridview-control.md)  
 [Walkthrough: Implementing Virtual Mode in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/implementing-virtual-mode-wf-datagridview-control.md)  
 [How to: Implement Virtual Mode with Just-In-Time Data Loading in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/virtual-mode-with-just-in-time-data-loading-in-the-datagrid.md)
