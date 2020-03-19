---
ms.service: multiple
ms.date: 9/20/2018
ms.topic: include
---
Create a text file named `azureauth.json`. Paste the JSON output from when you created the service principal.

Save this file in a secure location on your system where your code can read it. Use PowerShell to set an environment variable named `AZURE_AUTH_LOCATION` with the full path to the file, for example:

```powershell
[Environment]::SetEnvironmentVariable("AZURE_AUTH_LOCATION", "C:\src\azureauth.json", "User")
```
