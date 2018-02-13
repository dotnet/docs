---
title: "Walkthrough: Using Client Application Services"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
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
  - "application services host [client application services]"
  - "client application services, walkthroughs"
ms.assetid: bb7c8950-4517-4dae-b705-b74a14059b26
caps.latest.revision: 47
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Walkthrough: Using Client Application Services
This topic describes how to create a Windows application that uses client application services to authenticate users and retrieve user roles and settings.  
  
 In this walkthrough, you perform the following tasks:  
  
-   Create a Windows Forms application and use the [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] project designer to enable and configure client application services.  
  
-   Create a simple ASP.NET Web Service application to host the application services and test your client configuration.  
  
-   Add forms authentication to your application. You will start by using a hard-coded user name and password to test the service. You will then add a login form by specifying it as a credentials provider in your application configuration.  
  
-   Add role-based functionality, enabling and displaying a button only for users in the "manager" role.  
  
-   Access Web settings. You will start by loading Web settings for an authenticated (test) user on the **Settings** page of the project designer. You will then use the Windows Forms Designer to bind a text box to a Web setting. Finally, you will save the modified value back to the server.  
  
-   Implement logout. You will add a logout option to the form and call a logout method.  
  
-   Enable offline mode. You will provide a check box so that users can specify their connection status. You will then use this value to specify whether the client application service providers will use locally cached data instead of accessing their Web services. Finally, you will re-authenticate the current user when the application returns to online mode.  
  
## Prerequisites  
 You need the following component to complete this walkthrough:  
  
-   [!INCLUDE[vs_orcas_long](../../../includes/vs-orcas-long-md.md)].  
  
## Creating the Client Application  
 The first thing that you will do is create a Windows Forms project. This walkthrough uses Windows Forms because more people are familiar with it, but the process is similar for Windows Presentation Foundation (WPF) projects.  
  
#### To create a client application and enable client application services  
  
1.  In [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)], select the **File &#124; New &#124; Project** menu option.  
  
2.  In the **New Project** dialog box, in the **Project types** pane, expand the **Visual Basic** or **Visual C#** node and select the **Windows** project type.  
  
3.  Make sure that **.NET Framework 3.5** is selected, and then select the **Windows Forms Application** template.  
  
4.  Change the project **Name** to `ClientAppServicesDemo`, and then click **OK**.  
  
     A new Windows Forms project is opened in [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)].  
  
5.  On the **Project** menu, select **ClientAppServicesDemo Properties**.  
  
     The project designer appears.  
  
6.  On the **Services** tab, select **Enable client application services**.  
  
7.  Make sure that **Use Forms authentication** is selected, and then set **Authentication service location**, **Roles service location**, and **Web settings service location** to `http://localhost:55555/AppServices`.  
  
8.  For [!INCLUDE[vbprvb](../../../includes/vbprvb-md.md)], on the **Application** tab, set **Authentication mode** to **Application-defined**.  
  
 The designer stores the specified settings in the application's app.config file.  
  
 At this point, the application is configured to access all three services from the same host. In the next section, you will create the host as a simple Web service application, enabling you to test your client configuration.  
  
