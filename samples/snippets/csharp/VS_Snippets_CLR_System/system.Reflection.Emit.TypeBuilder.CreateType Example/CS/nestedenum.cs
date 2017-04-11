// <Snippet1>

using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;
using System.Text;
using System.Resources;
using System.Collections;
using System.IO;

internal class NestedEnum {    
    internal static TypeBuilder enumType = null;
    internal static Type tNested = null;   
    internal static Type tNesting = null;

    public static void Main(String[] args) {
	AssemblyName asmName = new AssemblyName();
	asmName.Name = "NestedEnum";
	AssemblyBuilder asmBuild = Thread.GetDomain().DefineDynamicAssembly(asmName, AssemblyBuilderAccess.RunAndSave);
	ModuleBuilder modBuild = asmBuild.DefineDynamicModule("ModuleOne", "NestedEnum.dll");       

	// Hook up the event listening.
	TypeResolveHandler typeResolveHandler = new TypeResolveHandler(modBuild);
	// Add a listener for the type resolve events.
	AppDomain currentDomain = Thread.GetDomain();
	ResolveEventHandler resolveHandler = new ResolveEventHandler(typeResolveHandler.ResolveEvent);
	currentDomain.TypeResolve += resolveHandler;

	TypeBuilder tb = modBuild.DefineType("AType", TypeAttributes.Public);
	TypeBuilder eb = tb.DefineNestedType("AnEnum", TypeAttributes.NestedPublic | TypeAttributes.Sealed, typeof(Enum), null);
	eb.DefineField("value__", typeof(int), FieldAttributes.Private | FieldAttributes.SpecialName);
	FieldBuilder fb = eb.DefineField("Field1", eb, FieldAttributes.Public | FieldAttributes.Literal | FieldAttributes.Static);
	fb.SetConstant(1);

	enumType = eb;

	// Comment out this field.
	// When this field is defined, the loader cannot determine the size
	// of the type. Therefore, a TypeResolve event is generated when the
	// nested type is completed.
	tb.DefineField("Field2", eb, FieldAttributes.Public);        

	tNesting = tb.CreateType();
	if (tNesting == null)
	    Console.WriteLine("NestingType CreateType failed but didn't throw!");	

	try {
	    tNested = eb.CreateType();
	    if (tNested == null)
		Console.WriteLine("NestedType CreateType failed but didn't throw!");	
	}
	catch {
	    // This is needed because you might have already completed the type in the TypeResolve event.
	}

	if (tNested != null) {
	    Type x = tNested.DeclaringType;
	    if (x == null)
		Console.WriteLine("Declaring type was null.");
	    else 
		Console.WriteLine(x.Name);
	}

	asmBuild.Save( "NestedEnum.dll" );

	// Remove the listener for the type resolve events.
	currentDomain.TypeResolve -= resolveHandler;
    }
}

// Helper class called when a resolve type event is raised.
internal class TypeResolveHandler 
{
    private Module m_Module;

    public TypeResolveHandler(Module mod)
    {
	m_Module = mod;
    }

    public Assembly ResolveEvent(Object sender, ResolveEventArgs args)
    {
	Console.WriteLine(args.Name);
	// Use args.Name to look up the type name. In this case, you are getting AnEnum.
	try {
	    NestedEnum.tNested = NestedEnum.enumType.CreateType();
	}
	catch {
	    // This is needed to throw away InvalidOperationException.
	    // Loader might send the TypeResolve event more than once
	    // and the type might be complete already.
	}

	// Complete the type.		    
	return m_Module.Assembly;
    }
}
    
// </Snippet1>



 
