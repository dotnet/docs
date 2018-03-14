// Convert.cs
//<snippet1>
using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;


public class App
{
	private enum RegKind
	{
		RegKind_Default = 0,
		RegKind_Register = 1,
		RegKind_None = 2
	}
	
	[ DllImport( "oleaut32.dll", CharSet = CharSet.Unicode, PreserveSig = false )]
	private static extern void LoadTypeLibEx( String strTypeLibName, RegKind regKind, 
		[ MarshalAs( UnmanagedType.Interface )] out Object typeLib );
	
	public static void Main()
	{
		Object typeLib;
		LoadTypeLibEx( "SHDocVw.dll", RegKind.RegKind_None, out typeLib ); 
		
		if( typeLib == null )
		{
			Console.WriteLine( "LoadTypeLibEx failed." );
			return;
		}
			
		TypeLibConverter converter = new TypeLibConverter();
		ConversionEventHandler eventHandler = new ConversionEventHandler();
		AssemblyBuilder asm = converter.ConvertTypeLibToAssembly( typeLib, "ExplorerLib.dll", 0, eventHandler, null, null, null, null );	
		asm.Save( "ExplorerLib.dll" );
	}
}

public class ConversionEventHandler : ITypeLibImporterNotifySink
{
	public void ReportEvent( ImporterEventKind eventKind, int eventCode, string eventMsg )
	{
		// handle warning event here...
	}
	
	public Assembly ResolveRef( object typeLib )
	{
		// resolve reference here and return a correct assembly...
		return null; 
	}	
}
//</snippet1>