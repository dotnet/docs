// <Snippet1>
using System;
using System.Windows.Forms;
using Microsoft.VisualStudio.Data.Core;
using Microsoft.VisualStudio.Data.Services.SupportEntities;

public class DdexExample
{
    public static IVsDataConnectionProperties CreateConnectionProperties(
        IVsDataProvider provider)
    {
        IVsDataConnectionProperties connProperties = null;
        try
        {
            connProperties = provider.CreateObject<IVsDataConnectionProperties>();
        }
        catch (DataProviderException e)
        {
            MessageBox.Show(e.Message);
        }
        return connProperties;
    }
}
// </Snippet1>
