 ' <Snippet1>
Imports System
Imports System.Threading
Imports System.Reflection
Imports System.Reflection.Emit

 _

Class MethodBodyDemo
   
   ' This class will demonstrate how to create a method body using 
   ' the MethodBuilder.CreateMethodBody(byte[], int) method.

   Public Shared Function BuildDynType() As Type
      
      Dim addType As Type = Nothing
      
      Dim currentDom As AppDomain = Thread.GetDomain()
      
      Dim myAsmName As New AssemblyName()
      myAsmName.Name = "MyDynamicAssembly"
      
      Dim myAsmBldr As AssemblyBuilder = currentDom.DefineDynamicAssembly(myAsmName, _
				         AssemblyBuilderAccess.RunAndSave)
      
      ' The dynamic assembly space has been created.  Next, create a module
      ' within it.  The type Point will be reflected into this module.
      Dim myModuleBldr As ModuleBuilder = myAsmBldr.DefineDynamicModule("MyModule")
      
      Dim myTypeBldr As TypeBuilder = myModuleBldr.DefineType("Adder")
      
      Dim myMthdBldr As MethodBuilder = myTypeBldr.DefineMethod("DoAdd", _
					MethodAttributes.Public Or MethodAttributes.Static, _
				        GetType(Integer), _
					New Type() {GetType(Integer), GetType(Integer)})

      ' Build the array of Bytes holding the MSIL instructions.

      Dim ILcodes() As Byte = {&H2, &H3, &H58, &H2A}

      ' 02h is the opcode for ldarg.0 
      ' 03h is the opcode for ldarg.1 
      ' 58h is the opcode for add     
      ' 2Ah is the opcode for ret     
      
      myMthdBldr.CreateMethodBody(ILcodes, ILcodes.Length)
      
      addType = myTypeBldr.CreateType()
      
      Return addType

   End Function 'BuildDynType
   
   
   Public Shared Sub Main()
      
      Dim myType As Type = BuildDynType()
      Console.WriteLine("---")
      Console.Write("Enter the first integer to add: ")
      Dim aVal As Integer = Convert.ToInt32(Console.ReadLine())
      
      Console.Write("Enter the second integer to add: ")
      Dim bVal As Integer = Convert.ToInt32(Console.ReadLine())
      
      Dim adderInst As Object = Activator.CreateInstance(myType, New Object() {})
      
      Console.WriteLine("The value of adding {0} to {1} is: {2}.", _
			 aVal, bVal, _
			 myType.InvokeMember("DoAdd", _
					      BindingFlags.InvokeMethod, _
					      Nothing, _
					      adderInst, _
					      New Object() {aVal, bVal}))

   End Sub 'Main

End Class 'MethodBodyDemo


' </Snippet1>