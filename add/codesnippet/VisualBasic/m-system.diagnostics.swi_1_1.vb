Public Class MySourceSwitch
    Inherits SourceSwitch
    Private sourceAttribute As Integer = 0

    Public Sub New(ByVal n As String)
        MyBase.New(n)

    End Sub 'New

    Public Property CustomSourceSwitchAttribute() As Integer
        Get
            Dim de As DictionaryEntry
            For Each de In Me.Attributes
                If de.Key.ToString().ToLower() = "customsourceswitchattribute" Then
                    sourceAttribute = Fix(de.Value)
                End If
            Next de
            Return sourceAttribute
        End Get
        Set(ByVal value As Integer)
            sourceAttribute = Fix(Value)
        End Set
    End Property

    Protected Overrides Function GetSupportedAttributes() As String()
        Return New String() {"customsourceSwitchattribute"}

    End Function 'GetSupportedAttributes
End Class 'MySourceSwitch