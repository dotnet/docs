// <Snippet3>
using System;
using System.ComponentModel.Design;
using Microsoft.Win32;
using Microsoft.VisualStudio.Data.Core;

public class MyProviderDynamicSupport3 : IVsDataProviderDynamicSupport
{
    public bool IsProviderSupported
    {
        get
        {
            return true;
        }
    }

    public bool IsSourceSupported(Guid source)
    {
        RegistryKey key = Registry.LocalMachine.OpenSubKey(
            @"SOFTWARE\Company\MyDatabaseSource");
        if (key == null)
        {
            return false;
        }
        key.Close();
        return true;
    }

    public bool IsOperationSupported(
        Guid source, CommandID command, object context)
    {
        return true;
    }

    public string GetUnsupportedReason(
        Guid source, CommandID command, object context)
    {
        return null;
    }
}
// </Snippet3>