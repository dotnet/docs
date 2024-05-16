In this method, dedicated **application service principal** objects are set up using the App registration process for use during local development.  The identity of the service principal is then stored as environment variables to be accessed by the app when it is run in local development.<br>
<br>
This method allows you to assign the specific resource permissions needed by the app to the service principal objects used by developers during local development.  This makes sure the application only has access to the specific resources it needs and replicates the permissions the app will have in production.<br>
<br>
The downside of this approach is the need to create separate service principal objects for each developer that works on an application.<br>
<br>
> [!div class="nextstepaction"]
> [Learn about auth from Azure-hosted apps](../authentication/local-development-service-principal.md)
