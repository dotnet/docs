// <Snippet1>
using System;
using Microsoft.VisualStudio.Data.Core;
using Microsoft.VisualStudio.Data.Framework;
using Microsoft.VisualStudio.Data.Services;
using Microsoft.VisualStudio.Data.Services.SupportEntities;

internal class MyProviderObjectFactory : DataProviderObjectFactory
{
    public override object CreateObject(Type objType)
    {
        if (objType == null)
        {
            throw new ArgumentNullException("objType");
        }
        if (objType == typeof(IVsDataConnectionProperties))
        {
            return new MyConnectionProperties();
        }
        if (objType == typeof(IVsDataConnectionSupport))
        {
            return new MyConnectionSupport();
        }
        return null;
    }
}

internal class MyConnectionProperties : DataConnectionProperties
{
}

internal class MyConnectionSupport : IVsDataConnectionSupport
{
    // Implement the interface methods

    public void Initialize(object providerObj) {}
    public bool Open(bool doPromptCheck) {return true;}
    public void Close() {}
    public string ConnectionString { get {return "";} set {} }
    public int ConnectionTimeout { get {return 0;} set {} }
    public DataConnectionState State { get {return DataConnectionState.Closed;} }
    public object ProviderObject { get {return null;} }

    // Inherited from System.IServiceProvider 
    public Object GetService(Type serviceType) {return null;}

    // Inherited from System.IDisposable
    public void Dispose() {}

}
// </Snippet1>