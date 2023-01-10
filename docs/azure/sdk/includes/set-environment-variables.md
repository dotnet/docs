The `DefaultAzureCredential` object will look for service principal credentials in a set of environment variables at runtime. There are multiple ways to configure environment variables when working with .NET depending on your tooling and environment.

Regardless of which approach you choose, you will need to configure the following environment variables when working with a service principal.

- `AZURE_CLIENT_ID` &rarr; The app ID value.
- `AZURE_TENANT_ID` &rarr; The tenant ID value.
- `AZURE_CLIENT_SECRET` &rarr; The password/credential generated for the app.

### [Visual Studio](#tab/visual-studio)

When working locally with Visual Studio, environment variables can be set in the `launchsettings.json` file in the `Properties` folder of your project.  When the app starts up, these values will be pulled in automatically.  Keep in mind these configurations do not travel with your application when it gets deployed, so you will still need to setup environment variables on your target hosting environment.

```json
"profiles": {
    "SampleProject": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "applicationUrl": "https://localhost:7177;http://localhost:5177",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development",
        "AZURE_CLIENT_ID": "00000000-0000-0000-0000-000000000000",
        "AZURE_TENANT_ID":"11111111-1111-1111-1111-111111111111",
        "AZURE_CLIENT_SECRET": "=abcdefghijklmnopqrstuvwxyz"
      }
    },
    "IIS Express": {
      "commandName": "IISExpress",
      "launchBrowser": true,
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development",
        "AZURE_CLIENT_ID": "00000000-0000-0000-0000-000000000000",
        "AZURE_TENANT_ID": "11111111-1111-1111-1111-111111111111",
        "AZURE_CLIENT_SECRET": "=abcdefghijklmnopqrstuvwxyz"
      }
    }
  }
```

### [VS Code](#tab/vs-code)

When working locally with Visual Studio Code, environment variables can be set in the `launch.json` file of your project.  When the app starts up, these values will be pulled in automatically.  Keep in mind these configurations do not travel with your application when it gets deployed, so you will still need to setup environment variables on your target hosting environment.

```json
"configurations": [
{
    "env": {
        "ASPNETCORE_ENVIRONMENT": "Development",
        "AZURE_CLIENT_ID": "00000000-0000-0000-0000-000000000000",
        "AZURE_TENANT_ID":"11111111-1111-1111-1111-111111111111",
        "AZURE_CLIENT_SECRET": "=abcdefghijklmnopqrstuvwxyz"
    }
}
```

### [Windows](#tab/windows)

You can easily set environment variables for Windows from the command line. Windows environment variables can be used for both local development or for hosting environments.  However, remember that when using this approach the values will apply to all applications running on that operating system and may cause conflicts if you are not careful.

```bash
setx AZURE_CLIENT_ID "00000000-0000-0000-0000-000000000000"
setx AZURE_TENANT_ID "11111111-1111-1111-1111-111111111111"
setx AZURE_CLIENT_SECRET "=abcdefghijklmnopqrstuvwxyz"
```

Alternatively, if your app is hosted in IIS you can also set environment variables per app. This can be configured using the applicationHost.config file.

```xml
<location path="production.site.com">
  <system.webServer>
    <aspNetCore>
      <environmentVariables>
        <environmentVariable name="ASPNETCORE_ENVIRONMENT" value="Production" />
        <environmentVariable name="AZURE_CLIENT_ID" value="00000000-0000-0000-0000-000000000000" />
        <environmentVariable name="AZURE_TENANT_ID" value="11111111-1111-1111-1111-111111111111" />
        <environmentVariable name="AZURE_CLIENT_SECRET" value="=abcdefghijklmnopqrstuvwxyz" />
      </environmentVariables>
    </aspNetCore>
  </system.webServer>
</location>
```

---
