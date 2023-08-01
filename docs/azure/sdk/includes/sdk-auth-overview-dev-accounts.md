In this method, a developer must be signed-in to Azure from either Visual Studio, the Azure Tools extension for VS Code, the Azure CLI, or Azure PowerShell on their local workstation.  The application then can access the developer's credentials from the credential store and use those credentials to access Azure resources from the app.<br>
<br>
This method has the advantage of easier setup since a developer only needs to login to their Azure account from Visual Studio, VS Code or the Azure CLI.  The disadvantage of this approach is that the developer's account likely has more permissions than required by the application, therefore not properly replicating the permissions the app will run with in production.<br>
<br>
> [!div class="nextstepaction"]
> [Learn about auth from Azure-hosted apps](../authentication/local-development-dev-accounts.md)
