// <Snippet4>
using System;
using System.Reflection;
using Microsoft.VisualStudio.Data.Core;
using Microsoft.VisualStudio.Data.Framework;

public class MySourceSpecializer4 : DataSourceSpecializer
{
    private static readonly Guid s_dataSource1 =
        new Guid("EB5246D3-277C-4277-910F-111CB9EAD253");
    private static readonly Guid s_dataSource2 =
        new Guid("1EC8B196-7155-4d5a-BBDC-0CC47D631E52");

    public override Assembly GetAssembly(Guid source, string assemblyString)
    {
        if (source == s_dataSource1)
        {
            return Assembly.Load("AssemblyForDataSource1");
        }
        else if (source == s_dataSource2)
        {
            return Assembly.Load("AssemblyForDataSource2");
        }
        else
        {
            return base.GetAssembly(source, assemblyString);
        }
    }
}
// </Snippet4>