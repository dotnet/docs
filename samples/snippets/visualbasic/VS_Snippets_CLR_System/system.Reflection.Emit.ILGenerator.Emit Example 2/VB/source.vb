' <Snippet1>

Imports System
Imports System.Threading
Imports System.Reflection
Imports System.Reflection.Emit

 _

Class DynamicJumpTableDemo
   
   Public Shared Function BuildMyType() As Type

      Dim myDomain As AppDomain = Thread.GetDomain()
      Dim myAsmName As New AssemblyName()
      myAsmName.Name = "MyDynamicAssembly"
      
      Dim myAsmBuilder As AssemblyBuilder = myDomain.DefineDynamicAssembly(myAsmName, _
							AssemblyBuilderAccess.Run)
      Dim myModBuilder As ModuleBuilder = myAsmBuilder.DefineDynamicModule("MyJumpTableDemo")
      
      Dim myTypeBuilder As TypeBuilder = myModBuilder.DefineType("JumpTableDemo", _
								 TypeAttributes.Public)
      Dim myMthdBuilder As MethodBuilder = myTypeBuilder.DefineMethod("SwitchMe", _
						MethodAttributes.Public Or MethodAttributes.Static, _
						GetType(String), New Type() {GetType(Integer)})
      
      Dim myIL As ILGenerator = myMthdBuilder.GetILGenerator()
      
      Dim defaultCase As Label = myIL.DefineLabel()
      Dim endOfMethod As Label = myIL.DefineLabel()
      
      ' We are initializing our jump table. Note that the labels
      ' will be placed later using the MarkLabel method. 

      Dim jumpTable() As Label = {myIL.DefineLabel(), _
				  myIL.DefineLabel(), _
				  myIL.DefineLabel(), _
				  myIL.DefineLabel(), _
				  myIL.DefineLabel()}
      
      ' arg0, the number we passed, is pushed onto the stack.
      ' In this case, due to the design of the code sample,
      ' the value pushed onto the stack happens to match the
      ' index of the label (in IL terms, the index of the offset
      ' in the jump table). If this is not the case, such as
      ' when switching based on non-integer values, rules for the correspondence
      ' between the possible case values and each index of the offsets
      ' must be established outside of the ILGenerator.Emit calls,
      ' much as a compiler would.

      myIL.Emit(OpCodes.Ldarg_0)
      myIL.Emit(OpCodes.Switch, jumpTable)
      
      ' Branch on default case
      myIL.Emit(OpCodes.Br_S, defaultCase)
      
      ' Case arg0 = 0
      myIL.MarkLabel(jumpTable(0))
      myIL.Emit(OpCodes.Ldstr, "are no bananas")
      myIL.Emit(OpCodes.Br_S, endOfMethod)
      
      ' Case arg0 = 1
      myIL.MarkLabel(jumpTable(1))
      myIL.Emit(OpCodes.Ldstr, "is one banana")
      myIL.Emit(OpCodes.Br_S, endOfMethod)
      
      ' Case arg0 = 2
      myIL.MarkLabel(jumpTable(2))
      myIL.Emit(OpCodes.Ldstr, "are two bananas")
      myIL.Emit(OpCodes.Br_S, endOfMethod)
      
      ' Case arg0 = 3
      myIL.MarkLabel(jumpTable(3))
      myIL.Emit(OpCodes.Ldstr, "are three bananas")
      myIL.Emit(OpCodes.Br_S, endOfMethod)
      
      ' Case arg0 = 4
      myIL.MarkLabel(jumpTable(4))
      myIL.Emit(OpCodes.Ldstr, "are four bananas")
      myIL.Emit(OpCodes.Br_S, endOfMethod)
      
      ' Default case
      myIL.MarkLabel(defaultCase)
      myIL.Emit(OpCodes.Ldstr, "are many bananas")
      
      myIL.MarkLabel(endOfMethod)
      myIL.Emit(OpCodes.Ret)
      
      Return myTypeBuilder.CreateType()

   End Function 'BuildMyType
    
   
   Public Shared Sub Main()

      Dim myType As Type = BuildMyType()
      
      Console.Write("Enter an integer between 0 and 5: ")
      Dim theValue As Integer = Convert.ToInt32(Console.ReadLine())
      
      Console.WriteLine("---")
      Dim myInstance As [Object] = Activator.CreateInstance(myType, New Object() {})
      Console.WriteLine("Yes, there {0} today!", myType.InvokeMember("SwitchMe", _
						 BindingFlags.InvokeMethod, Nothing, _
					         myInstance, New Object() {theValue}))

   End Sub 'Main

End Class 'DynamicJumpTableDemo

' </Snippet1>
