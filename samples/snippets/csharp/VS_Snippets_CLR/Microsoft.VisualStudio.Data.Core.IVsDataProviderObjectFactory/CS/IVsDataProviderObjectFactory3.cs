// <Snippet3>
using System;
using Microsoft.VisualStudio.Data.Core;
using Microsoft.VisualStudio.Data.Framework;

public class MyProviderObjectFactory3 : DataProviderObjectFactory
{
    public override object CreateObject(Type objType)
    {
        return null;
    }

    public override Type GetType(string typeName)
    {
        typeName = "Company.DdexProvider." + typeName;
        return base.GetType(typeName);
    }
}
// </Snippet3>