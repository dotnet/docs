---
title: "Binding Data to Controls (WCF Data Services)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework-oob"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "client applications, WCF Data Services"
  - "WCF Data Services, client library"
  - "data binding, WCF Data Services"
ms.assetid: b32e1d49-c214-4cb1-867e-88fbb3d08c8d
caps.latest.revision: 3
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Binding Data to Controls (WCF Data Services)
With [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)], you can bind controls such as the `ComboBox` and `ListView` controls to an instance of the <xref:System.Data.Services.Client.DataServiceCollection%601> class. This collection, which inherits from the <xref:System.Collections.ObjectModel.ObservableCollection%601> class, contains the data from an [!INCLUDE[ssODataFull](../../../../includes/ssodatafull-md.md)] feed. This class represents a dynamic data collection that provides notifications when items get added or removed. When you use an instance of <xref:System.Data.Services.Client.DataServiceCollection%601> for data binding, the [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] client libraries handle these events to ensure that objects tracked by the <xref:System.Data.Services.Client.DataServiceContext> remain synchronized with the data in the bound UI element.  
  
 The <xref:System.Data.Services.Client.DataServiceCollection%601> class (indirectly) implements the <xref:System.Collections.Specialized.INotifyCollectionChanged> interface to alert the context when objects are added to or removed from the collection. Data service type objects used with a <xref:System.Data.Services.Client.DataServiceCollection%601> must also implement the <xref:System.ComponentModel.INotifyPropertyChanged> interface to alert the <xref:System.Data.Services.Client.DataServiceCollection%601> when properties of objects in the binding collection have changed.  
  
> [!NOTE]
>  When you use the **Add Service Reference** dialog or the[DataSvcUtil.exe](../../../../docs/framework/data/wcf/wcf-data-service-client-utility-datasvcutil-exe.md) tool with the `/dataservicecollection` option to generate the client data service classes, the generated data classes implement the <xref:System.ComponentModel.INotifyPropertyChanged> interface. For more information, see [How to: Manually Generate Client Data Service Classes](../../../../docs/framework/data/wcf/how-to-manually-generate-client-data-service-classes-wcf-data-services.md).  
  
