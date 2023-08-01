Apps hosted outside of Azure (for example on-premises apps) that need to connect to Azure services should use an **Application service principal**. An Application service principal represents the identity of the app in Azure and is created through the application registration process.<br>
<br>
For example, consider a .NET web app hosted on-premises that makes use of Azure Blob Storage.  You would create an Application service principal for the app using the App registration process. The `AZURE_CLIENT_ID`, `AZURE_TENANT_ID`, and `AZURE_CLIENT_SECRET` would all be stored as environment variables to be read by the application at runtime and allow the app to authenticate to Azure using the Application service principal.<br>
<br>
> [!div class="nextstepaction"]
> [Learn about auth from apps hosted outside of Azure](../authentication/on-premises-apps.md)
