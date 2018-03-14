// <Snippet2>
using System;
using System.Reflection;
using Microsoft.VisualStudio.Data.Core;
using Microsoft.VisualStudio.Data.Framework;

public class MyProviderObjectFactory2 : DataProviderObjectFactory
{
    public override object CreateObject(Type objType)
    {
        return null;
    }

    public override Assembly GetAssembly(string assemblyString)
    {
        if (assemblyString == null)
        {
            throw new ArgumentNullException("assemblyString");
        }
        if (assemblyString.Length == 0)
        {
            return GetType().Assembly;
        }
        return base.GetAssembly(assemblyString);
    }
}
// </Snippet2>