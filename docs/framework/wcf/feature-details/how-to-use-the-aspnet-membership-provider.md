---
title: "How to: Use the ASP.NET Membership Provider"
description: Learn how the ASP.NET membership provider supports websites that let users create a user name and password for access without having a Windows domain account.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "WCF and ASP.NET"
  - "WCF, authorization"
  - "WCF, security"
ms.assetid: 322c56e0-938f-4f19-a981-7b6530045b90
---
# How to: Use the ASP.NET Membership Provider

The ASP.NET membership provider is a feature that enables ASP.NET developers to create Web sites that allow users to create unique user name and password combinations. With this facility, any user can establish an account with the site, and sign in for exclusive access to the site and its services. This is in contrast to Windows security, which requires users to have accounts in a Windows domain. Instead, any user that supplies their credentials (the user name/password combination) can use the site and its services.

For a sample application, see [Membership and Role Provider](/previous-versions/dotnet/framework/wcf/samples/membership-and-role-provider). For information about using the ASP.NET role provider feature, see [How to: Use the ASP.NET Role Provider with a Service](how-to-use-the-aspnet-role-provider-with-a-service.md).

The membership feature requires using a SQL Server database to store the user information. The feature also includes methods for prompting with a question any users who have forgotten their password.

Windows Communication Foundation (WCF) developers can take advantage of these features for security purposes. When integrated into an WCF application, users must supply a user name/password combination to the WCF client application. To transfer the data to the WCF service, use a binding that supports user name/password credentials, such as the <xref:System.ServiceModel.WSHttpBinding> (in configuration, the [\<wsHttpBinding>](../../configure-apps/file-schema/wcf/wshttpbinding.md)) and set the client credential type to `UserName`. On the service, WCF security authenticates the user based on the user name and password, and also assigns the role specified by the ASP.NET role.

> [!NOTE]
> WCF does not provide methods to populate the database with user name/password combinations or other user information.

### To configure the membership provider

1. In the Web.config file, under the <`system.web`> element, create a <`membership`> element.

2. Under the `<membership>` element, create a `<providers>` element.

3. As a child to the <`providers`> element, add a `<clear />` element to flush the collection of providers.

4. Under the `<clear />` element, create an <`add`> element with the following attributes set to appropriate values: `name`, `type`, `connectionStringName`, `applicationName`, `enablePasswordRetrieval`, `enablePasswordReset`, `requiresQuestionAndAnswer`, `requiresUniqueEmail`, and `passwordFormat`. The `name` attribute is used later as a value in the configuration file. The following example sets it to `SqlMembershipProvider`.

    The following example shows the configuration section.

    ```xml
    <!-- Configure the Sql Membership Provider -->
    <membership defaultProvider="SqlMembershipProvider" userIsOnlineTimeWindow="15">
      <providers>
        <clear />
          <add
            name="SqlMembershipProvider"
            type="System.Web.Security.SqlMembershipProvider"
            connectionStringName="SqlConn"
            applicationName="MembershipAndRoleProviderSample"
            enablePasswordRetrieval="false"
            enablePasswordReset="false"
            requiresQuestionAndAnswer="false"
            requiresUniqueEmail="true"
            passwordFormat="Hashed" />
      </providers>
    </membership>
    ```

### To configure service security to accept the user name/password combination

1. In the configuration file, under the [\<system.serviceModel>](../../configure-apps/file-schema/wcf/system-servicemodel.md) element, add a [\<bindings>](../../configure-apps/file-schema/wcf/bindings.md) element.

2. Add a [\<wsHttpBinding>](../../configure-apps/file-schema/wcf/wshttpbinding.md) to the bindings section. For more information about creating an WCF binding element, see [How to: Specify a Service Binding in Configuration](../how-to-specify-a-service-binding-in-configuration.md).

3. Set the `mode` attribute of the `<security>` element to `Message`.

4. Set the `clientCredentialType` attribute of the <`message`> element to `UserName`. This specifies that a user name/password pair will be used as the client's credential.

    The following example shows the configuration code for the binding.

    ```xml
    <system.serviceModel>
    <bindings>
      <wsHttpBinding>
      <!-- Set up a binding that uses UserName as the client credential type -->
        <binding name="MembershipBinding">
          <security mode ="Message">
            <message clientCredentialType ="UserName"/>
          </security>
        </binding>
      </wsHttpBinding>
    </bindings>
    </system.serviceModel>
    ```

### To configure a service to use the membership provider

1. As a child to the `<system.serviceModel>` element, add a [\<behaviors>](../../configure-apps/file-schema/wcf/behaviors.md) element

2. Add a [\<serviceBehaviors>](../../configure-apps/file-schema/wcf/servicebehaviors.md) to the <`behaviors`> element.

3. Add a [\<behavior>](../../configure-apps/file-schema/wcf/behavior-of-endpointbehaviors.md) and set the `name` attribute to an appropriate value.

4. Add a [\<serviceCredentials>](../../configure-apps/file-schema/wcf/servicecredentials.md) to the <`behavior`> element.

5. Add a [\<userNameAuthentication>](../../configure-apps/file-schema/wcf/usernameauthentication.md) to the `<serviceCredentials>` element.

6. Set the `userNamePasswordValidationMode` attribute to `MembershipProvider`.

    > [!IMPORTANT]
    > If the `userNamePasswordValidationMode` value is not set, WCF uses Windows authentication instead of the ASP.NET membership provider.

7. Set the `membershipProviderName` attribute to the name of the provider (specified when adding the provider in the first procedure in this topic). The following example shows the `<serviceCredentials>` fragment to this point.

    ```xml
    <behaviors>
       <serviceBehaviors>
          <behavior name="MyServiceBehavior">
             <serviceCredentials>
                <userNameAuthentication
                userNamePasswordValidationMode="MembershipProvider"
                membershipProviderName="SqlMembershipProvider" />
             </serviceCredentials>
          </behavior>
       </serviceBehaviors>
    </behaviors>
    ```

## Example

The following code shows the configuration for a service that uses the ASP membership feature.

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <system.serviceModel>
    <services>
      <service behaviorConfiguration="MyServiceBehavior" name="Microsoft.Samples.GettingStarted.CalculatorService">
        <endpoint address="http://microsoft.com/WCFservices/Calculator"
          binding="wsHttpBinding" bindingConfiguration="MembershipBinding"
          name="ASPmemberUserName" contract="Microsoft.Samples.GettingStarted.ICalculator" />
      </service>
    </services>
    <behaviors>
      <serviceBehaviors>
        <behavior name="MyServiceBehavior">
          <serviceCredentials>
            <userNameAuthentication
              userNamePasswordValidationMode="MembershipProvider"
              membershipProviderName="SqlMembershipProvider" />
          </serviceCredentials>
        </behavior>
          </serviceBehaviors>
    </behaviors>
    <bindings>
      <wsHttpBinding>
        <binding name="MembershipBinding">
          <security mode="Message">
            <message clientCredentialType="UserName" />
          </security>
        </binding>
      </wsHttpBinding>
    </bindings>
  </system.serviceModel>
</configuration>
```

## See also

- [How to: Use the ASP.NET Role Provider with a Service](how-to-use-the-aspnet-role-provider-with-a-service.md)
- [Membership and Role Provider](/previous-versions/dotnet/framework/wcf/samples/membership-and-role-provider)
