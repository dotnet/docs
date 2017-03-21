Public Class MyMethodTracingSwitch
    Inherits Switch
    Protected outExit As Boolean
    Protected outEnter As Boolean
    Protected myLevel As MethodTracingSwitchLevel
    
    Public Sub New(displayName As String, description As String)
        MyBase.New(displayName, description)
    End Sub 'New


    Public Property Level() As MethodTracingSwitchLevel
        Get
            Return myLevel
        End Get
        Set
            SetSwitchSetting(CInt(value))
        End Set
    End Property


    Protected Sub SetSwitchSetting(value As Integer)
        If value < 0 Then
            value = 0
        End If
        If value > 3 Then
            value = 3
        End If

        myLevel = CType(value, MethodTracingSwitchLevel)

        outEnter = False
        If value = CInt(MethodTracingSwitchLevel.EnteringMethod) Or _
            value = CInt(MethodTracingSwitchLevel.Both) Then

            outEnter = True
        End If

        outExit = False
        If value = CInt(MethodTracingSwitchLevel.ExitingMethod) Or _
            value = CInt(MethodTracingSwitchLevel.Both) Then

            outExit = True
        End If
    End Sub 'SetSwitchSetting


    Public ReadOnly Property OutputExit() As Boolean
        Get
            Return outExit
        End Get
    End Property


    Public ReadOnly Property OutputEnter() As Boolean
        Get
            Return outEnter
        End Get
    End Property
End Class 'MyMethodTracingSwitch
