' <Snippet1>
Imports System
Imports System.Reflection
Imports System.Reflection.Emit

Class DemoMethodBuilder
   
   Public Shared Sub AddMethodDynamically(ByVal myTypeBld As TypeBuilder, _
                                          ByVal mthdName As String, _
                                          ByVal mthdParams() As Type, _
                                          ByVal returnType As Type, _
                                          ByVal mthdAction As String)
      
      Dim myMthdBld As MethodBuilder = myTypeBld.DefineMethod(mthdName, _
                                       MethodAttributes.Public Or MethodAttributes.Static, _
                                       returnType, _
                                       mthdParams)
      
      Dim ILout As ILGenerator = myMthdBld.GetILGenerator()
      
      Dim numParams As Integer = mthdParams.Length
      
      Dim x As Byte
      For x = 0 To numParams - 1
         ILout.Emit(OpCodes.Ldarg_S, x)
      Next x
      
      If numParams > 1 Then
         Dim y As Integer
         For y = 0 To (numParams - 1) - 1
            Select Case mthdAction
               Case "A"
                  ILout.Emit(OpCodes.Add)
               Case "M"
                  ILout.Emit(OpCodes.Mul)
               Case Else
                  ILout.Emit(OpCodes.Add)
            End Select
         Next y
      End If
      ILout.Emit(OpCodes.Ret)
   End Sub 
    
   
   Public Shared Sub Main()
      
      Dim myDomain As AppDomain = AppDomain.CurrentDomain
      Dim asmName As New AssemblyName()
      asmName.Name = "MyDynamicAsm"
      
      Dim myAsmBuilder As AssemblyBuilder = myDomain.DefineDynamicAssembly(asmName, _
                                            AssemblyBuilderAccess.RunAndSave)
      
      Dim myModule As ModuleBuilder = myAsmBuilder.DefineDynamicModule("MyDynamicAsm", _
                                                                       "MyDynamicAsm.dll")
      
      Dim myTypeBld As TypeBuilder = myModule.DefineType("MyDynamicType", TypeAttributes.Public)
      
      ' Get info from the user to build the method dynamically.
      Console.WriteLine("Let's build a simple method dynamically!")
      Console.WriteLine("Please enter a few numbers, separated by spaces.")
      Dim inputNums As String = Console.ReadLine()
      Console.Write("Do you want to [A]dd (default) or [M]ultiply these numbers? ")
      Dim myMthdAction As String = Console.ReadLine().ToUpper()
      Console.Write("Lastly, what do you want to name your new dynamic method? ")
      Dim myMthdName As String = Console.ReadLine()
      
      ' Process inputNums into an array and create a corresponding Type array 
      Dim index As Integer = 0
      Dim inputNumsList As String() = inputNums.Split()
      
      Dim myMthdParams(inputNumsList.Length - 1) As Type
      Dim inputValsList(inputNumsList.Length - 1) As Object
      
      
      Dim inputNum As String
      For Each inputNum In  inputNumsList
         inputValsList(index) = CType(Convert.ToInt32(inputNum), Object)
         myMthdParams(index) = GetType(Integer)
         index += 1
      Next inputNum
      
      ' Now, call the method building method with the parameters, passing the 
      ' TypeBuilder by reference.
      AddMethodDynamically(myTypeBld, myMthdName, myMthdParams, GetType(Integer), myMthdAction)
      
      Dim myType As Type = myTypeBld.CreateType()
     
      Dim description as String 
      If myMthdAction = "M" Then
         description = "multiplying"
      Else
         description = "adding"
      End If

      Console.WriteLine("---")
      Console.WriteLine("The result of {0} the values is: {1}", _
                         description, _
                         myType.InvokeMember(myMthdName, _
                                             BindingFlags.InvokeMethod _
                                               Or BindingFlags.Public _
                                               Or BindingFlags.Static, _
                                             Nothing, _
                                             Nothing, _
                                             inputValsList)) 
      Console.WriteLine("---")

      ' If you are interested in seeing the MSIL generated dynamically for the method
      ' your program generated, change to the directory where you ran the compiled
      ' code sample and type "ildasm MyDynamicAsm.dll" at the prompt. When the list
      ' of manifest contents appears, click on "MyDynamicType" and then on the name of
      ' of the method you provided during execution.
 
      myAsmBuilder.Save("MyDynamicAsm.dll") 

      Dim myMthdInfo As MethodInfo = myType.GetMethod(myMthdName)
      Console.WriteLine("Your Dynamic Method: {0};", myMthdInfo.ToString())
   End Sub 
End Class 

' </Snippet1>
