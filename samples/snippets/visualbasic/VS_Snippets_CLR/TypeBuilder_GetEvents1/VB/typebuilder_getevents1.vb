' System.Reflection.Emit.TypeBuilder.GetEvents(BindingFlags)

' The program demonstrates the 'GetEvents(BindingFlags)' method of the 'TypeBuilder' class.
' It builds an assembly by defining 'HelloWorld' type and creates a 'Click' and
' 'MouseUp' events on the type. Then displays all events to the Console.

' <Snippet1>
Imports System
Imports System.Threading
Imports System.Reflection
Imports System.Reflection.Emit

Public Class MyApplication

   Delegate Sub MyEvent(temp As Object)

   Public Shared Sub Main()
      Dim helloWorldClass As TypeBuilder = CreateCallee(Thread.GetDomain())

      Dim info As EventInfo() = helloWorldClass.GetEvents(BindingFlags.Public Or _
                                                          BindingFlags.Instance)
      Console.WriteLine("'HelloWorld' type has following events :")
      Dim i As Integer
      For i = 0 To info.Length - 1
         Console.WriteLine(info(i).Name)
      Next i
   End Sub 'Main

   ' Create the callee transient dynamic assembly.
   Private Shared Function CreateCallee(myDomain As AppDomain) As TypeBuilder
      Dim myAssemblyName As New AssemblyName()
      myAssemblyName.Name = "EmittedAssembly"

      ' Create the callee dynamic assembly.
      Dim myAssembly As AssemblyBuilder = myDomain.DefineDynamicAssembly _
                                          (myAssemblyName, AssemblyBuilderAccess.Run)
      ' Create a dynamic module named "CalleeModule" in the callee
      Dim myModule As ModuleBuilder = myAssembly.DefineDynamicModule("EmittedModule")

      ' Define a public class named "HelloWorld" in the assembly.
      Dim helloWorldClass As TypeBuilder = myModule.DefineType _
                                           ("HelloWorld", TypeAttributes.Public)

      Dim myMethod1 As MethodBuilder = helloWorldClass.DefineMethod _
                    ("OnClick", MethodAttributes.Public, Nothing, New Type() {GetType(Object)})
      Dim methodIL1 As ILGenerator = myMethod1.GetILGenerator()
      methodIL1.Emit(OpCodes.Ret)
      Dim myMethod2 As MethodBuilder = helloWorldClass.DefineMethod _
                   ("OnMouseUp", MethodAttributes.Public, Nothing, New Type() {GetType(Object)})
      Dim methodIL2 As ILGenerator = myMethod2.GetILGenerator()
      methodIL2.Emit(OpCodes.Ret)

      ' Create the events.
      Dim myEvent1 As EventBuilder = helloWorldClass.DefineEvent _
                                         ("Click", EventAttributes.None, GetType(MyEvent))
      myEvent1.SetRaiseMethod(myMethod1)
      Dim myEvent2 As EventBuilder = helloWorldClass.DefineEvent _
                                         ("MouseUp", EventAttributes.None, GetType(MyEvent))
      myEvent2.SetRaiseMethod(myMethod2)

      helloWorldClass.CreateType()
      Return helloWorldClass
   End Function 'CreateCallee
End Class 'MyApplication
' </Snippet1>