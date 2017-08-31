'------------------------------------------------------------------------------
'<Snippet5>
Imports System
Imports System.Data.SqlTypes
Imports Microsoft.SqlServer.Server

<Serializable()>
<SqlUserDefinedType(Format.Native)>
Public Structure Point
    Implements INullable

    Private m_x As Int32
    Private m_y As Int32
    Private is_Null As Boolean


    Public Property X() As Int32
        Get
            Return (Me.m_x)
        End Get
        Set(ByVal Value As Int32)
            m_x = Value
        End Set
    End Property


    Public Property Y() As Int32
        Get
            Return (Me.m_y)
        End Get
        Set(ByVal Value As Int32)
            m_y = Value
        End Set
    End Property


    Public ReadOnly Property IsNull() As Boolean Implements INullable.IsNull
        Get
            Return is_Null
        End Get
    End Property


    Public Shared ReadOnly Property Null() As Point
        Get
            Dim pt As Point = New Point
            pt.is_Null = True
            Return pt
        End Get
    End Property


    Public Overrides Function ToString() As String
        If Me.IsNull() Then
            Return Nothing
        Else
            Return Me.m_x & ":" & Me.m_y
        End If
    End Function


    Public Shared Function Parse(ByVal s As SqlString) As Point
        If s = SqlString.Null Then
            Return Null
        End If

        If s.ToString() = SqlString.Null.ToString() Then
            Return Null
        End If

        If s.IsNull Then
            Return Null
        End If

        'Parse input string here to separate out coordinates
        Dim str As String = Convert.ToString(s)
        Dim xy() As String = str.Split(":"c)

        Dim pt As New Point()
        pt.X = CType(xy(0), Int32)
        pt.Y = CType(xy(1), Int32)
        Return (pt)
    End Function


    Public Function Quadrant() As SqlString

        If m_x = 0 And m_y = 0 Then
            Return "centered"
        End If

        Dim stringResult As String = ""

        Select Case m_x
            Case 0
                stringResult = "center"
            Case Is > 0
                stringResult = "right"
            Case Is < 0
                stringResult = "left"
        End Select

        Select Case m_y
            Case 0
                stringResult = stringResult & " center"
            Case Is > 0
                stringResult = stringResult & " top"
            Case Is < 0
                stringResult = stringResult & " bottom"
        End Select

        Return stringResult
    End Function
End Structure
'</Snippet5>


'------------------------------------------------------------------------------
'<Snippet12>
<SqlUserDefinedType(Format.Native, MaxByteSize:=8000)>
Public Class SampleType

   '...
End Class
'</Snippet12>
