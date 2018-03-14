// <Snippet2>
using System;
using System.ComponentModel.Design;
using Microsoft.Win32;
using Microsoft.VisualStudio.Data.Core;
using Microsoft.VisualStudio.Data.Services;

public class MyProviderDynamicSupport2 : IVsDataProviderDynamicSupport
{
    private static readonly CommandID DeployCommand =
        new CommandID(new Guid("6535F307-2083-4cbb-B2FA-11F2DCD69DAF"), 25);

    public bool IsProviderSupported
    {
        get
        {
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
        if (command == null)
        {
            throw new ArgumentNullException("command");
        }
        if (command.Equals(DeployCommand))
        {
            IVsDataExplorerConnection explorerConnection =
                context as IVsDataExplorerConnection;
            if (explorerConnection == null)
            {
                throw new ArgumentException();
            }
            RegistryKey key = Registry.LocalMachine.OpenSubKey(
                @"SOFTWARE\Company\DeployTechnology");
            if (key == null)
            {
                return false;
            }
            key.Close();
        }
        return true;
    }

    public string GetUnsupportedReason(
        Guid source, CommandID command, object context)
    {
        if (command == null)
        {
            throw new ArgumentNullException("command");
        }
        if (command.Equals(DeployCommand) &&
            !IsOperationSupported(source, command, context))
        {
            // Note: This string should be localized
            return "In order to deploy a database you need to install our deployment technology.";
        }
        return null;
    }
}
// </Snippet2>