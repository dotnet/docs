' Visual Basic .NET Document
Option Strict On

' <Snippet12>
<Assembly: CLSCompliant(True)>

<CLSCompliant(False)> _
Public Class Counter
    Dim ctr As UInt32

    Public Sub New
        ctr = 0
    End Sub

    Protected Sub New(ctr As UInt32)
        ctr = ctr
    End Sub

    Public Overrides Function ToString() As String
        Return String.Format("{0}). ", ctr)
    End Function

    Public ReadOnly Property Value As UInt32
        Get
            Return ctr
        End Get
    End Property

    Public Sub Increment()
        ctr += CType(1, UInt32)
    End Sub
End Class

Public Class NonZeroCounter : Inherits Counter
    Public Sub New(startIndex As Integer)
        MyClass.New(CType(startIndex, UInt32))
    End Sub

    Private Sub New(startIndex As UInt32)
        MyBase.New(CType(startIndex, UInt32))
    End Sub
End Class
' Compilation produces a compiler warning like the following:
'    Type3.vb(34) : warning BC40026: 'NonZeroCounter' is not CLS-compliant 
'    because it derives from 'Counter', which is not CLS-compliant.
'    
'    Public Class NonZeroCounter : Inherits Counter
'                 ~~~~~~~~~~~~~~
' </Snippet12>


Module Example
    Public Sub Main()
        ''      Dim c As New NonZeroCounter(-3)
    End Sub
End Module

