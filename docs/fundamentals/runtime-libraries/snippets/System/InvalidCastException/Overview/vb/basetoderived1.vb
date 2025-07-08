' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Public Class Person
   Dim _name As String
   
   Public Property Name As String
      Get
         Return _name
      End Get
      Set
         _name = value
      End Set
   End Property
End Class

Public Class PersonWithID : Inherits Person
   Dim _id As String
   
   Public Property Id As String
      Get
         Return _id
      End Get
      Set
         _id = value
      End Set
   End Property
End Class

Module Example1
    Public Sub Main()
        Dim p As New Person()
        p.Name = "John"
        Try
            Dim pid As PersonWithID = CType(p, PersonWithID)
            Console.WriteLine("Conversion succeeded.")
        Catch e As InvalidCastException
            Console.WriteLine("Conversion failed.")
        End Try

        Dim pid1 As New PersonWithID()
        pid1.Name = "John"
        pid1.Id = "246"
        Dim p1 As Person = pid1

        Try
            Dim pid1a As PersonWithID = CType(p1, PersonWithID)
            Console.WriteLine("Conversion succeeded.")
        Catch e As InvalidCastException
            Console.WriteLine("Conversion failed.")
        End Try

        Dim p2 As Person = Nothing
        Try
            Dim pid2 As PersonWithID = CType(p2, PersonWithID)
            Console.WriteLine("Conversion succeeded.")
        Catch e As InvalidCastException
            Console.WriteLine("Conversion failed.")
        End Try
    End Sub
End Module
' The example displays the following output:
'       Conversion failed.
'       Conversion succeeded.
'       Conversion succeeded.
' </Snippet1>
