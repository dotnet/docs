' Created by REDMOND\glennha for Whidbey.
'<Snippet1>
Imports System
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.IO

Public Class Example
    
    Public Shared Sub Main() 

        ' Define a dynamic assembly with one module. The module
        ' name and the assembly name are the same.
        Dim asmName As New AssemblyName("EmittedManifestResourceAssembly")
        Dim asmBuilder As AssemblyBuilder = _
            AppDomain.CurrentDomain.DefineDynamicAssembly( _
                asmName, _
                AssemblyBuilderAccess.RunAndSave _
            )
        Dim modBuilder As ModuleBuilder = _
            asmBuilder.DefineDynamicModule( _
                asmName.Name, _
                asmName.Name + ".exe" _
            )
        
        ' Create a memory stream for the unmanaged resource data.
        ' You can use any stream; for example, you might read the
        ' unmanaged resource data from a binary file. It is not
        ' necessary to put any data into the stream right now.
        Dim ms As New MemoryStream(1024)
        
        ' Define a public manifest resource with the name 
        ' "MyBinaryData, and associate it with the memory stream.
        modBuilder.DefineManifestResource( _
            "MyBinaryData", _
            ms, _
            ResourceAttributes.Public _
        )
        
        ' Create a type with a public static Main method that will
        ' be the entry point for the emitted assembly. 
        '
        ' The purpose of the Main method in this example is to read 
        ' the manifest resource and display it, byte by byte.
        '
        Dim tb As TypeBuilder = modBuilder.DefineType("Example")
        Dim main As MethodBuilder = tb.DefineMethod( _
            "Main", _
            MethodAttributes.Public Or MethodAttributes.Static _
        )
        
        ' The Main method uses the Assembly type and the Stream
        ' type. 
        Dim asm As Type = GetType([Assembly])
        Dim str As Type = GetType(Stream)
        
        ' Get MethodInfo objects for the methods called by 
        ' Main.
        Dim getEx As MethodInfo = asm.GetMethod("GetExecutingAssembly")
        ' Use the overload of GetManifestResourceStream that 
        ' takes one argument, a string.
        Dim getMRS As MethodInfo = asm.GetMethod( _
            "GetManifestResourceStream", _
            New Type() {GetType(String)} _
        )
        Dim rByte As MethodInfo = str.GetMethod("ReadByte")
        ' Use the overload of WriteLine that writes an Int32.
        Dim write As MethodInfo = GetType(Console).GetMethod( _
            "WriteLine", _
            New Type() {GetType(Integer)} _
        )
        
        Dim ilg As ILGenerator = main.GetILGenerator()
        
        ' Main uses two local variables: the instance of the
        ' stream returned by GetManifestResourceStream, and 
        ' the value returned by ReadByte. The load and store 
        ' instructions refer to these locals by position  
        ' (0 and 1).
        Dim s As LocalBuilder = ilg.DeclareLocal(str)
        Dim b As LocalBuilder = ilg.DeclareLocal(GetType(Integer))
        
        ' Call the static Assembly.GetExecutingAssembly() method,
        ' which leaves the assembly instance on the stack. Push the
        ' string name of the resource on the stack, and call the
        ' GetManifestResourceStream(string) method of the assembly
        ' instance.
        ilg.EmitCall(OpCodes.Call, getEx, Nothing)
        ilg.Emit(OpCodes.Ldstr, "MyBinaryData")
        ilg.EmitCall(OpCodes.Callvirt, getMRS, Nothing)
        
        ' Store the Stream instance.
        ilg.Emit(OpCodes.Stloc_0)
        
        ' Create a label, and associate it with this point
        ' in the emitted code.
        Dim theLoop As Label = ilg.DefineLabel()
        ilg.MarkLabel(theLoop)
        
        ' Load the Stream instance onto the stack, and call
        ' its ReadByte method. The return value is on the
        ' stack now; store it in location 1 (variable b).
        ilg.Emit(OpCodes.Ldloc_0)
        ilg.EmitCall(OpCodes.Callvirt, rByte, Nothing)
        ilg.Emit(OpCodes.Stloc_1)
        
        ' Load the value on the stack again, and call the
        ' WriteLine method to print it.
        ilg.Emit(OpCodes.Ldloc_1)
        ilg.EmitCall(OpCodes.Call, write, Nothing)
        
        ' Load the value one more time; load -1 (minus one)  
        ' and compare the two values. If return value from
        ' ReadByte was not -1, branch to the label 'loop'.
        ilg.Emit(OpCodes.Ldloc_1)
        ilg.Emit(OpCodes.Ldc_I4_M1)
        ilg.Emit(OpCodes.Ceq)
        ilg.Emit(OpCodes.Brfalse_S, theLoop)
        
        ' When all the bytes in the stream have been read,
        ' return. This is the end of Main.
        ilg.Emit(OpCodes.Ret)
        
        ' Create the type "Example" in the dynamic assembly.
        tb.CreateType()
        
        ' Because the manifest resource was added as an open
        ' stream, the data can be written at any time, right up
        ' until the assembly is saved. In this case, the data
        ' consists of five bytes.
        ms.Write(New Byte() {105, 36, 74, 97, 109}, 0, 5)
        ms.SetLength(5)
        
        ' Set the Main method as the entry point for the 
        ' assembly, and save the assembly. The manifest resource
        ' is read from the memory stream, and appended to the
        ' end of the assembly. You can open the assembly with
        ' Ildasm and view the resource header for "MyBinaryData".
        asmBuilder.SetEntryPoint(main)
        asmBuilder.Save(asmName.Name + ".exe")
        
        Console.WriteLine("Now run EmittedManifestResourceAssembly.exe")
    
    End Sub 
End Class 

' This code example doesn't produce any output. The assembly it
' emits, EmittedManifestResourceAssembly.exe, produces the following
' output:
'
'105
'36
'74
'97
'109
'-1
'
'</Snippet1>
