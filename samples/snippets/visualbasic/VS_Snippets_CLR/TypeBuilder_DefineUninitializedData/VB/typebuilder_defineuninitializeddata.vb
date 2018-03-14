' System.Reflection.Emit.TypeBuilder.DefineUninitializedData(string,int,FieldAttributes)
' The following program demonstrates the 'DefineUninitializedData'
' method of 'TypeBuilder' class. It builds an assembly by defining 'MyHelloWorld' type and
' it has 'MyGreeting' field. Then it displays the initial value of 'MyGreeting'
' field to the console.

' <Snippet1>
Imports System
Imports System.Threading
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Runtime.InteropServices


Module Example

   Sub Main()
      Dim myHelloWorldType As Type = CreateCallee(Thread.GetDomain())
      Dim myHelloWorldInstance As Object = Activator.CreateInstance(myHelloWorldType)
      Dim myGreetingFieldInfo As FieldInfo = myHelloWorldType.GetField("MyGreeting")
      Dim oval As Object = Activator.CreateInstance(myGreetingFieldInfo.FieldType)
      Dim myIntPtr As IntPtr = Marshal.AllocHGlobal(4)
      Dim rand As New Random()
      Dim iTempSeed As Integer = rand.Next()
      Dim bINITBYTE As Byte() = GetRandBytes(iTempSeed, 4)
      Dim intptrTemp As IntPtr = myIntPtr
      Dim j As Integer
      For j = 0 To 3
         Marshal.WriteByte(myIntPtr, bINITBYTE(j))
         myIntPtr = intptr.op_Explicit(myIntPtr.ToInt32 + 1)
      Next j
      myIntPtr = intptrTemp
      Dim oValNew As [Object] = Marshal.PtrToStructure(myIntPtr, myGreetingFieldInfo.FieldType)
      Marshal.FreeHGlobal(myIntPtr)

      myIntPtr = Marshal.AllocHGlobal(4)
      Dim myObj As Object = myGreetingFieldInfo.GetValue(myHelloWorldInstance)
      Marshal.StructureToPtr(myObj, myIntPtr, True)
      intptrTemp = myIntPtr
      Console.WriteLine("The value of 'MyGreeting' field : ")

      For j = 0 To 3
         Marshal.WriteByte(myIntPtr, bINITBYTE(j))
         Console.WriteLine(bINITBYTE(j))
         myIntPtr = intptr.op_Explicit(myIntPtr.ToInt32 + 1)
      Next j
   End Sub 'Main


   Private Function GetRandBytes(ByVal iRandSeed As Integer, ByVal iSize As Integer) As Byte()
      Dim barr(iSize) As Byte
      Dim randTemp As New Random(iRandSeed)
      randTemp.NextBytes(barr)
      Return barr
   End Function 'GetRandBytes


   ' Create the callee transient dynamic assembly.
   Private Function CreateCallee(ByVal myDomain As AppDomain) As Type
      ' Create a simple name for the callee assembly.
      Dim myAssemblyName As New AssemblyName()
      myAssemblyName.Name = "EmittedClass"

      ' Create the callee dynamic assembly.
      Dim myAssembly As AssemblyBuilder = myDomain.DefineDynamicAssembly(myAssemblyName, AssemblyBuilderAccess.Run)


      ' Create a dynamic module in the callee assembly.
      Dim myModule As ModuleBuilder = myAssembly.DefineDynamicModule("EmittedModule")

      ' Define a public class named "MyHelloWorld"
      Dim myHelloWorldType As TypeBuilder = myModule.DefineType("MyHelloWorld", TypeAttributes.Public)

      ' Define a 'MyGreeting' field and initialize it.
      Dim myFieldBuilder As FieldBuilder = myHelloWorldType.DefineUninitializedData("MyGreeting", 4, FieldAttributes.Public)

      ' Create the 'MyHelloWorld' class.
      Return myHelloWorldType.CreateType()
   End Function 'CreateCallee

End Module
' </Snippet1>