// <snippet1>
using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;

[ComImport,
GuidAttribute( "00020406-0000-0000-C000-000000000046" ),
InterfaceTypeAttribute( ComInterfaceType.InterfaceIsIUnknown ),
ComVisible( false )]
public interface UCOMICreateITypeLib
{
    void CreateTypeInfo();
    void SetName();
    void SetVersion();
    void SetGuid();
    void SetDocString();
    void SetHelpFileName();
    void SetHelpContext();
    void SetLcid();
    void SetLibFlags();
    void SaveAllChanges();
}

public class App
{
    public static void Main()
    {
        Assembly asm = Assembly.LoadFrom( "MyAssembly.dll" );
        TypeLibConverter converter = new TypeLibConverter();
        ConversionEventHandler eventHandler = new ConversionEventHandler();
		
        UCOMICreateITypeLib typeLib = (UCOMICreateITypeLib)converter.ConvertAssemblyToTypeLib( asm, "MyTypeLib.dll", 0, eventHandler );	
        typeLib.SaveAllChanges();
    }
}

public class ConversionEventHandler : ITypeLibExporterNotifySink
{
    public void ReportEvent( ExporterEventKind eventKind, int eventCode, string eventMsg )
    {
        // Handle the warning event here.
    }
	
    public Object ResolveRef( Assembly asm )
    {
        // Resolve the reference here and return a correct type library.
        return null; 
    }	
}
// </snippet1>