
'  System.Reflection.ParameterInfo.IsIn
'  System.Reflection.ParameterInfo.IsOptional
'  System.Reflection.ParameterInfo.IsOut

'  The following program creates a dynamic assembly named 'MyAssembly', defines a
'  module named 'MyModule' within the assembly. It defines a type called 'MyType'
'  within the module and also defines a static method named 'MyMethod' for the 
'  type. This dynamic assembly is then queried for the type defined within it and
'  then the attributes of all the parameters of the method named 'MyMethod' is 
'  displayed.

' <Snippet1>
' <Snippet2>
' <Snippet3>
Imports System
Imports System.Reflection
Imports System.Threading
Imports System.Reflection.Emit
Imports Microsoft.VisualBasic



Public Class ParameterInfo_IsIn_IsOut_IsOptional
   
   Public Shared Sub DefineMethod()
      Dim myAssemblyName As New AssemblyName()
      myAssemblyName.Name = "MyAssembly"
      ' Get the assesmbly builder from the application domain associated with the current thread.
      Dim myAssemblyBuilder As AssemblyBuilder = Thread.GetDomain().DefineDynamicAssembly(myAssemblyName, AssemblyBuilderAccess.RunAndSave)
      ' Create a dynamic module in the assembly.
      Dim myModuleBuilder As ModuleBuilder = myAssemblyBuilder.DefineDynamicModule("MyModule", "MyAssembly.dll")
      ' Create a type in the module.
      Dim myTypeBuilder As TypeBuilder = myModuleBuilder.DefineType("MyType")
      ' Create a method called MyMethod.
      Dim myMethodBuilder As MethodBuilder = myTypeBuilder.DefineMethod("MyMethod", MethodAttributes.Public Or MethodAttributes.HideBySig Or MethodAttributes.Static, GetType(String), New Type() {GetType(Integer), GetType(Short), GetType(Long)})
      ' Set the attributes for the parameters of the method.
      ' Set the attribute for the first parameter to IN.
      Dim myParameterBuilder As ParameterBuilder = myMethodBuilder.DefineParameter(1, ParameterAttributes.In, "MyIntParameter")
      ' Set the attribute for the second parameter to OUT.
      myParameterBuilder = myMethodBuilder.DefineParameter(2, ParameterAttributes.Out, "MyShortParameter")
      ' Set the attribute for the third parameter to OPTIONAL.
      myParameterBuilder = myMethodBuilder.DefineParameter(3, ParameterAttributes.Optional Or ParameterAttributes.HasDefault, "MyLongParameter")
      ' Get the Microsoft Intermediate Language generator for the method.
      Dim myILGenerator As ILGenerator = myMethodBuilder.GetILGenerator()
      ' Use the utility method to generate the MSIL instructions that print a string to the console.
      myILGenerator.EmitWriteLine("Hello World!")
      ' Generate the "ret" MSIL instruction.
      myILGenerator.Emit(OpCodes.Ret)
      ' End the creation of the type.
      myTypeBuilder.CreateType()
   End Sub 'DefineMethod
   
   
   Public Shared Sub Main()
      ' Create a dynamic assembly with a type named 'MyType'.
      DefineMethod()
      
      ' Get the assemblies currently loaded in the application domain.
      Dim myAssemblies As [Assembly]() = Thread.GetDomain().GetAssemblies()
      Dim myAssembly As [Assembly] = Nothing
      ' Get the assembly named MyAssembly.
      Dim i As Integer
      For i = 0 To myAssemblies.Length - 1
         If [String].Compare(myAssemblies(i).GetName(False).Name, "MyAssembly") = 0 Then
            myAssembly = myAssemblies(i)
         End If 
      Next i
      If Not (myAssembly Is Nothing) Then
         ' Get a type named MyType.
         Dim myType As Type = myAssembly.GetType("MyType")
         ' Get a method named MyMethod from the type.
         Dim myMethodBase As MethodBase = myType.GetMethod("MyMethod")
         ' Get the parameters associated with the method.
         Dim myParameters As ParameterInfo() = myMethodBase.GetParameters()
         Console.WriteLine(ControlChars.Cr + "The method {0} has the {1} parameters :", myMethodBase, myParameters.Length)
         ' Print the IN, OUT and OPTIONAL attributes associated with each of the parameters.
         For i = 0 To myParameters.Length - 1
            If myParameters(i).IsIn Then
               Console.WriteLine(ControlChars.Tab + "The {0} parameter has the In attribute", i + 1)
            End If
            If myParameters(i).IsOptional Then
               Console.WriteLine(ControlChars.Tab + "The {0} parameter has the Optional attribute", i + 1)
            End If
            If myParameters(i).IsOut Then
               Console.WriteLine(ControlChars.Tab + "The {0} parameter has the Out attribute", i + 1)
            End If
         Next i
      Else
         Console.WriteLine("Could not find a assembly named 'MyAssembly' for the current application domain")
      End If
   End Sub 'Main
End Class 'ParameterInfo_IsIn_IsOut_IsOptional 
' </Snippet3>
' </Snippet2>
' </Snippet1>