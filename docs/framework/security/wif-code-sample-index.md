---
title: "WIF Code Sample Index"
ms.date: "03/30/2017"
ms.assetid: 6711f01a-4743-43ce-95ab-5e2302a363ea
author: "BrucePerlerMS"
---

# WIF Code Sample Index

The following are code samples for Windows Identity Foundation 4.5:

- [ClaimsAwareWebApp](https://code.msdn.microsoft.com/vstudio/Claims-Aware-Web-d94a89ca) - this sample demonstrates basic use of authentication externalization (to the local test Security Token Service from the Identity and Access Tool for Visual Studio 11) on a classic ASP.NET application (as opposed to a web site).

- [ClaimsAwareWebService](https://code.msdn.microsoft.com/vstudio/Claims-Aware-Web-Service-1d55facc) - this sample demonstrates basic use of authentication externalization on a classic WCF service.

- [ClaimsAwareMvcApplication](https://code.msdn.microsoft.com/vstudio/Claims-Aware-MVC-523e079b) - this sample demonstrates how to integrate WIF with MVC, including non-blanket protection and code which honors the forms authentication redirects out of the LogOn controller.

- [ClaimsAwareWebFarm](https://code.msdn.microsoft.com/vstudio/Claims-Aware-Web-Farm-088a7a4f) - this sample demonstrates a farm ready session cache (as opposed to a tokenreplycache) so that you can use sessions by reference instead of exchanging big cookies. It also demonstrates an easier way of securing cookies in a farm.

- [ClaimsAwareFormsAuthentication](https://code.msdn.microsoft.com/vstudio/Claims-Aware-Forms-8c6a8b4d) - this very simple sample demonstrates that in .NET 4.5 you get claims in your principals regardless of how you authenticate your users.

- [ClaimsBasedAuthorization](https://code.msdn.microsoft.com/vstudio/Claims-Based-Authorization-89cf736e)- this samples shows how to use your ClaimsAuthorizationManager class and the ClaimsAuthorizationModule for applying your own authorization policies.

- [FederationMetadata](https://code.msdn.microsoft.com/vstudio/Federation-Metadata-34036040) – this sample demonstrates both dynamic generation (on a custom STS) and dynamic consumption (on a relying party application) of metadata documents.

- [CustomToken](https://code.msdn.microsoft.com/vstudio/Custom-Token-ddce2f55) – this sample demonstrates how to build a custom Simple Web Token (SWT) token type.

## See also

- [Windows Identity Foundation](index.md)
