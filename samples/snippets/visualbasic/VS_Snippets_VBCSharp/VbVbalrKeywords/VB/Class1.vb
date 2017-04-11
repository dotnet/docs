Public Class Class1


  '****************************************************************************
  '<Snippet6>
  Function PrintTypeCode(ByVal obj As Object) As String
      Dim objAsConvertible As IConvertible = TryCast(obj, IConvertible)
      If objAsConvertible Is Nothing Then
          Return obj.ToString() & " does not implement IConvertible"
      Else
          Return "Type code is " & objAsConvertible.GetTypeCode()
      End If
  End Function
  '</Snippet6>


  '****************************************************************************
  '<Snippet5>
  Function updateSales(ByVal thisSale As Decimal) As Decimal
      Static totalSales As Decimal = 0
      totalSales += thisSale
      Return totalSales
  End Function
  '</Snippet5>


  '****************************************************************************
  '<Snippet4>
  Class employee
      ' Only code inside class employee can change the value of hireDateValue.
      Private hireDateValue As Date
      ' Any code that can access class employee can read property dateHired.
      Public ReadOnly Property dateHired() As Date
          Get
              Return hireDateValue
          End Get
      End Property
  End Class
  '</Snippet4>


  '****************************************************************************
  '<Snippet3>
  Partial Public Class sampleClass
      Public Sub sub1()
      End Sub
  End Class
  Partial Public Class sampleClass
      Public Sub sub2()
      End Sub
  End Class
  '</Snippet3>


  '****************************************************************************
  '<Snippet2>
  Public MustInherit Class shape
      Public acrossLine As Double
      Public MustOverride Function area() As Double
  End Class
  Public Class circle : Inherits shape
      Public Overrides Function area() As Double
          Return Math.PI * acrossLine
      End Function
  End Class
  Public Class square : Inherits shape
      Public Overrides Function area() As Double
          Return acrossLine * acrossLine
      End Function
  End Class
  Public Class consumeShapes
      Public Sub makeShapes()
          Dim shape1, shape2 As shape
          shape1 = New circle
          shape2 = New square
      End Sub
  End Class
  '</Snippet2>


  '****************************************************************************
  Shared Function Test() As Integer

    '<Snippet1>
    Dim q As Object = 2.37
    Dim i As Integer = CType(q, Integer)
    ' The following conversion fails at run time
    Dim j As Integer = DirectCast(q, Integer)
    Dim f As New System.Windows.Forms.Form
    Dim c As System.Windows.Forms.Control
    ' The following conversion succeeds.
    c = DirectCast(f, System.Windows.Forms.Control)
    '</Snippet1>

    Return 0
  End Function


  Class System

    Class Windows
      Class Forms
        '******************
        Class Form
        End Class
        '******************
        Class Control
          Inherits Form

          Sub New()
          End Sub

          Sub New(ByVal s As String)
          End Sub
        End Class
        '******************
      End Class
    End Class
  End Class
End Class
