//<Snippet1>
using System;
using System.Reflection;
using System.Reflection.Emit;
using System.IO;

public class Example
{
    public static void Main()
    {
        // Define a dynamic assembly with one module. The module
        // name and the assembly name are the same.
        AssemblyName asmName = 
            new AssemblyName("EmittedManifestResourceAssembly");
        AssemblyBuilder asmBuilder =
            AppDomain.CurrentDomain.DefineDynamicAssembly(
                asmName,
                AssemblyBuilderAccess.RunAndSave
            ); 
        ModuleBuilder modBuilder = asmBuilder.DefineDynamicModule(
            asmName.Name,
            asmName.Name + ".exe"
        );

        // Create a memory stream for the unmanaged resource data.
        // You can use any stream; for example, you might read the
        // unmanaged resource data from a binary file. It is not
        // necessary to put any data into the stream right now.
        MemoryStream ms = new MemoryStream(1024);

        // Define a public manifest resource with the name 
        // "MyBinaryData, and associate it with the memory stream.
        modBuilder.DefineManifestResource(
            "MyBinaryData",
            ms,
            ResourceAttributes.Public
        );

        // Create a type with a public static Main method that will
        // be the entry point for the emitted assembly. 
        //
        // The purpose of the Main method in this example is to read 
        // the manifest resource and display it, byte by byte.
        //
        TypeBuilder tb = modBuilder.DefineType("Example");
        MethodBuilder main = tb.DefineMethod("Main", 
            MethodAttributes.Public | MethodAttributes.Static
        );

        // The Main method uses the Assembly type and the Stream
        // type. 
        Type asm = typeof(Assembly);
        Type str = typeof(Stream);

        // Get MethodInfo objects for the methods called by 
        // Main.
        MethodInfo getEx = asm.GetMethod("GetExecutingAssembly");
        // Use the overload of GetManifestResourceStream that 
        // takes one argument, a string.
        MethodInfo getMRS = asm.GetMethod(
            "GetManifestResourceStream", 
            new Type[] {typeof(string)}
        );
        MethodInfo rByte = str.GetMethod("ReadByte");
        // Use the overload of WriteLine that writes an Int32.
        MethodInfo write = typeof(Console).GetMethod(
            "WriteLine", 
            new Type[] {typeof(int)}
        );

        ILGenerator ilg = main.GetILGenerator();

        // Main uses two local variables: the instance of the
        // stream returned by GetManifestResourceStream, and 
        // the value returned by ReadByte. The load and store 
        // instructions refer to these locals by position
        // (0 and 1).
        LocalBuilder s = ilg.DeclareLocal(str);
        LocalBuilder b = ilg.DeclareLocal(typeof(int));

        // Call the static Assembly.GetExecutingAssembly() method,
        // which leaves the assembly instance on the stack. Push the
        // string name of the resource on the stack, and call the
        // GetManifestResourceStream(string) method of the assembly
        // instance.
        ilg.EmitCall(OpCodes.Call, getEx, null);
        ilg.Emit(OpCodes.Ldstr, "MyBinaryData");
        ilg.EmitCall(OpCodes.Callvirt, getMRS, null);

        // Store the Stream instance.
        ilg.Emit(OpCodes.Stloc_0);

        // Create a label, and associate it with this point
        // in the emitted code.
        Label loop = ilg.DefineLabel();
        ilg.MarkLabel(loop);

        // Load the Stream instance onto the stack, and call
        // its ReadByte method. The return value is on the
        // stack now; store it in location 1 (variable b).
        ilg.Emit(OpCodes.Ldloc_0);
        ilg.EmitCall(OpCodes.Callvirt, rByte, null);
        ilg.Emit(OpCodes.Stloc_1);

        // Load the value on the stack again, and call the
        // WriteLine method to print it.
        ilg.Emit(OpCodes.Ldloc_1);
        ilg.EmitCall(OpCodes.Call, write, null);

        // Load the value one more time; load -1 (minus one)  
        // and compare the two values. If return value from
        // ReadByte was not -1, branch to the label 'loop'.
        ilg.Emit(OpCodes.Ldloc_1);
        ilg.Emit(OpCodes.Ldc_I4_M1);
        ilg.Emit(OpCodes.Ceq);
        ilg.Emit(OpCodes.Brfalse_S, loop);

        // When all the bytes in the stream have been read,
        // return. This is the end of Main.
        ilg.Emit(OpCodes.Ret);

        // Create the type "Example" in the dynamic assembly.
        tb.CreateType();

        // Because the manifest resource was added as an open
        // stream, the data can be written at any time, right up
        // until the assembly is saved. In this case, the data
        // consists of five bytes.
        ms.Write(new byte[] { 105, 36, 74, 97, 109 }, 0, 5);
        ms.SetLength(5);

        // Set the Main method as the entry point for the 
        // assembly, and save the assembly. The manifest resource
        // is read from the memory stream, and appended to the
        // end of the assembly. You can open the assembly with
        // Ildasm and view the resource header for "MyBinaryData".
        asmBuilder.SetEntryPoint(main);
	asmBuilder.Save(asmName.Name + ".exe");

        Console.WriteLine("Now run EmittedManifestResourceAssembly.exe");
    }
}

/* This code example doesn't produce any output. The assembly it
   emits, EmittedManifestResourceAssembly.exe, produces the following
   output:

105
36
74
97
109
-1

 */
//</Snippet1>