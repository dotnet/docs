// <Snippet3>
using System;
using Microsoft.VisualStudio.Data.Core;
using Microsoft.VisualStudio.Data.Framework;

public class MySourceSpecializer3 : DataSourceSpecializer
{
    private static readonly Guid s_sqlServerDataSource =
        new Guid("067EA0D9-BA62-43f7-9106-34930C60C528");
    private static readonly Guid s_sqlServerFileDataSource =
        new Guid("485C80D5-BC85-46db-9E6D-4238A0AD7B6B");

    public override Guid DeriveSource(string connectionString)
    {
        if (connectionString == null)
        {
            throw new ArgumentNullException("connectionString");
        }
        if (connectionString.Contains("AttachDBFilename"))
        {
            return s_sqlServerFileDataSource;
        }
        return s_sqlServerDataSource;
    }
}
// </Snippet3>