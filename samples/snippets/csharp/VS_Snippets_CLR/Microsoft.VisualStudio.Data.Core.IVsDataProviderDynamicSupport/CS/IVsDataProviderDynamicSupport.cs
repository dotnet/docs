// <Snippet1>
using System;
using System.ComponentModel.Design;
using Microsoft.Win32;
using Microsoft.VisualStudio.Data.Core;

internal class MyProviderDynamicSupport : IVsDataProviderDynamicSupport
{
    public bool IsProviderSupported
    {
        get
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey(
                @"SOFTWARE\Company\AdoDotNetProvider");
            if (key == null)
            {
                return false;
            }
            key.Close();
            return true;
        }
    }

    public bool IsSourceSupported(Guid source)
    {
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
// </Snippet1>