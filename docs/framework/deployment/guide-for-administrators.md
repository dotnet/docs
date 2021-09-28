---
title: ".NET Framework Deployment Guide for Administrators"
description: Read the .NET deployment guide for administrators. Use this information to deploy .NET version 4.5 and its system dependencies across a network.
ms.date: "04/10/2018"
helpviewer_keywords:
  - "administrator's guide, deploying .NET Framework"
  - "deployment [.NET Framework], administrator's guide"
ms.assetid: bee14036-0436-44e8-89f5-4bc61317977a
---
# .NET Framework Deployment Guide for Administrators

This step-by-step article describes how a system administrator can deploy .NET Framework 4.5 and its system dependencies across a network by using Microsoft Endpoint Configuration Manager. This article assumes that all target client computers meet the minimum requirements for .NET Framework. For a list of the software and hardware requirements for installing .NET Framework 4.5, see [System Requirements](../get-started/system-requirements.md).

> [!NOTE]
> The software referenced in this document, including, without limitation, .NET Framework 4.5, Configuration Manager, and Active Directory, are each subject to license terms and conditions. These instructions assume that such license terms and conditions have been reviewed and accepted by the appropriate licensees of the software. These instructions do not waive any of the terms and conditions of such license agreements.
>
> For information about support for .NET Framework, see [.NET Framework official support policy](https://dotnet.microsoft.com/platform/support/policy/dotnet-framework) on the Microsoft Support website.

This topic contains the following sections:

- [The deployment process](#the_deployment_process)
- [Deploying .NET Framework](#deploying_in_a_test_environment)
- [Create a collection](#creating_a_collection)
- [Create a package and program](#creating_a_package)
- [Select a distribution point](#select_dist_point)
- [Deploy the package](#deploying_package)
- [Resources](#resources)
- [Troubleshooting](#troubleshooting)

<a name="the_deployment_process"></a>

## The deployment process

When you have the supporting infrastructure in place, you use Configuration Manager to deploy the .NET Framework redistributable package to computers on the network. Building the infrastructure involves creating and defining five primary areas: collections, a package and program for the software, distribution points, and deployments.

- **Collections** are groups of Configuration Manager resources, such as users, user groups, or computers, to which .NET Framework is deployed. For more information, see [Introduction to collections in Configuration Manager](/configmgr/core/clients/manage/collections/introduction-to-collections) in the Configuration Manager documentation library.

- **Packages and programs** typically represent software applications to be installed on a client computer, but they might also contain individual files, updates, or even individual commands. For more information, see [Packages and programs in Configuration Manager](/configmgr/apps/deploy-use/packages-and-programs) in the Configuration Manager documentation library.

- **Distribution points** are Configuration Manager site system roles that store files required for software to run on client computers. When the Configuration Manager client receives and processes a software deployment, it contacts a distribution point to download the content associated with the software and to start the installation process. For more information, see [Fundamental concepts for content management in Configuration Manager](/configmgr/core/plan-design/hierarchy/fundamental-concepts-for-content-management) in the Configuration Manager documentation library.

- **Deployments** instruct applicable members of the specified target collection to install the software package.

> [!IMPORTANT]
> The procedures in this topic contain typical settings for creating and deploying a package and program, and might not cover all possible settings. For other Configuration Manager deployment options, see the [Configuration Manager Documentation Library](/previous-versions/system-center/system-center-2012-R2/gg682041(v=technet.10)).

<a name="deploying_in_a_test_environment"></a>

## Deploying .NET Framework

You can use Configuration Manager to deploy a silent installation of .NET Framework 4.5, where the users do not interact with the installation process. Follow these steps:

1. [Create a collection](#creating_a_collection).

2. [Create a package and program for the .NET Framework redistributable](#creating_a_package).

3. [Select a distribution point](#select_dist_point).

4. [Deploy the package](#deploying_package).

<a name="creating_a_collection"></a>

### Create a collection

In this step, you select the computers to which you will deploy the package and program, and group them into a device collection. To create a collection in Configuration Manager, you can use direct membership rules (where you manually specify the collection members) or query rules (where Configuration Manager determines the collection members based on criteria you specify). For more information about membership rules, including queries and direct rules, see [Introduction to collections in Configuration Manager](/configmgr/core/clients/manage/collections/introduction-to-collections) in the Configuration Manager Documentation Library.

To create a collection:

1. In the Configuration Manager console, choose **Assets and Compliance**.

2. In the **Assets and Compliance** workspace, choose **Device Collections**.

3. On the **Home** tab in the **Create** group, choose **Create Device Collection**.

4. On the **General** page of the **Create Device Collection Wizard**, enter a name for the collection.

5. Choose **Browse** to specify a limiting collection.

6. On the **Membership Rules** page, choose **Add Rule**, and then choose **Direct Rule** to open the **Create Direct Membership Rule Wizard**. Choose **Next**.

7. On the **Search for Resources** page, in the **Resource class** list, choose **System Resource**. In the **Attribute name** list, choose **Name**. In the **Value** field, enter `%`, and then choose **Next**.

8. On the **Select Resources** page, select the check box for each computer that you want to deploy the .NET Framework to. Choose **Next**, and then complete the wizard.

9. On the **Membership Rules** page of the **Create Device Collection Wizard**, choose **Next**, and then complete the wizard.

<a name="creating_a_package"></a>

### Create a package and program for the .NET Framework redistributable package

The following steps create a package for the .NET Framework redistributable manually. The package contains the specified parameters for installing .NET Framework and the location from where the package will be distributed to the target computers.

To create a package:

1. In the Configuration Manager console, choose **Software Library**.

2. In the **Software Library** workspace, expand **Application Management**, and then choose **Packages**.

3. On the **Home** tab, in the **Create** group, choose **Create Package**.

4. On the **Package** page of the **Create Package and Program Wizard**, enter the following information:

    - Name: `.NET Framework 4.5`

    - Manufacturer: `Microsoft`

    - Language. `English (US)`

5. Choose **This package contains source files**, and then choose **Browse** to select the local or network folder that contains the .NET Framework installation files. When you have selected the folder, choose **OK**, and then choose **Next**.

6. On the **Program Type** page of the wizard, choose **Standard Program**, and then choose **Next**.

7. On the **Program** page of the **Create Package and Program Wizard**, enter the following information:

    1. **Name:** `.NET Framework 4.5`

    2. **Command line:** `dotNetFx45_Full_x86_x64.exe /q /norestart /ChainingPackage ADMINDEPLOYMENT` (command-line options are described in the table after these steps)

    3. **Run:** Choose **Hidden**.

    4. **Program can run:** Choose the option that specifies that the program can run regardless of whether a user is logged on.

8. On the **Requirements** page, choose **Next** to accept the default values, and then complete the wizard.

The following table describes the command-line options specified in step 7.

|Option|Description|
|------------|-----------------|
|**/q**|Sets quiet mode. No user input is required, and no output is shown.|
|**/norestart**|Prevents the Setup program from rebooting automatically. If you use this option, Configuration Manager must handle the computer restart.|
|**/chainingpackage** *PackageName*|Specifies the name of the package that is doing the chaining. This information is reported with other installation session information for those who have signed up for the Microsoft Customer Experience Improvement Program (CEIP). If the package name includes spaces, use double quotation marks as delimiters; for example: **/chainingpackage "Chaining Product"**.|

These steps create a package named .NET Framework 4.5. The program deploys a silent installation of .NET Framework 4.5. In a silent installation, users do not interact with the installation process, and the chaining application has to capture the return code and handle rebooting; see [Getting Progress Information from an Installation Package](/previous-versions/cc825975(v=vs.100)).

<a name="select_dist_point"></a>

### Select a distribution point

To distribute the package and program to client computers from a server, you must first designate a site system as a distribution point and then distribute the package to the distribution point.

Use the following steps to select a distribution point for the .NET Framework 4.5 package you created in the previous section:

1. In the Configuration Manager console, choose **Software Library**.

2. In the **Software Library** workspace, expand **Application Management**, and then choose **Packages**.

3. From the list of packages, select the package **.NET Framework 4.5** that you created in the previous section.

4. On the **Home** tab, in the **Deployment** group, choose **Distribute Content**.

5. On the **General** tab of the **Distribute Content Wizard**, choose **Next**.

6. On the **Content Destination** page of the wizard, choose **Add**, and then choose **Distribution Point**.

7. In the **Add Distribution Points** dialog box, select the distribution point(s) that will host the package and program, and then choose **OK**.

8. Complete the wizard.

The package now contains all the information you need to silently deploy .NET Framework 4.5. Before you deploy the package and program, verify that it was installed on the distribution point; see the "Content status monitoring" section of [Monitor content you distribute with Configuration Manager](/configmgr/core/servers/deploy/configure/monitor-content-you-have-distributed) in the Configuration Manager Documentation Library.

<a name="deploying_package"></a>

### Deploy the package

To deploy the .NET Framework 4.5 package and program:

1. In the Configuration Manager console, choose **Software Library**.

2. In the **Software Library** workspace, expand **Application Management**, and then choose **Packages**.

3. From the list of packages, select the package you created named **.NET Framework 4.5**.

4. On the **Home** tab, in the **Deployment** group, choose **Deploy**.

5. On the **General** page of the **Deploy Software Wizard**, choose **Browse**, and then select the collection that you created earlier. Choose **Next**.

6. On the **Content** page of the wizard, verify that the point from which you want to distribute the software is displayed, and then choose **Next**.

7. On the **Deployment Settings** page of the wizard, confirm that **Action** is set to **Install**, and **Purpose** is set to **Required**. This ensures that the software package will be a mandatory installation on the targeted computers. Choose **Next**.

8. On the **Scheduling** page of the wizard, specify when you want .NET Framework to be installed. You can choose **New** to assign an installation time, or instruct the software to install when the user logs on or off, or as soon as possible. Choose **Next**.

9. On the **User Experience** page of the wizard, use the default values and choose **Next**.

    > [!WARNING]
    > Your production environment might have policies that require different selections for the deployment schedule.

10. On the **Distribution Points** page of the wizard, use the default values and choose **Next**.

11. Complete the wizard. You can monitor the progress of the deployment in the **Deployments** node of the **Monitoring** workspace.

The package will now be deployed to the targeted collection and the silent installation of .NET Framework 4.5 will begin. For information about .NET Framework 4.5 installation error codes, see the [Return Codes](#return_codes) section later in this topic.

<a name="resources"></a>

## Resources

For more information about the infrastructure for testing the deployment of the .NET Framework 4.5 redistributable package, see the following resources.

**Active Directory, DNS, DHCP:**

- [Active Directory Domain Services](/windows/desktop/ad/active-directory-domain-services)

- [Domain Name System (DNS)](/windows-server/networking/dns/dns-top)

- [Dynamic Host Configuration Protocol (DHCP)](/windows-server/networking/technologies/dhcp/dhcp-top)

**SQL Server 2008:**

- [Installing SQL Server 2008 (SQL Server Video)](/previous-versions/sql/sql-server-2008/dd299415(v=sql.100))

- [SQL Server 2008 Security Overview for Database Administrators](https://download.microsoft.com/download/a/c/d/acd8e043-d69b-4f09-bc9e-4168b65aaa71/SQL2008SecurityOverviewforAdmins.docx)

**System Center 2012 Configuration Manager (Management Point, Distribution Point):**

- [Site Administration for System Center 2012 Configuration Manager](/previous-versions/system-center/system-center-2012-R2/gg681983(v=technet.10))

**System Center 2012 Configuration Manager client for Windows computers:**

- [Deploying Clients for System Center 2012 Configuration Manager](/previous-versions/system-center/system-center-2012-R2/gg699391(v=technet.10))

<a name="troubleshooting"></a>

## Troubleshooting

### Log file locations

The following log files are generated during .NET Framework setup:

- %temp%\Microsoft .NET Framework *version*\*.txt
- %temp%\Microsoft .NET Framework *version*\*.html

where *version* is the version of .NET Framework that you're installing, such as 4.5 or 4.7.2.

You can also specify the directory to which log files are written by using the `/log` command-line option in the .NET Framework installation command. For more information, see [.NET Framework deployment guide for developers](deployment-guide-for-developers.md#command-line-options).

You can use the [log collection tool](https://www.microsoft.com/download/details.aspx?id=12493) to collect the .NET Framework log files and to create a compressed cabinet (.cab) file that reduces the size of the files.

<a name="return_codes"></a>

### Return codes

The following table lists the most common return codes from the .NET Framework 4.5 redistributable installation program. The return codes are the same for all versions of the installer.

For links to detailed information, see the next section, [Download error codes](#additional_error_codes).

|Return code|Description|
|-----------------|-----------------|
|0|Installation completed successfully.|
|1602|The user canceled installation.|
|1603|A fatal error occurred during installation.|
|1641|A restart is required to complete the installation. This message indicates success.|
|3010|A restart is required to complete the installation. This message indicates success.|
|5100|The user's computer does not meet system requirements.|

<a name="additional_error_codes"></a>

### Download error codes

- [Background Intelligent Transfer Service (BITS) error codes](/windows/desktop/Bits/bits-return-values)

- [URL moniker error codes](/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775145(v=vs.85))

- [WinHttp error codes](/windows/desktop/WinHttp/error-messages)

Other error codes:

- [Windows Installer error codes](/windows/desktop/msi/error-codes)

- [Windows Update Agent result codes](/previous-versions/windows/it-pro/windows-server-2008-R2-and-2008/cc720442(v=ws.10))

## See also

- [Deployment Guide for Developers](deployment-guide-for-developers.md)
- [System Requirements](../get-started/system-requirements.md)
