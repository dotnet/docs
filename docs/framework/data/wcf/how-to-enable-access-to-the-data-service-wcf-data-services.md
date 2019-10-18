---
title: "How to: Enable Access to the Data Service (WCF Data Services)"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "WCF Data Services, configuring"
ms.assetid: 3d830bcd-32b4-4f26-9287-d58a071452c6
---
# How to: Enable Access to the Data Service (WCF Data Services)
In [!INCLUDE[ssAstoria](../../../../includes/ssastoria-md.md)], you must explicitly grant access to the resources that are exposed by a data service. This means that after you create a new data service, you must still explicitly provide access to individual resources as entity sets. This topic shows how to enable read and write access to five of the entity sets in the Northwind data service that is created when you complete the [quickstart](quickstart-wcf-data-services.md). Because the <xref:System.Data.Services.EntitySetRights> enumeration is defined by using the <xref:System.FlagsAttribute>, you can use a logical OR operator to specify multiple permissions for a single entity set.  
  
> [!NOTE]
> Any client that can access the ASP.NET application can also access the resources exposed by the data service. In a production data service, to prevent unauthorized access to resources, you should also secure the application itself. For more information, see [Securing ASP.NET Web Sites](https://docs.microsoft.com/previous-versions/aspnet/91f66yxt(v=vs.100)).  
  
### To enable access to the data service  
  
- In the code for the data service, replace the placeholder code in the `InitializeService` function with the following:  
  
     [!code-csharp[Astoria Quickstart Service#AllReadConfig](../../../../samples/snippets/csharp/VS_Snippets_Misc/astoria_quickstart_service/cs/northwind.svc.cs#allreadconfig)]
     [!code-vb[Astoria Quickstart Service#AllReadConfig](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/astoria_quickstart_service/vb/northwind.svc.vb#allreadconfig)]  
  
     This enables clients to have read and write access to the `Orders` and `Order_Details` entity sets and read-only access to the `Customers` entity sets.  
  
## See also

- [How to: Develop a WCF Data Service Running on IIS](how-to-develop-a-wcf-data-service-running-on-iis.md)
- [Configuring the Data Service](configuring-the-data-service-wcf-data-services.md)
