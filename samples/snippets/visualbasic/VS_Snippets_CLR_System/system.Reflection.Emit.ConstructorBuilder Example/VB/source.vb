' <Snippet1>

Imports System
Imports System.Threading
Imports System.Reflection
Imports System.Reflection.Emit

 _

Class TestCtorBuilder
   
   
   Public Shared Function DynamicPointTypeGen() As Type
      
      Dim pointType As Type = Nothing
      Dim ctorParams() As Type = {GetType(Integer), GetType(Integer), GetType(Integer)}
      
      Dim myDomain As AppDomain = Thread.GetDomain()
      Dim myAsmName As New AssemblyName()
      myAsmName.Name = "MyDynamicAssembly"
      
      Dim myAsmBuilder As AssemblyBuilder = myDomain.DefineDynamicAssembly(myAsmName, AssemblyBuilderAccess.RunAndSave)
      
      Dim pointModule As ModuleBuilder = myAsmBuilder.DefineDynamicModule("PointModule", "Point.dll")
      
      Dim pointTypeBld As TypeBuilder = pointModule.DefineType("Point", TypeAttributes.Public)
      
      Dim xField As FieldBuilder = pointTypeBld.DefineField("x", GetType(Integer), FieldAttributes.Public)
      Dim yField As FieldBuilder = pointTypeBld.DefineField("y", GetType(Integer), FieldAttributes.Public)
      Dim zField As FieldBuilder = pointTypeBld.DefineField("z", GetType(Integer), FieldAttributes.Public)
      
      Dim objType As Type = Type.GetType("System.Object")
      Dim objCtor As ConstructorInfo = objType.GetConstructor(New Type() {})
      
      Dim pointCtor As ConstructorBuilder = pointTypeBld.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, ctorParams)
      Dim ctorIL As ILGenerator = pointCtor.GetILGenerator()
      
      ' NOTE: ldarg.0 holds the "this" reference - ldarg.1, ldarg.2, and ldarg.3
      ' hold the actual passed parameters. ldarg.0 is used by instance methods
      ' to hold a reference to the current calling object instance. Static methods
      ' do not use arg.0, since they are not instantiated and hence no reference
      ' is needed to distinguish them. 
      ctorIL.Emit(OpCodes.Ldarg_0)
      
      ' Here, we wish to create an instance of System.Object by invoking its
      ' constructor, as specified above.
      ctorIL.Emit(OpCodes.Call, objCtor)
      
      ' Now, we'll load the current instance ref in arg 0, along
      ' with the value of parameter "x" stored in arg 1, into stfld.
      ctorIL.Emit(OpCodes.Ldarg_0)
      ctorIL.Emit(OpCodes.Ldarg_1)
      ctorIL.Emit(OpCodes.Stfld, xField)
      
      ' Now, we store arg 2 "y" in the current instance with stfld.
      ctorIL.Emit(OpCodes.Ldarg_0)
      ctorIL.Emit(OpCodes.Ldarg_2)
      ctorIL.Emit(OpCodes.Stfld, yField)
      
      ' Last of all, arg 3 "z" gets stored in the current instance.
      ctorIL.Emit(OpCodes.Ldarg_0)
      ctorIL.Emit(OpCodes.Ldarg_3)
      ctorIL.Emit(OpCodes.Stfld, zField)
      
      ' Our work complete, we return.
      ctorIL.Emit(OpCodes.Ret)
      
      ' Now, let's create three very simple methods so we can see our fields.
      Dim mthdNames() As String = {"GetX", "GetY", "GetZ"}
      
      Dim mthdName As String
      For Each mthdName In  mthdNames
         Dim getFieldMthd As MethodBuilder = pointTypeBld.DefineMethod(mthdName, MethodAttributes.Public, GetType(Integer), Nothing)
         Dim mthdIL As ILGenerator = getFieldMthd.GetILGenerator()
         
         mthdIL.Emit(OpCodes.Ldarg_0)
         Select Case mthdName
            Case "GetX"
               mthdIL.Emit(OpCodes.Ldfld, xField)
            Case "GetY"
               mthdIL.Emit(OpCodes.Ldfld, yField)
            Case "GetZ"
               mthdIL.Emit(OpCodes.Ldfld, zField)
         End Select
         
         mthdIL.Emit(OpCodes.Ret)
      Next mthdName 
      ' Finally, we create the type.
      pointType = pointTypeBld.CreateType()
      
      ' Let's save it, just for posterity.
      myAsmBuilder.Save("Point.dll")
      
      Return pointType
   End Function 'DynamicPointTypeGen
    
   
   Public Shared Sub Main()
      
      Dim myDynamicType As Type = Nothing
      Dim aPoint As Object = Nothing
      Dim aPtypes() As Type = {GetType(Integer), GetType(Integer), GetType(Integer)}
      Dim aPargs() As Object = {4, 5, 6}
      
      ' Call the  method to build our dynamic class.
      myDynamicType = DynamicPointTypeGen()
      
      Console.WriteLine("Some information about my new Type '{0}':", myDynamicType.FullName)
      Console.WriteLine("Assembly: '{0}'", myDynamicType.Assembly)
      Console.WriteLine("Attributes: '{0}'", myDynamicType.Attributes)
      Console.WriteLine("Module: '{0}'", myDynamicType.Module)
      Console.WriteLine("Members: ")
      Dim member As MemberInfo
      For Each member In  myDynamicType.GetMembers()
         Console.WriteLine("-- {0} {1};", member.MemberType, member.Name)
      Next member
      
      Console.WriteLine("---")
      
      ' Let's take a look at the constructor we created.
      Dim myDTctor As ConstructorInfo = myDynamicType.GetConstructor(aPtypes)
      Console.WriteLine("Constructor: {0};", myDTctor.ToString())
      
      Console.WriteLine("---")
      
      ' Now, we get to use our dynamically-created class by invoking the constructor. 
      aPoint = myDTctor.Invoke(aPargs)
      Console.WriteLine("aPoint is type {0}.", aPoint.GetType())
      
      
      ' Finally, let's reflect on the instance of our new type - aPoint - and
      ' make sure everything proceeded according to plan.
      Console.WriteLine("aPoint.x = {0}", myDynamicType.InvokeMember("GetX", BindingFlags.InvokeMethod, Nothing, aPoint, New Object() {}))
      Console.WriteLine("aPoint.y = {0}", myDynamicType.InvokeMember("GetY", BindingFlags.InvokeMethod, Nothing, aPoint, New Object() {}))
      Console.WriteLine("aPoint.z = {0}", myDynamicType.InvokeMember("GetZ", BindingFlags.InvokeMethod, Nothing, aPoint, New Object() {}))
   End Sub 'Main
End Class 'TestCtorBuilder



' +++ OUTPUT +++
' Some information about my new Type 'Point':
' Assembly: 'MyDynamicAssembly, Version=0.0.0.0'
' Attributes: 'AutoLayout, AnsiClass, NotPublic, Public'
' Module: 'PointModule'
' Members: 
' -- Field x;
' -- Field y;
' -- Field z;
' -- Method GetHashCode;
' -- Method Equals;
' -- Method ToString;
' -- Method GetType;
' -- Constructor .ctor;
' ---
' Constructor: Void .ctor(Int32, Int32, Int32);
' ---
' aPoint is type Point.
' aPoint.x = 4
' aPoint.y = 5
' aPoint.z = 6

' </Snippet1>
