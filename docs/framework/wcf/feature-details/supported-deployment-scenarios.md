---
description: "Learn more about: Supported deployment scenarios"
title: "Supported deployment scenarios"
ms.date: "03/30/2017"
ms.assetid: 3399f208-3504-4c70-a22e-a7c02a8b94a6
---
# Supported deployment scenarios

The subset of Windows Communication Foundation (WCF) features supported for use in partially trusted applications is designed to meet the requirements of some, but not all, scenarios for using WCF. On the server, WCF meets the requirements of Internet-scale shared hosting providers who run third-party applications in the ASP.NET 2.0 Medium Trust permission set for security reasons. On the client, WCF partial trust support is designed to meet the requirements of deployment technologies such as [ClickOnce Deployment](/visualstudio/deployment/clickonce-security-and-deployment) or WPF's XAML Browser Application technology, which allow seamless and secure deployment of desktop applications from untrusted sites.

## Minimum permission requirements

WCF supports a subset of features in applications running under either of the following standard named permission sets:

- Medium Trust permissions

- Internet Zone permissions

Attempting to use WCF in partially trusted applications with more restrictive permissions may result in security exceptions at runtime.

For more information about the features supported in these permission sets, see [Partial Trust Feature Compatibility](partial-trust-feature-compatibility.md).

## Partial trust on the server

Many commercial providers of ASP.NET Web application hosting services mandate that applications running on their servers run in the ASP.NET 2.0 Medium Trust permission set. WCF services can run in these environments provided they use the <xref:System.ServiceModel.BasicHttpBinding>, the <xref:System.ServiceModel.WebHttpBinding>, or the <xref:System.ServiceModel.WSHttpBinding> with transport-level security.

WCF services running in Medium Trust hosting environments can also act as middle-tier services by sending messages to other servers in response to client requests. Middle-tier scenarios on the server are supported if the hosting environment has granted the application the appropriate <xref:System.Net.WebPermission> to make outbound requests to the desired server.

In addition to SOAP messaging using one of the supported SOAP bindings, WCF supports the <xref:System.ServiceModel.WebHttpBinding> for building Web-style services in partially trusted applications. The [WCF Web HTTP Programming Model](wcf-web-http-programming-model.md), [WCF Syndication](wcf-syndication.md), and [AJAX Integration and JSON Support](ajax-integration-and-json-support.md) features of WCF are all supported in partial trust.

Workflow Services require Full Trust permissions and cannot be used in partially trusted applications.

For more information, see [How to: Use Medium Trust in ASP.NET 2.0](/previous-versions/msp-n-p/ff648344(v=pandp.10)).

## Partial trust on the client

Certain security precautions must be taken when downloading and running code from untrusted Internet sites. Both [ClickOnce Deployment](/visualstudio/deployment/clickonce-security-and-deployment) and WPF's XAML Browser Application (XBAP) technology make use of partial trust to grant limited permissions (Internet Zone) to untrusted code.

WCF can be used to communicate with remote servers from within partially trusted applications deployed by either [ClickOnce Deployment](/visualstudio/deployment/clickonce-security-and-deployment) or XBAP. The Internet Zone permission set includes <xref:System.Net.WebPermission> for the originating host, which allows these applications to communicate with their origin server using any of the supported WCF bindings described in [Partial Trust Feature Compatibility](partial-trust-feature-compatibility.md).

## See also

- [Code Access Security](/previous-versions/dotnet/framework/code-access-security/code-access-security)
- [Windows Presentation Foundation Browser-Hosted Applications Overview](/dotnet/desktop/wpf/app-development/wpf-xaml-browser-applications-overview)
- [Partial Trust](partial-trust.md)
- [ASP.NET Trust Levels and Policy Files](/previous-versions/wyts434y(v=vs.140))
