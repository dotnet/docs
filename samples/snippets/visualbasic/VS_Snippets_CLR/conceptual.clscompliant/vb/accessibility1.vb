' Visual Basic .NET Document
Option Strict On

' <Snippet28>
<Assembly: CLSCompliant(True)>

Public Class Animal
    Private _species As String

    Public Sub New(species As String)
        _species = species
    End Sub

    Public Overridable ReadOnly Property Species As String
        Get
            Return _species
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return _species
    End Function
End Class

Public Class Human : Inherits Animal
    Private _name As String

    Public Sub New(name As String)
        MyBase.New("Homo Sapiens")
        _name = name
    End Sub

    Public ReadOnly Property Name As String
        Get
            Return _name
        End Get
    End Property

    Private Overrides ReadOnly Property Species As String
        Get
            Return MyBase.Species
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return _name
    End Function
End Class

Public Module Example
    Public Sub Main()
        Dim p As New Human("John")
        Console.WriteLine(p.Species)
        Console.WriteLine(p.ToString())
    End Sub
End Module
' The example displays the following output:
'     'Private Overrides ReadOnly Property Species As String' cannot override 
'     'Public Overridable ReadOnly Property Species As String' because
'      they have different access levels.
' 
'         Private Overrides ReadOnly Property Species As String
' </Snippet28>
