// <Snippet1>
using System;
using Microsoft.VisualStudio.Data.Core;
using Microsoft.VisualStudio.Data.Framework;
using Microsoft.VisualStudio.Data.Services.SupportEntities;

internal class MySourceSpecializer : DataSourceSpecializer
{
    private static readonly Guid Source1Guid =
        new Guid("A871863D-7D71-4e49-A8C5-4E959DDE7AF7");
    private static readonly Guid Source2Guid =
        new Guid("D79D7D55-A266-4db9-92A9-3FDBA5D6A722");

    public override Guid DeriveSource(string connectionString)
    {
        if (connectionString.StartsWith("Source1"))
        {
            return Source1Guid;
        }
        if (connectionString.StartsWith("Source2"))
        {
            return Source2Guid;
        }
        return base.DeriveSource(connectionString);
    }

    public override object CreateObject(Guid source, Type objType)
    {
        if (objType == null)
        {
            throw new ArgumentNullException("objType");
        }
        if (objType == typeof(IVsDataConnectionProperties))
        {
            if (source == Source1Guid)
            {
                return new MySource1ConnectionProperties();
            }
            if (source == Source2Guid)
            {
                return new MySource2ConnectionProperties();
            }
        }
        return base.CreateObject(source, objType);
    }
}

internal class MySource1ConnectionProperties : DataConnectionProperties
{
}

internal class MySource2ConnectionProperties : DataConnectionProperties
{
}
// </Snippet1>