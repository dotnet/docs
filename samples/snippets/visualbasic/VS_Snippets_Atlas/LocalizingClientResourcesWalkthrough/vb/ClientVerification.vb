' <Snippet2>
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Resources

Public Class ClientVerification
    Inherits Control

    Private _button As Button
    Private _firstLabel As Label
    Private _secondLabel As Label
    Private _answer As TextBox
    Private _firstInt As Int32
    Private _secondInt As Int32


    Protected Overrides Sub CreateChildControls()
        Dim random = New Random()
        _firstInt = random.Next(0, 20)
        _secondInt = random.Next(0, 20)

        Dim rm = New ResourceManager("LocalizingScriptResources.VerificationResources", Me.GetType().Assembly)
        Controls.Clear()

        _firstLabel = New Label()
        _firstLabel.ID = "firstNumber"
        _firstLabel.Text = _firstInt.ToString()

        _secondLabel = New Label()
        _secondLabel.ID = "secondNumber"
        _secondLabel.Text = _secondInt.ToString()

        _answer = New TextBox()
        _answer.ID = "userAnswer"

        _button = New Button()
        _button.ID = "Button"
        _button.Text = rm.GetString("Verify")
        _button.OnClientClick = "return CheckAnswer();"

        Controls.Add(_firstLabel)
        Controls.Add(New LiteralControl(" + "))
        Controls.Add(_secondLabel)
        Controls.Add(New LiteralControl(" = "))
        Controls.Add(_answer)
        Controls.Add(_button)
    End Sub

End Class
' </Snippet2>