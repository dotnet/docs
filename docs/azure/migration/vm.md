---
title: Migrate an ASP.NET Web app to an Azure VM
description: Learn how to migrate an ASP.NET Web application from on-premises to an Azure Virtual Machine.
ms.topic: how-to
ms.date: 06/20/2020
recommendations: false
---

# Migrate an ASP.NET Web application to an Azure Virtual Machine

This document provides an overview of how to migrate an ASP.NET web application from on-premises to an Azure Virtual Machine.

## Quickstart

Learn how to create a virtual machine and publish your app to it: [Publish to an Azure VM](https://tutorials.visualstudio.com/aspnet-vm/intro)

## Get Started

These tutorials demonstrate the steps to create (or migrate) a virtual machine, publish your web application to it, and other tasks that may be required to support your application in Azure.

- Create a virtual machine for your ASP.NET application in Azure using one of the following options:
  - [Create a new virtual machine for ASP.NET Applications](https://go.microsoft.com/fwlink/?linkid=863237)
  - [Migrate an existing on-premises VMWare virtual machine](/azure/migrate/tutorial-migrate-vmware)
  - [Migrate an existing on-premises Hyper-V virtual machine](/azure/migrate/tutorial-migrate-hyper-v)
- [Publish a cloud service using Visual Studio](/visualstudio/azure/vs-azure-tools-publishing-a-cloud-service)
- [Create a secure virtual network for your VMs](/azure/virtual-network/virtual-network-get-started-vnet-subnet)
- [Create a CI/CD pipeline for your application](/vsts/build-release/apps/cd/deploy-webdeploy-iis-deploygroups)
- [Move to a VM scale set for high availability and scalability](/azure/virtual-machine-scale-sets/virtual-machine-scale-sets-deploy-app)

## Considerations

### Benefits

Virtual machines offer the easiest path to migrate an application from on-premises to the cloud. They enable you to replicate the same environment your application uses on-premises, while removing the need to maintain your own data centers. Virtual Machine Scale Sets provide high availability and scalability for applications running in Virtual Machines.

### Virtual Machine Size

Choose the virtual machine size and type that is best optimized for your workload. For more information, see [Sizes for Windows virtual machines in Azure](/azure/virtual-machines/windows/sizes).

### Maintenance

Just like an on-premises machine, you are responsible for maintaining and updating the virtual machine<sup>&#42;</sup>. If your application can run in a Platform as a Service (PaaS) environment such as [Azure App Service](/azure/app-service/) or in a [container](/azure/app-service/containers/), that will remove this need.

*<sup>&#42;</sup>[Automatic OS upgrades for virtual machine scale sets](/azure/virtual-machine-scale-sets/virtual-machine-scale-sets-automatic-upgrade) is currently available as a Preview service.*

### Virtual Networks

Azure Virtual Networks enable you to:

- Build a hybrid infrastructure that you control
- Bring your own IP addresses and DNS servers
- Create an isolated and highly secure environment for your applications
- Connect your VM to your on-premises network using one of several [connectivity options](/azure/vpn-gateway/vpn-gateway-about-vpngateways#s2smulti)
- Integrate your virtual machine into your on-premises network using [ExpressRoute](https://azure.microsoft.com/services/expressroute/)

To get started, see the [Virtual Network documentation](/azure/virtual-network/)

### Active Directory

Many applications use Active Directory for authentication and identity management.

- Azure AD Connect enables you to integrate your on-premises directories with Azure Active Directory. To get started, see [Integrate your on-premises directories with Azure Active Directory](/azure/active-directory/connect/active-directory-aadconnect).
- Alternatively, [ExpressRoute](https://azure.microsoft.com/services/expressroute/) enables your application to access your on-premises Active Directory.

### SQL Databases

If your application is using an on-premises database, your app will not be able to talk to it by default. You can either:

- Configure a hybrid network that enables your application to access your database running on-premises.
- Migrate your database to the Azure. For more information, see [Migrate your SQL Server database to Azure](sql.md).

### High Availability and Scalability

#### Virtual Machine Scale Sets

You want to make sure that your application is highly available and can scale, migrate your VM image to an Azure Virtual Machine Scale Set to improve the availability and scalability of your application. VM Scale Sets provide the ability to use an existing VM you've already configured or set up a build pipeline to build an image with your application.

To get started, see [Deploy your application on virtual machine scale sets](/azure/virtual-machine-scale-sets/virtual-machine-scale-sets-deploy-app).

#### Centralized Logging

When running your application across multiple instances, consider storing your logs in a centralized location such as [Azure Storage](/azure/storage/).

## Next steps

> [!div class="nextstepaction"]
> [Migrate a SQL Server database to Azure](sql.md)
