---
title: "Developing and Deploying WCF Data Services"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "WCF Data Services, developing"
  - "WCF Data Services, deploying"
  - "deploying [WCF Data Services"
  - "developing applications [WCF Data Services]"
ms.assetid: 6557c0e3-5aea-4f6e-bc14-77ad317a168b
---
# Develop and Deploy WCF Data Services

This topic provides information about developing and deploying WCF Data Services. For more basic information about WCF Data Services, see [Getting Started](../../../../docs/framework/data/wcf/getting-started-with-wcf-data-services.md) and [Overview](../../../../docs/framework/data/wcf/wcf-data-services-overview.md).

## Develop WCF Data Services

When you use WCF Data Services to create a data service that supports the [!INCLUDE[ssODataFull](../../../../includes/ssodatafull-md.md)], you must perform the following basic tasks during development:

1.  **Define the data model**

     WCF Data Services supports a variety of data service providers that enable you to define a data model based on data from a variety of data sources, from relational databases to late-bound data types. For more information, see [Data Services Providers](../../../../docs/framework/data/wcf/data-services-providers-wcf-data-services.md).

2.  **Create the data service**

     The most basic data service exposes a class that inherits from the <xref:System.Data.Services.DataService%601> class, with a type `T` that is the namespace-qualified name of the entity container. For more information, see [Defining WCF Data Services](../../../../docs/framework/data/wcf/defining-wcf-data-services.md).

3.  **Configure the data service**

     By default, WCF Data Services disables access to resources that are exposed by an entity container. The <xref:System.Data.Services.DataServiceConfiguration> interface enables you to configure access to resources and service operations, specify the supported version of OData, and to define other service-wide behaviors, such as batching behaviors or the maximum number of entities that can be returned in a single response feed. For more information, see [Configuring the Data Service](../../../../docs/framework/data/wcf/configuring-the-data-service-wcf-data-services.md).

This topic covers primarily the development and deployment of data services by using Visual Studio. For information about the flexibility provided by WCF Data Services for exposing your data as OData feeds, see [Defining WCF Data Services](../../../../docs/framework/data/wcf/defining-wcf-data-services.md).

### Choose a Development Web Server

When you develop a WCF Data Service as an [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] application or [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] Web site by using Visual Studio 2015, you have a choice of Web servers on which to run the data service during development. The following Web servers integrate with Visual Studio to make it easier to test and debug your data services on the local computer.

1.  **Local IIS Server**

     When you create a data service that is an [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] application or [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] Web site that runs on Internet Information Services (IIS), we recommend that you develop and test your data service by using IIS on the local computer. Running the data service on IIS makes it easier to trace HTTP requests during debugging. This also enables you to pre-determine the necessary rights required by IIS to access files, databases, and other resources required by the data service. To run your data service on IIS, you must makes sure that both IIS and Windows Communication Foundation (WCF) are installed and configured correctly and grant access to IIS accounts in the file system and databases. For more information, see [How to: Develop a WCF Data Service Running on IIS](../../../../docs/framework/data/wcf/how-to-develop-a-wcf-data-service-running-on-iis.md).

    > [!NOTE]
    > You must run Visual Studio with administrator rights to enable the develop environment to configure the local IIS server.

