Apps hosted in Azure should use a **Managed Identity service principal**. Managed identities are designed to represent the identity of an app hosted in Azure and can only be used with Azure hosted apps.<br>
<br>
For example, a .NET web app hosted in Azure App Service would be assigned a Managed Identity.  The Managed Identity assigned to the app would then be used to authenticate the app to other Azure services.<br>
<br>
> [!div class="nextstepaction"]
> [Learn about auth from Azure hosted apps](../authentication-azure-hosted-apps.md)
