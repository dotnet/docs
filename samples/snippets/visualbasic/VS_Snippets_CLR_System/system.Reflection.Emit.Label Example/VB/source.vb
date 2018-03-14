 ' <Snippet1>
Imports System
Imports System.Threading
Imports System.Reflection
Imports System.Reflection.Emit

 _

Class ILLabelDemo
   
   
   Public Shared Function BuildAdderType() As Type
      
      Dim myDomain As AppDomain = Thread.GetDomain()
      Dim myAsmName As New AssemblyName()
      myAsmName.Name = "AdderExceptionAsm"
      Dim myAsmBldr As AssemblyBuilder = myDomain.DefineDynamicAssembly(myAsmName, _
					 		AssemblyBuilderAccess.Run)
      
      Dim myModBldr As ModuleBuilder = myAsmBldr.DefineDynamicModule("AdderExceptionMod")
      
      Dim myTypeBldr As TypeBuilder = myModBldr.DefineType("Adder")
      
      Dim adderParams() As Type = {GetType(Integer), GetType(Integer)}
      
      ' This method will add two numbers which are 100 or less. If either of the
      ' passed integer vales are greater than 100, it will return the value of -1.

      Dim adderBldr As MethodBuilder = myTypeBldr.DefineMethod("DoAdd", _
						MethodAttributes.Public Or MethodAttributes.Static, _
						GetType(Integer), adderParams)
      Dim adderIL As ILGenerator = adderBldr.GetILGenerator()
      
      ' In order to successfully branch, we need to create labels
      ' representing the offset IL instruction block to branch to.
      ' These labels, when the MarkLabel(Label) method is invoked,
      ' will specify the IL instruction to branch to.

      Dim failed As Label = adderIL.DefineLabel()
      Dim endOfMthd As Label = adderIL.DefineLabel()
      
      ' First, load argument 0 and the integer value of "100" onto the
      ' stack. If arg0 > 100, branch to the label "failed", which is marked
      ' as the address of the block that loads -1 onto the stack, bypassing
      ' the addition.

      adderIL.Emit(OpCodes.Ldarg_0)
      adderIL.Emit(OpCodes.Ldc_I4_S, 100)
      adderIL.Emit(OpCodes.Bgt_S, failed)
      
      ' Now, check to see if argument 1 was greater than 100. If it was,
      ' branch to "failed." Otherwise, fall through and perform the addition,
      ' branching unconditionally to the instruction at the label "endOfMthd".

      adderIL.Emit(OpCodes.Ldarg_1)
      adderIL.Emit(OpCodes.Ldc_I4_S, 100)
      adderIL.Emit(OpCodes.Bgt_S, failed)
      
      adderIL.Emit(OpCodes.Ldarg_0)
      adderIL.Emit(OpCodes.Ldarg_1)
      adderIL.Emit(OpCodes.Add_Ovf_Un)
      adderIL.Emit(OpCodes.Br_S, endOfMthd)
      
      ' If this label is branched to (the failure case), load -1 onto the stack
      ' and fall through to the return opcode.

      adderIL.MarkLabel(failed)
      adderIL.Emit(OpCodes.Ldc_I4_M1)
      
      ' The end of the method. If both values were less than 100, the
      ' correct result will return. If one of the arguments was greater
      ' than 100, the result will be -1. 

      adderIL.MarkLabel(endOfMthd)
      adderIL.Emit(OpCodes.Ret)
      
      Return myTypeBldr.CreateType()

   End Function 'BuildAdderType
    
   
   Public Shared Sub Main()
      
      Dim adderType As Type = BuildAdderType()
      
      Dim addIns As Object = Activator.CreateInstance(adderType)
      
      Dim addParams(1) As Object
      
      Console.Write("Enter an integer value: ")
      addParams(0) = CType(Convert.ToInt32(Console.ReadLine()), Object)
      
      Console.Write("Enter another integer value: ")
      addParams(1) = CType(Convert.ToInt32(Console.ReadLine()), Object)
      
      Console.WriteLine("---")
      
      Dim adderResult As Integer = CInt(adderType.InvokeMember("DoAdd", _
					BindingFlags.InvokeMethod, Nothing, _
					addIns, addParams))
      
      If adderResult <> - 1 Then
         
         Console.WriteLine("{0} + {1} = {2}", addParams(0), addParams(1), adderResult)
      
      Else
         
         Console.WriteLine("One of the integers to add was greater than 100!")
      End If 
   End Sub 'Main
End Class 'ILLabelDemo 


' </Snippet1>