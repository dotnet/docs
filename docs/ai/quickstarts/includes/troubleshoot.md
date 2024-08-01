---
author: jmatthiesen
ms.author: jomatthi
ms.date: 07/03/2024
ms.topic: include
---

## Troubleshoot

On Windows, you might get the following error messages after running `azd up`:

> *postprovision.ps1 is not digitally signed. The script will not execute on the system*

The script **postprovision.ps1** is executed to set the .NET user secrets used in the application. To avoid this error, run the following PowerShell command:

```powershell
Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass
```

Then re-run the `azd up` command.

Another possible error:

> 'pwsh' is not recognized as an internal or external command,
> operable program or batch file.
> WARNING: 'postprovision' hook failed with exit code: '1', Path: '.\infra\post-script\postprovision.ps1'. : exit code: 1
> Execution will continue since ContinueOnError has been set to true.

The script **postprovision.ps1** is executed to set the .NET user secrets used in the application. To avoid this error, manually run the script using the following PowerShell command:

```powershell
.\infra\post-script\postprovision.ps1
```

The .NET AI apps now have the user secrets configured and they can be tested.
