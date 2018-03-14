 ' <Snippet1>
Imports System
Imports System.Text
Imports System.Threading
Imports System.Reflection
Imports System.Reflection.Emit

 _

' The Point class is the class we will reflect on and copy into our
' dynamic assembly. The public static function PointMain() will be used
' as our entry point.
'
' We are constructing the type seen here dynamically, and will write it
' out into a .exe file for later execution from the command-line.
' --- 
' Class Point
'    
'    Private x As Integer
'    Private y As Integer
'    
'    
'    Public Sub New(ix As Integer, iy As Integer)
'       
'       Me.x = ix
'       Me.y = iy
'    End Sub 'New
'     
'    
'    Public Function DotProduct(p As Point) As Integer
'       
'       Return Me.x * p.x + Me.y * p.y
'    End Function 'DotProduct
'     
'    
'    Public Shared Sub Main()
'       
'       Console.Write("Enter the 'x' value for point 1: ")
'       Dim x1 As Integer = Convert.ToInt32(Console.ReadLine())
'       
'       Console.Write("Enter the 'y' value for point 1: ")
'       Dim y1 As Integer = Convert.ToInt32(Console.ReadLine())
'       
'       Console.Write("Enter the 'x' value for point 2: ")
'       Dim x2 As Integer = Convert.ToInt32(Console.ReadLine())
'       
'       Console.Write("Enter the 'y' value for point 2: ")
'       Dim y2 As Integer = Convert.ToInt32(Console.ReadLine())
'       
'       Dim p1 As New Point(x1, y1)
'       Dim p2 As New Point(x2, y2)
'       
'       Console.WriteLine("({0}, {1}) . ({2}, {3}) = {4}.", x1, y1, x2, y2, p1.DotProduct(p2))
'    End Sub 'Main
' End Class 'Point 
' ---
Class AssemblyBuilderDemo
   
   
   Public Shared Function BuildDynAssembly() As Type
      
      Dim pointType As Type = Nothing
      
      Dim currentDom As AppDomain = Thread.GetDomain()
      
      Console.Write("Please enter a name for your new assembly: ")
      Dim asmFileNameBldr As New StringBuilder()
      asmFileNameBldr.Append(Console.ReadLine())
      asmFileNameBldr.Append(".exe")
      Dim asmFileName As String = asmFileNameBldr.ToString()
      
      Dim myAsmName As New AssemblyName()
      myAsmName.Name = "MyDynamicAssembly"
      
      Dim myAsmBldr As AssemblyBuilder = currentDom.DefineDynamicAssembly(myAsmName, _
					 AssemblyBuilderAccess.RunAndSave)
      
      ' We've created a dynamic assembly space - now, we need to create a module
      ' within it to reflect the type Point into.
      Dim myModuleBldr As ModuleBuilder = myAsmBldr.DefineDynamicModule(asmFileName, _
									asmFileName)
      
      Dim myTypeBldr As TypeBuilder = myModuleBldr.DefineType("Point")
      
      Dim xField As FieldBuilder = myTypeBldr.DefineField("x", GetType(Integer), _
						          FieldAttributes.Private)
      Dim yField As FieldBuilder = myTypeBldr.DefineField("y", GetType(Integer), _
					 		  FieldAttributes.Private)
      
      ' Build the constructor.
      Dim objType As Type = Type.GetType("System.Object")
      Dim objCtor As ConstructorInfo = objType.GetConstructor(New Type() {})
      
      Dim ctorParams() As Type = {GetType(Integer), GetType(Integer)}
      Dim pointCtor As ConstructorBuilder = myTypeBldr.DefineConstructor( _
					    MethodAttributes.Public, _
					    CallingConventions.Standard, _
					    ctorParams)
      Dim ctorIL As ILGenerator = pointCtor.GetILGenerator()
      ctorIL.Emit(OpCodes.Ldarg_0)
      ctorIL.Emit(OpCodes.Call, objCtor)
      ctorIL.Emit(OpCodes.Ldarg_0)
      ctorIL.Emit(OpCodes.Ldarg_1)
      ctorIL.Emit(OpCodes.Stfld, xField)
      ctorIL.Emit(OpCodes.Ldarg_0)
      ctorIL.Emit(OpCodes.Ldarg_2)
      ctorIL.Emit(OpCodes.Stfld, yField)
      ctorIL.Emit(OpCodes.Ret)
      
      ' Build the DotProduct method.
      Console.WriteLine("Constructor built.")
      
      Dim pointDPBldr As MethodBuilder = myTypeBldr.DefineMethod("DotProduct", _
								 MethodAttributes.Public, _
								 GetType(Integer), _
								 New Type(0) {myTypeBldr})
      
      Dim dpIL As ILGenerator = pointDPBldr.GetILGenerator()
      dpIL.Emit(OpCodes.Ldarg_0)
      dpIL.Emit(OpCodes.Ldfld, xField)
      dpIL.Emit(OpCodes.Ldarg_1)
      dpIL.Emit(OpCodes.Ldfld, xField)
      dpIL.Emit(OpCodes.Mul_Ovf_Un)
      dpIL.Emit(OpCodes.Ldarg_0)
      dpIL.Emit(OpCodes.Ldfld, yField)
      dpIL.Emit(OpCodes.Ldarg_1)
      dpIL.Emit(OpCodes.Ldfld, yField)
      dpIL.Emit(OpCodes.Mul_Ovf_Un)
      dpIL.Emit(OpCodes.Add_Ovf_Un)
      dpIL.Emit(OpCodes.Ret)
      
      ' Build the PointMain method.
      Console.WriteLine("DotProduct built.")
      
      Dim pointMainBldr As MethodBuilder = myTypeBldr.DefineMethod("PointMain", _
						      MethodAttributes.Public Or _
						      MethodAttributes.Static, _
						      Nothing, Nothing)
      pointMainBldr.InitLocals = True
      Dim pmIL As ILGenerator = pointMainBldr.GetILGenerator()
      
      ' We have four methods that we wish to call, and must represent as
      ' MethodInfo tokens:
      ' - Sub Console.WriteLine(string)
      ' - Function Console.ReadLine() As String
      ' - Function Convert.Int32(string) As Int
      ' - Sub Console.WriteLine(string, object[])

      Dim writeMI As MethodInfo = GetType(Console).GetMethod("Write", _
					           New Type(0) {GetType(String)}) 
								     
      Dim readLineMI As MethodInfo = GetType(Console).GetMethod("ReadLine", _
						      New Type() {})
      Dim convertInt32MI As MethodInfo = GetType(Convert).GetMethod("ToInt32", _
							  New Type(0) {GetType(String)})
      Dim wlParams() As Type = {GetType(String), GetType(Object())}
      Dim writeLineMI As MethodInfo = GetType(Console).GetMethod("WriteLine", wlParams)
      
      ' Although we could just refer to the local variables by
      ' index (short ints for Ldloc/Stloc, bytes for LdLoc_S/Stloc_S),
      ' this time, we'll use LocalBuilders for clarity and to
      ' demonstrate their usage and syntax.

      Dim x1LB As LocalBuilder = pmIL.DeclareLocal(GetType(Integer))
      Dim y1LB As LocalBuilder = pmIL.DeclareLocal(GetType(Integer))
      Dim x2LB As LocalBuilder = pmIL.DeclareLocal(GetType(Integer))
      Dim y2LB As LocalBuilder = pmIL.DeclareLocal(GetType(Integer))
      Dim point1LB As LocalBuilder = pmIL.DeclareLocal(myTypeBldr)
      Dim point2LB As LocalBuilder = pmIL.DeclareLocal(myTypeBldr)
      Dim tempObjArrLB As LocalBuilder = pmIL.DeclareLocal(GetType(Object()))
      
      pmIL.Emit(OpCodes.Ldstr, "Enter the 'x' value for point 1: ")
      pmIL.EmitCall(OpCodes.Call, writeMI, Nothing)
      pmIL.EmitCall(OpCodes.Call, readLineMI, Nothing)
      pmIL.EmitCall(OpCodes.Call, convertInt32MI, Nothing)
      pmIL.Emit(OpCodes.Stloc, x1LB)
      
      pmIL.Emit(OpCodes.Ldstr, "Enter the 'y' value for point 1: ")
      pmIL.EmitCall(OpCodes.Call, writeMI, Nothing)
      pmIL.EmitCall(OpCodes.Call, readLineMI, Nothing)
      pmIL.EmitCall(OpCodes.Call, convertInt32MI, Nothing)
      pmIL.Emit(OpCodes.Stloc, y1LB)
      
      pmIL.Emit(OpCodes.Ldstr, "Enter the 'x' value for point 2: ")
      pmIL.EmitCall(OpCodes.Call, writeMI, Nothing)
      pmIL.EmitCall(OpCodes.Call, readLineMI, Nothing)
      pmIL.EmitCall(OpCodes.Call, convertInt32MI, Nothing)
      pmIL.Emit(OpCodes.Stloc, x2LB)
      
      pmIL.Emit(OpCodes.Ldstr, "Enter the 'y' value for point 2: ")
      pmIL.EmitCall(OpCodes.Call, writeMI, Nothing)
      pmIL.EmitCall(OpCodes.Call, readLineMI, Nothing)
      pmIL.EmitCall(OpCodes.Call, convertInt32MI, Nothing)
      pmIL.Emit(OpCodes.Stloc, y2LB)
      
      pmIL.Emit(OpCodes.Ldloc, x1LB)
      pmIL.Emit(OpCodes.Ldloc, y1LB)
      pmIL.Emit(OpCodes.Newobj, pointCtor)
      pmIL.Emit(OpCodes.Stloc, point1LB)
      
      pmIL.Emit(OpCodes.Ldloc, x2LB)
      pmIL.Emit(OpCodes.Ldloc, y2LB)
      pmIL.Emit(OpCodes.Newobj, pointCtor)
      pmIL.Emit(OpCodes.Stloc, point2LB)
      
      pmIL.Emit(OpCodes.Ldstr, "({0}, {1}) . ({2}, {3}) = {4}.")
      pmIL.Emit(OpCodes.Ldc_I4_5)
      pmIL.Emit(OpCodes.Newarr, GetType([Object]))
      pmIL.Emit(OpCodes.Stloc, tempObjArrLB)
      
      pmIL.Emit(OpCodes.Ldloc, tempObjArrLB)
      pmIL.Emit(OpCodes.Ldc_I4_0)
      pmIL.Emit(OpCodes.Ldloc, x1LB)
      pmIL.Emit(OpCodes.Box, GetType(Integer))
      pmIL.Emit(OpCodes.Stelem_Ref)
      
      pmIL.Emit(OpCodes.Ldloc, tempObjArrLB)
      pmIL.Emit(OpCodes.Ldc_I4_1)
      pmIL.Emit(OpCodes.Ldloc, y1LB)
      pmIL.Emit(OpCodes.Box, GetType(Integer))
      pmIL.Emit(OpCodes.Stelem_Ref)
      
      pmIL.Emit(OpCodes.Ldloc, tempObjArrLB)
      pmIL.Emit(OpCodes.Ldc_I4_2)
      pmIL.Emit(OpCodes.Ldloc, x2LB)
      pmIL.Emit(OpCodes.Box, GetType(Integer))
      pmIL.Emit(OpCodes.Stelem_Ref)
      
      pmIL.Emit(OpCodes.Ldloc, tempObjArrLB)
      pmIL.Emit(OpCodes.Ldc_I4_3)
      pmIL.Emit(OpCodes.Ldloc, y2LB)
      pmIL.Emit(OpCodes.Box, GetType(Integer))
      pmIL.Emit(OpCodes.Stelem_Ref)
      
      pmIL.Emit(OpCodes.Ldloc, tempObjArrLB)
      pmIL.Emit(OpCodes.Ldc_I4_4)
      pmIL.Emit(OpCodes.Ldloc, point1LB)
      pmIL.Emit(OpCodes.Ldloc, point2LB)
      pmIL.EmitCall(OpCodes.Callvirt, pointDPBldr, Nothing)
      
      pmIL.Emit(OpCodes.Box, GetType(Integer))
      pmIL.Emit(OpCodes.Stelem_Ref)
      pmIL.Emit(OpCodes.Ldloc, tempObjArrLB)
      pmIL.EmitCall(OpCodes.Call, writeLineMI, Nothing)
      
      pmIL.Emit(OpCodes.Ret)
      
      Console.WriteLine("PointMain (entry point) built.")
      
      pointType = myTypeBldr.CreateType()
      
      Console.WriteLine("Type completed.")
      
      myAsmBldr.SetEntryPoint(pointMainBldr)
      
      myAsmBldr.Save(asmFileName)
      
      Console.WriteLine("Assembly saved as '{0}'.", asmFileName)
      Console.WriteLine("Type '{0}' at the prompt to run your new " + "dynamically generated dot product calculator.", asmFileName)
      
      ' After execution, this program will have generated and written to disk,
      ' in the directory you executed it from, a program named 
      ' <name_you_entered_here>.exe. You can run it by typing
      ' the name you gave it during execution, in the same directory where
      ' you executed this program.

      Return pointType

   End Function 'BuildDynAssembly
    
   
   Public Shared Sub Main()
      
      Dim myType As Type = BuildDynAssembly()
      Console.WriteLine("---")
      
      ' Let's invoke the type 'Point' created in our dynamic assembly. 
      Dim ptInstance As Object = Activator.CreateInstance(myType, New Object(1) {0, 0})
      
      myType.InvokeMember("PointMain", BindingFlags.InvokeMethod, _
			  Nothing, ptInstance, New Object() {})

   End Sub 'Main

End Class 'AssemblyBuilderDemo





' </Snippet1>