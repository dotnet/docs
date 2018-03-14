' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Reflection

Module Example
   Public Sub Main()
      Dim t As New TestClass()  
      Console.WriteLine(t.GetValue())
      t.Value = 10
      Console.WriteLine(t.Value)
      Console.WriteLine()
      
      Dim tg As New Test(Of Integer)(200)
      Console.WriteLine(tg.GetValue())
      Dim b = tg.ConvertValue(Of Byte)()
      Console.WriteLine("{0} -> {1} ({2})", tg.GetValue().GetType().Name,
                        b, b.GetType().Name)
                                            
                                             
   End Sub
End Module

Public Class TestClass
   Private _value As Nullable(Of Integer)
   
   Public Sub New()
      Dim m As MethodBase = MethodBase.GetCurrentMethod()
      Console.WriteLine("   Executing {0}.{1}", 
                        m.ReflectedType.Name, m.Name)
   End Sub
   
   Public Sub New(value As Integer)
      Dim m As MethodBase = MethodBase.GetCurrentMethod()
      Console.WriteLine("   Executing {0}.{1}", 
                        m.ReflectedType.Name, m.Name)
      _value = value
   End Sub
   
   Public Property Value As Integer
      Get
         Dim m As MethodBase = MethodBase.GetCurrentMethod()
         Console.WriteLine("   Executing {0}.{1}", 
                           m.ReflectedType.Name, m.Name)
         Return _value.GetValueOrDefault()
      End Get
      Set
         Dim m As MethodBase = MethodBase.GetCurrentMethod()
         Console.WriteLine("   Executing {0}.{1}", 
                           m.ReflectedType.Name, m.Name)
         _value = value
      End Set
   End Property
   
   Public Function GetValue() As Integer
      Dim m As MethodBase = MethodBase.GetCurrentMethod()
      Console.WriteLine("   Executing {0}.{1}", 
                        m.ReflectedType.Name, m.Name)
      Return Me.Value
   End Function
End Class

Public Class Test(Of T)
   Private value As T
   
   Public Sub New(value As T)
      Dim m As MethodBase = MethodBase.GetCurrentMethod()
      Console.WriteLine("   Executing {0}.{1}", 
                        m.ReflectedType.Name, m.Name)
      Me.value = value
   End Sub
   
   Public Function GetValue() As T
      Dim m As MethodBase = MethodBase.GetCurrentMethod()
      Console.WriteLine("   Executing {0}.{1}", 
                        m.ReflectedType.Name, m.Name)
      Return value
   End Function
   
   Public Function ConvertValue(Of Y)() As Y
      Dim m As MethodBase = MethodBase.GetCurrentMethod()
      Console.WriteLine("   Executing {0}.{1}", 
                        m.ReflectedType.Name, m.Name)
      Console.Write("      Generic method: {0}, definition: {1}, Args: ", 
                        m.IsGenericMethod, m.IsGenericMethodDefinition)
      If m.IsGenericMethod Then
         For Each arg In m.GetGenericArguments()
            Console.Write("{0} ", arg.Name)
         Next
      End If
      Console.WriteLine()
      Try
         Return CType(Convert.ChangeType(value, GetType(Y)), Y)
      Catch e As OverflowException
         Throw 
      Catch e As InvalidCastException
         Throw
      End Try   
   End Function   
End Class
' The example displays the following output:
'       Executing TestClass..ctor
'       Executing TestClass.GetValue
'       Executing TestClass.get_Value
'       0
'       Executing TestClass.set_Value
'       Executing TestClass.get_Value
'       10
'       
'       Executing Test`1..ctor
'       Executing Test`1.GetValue
'       200
'       Executing Test`1.ConvertValue
'             Generic method: True, definition: True, Args: Y
'       Executing Test`1.GetValue
'       Int32 -> 200 (Byte)
' </Snippet1>
