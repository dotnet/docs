'<Snippet1>
Imports System
Imports System.Reflection
Imports System.Reflection.Emit

Class ILThrowExceptionDemo
   
   Public Shared Sub Main()
            
      Dim current As AppDomain = AppDomain.CurrentDomain
      Dim myAsmName As New AssemblyName()
      myAsmName.Name = "AdderExceptionAsm"
      Dim myAsmBldr As AssemblyBuilder = _
                 current.DefineDynamicAssembly(myAsmName, _
                     AssemblyBuilderAccess.RunAndSave)
      
      Dim myModBldr As ModuleBuilder = _
                     myAsmBldr.DefineDynamicModule(myAsmName.Name, _
                         myAsmName.Name & ".dll")
      
      Dim myTypeBldr As TypeBuilder = myModBldr.DefineType("Adder")
      
      Dim adderParams() As Type = {GetType(Integer), GetType(Integer)}
      
      ' This method will add two numbers which are 100 or less. If either of the
      ' passed integer vales are greater than 100, it will throw an exception.
      Dim adderBldr As MethodBuilder = myTypeBldr.DefineMethod("DoAdd", _
                  MethodAttributes.Public Or MethodAttributes.Static, _
                  GetType(Integer), adderParams)
      Dim adderIL As ILGenerator = adderBldr.GetILGenerator()

      ' Types and methods used in the code to throw, catch, and
      ' display OverflowException. Note that if the catch block were
      ' for a more general type, such as Exception, we would need 
      ' a MethodInfo for that type's ToString method.
      ' 
      Dim overflow As Type = GetType(OverflowException)
      Dim exCtorInfo As ConstructorInfo = overflow.GetConstructor( _
                     New Type() {GetType(String)})
      Dim exToStrMI As MethodInfo = overflow.GetMethod("ToString")
      Dim writeLineMI As MethodInfo = GetType(Console).GetMethod("WriteLine", _
                     New Type() {GetType(String), _
                            GetType(Object)})
      
      Dim tmp1 As LocalBuilder = adderIL.DeclareLocal(GetType(Integer))
      Dim tmp2 As LocalBuilder = adderIL.DeclareLocal(overflow)
      
      ' In order to successfully branch, we need to create labels
      ' representing the offset IL instruction block to branch to.
      ' These labels, when the MarkLabel(Label) method is invoked,
      ' will specify the IL instruction to branch to.
      '
      Dim failed As Label = adderIL.DefineLabel()
      Dim endOfMthd As Label = adderIL.DefineLabel()

      ' Begin the try block.      
      Dim exBlock As Label = adderIL.BeginExceptionBlock()

      ' First, load argument 0 and the integer value of "100" onto the
      ' stack. If arg0 > 100, branch to the label "failed", which is marked
      ' as the address of the block that throws an exception.
      '
      adderIL.Emit(OpCodes.Ldarg_0)
      adderIL.Emit(OpCodes.Ldc_I4_S, 100)
      adderIL.Emit(OpCodes.Bgt_S, failed)
      
      ' Now, check to see if argument 1 was greater than 100. If it was,
      ' branch to "failed." Otherwise, fall through and perform the addition,
      ' branching unconditionally to the instruction at the label "endOfMthd".
      '
      adderIL.Emit(OpCodes.Ldarg_1)
      adderIL.Emit(OpCodes.Ldc_I4_S, 100)
      adderIL.Emit(OpCodes.Bgt_S, failed)
      
      adderIL.Emit(OpCodes.Ldarg_0)
      adderIL.Emit(OpCodes.Ldarg_1)
      adderIL.Emit(OpCodes.Add_Ovf_Un)
      ' Store the result of the addition.
      adderIL.Emit(OpCodes.Stloc_S, tmp1)
      adderIL.Emit(OpCodes.Br_S, endOfMthd)
      
      ' If one of the arguments was greater than 100, we need to throw an
      ' exception. We'll use "OverflowException" with a customized message.
      ' First, we load our message onto the stack, and then create a new
      ' exception object using the constructor overload that accepts a
      ' string message.
      adderIL.MarkLabel(failed)
      adderIL.Emit(OpCodes.Ldstr, "Cannot accept values over 100 for add.")
      adderIL.Emit(OpCodes.Newobj, exCtorInfo)
      
      ' Throw the exception now on the stack.
      adderIL.ThrowException(overflow)
      
      ' Start the catch block for OverflowException.
      '
      adderIL.BeginCatchBlock(overflow)

      ' When we enter the catch block, the thrown exception 
      ' is on the stack. Store it, then load the format string
      ' for WriteLine. 
      '
      adderIL.Emit(OpCodes.Stloc_S, tmp2)
      adderIL.Emit(OpCodes.Ldstr, "Caught {0}")

      ' Push the thrown exception back on the stack, then 
      ' call its ToString() method. Note that if this catch block
      ' were for a more general exception type, like Exception,
      ' it would be necessary to use the ToString for that type.
      '
      adderIL.Emit(OpCodes.Ldloc_S, tmp2)
      adderIL.EmitCall(OpCodes.Callvirt, exToStrMI, Nothing)
      
      ' The format string and the return value from ToString() are
      ' now on the stack. Call WriteLine(string, object).
      '
      adderIL.EmitCall(OpCodes.Call, writeLineMI, Nothing)
      
      ' Since our function has to return an integer value, load -1 onto
      ' the stack to indicate an error, and store it in local variable
      ' tmp1.
      adderIL.Emit(OpCodes.Ldc_I4_M1)
      adderIL.Emit(OpCodes.Stloc_S, tmp1)
      
      ' End the exception handling block.

      adderIL.EndExceptionBlock()
      
      ' The end of the method. If no exception was thrown, the correct value
      ' will be saved in tmp1. If an exception was thrown, tmp1 will be equal
      ' to -1. Either way, we'll load the value of tmp1 onto the stack and return.
      '
      adderIL.MarkLabel(endOfMthd)
      adderIL.Emit(OpCodes.Ldloc_S, tmp1)
      adderIL.Emit(OpCodes.Ret)
      
      Dim adderType As Type = myTypeBldr.CreateType()

      Dim addIns As Object = Activator.CreateInstance(adderType)
      
      Dim addParams(1) As Object
      
      Console.Write("Enter an integer value: ")
      addParams(0) = CType(Convert.ToInt32(Console.ReadLine()), Object)
      
      Console.Write("Enter another integer value: ")
      addParams(1) = CType(Convert.ToInt32(Console.ReadLine()), Object)
      
      Console.WriteLine("If either integer was > 100, an exception will be thrown.")
      Console.WriteLine("---")
      
      Console.WriteLine("{0} + {1} = {2}", addParams(0), addParams(1), _
         adderType.InvokeMember("DoAdd", BindingFlags.InvokeMethod, _
                  Nothing, addIns, addParams))
   End Sub 

End Class 

' This code example produces output similar to the following:
'
'Enter an integer value: 24
'Enter another integer value: 101
'If either integer was > 100, an exception will be thrown.
'---
'Caught System.OverflowException: Arithmetic operation resulted in an overflow.
'   at Adder.DoAdd(Int32 , Int32 )
'24 + 101 = -1
'</Snippet1>