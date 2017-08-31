Option Explicit On
Option Strict On

Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        '        SetFormTitle()
        '       SetFormIcon()
        '      SetFormBackgroundImage()
        '     PlayFormGreeting()
        ShowLocalizedMessage()
    End Sub

#Region " MySettings "

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' b0bc737e-50d1-43d1-a6df-268db6e6f91c
        ' How to: Create Property Grids for User Settings in Visual Basic

        ' <snippet11>
        PropertyGrid1.SelectedObject = My.Settings
        ' </snippet11>

        ' <snippet12>
        ' Attribute for the user-scope settings.
        Dim userAttr As New System.Configuration.UserScopedSettingAttribute
        Dim attrs As New System.ComponentModel.AttributeCollection(userAttr)
        PropertyGrid1.BrowsableAttributes = attrs
        ' </snippet12>
    End Sub


    ' 0e5e6415-b6e2-4602-9be0-a65fa167d007
    ' How to: Persist User Settings in Visual Basic
    ' <snippet5>
    Sub ChangeAndPersistSettings()
        My.Settings.LastChanged = Today
        My.Settings.Save()
    End Sub
    ' </snippet5>

    ' 41250181-c594-4854-9988-8183b9eb03cf
    ' How to: Change User Settings in Visual Basic
    ' <snippet7>
    Sub ChangeNickname(ByVal newNickname As String)
        My.Settings.Nickname = newNickname
    End Sub
    ' </snippet7>

    ' eb3428ef-115e-49a8-a878-e0613183fee0
    ' How to: Read Application Settings in Visual Basic
    ' <snippet14>
    Sub ShowNickname()
        MsgBox("Nickname is " & My.Settings.Nickname)
    End Sub
    ' </snippet14>
#End Region

#Region " MyResources "

    '<snippet1>
    Sub SetFormTitle()
        Me.Text = My.Resources.Form1Title
    End Sub
    '</snippet1>

    ' 34c3f2dc-7b87-432c-9d5f-17ea666bb266
    ' My.Resources Object
    '<snippet2>
    Sub SetFormIcon()
        Me.Icon = My.Resources.Form1Icon
    End Sub
    '</snippet2>

    '<snippet3>
    Sub SetFormBackgroundImage()
        Me.BackgroundImage = My.Resources.Form1Background
    End Sub
    '</snippet3>

    '<snippet4>
    Sub PlayFormGreeting()
        My.Computer.Audio.Play(My.Resources.Form1Greeting, 
            AudioPlayMode.Background)
    End Sub
    '</snippet4>

    ' a484f1e9-8de0-4bef-802e-d4083263e99f
    ' How to: Retrieve Localized Resources in Visual Basic
    ' <snippet10>
    Sub ShowLocalizedMessage()
        Dim culture As String = My.Application.UICulture.Name
        My.Application.ChangeUICulture("fr-FR")
        MsgBox(My.Resources.Message)
        My.Application.ChangeUICulture(culture)
    End Sub
    ' </snippet10>

#End Region

End Class




