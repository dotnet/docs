' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Public Class Automobile
   Private _doors As Integer
   Private _cylinders As String
   Private _year As Integer
   Private _model As String
   
   Public Sub New(model As String, year As Integer, doors As Integer,
                  cylinders As String)
      _model = model
      _year = year
      _doors = doors
      _cylinders = cylinders
   End Sub
   
   Public ReadOnly Property Doors As Integer
      Get
          Return _doors
      End Get
   End Property
   
   Public ReadOnly Property Model As String
      Get
         Return _model
      End Get
   End Property
   
   Public ReadOnly Property Year As Integer
      Get
         Return _year
      End Get
   End Property
   
   Public ReadOnly Property Cylinders As String
      Get
         Return _cylinders
      End Get
   End Property
   
   Public Overrides Function ToString() As String
      Return ToString("G")
   End Function
   
   Public Overloads Function ToString(fmt As String) As String
      If String.IsNullOrEmpty(fmt) Then fmt = "G"
      
      Select Case fmt.ToUpperInvariant()
         Case "G"
            Return String.Format("{0} {1}", _year, _model)
         Case "D"
            Return String.Format("{0} {1}, {2} dr.",
                                 _year, _model, _doors)
         Case "C"
            Return String.Format("{0} {1}, {2}",
                                 _year, _model, _cylinders)
         Case "A"
            Return String.Format("{0} {1}, {2} dr. {3}",
                                 _year, _model, _doors, _cylinders)
         Case Else
            Dim msg As String = String.Format("'{0}' is an invalid format string",
                                              fmt)
            Throw New ArgumentException(msg)
      End Select
   End Function
End Class

Module Example6
    Public Sub Main()
        Dim auto As New Automobile("Lynx", 2016, 4, "V8")
        Console.WriteLine(auto.ToString())
        Console.WriteLine(auto.ToString("A"))
    End Sub
End Module
' The example displays the following output:
'       2016 Lynx
'       2016 Lynx, 4 dr. V8
' </Snippet4>