2.  **Visual Studio Development Server**

     Visual Studio includes a built-in Web server, the Visual Studio Development Server, which is the default Web server for [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] projects. This Web server is designed to run [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] projects on the local computer during development. The [WCF Data Services quickstart](../../../../docs/framework/data/wcf/quickstart-wcf-data-services.md) shows how to create a data service that runs in the Visual Studio Development Server.

     You should be aware of the following limitations when you use the Visual Studio Development Server to develop the data service:

    -   This server can only be accessed on the local computer.

    -   This server listens on `localhost` and on a specific port, not on port 80, which is the default port for HTTP messages. For more information, see [Web Servers in Visual Studio for ASP.NET Web Projects](https://docs.microsoft.com/previous-versions/aspnet/58wxa9w5(v=vs.120)).

    -   This server runs the data service in the context of your current user account. For example, if you are running as an administrator-level user, a data service running in the Visual Studio Development Server will have administrator-level privileges. This can cause the data service to be able to access resources that it does not have the rights to access when deployed to an IIS server.

    -   This server does not include the extra facilities of IIS, such as authentication.

    -   This server cannot handle chunked HTTP streams, which are sent be default by the WCF Data Services client when accessing large binary data from the data service. For more information, see [Streaming Provider](../../../../docs/framework/data/wcf/streaming-provider-wcf-data-services.md).

    -   This server has issues with processing the period (`.`) character in a URL, even though this character is supported by WCF Data Services in key values.

    > [!TIP]
    > Even though you can use the Visual Studio Development Server to test your data services during development, you should test them again after deploying to a Web server that is running IIS.

3.  **Windows Azure Development Environment**

     Windows Azure Tools for Visual Studio includes an integrated set of tools for developing Windows Azure services in Visual Studio. With these tools, you can develop a data service that can be deployed to Windows Azure, and you can test the data service on the local computer before deployment. Use these tools when using Visual Studio to develop a data service that runs on the Windows Azure platform. You can download the Windows Azure Tools for Visual Studio from the [Microsoft Download Center](https://go.microsoft.com/fwlink/?LinkID=201848). For more information about developing a data service that runs on Windows Azure, see the post [Deploying an OData Service in Windows Azure](https://go.microsoft.com/fwlink/?LinkId=201847).

### Development Tips

You should consider the following when you develop a data service:

-   Determine the security requirements of your data service, if you plan authenticate users or restrict access for specific users. For more information, see [Securing WCF Data Services](../../../../docs/framework/data/wcf/securing-wcf-data-services.md).

-   An HTTP inspection program can be very helpful when debugging a data service by enabling you to inspect the contents of request and response messages. Any network packet analyzer that can display raw packets can be used to inspect HTTP requests to and responses from the data service.

-   When debugging a data service, you may want to get more information about an error from the data service than during regular operation. You can get additional error information from the data service by setting the <xref:System.Data.Services.DataServiceConfiguration.UseVerboseErrors%2A> property in the <xref:System.Data.Services.DataServiceConfiguration> to `true` and by setting the <xref:System.ServiceModel.Description.ServiceDebugBehavior.IncludeExceptionDetailInFaults%2A> property of the <xref:System.ServiceModel.Description.ServiceDebugBehavior> attribute on the data service class to `true`. For more information, see the post [Debugging WCF Data Services](https://go.microsoft.com/fwlink/?LinkId=201868). You can also enable tracing in WCF to view exceptions raised in the HTTP messaging layer. For more information, see [Configuring Tracing](../../../../docs/framework/wcf/diagnostics/tracing/configuring-tracing.md).

-   A data service is usually developed as an [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] application project, but you can also create you data service as an [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] Web site project in Visual Studio. For information about the differences between the two types of projects, see [Web Application Projects versus Web Site Projects in Visual Studio](https://docs.microsoft.com/previous-versions/aspnet/dd547590(v=vs.110)).

-   When you create a data service by using the **Add New Item** dialog box in Visual Studio, the data service is hosted by [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] in IIS. While [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] and IIS is the default host for a data service, other hosting options are supported. For more information, see [Hosting the Data Service](../../../../docs/framework/data/wcf/hosting-the-data-service-wcf-data-services.md).

## Deploy WCF Data Services

WCF Data Service provides flexibility in choosing the process that hosts the data service. You can use Visual Studio to deploy a data service to the following platforms:

-   **IIS-Hosted Web Server**

     When a data service is developed as an [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] project, it can be deployed to an IIS Web server by using the standard [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] deployment processes.  Visual Studio provides the following deployment technologies for [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)], depending on the kind of [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] project that hosts the data service that you are deploying.

    -   **Deployment Technologies for ASP.NET Web Applications**

        -   [How to: Create a Web Deployment Package in Visual Studio](https://docs.microsoft.com/previous-versions/aspnet/dd465323(v=vs.110))

        -   [How to: Deploy a Web Project Using One-Click Publish in Visual Studio](https://docs.microsoft.com/previous-versions/aspnet/dd465337(v=vs.110))

    -   **Deployment Technologies for ASP.NET Web Sites**

        -   [How to: Copy Web Site Files with the Copy Web Site Tool](https://docs.microsoft.com/previous-versions/aspnet/c95809c0(v=vs.100))

        -   [How to: Publish Web Sites](https://docs.microsoft.com/previous-versions/aspnet/20yh9f1b(v=vs.100))

        -   [Walkthrough: Deploying an ASP.NET Web Application Using XCOPY](https://docs.microsoft.com/previous-versions/aspnet/f735abw9(v=vs.100))

     For more information about the deployment options for an [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] application, see [Web Deployment Overview for Visual Studio and ASP.NET](https://docs.microsoft.com/previous-versions/aspnet/dd394698(v=vs.110)).

    > [!TIP]
    > Before you attempt to deploy the data service to IIS, make sure that you have tested the deployment to a Web server that is running IIS. For more information, see [How to: Develop a WCF Data Service Running on IIS](../../../../docs/framework/data/wcf/how-to-develop-a-wcf-data-service-running-on-iis.md).

-   **Windows Azure**

     You can deploy a data service to Windows Azure by using Windows Azure Tools for Visual Studio. You can download the Windows Azure Tools for Visual Studio from the [Microsoft Download Center](https://go.microsoft.com/fwlink/?LinkID=201848). For more information about deploying a data service to Windows Azure, see the post [Deploying an OData Service in Windows Azure](https://go.microsoft.com/fwlink/?LinkId=201847).

### Deployment Considerations

You should consider the following when deploying a data service:

-   When you deploy a data service that uses the [!INCLUDE[adonet_ef](../../../../includes/adonet-ef-md.md)] provider to access a SQL Server database, you might also have to propagate data structures, data, or both with your data service deployment. Visual Studio can automatically create scripts (.sql files) to do this in the destination database, and these scripts can be included in the Web deployment package of an [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] application. For more information, see [How to: Deploy a Database With a Web Application Project](https://docs.microsoft.com/previous-versions/dd465343(v=vs.100)). For an [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] Web site, you can do this by using the **Database Publishing Wizard** in Visual Studio. For more information, see [Publishing a SQL Database](https://docs.microsoft.com/previous-versions/aspnet/bb907585(v=vs.100)).

-   Because WCF Data Services includes a basic WCF implementation, you can use Windows Server AppFabric to monitor a data service deployed to IIS running on Windows Server. For more information about using Windows Server AppFabric to monitor a data service, see the post [Tracking WCF Data Services with Windows Server AppFabric](https://go.microsoft.com/fwlink/?LinkID=202005).

## See also

- [Hosting the Data Service](../../../../docs/framework/data/wcf/hosting-the-data-service-wcf-data-services.md)
- [Securing WCF Data Services](../../../../docs/framework/data/wcf/securing-wcf-data-services.md)
- [Defining WCF Data Services](../../../../docs/framework/data/wcf/defining-wcf-data-services.md)
