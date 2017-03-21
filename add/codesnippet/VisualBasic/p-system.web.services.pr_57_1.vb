Imports System
Imports System.Reflection
Imports System.Web.Services.Protocols
Imports Microsoft.VisualBasic

Public Class MyService
   
   Public Sub MyMethod(inParameter As Integer, ByRef outParameter As Integer)
      outParameter = inParameter
   End Sub 'MyMethod
End Class 'MyService

Public Class LogicalMethodInfo_Create
   
   Public Shared Sub Main()
      Dim myType As Type = GetType(MyService)
      Dim myMethodInfo As MethodInfo = myType.GetMethod("MyMethod")
      Dim myLogicalMethodInfo As LogicalMethodInfo = _
                             LogicalMethodInfo.Create(New MethodInfo() {myMethodInfo})(0)
      
      Console.WriteLine _
        (ControlChars.Newline + "Printing parameters for the method : {0}", myLogicalMethodInfo.Name)
      
      Console.WriteLine _
        (ControlChars.Newline + "The parameters of the method {0} are :" + _
                                           ControlChars.Newline, myLogicalMethodInfo.Name)
      Dim myParameters As ParameterInfo() = myLogicalMethodInfo.Parameters
      Dim i As Integer
      For i = 0 To myParameters.Length - 1
         Console.WriteLine _
         (ControlChars.Tab + myParameters(i).Name + " : " + myParameters(i).ParameterType.toString())
      Next i
      
      Console.WriteLine _
          (ControlChars.Newline + "The in parameters of the method {0} are :" + _
                                               ControlChars.Newline, myLogicalMethodInfo.Name)
      myParameters = myLogicalMethodInfo.InParameters

      For i = 0 To myParameters.Length - 1
         Console.WriteLine(ControlChars.Tab + myParameters(i).Name + " : " + _
                                                   myParameters(i).ParameterType.toString())
      Next i
      
      Console.WriteLine(ControlChars.Newline + "The out parameters of the method {0} are :" + _
                                                    ControlChars.Newline, myLogicalMethodInfo.Name)
      myParameters = myLogicalMethodInfo.OutParameters

      For i = 0 To myParameters.Length - 1
         Console.WriteLine(ControlChars.Tab + myParameters(i).Name + " : " + _
                                                     myParameters(i).ParameterType.toString())
      Next i
      
      If myLogicalMethodInfo.IsVoid Then
         Console.WriteLine(ControlChars.Newline + "The return type is void")
      Else
         Console.WriteLine _
             (ControlChars.Newline + "The return type is {0}", myLogicalMethodInfo.ReturnType)
      End If
   End Sub 'Main 
End Class 'LogicalMethodInfo_Create