## Creating the Application Services Host  
 In this section, you will create a simple Web service application that accesses user data from a local SQL Server Compact database file. Then, you will populate the database using the [ASP.NET Web Site Administration Tool](http://msdn.microsoft.com/library/100ddd8b-7d11-4df9-91ef-0bbbe92e5aec). This simple configuration enables you to quickly test your client application. As an alternative, you can configure the Web service host to access user data from a full SQL Server database or through custom <xref:System.Web.Security.MembershipProvider> and <xref:System.Web.Security.RoleProvider> classes. For more information, see [Creating and Configuring the Application Services Database for SQL Server](http://msdn.microsoft.com/library/ab894e83-7e2f-4af8-a116-b1bff8f815b2).  
  
 In the following procedure, you create and configure the AppServices Web service.  
  
#### To create and configure the application services host  
  
1.  In **Solution Explorer**, select the ClientAppServicesDemo solution, and then on the **File** menu, select **Add &#124; New Project**.  
  
2.  In the **Add New Project** dialog box, in the **Project types** pane, expand the **Visual Basic** or **Visual C#** node and select the **Web** project type.  
  
3.  Make sure that **.NET Framework 3.5** is selected, and then select the **ASP.NET Web Service Application** template.  
  
4.  Change the project **Name** to `AppServices` and then click **OK**.  
  
     A new ASP.NET Web service application project is added to the solution, and the Service1.asmx.vb or Service1.asmx.cs file appears in the editor.  
  
    > [!NOTE]
    >  The Service1.asmx.vb or Service1.asmx.cs file is not used in this example. If you want to keep your work environment uncluttered, you can close it and delete it from **Solution Explorer**.  
  
5.  In **Solution Explorer**, select the AppServices project, and then on the **Project** menu, select **AppServices Properties**.  
  
     The project designer appears.  
  
6.  On the **Web** tab, make sure that **Use Visual Studio Development Server** is selected.  
  
7.  Select **Specific port**, specify a value of `55555`, and then set **Virtual path** to `/AppServices`.  
  
8.  Save all files.  
  
9. In **Solution Explorer**, open Web.config and find the `<system.web>` opening tag.  
  
10. Add the following markup before the `<system.web>` tag.  
  
     The `authenticationService`, `profileService`, and `roleService` elements in this markup enable and configure the application services. For testing purposes, the `requireSSL` attribute of the `authenticationService` element is set to "false". The `readAccessProperties` and `writeAccessProperties` attributes of the `profileService` element indicate that the `WebSettingsTestText` property is read/write.  
  
    > [!NOTE]
    >  In production code, you should always access the authentication service over the secure sockets layer (SSL, by using the HTTPS protocol). For information about how to set up SSL, see [Configuring Secure Sockets Layer (IIS 6.0 Operations Guide)](http://go.microsoft.com/fwlink/?LinkId=91844).  
  
    ```xml  
    <system.web.extensions>  
      <scripting>  
        <webServices>  
          <authenticationService enabled="true" requireSSL = "false"/>  
          <profileService enabled="true"  
            readAccessProperties="WebSettingsTestText"  
            writeAccessProperties="WebSettingsTestText" />  
          <roleService enabled="true"/>  
        </webServices>  
      </scripting>  
    </system.web.extensions>  
    ```  
  
11. Add the following markup after the `<system.web>` opening tag so that it is within the `<system.web>` element.  
  
     The `profile` element configures a single Web setting named `WebSettingsTestText`.  
  
    ```xml  
    <profile enabled="true" >  
      <properties>  
        <add name="WebSettingsTestText" type="string"   
          readOnly="false" defaultValue="DefaultText"   
          serializeAs="String" allowAnonymous="false" />  
      </properties>  
    </profile>  
    ```  
  
 In the following procedure, you use the ASP.NET Web Site Administration tool to complete the service configuration and populate the local database file. You will add two users named `employee` and `manager` belonging to two roles with the same names. The user passwords are `employee!` and `manager!` respectively.  
  
#### To configure membership and roles  
  
1.  In **Solution Explorer**, select the AppServices project, and then on the **Project** menu, select **ASP.NET Configuration**.  
  
     The **ASP.NET Web Site Administration Tool** appears.  
  
2.  On the **Security** tab, click **Use the security Setup Wizard to configure security step by step**.  
  
     The **Security Setup Wizard** appears and displays the **Welcome** step.  
  
3.  Click **Next**.  
  
     The **Select Access Method** step appears.  
  
4.  Select **From the internet**. This configures the service to use Forms authentication instead of Windows authentication.  
  
5.  Click **Next** twice.  
  
     The **Define Roles** step appears.  
  
6.  Select **Enable roles for this Web site**.  
  
7.  Click **Next**. The **Create New Role** form appears.  
  
8.  In the **New Role Name** text box, type `manager` and then click **Add Role**.  
  
     The **Existing Roles** table appears with the specified value.  
  
9. In the **New Role Name** text box, replace `manager` with `employee` and then click **Add Role**.  
  
     The new value appears in the **Existing Roles** table.  
  
10. Click **Next**.  
  
     The **Add New Users** step appears.  
  
11. In the **Create User** form, specify the following values.  
  
    |||  
    |-|-|  
    |**User Name**|`manager`|  
    |**Password**|`manager!`|  
    |**Confirm Password**|`manager!`|  
    |**Email**|`manager@contoso.com`|  
    |**Security Question**|`manager`|  
    |**Security Answer**|`manager`|  
  
12. Click **Create User**.  
  
     A success message appears.  
  
    > [!NOTE]
    >  The **Email**, **Security Question**, and **Security Answer** values are required by the form, but are not used in this example.  
  
13. Click **Continue**.  
  
     The **Create User** form reappears.  
  
14. In the **Create User** form, specify the following values.  
  
    |||  
    |-|-|  
    |**User Name**|`employee`|  
    |**Password**|`employee!`|  
    |**Confirm Password**|`employee!`|  
    |**Email**|`employee@contoso.com`|  
    |**Security Question**|`Employee`|  
    |**Security Answer**|`employee`|  
  
15. Click **Create User**.  
  
     A success message appears.  
  
16. Click **Finish**.  
  
     The **Web Site Administration Tool** reappears.  
  
17. Click **Manager users**.  
  
     The list of users appears.  
  
18. Click **Edit roles** for the **employee** user, and then select the **employee** role.  
  
19. Click **Edit roles** for the **manager** user, and then select the **manager** role.  
  
20. Close the browser window that hosts the **Web Site Administration Tool**.  
  
21. If a message box appears asking if you want to reload the modified Web.config file, click **Yes**.  
  
 This completes the Web service setup. At this point, you can press F5 to run the client application, and the **ASP.NET Development Server** will start automatically along with your client application. The server will continue to run after you exit the application, but will restart when you restart the application. This allows it to detect any changes you have made to Web.config.  
  
 To stop the server manually, right-click the ASP.NET Development Server icon in the notification area of the taskbar and then click **Stop**. This is useful occasionally to make sure that a clean restart occurs.  
  
## Adding Forms Authentication  
 In the following procedure, you add code to the main form that attempts to validate the user, and denies access when the user supplies invalid credentials. You use a hard-coded user name and password to test the service.  
  
#### To validate the user in your application code  
  
1.  In **Solution Explorer**, in the ClientAppServicesDemo project, add a reference to the System.Web assembly.  
  
2.  Select the Form1 file and then select **View &#124; Code** from the [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] main menu.  
  
3.  In the code editor, add the following statements to the top of the Form1 file.  
  
     [!code-csharp[ClientApplicationServices#001](../../../samples/snippets/csharp/VS_Snippets_Winforms/ClientApplicationServices/CS/Form1.cs#001)]
     [!code-vb[ClientApplicationServices#001](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/ClientApplicationServices/VB/Form1.vb#001)]  
  
4.  In **Solution Explorer**, double-click Form1 to display the designer.  
  
5.  In the designer, double-click the form surface to generate a <xref:System.Windows.Forms.Form.Load?displayProperty=nameWithType> event handler named `Form1_Load`.  
  
     The code editor appears with the cursor in the `Form1_Load` method.  
  
6.  Add the following code to the `Form1_Load` method.  
  
     This code denies access to unauthenticated users by exiting the application. Alternatively, you could allow unauthenticated users access to the form, but deny access to specific functionality. Normally, you will not hard-code the user name and password like this, but it is useful for testing purposes. In the next section, you will replace this code with more robust code that displays a login dialog box and includes exception handling.  
  
     Note that the `static` <xref:System.Web.Security.Membership.ValidateUser%2A?displayProperty=nameWithType> method is in the [!INCLUDE[dnprdnext](../../../includes/dnprdnext-md.md)]. This method delegates its work to the configured authentication provider, and returns `true` if authentication is successful. Your application does not require a direct reference to the client authentication provider.  
  
     [!code-csharp[ClientApplicationServices#300](../../../samples/snippets/csharp/VS_Snippets_Winforms/ClientApplicationServices/CS/Class1.cs#300)]
     [!code-vb[ClientApplicationServices#300](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/ClientApplicationServices/VB/Class1.vb#300)]  
  
 You can now press F5 to run the application, and because you provide a correct user name and password, you will see the form.  
  
> [!NOTE]
>  If you are unable to run the application, try stopping the ASP.NET Development Server. When the server restarts, verify that the port is set to 55555.  
  
 To see the error message instead, change the <xref:System.Web.Security.Membership.ValidateUser%2A> parameters. For example, replace the second `"manager!"` parameter with an incorrect password like `"MANAGER"`.  
  
## Adding a Login Form as a Credentials Provider  
 You can acquire the user credentials in your application code and pass them to the <xref:System.Web.Security.Membership.ValidateUser%2A> method. However, it is often useful to keep your credentials-acquiring code separate from your application code, in case you want to change it later.  
  
 In the following procedure, you configure your application to use a credentials provider, and then change your <xref:System.Web.Security.Membership.ValidateUser%2A> method call to pass <xref:System.String.Empty> for both parameters. The empty strings signal the <xref:System.Web.Security.Membership.ValidateUser%2A> method to call the <xref:System.Web.ClientServices.Providers.IClientFormsAuthenticationCredentialsProvider.GetCredentials%2A> method of the configured credentials provider.  
  
#### To configure your application to use a credentials provider  
  
1.  In **Solution Explorer**, select the ClientAppServicesDemo project, and then on the **Project** menu, select **ClientAppServicesDemo Properties**.  
  
     The project designer appears.  
  
2.  On the **Services** tab, set **Optional: Credential provider** to the following value. This value indicates the assembly-qualified type name.  
  
    ```  
    ClientAppServicesDemo.Login, ClientAppServicesDemo  
    ```  
  
3.  In the Form1 code file, replace the code in the `Form1_Load` method with the following code.  
  
     This code displays a welcome message and then calls the `ValidateUsingCredentialsProvider` method that you will add in the next step. If the user is not authenticated, the `ValidateUsingCredentialsProvider` method returns `false` and the `Form1_Load` method returns. This prevents any additional code from running before the application exits. The welcome message is useful to make it clear when the application restarts. You will add code to restart the application when you implement logout later in this walkthrough.  
  
     [!code-csharp[ClientApplicationServices#011](../../../samples/snippets/csharp/VS_Snippets_Winforms/ClientApplicationServices/CS/Form1.cs#011)]
     [!code-vb[ClientApplicationServices#011](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/ClientApplicationServices/VB/Form1.vb#011)]  
  
4.  Add the following method after the `Form1_Load` method.  
  
     This method passes empty strings to the `static` <xref:System.Web.Security.Membership.ValidateUser%2A?displayProperty=nameWithType> method, which causes the Login dialog box to appear. If the authentication service is unavailable, the <xref:System.Web.Security.Membership.ValidateUser%2A> method will throw a <xref:System.Net.WebException>. In this case, the `ValidateUsingCredentialsProvider` method displays a warning message and asks if the user wants to try again in offline mode. This functionality requires the **Save password hash locally to enable offline login** feature described in [How to: Configure Client Application Services](../../../docs/framework/common-client-technologies/how-to-configure-client-application-services.md). This feature is enabled by default for new projects.  
  
     If the user is not validated, the `ValidateUsingCredentialsProvider` method displays an error message and exits the application. Finally, this method returns the result of the authentication attempt.  
  
     [!code-csharp[ClientApplicationServices#020](../../../samples/snippets/csharp/VS_Snippets_Winforms/ClientApplicationServices/CS/Form1.cs#020)]
     [!code-vb[ClientApplicationServices#020](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/ClientApplicationServices/VB/Form1.vb#020)]  
  
### Creating a Login Form  
 A credentials provider is a class that implements the <xref:System.Web.ClientServices.Providers.IClientFormsAuthenticationCredentialsProvider> interface. This interface has a single method named <xref:System.Web.ClientServices.Providers.IClientFormsAuthenticationCredentialsProvider.GetCredentials%2A> that returns a <xref:System.Web.ClientServices.Providers.ClientFormsAuthenticationCredentials> object. The following procedures describe how to create a login dialog box that implements <xref:System.Web.ClientServices.Providers.IClientFormsAuthenticationCredentialsProvider.GetCredentials%2A> to display itself and return the user-specified credentials.  
  
 Separate procedures are provided for [!INCLUDE[vbprvb](../../../includes/vbprvb-md.md)] and C# because [!INCLUDE[vbprvb](../../../includes/vbprvb-md.md)] provides a **Login Form** template. This saves some time and coding effort.  
  
##### To create a login dialog box as a credentials provider in Visual Basic  
  
1.  In **Solution Explorer**, select the ClientAppServicesDemo project, and then on the **Project** menu, select **Add New Item**.  
  
2.  In the **Add New Item** dialog box, select the **Login Form** template, change the item **Name** to `Login.vb`, and then click **Add**.  
  
     The login dialog box appears in the Windows Forms Designer.  
  
3.  In the designer, select the **OK** button and then, in the **Properties** window, set `DialogResult` to `OK`.  
  
4.  In the designer, add a `CheckBox` control to the form under the **Password** text box.  
  
5.  In the **Properties** window, specify a **(Name)** value of `rememberMeCheckBox` and a **Text** value of `&Remember me`.  
  
6.  Select **View &#124; Code** from the [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] main menu.  
  
7.  In the code editor, add the following code to the top of the file.  
  
     [!code-vb[ClientApplicationServices#101](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/ClientApplicationServices/VB/Login.vb#101)]  
  
8.  Modify the class signature so that the class implements the <xref:System.Web.ClientServices.Providers.IClientFormsAuthenticationCredentialsProvider> interface.  
  
     [!code-vb[ClientApplicationServices#110](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/ClientApplicationServices/VB/Class1.vb#110)]  
  
9. Make sure that the cursor is after `IClientformsAuthenticationCredentialsProvider`, and then press ENTER to generate the `GetCredentials` method.  
  
10. Locate the <xref:System.Web.ClientServices.Providers.IClientFormsAuthenticationCredentialsProvider.GetCredentials%2A> implementation and then replace it with the following code.  
  
     [!code-vb[ClientApplicationServices#120](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/ClientApplicationServices/VB/Login.vb#120)]  
  
 The following C# procedure provides the entire code listing for a simple login dialog box. The layout for this dialog box is a bit crude, but the important part is the <xref:System.Web.ClientServices.Providers.IClientFormsAuthenticationCredentialsProvider.GetCredentials%2A> implementation.  
  
##### To create a login dialog box as a credentials provider in C#  
  
1.  In **Solution Explorer**, select the ClientAppServicesDemo project, and then on the **Project** menu, select **Add Class**.  
  
2.  In the **Add New Item** dialog box, change the **Name** to `Login.cs`, and then click **Add**.  
  
     The Login.cs file opens in the code editor.  
  
3.  Replace the default code with the following code.  
  
     [!code-csharp[ClientApplicationServices#200](../../../samples/snippets/csharp/VS_Snippets_Winforms/ClientApplicationServices/CS/Login.cs#200)]  
  
 You can now run the application and see the login dialog box appear. To test this code, try different credentials, both valid and invalid, and confirm that you can access the form only with valid credentials. Valid user names are `employee` and `manager` with passwords `employee!` and `manager!` respectively.  
  
> [!NOTE]
>  Do not select **Remember me** at this point or you will not be able to login as another user until you implement logout later in this walkthrough.  
  
## Adding Role-Based Functionality  
 In the following procedure, you add a button to the form and display it only for users in the manager role.  
  
#### To change the user interface based on user role  
  
1.  In **Solution Explorer**, in the ClientAppServicesDemo project, select Form1 and then select **View &#124; Designer** from the [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] main menu.  
  
2.  In the designer, add a <xref:System.Windows.Forms.Button> control to the form from the **ToolBox**.  
  
3.  In the **Properties** window, set the following properties for the button.  
  
    |Property|Value|  
    |--------------|-----------|  
    |**(Name)**|managerOnlyButton|  
    |**Text**|&Manager task|  
    |**Visible**|`False`|  
  
4.  In the code editor for Form1, add the following code to the end of the `Form1_Load` method.  
  
     This code calls the `DisplayButtonForManagerRole` method that you will add in the next step.  
  
     [!code-csharp[ClientApplicationServices#012](../../../samples/snippets/csharp/VS_Snippets_Winforms/ClientApplicationServices/CS/Form1.cs#012)]
     [!code-vb[ClientApplicationServices#012](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/ClientApplicationServices/VB/Form1.vb#012)]  
  
5.  Add the following method to the end of the Form1 class.  
  
     This method calls the <xref:System.Security.Principal.IPrincipal.IsInRole%2A> method of the <xref:System.Security.Principal.IPrincipal> returned by the `static` <xref:System.Threading.Thread.CurrentPrincipal%2A?displayProperty=nameWithType> property. For applications configured to use client application services, this property returns a <xref:System.Web.ClientServices.ClientRolePrincipal>. Because this class implements the <xref:System.Security.Principal.IPrincipal> interface, you do not need to reference it explicitly.  
  
     If the user is in the "manager" role, the `DisplayButtonForManagerRole` method sets the <xref:System.Windows.Forms.Control.Visible%2A> property of the `managerOnlyButton` to `true`. This method also displays an error message if a <xref:System.Net.WebException> is thrown, which indicates that the roles service is unavailable.  
  
    > [!NOTE]
    >  The <xref:System.Web.ClientServices.ClientRolePrincipal.IsInRole%2A> method will always return `false` if the user login has expired. This will not occur if your application calls the <xref:System.Security.Principal.IPrincipal.IsInRole%2A> method one time shortly after authentication, as shown in the example code for this walkthrough. If your application must retrieve user roles at other times, you might want to add code to revalidate users whose login has expired. If all valid users are assigned to roles, you can determine whether the login has expired by calling the <xref:System.Web.ClientServices.Providers.ClientRoleProvider.GetRolesForUser%2A?displayProperty=nameWithType> method. If no roles are returned, the login has expired. For an example of this functionality, see the <xref:System.Web.ClientServices.Providers.ClientRoleProvider.GetRolesForUser%2A> method. This functionality is only necessary if you have selected **Require users to log on again whenever the server cookie expires** in your application configuration. For more information, see [How to: Configure Client Application Services](../../../docs/framework/common-client-technologies/how-to-configure-client-application-services.md).  
  
     [!code-csharp[ClientApplicationServices#030](../../../samples/snippets/csharp/VS_Snippets_Winforms/ClientApplicationServices/CS/Form1.cs#030)]
     [!code-vb[ClientApplicationServices#030](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/ClientApplicationServices/VB/Form1.vb#030)]  
  
 If authentication is successful, the client authentication provider sets the <xref:System.Threading.Thread.CurrentPrincipal%2A?displayProperty=nameWithType> property to an instance of the <xref:System.Web.ClientServices.ClientRolePrincipal> class. This class implements the <xref:System.Security.Principal.IPrincipal.IsInRole%2A> method so that the work is delegated to the configured role provider. As before, your application code does not require a direct reference to the service provider.  
  
 You can now run the application and log in as employee to see that the button does not appear, and then log in as manager to see the button.  
  
## Accessing Web Settings  
 In the following procedure, you add a text box to the form and bind it to a Web setting. Like the previous code that uses authentication and roles, your settings code does not access the settings provider directly. Instead, it uses the strongly-typed `Settings` class (accessed as `Properties.Settings.Default` in C# and `My.Settings` in [!INCLUDE[vbprvb](../../../includes/vbprvb-md.md)]) generated for your project by [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)].  
  
#### To use Web settings in your user interface  
  
1.  Make sure that the **ASP.NET Web Development Server** is still running by checking the notification area of the taskbar. If you have stopped the server, restart the application (which starts the server automatically) then close the login dialog box.  
  
2.  In **Solution Explorer**, select the ClientAppServicesDemo project, and then on the **Project** menu, select **ClientAppServicesDemo Properties**.  
  
     The project designer appears.  
  
3.  On the **Settings** tab, click **Load Web Settings**.  
  
     A **Login** dialog box appears.  
  
4.  Enter credentials for employee or manager and click **Log In**. The Web setting you will use is configured for access by authenticated users only, so clicking **Skip Login** will not load any settings.  
  
     The `WebSettingsTestText` setting appears in the designer with the default value of `DefaultText`. Additionally, a `Settings` class that contains a `WebSettingsTestText` property is generated for your project.  
  
5.  In **Solution Explorer**, in the ClientAppServicesDemo project, select Form1 and then select **View &#124; Designer** from the [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] main menu.  
  
6.  In the designer, add a <xref:System.Windows.Forms.TextBox> control to the form.  
  
7.  In the **Properties** window, specify a **(Name)** value of `webSettingsTestTextBox`.  
  
8.  In the code editor, add the following code to the end of the `Form1_Load` method.  
  
     This code calls the `BindWebSettingsTestTextBox` method that you will add in the next step.  
  
     [!code-csharp[ClientApplicationServices#013](../../../samples/snippets/csharp/VS_Snippets_Winforms/ClientApplicationServices/CS/Form1.cs#013)]
     [!code-vb[ClientApplicationServices#013](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/ClientApplicationServices/VB/Form1.vb#013)]  
  
9. Add the following method to the end of the Form1 class.  
  
     This method binds the <xref:System.Windows.Forms.TextBox.Text%2A> property of the `webSettingsTestTextBox` to the `WebSettingsTestText` property of the `Settings` class generated earlier in this procedure. This method also displays an error message if a <xref:System.Net.WebException> is thrown, which indicates that the Web settings service is unavailable.  
  
     [!code-csharp[ClientApplicationServices#040](../../../samples/snippets/csharp/VS_Snippets_Winforms/ClientApplicationServices/CS/Form1.cs#040)]
     [!code-vb[ClientApplicationServices#040](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/ClientApplicationServices/VB/Form1.vb#040)]  
  
    > [!NOTE]
    >  You will typically use data binding to enable automatic two-way communication between a control and a Web setting. However, you can also access Web settings directly as shown in the following example:  
  
     [!code-csharp[ClientApplicationServices#322](../../../samples/snippets/csharp/VS_Snippets_Winforms/ClientApplicationServices/CS/Class1.cs#322)]
     [!code-vb[ClientApplicationServices#322](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/ClientApplicationServices/VB/Class1.vb#322)]  
  
10. In the designer, select the form, and then, in the **Properties** window, click the **Events** button.  
  
11. Select the <xref:System.Windows.Forms.Form.FormClosing> event and then press ENTER to generate an event handler.  
  
12. Replace the generated method with the following code.  
  
     The <xref:System.Windows.Forms.Form.FormClosing> event handler calls the `SaveSettings` method, which is also used by the logout functionality that you will add in the next section. The `SaveSettings` method first confirms that the user has not logged out. It does this by checking the <xref:System.Security.Principal.IIdentity.AuthenticationType%2A> property of the <xref:System.Security.Principal.IIdentity> returned by the current principal. The current principal is retrieved through the `static` <xref:System.Threading.Thread.CurrentPrincipal%2A> property. If the user has been authenticated for client application services, the authentication type will be "ClientForms". The `SaveSettings` method cannot just check the <xref:System.Security.Principal.IIdentity.IsAuthenticated%2A?displayProperty=nameWithType> property because the user might have a valid Windows identity after logout.  
  
     If the user has not logged out, the `SaveSettings` method calls the <xref:System.Configuration.ApplicationSettingsBase.Save%2A> method of the `Settings` class generated earlier in this procedure. This method can throw a <xref:System.Net.WebException> if the authentication cookie has expired. This occurs only if you have selected **Require users to log on again whenever the server cookie expires** in your application configuration. For more information, see [How to: Configure Client Application Services](../../../docs/framework/common-client-technologies/how-to-configure-client-application-services.md). The `SaveSettings` method handles cookie expiration by calling <xref:System.Web.Security.Membership.ValidateUser%2A> to display the login dialog box. If the user logs in successfully, the `SaveSettings` method tries to save the settings again by calling itself.  
  
     Like in previous code, the `SaveSettings` method displays an error message if the remote service is unavailable. If the settings provider cannot access the remote service, the settings are still saved to the local cache and reloaded when the application restarts.  
  
     [!code-csharp[ClientApplicationServices#050](../../../samples/snippets/csharp/VS_Snippets_Winforms/ClientApplicationServices/CS/Form1.cs#050)]
     [!code-vb[ClientApplicationServices#050](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/ClientApplicationServices/VB/Form1.vb#050)]  
  
13. Add the following method to the end of the Form1 class.  
  
     This code handles the <xref:System.Web.ClientServices.Providers.ClientSettingsProvider.SettingsSaved?displayProperty=nameWithType> event and displays a warning if any of the settings could not be saved. The <xref:System.Web.ClientServices.Providers.ClientSettingsProvider.SettingsSaved> event does not occur if the settings service is unavailable or if the authentication cookie has expired. One example of when the <xref:System.Web.ClientServices.Providers.ClientSettingsProvider.SettingsSaved> event will occur is if the user has already logged out. You can test this event handler by adding logout code to the `SaveSettings` method directly before the <xref:System.Configuration.ApplicationSettingsBase.Save%2A> method call. Logout code that you can use is described in the next section.  
  
     [!code-csharp[ClientApplicationServices#090](../../../samples/snippets/csharp/VS_Snippets_Winforms/ClientApplicationServices/CS/Form1.cs#090)]
     [!code-vb[ClientApplicationServices#090](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/ClientApplicationServices/VB/Form1.vb#090)]  
  
14. For C#, add the following code to the end of the `Form1_Load` method. This code associates the method you added in the last step with the <xref:System.Web.ClientServices.Providers.ClientSettingsProvider.SettingsSaved> event.  
  
     [!code-csharp[ClientApplicationServices#015](../../../samples/snippets/csharp/VS_Snippets_Winforms/ClientApplicationServices/CS/Form1.cs#015)]  
  
 To test the application at this point, run it multiple times as both employee and manager, and type different values into the text box. The values will persist across sessions on a per-user basis.  
  
## Implementing Logout  
 When the user selects the **Remember me** check box when logging in, the application will automatically authenticate the user on subsequent runs. Automatic authentication will then continue while the application is in offline mode or until the authentication cookie expires. Sometimes, however, multiple users will need access to the application or a single user might occasionally log in with different credentials. To enable this scenario, you must implement logout functionality, as described in the following procedure.  
  
#### To implement logout functionality  
  
1.  In the Form1 designer, add a <xref:System.Windows.Forms.Button> control to the form from the **ToolBox**.  
  
2.  In the **Properties** window, specify a **(Name)** value of `logoutButton` and a **Text** value of **&Log Out**.  
  
3.  Double-click the `logoutButton` to generate a <xref:System.Windows.Forms.Control.Click> event handler.  
  
     The code editor appears with the cursor in the `logoutButton_Click` method.  
  
4.  Replace the generated `logoutButton_Click` method with the following code.  
  
     This event handler first calls the `SaveSettings` method that you added in the previous section. Then, the event handler calls the <xref:System.Web.ClientServices.Providers.ClientFormsAuthenticationMembershipProvider.Logout%2A?displayProperty=nameWithType> method. If the authentication service is unavailable, the <xref:System.Web.ClientServices.Providers.ClientFormsAuthenticationMembershipProvider.Logout%2A> method will throw a <xref:System.Net.WebException>. In this case, the `logoutButton_Click` method displays a warning message and switches temporarily to offline mode to log the user out. Offline mode is described in the next section.  
  
     Logout deletes the local authentication cookie so that login will be required when the application is restarted. After logout, the event handler restarts the application. When the application restarts, it displays the welcome message followed by the login dialog box. The welcome message makes it clear that the application has restarted. This prevents potential confusion if the user must log in to save settings, and then must log in again because the application has restarted.  
  
     [!code-csharp[ClientApplicationServices#070](../../../samples/snippets/csharp/VS_Snippets_Winforms/ClientApplicationServices/CS/Form1.cs#070)]
     [!code-vb[ClientApplicationServices#070](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/ClientApplicationServices/VB/Form1.vb#070)]  
  
 To test the logout functionality, run the application and select **Remember me** on the Login dialog box. Next, close and restart the application to confirm that you no longer have to log in. Finally, restart the application by clicking Log out.  
  
## Enabling Offline Mode  
 In the following procedure, you add a check box to the form to enable the user to enter offline mode. Your application indicates offline mode by setting the `static` <xref:System.Web.ClientServices.ConnectivityStatus.IsOffline%2A?displayProperty=nameWithType> property to `true`. The offline status is stored on the local hard disk at the location indicated by the <xref:System.Windows.Forms.Application.UserAppDataPath%2A?displayProperty=nameWithType> property. This means that the offline status is stored on a per-user, per-application basis.  
  
 In offline mode, all client application service requests retrieve data from the local cache instead of trying to access the services. In the default configuration, the local data includes an encrypted form of the user's password. This enables the user to log in while the application is in offline mode. For more information, see [How to: Configure Client Application Services](../../../docs/framework/common-client-technologies/how-to-configure-client-application-services.md).  
  
#### To enable offline mode in your application  
  
1.  In **Solution Explorer**, in the ClientAppServicesDemo project, select Form1 and then select **View &#124; Designer** from the [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] main menu.  
  
2.  In the designer, add a <xref:System.Windows.Forms.CheckBox> control to the form.  
  
3.  In the **Properties** window, specify a **(Name)** value of `workOfflineCheckBox` and a **Text** value of **&Work offline**.  
  
4.  In the **Properties** window, click the **Events** button.  
  
5.  Select the <xref:System.Windows.Forms.CheckBox.CheckedChanged> event and then press ENTER to generate an event handler.  
  
6.  Replace the generated method with the following code.  
  
     This code updates the <xref:System.Web.ClientServices.ConnectivityStatus.IsOffline%2A> value and silently revalidates the user when they return to online mode. The <xref:System.Web.ClientServices.ClientFormsIdentity.RevalidateUser%2A?displayProperty=nameWithType> method uses the cached credentials so that the user does not have to explicitly log in. If the authentication service is unavailable, a warning message appears and the application stays offline.  
  
    > [!NOTE]
    >  The <xref:System.Web.ClientServices.ClientFormsIdentity.RevalidateUser%2A> method is for convenience only. Because it does not have a return value, it cannot indicate whether revalidation has failed. Revalidation can fail, for example, if the user credentials have changed on the server. In this case, you might want to include code that explicitly validates users after a service call fails. For more information, see the Accessing Web Settings section earlier in this walkthrough.  
  
     After revalidation, this code saves any changes to the local Web settings by calling the `SaveSettings` method that you added previously. It then retrieves any new values on the server by calling the <xref:System.Configuration.ApplicationSettingsBase.Reload%2A> method of the project's `Settings` class (accessed as `Properties.Settings.Default` in C# and `My.Settings` in [!INCLUDE[vbprvb](../../../includes/vbprvb-md.md)]).  
  
     [!code-csharp[ClientApplicationServices#080](../../../samples/snippets/csharp/VS_Snippets_Winforms/ClientApplicationServices/CS/Form1.cs#080)]
     [!code-vb[ClientApplicationServices#080](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/ClientApplicationServices/VB/Form1.vb#080)]  
  
7.  Add the following code to the end of the `Form1_Load` method to make sure that the check box displays the current connection state.  
  
     [!code-csharp[ClientApplicationServices#014](../../../samples/snippets/csharp/VS_Snippets_Winforms/ClientApplicationServices/CS/Form1.cs#014)]
     [!code-vb[ClientApplicationServices#014](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/ClientApplicationServices/VB/Form1.vb#014)]  
  
 This completes the example application. To test the offline capability, run the application, log in as either employee or manager, and then select **Work offline**. Modify the value in the text box, and then close the application. Restart the application. Before you log in, right-click the ASP.NET Development Server icon in the notification area of the taskbar and then click **Stop**. Then, log in like normal. Even when the server is not running, you can still log in. Modify the text box value, exit, and restart to see the modified value.  
  
## Summary  
 In this walkthrough, you learned how to enable and use client application services in a Windows Forms application. After setting up a test server, you added code to your application to authenticate users and retrieve user roles and application settings from the server. You also learned how to enable offline mode so that your application uses a local data cache instead of the remote services when connectivity is not available.  
  
## Next Steps  
 In a real-world application, you will access data for many users from a remote server that may not always be available, or may go down without notice. To make your application robust, you must respond appropriately to situations where the service is not available. This walkthrough includes try/catch blocks to catch a <xref:System.Net.WebException> and display an error message when the service is not available. In production code, you might want to handle this case by switching to offline mode, exiting the application, or denying access to specific functionality.  
  
 To increase the security of your application, make sure to thoroughly test the application and server before deployment.  
  
## See Also  
 [Client Application Services](../../../docs/framework/common-client-technologies/client-application-services.md)  
 [Client Application Services Overview](../../../docs/framework/common-client-technologies/client-application-services-overview.md)  
 [How to: Configure Client Application Services](../../../docs/framework/common-client-technologies/how-to-configure-client-application-services.md)  
 [ASP.NET Web Site Administration Tool](http://msdn.microsoft.com/library/100ddd8b-7d11-4df9-91ef-0bbbe92e5aec)  
 [Creating and Configuring the Application Services Database for SQL Server](http://msdn.microsoft.com/library/ab894e83-7e2f-4af8-a116-b1bff8f815b2)  
 [Walkthrough: Using ASP.NET Application Services](http://msdn.microsoft.com/library/f3f394f0-20d6-4361-aa8f-4b21bf4933eb)
