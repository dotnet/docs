 ' <Snippet1>
Imports System
Imports System.Threading
Imports System.Reflection
Imports System.Reflection.Emit

Class PropertyBuilderDemo
   
   Public Shared Function BuildDynamicTypeWithProperties() As Type
      Dim myDomain As AppDomain = Thread.GetDomain()
      Dim myAsmName As New AssemblyName()
      myAsmName.Name = "MyDynamicAssembly"
      
      ' To generate a persistable assembly, specify AssemblyBuilderAccess.RunAndSave.
      Dim myAsmBuilder As AssemblyBuilder = myDomain.DefineDynamicAssembly(myAsmName, _
                                                        AssemblyBuilderAccess.RunAndSave)
      
      ' Generate a persistable, single-module assembly.
      Dim myModBuilder As ModuleBuilder = _
          myAsmBuilder.DefineDynamicModule(myAsmName.Name, myAsmName.Name & ".dll")
      
      Dim myTypeBuilder As TypeBuilder = myModBuilder.DefineType("CustomerData", TypeAttributes.Public)
      
      ' Define a private field to hold the property value.
      Dim customerNameBldr As FieldBuilder = myTypeBuilder.DefineField("customerName", _
                                             GetType(String), FieldAttributes.Private)
      
      ' The last argument of DefineProperty is Nothing, because the
      ' property has no parameters. (If you don't specify Nothing, you must
      ' specify an array of Type objects. For a parameterless property,
      ' use an array with no elements: New Type() {})
      Dim custNamePropBldr As PropertyBuilder = _
          myTypeBuilder.DefineProperty("CustomerName", _
                                       PropertyAttributes.HasDefault, _
                                       GetType(String), _
                                       Nothing)
      
      ' The property set and property get methods require a special
      ' set of attributes.
      Dim getSetAttr As MethodAttributes = _
          MethodAttributes.Public Or MethodAttributes.SpecialName _
              Or MethodAttributes.HideBySig

      ' Define the "get" accessor method for CustomerName.
      Dim custNameGetPropMthdBldr As MethodBuilder = _
          myTypeBuilder.DefineMethod("GetCustomerName", _
                                     getSetAttr, _
                                     GetType(String), _
                                     Type.EmptyTypes)
      
      Dim custNameGetIL As ILGenerator = custNameGetPropMthdBldr.GetILGenerator()
      
      custNameGetIL.Emit(OpCodes.Ldarg_0)
      custNameGetIL.Emit(OpCodes.Ldfld, customerNameBldr)
      custNameGetIL.Emit(OpCodes.Ret)
      
      ' Define the "set" accessor method for CustomerName.
      Dim custNameSetPropMthdBldr As MethodBuilder = _
          myTypeBuilder.DefineMethod("get_CustomerName", _
                                     getSetAttr, _
                                     Nothing, _
                                     New Type() {GetType(String)})
      
      Dim custNameSetIL As ILGenerator = custNameSetPropMthdBldr.GetILGenerator()
      
      custNameSetIL.Emit(OpCodes.Ldarg_0)
      custNameSetIL.Emit(OpCodes.Ldarg_1)
      custNameSetIL.Emit(OpCodes.Stfld, customerNameBldr)
      custNameSetIL.Emit(OpCodes.Ret)
      
      ' Last, we must map the two methods created above to our PropertyBuilder to 
      ' their corresponding behaviors, "get" and "set" respectively. 
      custNamePropBldr.SetGetMethod(custNameGetPropMthdBldr)
      custNamePropBldr.SetSetMethod(custNameSetPropMthdBldr)
            
      Dim retval As Type = myTypeBuilder.CreateType()

      ' Save the assembly so it can be examined with Ildasm.exe,
      ' or referenced by a test program.
      myAsmBuilder.Save(myAsmName.Name & ".dll")
      return retval
   End Function 'BuildDynamicTypeWithProperties
    
   
   Public Shared Sub Main()
      Dim custDataType As Type = BuildDynamicTypeWithProperties()
      
      Dim custDataPropInfo As PropertyInfo() = custDataType.GetProperties()
      Dim pInfo As PropertyInfo
      For Each pInfo In  custDataPropInfo
         Console.WriteLine("Property '{0}' created!", pInfo.ToString())
      Next pInfo
      
      Console.WriteLine("---")
      ' Note that when invoking a property, you need to use the proper BindingFlags -
      ' BindingFlags.SetProperty when you invoke the "set" behavior, and 
      ' BindingFlags.GetProperty when you invoke the "get" behavior. Also note that
      ' we invoke them based on the name we gave the property, as expected, and not
      ' the name of the methods we bound to the specific property behaviors.
      Dim custData As Object = Activator.CreateInstance(custDataType)
      custDataType.InvokeMember("CustomerName", BindingFlags.SetProperty, Nothing, _
                                custData, New Object() {"Joe User"})
      
      Console.WriteLine("The customerName field of instance custData has been set to '{0}'.", _
                        custDataType.InvokeMember("CustomerName", BindingFlags.GetProperty, _
                        Nothing, custData, New Object() {}))
   End Sub 'Main
End Class 'PropertyBuilderDemo


' --- O U T P U T ---
' The output should be as follows:
' -------------------
' Property 'System.String CustomerName [System.String]' created!
' ---
' The customerName field of instance custData has been set to 'Joe User'.
' -------------------
' </Snippet1>

