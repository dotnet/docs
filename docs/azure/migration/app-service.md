---
title: Migrate your .NET web app or service to Azure App Service
description: Learn about migrating a .NET web app or service from on-premises to Azure App Service.
ms.topic: conceptual
ms.date: 07/08/2020
---
# Migrate your .NET web app or service to Azure App Service

[App Service](/azure/app-service/overview) is a fully managed compute platform service that's optimized for hosting scalable websites and web applications. This article provides information on how to lift-and-shift an existing application to Azure App Service, modifications to consider, and additional resources for [moving to the cloud](https://azure.microsoft.com/migration/web-applications/). Most ASP.NET websites (Webforms, MVC) and services (Web API, WCF) can move directly to Azure App Service with no changes. Some may need minor changes while others may need some refactoring.

Ready to get started? [Publish your ASP.NET + SQL application to Azure App Service](https://tutorials.visualstudio.com/azure-webapp-migrate/intro).

## Considerations

### On-premises resources (including SQL Server)

Verify access to on-premises resources as these may need to be migrated or changed. The following are options for mitigating access to on-premises resources:

* Create a VPN connecting App Service to on-premises resources using [Azure Virtual Networks](/azure/app-service/web-sites-integrate-with-vnet).
* Securely expose on-premises services to the cloud without firewall changes using [Azure Relay](/azure/service-bus-relay/relay-what-is-it).
* Migrate dependencies such as a [SQL database](./sql.md) to Azure.
* Use platform-as-a-service offerings in the cloud to reduce dependencies. For example, rather than connect to an on-premises mail server, consider using [SendGrid](/azure/sendgrid-dotnet-how-to-send-email).

### Port Bindings

Azure App Service supports port 80 for HTTP and port 443 for HTTPS traffic.

For WCF, the following bindings are supported:

| Binding | Notes |
|--|--|
| `BasicHttp` |  |
| `WSHttp` |  |
| `WSDualHttpBinding` | [Web socket support](/azure/app-service/web-sites-configure) must be enabled. |
| `NetHttpBinding` | [Web socket support](/azure/app-service/web-sites-configure) must be enabled for duplex contracts. |
| `NetHttpsBinding` | [Web socket support](/azure/app-service/web-sites-configure) must be enabled for duplex contracts. |
| `BasicHttpContextBinding` |  |
| `WebHttpBinding` |  |
| `WSHttpContextBinding` |  |

### Authentication

Azure App Service supports anonymous authentication by default and Forms authentication when intended. Windows authentication can be used by integrating with Azure Active Directory and ADFS only. [Learn more about how to integrate your on-premises directories with Azure Active Directory](/azure/active-directory/connect/active-directory-aadconnect).

### Assemblies in the GAC (Global Assembly Cache)

This isn't supported. Consider copying required assemblies to the app's *\bin* folder. Custom *.msi* files installed on the server (for example, PDF generators) cannot be used.

### IIS settings

Everything traditionally configured via applicationHost.config in your application can now be configured through the Azure portal. This applies to AppPool bitness, enable/disable WebSockets, managed pipeline version, .NET Framework version (2.0/4.0), and so on. To modify your [application settings](/azure/app-service/web-sites-configure), navigate to the [Azure portal](https://portal.azure.com), open the blade for your web app, and then select the **Application Settings** tab.

#### IIS5 Compatibility Mode

IIS5 Compatibility Mode is not supported. In Azure App Service, each web app and all of the applications under it run in the same worker process with a specific set of [application pools](/previous-versions/windows/it-pro/windows-server-2008-R2-and-2008/cc735247(v=ws.10)).

#### IIS7+ schema compliance

Some elements and attributes are not defined in the Azure App Service IIS schema. If you encounter issues, consider using [XDT transforms](/azure/app-service/configure-common).

#### Single application pool per site

In Azure App Service, each web app and all of the applications under it run in the same application pool. Consider establishing a single application pool with common settings or creating a separate web app for each application.

### COM and COM+ components

Azure App Service does not allow the registration of COM components on the platform. If your app makes use of any COM components, these need to be rewritten in managed code and deployed with the site or application.

### Physical directories

Azure App Service does not allow physical drive access. You may need to use [Azure Files](/azure/storage/files/storage-files-introduction) to access files via SMB. [Azure Blob Storage](/azure/storage/blobs/storage-blobs-introduction) can store files for access via HTTPS.

### ISAPI filters

Azure App Service can support the use of ISAPI Filters, however, the ISAPI DLL must be deployed with your site and registered via web.config.

### HTTPS bindings and SSL

HTTPS bindings are not migrated, nor are the SSL certificates associated with your web sites. [SSL certificates can be manually uploaded](/azure/app-service/app-service-web-tutorial-custom-ssl) after site migration is completed, however.

### SharePoint and FrontPage

SharePoint and FrontPage Server Extensions (FPSE) are not supported.

### Web site size

Free sites have a size limit of 1 GB of content. If your site is greater than 1 GB, you must upgrade to a paid SKU. See [App Service pricing](https://azure.microsoft.com/pricing/details/app-service/windows/).

### Database size

For SQL Server databases, please check the current [SQL Database pricing](https://azure.microsoft.com/pricing/details/sql-database).

### Azure Active Directory (AAD) integration

AAD does not work with free apps. To use AAD, you must upgrade the app SKU. See [App Service pricing](https://azure.microsoft.com/pricing/details/app-service/windows/).

### Monitoring and diagnostics

Your current on-premises solutions for monitoring and diagnostics are unlikely to work in the cloud. However, Azure provides tools for logging, monitoring, and diagnostics so that you can identify and debug issues with web apps. You can easily enable diagnostics for your web app in its configuration, and you can view the logs recorded in Azure Application Insights. [Learn more about enabling diagnostics logging for web apps](/azure/app-service/web-sites-enable-diagnostic-log).

### Connection strings and application settings

Consider using [Azure KeyVault](/azure/key-vault/), a service that securely stores sensitive information used in your application. Alternatively, you can store this data as an App Service setting.

### DNS

You may need to update DNS configurations based on the requirements of your application. These DNS settings can be configured in the App Service [custom domain settings](/azure/app-service/app-service-web-tutorial-custom-domain).

## Azure App Service with Windows Containers

If your app cannot be migrated directly to App Service, consider App Service using Windows Containers, which enables usage of the GAC, COM components, MSIs, full access to .NET FX APIs, DirectX, and more.

## See also

* [How to determine if your app qualifies for App Service](https://appmigration.microsoft.com/)
* [Moving your database to the cloud](sql.md)
* [Azure web app sandbox details and restrictions](https://github.com/projectkudu/kudu/wiki/Azure-Web-App-sandbox)
