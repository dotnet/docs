// <Snippet1>
using System;
using Microsoft.VisualStudio.Data.Core;
using Microsoft.VisualStudio.Data.Services.SupportEntities;
using Microsoft.VisualStudio.Data.Services.SupportEntities.Interop;

internal class MyDSRefBuilder : IDSRefBuilder,
    IVsDataSupportObject<IDSRefBuilder>
{
    public void AppendToDSRef(
        object dsRef, string typeName, object[] identifier)
    {
        AppendToDSRef(dsRef, typeName, identifier, null);
    }

    object IVsDataSupportObject<IDSRefBuilder>.Invoke(
        string name, object[] args, object[] parameters)
    {
        if (name == null)
        {
            throw new ArgumentNullException("name");
        }
        if (name.Equals("AppendToDSRef", StringComparison.Ordinal))
        {
            if (args == null || args.Length != 3)
            {
                throw new ArgumentException();
            }
            AppendToDSRef(args[0], args[1] as string,
                args[2] as object[], parameters);
            return null;
        }
        throw new ArgumentException();
    }

    private void AppendToDSRef(object dsRef,
        string typeName, object[] identifier, object[] parameters)
    {
        if (parameters == null || parameters.Length == 0)
        {
            throw new ArgumentException();
        }
        string dsRefType = parameters[0] as string;
        if (dsRefType.Equals("DSREFTYPE_TABLE"))
        {
            AppendTableToDSRef(dsRef, identifier);
        }
        else if (dsRefType.Equals("DSREFTYPE_VIEW"))
        {
            AppendViewToDSRef(dsRef, identifier);
        }
    }

    private void AppendTableToDSRef(object dsRef, object[] identifier)
    {
        // Append table
    }

    private void AppendViewToDSRef(object dsRef, object[] identifier)
    {
        // Append view
    }
}
// </Snippet1>