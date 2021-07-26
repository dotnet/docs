---
title: "How to: Specify the Security Context for Services"
description: Specify the security context for services. Services run in the default system account context have other system resource access rights than the logged-in user.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "Windows Service applications, security"
  - "security [Visual Studio], contexts"
  - "contexts, Visual Studio security"
  - "security [Visual Studio], service applications"
  - "ServiceProcessInstaller class, security context"
  - "services, security"
  - "ServiceInstaller class, security context"
ms.assetid: 02187c7b-dbf2-45f2-96c2-e11010225a22
---
# How to: Specify the Security Context for Services

[!INCLUDE [windows-service-disambiguation](../../core/extensions/includes/windows-service-disambiguation.md)]

By default, services run in a different security context than that of the logged-in user. Services run in the context of the default system account, called `LocalSystem`, which gives them different access privileges to system resources than the user. You can change this behavior to specify a different user account under which your service should run.  
  
 You set the security context by manipulating the <xref:System.ServiceProcess.ServiceProcessInstaller.Account%2A> property for the process within which the service runs. This property allows you to set the service to one of four account types:  
  
- `User`, which causes the system to prompt for a valid user name and password when the service is installed and runs in the context of an account specified by a single user on the network;  
  
- `LocalService`, which runs in the context of an account that acts as a non-privileged user on the local computer, and presents anonymous credentials to any remote server;  
  
- `LocalSystem`, which runs in the context of an account that provides extensive local privileges, and presents the computer's credentials to any remote server;  
  
- `NetworkService`, which runs in the context of an account that acts as a non-privileged user on the local computer, and presents the computer's credentials to any remote server.  
  
 For more information, see the <xref:System.ServiceProcess.ServiceAccount> enumeration.  
  
### To specify the security context for a service  
  
1. After creating your service, add the necessary installers for it. For more information, see [How to: Add Installers to Your Service Application](how-to-add-installers-to-your-service-application.md).  
  
2. In the designer, access the `ProjectInstaller` class and click the service process installer for the service you are working with.  
  
    > [!NOTE]
    > For every service application, there are at least two installation components in the `ProjectInstaller` class — one that installs the processes for all services in the project, and one installer for each service the application contains. In this instance, you want to select <xref:System.ServiceProcess.ServiceProcessInstaller>.  
  
3. In the **Properties** window, set the <xref:System.ServiceProcess.ServiceProcessInstaller.Account%2A> to the appropriate value.  
  
## See also

- [Introduction to Windows Service Applications](introduction-to-windows-service-applications.md)
- [How to: Add Installers to Your Service Application](how-to-add-installers-to-your-service-application.md)
- [How to: Create Windows Services](how-to-create-windows-services.md)