## Creating the Binding Collection  
 Create a new instance of the <xref:System.Data.Services.Client.DataServiceCollection%601> class by calling one of the class constructor methods with a supplied <xref:System.Data.Services.Client.DataServiceContext> instance and optionally a <xref:System.Data.Services.Client.DataServiceQuery%601> or LINQ query that, when it is executed, returns an <xref:System.Collections.Generic.IEnumerable%601> instance. This <xref:System.Collections.Generic.IEnumerable%601> provides the source of objects for the binding collection, which are materialized from an [!INCLUDE[ssODataShort](../../../../includes/ssodatashort-md.md)] feed. For more information, see [Object Materialization](../../../../docs/framework/data/wcf/object-materialization-wcf-data-services.md). By default, changes made to bound objects and items inserted into the collection are automatically tracked by the <xref:System.Data.Services.Client.DataServiceContext>. If you need to manually track these changes, call one of the constructor methods that takes a `trackingMode` parameter and specify a value of <xref:System.Data.Services.Client.TrackingMode.None>.  
  
 The following example shows how to create an instance of <xref:System.Data.Services.Client.DataServiceCollection%601> based on a supplied <xref:System.Data.Services.Client.DataServiceContext> and a <xref:System.Data.Services.Client.DataServiceQuery%601> that returns all customers with related orders:  
  
 [!code-csharp[Astoria Northwind Client#CustomersOrders2Binding](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria northwind client/cs/customerorders2.cs#customersorders2binding)]
 [!code-vb[Astoria Northwind Client#CustomersOrders2Binding](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria northwind client/vb/customerorders2.vb#customersorders2binding)]  
  
## Binding Data to Windows Presentation Foundation Elements  
 Because the <xref:System.Data.Services.Client.DataServiceCollection%601> class inherits from the <xref:System.Collections.ObjectModel.ObservableCollection%601> class, you can bind objects to an element, or control, in a Windows Presentation Foundation (WPF) application as you would when using the <xref:System.Collections.ObjectModel.ObservableCollection%601> class for binding. For more information, see [Data Binding (Windows Presentation Foundation)](../../../../docs/framework/wpf/data/data-binding-wpf.md). One way to bind data service data to WPF controls is to set the `DataContext` property of the element to the instance of the <xref:System.Data.Services.Client.DataServiceCollection%601> class that contains the query result. In this case, you use the <xref:System.Windows.Controls.ItemsControl.ItemsSource%2A> property to set the object source for the control. Use the <xref:System.Windows.Controls.ItemsControl.DisplayMemberPath%2A> property to specify which property of the bound object to display. If you are binding an element to a related object that is returned by a navigation property, include the path in the binding defined for the <xref:System.Windows.Controls.ItemsControl.ItemsSource%2A> property. This path is relative to the root object set by the <xref:System.Windows.FrameworkElement.DataContext%2A> property of the parent control. The following example sets the <xref:System.Windows.FrameworkElement.DataContext%2A> property of a <xref:System.Windows.Controls.StackPanel> element to bind the parent control to an <xref:System.Data.Services.Client.DataServiceCollection%601> of customer objects:  
  
 [!code-csharp[Astoria Northwind Client#MasterDetailBinding](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria northwind client/cs/customerorderscustom.xaml.cs#masterdetailbinding)]
 [!code-csharp[Astoria Northwind Client#MasterDetailBinding](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria northwind client/cs/customerorderswpf.xaml.cs#masterdetailbinding)]
 [!code-vb[Astoria Northwind Client#MasterDetailBinding](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria northwind client/vb/customerorderscustom.xaml.vb#masterdetailbinding)]
 [!code-vb[Astoria Northwind Client#MasterDetailBinding](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria northwind client/vb/customerorderswpf.xaml.vb#masterdetailbinding)]
 [!code-vb[Astoria Northwind Client#MasterDetailBinding](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria northwind client/vb/customerorderscustom2.xaml.vb#masterdetailbinding)]  
  
 The following example shows the XAML binding definition of the child <xref:System.Windows.Controls.DataGrid> and <xref:System.Windows.Controls.ComboBox> controls:  
  
 [!code-xaml[Astoria Northwind Client#MasterDetailXaml](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria northwind client/vb/customerorderswpf.xaml#masterdetailxaml)]  
  
 For more information, see [How to: Bind Data to Windows Presentation Foundation Elements](../../../../docs/framework/data/wcf/bind-data-to-wpf-elements-wcf-data-services.md).  
  
 When an entity participates in a one-to-many or many-to-many relationship, the navigation property for the relationship returns a collection of related objects. When you use the **Add Service Reference** dialog box or the DataSvcUtil.exe tool to generate the client data service classes, the navigation property returns an instance of <xref:System.Data.Services.Client.DataServiceCollection%601>. This enables you to bind related objects to a control, and support common WPF binding scenarios, such as the master-detail binding pattern for related entities. In the previous XAML example, the XAML code binds the master <xref:System.Data.Services.Client.DataServiceCollection%601> to the root data element. The order <xref:System.Windows.Controls.DataGrid> is then bound to the Orders <xref:System.Data.Services.Client.DataServiceCollection%601> returned from the selected Customers object, which is in turn bound to the root data element of the <xref:System.Windows.Window>.  
  
## Binding Data to Windows Forms Controls  
 To bind objects to a Windows Form control, set the `DataSource` property of the control to the instance of the <xref:System.Data.Services.Client.DataServiceCollection%601> class that contains the query result.  
  
> [!NOTE]
>  Data binding is only supported for controls that listen for change events by implementing the <xref:System.Collections.Specialized.INotifyCollectionChanged> and <xref:System.ComponentModel.INotifyPropertyChanged> interfaces. When a control does not support this kind of change notification, changes that are made to the underlying <xref:System.Data.Services.Client.DataServiceCollection%601> are not reflected in the bound control.  
  
 The following example binds an <xref:System.Data.Services.Client.DataServiceCollection%601> to a <xref:System.Windows.Forms.ComboBox> control:  
  
 [!code-csharp[Astoria Northwind Client#CustomersOrdersDataBindingSpecific](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria northwind client/cs/customerorders.cs#customersordersdatabindingspecific)]
 [!code-vb[Astoria Northwind Client#CustomersOrdersDataBindingSpecific](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria northwind client/vb/customerorders.vb#customersordersdatabindingspecific)]  
  
 When you use the **Add Service Reference** dialog to generate the client data service classes, a project data source is also created that is based on the generated <xref:System.Data.Services.Client.DataServiceContext>. With this data source, you can create UI elements or controls that display data from the data service simply by dragging items from the **Data Sources** window onto the designer. These items become elements in the application UI that are bound to the data source. For more information, see [How to: Bind Data Using a Project Data Source](../../../../docs/framework/data/wcf/how-to-bind-data-using-a-project-data-source-wcf-data-services.md).  
  
## Binding Paged Data  
 A data service can be configured to limit the amount of queried data that is returned in a single response message. For more information, see [Configuring the Data Service](../../../../docs/framework/data/wcf/configuring-the-data-service-wcf-data-services.md). When the data service is paging response data, each response contains a link that is used to return the next page of results. For more information, see [Loading Deferred Content](../../../../docs/framework/data/wcf/loading-deferred-content-wcf-data-services.md). In this case, you must explicitly load pages by calling the <xref:System.Data.Services.Client.DataServiceCollection%601.Load%2A> method on the <xref:System.Data.Services.Client.DataServiceCollection%601> by passing the URI obtained from the <xref:System.Data.Services.Client.DataServiceQueryContinuation.NextLinkUri%2A> property, as in the following example:  
  
 [!code-csharp[Astoria Northwind Client#BindPagedDataSpecific](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria northwind client/cs/customerorderswpf3.xaml.cs#bindpageddataspecific)]
 [!code-vb[Astoria Northwind Client#BindPagedDataSpecific](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria northwind client/vb/customerorderswpf3.xaml.vb#bindpageddataspecific)]  
  
 Related objects are loaded in a similar manner. For more information, see [How to: Bind Data to Windows Presentation Foundation Elements](../../../../docs/framework/data/wcf/bind-data-to-wpf-elements-wcf-data-services.md).  
  
## Customizing Data Binding Behaviors  
 The <xref:System.Data.Services.Client.DataServiceCollection%601> class enables you to intercept the events raised when changes are made to the collection, such as an object being added or removed, and when changes are made to the properties of object in a collection. You can modify the data binding events to override the default behavior, which includes the following constraints:  
  
-   No validation is performed within the delegates.  
  
-   Adding an entity automatically adds related entities.  
  
-   Deleting an entity does not delete the related entities.  
  
 When you create a new instance of <xref:System.Data.Services.Client.DataServiceCollection%601>, you have the option to specify the following parameters that define delegates to methods that handle the events raised when bound objects are changed:  
  
-   `entityChanged` - a method that is called when the property of a bound object is changed. This <xref:System.Func%602> delegate accepts an <xref:System.Data.Services.Client.EntityChangedParams> object and returns a Boolean value that indicates whether the default behavior, to call <xref:System.Data.Services.Client.DataServiceContext.UpdateObject%2A> on the <xref:System.Data.Services.Client.DataServiceContext>, should still occur.  
  
-   `entityCollectionChanged` - a method that is called when an object is added or removed from the binding collection. This <xref:System.Func%602> delegate accepts an <xref:System.Data.Services.Client.EntityCollectionChangedParams> object and returns a Boolean value that indicates whether the default behavior, to call <xref:System.Data.Services.Client.DataServiceContext.AddObject%2A> for an <xref:System.Collections.Specialized.NotifyCollectionChangedAction.Add> action or <xref:System.Data.Services.Client.DataServiceContext.DeleteObject%2A> for a <xref:System.Collections.Specialized.NotifyCollectionChangedAction.Remove> action on the <xref:System.Data.Services.Client.DataServiceContext>, should still occur.  
  
> [!NOTE]
>  [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)] performs no validation of the custom behaviors that you implement in these delegates.  
  
 In the following example, the <xref:System.Collections.Specialized.NotifyCollectionChangedAction.Remove> action is customized to call the <xref:System.Data.Services.Client.DataServiceContext.DeleteLink%2A> and <xref:System.Data.Services.Client.DataServiceContext.DeleteObject%2A> method to remove `Orders_Details` entities that belong to a deleted `Orders` entity. This custom action is performed because dependent entities are not automatically deleted when the parent entity is deleted.  
  
 [!code-csharp[Astoria Northwind Client#CustomersOrdersDeleteRelated](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria northwind client/cs/customerorderscustom.xaml.cs#customersordersdeleterelated)]
 [!code-vb[Astoria Northwind Client#CustomersOrdersDeleteRelated](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria northwind client/vb/customerorderscustom.xaml.vb#customersordersdeleterelated)]
 [!code-vb[Astoria Northwind Client#CustomersOrdersDeleteRelated](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria northwind client/vb/customerorderscustom2.xaml.vb#customersordersdeleterelated)]  
  
 For more information, see [How to: Customize Data Binding Behaviors](../../../../docs/framework/data/wcf/how-to-customize-data-binding-behaviors-wcf-data-services.md).  
  
 The default behavior when an object is removed from a <xref:System.Data.Services.Client.DataServiceCollection%601> by using the <xref:System.Collections.ObjectModel.Collection%601.Remove%2A> method is that the object is also marked as deleted in the <xref:System.Data.Services.Client.DataServiceContext>. To change this behavior, you can specify a delegate to a method in the `entityCollectionChanged` parameter that is called when the <xref:System.Collections.Specialized.INotifyCollectionChanged.CollectionChanged> event occurs.  
  
## Data Binding with Custom Client Data Classes  
 To be able to load objects into a <xref:System.Data.Services.Client.DataServiceCollection%601>, the objects themselves must implement the <xref:System.ComponentModel.INotifyPropertyChanged> interface. Data service client classes that are generated when you use the **Add Service Reference** dialog box or the [DataSvcUtil.exe](../../../../docs/framework/data/wcf/wcf-data-service-client-utility-datasvcutil-exe.md) tool implement this interface. If you provide your own client data classes, you must use another type of collection for data binding. When objects change, you must handle events in the data bound controls to call the following methods of the <xref:System.Data.Services.Client.DataServiceContext> class:  
  
-   <xref:System.Data.Services.Client.DataServiceContext.AddObject%2A> - when a new object is added to the collection.  
  
-   <xref:System.Data.Services.Client.DataServiceContext.DeleteObject%2A> - when an object is removed from the collection.  
  
-   <xref:System.Data.Services.Client.DataServiceContext.UpdateObject%2A> - when a property is changed on an object in the collection.  
  
-   <xref:System.Data.Services.Client.DataServiceContext.AddLink%2A> - when an object is added to a collection of related object.  
  
-   <xref:System.Data.Services.Client.DataServiceContext.SetLink%2A> - when an object is added to a collection of related objects.  
  
 For more information, see [Updating the Data Service](../../../../docs/framework/data/wcf/updating-the-data-service-wcf-data-services.md).  
  
## See Also  
 [How to: Manually Generate Client Data Service Classes](../../../../docs/framework/data/wcf/how-to-manually-generate-client-data-service-classes-wcf-data-services.md)  
 [How to: Add a Data Service Reference](../../../../docs/framework/data/wcf/how-to-add-a-data-service-reference-wcf-data-services.md)
