Option Strict On

' <Snippet5>
Public Module Func
   Public Sub Main()
      ' Note that each lambda expression has no parameters.
      Dim lazyOne As New LazyValue(Of Integer)(Function() ExpensiveOne())
      Dim lazyTwo As New LazyValue(Of Long)(Function() ExpensiveTwo("apple")) 

      Console.WriteLine("LazyValue objects have been created.")

      ' Get the values of the LazyValue objects.
      Console.WriteLine(lazyOne.Value)
      Console.WriteLine(lazyTwo.Value)
   End Sub

   Public Function ExpensiveOne() As Integer
      Console.WriteLine()
      Console.WriteLine("ExpensiveOne() is executing.")
      Return 1
   End Function

   Public Function ExpensiveTwo(input As String) As Long
      Console.WriteLine() 
      Console.WriteLine("ExpensiveTwo() is executing.")
      Return input.Length
   End Function
End Module

Public Class LazyValue(Of T As Structure)
   Private val As Nullable(Of T)
   Private getValue As Func(Of T)

   ' Constructor.
   Public Sub New(func As Func(Of T))
      Me.val = Nothing
      Me.getValue = func
   End Sub

   Public ReadOnly Property Value() As T
      Get
         If Me.val Is Nothing Then
            ' Execute the delegate.
            Me.val = Me.getValue()
         End If   
         Return CType(val, T)
      End Get
   End Property
End Class
' </Snippet5>
