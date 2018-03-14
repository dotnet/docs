// <Snippet2>
using System;
using Microsoft.VisualStudio.Data.Core;
using Microsoft.VisualStudio.Data.Services.SupportEntities;
using Microsoft.VisualStudio.Data.Framework;

public class MySourceSpecializer2 : DataSourceSpecializer
{
    private static readonly Guid s_dataSource1 =
        new Guid("F24C1C71-D9AE-47ec-80C6-91B864201D72");
    private static readonly Guid s_dataSource2 =
        new Guid("194DD1D2-19A8-4493-A70B-F83C141D29E5");

    public override object CreateObject(Guid source, Type objType)
    {
        if (source == s_dataSource1)
        {
            if (objType == typeof(IVsDataConnectionUIControl))
            {
                return new MyConnectionUIControl1();
            }
        }
        if (source == s_dataSource2)
        {
            if (objType == typeof(IVsDataConnectionUIControl))
            {
                return new MyConnectionUIControl2();
            }
        }
        return null;
    }
}

internal class MyConnectionUIControl1 : DataConnectionUIControl
{
}

internal class MyConnectionUIControl2 : DataConnectionUIControl
{
}
// </Snippet2>