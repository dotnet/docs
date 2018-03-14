// <Snippet1>
using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;

class SwapMethodBodySample
{
    // First make a method that returns 0.
    // Then swap the method body with a body that returns 1.
    public static void Main(String [] args)
    {
    // Construct a dynamic assembly
    Guid g = Guid.NewGuid();    
    AssemblyName asmname = new AssemblyName();
    asmname.Name = "tempfile" + g;
    AssemblyBuilder asmbuild = System.Threading.Thread.GetDomain().
        DefineDynamicAssembly(asmname, AssemblyBuilderAccess.Run);

    // Add a dynamic module that contains one type that has one method that
    // has no arguments.
    ModuleBuilder modbuild = asmbuild.DefineDynamicModule( "test");
        TypeBuilder tb = modbuild.DefineType( "name of the Type" );
        MethodBuilder somemethod = tb.DefineMethod
            ("My method Name",
             MethodAttributes.Public | MethodAttributes.Static,
             typeof(int),                                                     
             new Type[]{} );
    // Define the body of the method to return 0.
        ILGenerator ilg = somemethod.GetILGenerator();
    ilg.Emit(OpCodes.Ldc_I4_0);
    ilg.Emit(OpCodes.Ret);

    // Complete the type and verify that it returns 0.
    Type tbBaked = tb.CreateType();
    int res1 = (int)tbBaked.GetMethod("My method Name").Invoke( null, new Object[]{} );
    if ( res1 != 0 ) {
        Console.WriteLine( "Err_001a, should have returned 0" );
    } else {
        Console.WriteLine("Original method returned 0");
    }
                
    // Define a new method body that will return a 1 instead.
    Byte[] methodBytes = {
        0x03,
        0x30,
        0x0A,
        0x00,
        0x02,                // code size
        0x00,
        0x00,
        0x00,
        0x00,
        0x00,
        0x00,
        0x00,
        0x17,                // ldc_i4_1
        0x2a                // ret
    };

    // Get the token for the method whose body you are replacing.
    MethodToken somemethodToken = somemethod.GetToken();        

    // Get the pointer to the method body.
        GCHandle hmem = GCHandle.Alloc((Object) methodBytes, GCHandleType.Pinned);
        IntPtr addr = hmem.AddrOfPinnedObject();
    int cbSize = methodBytes.Length;

    // Swap the old method body with the new body.
    MethodRental.SwapMethodBody(
                    tbBaked, 
                    somemethodToken.Token, 
                    addr,
                    cbSize,
                    MethodRental.JitImmediate);

    // Verify that the modified method returns 1.
    int res2 = (int)tbBaked.GetMethod("My method Name").Invoke( null, new Object[]{} );
    if ( res2 != 1 ) {
        Console.WriteLine( "Err_001b, should have returned 1" );
    } else {
        Console.WriteLine("Swapped method body returned 1");
    }
    }
}
// </Snippet1>

