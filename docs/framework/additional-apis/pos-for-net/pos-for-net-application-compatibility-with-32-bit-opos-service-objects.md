---
title: POS for .NET Application Compatibility with 32-bit OPOS Service Objects (POS for .NET v1.14 SDK Documentation)
description: POS for .NET Application Compatibility with 32-bit OPOS Service Objects (POS for .NET v1.14 SDK Documentation) (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.topic: how-to
ms.custom: "pos-restored-from-archive,UpdateFrequency5"
---

# POS for .NET Application Compatibility with 32-bit OPOS Service Objects (POS for .NET v1.14 SDK Documentation)

Because OLE for Retail POS (OPOS) service objects only exist as 32-bit objects, under certain circumstances 64-bit applications that reference Microsoft Point of Service for .NET (POS for .NET) assemblies may fail to load OPOS service objects. If your application meets certain requirements, you can use one of the two procedures discussed in this topic to interoperate with 32-bit OPOS service objects.

POS for .NET applications that are compiled as 32-bit should work with all OPOS service objects, and do not require any of the procedures described in this topic.

## Requirements

Your application must meet all of the following conditions in order to use the procedures described in this topic:

- Your application runs on 64-bit Windows.
- Your application uses OPOS service objects.
- The executable that references POS for .NET is compiled as Microsoft intermediate language (MSIL) ('anycpu' platform).
- All managed assemblies referenced by the application are also compiled as MSIL.

Under these conditions, the Common Library Runtime (CLR) will see that all managed assemblies are MSIL so it will choose to run the managed application as a 64-bit process. When POS for .NET attempts to load a 32-bit OPOS service object as an in-process COM server, it will fail to load and the device will not be visible to your application. This is because a 64-bit process cannot load a 32-bit COM server into its process space.

You can work around this by using one of the following two solutions:

## Compile the managed process as a 32-bit process

You can force your process to run as a 32-bit process by compiling your main executable to target the **x86** or **anycpu32bitpreferred** platform. This causes the managed app to run as 32-bit and load the OPOS object as an in-process COM server.

## To compile your application as 32-bit at the command prompt

1. Add the `/platform:x86` compiler option to your C\# compiler command, as in the following example:

    `csc /platform:x86 <filename>.cs`

    For more information, see [/platform (C\# Compiler Options)](https://go.microsoft.com/fwlink/p/?linkid=389441) on MSDN.

## To compile your application as 32-bit in Visual Studio 2013

1. In Microsoft Visual Studio 2013, open your project.

2. Open the **BUILD** menu and select **Configuration Manager**.

3. In the **Configuration Manager** dialog box, in the **Platform** column, click on the cell to expand the drop down menu and select **x86**. If **x86** is not available, select **\<New…\>**, and then select **x86** as the new platform and click **OK**.

4. Rebuild the project.

## Compile the managed process as a 64-bit process and modify the COM registry of the OPOS object

You can modify the COM registration of the OPOS service object to use a 32-bit host process. This causes Windows to handle inter-process communication (IPC) and marshalling of data between the 64-bit managed process and the 32-bit COM surrogate host process.

## To modify the COM registry of the OPOS service object

1. In the registry, locate your COM object GUID key under **HKEY\_CLASSES\_ROOT/Wow6432Node/CLSID**.

2. Once you locate the COM object GUID key, add a new string value (REG\_SZ). Set the name to **AppID** and set the data to the COM object GUID, including the curly braces.

3. Add a new key under **HKEY\_CLASSES\_ROOT/Wow6432Node/AppID** with the same name as the COM object GUID key.

4. Under the new key you just added, add a new string value (REG\_SZ). Set the name to **DllSurrogate**. Leave the value empty.

5. Create a new key under **HKEY\_LOCAL\_MACHINE/Software/Classes/AppID** with the same name as the COM object’s GUID, if it doesn't already exist. You do not need to add any values to this key.

Alternatively, you can use the following Windows PowerShell script to modify the COM registry for all of the OPOS Common Control Objects (CCO) to use out of process COM servers. You can run this script to ensure that all OPOS service objects will be able to interoperate with 64-bit applications. You must run the script from an administrator Windows PowerShell prompt.

```csharp
# This Windows PowerShell script modifies the COM registry for all OPOS
# Common Control Objects (CCO) so that they use out of process COM servers.
# This enables OPOS service objects to work with both 32-bit and 64-bit
# POS for .NET applications.

# .Synopsis
# Create-Regkey: This function creates a new key in the registry
function Create-Regkey {
    param(
        [string] $Key
    )

    if (!(test-path -path $Key -pathType container)) {
            New-Item -path $Key -type container | Out-Null
    }
}

# .Synopsis
# Set-RegEntry: This function creates a new registry key in the registry and
# creates a new value in the key.
function Set-RegEntry {
    param(
        [string] $Key,
        [string] $Name,
        [string] $PropertyType,
        $Value
    )

    Create-RegKey -Key $Key
    Remove-ItemProperty -Path $Key -Name $Name -ErrorAction SilentlyContinue
    New-ItemProperty -Path $Key -Name $Name -PropertyType $PropertyType -Value $Value | Out-Null
}

# Iterate through all of the OPOS Common Control Objects, setting registry
# entries and values for each object.

for ($i = 2; $i -lt 38; $i++) {
    $clsid = '{{CCB90{0:D2}2-B81E-11D2-AB74-0040054C3719}}' -f $i

    Set-RegEntry -Key "hklm:\SOFTWARE\Classes\Wow6432Node\CLSID\$clsid" -Name 'AppID' -PropertyType String -Value $clsid
    Set-RegEntry -Key "hklm:\SOFTWARE\Classes\Wow6432Node\AppID\$clsid" -Name 'DllSurrogate' -PropertyType String
    Create-RegKey -Key "hklm:\SOFTWARE\Classes\AppID\$clsid"
}

If you need to revert the COM registry after running the previous script, you can run the following Windows PowerShell script to remove the new COM registry entries:

# This Windows PowerShell script restores the COM registry for all OPOS
# Common Control Objects (CCO) to their original values.

for ($i = 2; $i -lt 38; $i++) {
    $clsid = '{{CCB90{0:D2}2-B81E-11D2-AB74-0040054C3719}}' -f $i

    Remove-ItemProperty -Path "hklm:\SOFTWARE\Classes\Wow6432Node\CLSID\$clsid" -Name 'AppID'
    Remove-Item -Path "hklm:\SOFTWARE\Classes\Wow6432Node\AppID\$clsid"
    Remove-Item -Path "hklm:\SOFTWARE\Classes\AppID\$clsid"
}
```

## See Also

#### Other Resources

- [Developing a POS Application](developing-a-pos-application.md)
