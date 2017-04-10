// <Snippet1>
using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Data.Core;
using Microsoft.VisualStudio.Data.Services;

[DataDefaultObject("C58E1B8D-9723-40c8-8B11-9DDAF0B393BA")]
public interface IVsDataConnectionUIConnector
{
    void Connect(IVsDataConnection connection);
}

[Guid("C58E1B8D-9723-40c8-8B11-9DDAF0B393BA")]
internal class DefaultConnectionUIConnector
    : IVsDataConnectionUIConnector,
      IVsDataDefaultObject
{
    public void Connect(IVsDataConnection connection)
    {
        if (connection == null)
        {
            throw new ArgumentNullException("connection");
        }
        connection.Open();
    }
}
// </Snippet1>
