// <Snippet5>
using System;
using Microsoft.VisualStudio.Data.Core;
using Microsoft.VisualStudio.Data.Framework;

public class MySourceSpecializer5 : DataSourceSpecializer
{
    private static readonly Guid s_dataSource1 =
        new Guid("EB5246D3-277C-4277-910F-111CB9EAD253");

    public override Type GetType(Guid source, string typeName)
    {
        if (source == s_dataSource1)
        {
            typeName = "Company.DdexProvider.Source1." + typeName;
        }
        else
        {
            typeName = "Company.DdexProvider." + typeName;
        }
        return GetType().Assembly.GetType(typeName);
    }
}
// </Snippet5>