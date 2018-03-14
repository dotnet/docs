// <Snippet1>
using System;
using Microsoft.VisualStudio.Data.Core;
using Microsoft.VisualStudio.Data.Framework;

internal class MyConnectionProperties : DataConnectionProperties,
    IVsDataSiteableObject<IVsDataProvider>,
    IVsDataSiteableObject<IServiceProvider>
{
    private IVsDataProvider _provider;
    private IServiceProvider _serviceProvider;

    IVsDataProvider IVsDataSiteableObject<IVsDataProvider>.Site
    {
        get
        {
            return _provider;
        }
        set
        {
            _provider = value;
        }
    }

    IServiceProvider IVsDataSiteableObject<IServiceProvider>.Site
    {
        get
        {
            return _serviceProvider;
        }
        set
        {
            _serviceProvider = value;
        }
    }
}
// </Snippet1>