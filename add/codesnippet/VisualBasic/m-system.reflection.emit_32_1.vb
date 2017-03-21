        ' Create an array that specifies the parameter types of the
        ' overload of Console.WriteLine to be used in Hello.
        Dim writeStringArgs() As Type = {GetType(String)}
        ' Get the overload of Console.WriteLine that has one
        ' String parameter.
        Dim writeString As MethodInfo = GetType(Console). _
            GetMethod("WriteLine", writeStringArgs) 

        ' Get an ILGenerator and emit a body for the dynamic method,
        ' using a stream size larger than the IL that will be
        ' emitted.
        Dim il As ILGenerator = hello.GetILGenerator(256)
        ' Load the first argument, which is a string, onto the stack.
        il.Emit(OpCodes.Ldarg_0)
        ' Call the overload of Console.WriteLine that prints a string.
        il.EmitCall(OpCodes.Call, writeString, Nothing)
        ' The Hello method returns the value of the second argument;
        ' to do this, load the onto the stack and return.
        il.Emit(OpCodes.Ldarg_1)
        il.Emit(OpCodes.Ret)