Public Class MyTraceSource
    Inherits TraceSource
    Private firstAttribute As String = ""
    Private secondAttribute As String = ""

    Public Sub New(ByVal n As String)
        MyBase.New(n)

    End Sub 'New 

    Public Property FirstTraceSourceAttribute() As String
        Get
            Dim de As DictionaryEntry
            For Each de In Me.Attributes
                If de.Key.ToString().ToLower() = "firsttracesourceattribute" Then
                    firstAttribute = de.Value.ToString()
                End If
            Next de
            Return firstAttribute
        End Get
        Set(ByVal value As String)
            firstAttribute = value
        End Set
    End Property

    Public Property SecondTraceSourceAttribute() As String
        Get
            Dim de As DictionaryEntry
            For Each de In Me.Attributes
                If de.Key.ToString().ToLower() = "secondtracesourceattribute" Then
                    secondAttribute = de.Value.ToString()
                End If
            Next de
            Return secondAttribute
        End Get
        Set(ByVal value As String)
            secondAttribute = Value
        End Set
    End Property

    Protected Overrides Function GetSupportedAttributes() As String()
        ' Allow the use of the attributes in the configuration file.
        Return New String() {"FirstTraceSourceAttribute", "SecondTraceSourceAttribute"}

    End Function 'GetSupportedAttributes
End Class 'MyTraceSource 